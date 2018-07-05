#if NETFX_CORE && XAMARIN

using PlayFab.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace PlayFab.Internal
{
    public class PlayFabWinHttp : IPlayFabHttp
    {
        private readonly HttpClient _client = new HttpClient();
        private ISerializerPlugin _serializer;

        public PlayFabSysHttp()
        {
            _serializer = (ISerializerPlugin)PluginManager.Instance.GetPlugin(PluginContract.Serializer);
            if (_serializer == null)
            {
                _serializer = new PlayFabSerializer();
                PluginManager.Instance.SetPlugin(PluginContract.Serializer, _serializer);
            }
        }

        public async Task<object> DoPost(string urlPath, PlayFabRequestCommon request, string authType, string authKey, Dictionary<string, string> extraHeaders)
        {
            var fullUrl = PlayFabSettings.GetFullUrl(urlPath);
            string bodyString;

            if (request == null)
            {
                bodyString = "{}";
            }
            else
            {
                bodyString = _serializer.SerializeObject(request);
            }

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, new Uri(fullUrl));
            requestMessage.Content = new HttpStringContent(bodyString, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json");
            if (authType != null)
                requestMessage.Headers.Add(new KeyValuePair<string, string>(authType, authKey));
            requestMessage.Headers.Add(new KeyValuePair<string, string>("X-PlayFabSDK", PlayFabSettings.SdkVersionString));
            if (extraHeaders != null)
                foreach (var headerPair in extraHeaders)
                    requestMessage.Headers.Add(headerPair);

            HttpResponseMessage httpResponse;
            string httpResponseString;
            try
            {
                httpResponse = await _client.SendRequestAsync(requestMessage);
                httpResponseString = await httpResponse.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                return new PlayFabError
                {
                    Error = PlayFabErrorCode.ConnectionError,
                    ErrorMessage = e.Message
                };
            }

            if (!httpResponse.IsSuccessStatusCode)
            {
                var error = new PlayFabError();

                if (string.IsNullOrEmpty(httpResponseString) || httpResponse.StatusCode == HttpStatusCode.NotFound)
                {
                    error.HttpCode = (int)httpResponse.StatusCode;
                    error.HttpStatus = httpResponse.StatusCode.ToString();
                    return error;
                }

                PlayFabJsonError errorResult;
                try
                {
                    errorResult = _serializer.DeserializeObject<PlayFabJsonError>(httpResponseString);
                }
                catch (Exception e)
                {
                    error.HttpCode = (int)httpResponse.StatusCode;
                    error.HttpStatus = httpResponse.StatusCode.ToString();
                    error.Error = PlayFabErrorCode.JsonParseError;
                    error.ErrorMessage = e.Message;
                    return error;
                }

                error.HttpCode = errorResult.code;
                error.HttpStatus = errorResult.status;
                error.Error = (PlayFabErrorCode)errorResult.errorCode;
                error.ErrorMessage = errorResult.errorMessage;
                error.ErrorDetails = errorResult.errorDetails;
                return error;
            }

            if (string.IsNullOrEmpty(httpResponseString))
            {
                return new PlayFabError
                {
                    Error = PlayFabErrorCode.Unknown,
                    ErrorMessage = "Internal server error"
                };
            }

            return httpResponseString;
        }
    }
}
#endif
