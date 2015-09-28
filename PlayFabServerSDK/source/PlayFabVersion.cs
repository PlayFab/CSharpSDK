
namespace PlayFab.Internal
{
	public class PlayFabVersion
	{
		public static string ApiRevision = "1.6.20150928";
		public static string SdkRevision = "1.0.2";

		public static string getVersionString()
		{
			return "CSharpSDK-" + SdkRevision + "-" + ApiRevision;
		}
	}
}

