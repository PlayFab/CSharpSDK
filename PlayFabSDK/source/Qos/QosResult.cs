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
    internal class QosResultFacade
    {
        public static QosResultFacade CreateFrom(QosResult result)
        {
            return new QosResultFacade
            {
                RegionResults = new List<QosRegionResult>(result.RegionResults),
                ErrorCode = result.ErrorCode
            };
        }

        public List<QosRegionResult> RegionResults { get; set; }

        public int ErrorCode { get; set; }
    }
}
#endif
