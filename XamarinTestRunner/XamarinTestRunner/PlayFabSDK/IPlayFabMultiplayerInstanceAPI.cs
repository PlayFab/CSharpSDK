#if !DISABLE_PLAYFABENTITY_API

using PlayFab.MultiplayerModels;
using PlayFab.Internal;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayFab
{
    /// <summary>
    /// API methods for managing multiplayer servers. API methods for managing parties. The lobby service helps players group
    /// together to play multiplayer games. It is often used as a rendezvous point for players to share connection information.
    /// The TrueSkill service helps titles to estimate a player's skill based on their match results. The player skill values
    /// from this service are commonly used by a matchmaking service to provide players with balanced matches.
    /// </summary>
    public interface IPlayFabMultiplayerInstanceAPI
    {
        /// <summary>
        /// Cancel all active tickets the player is a member of in a given queue.
        /// </summary>
        Task<PlayFabResult<CancelAllMatchmakingTicketsForPlayerResult>> CancelAllMatchmakingTicketsForPlayerAsync(
            CancelAllMatchmakingTicketsForPlayerRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Cancel all active backfill tickets the player is a member of in a given queue.
        /// </summary>
        Task<PlayFabResult<CancelAllServerBackfillTicketsForPlayerResult>> CancelAllServerBackfillTicketsForPlayerAsync(
            CancelAllServerBackfillTicketsForPlayerRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Cancel a matchmaking ticket.
        /// </summary>
        Task<PlayFabResult<CancelMatchmakingTicketResult>> CancelMatchmakingTicketAsync(
            CancelMatchmakingTicketRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Cancel a server backfill ticket.
        /// </summary>
        Task<PlayFabResult<CancelServerBackfillTicketResult>> CancelServerBackfillTicketAsync(
            CancelServerBackfillTicketRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Creates a multiplayer server build alias.
        /// </summary>
        Task<PlayFabResult<BuildAliasDetailsResponse>> CreateBuildAliasAsync(
            CreateBuildAliasRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Creates a multiplayer server build with a custom container.
        /// </summary>
        Task<PlayFabResult<CreateBuildWithCustomContainerResponse>> CreateBuildWithCustomContainerAsync(
            CreateBuildWithCustomContainerRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Creates a multiplayer server build with a managed container.
        /// </summary>
        Task<PlayFabResult<CreateBuildWithManagedContainerResponse>> CreateBuildWithManagedContainerAsync(
            CreateBuildWithManagedContainerRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Creates a multiplayer server build with the server running as a process.
        /// </summary>
        Task<PlayFabResult<CreateBuildWithProcessBasedServerResponse>> CreateBuildWithProcessBasedServerAsync(
            CreateBuildWithProcessBasedServerRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Create a lobby.
        /// </summary>
        Task<PlayFabResult<CreateLobbyResult>> CreateLobbyAsync(
            CreateLobbyRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Create a matchmaking ticket as a client.
        /// </summary>
        Task<PlayFabResult<CreateMatchmakingTicketResult>> CreateMatchmakingTicketAsync(
            CreateMatchmakingTicketRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Creates a remote user to log on to a VM for a multiplayer server build.
        /// </summary>
        Task<PlayFabResult<CreateRemoteUserResponse>> CreateRemoteUserAsync(
            CreateRemoteUserRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Create a backfill matchmaking ticket as a server. A backfill ticket represents an ongoing game. The matchmaking service
        /// automatically starts matching the backfill ticket against other matchmaking tickets. Backfill tickets cannot match with
        /// other backfill tickets.
        /// </summary>
        Task<PlayFabResult<CreateServerBackfillTicketResult>> CreateServerBackfillTicketAsync(
            CreateServerBackfillTicketRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Create a matchmaking ticket as a server. The matchmaking service automatically starts matching the ticket against other
        /// matchmaking tickets.
        /// </summary>
        Task<PlayFabResult<CreateMatchmakingTicketResult>> CreateServerMatchmakingTicketAsync(
            CreateServerMatchmakingTicketRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Creates a request to change a title's multiplayer server quotas.
        /// </summary>
        Task<PlayFabResult<CreateTitleMultiplayerServersQuotaChangeResponse>> CreateTitleMultiplayerServersQuotaChangeAsync(
            CreateTitleMultiplayerServersQuotaChangeRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes a multiplayer server game asset for a title.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> DeleteAssetAsync(
            DeleteAssetRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes a multiplayer server build.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> DeleteBuildAsync(
            DeleteBuildRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes a multiplayer server build alias.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> DeleteBuildAliasAsync(
            DeleteBuildAliasRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Removes a multiplayer server build's region.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> DeleteBuildRegionAsync(
            DeleteBuildRegionRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes a multiplayer server game certificate.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> DeleteCertificateAsync(
            DeleteCertificateRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes a container image repository.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> DeleteContainerImageRepositoryAsync(
            DeleteContainerImageRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Delete a lobby.
        /// </summary>
        Task<PlayFabResult<LobbyEmptyResult>> DeleteLobbyAsync(
            DeleteLobbyRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes a remote user to log on to a VM for a multiplayer server build.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> DeleteRemoteUserAsync(
            DeleteRemoteUserRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes a multiplayer server game secret.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> DeleteSecretAsync(
            DeleteSecretRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Enables the multiplayer server feature for a title.
        /// </summary>
        Task<PlayFabResult<EnableMultiplayerServersForTitleResponse>> EnableMultiplayerServersForTitleAsync(
            EnableMultiplayerServersForTitleRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Find lobbies which match certain criteria, and which friends are in.
        /// </summary>
        Task<PlayFabResult<FindFriendLobbiesResult>> FindFriendLobbiesAsync(
            FindFriendLobbiesRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Find all the lobbies that match certain criteria.
        /// </summary>
        Task<PlayFabResult<FindLobbiesResult>> FindLobbiesAsync(
            FindLobbiesRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets a URL that can be used to download the specified asset. A sample pre-authenticated url -
        /// https://sampleStorageAccount.blob.core.windows.net/gameassets/gameserver.zip?sv=2015-04-05&ss=b&srt=sco&sp=rw&st=startDate&se=endDate&spr=https&sig=sampleSig&api-version=2017-07-29
        /// </summary>
        Task<PlayFabResult<GetAssetDownloadUrlResponse>> GetAssetDownloadUrlAsync(
            GetAssetDownloadUrlRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the URL to upload assets to. A sample pre-authenticated url -
        /// https://sampleStorageAccount.blob.core.windows.net/gameassets/gameserver.zip?sv=2015-04-05&ss=b&srt=sco&sp=rw&st=startDate&se=endDate&spr=https&sig=sampleSig&api-version=2017-07-29
        /// </summary>
        Task<PlayFabResult<GetAssetUploadUrlResponse>> GetAssetUploadUrlAsync(
            GetAssetUploadUrlRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets a multiplayer server build.
        /// </summary>
        Task<PlayFabResult<GetBuildResponse>> GetBuildAsync(
            GetBuildRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets a multiplayer server build alias.
        /// </summary>
        Task<PlayFabResult<BuildAliasDetailsResponse>> GetBuildAliasAsync(
            GetBuildAliasRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the credentials to the container registry.
        /// </summary>
        Task<PlayFabResult<GetContainerRegistryCredentialsResponse>> GetContainerRegistryCredentialsAsync(
            GetContainerRegistryCredentialsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Get a lobby.
        /// </summary>
        Task<PlayFabResult<GetLobbyResult>> GetLobbyAsync(
            GetLobbyRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Get a match.
        /// </summary>
        Task<PlayFabResult<GetMatchResult>> GetMatchAsync(
            GetMatchRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// SDK support is limited to C# and Java for this API. Get a matchmaking queue configuration.
        /// </summary>
        Task<PlayFabResult<GetMatchmakingQueueResult>> GetMatchmakingQueueAsync(
            GetMatchmakingQueueRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Get a matchmaking ticket by ticket Id.
        /// </summary>
        Task<PlayFabResult<GetMatchmakingTicketResult>> GetMatchmakingTicketAsync(
            GetMatchmakingTicketRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets multiplayer server session details for a build.
        /// </summary>
        Task<PlayFabResult<GetMultiplayerServerDetailsResponse>> GetMultiplayerServerDetailsAsync(
            GetMultiplayerServerDetailsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets multiplayer server logs after a server has terminated.
        /// </summary>
        Task<PlayFabResult<GetMultiplayerServerLogsResponse>> GetMultiplayerServerLogsAsync(
            GetMultiplayerServerLogsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets multiplayer server logs after a server has terminated.
        /// </summary>
        Task<PlayFabResult<GetMultiplayerServerLogsResponse>> GetMultiplayerSessionLogsBySessionIdAsync(
            GetMultiplayerSessionLogsBySessionIdRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Get the statistics for a queue.
        /// </summary>
        Task<PlayFabResult<GetQueueStatisticsResult>> GetQueueStatisticsAsync(
            GetQueueStatisticsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets a remote login endpoint to a VM that is hosting a multiplayer server build.
        /// </summary>
        Task<PlayFabResult<GetRemoteLoginEndpointResponse>> GetRemoteLoginEndpointAsync(
            GetRemoteLoginEndpointRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Get a matchmaking backfill ticket by ticket Id.
        /// </summary>
        Task<PlayFabResult<GetServerBackfillTicketResult>> GetServerBackfillTicketAsync(
            GetServerBackfillTicketRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the status of whether a title is enabled for the multiplayer server feature.
        /// </summary>
        Task<PlayFabResult<GetTitleEnabledForMultiplayerServersStatusResponse>> GetTitleEnabledForMultiplayerServersStatusAsync(
            GetTitleEnabledForMultiplayerServersStatusRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets a title's server quota change request.
        /// </summary>
        Task<PlayFabResult<GetTitleMultiplayerServersQuotaChangeResponse>> GetTitleMultiplayerServersQuotaChangeAsync(
            GetTitleMultiplayerServersQuotaChangeRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the quotas for a title in relation to multiplayer servers.
        /// </summary>
        Task<PlayFabResult<GetTitleMultiplayerServersQuotasResponse>> GetTitleMultiplayerServersQuotasAsync(
            GetTitleMultiplayerServersQuotasRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Send a notification to invite a player to a lobby.
        /// </summary>
        Task<PlayFabResult<LobbyEmptyResult>> InviteToLobbyAsync(
            InviteToLobbyRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Join an Arranged lobby.
        /// </summary>
        Task<PlayFabResult<JoinLobbyResult>> JoinArrangedLobbyAsync(
            JoinArrangedLobbyRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Join a lobby.
        /// </summary>
        Task<PlayFabResult<JoinLobbyResult>> JoinLobbyAsync(
            JoinLobbyRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Preview: Join a lobby as a server entity. This is restricted to client lobbies which are using connections.
        /// </summary>
        Task<PlayFabResult<JoinLobbyAsServerResult>> JoinLobbyAsServerAsync(
            JoinLobbyAsServerRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Join a matchmaking ticket.
        /// </summary>
        Task<PlayFabResult<JoinMatchmakingTicketResult>> JoinMatchmakingTicketAsync(
            JoinMatchmakingTicketRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Leave a lobby.
        /// </summary>
        Task<PlayFabResult<LobbyEmptyResult>> LeaveLobbyAsync(
            LeaveLobbyRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Preview: Request for server to leave a lobby. This is restricted to client owned lobbies which are using connections.
        /// </summary>
        Task<PlayFabResult<LobbyEmptyResult>> LeaveLobbyAsServerAsync(
            LeaveLobbyAsServerRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists archived multiplayer server sessions for a build.
        /// </summary>
        Task<PlayFabResult<ListMultiplayerServersResponse>> ListArchivedMultiplayerServersAsync(
            ListMultiplayerServersRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists multiplayer server game assets for a title.
        /// </summary>
        Task<PlayFabResult<ListAssetSummariesResponse>> ListAssetSummariesAsync(
            ListAssetSummariesRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists details of all build aliases for a title. Accepts tokens for title and if game client access is enabled, allows
        /// game client to request list of builds with player entity token.
        /// </summary>
        Task<PlayFabResult<ListBuildAliasesResponse>> ListBuildAliasesAsync(
            ListBuildAliasesRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists summarized details of all multiplayer server builds for a title. Accepts tokens for title and if game client
        /// access is enabled, allows game client to request list of builds with player entity token.
        /// </summary>
        Task<PlayFabResult<ListBuildSummariesResponse>> ListBuildSummariesV2Async(
            ListBuildSummariesRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists multiplayer server game certificates for a title.
        /// </summary>
        Task<PlayFabResult<ListCertificateSummariesResponse>> ListCertificateSummariesAsync(
            ListCertificateSummariesRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists custom container images for a title.
        /// </summary>
        Task<PlayFabResult<ListContainerImagesResponse>> ListContainerImagesAsync(
            ListContainerImagesRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists the tags for a custom container image.
        /// </summary>
        Task<PlayFabResult<ListContainerImageTagsResponse>> ListContainerImageTagsAsync(
            ListContainerImageTagsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// SDK support is limited to C# and Java for this API. List all matchmaking queue configs.
        /// </summary>
        Task<PlayFabResult<ListMatchmakingQueuesResult>> ListMatchmakingQueuesAsync(
            ListMatchmakingQueuesRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// List all matchmaking ticket Ids the user is a member of.
        /// </summary>
        Task<PlayFabResult<ListMatchmakingTicketsForPlayerResult>> ListMatchmakingTicketsForPlayerAsync(
            ListMatchmakingTicketsForPlayerRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists multiplayer server sessions for a build.
        /// </summary>
        Task<PlayFabResult<ListMultiplayerServersResponse>> ListMultiplayerServersAsync(
            ListMultiplayerServersRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists quality of service servers for party.
        /// </summary>
        Task<PlayFabResult<ListPartyQosServersResponse>> ListPartyQosServersAsync(
            ListPartyQosServersRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists quality of service servers for the title. By default, servers are only returned for regions where a Multiplayer
        /// Servers build has been deployed.
        /// </summary>
        Task<PlayFabResult<ListQosServersForTitleResponse>> ListQosServersForTitleAsync(
            ListQosServersForTitleRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists multiplayer server game secrets for a title.
        /// </summary>
        Task<PlayFabResult<ListSecretSummariesResponse>> ListSecretSummariesAsync(
            ListSecretSummariesRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// List all server backfill ticket Ids the user is a member of.
        /// </summary>
        Task<PlayFabResult<ListServerBackfillTicketsForPlayerResult>> ListServerBackfillTicketsForPlayerAsync(
            ListServerBackfillTicketsForPlayerRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// List all server quota change requests for a title.
        /// </summary>
        Task<PlayFabResult<ListTitleMultiplayerServersQuotaChangesResponse>> ListTitleMultiplayerServersQuotaChangesAsync(
            ListTitleMultiplayerServersQuotaChangesRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists virtual machines for a title.
        /// </summary>
        Task<PlayFabResult<ListVirtualMachineSummariesResponse>> ListVirtualMachineSummariesAsync(
            ListVirtualMachineSummariesRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// SDK support is limited to C# and Java for this API. Remove a matchmaking queue config.
        /// </summary>
        Task<PlayFabResult<RemoveMatchmakingQueueResult>> RemoveMatchmakingQueueAsync(
            RemoveMatchmakingQueueRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Remove a member from a lobby.
        /// </summary>
        Task<PlayFabResult<LobbyEmptyResult>> RemoveMemberAsync(
            RemoveMemberFromLobbyRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Request a multiplayer server session. Accepts tokens for title and if game client access is enabled, allows game client
        /// to request a server with player entity token.
        /// </summary>
        Task<PlayFabResult<RequestMultiplayerServerResponse>> RequestMultiplayerServerAsync(
            RequestMultiplayerServerRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Request a party session.
        /// </summary>
        Task<PlayFabResult<RequestPartyServiceResponse>> RequestPartyServiceAsync(
            RequestPartyServiceRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Rolls over the credentials to the container registry.
        /// </summary>
        Task<PlayFabResult<RolloverContainerRegistryCredentialsResponse>> RolloverContainerRegistryCredentialsAsync(
            RolloverContainerRegistryCredentialsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// SDK support is limited to C# and Java for this API. Create or update a matchmaking queue configuration.
        /// </summary>
        Task<PlayFabResult<SetMatchmakingQueueResult>> SetMatchmakingQueueAsync(
            SetMatchmakingQueueRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Shuts down a multiplayer server session.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> ShutdownMultiplayerServerAsync(
            ShutdownMultiplayerServerRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Subscribe to lobby resource notifications.
        /// </summary>
        Task<PlayFabResult<SubscribeToLobbyResourceResult>> SubscribeToLobbyResourceAsync(
            SubscribeToLobbyResourceRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Subscribe to match resource notifications.
        /// </summary>
        Task<PlayFabResult<SubscribeToMatchResourceResult>> SubscribeToMatchmakingResourceAsync(
            SubscribeToMatchResourceRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unsubscribe from lobby notifications.
        /// </summary>
        Task<PlayFabResult<LobbyEmptyResult>> UnsubscribeFromLobbyResourceAsync(
            UnsubscribeFromLobbyResourceRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unsubscribe from match resource notifications.
        /// </summary>
        Task<PlayFabResult<UnsubscribeFromMatchResourceResult>> UnsubscribeFromMatchmakingResourceAsync(
            UnsubscribeFromMatchResourceRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Untags a container image.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> UntagContainerImageAsync(
            UntagContainerImageRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Creates a multiplayer server build alias.
        /// </summary>
        Task<PlayFabResult<BuildAliasDetailsResponse>> UpdateBuildAliasAsync(
            UpdateBuildAliasRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates a multiplayer server build's name.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> UpdateBuildNameAsync(
            UpdateBuildNameRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates a multiplayer server build's region. If the region is not yet created, it will be created
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> UpdateBuildRegionAsync(
            UpdateBuildRegionRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates a multiplayer server build's regions.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> UpdateBuildRegionsAsync(
            UpdateBuildRegionsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Update a lobby.
        /// </summary>
        Task<PlayFabResult<LobbyEmptyResult>> UpdateLobbyAsync(
            UpdateLobbyRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Preview: Update fields related to a joined server in the lobby the server is in. Servers can keep a lobby from expiring
        /// by being the one to "update" the lobby in some way. Servers have no impact on last member leave/last member disconnect
        /// behavior.
        /// </summary>
        Task<PlayFabResult<LobbyEmptyResult>> UpdateLobbyAsServerAsync(
            UpdateLobbyAsServerRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Uploads a multiplayer server game certificate.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> UploadCertificateAsync(
            UploadCertificateRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Uploads a multiplayer server game secret.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> UploadSecretAsync(
            UploadSecretRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);
    }
}
#endif
