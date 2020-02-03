
#if !DISABLE_PLAYFABCLIENT_API && !DISABLE_PLAYFABENTITY_API
namespace PlayFab.QoS
{
    using System.Collections.Generic;
    
    public class QosRegionResult
    {
        public string Region { get; set; }

        public int LatencyMs { get; set; }
        
        public IReadOnlyList<int> RawMeasurements { get; set; }

        public int NumTimeouts { get; set; }

        public int ErrorCode { get; set; }
    }
    
    internal class QosRegionResultSummary
    {
        public static QosRegionResultSummary CreateFrom(QosRegionResult result)
        {
            return new QosRegionResultSummary
            {
                Region = result.Region,
                LatencyMs = result.LatencyMs,
                ErrorCode = result.ErrorCode
            };
        }

        public string Region;

        public int LatencyMs;

        public int ErrorCode;
    }
}
#endif
