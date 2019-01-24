using System.Collections.Generic;
using System.Text;

namespace PlayFab
{
    public class PlayFabSettings
    {
        public const string SdkVersion = "1.43.190123";
        public const string BuildIdentifier = "jbuild_csharpsdk__sdk-genericslave-1_2";
        public const string SdkVersionString = "CSharpSDK-1.43.190123";
        public static readonly Dictionary<string, string> RequestGetParams = new Dictionary<string, string> {
            { "sdk", SdkVersionString }
        };

        /// <summary> This is only for customers running a private cluster.  Generally you shouldn't touch this </summary>
        public static string ProductionEnvironmentUrl = ".playfabapi.com";
        /// <summary> The name of a customer vertical. This is only for customers running a private cluster.  Generally you shouldn't touch this </summary>
        public static string VerticalName = null;
        /// <summary> Session token for Entity API. Auto-Populated by GetEntityToken method. </summary>
        internal static string EntityToken = null;
        /// <summary> Session ticket for Client API. Auto-Populated by any login or registration call. </summary>
        internal static string ClientSessionTicket = null;
        /// <summary> You must set this value for PlayFabSdk to work properly (Found in the Game Manager for your title, at the PlayFab Website) </summary>
        public static string DeveloperSecretKey = null;
        /// <summary> You must set this value for PlayFabSdk to work properly (Found in the Game Manager for your title, at the PlayFab Website) </summary>
        public static string TitleId;
        public static ErrorCallback GlobalErrorHandler;

        public static string GetFullUrl(string apiCall, Dictionary<string, string> getParams)
        {
            StringBuilder sb = new StringBuilder(1000);
        
            var baseUrl = ProductionEnvironmentUrl;
            if (!baseUrl.StartsWith("http"))
            {
                if (VerticalName != null)
                {
                    sb.Append("https://").Append(VerticalName);
                }
                else
                {
                    sb.Append("https://").Append(TitleId);
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
