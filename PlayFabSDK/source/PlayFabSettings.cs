using System;
using System.Collections.Generic;
using System.Text;

namespace PlayFab
{
    public class PlayFabSettings
    {
        public const string SdkVersion = "1.185.240802";
        public const string BuildIdentifier = "adobuild_csharpsdk_114";
        public const string SdkVersionString = "CSharpSDK-1.185.240802";
        /// <summary> This is only for customers running a private cluster.  Generally you shouldn't touch this </summary>
        public static string DefaultProductionEnvironmentUrl = "playfabapi.com";

        public static ErrorCallback GlobalErrorHandler;

        public readonly static PlayFabApiSettings staticSettings = new PlayFabApiSettings();
        // This field will likely be removed someday
        internal readonly static PlayFabAuthenticationContext staticPlayer = new PlayFabAuthenticationContext();

        #region Deprecated staticSettings redirect properties
        [Obsolete("Moved to PlayFabSettings.staticSettings.RequestGetParams")]
        public static Dictionary<string, string> RequestGetParams { get { return staticSettings.RequestGetParams; } }

        [Obsolete("Moved to PlayFabSettings.staticSettings.ProductionEnvironmentUrl")]
        public static string ProductionEnvironmentUrl { get { return staticSettings.ProductionEnvironmentUrl; } set { staticSettings.ProductionEnvironmentUrl = value; } }

        [Obsolete("Moved to PlayFabSettings.staticSettings.VerticalName")]
        public static string VerticalName { get { return staticSettings.VerticalName; } set { staticSettings.VerticalName = value; } }

#if ENABLE_PLAYFABSERVER_API || ENABLE_PLAYFABADMIN_API || ENABLE_PLAYFAB_SECRETKEY
        [Obsolete("Moved to PlayFabSettings.staticSettings.DeveloperSecretKey")]
        public static string DeveloperSecretKey { get { return staticSettings.DeveloperSecretKey; } set { staticSettings.DeveloperSecretKey = value; } }
#endif

        [Obsolete("Moved to PlayFabSettings.staticSettings.TitleId")]
        public static string TitleId { get { return staticSettings.TitleId; } set { staticSettings.TitleId = value; } }
        #endregion Deprecated staticSettingsredirect properties

#if !NET45 && !NETSTANDARD2_0 && !UNITY_EDITOR && !UNITY_STANDALONE
        private static string _localApiServer;
#endif

        public static string LocalApiServer
        {
            get
            {
#if NET45 || NETSTANDARD2_0 || UNITY_EDITOR || UNITY_STANDALONE
                return PlayFabUtil.GetLocalSettingsFile().LocalApiServer;
#else
                return _localApiServer;
#endif
            }
#if !NET45 && !NETSTANDARD2_0 && !UNITY_EDITOR && !UNITY_STANDALONE
            set
            {
                _localApiServer = value;
            }
#endif
        }

        public static string GetFullUrl(string apiCall, Dictionary<string, string> getParams, PlayFabApiSettings instanceSettings = null)
        {
            StringBuilder sb = new StringBuilder(1000);

            var apiSettings = instanceSettings ?? staticSettings;
            var baseUrl = apiSettings?.ProductionEnvironmentUrl;


                if (!baseUrl.StartsWith("http"))
                {
                    sb.Append("https://");
                    if (!string.IsNullOrEmpty(apiSettings?.TitleId))
                    {
                        sb.Append(apiSettings.TitleId).Append(".");
                    }
                    if (!string.IsNullOrEmpty(apiSettings?.VerticalName))
                    {
                        sb.Append(apiSettings?.VerticalName).Append(".");
                    }
                }


            sb.Append(baseUrl).Append(apiCall);

            if (getParams != null)
            {
                bool firstParam = true;
                foreach (var paramPair in getParams)
                {
                    if (firstParam)
                    {
                        sb.Append("?");
                        firstParam = false;
                    }
                    else
                    {
                        sb.Append("&");
                    }
                    sb.Append(paramPair.Key).Append("=").Append(paramPair.Value);
                }
            }

            return sb.ToString();
        }
    }
}
