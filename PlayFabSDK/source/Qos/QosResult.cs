#if !DISABLE_PLAYFABCLIENT_API && !DISABLE_PLAYFABENTITY_API
namespace PlayFab.QoS
{
    using System.Collections.Generic;

    public class QosResult
    {
        public List<QosRegionResult> RegionResults { get; set; }

        public int ErrorCode { get; set; }

        public string ErrorMessage { get; set; }
    }

    /// <summary>
    /// This class is used to json serialize the content to send to PlayFab without the ErrorMessage
    /// </summary>
    internal class QosResultPlayFabEvent
    {
        public static QosResultPlayFabEvent CreateFrom(QosResult result)
        {
            return new QosResultPlayFabEvent
            {
                RegionResults = result.RegionResults.ConvertAll(x => new QosRegionResultSummary()
                {
                    Region = x.Region,
                    ErrorCode = x.ErrorCode,
                    LatencyMs = x.LatencyMs
                }),
                ErrorCode = result.ErrorCode
            };
        }

        public List<QosRegionResultSummary> RegionResults { get; set; }

        public int ErrorCode { get; set; }
    }
}
#endif
