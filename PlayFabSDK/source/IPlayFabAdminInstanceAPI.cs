#if ENABLE_PLAYFABADMIN_API

using PlayFab.AdminModels;
using PlayFab.Internal;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayFab
{
    /// <summary>
    /// APIs for managing title configurations, uploaded Game Server code executables, and user data
    /// </summary>
    public interface IPlayFabAdminInstanceAPI
    {
        /// <summary>
        /// Abort an ongoing task instance.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> AbortTaskInstanceAsync(
            AbortTaskInstanceRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Update news item to include localized version
        /// </summary>
        Task<PlayFabResult<AddLocalizedNewsResult>> AddLocalizedNewsAsync(
            AddLocalizedNewsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Adds a new news item to the title's news feed
        /// </summary>
        Task<PlayFabResult<AddNewsResult>> AddNewsAsync(
            AddNewsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Adds a given tag to a player profile. The tag's namespace is automatically generated based on the source of the tag.
        /// </summary>
        Task<PlayFabResult<AddPlayerTagResult>> AddPlayerTagAsync(
            AddPlayerTagRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Increments the specified virtual currency by the stated amount
        /// </summary>
        Task<PlayFabResult<ModifyUserVirtualCurrencyResult>> AddUserVirtualCurrencyAsync(
            AddUserVirtualCurrencyRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Adds one or more virtual currencies to the set defined for the title. Virtual Currencies have a maximum
        /// value of 2,147,483,647 when granted to a player. Any value over that will be discarded.
        /// </summary>
        Task<PlayFabResult<BlankResult>> AddVirtualCurrencyTypesAsync(
            AddVirtualCurrencyTypesRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Bans users by PlayFab ID with optional IP address, or MAC address for the provided game.
        /// </summary>
        Task<PlayFabResult<BanUsersResult>> BanUsersAsync(
            BanUsersRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Checks the global count for the limited edition item.
        /// </summary>
        Task<PlayFabResult<CheckLimitedEditionItemAvailabilityResult>> CheckLimitedEditionItemAvailabilityAsync(
            CheckLimitedEditionItemAvailabilityRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Create an ActionsOnPlayersInSegment task, which iterates through all players in a segment to execute action.
        /// </summary>
        Task<PlayFabResult<CreateTaskResult>> CreateActionsOnPlayersInSegmentTaskAsync(
            CreateActionsOnPlayerSegmentTaskRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Create a CloudScript task, which can run a CloudScript on a schedule.
        /// </summary>
        Task<PlayFabResult<CreateTaskResult>> CreateCloudScriptTaskAsync(
            CreateCloudScriptTaskRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Create a Insights Scheduled Scaling task, which can scale Insights Performance Units on a schedule
        /// </summary>
        Task<PlayFabResult<CreateTaskResult>> CreateInsightsScheduledScalingTaskAsync(
            CreateInsightsScheduledScalingTaskRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Registers a relationship between a title and an Open ID Connect provider.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> CreateOpenIdConnectionAsync(
            CreateOpenIdConnectionRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Creates a new Player Shared Secret Key. It may take up to 5 minutes for this key to become generally available after
        /// this API returns.
        /// </summary>
        Task<PlayFabResult<CreatePlayerSharedSecretResult>> CreatePlayerSharedSecretAsync(
            CreatePlayerSharedSecretRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Adds a new player statistic configuration to the title, optionally allowing the developer to specify a reset interval
        /// and an aggregation method.
        /// </summary>
        Task<PlayFabResult<CreatePlayerStatisticDefinitionResult>> CreatePlayerStatisticDefinitionAsync(
            CreatePlayerStatisticDefinitionRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Creates a new player segment by defining the conditions on player properties. Also, create actions to target the player
        /// segments for a title.
        /// </summary>
        Task<PlayFabResult<CreateSegmentResponse>> CreateSegmentAsync(
            CreateSegmentRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Delete a content file from the title. When deleting a file that does not exist, it returns success.
        /// </summary>
        Task<PlayFabResult<BlankResult>> DeleteContentAsync(
            DeleteContentRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Removes a master player account entirely from all titles and deletes all associated data
        /// </summary>
        Task<PlayFabResult<DeleteMasterPlayerAccountResult>> DeleteMasterPlayerAccountAsync(
            DeleteMasterPlayerAccountRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes PlayStream and telemetry event data associated with the master player account from PlayFab storage
        /// </summary>
        Task<PlayFabResult<DeleteMasterPlayerEventDataResult>> DeleteMasterPlayerEventDataAsync(
            DeleteMasterPlayerEventDataRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes a player's subscription
        /// </summary>
        Task<PlayFabResult<DeleteMembershipSubscriptionResult>> DeleteMembershipSubscriptionAsync(
            DeleteMembershipSubscriptionRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Removes a relationship between a title and an OpenID Connect provider.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> DeleteOpenIdConnectionAsync(
            DeleteOpenIdConnectionRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Removes a user's player account from a title and deletes all associated data
        /// </summary>
        Task<PlayFabResult<DeletePlayerResult>> DeletePlayerAsync(
            DeletePlayerRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes title-specific custom properties for a player
        /// </summary>
        Task<PlayFabResult<DeletePlayerCustomPropertiesResult>> DeletePlayerCustomPropertiesAsync(
            DeletePlayerCustomPropertiesRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes an existing Player Shared Secret Key. It may take up to 5 minutes for this delete to be reflected after this API
        /// returns.
        /// </summary>
        Task<PlayFabResult<DeletePlayerSharedSecretResult>> DeletePlayerSharedSecretAsync(
            DeletePlayerSharedSecretRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes an existing player segment and its associated action(s) for a title.
        /// </summary>
        Task<PlayFabResult<DeleteSegmentsResponse>> DeleteSegmentAsync(
            DeleteSegmentRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Deletes an existing virtual item store
        /// </summary>
        Task<PlayFabResult<DeleteStoreResult>> DeleteStoreAsync(
            DeleteStoreRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Delete a task.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> DeleteTaskAsync(
            DeleteTaskRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Permanently deletes a title and all associated configuration
        /// </summary>
        Task<PlayFabResult<DeleteTitleResult>> DeleteTitleAsync(
            DeleteTitleRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes a specified set of title data overrides.
        /// </summary>
        Task<PlayFabResult<DeleteTitleDataOverrideResult>> DeleteTitleDataOverrideAsync(
            DeleteTitleDataOverrideRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Exports all associated data of a master player account
        /// </summary>
        Task<PlayFabResult<ExportMasterPlayerDataResult>> ExportMasterPlayerDataAsync(
            ExportMasterPlayerDataRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Starts an export for the player profiles in a segment. This API creates a snapshot of all the player profiles which
        /// match the segment definition at the time of the API call. Profiles which change while an export is in progress will not
        /// be reflected in the results.
        /// </summary>
        Task<PlayFabResult<ExportPlayersInSegmentResult>> ExportPlayersInSegmentAsync(
            ExportPlayersInSegmentRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Get information about a ActionsOnPlayersInSegment task instance.
        /// </summary>
        Task<PlayFabResult<GetActionsOnPlayersInSegmentTaskInstanceResult>> GetActionsOnPlayersInSegmentTaskInstanceAsync(
            GetTaskInstanceRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves an array of player segment definitions. Results from this can be used in subsequent API calls such as
        /// GetPlayersInSegment which requires a Segment ID. While segment names can change the ID for that segment will not change.
        /// </summary>
        Task<PlayFabResult<GetAllSegmentsResult>> GetAllSegmentsAsync(
            GetAllSegmentsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Retrieves the specified version of the title's catalog of virtual goods, including all defined properties
        /// </summary>
        Task<PlayFabResult<GetCatalogItemsResult>> GetCatalogItemsAsync(
            GetCatalogItemsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the contents and information of a specific Cloud Script revision.
        /// </summary>
        Task<PlayFabResult<GetCloudScriptRevisionResult>> GetCloudScriptRevisionAsync(
            GetCloudScriptRevisionRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Get detail information about a CloudScript task instance.
        /// </summary>
        Task<PlayFabResult<GetCloudScriptTaskInstanceResult>> GetCloudScriptTaskInstanceAsync(
            GetTaskInstanceRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists all the current cloud script versions. For each version, information about the current published and latest
        /// revisions is also listed.
        /// </summary>
        Task<PlayFabResult<GetCloudScriptVersionsResult>> GetCloudScriptVersionsAsync(
            GetCloudScriptVersionsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// List all contents of the title and get statistics such as size
        /// </summary>
        Task<PlayFabResult<GetContentListResult>> GetContentListAsync(
            GetContentListRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves the pre-signed URL for uploading a content file. A subsequent HTTP PUT to the returned URL uploads the
        /// content. Also, please be aware that the Content service is specifically PlayFab's CDN offering, for which standard CDN
        /// rates apply.
        /// </summary>
        Task<PlayFabResult<GetContentUploadUrlResult>> GetContentUploadUrlAsync(
            GetContentUploadUrlRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves a download URL for the requested report
        /// </summary>
        Task<PlayFabResult<GetDataReportResult>> GetDataReportAsync(
            GetDataReportRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Get the list of titles that the player has played
        /// </summary>
        Task<PlayFabResult<GetPlayedTitleListResult>> GetPlayedTitleListAsync(
            GetPlayedTitleListRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves a title-specific custom property value for a player.
        /// </summary>
        Task<PlayFabResult<GetPlayerCustomPropertyResult>> GetPlayerCustomPropertyAsync(
            GetPlayerCustomPropertyRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets a player's ID from an auth token.
        /// </summary>
        Task<PlayFabResult<GetPlayerIdFromAuthTokenResult>> GetPlayerIdFromAuthTokenAsync(
            GetPlayerIdFromAuthTokenRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves the player's profile
        /// </summary>
        Task<PlayFabResult<GetPlayerProfileResult>> GetPlayerProfileAsync(
            GetPlayerProfileRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// List all segments that a player currently belongs to at this moment in time.
        /// </summary>
        Task<PlayFabResult<GetPlayerSegmentsResult>> GetPlayerSegmentsAsync(
            GetPlayersSegmentsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Returns all Player Shared Secret Keys including disabled and expired.
        /// </summary>
        Task<PlayFabResult<GetPlayerSharedSecretsResult>> GetPlayerSharedSecretsAsync(
            GetPlayerSharedSecretsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Allows for paging through all players in a given segment. This API creates a snapshot of all player profiles that match
        /// the segment definition at the time of its creation and lives through the Total Seconds to Live, refreshing its life span
        /// on each subsequent use of the Continuation Token. Profiles that change during the course of paging will not be reflected
        /// in the results. AB Test segments are currently not supported by this operation. NOTE: This API is limited to being
        /// called 30 times in one minute. You will be returned an error if you exceed this threshold.
        /// </summary>
        Task<PlayFabResult<GetPlayersInSegmentResult>> GetPlayersInSegmentAsync(
            GetPlayersInSegmentRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves the configuration information for all player statistics defined in the title, regardless of whether they have
        /// a reset interval.
        /// </summary>
        Task<PlayFabResult<GetPlayerStatisticDefinitionsResult>> GetPlayerStatisticDefinitionsAsync(
            GetPlayerStatisticDefinitionsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves the information on the available versions of the specified statistic.
        /// </summary>
        Task<PlayFabResult<GetPlayerStatisticVersionsResult>> GetPlayerStatisticVersionsAsync(
            GetPlayerStatisticVersionsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Get all tags with a given Namespace (optional) from a player profile.
        /// </summary>
        Task<PlayFabResult<GetPlayerTagsResult>> GetPlayerTagsAsync(
            GetPlayerTagsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the requested policy.
        /// </summary>
        Task<PlayFabResult<GetPolicyResponse>> GetPolicyAsync(
            GetPolicyRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves the key-value store of custom publisher settings
        /// </summary>
        Task<PlayFabResult<GetPublisherDataResult>> GetPublisherDataAsync(
            GetPublisherDataRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Retrieves the random drop table configuration for the title
        /// </summary>
        Task<PlayFabResult<GetRandomResultTablesResult>> GetRandomResultTablesAsync(
            GetRandomResultTablesRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves the result of an export started by ExportPlayersInSegment API. If the ExportPlayersInSegment is successful and
        /// complete, this API returns the IndexUrl from which the index file can be downloaded. The index file has a list of urls
        /// from which the files containing the player profile data can be downloaded. Otherwise, it returns the current 'State' of
        /// the export
        /// </summary>
        Task<PlayFabResult<GetPlayersInSegmentExportResponse>> GetSegmentExportAsync(
            GetPlayersInSegmentExportRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Get detail information of a segment and its associated definition(s) and action(s) for a title.
        /// </summary>
        Task<PlayFabResult<GetSegmentsResponse>> GetSegmentsAsync(
            GetSegmentsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Retrieves the set of items defined for the specified store, including all prices defined
        /// </summary>
        Task<PlayFabResult<GetStoreItemsResult>> GetStoreItemsAsync(
            GetStoreItemsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Query for task instances by task, status, or time range.
        /// </summary>
        Task<PlayFabResult<GetTaskInstancesResult>> GetTaskInstancesAsync(
            GetTaskInstancesRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Get definition information on a specified task or all tasks within a title.
        /// </summary>
        Task<PlayFabResult<GetTasksResult>> GetTasksAsync(
            GetTasksRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves the key-value store of custom title settings which can be read by the client
        /// </summary>
        Task<PlayFabResult<GetTitleDataResult>> GetTitleDataAsync(
            GetTitleDataRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves the key-value store of custom title settings which cannot be read by the client
        /// </summary>
        Task<PlayFabResult<GetTitleDataResult>> GetTitleInternalDataAsync(
            GetTitleDataRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves the relevant details for a specified user, based upon a match against a supplied unique identifier
        /// </summary>
        Task<PlayFabResult<LookupUserAccountInfoResult>> GetUserAccountInfoAsync(
            LookupUserAccountInfoRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets all bans for a user.
        /// </summary>
        Task<PlayFabResult<GetUserBansResult>> GetUserBansAsync(
            GetUserBansRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves the title-specific custom data for the user which is readable and writable by the client
        /// </summary>
        Task<PlayFabResult<GetUserDataResult>> GetUserDataAsync(
            GetUserDataRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves the title-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        Task<PlayFabResult<GetUserDataResult>> GetUserInternalDataAsync(
            GetUserDataRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Retrieves the specified user's current inventory of virtual goods
        /// </summary>
        Task<PlayFabResult<GetUserInventoryResult>> GetUserInventoryAsync(
            GetUserInventoryRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves the publisher-specific custom data for the user which is readable and writable by the client
        /// </summary>
        Task<PlayFabResult<GetUserDataResult>> GetUserPublisherDataAsync(
            GetUserDataRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves the publisher-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        Task<PlayFabResult<GetUserDataResult>> GetUserPublisherInternalDataAsync(
            GetUserDataRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves the publisher-specific custom data for the user which can only be read by the client
        /// </summary>
        Task<PlayFabResult<GetUserDataResult>> GetUserPublisherReadOnlyDataAsync(
            GetUserDataRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves the title-specific custom data for the user which can only be read by the client
        /// </summary>
        Task<PlayFabResult<GetUserDataResult>> GetUserReadOnlyDataAsync(
            GetUserDataRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Adds the specified items to the specified user inventories
        /// </summary>
        Task<PlayFabResult<GrantItemsToUsersResult>> GrantItemsToUsersAsync(
            GrantItemsToUsersRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Increases the global count for the given scarce resource.
        /// </summary>
        Task<PlayFabResult<IncrementLimitedEditionItemAvailabilityResult>> IncrementLimitedEditionItemAvailabilityAsync(
            IncrementLimitedEditionItemAvailabilityRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Resets the indicated statistic, removing all player entries for it and backing up the old values.
        /// </summary>
        Task<PlayFabResult<IncrementPlayerStatisticVersionResult>> IncrementPlayerStatisticVersionAsync(
            IncrementPlayerStatisticVersionRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves a list of all Open ID Connect providers registered to a title.
        /// </summary>
        Task<PlayFabResult<ListOpenIdConnectionResponse>> ListOpenIdConnectionAsync(
            ListOpenIdConnectionRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves title-specific custom property values for a player.
        /// </summary>
        Task<PlayFabResult<ListPlayerCustomPropertiesResult>> ListPlayerCustomPropertiesAsync(
            ListPlayerCustomPropertiesRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Retuns the list of all defined virtual currencies for the title
        /// </summary>
        Task<PlayFabResult<ListVirtualCurrencyTypesResult>> ListVirtualCurrencyTypesAsync(
            ListVirtualCurrencyTypesRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Attempts to process an order refund through the original real money payment provider.
        /// </summary>
        Task<PlayFabResult<RefundPurchaseResponse>> RefundPurchaseAsync(
            RefundPurchaseRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Remove a given tag from a player profile. The tag's namespace is automatically generated based on the source of the tag.
        /// </summary>
        Task<PlayFabResult<RemovePlayerTagResult>> RemovePlayerTagAsync(
            RemovePlayerTagRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Removes one or more virtual currencies from the set defined for the title.
        /// </summary>
        Task<PlayFabResult<BlankResult>> RemoveVirtualCurrencyTypesAsync(
            RemoveVirtualCurrencyTypesRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Completely removes all statistics for the specified character, for the current game
        /// </summary>
        Task<PlayFabResult<ResetCharacterStatisticsResult>> ResetCharacterStatisticsAsync(
            ResetCharacterStatisticsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Reset a player's password for a given title.
        /// </summary>
        Task<PlayFabResult<ResetPasswordResult>> ResetPasswordAsync(
            ResetPasswordRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Completely removes all statistics for the specified user, for the current game
        /// </summary>
        Task<PlayFabResult<ResetUserStatisticsResult>> ResetUserStatisticsAsync(
            ResetUserStatisticsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Attempts to resolve a dispute with the original order's payment provider.
        /// </summary>
        Task<PlayFabResult<ResolvePurchaseDisputeResponse>> ResolvePurchaseDisputeAsync(
            ResolvePurchaseDisputeRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Revoke all active bans for a user.
        /// </summary>
        Task<PlayFabResult<RevokeAllBansForUserResult>> RevokeAllBansForUserAsync(
            RevokeAllBansForUserRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Revoke all active bans specified with BanId.
        /// </summary>
        Task<PlayFabResult<RevokeBansResult>> RevokeBansAsync(
            RevokeBansRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Revokes access to an item in a user's inventory
        /// </summary>
        Task<PlayFabResult<RevokeInventoryResult>> RevokeInventoryItemAsync(
            RevokeInventoryItemRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Revokes access for up to 25 items across multiple users and characters.
        /// </summary>
        Task<PlayFabResult<RevokeInventoryItemsResult>> RevokeInventoryItemsAsync(
            RevokeInventoryItemsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Run a task immediately regardless of its schedule.
        /// </summary>
        Task<PlayFabResult<RunTaskResult>> RunTaskAsync(
            RunTaskRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Forces an email to be sent to the registered email address for the user's account, with a link allowing the user to
        /// change the password.If an account recovery email template ID is provided, an email using the custom email template will
        /// be used.
        /// </summary>
        Task<PlayFabResult<SendAccountRecoveryEmailResult>> SendAccountRecoveryEmailAsync(
            SendAccountRecoveryEmailRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Creates the catalog configuration of all virtual goods for the specified catalog version
        /// </summary>
        Task<PlayFabResult<UpdateCatalogItemsResult>> SetCatalogItemsAsync(
            UpdateCatalogItemsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Sets the override expiration for a membership subscription
        /// </summary>
        Task<PlayFabResult<SetMembershipOverrideResult>> SetMembershipOverrideAsync(
            SetMembershipOverrideRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Sets or resets the player's secret. Player secrets are used to sign API requests.
        /// </summary>
        Task<PlayFabResult<SetPlayerSecretResult>> SetPlayerSecretAsync(
            SetPlayerSecretRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Sets the currently published revision of a title Cloud Script
        /// </summary>
        Task<PlayFabResult<SetPublishedRevisionResult>> SetPublishedRevisionAsync(
            SetPublishedRevisionRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates the key-value store of custom publisher settings
        /// </summary>
        Task<PlayFabResult<SetPublisherDataResult>> SetPublisherDataAsync(
            SetPublisherDataRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Sets all the items in one virtual store
        /// </summary>
        Task<PlayFabResult<UpdateStoreItemsResult>> SetStoreItemsAsync(
            UpdateStoreItemsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Creates and updates the key-value store of custom title settings which can be read by the client. For example, a
        /// developer could choose to store values which modify the user experience, such as enemy spawn rates, weapon strengths,
        /// movement speeds, etc. This allows a developer to update the title without the need to create, test, and ship a new
        /// build.
        /// </summary>
        Task<PlayFabResult<SetTitleDataResult>> SetTitleDataAsync(
            SetTitleDataRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Set and delete key-value pairs in a title data override instance.
        /// </summary>
        Task<PlayFabResult<SetTitleDataAndOverridesResult>> SetTitleDataAndOverridesAsync(
            SetTitleDataAndOverridesRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates the key-value store of custom title settings which cannot be read by the client. These values can be used to
        /// tweak settings used by game servers and Cloud Scripts without the need to update and re-deploy.
        /// </summary>
        Task<PlayFabResult<SetTitleDataResult>> SetTitleInternalDataAsync(
            SetTitleDataRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Sets the Amazon Resource Name (ARN) for iOS and Android push notifications. Documentation on the exact restrictions can
        /// be found at: http://docs.aws.amazon.com/sns/latest/api/API_CreatePlatformApplication.html. Currently, Amazon device
        /// Messaging is not supported.
        /// </summary>
        Task<PlayFabResult<SetupPushNotificationResult>> SetupPushNotificationAsync(
            SetupPushNotificationRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Decrements the specified virtual currency by the stated amount
        /// </summary>
        Task<PlayFabResult<ModifyUserVirtualCurrencyResult>> SubtractUserVirtualCurrencyAsync(
            SubtractUserVirtualCurrencyRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates information of a list of existing bans specified with Ban Ids.
        /// </summary>
        Task<PlayFabResult<UpdateBansResult>> UpdateBansAsync(
            UpdateBansRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Updates the catalog configuration for virtual goods in the specified catalog version
        /// </summary>
        Task<PlayFabResult<UpdateCatalogItemsResult>> UpdateCatalogItemsAsync(
            UpdateCatalogItemsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Creates a new Cloud Script revision and uploads source code to it. Note that at this time, only one file should be
        /// submitted in the revision.
        /// </summary>
        Task<PlayFabResult<UpdateCloudScriptResult>> UpdateCloudScriptAsync(
            UpdateCloudScriptRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Modifies data and credentials for an existing relationship between a title and an Open ID Connect provider
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> UpdateOpenIdConnectionAsync(
            UpdateOpenIdConnectionRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates the title-specific custom property values for a player
        /// </summary>
        Task<PlayFabResult<UpdatePlayerCustomPropertiesResult>> UpdatePlayerCustomPropertiesAsync(
            UpdatePlayerCustomPropertiesRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates a existing Player Shared Secret Key. It may take up to 5 minutes for this update to become generally available
        /// after this API returns.
        /// </summary>
        Task<PlayFabResult<UpdatePlayerSharedSecretResult>> UpdatePlayerSharedSecretAsync(
            UpdatePlayerSharedSecretRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates a player statistic configuration for the title, optionally allowing the developer to specify a reset interval.
        /// </summary>
        Task<PlayFabResult<UpdatePlayerStatisticDefinitionResult>> UpdatePlayerStatisticDefinitionAsync(
            UpdatePlayerStatisticDefinitionRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Changes a policy for a title
        /// </summary>
        Task<PlayFabResult<UpdatePolicyResponse>> UpdatePolicyAsync(
            UpdatePolicyRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Updates the random drop table configuration for the title
        /// </summary>
        Task<PlayFabResult<UpdateRandomResultTablesResult>> UpdateRandomResultTablesAsync(
            UpdateRandomResultTablesRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates an existing player segment and its associated definition(s) and action(s) for a title.
        /// </summary>
        Task<PlayFabResult<UpdateSegmentResponse>> UpdateSegmentAsync(
            UpdateSegmentRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Updates an existing virtual item store with new or modified items
        /// </summary>
        Task<PlayFabResult<UpdateStoreItemsResult>> UpdateStoreItemsAsync(
            UpdateStoreItemsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Update an existing task.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> UpdateTaskAsync(
            UpdateTaskRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates the title-specific custom data for the user which is readable and writable by the client
        /// </summary>
        Task<PlayFabResult<UpdateUserDataResult>> UpdateUserDataAsync(
            UpdateUserDataRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates the title-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        Task<PlayFabResult<UpdateUserDataResult>> UpdateUserInternalDataAsync(
            UpdateUserInternalDataRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates the publisher-specific custom data for the user which is readable and writable by the client
        /// </summary>
        Task<PlayFabResult<UpdateUserDataResult>> UpdateUserPublisherDataAsync(
            UpdateUserDataRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates the publisher-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        Task<PlayFabResult<UpdateUserDataResult>> UpdateUserPublisherInternalDataAsync(
            UpdateUserInternalDataRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates the publisher-specific custom data for the user which can only be read by the client
        /// </summary>
        Task<PlayFabResult<UpdateUserDataResult>> UpdateUserPublisherReadOnlyDataAsync(
            UpdateUserDataRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates the title-specific custom data for the user which can only be read by the client
        /// </summary>
        Task<PlayFabResult<UpdateUserDataResult>> UpdateUserReadOnlyDataAsync(
            UpdateUserDataRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates the title specific display name for a user
        /// </summary>
        Task<PlayFabResult<UpdateUserTitleDisplayNameResult>> UpdateUserTitleDisplayNameAsync(
            UpdateUserTitleDisplayNameRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);
    }
}
#endif
