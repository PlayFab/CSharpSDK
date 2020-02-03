#if !DISABLE_PLAYFABCLIENT_API && !DISABLE_PLAYFABENTITY_API
namespace PlayFab.QoS
{
    using EventsModels;
    using MultiplayerModels;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class PlayFabQosApi
    {
        private readonly PlayFabAuthenticationContext _authContext;
        private const int DefaultPingsPerRegion = 10;
        private const int DefaultDegreeOfParallelism = 4;
        private const int NumTimeoutsForError = 3;
        private const int DefaultTimeoutMs = 250;
        
        private readonly PlayFabMultiplayerInstanceAPI multiplayerApi;
        private readonly PlayFabEventsInstanceAPI eventsApi;

        private Dictionary<string, string> _dataCenterMap;

        public PlayFabQosApi(PlayFabApiSettings settings = null, PlayFabAuthenticationContext authContext = null)
        {
            _authContext = authContext ?? PlayFabSettings.staticPlayer;
            
            multiplayerApi = new PlayFabMultiplayerInstanceAPI(settings, _authContext);
            eventsApi = new PlayFabEventsInstanceAPI(settings, _authContext);
        }
        
#pragma warning disable 4014
        public async Task<QosResult> GetQosResultAsync(
            int timeoutMs = DefaultTimeoutMs, 
            int pingsPerRegion = DefaultPingsPerRegion, 
            int degreeOfParallelism = DefaultDegreeOfParallelism)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            QosResult result = await GetResultAsync(timeoutMs, pingsPerRegion, degreeOfParallelism);
            if (result.ErrorCode != (int)QosErrorCode.Success)
            {
                return result;
            }

            Task.Factory.StartNew(() => SendResultsToPlayFab(result));
            return result;
        }
#pragma warning restore 4014

        private async Task<QosResult> GetResultAsync(int timeoutMs, int pingsPerRegion, int degreeOfParallelism)
        {
            if (!_authContext.IsClientLoggedIn())
            {
                return new QosResult
                {
                    ErrorCode = (int) QosErrorCode.NotLoggedIn, 
                    ErrorMessage = "Client is not logged in"
                };
            }

            Dictionary<string, string> dataCenterMap = await GetQoSServerList();

            if (!(dataCenterMap?.Count > 0))
            {
                return new QosResult
                {
                    ErrorCode = (int) QosErrorCode.FailedToRetrieveServerList,
                    ErrorMessage = "Failed to get server list from PlayFab multiplayer servers"
                };
            }

            return await GetSortedRegionLatencies(timeoutMs, dataCenterMap, pingsPerRegion, degreeOfParallelism);
        }

        private async Task<Dictionary<string,string>> GetQoSServerList()
        {
            if (_dataCenterMap?.Count > 0)
            {
                // If the dataCenterMap is already initialized, return
                return _dataCenterMap;
            }

            var request = new ListQosServersRequest();
            PlayFabResult<ListQosServersResponse> response = await multiplayerApi.ListQosServersAsync(request);

            if (response == null || response.Error != null)
            {
                return null;
            }
            
            var dataCenterMap = new Dictionary<string, string>(response.Result.QosServers.Count);

            foreach (QosServer qosServer in response.Result.QosServers)
            {
                if (string.IsNullOrEmpty(qosServer.Region))
                {
                    continue;
                }

                dataCenterMap[qosServer.Region] = qosServer.ServerUrl;
            }

            return _dataCenterMap = dataCenterMap;
        }

        private async Task<QosResult> GetSortedRegionLatencies(int timeoutMs,
            Dictionary<string, string> dataCenterMap, int pingsPerRegion, int degreeOfParallelism)
        {
            RegionPinger[] regionPingers = dataCenterMap.Select(
                datacenter => new RegionPinger(datacenter.Value, datacenter.Key, timeoutMs, NumTimeoutsForError, pingsPerRegion)).ToArray();

            ConcurrentBag<int> seeds = new ConcurrentBag<int>(Enumerable.Range(0, pingsPerRegion)
                .Select(i => i * dataCenterMap.Count / pingsPerRegion));

            Task[] pingWorkers = Enumerable.Range(0, degreeOfParallelism).Select(
                i => PingWorker(regionPingers, seeds)).ToArray();

            await Task.WhenAll(pingWorkers);

            List<QosRegionResult> results = regionPingers.Select(x => x.GetResult()).ToList();
            results.Sort((x, y) => x.LatencyMs.CompareTo(y.LatencyMs));

            QosErrorCode resultCode = QosErrorCode.Success;
            string errorMessage = null;
            if (results.All(x => x.ErrorCode == (int) QosErrorCode.NoResult))
            {
                resultCode = QosErrorCode.NoResult;
                errorMessage = "No valid results from any QoS server";
            }
            
            return new QosResult()
            {
                ErrorCode = (int) resultCode,
                RegionResults = results,
                ErrorMessage = errorMessage
            };
        }
        
        
        private async Task PingWorker(RegionPinger[] regionPingers, IProducerConsumerCollection<int> seeds)
        {
            while(seeds.TryTake(out int seed))
            {
                for (int i = 0; i < regionPingers.Length; i++)
                {
                    int index = (i + seed) % regionPingers.Length;
                    await regionPingers[index].PingAsync();
                }
            }
        }

        private async Task SendResultsToPlayFab(QosResult result)
        {
            var eventContents = new EventContents
            {
                Name = "qos_result",
                EventNamespace = "playfab.servers",
                Payload = QosResultPlayFabEvent.CreateFrom(result)
            };

            var writeEventsRequest = new WriteEventsRequest
            {
                Events = new List<EventContents> { eventContents }
            };

            await eventsApi.WriteTelemetryEventsAsync(writeEventsRequest);
        }
    }
}

#endif
