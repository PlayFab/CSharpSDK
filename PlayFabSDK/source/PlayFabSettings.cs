using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

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

		const string ProductionEnvironmentURL = ".playfabapi.com";
		public static string LogicServerURL = null;
        public static string TitleId { get; set; }
		public static ErrorCallback GlobalErrorHandler  { get; set; }
		public static string DeveloperSecretKey = null;
		
		public static string GetURL()
		{
            if (string.IsNullOrWhiteSpace(TitleId))
                throw new InvalidOperationException("PlayFabSettings.TitleId must be initialized to the value of your title's ID before making API requests.");

			string baseUrl = ProductionEnvironmentURL;
			if(baseUrl.StartsWith("http"))
				return baseUrl;
			return "https://"+TitleId+baseUrl;
		}
		
		public static string GetLogicURL()
		{
			return LogicServerURL;
		}
	}
}