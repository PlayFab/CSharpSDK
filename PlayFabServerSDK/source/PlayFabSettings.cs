using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PlayFab
{
    public class PlayFabSettings
    {
        public static JsonSerializerSettings JsonSettings = new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore,
            Converters = { new IsoDateTimeConverter() { DateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFF'Z'" } },
        };
        public static Formatting JsonFormatting = Formatting.None;

        public static bool UseDevelopmentEnvironment = false;
        public static string DevelopmentEnvironmentURL = ".playfabsandbox.com";
        public static string ProductionEnvironmentURL = ".playfabapi.com";
        public static string TitleId; // You must set this value for PlayFabSdk to work properly (Found in the Game Manager for your title, at the PlayFab Website)
        public static ErrorCallback GlobalErrorHandler;
        public static string DeveloperSecretKey = null; // You must set this value for PlayFabSdk to work properly (Found in the Game Manager for your title, at the PlayFab Website)

        public static string GetURL()
        {
            string baseUrl = UseDevelopmentEnvironment ? DevelopmentEnvironmentURL : ProductionEnvironmentURL;
            if (baseUrl.StartsWith("http"))
                return baseUrl;
            return "https://" + TitleId + baseUrl;
        }
    }
}
