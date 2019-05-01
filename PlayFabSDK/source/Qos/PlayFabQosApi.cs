namespace PlayFab.QoS
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using EventsModels;
    using Internal;
    using MultiplayerModels;

    public class PlayFabQosApi
    {
        private const int DefaultTimeoutMs = 250;
        private readonly Dictionary<AzureRegion, string> _dataCenterMap = new Dictionary<AzureRegion, string>();
        private readonly Action<string> _logAction;

        public PlayFabQosApi(Action<string> logAction = null)
        {
            _logAction = logAction;
        }

        public async Task<QosResult> GetQoSResultAsync(int timeoutMs = DefaultTimeoutMs)
        {
            QosResult result = await GetResultAsync(timeoutMs);
            if (result.ErrorCode != 0)
            {
                return result;
            }

            bool eventSent = await SendResultsToPlayFab(result);
            if (!eventSent)
            {
                result.ErrorCode = -3;
            }

            return result;
        }

        private async Task<QosResult> GetResultAsync(int timeoutMs)
        {
            var result = new QosResult();

            if (!PlayFabClientAPI.IsClientLoggedIn())
            {
                LogQos("Client is not logged in");
                result.ErrorCode = -1;
                return result;
            }

            // get datacenter map (call thunderhead)
            await GetQoSServerList();

            int serverCount = _dataCenterMap.Count;
            if (serverCount < 0)
            {
                result.ErrorCode = -2;
                return result;
            }

            // ping servers
            result.RegionResults = await GetSortedRegionLatencies(timeoutMs);
            result.ErrorCode = 0;
            return result;
        }

        private async Task GetQoSServerList()
        {
            if (_dataCenterMap.Count > 0)
            {
                // If the dataCenterMap is already initialized, return
                return;
            }

            var request = new ListQosServersRequest();
            PlayFabResult<ListQosServersResponse> response = await PlayFabMultiplayerAPI.ListQosServersAsync(request);
            
            if (response?.Error != null)
            {
                LogQos("Could not get the server list from thunderhead\n Error : " + response.Error.ErrorMessage);
            }

            foreach (QosServer qosServer in response.Result.QosServers)
            {
                if (!qosServer.Region.HasValue)
                {
                    continue;
                }

                _dataCenterMap[qosServer.Region.Value] = qosServer.ServerUrl;
            }
        }

        private async Task<List<QosRegionResult>> GetSortedRegionLatencies(int timeoutMs)
        {
            List<Task<QosRegionResult>> asyncPingResults = _dataCenterMap.Select(async kvp =>
            {
                var regionPinger = new RegionPinger(kvp.Value, kvp.Key);
                return await regionPinger.PingAsync(timeoutMs);
            }).ToList();

            await Task.WhenAll(asyncPingResults);
            return asyncPingResults.Select(t => t.Result).OrderBy(t => t.LatencyMs).ToList();
        }

        private async Task<bool> SendResultsToPlayFab(QosResult result)
        {
            var eventContents = new EventContents
            {
                Name = "qos_result",
                EventNamespace = "playfab.servers.qos",
                Payload = result
            };

            var writeEventsRequest = new WriteEventsRequest
            {
                Events = new List<EventContents> {eventContents}
            };

            PlayFabResult<WriteEventsResponse> response = null;
            try
            {
                response = await WriteTelemetryAsync(writeEventsRequest);
            }
            catch (Exception exception)
            {
                LogQos(exception.ToString());
                return false;
            }

            if (response == null || response.Error != null)
            {
                LogQos(response?.Error.ErrorMessage);
                return false;
            }

            return true;
        }

        private static async Task<PlayFabResult<WriteEventsResponse>> WriteTelemetryAsync(WriteEventsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            if ((request?.AuthenticationContext?.EntityToken ?? PlayFabSettings.staticPlayer.EntityToken) == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Event/WriteTelemetryEvents", request, "X-EntityToken", PlayFabSettings.staticPlayer.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<WriteEventsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<WriteEventsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<WriteEventsResponse> { Result = result, CustomData = customData };
        }

        private void LogQos(string message)
        {
            _logAction?.Invoke(message);
        }
    }
}
