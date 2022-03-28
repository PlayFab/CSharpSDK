#if !DISABLE_PLAYFABENTITY_API && !DISABLE_PLAYFAB_STATIC_API

using PlayFab.MultiplayerModels;
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
    /// API methods for managing multiplayer servers. API methods for managing parties. The lobby service helps players group
    /// together to play multiplayer games. It is often used as a rendezvous point for players to share connection information.
    /// </summary>
    public static class PlayFabMultiplayerAPI
    {
        /// <summary>
        /// Verify entity login.
        /// </summary>
        public static bool IsEntityLoggedIn()
        {
            return PlayFabSettings.staticPlayer.IsEntityLoggedIn();
        }

        /// <summary>
        /// Clear the Client SessionToken which allows this Client to call API calls requiring login.
        /// A new/fresh login will be required after calling this.
        /// </summary>
        public static void ForgetAllCredentials()
        {
            PlayFabSettings.staticPlayer.ForgetAllCredentials();
        }

        /// <summary>
        /// Cancel all active tickets the player is a member of in a given queue.
        /// </summary>
        public static async Task<PlayFabResult<CancelAllMatchmakingTicketsForPlayerResult>> CancelAllMatchmakingTicketsForPlayerAsync(CancelAllMatchmakingTicketsForPlayerRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Match/CancelAllMatchmakingTicketsForPlayer", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<CancelAllMatchmakingTicketsForPlayerResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<CancelAllMatchmakingTicketsForPlayerResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<CancelAllMatchmakingTicketsForPlayerResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Cancel all active backfill tickets the player is a member of in a given queue.
        /// </summary>
        public static async Task<PlayFabResult<CancelAllServerBackfillTicketsForPlayerResult>> CancelAllServerBackfillTicketsForPlayerAsync(CancelAllServerBackfillTicketsForPlayerRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Match/CancelAllServerBackfillTicketsForPlayer", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<CancelAllServerBackfillTicketsForPlayerResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<CancelAllServerBackfillTicketsForPlayerResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<CancelAllServerBackfillTicketsForPlayerResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Cancel a matchmaking ticket.
        /// </summary>
        public static async Task<PlayFabResult<CancelMatchmakingTicketResult>> CancelMatchmakingTicketAsync(CancelMatchmakingTicketRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Match/CancelMatchmakingTicket", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<CancelMatchmakingTicketResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<CancelMatchmakingTicketResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<CancelMatchmakingTicketResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Cancel a server backfill ticket.
        /// </summary>
        public static async Task<PlayFabResult<CancelServerBackfillTicketResult>> CancelServerBackfillTicketAsync(CancelServerBackfillTicketRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Match/CancelServerBackfillTicket", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<CancelServerBackfillTicketResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<CancelServerBackfillTicketResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<CancelServerBackfillTicketResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Creates a multiplayer server build alias.
        /// </summary>
        public static async Task<PlayFabResult<BuildAliasDetailsResponse>> CreateBuildAliasAsync(CreateBuildAliasRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/CreateBuildAlias", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<BuildAliasDetailsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<BuildAliasDetailsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<BuildAliasDetailsResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Creates a multiplayer server build with a custom container.
        /// </summary>
        public static async Task<PlayFabResult<CreateBuildWithCustomContainerResponse>> CreateBuildWithCustomContainerAsync(CreateBuildWithCustomContainerRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/CreateBuildWithCustomContainer", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<CreateBuildWithCustomContainerResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<CreateBuildWithCustomContainerResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<CreateBuildWithCustomContainerResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Creates a multiplayer server build with a managed container.
        /// </summary>
        public static async Task<PlayFabResult<CreateBuildWithManagedContainerResponse>> CreateBuildWithManagedContainerAsync(CreateBuildWithManagedContainerRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/CreateBuildWithManagedContainer", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<CreateBuildWithManagedContainerResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<CreateBuildWithManagedContainerResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<CreateBuildWithManagedContainerResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Creates a multiplayer server build with the server running as a process.
        /// </summary>
        public static async Task<PlayFabResult<CreateBuildWithProcessBasedServerResponse>> CreateBuildWithProcessBasedServerAsync(CreateBuildWithProcessBasedServerRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/CreateBuildWithProcessBasedServer", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<CreateBuildWithProcessBasedServerResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<CreateBuildWithProcessBasedServerResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<CreateBuildWithProcessBasedServerResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Create a lobby.
        /// </summary>
        public static async Task<PlayFabResult<CreateLobbyResult>> CreateLobbyAsync(CreateLobbyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Lobby/CreateLobby", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<CreateLobbyResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<CreateLobbyResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<CreateLobbyResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Create a matchmaking ticket as a client.
        /// </summary>
        public static async Task<PlayFabResult<CreateMatchmakingTicketResult>> CreateMatchmakingTicketAsync(CreateMatchmakingTicketRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Match/CreateMatchmakingTicket", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<CreateMatchmakingTicketResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<CreateMatchmakingTicketResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<CreateMatchmakingTicketResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Creates a remote user to log on to a VM for a multiplayer server build.
        /// </summary>
        public static async Task<PlayFabResult<CreateRemoteUserResponse>> CreateRemoteUserAsync(CreateRemoteUserRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/CreateRemoteUser", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<CreateRemoteUserResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<CreateRemoteUserResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<CreateRemoteUserResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Create a backfill matchmaking ticket as a server. A backfill ticket represents an ongoing game. The matchmaking service
        /// automatically starts matching the backfill ticket against other matchmaking tickets. Backfill tickets cannot match with
        /// other backfill tickets.
        /// </summary>
        public static async Task<PlayFabResult<CreateServerBackfillTicketResult>> CreateServerBackfillTicketAsync(CreateServerBackfillTicketRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Match/CreateServerBackfillTicket", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<CreateServerBackfillTicketResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<CreateServerBackfillTicketResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<CreateServerBackfillTicketResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Create a matchmaking ticket as a server. The matchmaking service automatically starts matching the ticket against other
        /// matchmaking tickets.
        /// </summary>
        public static async Task<PlayFabResult<CreateMatchmakingTicketResult>> CreateServerMatchmakingTicketAsync(CreateServerMatchmakingTicketRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Match/CreateServerMatchmakingTicket", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<CreateMatchmakingTicketResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<CreateMatchmakingTicketResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<CreateMatchmakingTicketResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Creates a request to change a title's multiplayer server quotas.
        /// </summary>
        public static async Task<PlayFabResult<CreateTitleMultiplayerServersQuotaChangeResponse>> CreateTitleMultiplayerServersQuotaChangeAsync(CreateTitleMultiplayerServersQuotaChangeRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/CreateTitleMultiplayerServersQuotaChange", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<CreateTitleMultiplayerServersQuotaChangeResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<CreateTitleMultiplayerServersQuotaChangeResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<CreateTitleMultiplayerServersQuotaChangeResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Deletes a multiplayer server game asset for a title.
        /// </summary>
        public static async Task<PlayFabResult<EmptyResponse>> DeleteAssetAsync(DeleteAssetRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/DeleteAsset", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<EmptyResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<EmptyResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<EmptyResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Deletes a multiplayer server build.
        /// </summary>
        public static async Task<PlayFabResult<EmptyResponse>> DeleteBuildAsync(DeleteBuildRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/DeleteBuild", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<EmptyResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<EmptyResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<EmptyResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Deletes a multiplayer server build alias.
        /// </summary>
        public static async Task<PlayFabResult<EmptyResponse>> DeleteBuildAliasAsync(DeleteBuildAliasRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/DeleteBuildAlias", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<EmptyResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<EmptyResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<EmptyResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Removes a multiplayer server build's region.
        /// </summary>
        public static async Task<PlayFabResult<EmptyResponse>> DeleteBuildRegionAsync(DeleteBuildRegionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/DeleteBuildRegion", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<EmptyResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<EmptyResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<EmptyResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Deletes a multiplayer server game certificate.
        /// </summary>
        public static async Task<PlayFabResult<EmptyResponse>> DeleteCertificateAsync(DeleteCertificateRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/DeleteCertificate", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<EmptyResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<EmptyResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<EmptyResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Deletes a container image repository.
        /// </summary>
        public static async Task<PlayFabResult<EmptyResponse>> DeleteContainerImageRepositoryAsync(DeleteContainerImageRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/DeleteContainerImageRepository", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<EmptyResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<EmptyResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<EmptyResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Delete a lobby.
        /// </summary>
        public static async Task<PlayFabResult<LobbyEmptyResult>> DeleteLobbyAsync(DeleteLobbyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Lobby/DeleteLobby", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<LobbyEmptyResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<LobbyEmptyResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<LobbyEmptyResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Deletes a remote user to log on to a VM for a multiplayer server build.
        /// </summary>
        public static async Task<PlayFabResult<EmptyResponse>> DeleteRemoteUserAsync(DeleteRemoteUserRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/DeleteRemoteUser", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<EmptyResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<EmptyResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<EmptyResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Enables the multiplayer server feature for a title.
        /// </summary>
        public static async Task<PlayFabResult<EnableMultiplayerServersForTitleResponse>> EnableMultiplayerServersForTitleAsync(EnableMultiplayerServersForTitleRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/EnableMultiplayerServersForTitle", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<EnableMultiplayerServersForTitleResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<EnableMultiplayerServersForTitleResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<EnableMultiplayerServersForTitleResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Find lobbies which match certain criteria, and which friends are in.
        /// </summary>
        public static async Task<PlayFabResult<FindFriendLobbiesResult>> FindFriendLobbiesAsync(FindFriendLobbiesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Lobby/FindFriendLobbies", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<FindFriendLobbiesResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<FindFriendLobbiesResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<FindFriendLobbiesResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Find all the lobbies that match certain criteria.
        /// </summary>
        public static async Task<PlayFabResult<FindLobbiesResult>> FindLobbiesAsync(FindLobbiesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Lobby/FindLobbies", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<FindLobbiesResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<FindLobbiesResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<FindLobbiesResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Gets a URL that can be used to download the specified asset. A sample pre-authenticated url -
        /// https://sampleStorageAccount.blob.core.windows.net/gameassets/gameserver.zip?sv=2015-04-05&ss=b&srt=sco&sp=rw&st=startDate&se=endDate&spr=https&sig=sampleSig&api-version=2017-07-29
        /// </summary>
        public static async Task<PlayFabResult<GetAssetDownloadUrlResponse>> GetAssetDownloadUrlAsync(GetAssetDownloadUrlRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/GetAssetDownloadUrl", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetAssetDownloadUrlResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetAssetDownloadUrlResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetAssetDownloadUrlResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Gets the URL to upload assets to. A sample pre-authenticated url -
        /// https://sampleStorageAccount.blob.core.windows.net/gameassets/gameserver.zip?sv=2015-04-05&ss=b&srt=sco&sp=rw&st=startDate&se=endDate&spr=https&sig=sampleSig&api-version=2017-07-29
        /// </summary>
        public static async Task<PlayFabResult<GetAssetUploadUrlResponse>> GetAssetUploadUrlAsync(GetAssetUploadUrlRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/GetAssetUploadUrl", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetAssetUploadUrlResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetAssetUploadUrlResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetAssetUploadUrlResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Gets a multiplayer server build.
        /// </summary>
        public static async Task<PlayFabResult<GetBuildResponse>> GetBuildAsync(GetBuildRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/GetBuild", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetBuildResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetBuildResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetBuildResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Gets a multiplayer server build alias.
        /// </summary>
        public static async Task<PlayFabResult<BuildAliasDetailsResponse>> GetBuildAliasAsync(GetBuildAliasRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/GetBuildAlias", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<BuildAliasDetailsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<BuildAliasDetailsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<BuildAliasDetailsResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Gets the credentials to the container registry.
        /// </summary>
        public static async Task<PlayFabResult<GetContainerRegistryCredentialsResponse>> GetContainerRegistryCredentialsAsync(GetContainerRegistryCredentialsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/GetContainerRegistryCredentials", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetContainerRegistryCredentialsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetContainerRegistryCredentialsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetContainerRegistryCredentialsResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Get a lobby.
        /// </summary>
        public static async Task<PlayFabResult<GetLobbyResult>> GetLobbyAsync(GetLobbyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Lobby/GetLobby", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetLobbyResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetLobbyResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetLobbyResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Get a match.
        /// </summary>
        public static async Task<PlayFabResult<GetMatchResult>> GetMatchAsync(GetMatchRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Match/GetMatch", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetMatchResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetMatchResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetMatchResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// SDK support is limited to C# and Java for this API. Get a matchmaking queue configuration.
        /// </summary>
        public static async Task<PlayFabResult<GetMatchmakingQueueResult>> GetMatchmakingQueueAsync(GetMatchmakingQueueRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Match/GetMatchmakingQueue", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetMatchmakingQueueResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetMatchmakingQueueResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetMatchmakingQueueResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Get a matchmaking ticket by ticket Id.
        /// </summary>
        public static async Task<PlayFabResult<GetMatchmakingTicketResult>> GetMatchmakingTicketAsync(GetMatchmakingTicketRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Match/GetMatchmakingTicket", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetMatchmakingTicketResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetMatchmakingTicketResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetMatchmakingTicketResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Gets multiplayer server session details for a build.
        /// </summary>
        public static async Task<PlayFabResult<GetMultiplayerServerDetailsResponse>> GetMultiplayerServerDetailsAsync(GetMultiplayerServerDetailsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/GetMultiplayerServerDetails", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetMultiplayerServerDetailsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetMultiplayerServerDetailsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetMultiplayerServerDetailsResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Gets multiplayer server logs after a server has terminated.
        /// </summary>
        public static async Task<PlayFabResult<GetMultiplayerServerLogsResponse>> GetMultiplayerServerLogsAsync(GetMultiplayerServerLogsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/GetMultiplayerServerLogs", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetMultiplayerServerLogsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetMultiplayerServerLogsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetMultiplayerServerLogsResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Gets multiplayer server logs after a server has terminated.
        /// </summary>
        public static async Task<PlayFabResult<GetMultiplayerServerLogsResponse>> GetMultiplayerSessionLogsBySessionIdAsync(GetMultiplayerSessionLogsBySessionIdRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/GetMultiplayerSessionLogsBySessionId", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetMultiplayerServerLogsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetMultiplayerServerLogsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetMultiplayerServerLogsResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Get the statistics for a queue.
        /// </summary>
        public static async Task<PlayFabResult<GetQueueStatisticsResult>> GetQueueStatisticsAsync(GetQueueStatisticsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Match/GetQueueStatistics", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetQueueStatisticsResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetQueueStatisticsResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetQueueStatisticsResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Gets a remote login endpoint to a VM that is hosting a multiplayer server build.
        /// </summary>
        public static async Task<PlayFabResult<GetRemoteLoginEndpointResponse>> GetRemoteLoginEndpointAsync(GetRemoteLoginEndpointRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/GetRemoteLoginEndpoint", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetRemoteLoginEndpointResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetRemoteLoginEndpointResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetRemoteLoginEndpointResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Get a matchmaking backfill ticket by ticket Id.
        /// </summary>
        public static async Task<PlayFabResult<GetServerBackfillTicketResult>> GetServerBackfillTicketAsync(GetServerBackfillTicketRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Match/GetServerBackfillTicket", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetServerBackfillTicketResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetServerBackfillTicketResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetServerBackfillTicketResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Gets the status of whether a title is enabled for the multiplayer server feature.
        /// </summary>
        public static async Task<PlayFabResult<GetTitleEnabledForMultiplayerServersStatusResponse>> GetTitleEnabledForMultiplayerServersStatusAsync(GetTitleEnabledForMultiplayerServersStatusRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/GetTitleEnabledForMultiplayerServersStatus", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetTitleEnabledForMultiplayerServersStatusResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetTitleEnabledForMultiplayerServersStatusResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetTitleEnabledForMultiplayerServersStatusResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Gets a title's server quota change request.
        /// </summary>
        public static async Task<PlayFabResult<GetTitleMultiplayerServersQuotaChangeResponse>> GetTitleMultiplayerServersQuotaChangeAsync(GetTitleMultiplayerServersQuotaChangeRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/GetTitleMultiplayerServersQuotaChange", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetTitleMultiplayerServersQuotaChangeResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetTitleMultiplayerServersQuotaChangeResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetTitleMultiplayerServersQuotaChangeResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Gets the quotas for a title in relation to multiplayer servers.
        /// </summary>
        public static async Task<PlayFabResult<GetTitleMultiplayerServersQuotasResponse>> GetTitleMultiplayerServersQuotasAsync(GetTitleMultiplayerServersQuotasRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/GetTitleMultiplayerServersQuotas", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetTitleMultiplayerServersQuotasResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetTitleMultiplayerServersQuotasResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetTitleMultiplayerServersQuotasResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Send a notification to invite a player to a lobby.
        /// </summary>
        public static async Task<PlayFabResult<LobbyEmptyResult>> InviteToLobbyAsync(InviteToLobbyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Lobby/InviteToLobby", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<LobbyEmptyResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<LobbyEmptyResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<LobbyEmptyResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Join an Arranged lobby.
        /// </summary>
        public static async Task<PlayFabResult<JoinLobbyResult>> JoinArrangedLobbyAsync(JoinArrangedLobbyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Lobby/JoinArrangedLobby", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<JoinLobbyResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<JoinLobbyResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<JoinLobbyResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Join a lobby.
        /// </summary>
        public static async Task<PlayFabResult<JoinLobbyResult>> JoinLobbyAsync(JoinLobbyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Lobby/JoinLobby", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<JoinLobbyResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<JoinLobbyResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<JoinLobbyResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Join a matchmaking ticket.
        /// </summary>
        public static async Task<PlayFabResult<JoinMatchmakingTicketResult>> JoinMatchmakingTicketAsync(JoinMatchmakingTicketRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Match/JoinMatchmakingTicket", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<JoinMatchmakingTicketResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<JoinMatchmakingTicketResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<JoinMatchmakingTicketResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Leave a lobby.
        /// </summary>
        public static async Task<PlayFabResult<LobbyEmptyResult>> LeaveLobbyAsync(LeaveLobbyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Lobby/LeaveLobby", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<LobbyEmptyResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<LobbyEmptyResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<LobbyEmptyResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Lists archived multiplayer server sessions for a build.
        /// </summary>
        public static async Task<PlayFabResult<ListMultiplayerServersResponse>> ListArchivedMultiplayerServersAsync(ListMultiplayerServersRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/ListArchivedMultiplayerServers", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ListMultiplayerServersResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ListMultiplayerServersResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ListMultiplayerServersResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Lists multiplayer server game assets for a title.
        /// </summary>
        public static async Task<PlayFabResult<ListAssetSummariesResponse>> ListAssetSummariesAsync(ListAssetSummariesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/ListAssetSummaries", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ListAssetSummariesResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ListAssetSummariesResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ListAssetSummariesResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Lists details of all build aliases for a title. Accepts tokens for title and if game client access is enabled, allows
        /// game client to request list of builds with player entity token.
        /// </summary>
        public static async Task<PlayFabResult<ListBuildAliasesResponse>> ListBuildAliasesAsync(ListBuildAliasesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/ListBuildAliases", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ListBuildAliasesResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ListBuildAliasesResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ListBuildAliasesResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Lists summarized details of all multiplayer server builds for a title. Accepts tokens for title and if game client
        /// access is enabled, allows game client to request list of builds with player entity token.
        /// </summary>
        public static async Task<PlayFabResult<ListBuildSummariesResponse>> ListBuildSummariesV2Async(ListBuildSummariesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/ListBuildSummariesV2", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ListBuildSummariesResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ListBuildSummariesResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ListBuildSummariesResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Lists multiplayer server game certificates for a title.
        /// </summary>
        public static async Task<PlayFabResult<ListCertificateSummariesResponse>> ListCertificateSummariesAsync(ListCertificateSummariesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/ListCertificateSummaries", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ListCertificateSummariesResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ListCertificateSummariesResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ListCertificateSummariesResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Lists custom container images for a title.
        /// </summary>
        public static async Task<PlayFabResult<ListContainerImagesResponse>> ListContainerImagesAsync(ListContainerImagesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/ListContainerImages", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ListContainerImagesResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ListContainerImagesResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ListContainerImagesResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Lists the tags for a custom container image.
        /// </summary>
        public static async Task<PlayFabResult<ListContainerImageTagsResponse>> ListContainerImageTagsAsync(ListContainerImageTagsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/ListContainerImageTags", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ListContainerImageTagsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ListContainerImageTagsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ListContainerImageTagsResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// SDK support is limited to C# and Java for this API. List all matchmaking queue configs.
        /// </summary>
        public static async Task<PlayFabResult<ListMatchmakingQueuesResult>> ListMatchmakingQueuesAsync(ListMatchmakingQueuesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Match/ListMatchmakingQueues", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ListMatchmakingQueuesResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ListMatchmakingQueuesResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ListMatchmakingQueuesResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// List all matchmaking ticket Ids the user is a member of.
        /// </summary>
        public static async Task<PlayFabResult<ListMatchmakingTicketsForPlayerResult>> ListMatchmakingTicketsForPlayerAsync(ListMatchmakingTicketsForPlayerRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Match/ListMatchmakingTicketsForPlayer", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ListMatchmakingTicketsForPlayerResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ListMatchmakingTicketsForPlayerResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ListMatchmakingTicketsForPlayerResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Lists multiplayer server sessions for a build.
        /// </summary>
        public static async Task<PlayFabResult<ListMultiplayerServersResponse>> ListMultiplayerServersAsync(ListMultiplayerServersRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/ListMultiplayerServers", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ListMultiplayerServersResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ListMultiplayerServersResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ListMultiplayerServersResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Lists quality of service servers for party.
        /// </summary>
        public static async Task<PlayFabResult<ListPartyQosServersResponse>> ListPartyQosServersAsync(ListPartyQosServersRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;


            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/ListPartyQosServers", request, null, null, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ListPartyQosServersResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ListPartyQosServersResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ListPartyQosServersResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Lists quality of service servers for the title. By default, servers are only returned for regions where a Multiplayer
        /// Servers build has been deployed.
        /// </summary>
        public static async Task<PlayFabResult<ListQosServersForTitleResponse>> ListQosServersForTitleAsync(ListQosServersForTitleRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/ListQosServersForTitle", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ListQosServersForTitleResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ListQosServersForTitleResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ListQosServersForTitleResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// List all server backfill ticket Ids the user is a member of.
        /// </summary>
        public static async Task<PlayFabResult<ListServerBackfillTicketsForPlayerResult>> ListServerBackfillTicketsForPlayerAsync(ListServerBackfillTicketsForPlayerRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Match/ListServerBackfillTicketsForPlayer", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ListServerBackfillTicketsForPlayerResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ListServerBackfillTicketsForPlayerResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ListServerBackfillTicketsForPlayerResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// List all server quota change requests for a title.
        /// </summary>
        public static async Task<PlayFabResult<ListTitleMultiplayerServersQuotaChangesResponse>> ListTitleMultiplayerServersQuotaChangesAsync(ListTitleMultiplayerServersQuotaChangesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/ListTitleMultiplayerServersQuotaChanges", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ListTitleMultiplayerServersQuotaChangesResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ListTitleMultiplayerServersQuotaChangesResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ListTitleMultiplayerServersQuotaChangesResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Lists virtual machines for a title.
        /// </summary>
        public static async Task<PlayFabResult<ListVirtualMachineSummariesResponse>> ListVirtualMachineSummariesAsync(ListVirtualMachineSummariesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/ListVirtualMachineSummaries", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ListVirtualMachineSummariesResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ListVirtualMachineSummariesResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ListVirtualMachineSummariesResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// SDK support is limited to C# and Java for this API. Remove a matchmaking queue config.
        /// </summary>
        public static async Task<PlayFabResult<RemoveMatchmakingQueueResult>> RemoveMatchmakingQueueAsync(RemoveMatchmakingQueueRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Match/RemoveMatchmakingQueue", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<RemoveMatchmakingQueueResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<RemoveMatchmakingQueueResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<RemoveMatchmakingQueueResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Remove a member from a lobby.
        /// </summary>
        public static async Task<PlayFabResult<LobbyEmptyResult>> RemoveMemberAsync(RemoveMemberFromLobbyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Lobby/RemoveMember", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<LobbyEmptyResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<LobbyEmptyResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<LobbyEmptyResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Request a multiplayer server session. Accepts tokens for title and if game client access is enabled, allows game client
        /// to request a server with player entity token.
        /// </summary>
        public static async Task<PlayFabResult<RequestMultiplayerServerResponse>> RequestMultiplayerServerAsync(RequestMultiplayerServerRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/RequestMultiplayerServer", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<RequestMultiplayerServerResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<RequestMultiplayerServerResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<RequestMultiplayerServerResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Rolls over the credentials to the container registry.
        /// </summary>
        public static async Task<PlayFabResult<RolloverContainerRegistryCredentialsResponse>> RolloverContainerRegistryCredentialsAsync(RolloverContainerRegistryCredentialsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/RolloverContainerRegistryCredentials", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<RolloverContainerRegistryCredentialsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<RolloverContainerRegistryCredentialsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<RolloverContainerRegistryCredentialsResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// SDK support is limited to C# and Java for this API. Create or update a matchmaking queue configuration.
        /// </summary>
        public static async Task<PlayFabResult<SetMatchmakingQueueResult>> SetMatchmakingQueueAsync(SetMatchmakingQueueRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Match/SetMatchmakingQueue", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<SetMatchmakingQueueResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<SetMatchmakingQueueResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<SetMatchmakingQueueResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Shuts down a multiplayer server session.
        /// </summary>
        public static async Task<PlayFabResult<EmptyResponse>> ShutdownMultiplayerServerAsync(ShutdownMultiplayerServerRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/ShutdownMultiplayerServer", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<EmptyResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<EmptyResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<EmptyResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Subscribe to lobby resource notifications.
        /// </summary>
        public static async Task<PlayFabResult<SubscribeToLobbyResourceResult>> SubscribeToLobbyResourceAsync(SubscribeToLobbyResourceRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Lobby/SubscribeToLobbyResource", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<SubscribeToLobbyResourceResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<SubscribeToLobbyResourceResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<SubscribeToLobbyResourceResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Subscribe to match resource notifications.
        /// </summary>
        public static async Task<PlayFabResult<SubscribeToMatchResourceResult>> SubscribeToMatchmakingResourceAsync(SubscribeToMatchResourceRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Match/SubscribeToMatchmakingResource", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<SubscribeToMatchResourceResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<SubscribeToMatchResourceResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<SubscribeToMatchResourceResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Unsubscribe from lobby notifications.
        /// </summary>
        public static async Task<PlayFabResult<LobbyEmptyResult>> UnsubscribeFromLobbyResourceAsync(UnsubscribeFromLobbyResourceRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Lobby/UnsubscribeFromLobbyResource", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<LobbyEmptyResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<LobbyEmptyResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<LobbyEmptyResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Unsubscribe from match resource notifications.
        /// </summary>
        public static async Task<PlayFabResult<UnsubscribeFromMatchResourceResult>> UnsubscribeFromMatchmakingResourceAsync(UnsubscribeFromMatchResourceRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Match/UnsubscribeFromMatchmakingResource", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<UnsubscribeFromMatchResourceResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<UnsubscribeFromMatchResourceResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<UnsubscribeFromMatchResourceResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Untags a container image.
        /// </summary>
        public static async Task<PlayFabResult<EmptyResponse>> UntagContainerImageAsync(UntagContainerImageRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/UntagContainerImage", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<EmptyResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<EmptyResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<EmptyResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Creates a multiplayer server build alias.
        /// </summary>
        public static async Task<PlayFabResult<BuildAliasDetailsResponse>> UpdateBuildAliasAsync(UpdateBuildAliasRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/UpdateBuildAlias", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<BuildAliasDetailsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<BuildAliasDetailsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<BuildAliasDetailsResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Updates a multiplayer server build's name.
        /// </summary>
        public static async Task<PlayFabResult<EmptyResponse>> UpdateBuildNameAsync(UpdateBuildNameRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/UpdateBuildName", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<EmptyResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<EmptyResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<EmptyResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Updates a multiplayer server build's region. If the region is not yet created, it will be created
        /// </summary>
        public static async Task<PlayFabResult<EmptyResponse>> UpdateBuildRegionAsync(UpdateBuildRegionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/UpdateBuildRegion", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<EmptyResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<EmptyResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<EmptyResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Updates a multiplayer server build's regions.
        /// </summary>
        public static async Task<PlayFabResult<EmptyResponse>> UpdateBuildRegionsAsync(UpdateBuildRegionsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/UpdateBuildRegions", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<EmptyResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<EmptyResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<EmptyResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Update a lobby.
        /// </summary>
        public static async Task<PlayFabResult<LobbyEmptyResult>> UpdateLobbyAsync(UpdateLobbyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Lobby/UpdateLobby", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<LobbyEmptyResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<LobbyEmptyResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<LobbyEmptyResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Uploads a multiplayer server game certificate.
        /// </summary>
        public static async Task<PlayFabResult<EmptyResponse>> UploadCertificateAsync(UploadCertificateRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/UploadCertificate", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<EmptyResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<EmptyResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<EmptyResponse> { Result = result, CustomData = customData };
        }
}
}
#endif
