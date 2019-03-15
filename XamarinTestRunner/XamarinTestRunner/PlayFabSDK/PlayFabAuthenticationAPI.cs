#if !DISABLE_PLAYFABENTITY_API

using PlayFab.AuthenticationModels;
using PlayFab.Internal;
using PlayFab.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayFab
{
    /// <summary>
    /// The Authentication APIs provide a convenient way to convert classic authentication responses into entity authentication
    /// models. These APIs will provide you with the entity authentication token needed for subsequent Entity API calls.
    /// </summary>
    public class PlayFabAuthenticationAPI
    {
        /// <summary>
        /// Method to exchange a legacy AuthenticationTicket or title SecretKey for an Entity Token or to refresh a still valid
        /// Entity Token.
        /// </summary>
        public static async Task<PlayFabResult<GetEntityTokenResponse>> GetEntityTokenAsync(GetEntityTokenRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            string authKey = null, authValue = null;
#if !DISABLE_PLAYFABCLIENT_API
            var context = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket != null) { authKey = "X-Authorization"; authValue = clientSessionTicket; }
#endif

#if ENABLE_PLAYFABSERVER_API || ENABLE_PLAYFABADMIN_API
            var developerSecretKey = PlayFabSettings.staticSettings.DeveloperSecretKey;
            if (developerSecretKey != null) { authKey = "X-SecretKey"; authValue = developerSecretKey; }
#endif

#if !DISABLE_PLAYFABENTITY_API
            var entityToken = request?.AuthenticationContext?.EntityToken ?? PlayFabSettings.staticPlayer.EntityToken;
            if (entityToken != null) { authKey = "X-EntityToken"; authValue = entityToken; }
#endif

            var httpResult = await PlayFabHttp.DoPost("/Authentication/GetEntityToken", request, authKey, authValue, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetEntityTokenResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetEntityTokenResponse>>(resultRawJson);
            var result = resultData.data;
            PlayFabSettings.staticPlayer.EntityToken = result.EntityToken;

            return new PlayFabResult<GetEntityTokenResponse> { Result = result, CustomData = customData };
        }

    }
}
#endif
