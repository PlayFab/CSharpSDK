
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
}
#endif
