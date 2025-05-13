#if !DISABLE_PLAYFABENTITY_API

using PlayFab.AddonModels;
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
    /// APIs for managing addons.
    /// </summary>
    public class PlayFabAddonInstanceAPI
    {
        public readonly PlayFabApiSettings apiSettings = null;
        public readonly PlayFabAuthenticationContext authenticationContext = null;

        public PlayFabAddonInstanceAPI(PlayFabAuthenticationContext context)
        {
            if (context == null)
                throw new PlayFabException(PlayFabExceptionCode.AuthContextRequired, "Context cannot be null, create a PlayFabAuthenticationContext for each player in advance, or get <PlayFabClientInstanceAPI>.authenticationContext");
            authenticationContext = context;
        }

        public PlayFabAddonInstanceAPI(PlayFabApiSettings settings, PlayFabAuthenticationContext context)
        {
            if (context == null)
                throw new PlayFabException(PlayFabExceptionCode.AuthContextRequired, "Context cannot be null, create a PlayFabAuthenticationContext for each player in advance, or get <PlayFabClientInstanceAPI>.authenticationContext");
            apiSettings = settings;
            authenticationContext = context;
        }

        /// <summary>
        /// Verify entity login.
        /// </summary>
        public bool IsEntityLoggedIn()
        {
            return authenticationContext == null ? false : authenticationContext.IsEntityLoggedIn();
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
        /// Creates the Apple addon on a title, or updates it if it already exists.
        /// </summary>
        public async Task<PlayFabResult<CreateOrUpdateAppleResponse>> CreateOrUpdateAppleAsync(CreateOrUpdateAppleRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Addon/CreateOrUpdateApple", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<CreateOrUpdateAppleResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<CreateOrUpdateAppleResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<CreateOrUpdateAppleResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Creates the Facebook addon on a title, or updates it if it already exists.
        /// </summary>
        public async Task<PlayFabResult<CreateOrUpdateFacebookResponse>> CreateOrUpdateFacebookAsync(CreateOrUpdateFacebookRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Addon/CreateOrUpdateFacebook", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<CreateOrUpdateFacebookResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<CreateOrUpdateFacebookResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<CreateOrUpdateFacebookResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Creates the Facebook Instant Games addon on a title, or updates it if it already exists.
        /// </summary>
        public async Task<PlayFabResult<CreateOrUpdateFacebookInstantGamesResponse>> CreateOrUpdateFacebookInstantGamesAsync(CreateOrUpdateFacebookInstantGamesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Addon/CreateOrUpdateFacebookInstantGames", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<CreateOrUpdateFacebookInstantGamesResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<CreateOrUpdateFacebookInstantGamesResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<CreateOrUpdateFacebookInstantGamesResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Creates the Google addon on a title, or updates it if it already exists.
        /// </summary>
        public async Task<PlayFabResult<CreateOrUpdateGoogleResponse>> CreateOrUpdateGoogleAsync(CreateOrUpdateGoogleRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Addon/CreateOrUpdateGoogle", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<CreateOrUpdateGoogleResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<CreateOrUpdateGoogleResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<CreateOrUpdateGoogleResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Creates the Kongregate addon on a title, or updates it if it already exists.
        /// </summary>
        public async Task<PlayFabResult<CreateOrUpdateKongregateResponse>> CreateOrUpdateKongregateAsync(CreateOrUpdateKongregateRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Addon/CreateOrUpdateKongregate", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<CreateOrUpdateKongregateResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<CreateOrUpdateKongregateResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<CreateOrUpdateKongregateResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Creates the Nintendo addon on a title, or updates it if it already exists.
        /// </summary>
        public async Task<PlayFabResult<CreateOrUpdateNintendoResponse>> CreateOrUpdateNintendoAsync(CreateOrUpdateNintendoRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Addon/CreateOrUpdateNintendo", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<CreateOrUpdateNintendoResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<CreateOrUpdateNintendoResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<CreateOrUpdateNintendoResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Creates the PSN addon on a title, or updates it if it already exists.
        /// </summary>
        public async Task<PlayFabResult<CreateOrUpdatePSNResponse>> CreateOrUpdatePSNAsync(CreateOrUpdatePSNRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Addon/CreateOrUpdatePSN", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<CreateOrUpdatePSNResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<CreateOrUpdatePSNResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<CreateOrUpdatePSNResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Creates the Steam addon on a title, or updates it if it already exists.
        /// </summary>
        public async Task<PlayFabResult<CreateOrUpdateSteamResponse>> CreateOrUpdateSteamAsync(CreateOrUpdateSteamRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Addon/CreateOrUpdateSteam", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<CreateOrUpdateSteamResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<CreateOrUpdateSteamResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<CreateOrUpdateSteamResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Creates the ToxMod addon on a title, or updates it if it already exists.
        /// </summary>
        public async Task<PlayFabResult<CreateOrUpdateToxModResponse>> CreateOrUpdateToxModAsync(CreateOrUpdateToxModRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Addon/CreateOrUpdateToxMod", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<CreateOrUpdateToxModResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<CreateOrUpdateToxModResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<CreateOrUpdateToxModResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Creates the Twitch addon on a title, or updates it if it already exists.
        /// </summary>
        public async Task<PlayFabResult<CreateOrUpdateTwitchResponse>> CreateOrUpdateTwitchAsync(CreateOrUpdateTwitchRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Addon/CreateOrUpdateTwitch", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<CreateOrUpdateTwitchResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<CreateOrUpdateTwitchResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<CreateOrUpdateTwitchResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Deletes the Apple addon on a title.
        /// </summary>
        public async Task<PlayFabResult<DeleteAppleResponse>> DeleteAppleAsync(DeleteAppleRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Addon/DeleteApple", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<DeleteAppleResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<DeleteAppleResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<DeleteAppleResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Deletes the Facebook addon on a title.
        /// </summary>
        public async Task<PlayFabResult<DeleteFacebookResponse>> DeleteFacebookAsync(DeleteFacebookRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Addon/DeleteFacebook", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<DeleteFacebookResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<DeleteFacebookResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<DeleteFacebookResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Deletes the Facebook addon on a title.
        /// </summary>
        public async Task<PlayFabResult<DeleteFacebookInstantGamesResponse>> DeleteFacebookInstantGamesAsync(DeleteFacebookInstantGamesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Addon/DeleteFacebookInstantGames", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<DeleteFacebookInstantGamesResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<DeleteFacebookInstantGamesResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<DeleteFacebookInstantGamesResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Deletes the Google addon on a title.
        /// </summary>
        public async Task<PlayFabResult<DeleteGoogleResponse>> DeleteGoogleAsync(DeleteGoogleRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Addon/DeleteGoogle", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<DeleteGoogleResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<DeleteGoogleResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<DeleteGoogleResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Deletes the Kongregate addon on a title.
        /// </summary>
        public async Task<PlayFabResult<DeleteKongregateResponse>> DeleteKongregateAsync(DeleteKongregateRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Addon/DeleteKongregate", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<DeleteKongregateResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<DeleteKongregateResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<DeleteKongregateResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Deletes the Nintendo addon on a title.
        /// </summary>
        public async Task<PlayFabResult<DeleteNintendoResponse>> DeleteNintendoAsync(DeleteNintendoRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Addon/DeleteNintendo", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<DeleteNintendoResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<DeleteNintendoResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<DeleteNintendoResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Deletes the PSN addon on a title.
        /// </summary>
        public async Task<PlayFabResult<DeletePSNResponse>> DeletePSNAsync(DeletePSNRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Addon/DeletePSN", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<DeletePSNResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<DeletePSNResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<DeletePSNResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Deletes the Steam addon on a title.
        /// </summary>
        public async Task<PlayFabResult<DeleteSteamResponse>> DeleteSteamAsync(DeleteSteamRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Addon/DeleteSteam", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<DeleteSteamResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<DeleteSteamResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<DeleteSteamResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Deletes the ToxMod addon on a title.
        /// </summary>
        public async Task<PlayFabResult<DeleteToxModResponse>> DeleteToxModAsync(DeleteToxModRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Addon/DeleteToxMod", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<DeleteToxModResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<DeleteToxModResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<DeleteToxModResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Deletes the Twitch addon on a title.
        /// </summary>
        public async Task<PlayFabResult<DeleteTwitchResponse>> DeleteTwitchAsync(DeleteTwitchRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Addon/DeleteTwitch", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<DeleteTwitchResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<DeleteTwitchResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<DeleteTwitchResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Gets information of the Apple addon on a title, omits secrets.
        /// </summary>
        public async Task<PlayFabResult<GetAppleResponse>> GetAppleAsync(GetAppleRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Addon/GetApple", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetAppleResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetAppleResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetAppleResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Gets information of the Facebook addon on a title, omits secrets.
        /// </summary>
        public async Task<PlayFabResult<GetFacebookResponse>> GetFacebookAsync(GetFacebookRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Addon/GetFacebook", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetFacebookResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetFacebookResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetFacebookResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Gets information of the Facebook Instant Games addon on a title, omits secrets.
        /// </summary>
        public async Task<PlayFabResult<GetFacebookInstantGamesResponse>> GetFacebookInstantGamesAsync(GetFacebookInstantGamesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Addon/GetFacebookInstantGames", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetFacebookInstantGamesResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetFacebookInstantGamesResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetFacebookInstantGamesResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Gets information of the Google addon on a title, omits secrets.
        /// </summary>
        public async Task<PlayFabResult<GetGoogleResponse>> GetGoogleAsync(GetGoogleRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Addon/GetGoogle", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetGoogleResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetGoogleResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetGoogleResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Gets information of the Kongregate addon on a title, omits secrets.
        /// </summary>
        public async Task<PlayFabResult<GetKongregateResponse>> GetKongregateAsync(GetKongregateRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Addon/GetKongregate", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetKongregateResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetKongregateResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetKongregateResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Gets information of the Nintendo addon on a title, omits secrets.
        /// </summary>
        public async Task<PlayFabResult<GetNintendoResponse>> GetNintendoAsync(GetNintendoRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Addon/GetNintendo", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetNintendoResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetNintendoResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetNintendoResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Gets information of the PSN addon on a title, omits secrets.
        /// </summary>
        public async Task<PlayFabResult<GetPSNResponse>> GetPSNAsync(GetPSNRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Addon/GetPSN", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetPSNResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetPSNResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetPSNResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Gets information of the Steam addon on a title, omits secrets.
        /// </summary>
        public async Task<PlayFabResult<GetSteamResponse>> GetSteamAsync(GetSteamRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Addon/GetSteam", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetSteamResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetSteamResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetSteamResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Gets information of the ToxMod addon on a title, omits secrets.
        /// </summary>
        public async Task<PlayFabResult<GetToxModResponse>> GetToxModAsync(GetToxModRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Addon/GetToxMod", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetToxModResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetToxModResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetToxModResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Gets information of the Twitch addon on a title, omits secrets.
        /// </summary>
        public async Task<PlayFabResult<GetTwitchResponse>> GetTwitchAsync(GetTwitchRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Addon/GetTwitch", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetTwitchResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetTwitchResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetTwitchResponse> { Result = result, CustomData = customData };
        }

}
}
#endif
