using System.Collections.Generic;
using System.Text;

namespace PlayFab
{
    public class PlayFabApiSettings
    {
        public readonly Dictionary<string, string> RequestGetParams = new Dictionary<string, string> {
            { "sdk", PlayFabSettings.SdkVersionString }
        };
        /// <summary> This is only for customers running a private cluster.  Generally you shouldn't touch this </summary>
        public string ProductionEnvironmentUrl = PlayFabSettings.DefaultProductionEnvironmentUrl;
        /// <summary> The name of a customer vertical. This is only for customers running a private cluster.  Generally you shouldn't touch this </summary>
        public string VerticalName = null;

#if ENABLE_PLAYFABSERVER_API || ENABLE_PLAYFABADMIN_API || ENABLE_PLAYFAB_SECRETKEY
        /// <summary> You must set this value for PlayFabSdk to work properly (Found in the Game Manager for your title, at the PlayFab Website) </summary>
        public string DeveloperSecretKey = null;
#endif

        /// <summary> You must set this value for PlayFabSdk to work properly (Found in the Game Manager for your title, at the PlayFab Website) </summary>
        public string TitleId;

        /// <summary> Set to enable Gzip compression on all responses. Defaults to false. </summary>
        public bool CompressResponses = false;


        public virtual string GetFullUrl(string apiCall)
        {
            return PlayFabSettings.GetFullUrl(apiCall, RequestGetParams, this);
        }
    }
}
