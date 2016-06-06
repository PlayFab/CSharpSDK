using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PlayFab
{
    public class PlayFabSettings
    {
        public static string SdkVersion = "0.26.160523";
        public static string BuildIdentifier = "jbuild_csharpsdk_1183";
        public static string SdkVersionString = "CSharpSDK-0.26.160523";

        public static bool UseDevelopmentEnvironment = false;
        public static string DevelopmentEnvironmentUrl = ".playfabsandbox.com";
        public static string ProductionEnvironmentUrl = ".playfabapi.com";
        public static string TitleId; // You must set this value for PlayFabSdk to work properly (Found in the Game Manager for your title, at the PlayFab Website)
        public static ErrorCallback GlobalErrorHandler;
        public static string DeveloperSecretKey = null; // You must set this value for PlayFabSdk to work properly (Found in the Game Manager for your title, at the PlayFab Website)

        public static string GetFullUrl(string apiCall)
        {
            {
                string baseUrl = UseDevelopmentEnvironment ? DevelopmentEnvironmentUrl : ProductionEnvironmentUrl;
                if (baseUrl.StartsWith("http"))
                    return baseUrl;
                return "https://" + TitleId + baseUrl + apiCall;
            }
        }
    }
}
