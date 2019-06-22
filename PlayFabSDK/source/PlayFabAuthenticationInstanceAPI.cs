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
    /// models. These APIs will provide you with the entity authentication token needed for subsequent Entity API calls. Manage
    /// API keys for authenticating any entity.
    /// </summary>
    public class PlayFabAuthenticationInstanceAPI
    {
        private PlayFabApiSettings apiSettings = null;
        private PlayFabAuthenticationContext authenticationContext = null;

        public PlayFabAuthenticationInstanceAPI()
        {

        }

        public PlayFabAuthenticationInstanceAPI(PlayFabApiSettings settings = null)
        {
            apiSettings = settings;
        }

        public PlayFabAuthenticationInstanceAPI(PlayFabAuthenticationContext context = null)
        {
            authenticationContext = context;
        }

        public PlayFabAuthenticationInstanceAPI(PlayFabApiSettings settings = null, PlayFabAuthenticationContext context = null)
        {
            apiSettings = settings;
            authenticationContext = context;
        }

        public void SetSettings(PlayFabApiSettings settings)
        {
            apiSettings = settings;
        }

        public PlayFabApiSettings GetSettings()
        {
            return apiSettings;
        }

        public void SetAuthenticationContext(PlayFabAuthenticationContext context)
        {
            authenticationContext = context;
        }

        public PlayFabAuthenticationContext GetAuthenticationContext()
        {
            return authenticationContext;
        }

        /// <summary>
        /// Method to exchange a legacy AuthenticationTicket or title SecretKey for an Entity Token or to refresh a still valid
        /// Entity Token.
        /// </summary>
        public async Task<PlayFabResult<GetEntityTokenResponse>> GetEntityTokenAsync(GetEntityTokenRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            string authKey = null, authValue = null;
#if !DISABLE_PLAYFABCLIENT_API
            var clientSessionTicket = request?.AuthenticationContext?.ClientSessionTicket ?? authenticationContext.ClientSessionTicket;
            if (clientSessionTicket != null) { authKey = "X-Authorization"; authValue = clientSessionTicket; }
#endif

#if ENABLE_PLAYFABSERVER_API || ENABLE_PLAYFABADMIN_API
            var settings = apiSettings ?? PlayFabSettings.staticSettings; var developerSecretKey = settings.DeveloperSecretKey;
            if (developerSecretKey != null) { authKey = "X-SecretKey"; authValue = developerSecretKey; }
#endif

#if !DISABLE_PLAYFABENTITY_API
            var entityToken = request?.AuthenticationContext?.EntityToken ?? authenticationContext.EntityToken;
            if (entityToken != null) { authKey = "X-EntityToken"; authValue = entityToken; }
#endif

            var httpResult = await PlayFabHttp.DoPost("/Authentication/GetEntityToken", request, authKey, authValue, extraHeaders, apiSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetEntityTokenResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetEntityTokenResponse>>(resultRawJson);
            var result = resultData.data;
            var updateContext = authenticationContext;
            updateContext.EntityToken = result.EntityToken;
            updateContext.EntityId = result.Entity.Id;
            updateContext.EntityType = result.Entity.Type;

            return new PlayFabResult<GetEntityTokenResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Method for a server to validate a client provided EntityToken. Only callable by the title entity.
        /// </summary>
        public async Task<PlayFabResult<ValidateEntityTokenResponse>> ValidateEntityTokenAsync(ValidateEntityTokenRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            if ((request?.AuthenticationContext?.EntityToken ?? authenticationContext.EntityToken) == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Authentication/ValidateEntityToken", request, "X-EntityToken", authenticationContext.EntityToken, extraHeaders, apiSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ValidateEntityTokenResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ValidateEntityTokenResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ValidateEntityTokenResponse> { Result = result, CustomData = customData };
        }

    }
}
#endif
