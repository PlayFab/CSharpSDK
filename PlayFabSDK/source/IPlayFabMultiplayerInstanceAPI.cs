using System.Collections.Generic;
using System.Threading.Tasks;
using PlayFab.MultiplayerModels;

namespace PlayFab
{
    /// <summary>
    /// Interface for PlayFab Multiplayer Instance API, providing asynchronous methods for multiplayer server and matchmaking operations.
    /// </summary>
    public interface IPlayFabMultiplayerInstanceAPI
    {
        /// <summary>
        /// Checks if an entity is currently logged in.
        /// </summary>
        /// <returns>True if an entity is logged in; otherwise, false.</returns>
        bool IsEntityLoggedIn();

        /// <summary>
        /// Forgets all stored credentials for the current entity.
        /// </summary>
        void ForgetAllCredentials();

        /// <summary>
        /// Cancels all matchmaking tickets for a player in a given queue.
        /// </summary>
        Task<PlayFabResult<CancelAllMatchmakingTicketsForPlayerResult>> CancelAllMatchmakingTicketsForPlayerAsync(CancelAllMatchmakingTicketsForPlayerRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Cancels all server backfill tickets for a player in a given queue.
        /// </summary>
        Task<PlayFabResult<CancelAllServerBackfillTicketsForPlayerResult>> CancelAllServerBackfillTicketsForPlayerAsync(CancelAllServerBackfillTicketsForPlayerRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Cancels a specific matchmaking ticket.
        /// </summary>
        Task<PlayFabResult<CancelMatchmakingTicketResult>> CancelMatchmakingTicketAsync(CancelMatchmakingTicketRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Cancels a specific server backfill ticket.
        /// </summary>
        Task<PlayFabResult<CancelServerBackfillTicketResult>> CancelServerBackfillTicketAsync(CancelServerBackfillTicketRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Creates a multiplayer server build alias.
        /// </summary>
        Task<PlayFabResult<BuildAliasDetailsResponse>> CreateBuildAliasAsync(CreateBuildAliasRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Creates a multiplayer server build with a custom container.
        /// </summary>
        Task<PlayFabResult<CreateBuildWithCustomContainerResponse>> CreateBuildWithCustomContainerAsync(CreateBuildWithCustomContainerRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Creates a multiplayer server build with a managed container.
        /// </summary>
        Task<PlayFabResult<CreateBuildWithManagedContainerResponse>> CreateBuildWithManagedContainerAsync(CreateBuildWithManagedContainerRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Creates a multiplayer server build with a process-based server.
        /// </summary>
        Task<PlayFabResult<CreateBuildWithProcessBasedServerResponse>> CreateBuildWithProcessBasedServerAsync(CreateBuildWithProcessBasedServerRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Creates a new lobby.
        /// </summary>
        Task<PlayFabResult<CreateLobbyResult>> CreateLobbyAsync(CreateLobbyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Creates a matchmaking ticket.
        /// </summary>
        Task<PlayFabResult<CreateMatchmakingTicketResult>> CreateMatchmakingTicketAsync(CreateMatchmakingTicketRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Creates a remote user for a multiplayer server build.
        /// </summary>
        Task<PlayFabResult<CreateRemoteUserResponse>> CreateRemoteUserAsync(CreateRemoteUserRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Creates a server backfill ticket.
        /// </summary>
        Task<PlayFabResult<CreateServerBackfillTicketResult>> CreateServerBackfillTicketAsync(CreateServerBackfillTicketRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Creates a server matchmaking ticket.
        /// </summary>
        Task<PlayFabResult<CreateMatchmakingTicketResult>> CreateServerMatchmakingTicketAsync(CreateServerMatchmakingTicketRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Creates a request to change a title's multiplayer server quotas.
        /// </summary>
        Task<PlayFabResult<CreateTitleMultiplayerServersQuotaChangeResponse>> CreateTitleMultiplayerServersQuotaChangeAsync(CreateTitleMultiplayerServersQuotaChangeRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes a multiplayer server game asset.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> DeleteAssetAsync(DeleteAssetRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes a multiplayer server build.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> DeleteBuildAsync(DeleteBuildRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes a multiplayer server build alias.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> DeleteBuildAliasAsync(DeleteBuildAliasRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes a multiplayer server build region.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> DeleteBuildRegionAsync(DeleteBuildRegionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes a multiplayer server game certificate.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> DeleteCertificateAsync(DeleteCertificateRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes a container image repository.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> DeleteContainerImageRepositoryAsync(DeleteContainerImageRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes a lobby.
        /// </summary>
        Task<PlayFabResult<LobbyEmptyResult>> DeleteLobbyAsync(DeleteLobbyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes a remote user for a multiplayer server build.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> DeleteRemoteUserAsync(DeleteRemoteUserRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes a multiplayer server game secret.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> DeleteSecretAsync(DeleteSecretRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Enables multiplayer servers for a title.
        /// </summary>
        Task<PlayFabResult<EnableMultiplayerServersForTitleResponse>> EnableMultiplayerServersForTitleAsync(EnableMultiplayerServersForTitleRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Finds friend lobbies for a player.
        /// </summary>
        Task<PlayFabResult<FindFriendLobbiesResult>> FindFriendLobbiesAsync(FindFriendLobbiesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Finds lobbies based on search criteria.
        /// </summary>
        Task<PlayFabResult<FindLobbiesResult>> FindLobbiesAsync(FindLobbiesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets a URL to download a specified asset.
        /// </summary>
        Task<PlayFabResult<GetAssetDownloadUrlResponse>> GetAssetDownloadUrlAsync(GetAssetDownloadUrlRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets a URL to upload an asset.
        /// </summary>
        Task<PlayFabResult<GetAssetUploadUrlResponse>> GetAssetUploadUrlAsync(GetAssetUploadUrlRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets details about a multiplayer server build.
        /// </summary>
        Task<PlayFabResult<GetBuildResponse>> GetBuildAsync(GetBuildRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets details about a multiplayer server build alias.
        /// </summary>
        Task<PlayFabResult<BuildAliasDetailsResponse>> GetBuildAliasAsync(GetBuildAliasRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets credentials for the container registry.
        /// </summary>
        Task<PlayFabResult<GetContainerRegistryCredentialsResponse>> GetContainerRegistryCredentialsAsync(GetContainerRegistryCredentialsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets details about a lobby.
        /// </summary>
        Task<PlayFabResult<GetLobbyResult>> GetLobbyAsync(GetLobbyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets details about a match.
        /// </summary>
        Task<PlayFabResult<GetMatchResult>> GetMatchAsync(GetMatchRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the configuration for a matchmaking queue.
        /// </summary>
        Task<PlayFabResult<GetMatchmakingQueueResult>> GetMatchmakingQueueAsync(GetMatchmakingQueueRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets details about a matchmaking ticket.
        /// </summary>
        Task<PlayFabResult<GetMatchmakingTicketResult>> GetMatchmakingTicketAsync(GetMatchmakingTicketRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets multiplayer server session details.
        /// </summary>
        Task<PlayFabResult<GetMultiplayerServerDetailsResponse>> GetMultiplayerServerDetailsAsync(GetMultiplayerServerDetailsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets multiplayer server logs for a specific server.
        /// </summary>
        Task<PlayFabResult<GetMultiplayerServerLogsResponse>> GetMultiplayerServerLogsAsync(GetMultiplayerServerLogsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets multiplayer server logs by session ID.
        /// </summary>
        Task<PlayFabResult<GetMultiplayerServerLogsResponse>> GetMultiplayerSessionLogsBySessionIdAsync(GetMultiplayerSessionLogsBySessionIdRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets matchmaking queue statistics.
        /// </summary>
        Task<PlayFabResult<GetQueueStatisticsResult>> GetQueueStatisticsAsync(GetQueueStatisticsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets a remote login endpoint for a VM hosting a multiplayer server.
        /// </summary>
        Task<PlayFabResult<GetRemoteLoginEndpointResponse>> GetRemoteLoginEndpointAsync(GetRemoteLoginEndpointRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets details about a server backfill ticket.
        /// </summary>
        Task<PlayFabResult<GetServerBackfillTicketResult>> GetServerBackfillTicketAsync(GetServerBackfillTicketRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the status of multiplayer server feature enablement for a title.
        /// </summary>
        Task<PlayFabResult<GetTitleEnabledForMultiplayerServersStatusResponse>> GetTitleEnabledForMultiplayerServersStatusAsync(GetTitleEnabledForMultiplayerServersStatusRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets a title's server quota change request.
        /// </summary>
        Task<PlayFabResult<GetTitleMultiplayerServersQuotaChangeResponse>> GetTitleMultiplayerServersQuotaChangeAsync(GetTitleMultiplayerServersQuotaChangeRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the quotas for a title in relation to multiplayer servers.
        /// </summary>
        Task<PlayFabResult<GetTitleMultiplayerServersQuotasResponse>> GetTitleMultiplayerServersQuotasAsync(GetTitleMultiplayerServersQuotasRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Invites a player to a lobby.
        /// </summary>
        Task<PlayFabResult<LobbyEmptyResult>> InviteToLobbyAsync(InviteToLobbyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Joins an arranged lobby.
        /// </summary>
        Task<PlayFabResult<JoinLobbyResult>> JoinArrangedLobbyAsync(JoinArrangedLobbyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Joins a lobby.
        /// </summary>
        Task<PlayFabResult<JoinLobbyResult>> JoinLobbyAsync(JoinLobbyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Joins a lobby as a server.
        /// </summary>
        Task<PlayFabResult<JoinLobbyAsServerResult>> JoinLobbyAsServerAsync(JoinLobbyAsServerRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Joins a matchmaking ticket.
        /// </summary>
        Task<PlayFabResult<JoinMatchmakingTicketResult>> JoinMatchmakingTicketAsync(JoinMatchmakingTicketRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Leaves a lobby.
        /// </summary>
        Task<PlayFabResult<LobbyEmptyResult>> LeaveLobbyAsync(LeaveLobbyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Leaves a lobby as a server.
        /// </summary>
        Task<PlayFabResult<LobbyEmptyResult>> LeaveLobbyAsServerAsync(LeaveLobbyAsServerRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists archived multiplayer servers.
        /// </summary>
        Task<PlayFabResult<ListMultiplayerServersResponse>> ListArchivedMultiplayerServersAsync(ListMultiplayerServersRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists multiplayer server game asset summaries.
        /// </summary>
        Task<PlayFabResult<ListAssetSummariesResponse>> ListAssetSummariesAsync(ListAssetSummariesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists multiplayer server build aliases.
        /// </summary>
        Task<PlayFabResult<ListBuildAliasesResponse>> ListBuildAliasesAsync(ListBuildAliasesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists multiplayer server build summaries.
        /// </summary>
        Task<PlayFabResult<ListBuildSummariesResponse>> ListBuildSummariesV2Async(ListBuildSummariesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists multiplayer server game certificate summaries.
        /// </summary>
        Task<PlayFabResult<ListCertificateSummariesResponse>> ListCertificateSummariesAsync(ListCertificateSummariesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists container images uploaded to the container registry.
        /// </summary>
        Task<PlayFabResult<ListContainerImagesResponse>> ListContainerImagesAsync(ListContainerImagesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists tags for a particular container image.
        /// </summary>
        Task<PlayFabResult<ListContainerImageTagsResponse>> ListContainerImageTagsAsync(ListContainerImageTagsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists all matchmaking queue configurations for the title.
        /// </summary>
        Task<PlayFabResult<ListMatchmakingQueuesResult>> ListMatchmakingQueuesAsync(ListMatchmakingQueuesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists all matchmaking tickets for a player.
        /// </summary>
        Task<PlayFabResult<ListMatchmakingTicketsForPlayerResult>> ListMatchmakingTicketsForPlayerAsync(ListMatchmakingTicketsForPlayerRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists multiplayer servers for a build in a specific region.
        /// </summary>
        Task<PlayFabResult<ListMultiplayerServersResponse>> ListMultiplayerServersAsync(ListMultiplayerServersRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists quality of service servers for party.
        /// </summary>
        Task<PlayFabResult<ListPartyQosServersResponse>> ListPartyQosServersAsync(ListPartyQosServersRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists quality of service servers for a title.
        /// </summary>
        Task<PlayFabResult<ListQosServersForTitleResponse>> ListQosServersForTitleAsync(ListQosServersForTitleRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists multiplayer server game secrets for a title.
        /// </summary>
        Task<PlayFabResult<ListSecretSummariesResponse>> ListSecretSummariesAsync(ListSecretSummariesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists all server backfill ticket IDs the user is a member of.
        /// </summary>
        Task<PlayFabResult<ListServerBackfillTicketsForPlayerResult>> ListServerBackfillTicketsForPlayerAsync(ListServerBackfillTicketsForPlayerRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists all server quota change requests for a title.
        /// </summary>
        Task<PlayFabResult<ListTitleMultiplayerServersQuotaChangesResponse>> ListTitleMultiplayerServersQuotaChangesAsync(ListTitleMultiplayerServersQuotaChangesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists virtual machines for a title.
        /// </summary>
        Task<PlayFabResult<ListVirtualMachineSummariesResponse>> ListVirtualMachineSummariesAsync(ListVirtualMachineSummariesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Removes the configuration for a matchmaking queue.
        /// </summary>
        Task<PlayFabResult<RemoveMatchmakingQueueResult>> RemoveMatchmakingQueueAsync(RemoveMatchmakingQueueRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Removes a member from a lobby.
        /// </summary>
        Task<PlayFabResult<LobbyEmptyResult>> RemoveMemberAsync(RemoveMemberFromLobbyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Requests a multiplayer server session.
        /// </summary>
        Task<PlayFabResult<RequestMultiplayerServerResponse>> RequestMultiplayerServerAsync(RequestMultiplayerServerRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Requests a party session.
        /// </summary>
        Task<PlayFabResult<RequestPartyServiceResponse>> RequestPartyServiceAsync(RequestPartyServiceRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets new credentials for the container registry.
        /// </summary>
        Task<PlayFabResult<RolloverContainerRegistryCredentialsResponse>> RolloverContainerRegistryCredentialsAsync(RolloverContainerRegistryCredentialsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Creates or updates matchmaking queue configurations.
        /// </summary>
        Task<PlayFabResult<SetMatchmakingQueueResult>> SetMatchmakingQueueAsync(SetMatchmakingQueueRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Shuts down a multiplayer server session.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> ShutdownMultiplayerServerAsync(ShutdownMultiplayerServerRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Subscribes to lobby resource notifications.
        /// </summary>
        Task<PlayFabResult<SubscribeToLobbyResourceResult>> SubscribeToLobbyResourceAsync(SubscribeToLobbyResourceRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Subscribes to matchmaking resource notifications.
        /// </summary>
        Task<PlayFabResult<SubscribeToMatchResourceResult>> SubscribeToMatchmakingResourceAsync(SubscribeToMatchResourceRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unsubscribes from lobby resource notifications.
        /// </summary>
        Task<PlayFabResult<LobbyEmptyResult>> UnsubscribeFromLobbyResourceAsync(UnsubscribeFromLobbyResourceRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unsubscribes from matchmaking resource notifications.
        /// </summary>
        Task<PlayFabResult<UnsubscribeFromMatchResourceResult>> UnsubscribeFromMatchmakingResourceAsync(UnsubscribeFromMatchResourceRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Removes a tag from a container image.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> UntagContainerImageAsync(UntagContainerImageRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates a multiplayer server build alias.
        /// </summary>
        Task<PlayFabResult<BuildAliasDetailsResponse>> UpdateBuildAliasAsync(UpdateBuildAliasRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates a multiplayer server build's name.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> UpdateBuildNameAsync(UpdateBuildNameRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates a multiplayer server build's region.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> UpdateBuildRegionAsync(UpdateBuildRegionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates a multiplayer server build's regions.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> UpdateBuildRegionsAsync(UpdateBuildRegionsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates a lobby.
        /// </summary>
        Task<PlayFabResult<LobbyEmptyResult>> UpdateLobbyAsync(UpdateLobbyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates a lobby as a server.
        /// </summary>
        Task<PlayFabResult<LobbyEmptyResult>> UpdateLobbyAsServerAsync(UpdateLobbyAsServerRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Uploads a multiplayer server game certificate.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> UploadCertificateAsync(UploadCertificateRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Uploads a multiplayer server game secret.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> UploadSecretAsync(UploadSecretRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
    }
}
