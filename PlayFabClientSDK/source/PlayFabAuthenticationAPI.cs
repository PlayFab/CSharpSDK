using PlayFab.AuthenticationModels;
using PlayFab.Internal;
using PlayFab.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayFab
{
    /// <summary>
    /// The Authentication API group is currently in-progress. The current GetEntityToken method is a stop-gap to convert
    /// another authentication into an Entity Authentication. See https://api.playfab.com/documentation/client#Authentication
    /// for the other authentication methods.
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
            if (PlayFabSettings.ClientSessionTicket != null) { authKey = "X-Authorization"; authValue = PlayFabSettings.ClientSessionTicket; }
            if (PlayFabSettings.DeveloperSecretKey != null) { authKey = "X-SecretKey"; authValue = PlayFabSettings.DeveloperSecretKey; }
            if (PlayFabSettings.EntityToken != null) { authKey = "X-EntityToken"; authValue = PlayFabSettings.EntityToken; }

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
            PlayFabSettings.EntityToken = result.EntityToken;

            return new PlayFabResult<GetEntityTokenResponse> { Result = result, CustomData = customData };
        }

    }
}
