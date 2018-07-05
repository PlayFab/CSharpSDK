using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayFab.Internal
{
    /// <summary>
    /// This is a base-class for all Api-request objects.
    /// It is currently unfinished, but we will add result-specific properties,
    ///   and add template where-conditions to make some code easier to follow
    /// </summary>
    public class PlayFabRequestCommon
    {
    }

    /// <summary>
    /// This is a base-class for all Api-result objects.
    /// It is currently unfinished, but we will add result-specific properties,
    ///   and add template where-conditions to make some code easier to follow
    /// </summary>
    public class PlayFabResultCommon
    {
    }

    public class PlayFabJsonError
    {
        public int code;
        public string status;
        public string error;
        public int errorCode;
        public string errorMessage;
        public Dictionary<string, string[]> errorDetails = null;
    }

    public class PlayFabJsonSuccess<TResult> where TResult : PlayFabResultCommon
    {
        public int code;
        public string status;
        public TResult data;
    }

    public static class PlayFabHttp
    {
        private static ITransportPlugin _transport;

        public static async Task<object> DoPost(string urlPath, PlayFabRequestCommon request, string authType, string authKey, Dictionary<string, string> extraHeaders)
        {
            if (PlayFabSettings.TitleId == null)
                throw new Exception("You must set your titleId before making an api call");
            if (_transport == null)
                _transport = GetTransport();

            return await _transport.DoPost(urlPath, request, authType, authKey, extraHeaders);
        }

        private static ITransportPlugin GetTransport()
        {
            var transport = (ITransportPlugin)PluginManager.Instance.GetPlugin(PluginContract.Transport);
            if (transport == null)
            {
                transport = new PlayFabTransport();
                PluginManager.Instance.SetPlugin(PluginContract.Transport, transport);
            }

            return transport;
        }
    }
}
