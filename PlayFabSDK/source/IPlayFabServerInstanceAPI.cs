#if ENABLE_PLAYFABSERVER_API

using PlayFab.ServerModels;
using PlayFab.Internal;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayFab
{
    /// <summary>
    /// Provides functionality to allow external (developer-controlled) servers to interact with user inventories and data in a
    /// trusted manner, and to handle matchmaking and client connection orchestration
    /// </summary>
    public interface IPlayFabServerInstanceAPI
    {
        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Increments the character's balance of the specified virtual currency by the stated amount
        /// </summary>
        Task<PlayFabResult<ModifyCharacterVirtualCurrencyResult>> AddCharacterVirtualCurrencyAsync(
            AddCharacterVirtualCurrencyRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Adds the Friend user to the friendlist of the user with PlayFabId. At least one of
        /// FriendPlayFabId,FriendUsername,FriendEmail, or FriendTitleDisplayName should be initialized.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> AddFriendAsync(
            AddFriendRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Adds the specified generic service identifier to the player's PlayFab account. This is designed to allow for a PlayFab
        /// ID lookup of any arbitrary service identifier a title wants to add. This identifier should never be used as
        /// authentication credentials, as the intent is that it is easily accessible by other players.
        /// </summary>
        Task<PlayFabResult<EmptyResult>> AddGenericIDAsync(
            AddGenericIDRequest request,
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
        /// Adds users to the set of those able to update both the shared data, as well as the set of users in the group. Only users
        /// in the group (and the server) can add new members. Shared Groups are designed for sharing data between a very small
        /// number of players, please see our guide:
        /// https://docs.microsoft.com/gaming/playfab/features/social/groups/using-shared-group-data
        /// </summary>
        Task<PlayFabResult<AddSharedGroupMembersResult>> AddSharedGroupMembersAsync(
            AddSharedGroupMembersRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Increments the user's balance of the specified virtual currency by the stated amount
        /// </summary>
        Task<PlayFabResult<ModifyUserVirtualCurrencyResult>> AddUserVirtualCurrencyAsync(
            AddUserVirtualCurrencyRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Validated a client's session ticket, and if successful, returns details for that user
        /// </summary>
        Task<PlayFabResult<AuthenticateSessionTicketResult>> AuthenticateSessionTicketAsync(
            AuthenticateSessionTicketRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Awards the specified users the specified Steam achievements
        /// </summary>
        Task<PlayFabResult<AwardSteamAchievementResult>> AwardSteamAchievementAsync(
            AwardSteamAchievementRequest request,
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
        /// version 2._ Consume uses of a consumable item. When all uses are consumed, it will be removed from the player's
        /// inventory.
        /// </summary>
        Task<PlayFabResult<ConsumeItemResult>> ConsumeItemAsync(
            ConsumeItemRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Requests the creation of a shared group object, containing key/value pairs which may be updated by all members of the
        /// group. When created by a server, the group will initially have no members. Shared Groups are designed for sharing data
        /// between a very small number of players, please see our guide:
        /// https://docs.microsoft.com/gaming/playfab/features/social/groups/using-shared-group-data
        /// </summary>
        Task<PlayFabResult<CreateSharedGroupResult>> CreateSharedGroupAsync(
            CreateSharedGroupRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes the specific character ID from the specified user.
        /// </summary>
        Task<PlayFabResult<DeleteCharacterFromUserResult>> DeleteCharacterFromUserAsync(
            DeleteCharacterFromUserRequest request,
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
        /// Deletes push notification template for title
        /// </summary>
        Task<PlayFabResult<DeletePushNotificationTemplateResult>> DeletePushNotificationTemplateAsync(
            DeletePushNotificationTemplateRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes a shared group, freeing up the shared group ID to be reused for a new group. Shared Groups are designed for
        /// sharing data between a very small number of players, please see our guide:
        /// https://docs.microsoft.com/gaming/playfab/features/social/groups/using-shared-group-data
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> DeleteSharedGroupAsync(
            DeleteSharedGroupRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Returns the result of an evaluation of a Random Result Table - the ItemId from the game Catalog which would
        /// have been added to the player inventory, if the Random Result Table were added via a Bundle or a call to
        /// UnlockContainer.
        /// </summary>
        Task<PlayFabResult<EvaluateRandomResultTableResult>> EvaluateRandomResultTableAsync(
            EvaluateRandomResultTableRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Executes a CloudScript function, with the 'currentPlayerId' set to the PlayFab ID of the authenticated player. The
        /// PlayFab ID is the entity ID of the player's master_player_account entity.
        /// </summary>
        Task<PlayFabResult<ExecuteCloudScriptResult>> ExecuteCloudScriptAsync(
            ExecuteCloudScriptServerRequest request,
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
        /// Lists all of the characters that belong to a specific user. CharacterIds are not globally unique; characterId must be
        /// evaluated with the parent PlayFabId to guarantee uniqueness.
        /// </summary>
        Task<PlayFabResult<ListUsersCharactersResult>> GetAllUsersCharactersAsync(
            ListUsersCharactersRequest request,
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
        /// Retrieves the title-specific custom data for the user which is readable and writable by the client
        /// </summary>
        Task<PlayFabResult<GetCharacterDataResult>> GetCharacterDataAsync(
            GetCharacterDataRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves the title-specific custom data for the user's character which cannot be accessed by the client
        /// </summary>
        Task<PlayFabResult<GetCharacterDataResult>> GetCharacterInternalDataAsync(
            GetCharacterDataRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Retrieves the specified character's current inventory of virtual goods
        /// </summary>
        Task<PlayFabResult<GetCharacterInventoryResult>> GetCharacterInventoryAsync(
            GetCharacterInventoryRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves a list of ranked characters for the given statistic, starting from the indicated point in the leaderboard
        /// </summary>
        Task<PlayFabResult<GetCharacterLeaderboardResult>> GetCharacterLeaderboardAsync(
            GetCharacterLeaderboardRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves the title-specific custom data for the user's character which can only be read by the client
        /// </summary>
        Task<PlayFabResult<GetCharacterDataResult>> GetCharacterReadOnlyDataAsync(
            GetCharacterDataRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves the details of all title-specific statistics for the specific character
        /// </summary>
        Task<PlayFabResult<GetCharacterStatisticsResult>> GetCharacterStatisticsAsync(
            GetCharacterStatisticsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// This API retrieves a pre-signed URL for accessing a content file for the title. A subsequent HTTP GET to the returned
        /// URL will attempt to download the content. A HEAD query to the returned URL will attempt to retrieve the metadata of the
        /// content. Note that a successful result does not guarantee the existence of this content - if it has not been uploaded,
        /// the query to retrieve the data will fail. See this post for more information:
        /// https://community.playfab.com/hc/community/posts/205469488-How-to-upload-files-to-PlayFab-s-Content-Service. Also,
        /// please be aware that the Content service is specifically PlayFab's CDN offering, for which standard CDN rates apply.
        /// </summary>
        Task<PlayFabResult<GetContentDownloadUrlResult>> GetContentDownloadUrlAsync(
            GetContentDownloadUrlRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves a list of ranked friends of the given player for the given statistic, starting from the indicated point in the
        /// leaderboard
        /// </summary>
        Task<PlayFabResult<GetLeaderboardResult>> GetFriendLeaderboardAsync(
            GetFriendLeaderboardRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves the current friends for the user with PlayFabId, constrained to users who have PlayFab accounts. Friends from
        /// linked accounts (Facebook, Steam) are also included. You may optionally exclude some linked services' friends.
        /// </summary>
        Task<PlayFabResult<GetFriendsListResult>> GetFriendsListAsync(
            GetFriendsListRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves a list of ranked users for the given statistic, starting from the indicated point in the leaderboard
        /// </summary>
        Task<PlayFabResult<GetLeaderboardResult>> GetLeaderboardAsync(
            GetLeaderboardRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves a list of ranked characters for the given statistic, centered on the requested user
        /// </summary>
        Task<PlayFabResult<GetLeaderboardAroundCharacterResult>> GetLeaderboardAroundCharacterAsync(
            GetLeaderboardAroundCharacterRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves a list of ranked users for the given statistic, centered on the currently signed-in user
        /// </summary>
        Task<PlayFabResult<GetLeaderboardAroundUserResult>> GetLeaderboardAroundUserAsync(
            GetLeaderboardAroundUserRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves a list of all of the user's characters for the given statistic.
        /// </summary>
        Task<PlayFabResult<GetLeaderboardForUsersCharactersResult>> GetLeaderboardForUserCharactersAsync(
            GetLeaderboardForUsersCharactersRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Returns whatever info is requested in the response for the user. Note that PII (like email address, facebook id) may be
        /// returned. All parameters default to false.
        /// </summary>
        Task<PlayFabResult<GetPlayerCombinedInfoResult>> GetPlayerCombinedInfoAsync(
            GetPlayerCombinedInfoRequest request,
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
        /// Allows for paging through all players in a given segment. This API creates a snapshot of all player profiles that match
        /// the segment definition at the time of its creation and lives through the Total Seconds to Live, refreshing its life span
        /// on each subsequent use of the Continuation Token. Profiles that change during the course of paging will not be reflected
        /// in the results. AB Test segments are currently not supported by this operation. NOTE: This API is limited to being
        /// called 30 times in one minute. You will be returned an error if you exceed this threshold.
        /// </summary>
[Obsolete("No longer available", false)]        Task<PlayFabResult<GetPlayersInSegmentResult>> GetPlayersInSegmentAsync(
            GetPlayersInSegmentRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves the current version and values for the indicated statistics, for the local player.
        /// </summary>
        Task<PlayFabResult<GetPlayerStatisticsResult>> GetPlayerStatisticsAsync(
            GetPlayerStatisticsRequest request,
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
        /// Retrieves the unique PlayFab identifiers for the given set of Battle.net account identifiers.
        /// </summary>
        Task<PlayFabResult<GetPlayFabIDsFromBattleNetAccountIdsResult>> GetPlayFabIDsFromBattleNetAccountIdsAsync(
            GetPlayFabIDsFromBattleNetAccountIdsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Facebook identifiers.
        /// </summary>
        Task<PlayFabResult<GetPlayFabIDsFromFacebookIDsResult>> GetPlayFabIDsFromFacebookIDsAsync(
            GetPlayFabIDsFromFacebookIDsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Facebook Instant Games identifiers.
        /// </summary>
        Task<PlayFabResult<GetPlayFabIDsFromFacebookInstantGamesIdsResult>> GetPlayFabIDsFromFacebookInstantGamesIdsAsync(
            GetPlayFabIDsFromFacebookInstantGamesIdsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of generic service identifiers. A generic identifier is the
        /// service name plus the service-specific ID for the player, as specified by the title when the generic identifier was
        /// added to the player account.
        /// </summary>
        Task<PlayFabResult<GetPlayFabIDsFromGenericIDsResult>> GetPlayFabIDsFromGenericIDsAsync(
            GetPlayFabIDsFromGenericIDsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Nintendo Service Account identifiers.
        /// </summary>
        Task<PlayFabResult<GetPlayFabIDsFromNintendoServiceAccountIdsResult>> GetPlayFabIDsFromNintendoServiceAccountIdsAsync(
            GetPlayFabIDsFromNintendoServiceAccountIdsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Nintendo Switch Device identifiers.
        /// </summary>
        Task<PlayFabResult<GetPlayFabIDsFromNintendoSwitchDeviceIdsResult>> GetPlayFabIDsFromNintendoSwitchDeviceIdsAsync(
            GetPlayFabIDsFromNintendoSwitchDeviceIdsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of PlayStation :tm: Network identifiers.
        /// </summary>
        Task<PlayFabResult<GetPlayFabIDsFromPSNAccountIDsResult>> GetPlayFabIDsFromPSNAccountIDsAsync(
            GetPlayFabIDsFromPSNAccountIDsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of PlayStation :tm: Network identifiers.
        /// </summary>
        Task<PlayFabResult<GetPlayFabIDsFromPSNOnlineIDsResult>> GetPlayFabIDsFromPSNOnlineIDsAsync(
            GetPlayFabIDsFromPSNOnlineIDsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Steam identifiers. The Steam identifiers are the profile
        /// IDs for the user accounts, available as SteamId in the Steamworks Community API calls.
        /// </summary>
        Task<PlayFabResult<GetPlayFabIDsFromSteamIDsResult>> GetPlayFabIDsFromSteamIDsAsync(
            GetPlayFabIDsFromSteamIDsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Steam identifiers. The Steam identifiers are persona
        /// names.
        /// </summary>
        Task<PlayFabResult<GetPlayFabIDsFromSteamNamesResult>> GetPlayFabIDsFromSteamNamesAsync(
            GetPlayFabIDsFromSteamNamesRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Twitch identifiers. The Twitch identifiers are the IDs for
        /// the user accounts, available as "_id" from the Twitch API methods (ex:
        /// https://github.com/justintv/Twitch-API/blob/master/v3_resources/users.md#get-usersuser).
        /// </summary>
        Task<PlayFabResult<GetPlayFabIDsFromTwitchIDsResult>> GetPlayFabIDsFromTwitchIDsAsync(
            GetPlayFabIDsFromTwitchIDsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of XboxLive identifiers.
        /// </summary>
        Task<PlayFabResult<GetPlayFabIDsFromXboxLiveIDsResult>> GetPlayFabIDsFromXboxLiveIDsAsync(
            GetPlayFabIDsFromXboxLiveIDsRequest request,
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
        /// version 2._ Retrieves the configuration information for the specified random results tables for the title, including all
        /// ItemId values and weights
        /// </summary>
        Task<PlayFabResult<GetRandomResultTablesResult>> GetRandomResultTablesAsync(
            GetRandomResultTablesRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves the associated PlayFab account identifiers for the given set of server custom identifiers.
        /// </summary>
        Task<PlayFabResult<GetServerCustomIDsFromPlayFabIDsResult>> GetServerCustomIDsFromPlayFabIDsAsync(
            GetServerCustomIDsFromPlayFabIDsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves data stored in a shared group object, as well as the list of members in the group. The server can access all
        /// public and private group data. Shared Groups are designed for sharing data between a very small number of players,
        /// please see our guide: https://docs.microsoft.com/gaming/playfab/features/social/groups/using-shared-group-data
        /// </summary>
        Task<PlayFabResult<GetSharedGroupDataResult>> GetSharedGroupDataAsync(
            GetSharedGroupDataRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Retrieves the set of items defined for the specified store, including all prices defined, for the specified
        /// player
        /// </summary>
        Task<PlayFabResult<GetStoreItemsResult>> GetStoreItemsAsync(
            GetStoreItemsServerRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves the current server time
        /// </summary>
        Task<PlayFabResult<GetTimeResult>> GetTimeAsync(
            GetTimeRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves the key-value store of custom title settings
        /// </summary>
        Task<PlayFabResult<GetTitleDataResult>> GetTitleDataAsync(
            GetTitleDataRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves the key-value store of custom internal title settings
        /// </summary>
        Task<PlayFabResult<GetTitleDataResult>> GetTitleInternalDataAsync(
            GetTitleDataRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves the title news feed, as configured in the developer portal
        /// </summary>
        Task<PlayFabResult<GetTitleNewsResult>> GetTitleNewsAsync(
            GetTitleNewsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves the relevant details for a specified user
        /// </summary>
        Task<PlayFabResult<GetUserAccountInfoResult>> GetUserAccountInfoAsync(
            GetUserAccountInfoRequest request,
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
        /// Grants the specified character type to the user. CharacterIds are not globally unique; characterId must be evaluated
        /// with the parent PlayFabId to guarantee uniqueness.
        /// </summary>
        Task<PlayFabResult<GrantCharacterToUserResult>> GrantCharacterToUserAsync(
            GrantCharacterToUserRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Adds the specified items to the specified character's inventory
        /// </summary>
        Task<PlayFabResult<GrantItemsToCharacterResult>> GrantItemsToCharacterAsync(
            GrantItemsToCharacterRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Adds the specified items to the specified user's inventory
        /// </summary>
        Task<PlayFabResult<GrantItemsToUserResult>> GrantItemsToUserAsync(
            GrantItemsToUserRequest request,
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
        /// Links the Battle.net account associated with the token to the user's PlayFab account.
        /// </summary>
        Task<PlayFabResult<EmptyResult>> LinkBattleNetAccountAsync(
            LinkBattleNetAccountRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Links the Nintendo account associated with the token to the user's PlayFab account
        /// </summary>
        Task<PlayFabResult<EmptyResult>> LinkNintendoServiceAccountAsync(
            LinkNintendoServiceAccountRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Links the Nintendo account associated with the Nintendo Service Account subject or id to the user's PlayFab account
        /// </summary>
        Task<PlayFabResult<EmptyResult>> LinkNintendoServiceAccountSubjectAsync(
            LinkNintendoServiceAccountSubjectRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Links the NintendoSwitchDeviceId to the user's PlayFab account
        /// </summary>
        Task<PlayFabResult<LinkNintendoSwitchDeviceIdResult>> LinkNintendoSwitchDeviceIdAsync(
            LinkNintendoSwitchDeviceIdRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Links the PlayStation :tm: Network account associated with the provided access code to the user's PlayFab account
        /// </summary>
        Task<PlayFabResult<LinkPSNAccountResult>> LinkPSNAccountAsync(
            LinkPSNAccountRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Links the PlayStation :tm: Network account associated with the provided user id to the user's PlayFab account
        /// </summary>
        Task<PlayFabResult<LinkPSNIdResponse>> LinkPSNIdAsync(
            LinkPSNIdRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Links the custom server identifier, generated by the title, to the user's PlayFab account.
        /// </summary>
        Task<PlayFabResult<LinkServerCustomIdResult>> LinkServerCustomIdAsync(
            LinkServerCustomIdRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Links the Steam account associated with the provided Steam ID to the user's PlayFab account
        /// </summary>
        Task<PlayFabResult<LinkSteamIdResult>> LinkSteamIdAsync(
            LinkSteamIdRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Links the Xbox Live account associated with the provided access code to the user's PlayFab account
        /// </summary>
        Task<PlayFabResult<LinkXboxAccountResult>> LinkXboxAccountAsync(
            LinkXboxAccountRequest request,
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
        /// Signs the user in using the Android device identifier, returning a session identifier that can subsequently be used for
        /// API calls which require an authenticated user
        /// </summary>
        Task<PlayFabResult<ServerLoginResult>> LoginWithAndroidDeviceIDAsync(
            LoginWithAndroidDeviceIDRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Sign in the user with a Battle.net identity token
        /// </summary>
        Task<PlayFabResult<ServerLoginResult>> LoginWithBattleNetAsync(
            LoginWithBattleNetRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Signs the user in using a custom unique identifier generated by the title, returning a session identifier that can
        /// subsequently be used for API calls which require an authenticated user
        /// </summary>
        Task<PlayFabResult<ServerLoginResult>> LoginWithCustomIDAsync(
            LoginWithCustomIDRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Signs the user in using the iOS device identifier, returning a session identifier that can subsequently be used for API
        /// calls which require an authenticated user
        /// </summary>
        Task<PlayFabResult<ServerLoginResult>> LoginWithIOSDeviceIDAsync(
            LoginWithIOSDeviceIDRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Signs the user in using a PlayStation :tm: Network authentication code, returning a session identifier that can
        /// subsequently be used for API calls which require an authenticated user
        /// </summary>
        Task<PlayFabResult<ServerLoginResult>> LoginWithPSNAsync(
            LoginWithPSNRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Securely login a game client from an external server backend using a custom identifier for that player. Server Custom ID
        /// and Client Custom ID are mutually exclusive and cannot be used to retrieve the same player account.
        /// </summary>
        Task<PlayFabResult<ServerLoginResult>> LoginWithServerCustomIdAsync(
            LoginWithServerCustomIdRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Signs the user in using an Steam ID, returning a session identifier that can subsequently be used for API calls which
        /// require an authenticated user
        /// </summary>
        Task<PlayFabResult<ServerLoginResult>> LoginWithSteamIdAsync(
            LoginWithSteamIdRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Signs the user in using a Xbox Live Token from an external server backend, returning a session identifier that can
        /// subsequently be used for API calls which require an authenticated user
        /// </summary>
        Task<PlayFabResult<ServerLoginResult>> LoginWithXboxAsync(
            LoginWithXboxRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Signs the user in using an Xbox ID and Sandbox ID, returning a session identifier that can subsequently be used for API
        /// calls which require an authenticated user
        /// </summary>
        Task<PlayFabResult<ServerLoginResult>> LoginWithXboxIdAsync(
            LoginWithXboxIdRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Modifies the number of remaining uses of a player's inventory item
        /// </summary>
        Task<PlayFabResult<ModifyItemUsesResult>> ModifyItemUsesAsync(
            ModifyItemUsesRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Moves an item from a character's inventory into another of the users's character's inventory.
        /// </summary>
        Task<PlayFabResult<MoveItemToCharacterFromCharacterResult>> MoveItemToCharacterFromCharacterAsync(
            MoveItemToCharacterFromCharacterRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Moves an item from a user's inventory into their character's inventory.
        /// </summary>
        Task<PlayFabResult<MoveItemToCharacterFromUserResult>> MoveItemToCharacterFromUserAsync(
            MoveItemToCharacterFromUserRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Moves an item from a character's inventory into the owning user's inventory.
        /// </summary>
        Task<PlayFabResult<MoveItemToUserFromCharacterResult>> MoveItemToUserFromCharacterAsync(
            MoveItemToUserFromCharacterRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Adds the virtual goods associated with the coupon to the user's inventory. Coupons can be generated via the
        /// Economy->Catalogs tab in the PlayFab Game Manager.
        /// </summary>
        Task<PlayFabResult<RedeemCouponResult>> RedeemCouponAsync(
            RedeemCouponRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Removes the specified friend from the the user's friend list
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> RemoveFriendAsync(
            RemoveFriendRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Removes the specified generic service identifier from the player's PlayFab account.
        /// </summary>
        Task<PlayFabResult<EmptyResult>> RemoveGenericIDAsync(
            RemoveGenericIDRequest request,
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
        /// Removes users from the set of those able to update the shared data and the set of users in the group. Only users in the
        /// group can remove members. If as a result of the call, zero users remain with access, the group and its associated data
        /// will be deleted. Shared Groups are designed for sharing data between a very small number of players, please see our
        /// guide: https://docs.microsoft.com/gaming/playfab/features/social/groups/using-shared-group-data
        /// </summary>
        Task<PlayFabResult<RemoveSharedGroupMembersResult>> RemoveSharedGroupMembersAsync(
            RemoveSharedGroupMembersRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Submit a report about a player (due to bad bahavior, etc.) on behalf of another player, so that customer service
        /// representatives for the title can take action concerning potentially toxic players.
        /// </summary>
        Task<PlayFabResult<ReportPlayerServerResult>> ReportPlayerAsync(
            ReportPlayerServerRequest request,
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
        /// Saves push notification template for title
        /// </summary>
        Task<PlayFabResult<SavePushNotificationTemplateResult>> SavePushNotificationTemplateAsync(
            SavePushNotificationTemplateRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Forces an email to be sent to the registered contact email address for the user's account based on an account recovery
        /// email template
        /// </summary>
        Task<PlayFabResult<SendCustomAccountRecoveryEmailResult>> SendCustomAccountRecoveryEmailAsync(
            SendCustomAccountRecoveryEmailRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Sends an email based on an email template to a player's contact email
        /// </summary>
        Task<PlayFabResult<SendEmailFromTemplateResult>> SendEmailFromTemplateAsync(
            SendEmailFromTemplateRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Sends an iOS/Android Push Notification to a specific user, if that user's device has been configured for Push
        /// Notifications in PlayFab. If a user has linked both Android and iOS devices, both will be notified.
        /// </summary>
        Task<PlayFabResult<SendPushNotificationResult>> SendPushNotificationAsync(
            SendPushNotificationRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Sends an iOS/Android Push Notification template to a specific user, if that user's device has been configured for Push
        /// Notifications in PlayFab. If a user has linked both Android and iOS devices, both will be notified.
        /// </summary>
        Task<PlayFabResult<SendPushNotificationResult>> SendPushNotificationFromTemplateAsync(
            SendPushNotificationFromTemplateRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates the tag list for a specified user in the friend list of another user
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> SetFriendTagsAsync(
            SetFriendTagsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Sets the player's secret if it is not already set. Player secrets are used to sign API requests. To reset a player's
        /// secret use the Admin or Server API method SetPlayerSecret.
        /// </summary>
        Task<PlayFabResult<SetPlayerSecretResult>> SetPlayerSecretAsync(
            SetPlayerSecretRequest request,
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
        /// Updates the key-value store of custom title settings
        /// </summary>
        Task<PlayFabResult<SetTitleDataResult>> SetTitleDataAsync(
            SetTitleDataRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates the key-value store of custom title settings
        /// </summary>
        Task<PlayFabResult<SetTitleDataResult>> SetTitleInternalDataAsync(
            SetTitleDataRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Decrements the character's balance of the specified virtual currency by the stated amount. It is possible to
        /// make a VC balance negative with this API.
        /// </summary>
        Task<PlayFabResult<ModifyCharacterVirtualCurrencyResult>> SubtractCharacterVirtualCurrencyAsync(
            SubtractCharacterVirtualCurrencyRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Decrements the user's balance of the specified virtual currency by the stated amount. It is possible to make
        /// a VC balance negative with this API.
        /// </summary>
        Task<PlayFabResult<ModifyUserVirtualCurrencyResult>> SubtractUserVirtualCurrencyAsync(
            SubtractUserVirtualCurrencyRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unlinks the related Battle.net account from the user's PlayFab account.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> UnlinkBattleNetAccountAsync(
            UnlinkBattleNetAccountRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unlinks the related Nintendo account from the user's PlayFab account
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> UnlinkNintendoServiceAccountAsync(
            UnlinkNintendoServiceAccountRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unlinks the related NintendoSwitchDeviceId from the user's PlayFab account
        /// </summary>
        Task<PlayFabResult<UnlinkNintendoSwitchDeviceIdResult>> UnlinkNintendoSwitchDeviceIdAsync(
            UnlinkNintendoSwitchDeviceIdRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unlinks the related PlayStation :tm: Network account from the user's PlayFab account
        /// </summary>
        Task<PlayFabResult<UnlinkPSNAccountResult>> UnlinkPSNAccountAsync(
            UnlinkPSNAccountRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unlinks the custom server identifier from the user's PlayFab account.
        /// </summary>
        Task<PlayFabResult<UnlinkServerCustomIdResult>> UnlinkServerCustomIdAsync(
            UnlinkServerCustomIdRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unlinks the Steam account associated with the provided Steam ID to the user's PlayFab account
        /// </summary>
        Task<PlayFabResult<UnlinkSteamIdResult>> UnlinkSteamIdAsync(
            UnlinkSteamIdRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unlinks the related Xbox Live account from the user's PlayFab account
        /// </summary>
        Task<PlayFabResult<UnlinkXboxAccountResult>> UnlinkXboxAccountAsync(
            UnlinkXboxAccountRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Opens a specific container (ContainerItemInstanceId), with a specific key (KeyItemInstanceId, when
        /// required), and returns the contents of the opened container. If the container (and key when relevant) are consumable
        /// (RemainingUses > 0), their RemainingUses will be decremented, consistent with the operation of ConsumeItem.
        /// </summary>
        Task<PlayFabResult<UnlockContainerItemResult>> UnlockContainerInstanceAsync(
            UnlockContainerInstanceRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Searches Player or Character inventory for any ItemInstance matching the given CatalogItemId, if necessary
        /// unlocks it using any appropriate key, and returns the contents of the opened container. If the container (and key when
        /// relevant) are consumable (RemainingUses > 0), their RemainingUses will be decremented, consistent with the operation of
        /// ConsumeItem.
        /// </summary>
        Task<PlayFabResult<UnlockContainerItemResult>> UnlockContainerItemAsync(
            UnlockContainerItemRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Update the avatar URL of the specified player
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> UpdateAvatarUrlAsync(
            UpdateAvatarUrlRequest request,
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
        /// Updates the title-specific custom data for the user's character which is readable and writable by the client
        /// </summary>
        Task<PlayFabResult<UpdateCharacterDataResult>> UpdateCharacterDataAsync(
            UpdateCharacterDataRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates the title-specific custom data for the user's character which cannot be accessed by the client
        /// </summary>
        Task<PlayFabResult<UpdateCharacterDataResult>> UpdateCharacterInternalDataAsync(
            UpdateCharacterDataRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates the title-specific custom data for the user's character which can only be read by the client
        /// </summary>
        Task<PlayFabResult<UpdateCharacterDataResult>> UpdateCharacterReadOnlyDataAsync(
            UpdateCharacterDataRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates the values of the specified title-specific statistics for the specific character
        /// </summary>
        Task<PlayFabResult<UpdateCharacterStatisticsResult>> UpdateCharacterStatisticsAsync(
            UpdateCharacterStatisticsRequest request,
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
        /// Updates the values of the specified title-specific statistics for the user
        /// </summary>
        Task<PlayFabResult<UpdatePlayerStatisticsResult>> UpdatePlayerStatisticsAsync(
            UpdatePlayerStatisticsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Adds, updates, and removes data keys for a shared group object. If the permission is set to Public, all fields updated
        /// or added in this call will be readable by users not in the group. By default, data permissions are set to Private.
        /// Regardless of the permission setting, only members of the group (and the server) can update the data. Shared Groups are
        /// designed for sharing data between a very small number of players, please see our guide:
        /// https://docs.microsoft.com/gaming/playfab/features/social/groups/using-shared-group-data
        /// </summary>
        Task<PlayFabResult<UpdateSharedGroupDataResult>> UpdateSharedGroupDataAsync(
            UpdateSharedGroupDataRequest request,
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
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Updates the key-value pair data tagged to the specified item, which is read-only from the client.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> UpdateUserInventoryItemCustomDataAsync(
            UpdateUserInventoryItemDataRequest request,
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
        /// Writes a character-based event into PlayStream.
        /// </summary>
        Task<PlayFabResult<WriteEventResponse>> WriteCharacterEventAsync(
            WriteServerCharacterEventRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Writes a player-based event into PlayStream.
        /// </summary>
        Task<PlayFabResult<WriteEventResponse>> WritePlayerEventAsync(
            WriteServerPlayerEventRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Writes a title-based event into PlayStream.
        /// </summary>
        Task<PlayFabResult<WriteEventResponse>> WriteTitleEventAsync(
            WriteTitleEventRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);
    }
}
#endif
