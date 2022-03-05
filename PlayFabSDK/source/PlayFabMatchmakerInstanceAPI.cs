#if ENABLE_PLAYFABSERVER_API

using PlayFab.MatchmakerModels;
using PlayFab.Internal;
#pragma warning disable 0649
using System;
// This is required for the Obsolete Attribute flag
//  which is not always present in all API's
#pragma warning restore 0649
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayFab
{
    /// <summary>
    /// Enables the use of an external match-making service in conjunction with PlayFab hosted Game Server instances
    /// </summary>
    public class PlayFabMatchmakerInstanceAPI
    {
        public readonly PlayFabApiSettings apiSettings = null;
        public readonly PlayFabAuthenticationContext authenticationContext = null;

        public PlayFabMatchmakerInstanceAPI(PlayFabAuthenticationContext context)
        {
            if (context == null)
                throw new PlayFabException(PlayFabExceptionCode.AuthContextRequired, "Context cannot be null, create a PlayFabAuthenticationContext for each player in advance, or get <PlayFabClientInstanceAPI>.authenticationContext");
            authenticationContext = context;
        }

        public PlayFabMatchmakerInstanceAPI(PlayFabApiSettings settings, PlayFabAuthenticationContext context)
        {
            if (context == null)
                throw new PlayFabException(PlayFabExceptionCode.AuthContextRequired, "Context cannot be null, create a PlayFabAuthenticationContext for each player in advance, or get <PlayFabClientInstanceAPI>.authenticationContext");
            apiSettings = settings;
            authenticationContext = context;
        }

        /// <summary>
        /// Clear the Client SessionToken which allows this Client to call API calls requiring login.
        /// A new/fresh login will be required after calling this.
        /// </summary>
        public void ForgetAllCredentials()
        {
            authenticationContext?.ForgetAllCredentials();
        }

        /// <summary>
        /// Validates a user with the PlayFab service
        /// </summary>
        public async Task<PlayFabResult<AuthUserResponse>> AuthUserAsync(AuthUserRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Matchmaker/AuthUser", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<AuthUserResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<AuthUserResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<AuthUserResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Informs the PlayFab game server hosting service that the indicated user has joined the Game Server Instance specified
        /// </summary>
        public async Task<PlayFabResult<PlayerJoinedResponse>> PlayerJoinedAsync(PlayerJoinedRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Matchmaker/PlayerJoined", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<PlayerJoinedResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<PlayerJoinedResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<PlayerJoinedResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Informs the PlayFab game server hosting service that the indicated user has left the Game Server Instance specified
        /// </summary>
        public async Task<PlayFabResult<PlayerLeftResponse>> PlayerLeftAsync(PlayerLeftRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Matchmaker/PlayerLeft", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<PlayerLeftResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<PlayerLeftResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<PlayerLeftResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves the relevant details for a specified user, which the external match-making service can then use to compute
        /// effective matches
        /// </summary>
        public async Task<PlayFabResult<UserInfoResponse>> UserInfoAsync(UserInfoRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Matchmaker/UserInfo", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<UserInfoResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<UserInfoResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<UserInfoResponse> { Result = result, CustomData = customData };
        }

}
}
#endif
