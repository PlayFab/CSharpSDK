#if !DISABLE_PLAYFABCLIENT_API

using PlayFab.ClientModels;
using PlayFab.Internal;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayFab
{
    /// <summary>
    /// APIs which provide the full range of PlayFab features available to the client - authentication, account and data
    /// management, inventory, friends, matchmaking, reporting, and platform-specific functionality
    /// </summary>
    public interface IPlayFabClientInstanceAPI
    {
        /// <summary>
        /// Accepts an open trade (one that has not yet been accepted or cancelled), if the locally signed-in player is in the
        /// allowed player list for the trade, or it is open to all players. If the call is successful, the offered and accepted
        /// items will be swapped between the two players' inventories.
        /// </summary>
        Task<PlayFabResult<AcceptTradeResponse>> AcceptTradeAsync(
            AcceptTradeRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Adds the PlayFab user, based upon a match against a supplied unique identifier, to the friend list of the local user. At
        /// least one of FriendPlayFabId,FriendUsername,FriendEmail, or FriendTitleDisplayName should be initialized.
        /// </summary>
        Task<PlayFabResult<AddFriendResult>> AddFriendAsync(
            AddFriendRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Adds the specified generic service identifier to the player's PlayFab account. This is designed to allow for a PlayFab
        /// ID lookup of any arbitrary service identifier a title wants to add. This identifier should never be used as
        /// authentication credentials, as the intent is that it is easily accessible by other players.
        /// </summary>
        Task<PlayFabResult<AddGenericIDResult>> AddGenericIDAsync(
            AddGenericIDRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Adds or updates a contact email to the player's profile.
        /// </summary>
        Task<PlayFabResult<AddOrUpdateContactEmailResult>> AddOrUpdateContactEmailAsync(
            AddOrUpdateContactEmailRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Adds users to the set of those able to update both the shared data, as well as the set of users in the group. Only users
        /// in the group can add new members. Shared Groups are designed for sharing data between a very small number of players,
        /// please see our guide: https://docs.microsoft.com/gaming/playfab/features/social/groups/using-shared-group-data
        /// </summary>
        Task<PlayFabResult<AddSharedGroupMembersResult>> AddSharedGroupMembersAsync(
            AddSharedGroupMembersRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Adds playfab username/password auth to an existing account created via an anonymous auth method, e.g. automatic device
        /// ID login.
        /// </summary>
        Task<PlayFabResult<AddUsernamePasswordResult>> AddUsernamePasswordAsync(
            AddUsernamePasswordRequest request,
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
        /// Registers the Android device to receive push notifications
        /// </summary>
        Task<PlayFabResult<AndroidDevicePushNotificationRegistrationResult>> AndroidDevicePushNotificationRegistrationAsync(
            AndroidDevicePushNotificationRegistrationRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Attributes an install for advertisment.
        /// </summary>
        Task<PlayFabResult<AttributeInstallResult>> AttributeInstallAsync(
            AttributeInstallRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Cancels an open trade (one that has not yet been accepted or cancelled). Note that only the player who created the trade
        /// can cancel it via this API call, to prevent griefing of the trade system (cancelling trades in order to prevent other
        /// players from accepting them, for trades that can be claimed by more than one player).
        /// </summary>
        Task<PlayFabResult<CancelTradeResponse>> CancelTradeAsync(
            CancelTradeRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Confirms with the payment provider that the purchase was approved (if applicable) and adjusts inventory and
        /// virtual currency balances as appropriate
        /// </summary>
        Task<PlayFabResult<ConfirmPurchaseResult>> ConfirmPurchaseAsync(
            ConfirmPurchaseRequest request,
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
        /// Grants the player's current entitlements from Microsoft Store's Collection API
        /// </summary>
        Task<PlayFabResult<ConsumeMicrosoftStoreEntitlementsResponse>> ConsumeMicrosoftStoreEntitlementsAsync(
            ConsumeMicrosoftStoreEntitlementsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Checks for any new consumable entitlements. If any are found, they are consumed (if they're consumables) and added as
        /// PlayFab items
        /// </summary>
        Task<PlayFabResult<ConsumePS5EntitlementsResult>> ConsumePS5EntitlementsAsync(
            ConsumePS5EntitlementsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Checks for any new consumable entitlements. If any are found, they are consumed and added as PlayFab items
        /// </summary>
        Task<PlayFabResult<ConsumePSNEntitlementsResult>> ConsumePSNEntitlementsAsync(
            ConsumePSNEntitlementsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Grants the player's current entitlements from Xbox Live, consuming all availble items in Xbox and granting them to the
        /// player's PlayFab inventory. This call is idempotent and will not grant previously granted items to the player.
        /// </summary>
        Task<PlayFabResult<ConsumeXboxEntitlementsResult>> ConsumeXboxEntitlementsAsync(
            ConsumeXboxEntitlementsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Requests the creation of a shared group object, containing key/value pairs which may be updated by all members of the
        /// group. Upon creation, the current user will be the only member of the group. Shared Groups are designed for sharing data
        /// between a very small number of players, please see our guide:
        /// https://docs.microsoft.com/gaming/playfab/features/social/groups/using-shared-group-data
        /// </summary>
        Task<PlayFabResult<CreateSharedGroupResult>> CreateSharedGroupAsync(
            CreateSharedGroupRequest request,
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
        /// Executes a CloudScript function, with the 'currentPlayerId' set to the PlayFab ID of the authenticated player. The
        /// PlayFab ID is the entity ID of the player's master_player_account entity.
        /// </summary>
        Task<PlayFabResult<ExecuteCloudScriptResult>> ExecuteCloudScriptAsync(
            ExecuteCloudScriptRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves the user's PlayFab account details
        /// </summary>
        Task<PlayFabResult<GetAccountInfoResult>> GetAccountInfoAsync(
            GetAccountInfoRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Returns a list of ad placements and a reward for each
        /// </summary>
        Task<PlayFabResult<GetAdPlacementsResult>> GetAdPlacementsAsync(
            GetAdPlacementsRequest request,
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
        /// Retrieves the title-specific custom data for the character which is readable and writable by the client
        /// </summary>
        Task<PlayFabResult<GetCharacterDataResult>> GetCharacterDataAsync(
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
        /// Retrieves the title-specific custom data for the character which can only be read by the client
        /// </summary>
        Task<PlayFabResult<GetCharacterDataResult>> GetCharacterReadOnlyDataAsync(
            GetCharacterDataRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves the details of all title-specific statistics for the user
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
        /// Retrieves a list of ranked friends of the current player for the given statistic, starting from the indicated point in
        /// the leaderboard
        /// </summary>
        Task<PlayFabResult<GetLeaderboardResult>> GetFriendLeaderboardAsync(
            GetFriendLeaderboardRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves a list of ranked friends of the current player for the given statistic, centered on the requested PlayFab
        /// user. If PlayFabId is empty or null will return currently logged in user.
        /// </summary>
        Task<PlayFabResult<GetFriendLeaderboardAroundPlayerResult>> GetFriendLeaderboardAroundPlayerAsync(
            GetFriendLeaderboardAroundPlayerRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves the current friend list for the local user, constrained to users who have PlayFab accounts. Friends from
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
        /// Retrieves a list of ranked characters for the given statistic, centered on the requested Character ID
        /// </summary>
        Task<PlayFabResult<GetLeaderboardAroundCharacterResult>> GetLeaderboardAroundCharacterAsync(
            GetLeaderboardAroundCharacterRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves a list of ranked users for the given statistic, centered on the requested player. If PlayFabId is empty or
        /// null will return currently logged in user.
        /// </summary>
        Task<PlayFabResult<GetLeaderboardAroundPlayerResult>> GetLeaderboardAroundPlayerAsync(
            GetLeaderboardAroundPlayerRequest request,
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
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ For payments flows where the provider requires playfab (the fulfiller) to initiate the transaction, but the
        /// client completes the rest of the flow. In the Xsolla case, the token returned here will be passed to Xsolla by the
        /// client to create a cart. Poll GetPurchase using the returned OrderId once you've completed the payment.
        /// </summary>
        Task<PlayFabResult<GetPaymentTokenResult>> GetPaymentTokenAsync(
            GetPaymentTokenRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets a Photon custom authentication token that can be used to securely join the player into a Photon room. See
        /// https://docs.microsoft.com/gaming/playfab/features/multiplayer/photon/quickstart for more details.
        /// </summary>
        Task<PlayFabResult<GetPhotonAuthenticationTokenResult>> GetPhotonAuthenticationTokenAsync(
            GetPhotonAuthenticationTokenRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves all of the user's different kinds of info.
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
            GetPlayerSegmentsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves the indicated statistics (current version and values for all statistics, if none are specified), for the local
        /// player.
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
        /// Gets all trades the player has either opened or accepted, optionally filtered by trade status.
        /// </summary>
        Task<PlayFabResult<GetPlayerTradesResponse>> GetPlayerTradesAsync(
            GetPlayerTradesRequest request,
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
        /// Retrieves the unique PlayFab identifiers for the given set of Facebook Instant Game identifiers.
        /// </summary>
        Task<PlayFabResult<GetPlayFabIDsFromFacebookInstantGamesIdsResult>> GetPlayFabIDsFromFacebookInstantGamesIdsAsync(
            GetPlayFabIDsFromFacebookInstantGamesIdsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Game Center identifiers (referenced in the Game Center
        /// Programming Guide as the Player Identifier).
        /// </summary>
        Task<PlayFabResult<GetPlayFabIDsFromGameCenterIDsResult>> GetPlayFabIDsFromGameCenterIDsAsync(
            GetPlayFabIDsFromGameCenterIDsRequest request,
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
        /// Retrieves the unique PlayFab identifiers for the given set of Google identifiers. The Google identifiers are the IDs for
        /// the user accounts, available as "id" in the Google+ People API calls.
        /// </summary>
        Task<PlayFabResult<GetPlayFabIDsFromGoogleIDsResult>> GetPlayFabIDsFromGoogleIDsAsync(
            GetPlayFabIDsFromGoogleIDsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Google Play Games identifiers. The Google Play Games
        /// identifiers are the IDs for the user accounts, available as "playerId" in the Google Play Games Services - Players API
        /// calls.
        /// </summary>
        Task<PlayFabResult<GetPlayFabIDsFromGooglePlayGamesPlayerIDsResult>> GetPlayFabIDsFromGooglePlayGamesPlayerIDsAsync(
            GetPlayFabIDsFromGooglePlayGamesPlayerIDsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Kongregate identifiers. The Kongregate identifiers are the
        /// IDs for the user accounts, available as "user_id" from the Kongregate API methods(ex:
        /// http://developers.kongregate.com/docs/client/getUserId).
        /// </summary>
        Task<PlayFabResult<GetPlayFabIDsFromKongregateIDsResult>> GetPlayFabIDsFromKongregateIDsAsync(
            GetPlayFabIDsFromKongregateIDsRequest request,
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
        /// version 2._ Retrieves a purchase along with its current PlayFab status. Returns inventory items from the purchase that
        /// are still active.
        /// </summary>
        Task<PlayFabResult<GetPurchaseResult>> GetPurchaseAsync(
            GetPurchaseRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves data stored in a shared group object, as well as the list of members in the group. Non-members of the group
        /// may use this to retrieve group data, including membership, but they will not receive data for keys marked as private.
        /// Shared Groups are designed for sharing data between a very small number of players, please see our guide:
        /// https://docs.microsoft.com/gaming/playfab/features/social/groups/using-shared-group-data
        /// </summary>
        Task<PlayFabResult<GetSharedGroupDataResult>> GetSharedGroupDataAsync(
            GetSharedGroupDataRequest request,
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
        /// Retrieves the title news feed, as configured in the developer portal
        /// </summary>
        Task<PlayFabResult<GetTitleNewsResult>> GetTitleNewsAsync(
            GetTitleNewsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Returns the title's base 64 encoded RSA CSP blob.
        /// </summary>
        Task<PlayFabResult<GetTitlePublicKeyResult>> GetTitlePublicKeyAsync(
            GetTitlePublicKeyRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the current status of an existing trade.
        /// </summary>
        Task<PlayFabResult<GetTradeStatusResponse>> GetTradeStatusAsync(
            GetTradeStatusRequest request,
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
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Retrieves the user's current inventory of virtual goods
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
        /// Links the Android device identifier to the user's PlayFab account
        /// </summary>
        Task<PlayFabResult<LinkAndroidDeviceIDResult>> LinkAndroidDeviceIDAsync(
            LinkAndroidDeviceIDRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Links the Apple account associated with the token to the user's PlayFab account.
        /// </summary>
        Task<PlayFabResult<EmptyResult>> LinkAppleAsync(
            LinkAppleRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Links the Battle.net account associated with the token to the user's PlayFab account.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> LinkBattleNetAccountAsync(
            LinkBattleNetAccountRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Links the custom identifier, generated by the title, to the user's PlayFab account
        /// </summary>
        Task<PlayFabResult<LinkCustomIDResult>> LinkCustomIDAsync(
            LinkCustomIDRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Links the Facebook account associated with the provided Facebook access token to the user's PlayFab account
        /// </summary>
        Task<PlayFabResult<LinkFacebookAccountResult>> LinkFacebookAccountAsync(
            LinkFacebookAccountRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Links the Facebook Instant Games Id to the user's PlayFab account
        /// </summary>
        Task<PlayFabResult<LinkFacebookInstantGamesIdResult>> LinkFacebookInstantGamesIdAsync(
            LinkFacebookInstantGamesIdRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Links the Game Center account associated with the provided Game Center ID to the user's PlayFab account. Logging in with
        /// a Game Center ID is insecure if you do not include the optional PublicKeyUrl, Salt, Signature, and Timestamp parameters
        /// in this request. It is recommended you require these parameters on all Game Center calls by going to the Apple Add-ons
        /// page in the PlayFab Game Manager and enabling the 'Require secure authentication only for this app' option.
        /// </summary>
        Task<PlayFabResult<LinkGameCenterAccountResult>> LinkGameCenterAccountAsync(
            LinkGameCenterAccountRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Links the currently signed-in user account to their Google account, using their Google account credentials
        /// </summary>
        Task<PlayFabResult<LinkGoogleAccountResult>> LinkGoogleAccountAsync(
            LinkGoogleAccountRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Links the currently signed-in user account to their Google Play Games account, using their Google Play Games account
        /// credentials
        /// </summary>
        Task<PlayFabResult<LinkGooglePlayGamesServicesAccountResult>> LinkGooglePlayGamesServicesAccountAsync(
            LinkGooglePlayGamesServicesAccountRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Links the vendor-specific iOS device identifier to the user's PlayFab account
        /// </summary>
        Task<PlayFabResult<LinkIOSDeviceIDResult>> LinkIOSDeviceIDAsync(
            LinkIOSDeviceIDRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Links the Kongregate identifier to the user's PlayFab account
        /// </summary>
        Task<PlayFabResult<LinkKongregateAccountResult>> LinkKongregateAsync(
            LinkKongregateAccountRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Links the Nintendo account associated with the token to the user's PlayFab account.
        /// </summary>
        Task<PlayFabResult<EmptyResult>> LinkNintendoServiceAccountAsync(
            LinkNintendoServiceAccountRequest request,
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
        /// Links an OpenID Connect account to a user's PlayFab account, based on an existing relationship between a title and an
        /// Open ID Connect provider and the OpenId Connect JWT from that provider.
        /// </summary>
        Task<PlayFabResult<EmptyResult>> LinkOpenIdConnectAsync(
            LinkOpenIdConnectRequest request,
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
        /// Links the Steam account associated with the provided Steam authentication ticket to the user's PlayFab account
        /// </summary>
        Task<PlayFabResult<LinkSteamAccountResult>> LinkSteamAccountAsync(
            LinkSteamAccountRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Links the Twitch account associated with the token to the user's PlayFab account.
        /// </summary>
        Task<PlayFabResult<LinkTwitchAccountResult>> LinkTwitchAsync(
            LinkTwitchAccountRequest request,
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
        Task<PlayFabResult<LoginResult>> LoginWithAndroidDeviceIDAsync(
            LoginWithAndroidDeviceIDRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Signs in the user with a Sign in with Apple identity token.
        /// </summary>
        Task<PlayFabResult<LoginResult>> LoginWithAppleAsync(
            LoginWithAppleRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Sign in the user with a Battle.net identity token
        /// </summary>
        Task<PlayFabResult<LoginResult>> LoginWithBattleNetAsync(
            LoginWithBattleNetRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Signs the user in using a custom unique identifier generated by the title, returning a session identifier that can
        /// subsequently be used for API calls which require an authenticated user
        /// </summary>
        Task<PlayFabResult<LoginResult>> LoginWithCustomIDAsync(
            LoginWithCustomIDRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Signs the user into the PlayFab account, returning a session identifier that can subsequently be used for API calls
        /// which require an authenticated user. Unlike most other login API calls, LoginWithEmailAddress does not permit the
        /// creation of new accounts via the CreateAccountFlag. Email addresses may be used to create accounts via
        /// RegisterPlayFabUser.
        /// </summary>
        Task<PlayFabResult<LoginResult>> LoginWithEmailAddressAsync(
            LoginWithEmailAddressRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Signs the user in using a Facebook access token, returning a session identifier that can subsequently be used for API
        /// calls which require an authenticated user
        /// </summary>
        Task<PlayFabResult<LoginResult>> LoginWithFacebookAsync(
            LoginWithFacebookRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Signs the user in using a Facebook Instant Games ID, returning a session identifier that can subsequently be used for
        /// API calls which require an authenticated user. Requires Facebook Instant Games to be configured.
        /// </summary>
        Task<PlayFabResult<LoginResult>> LoginWithFacebookInstantGamesIdAsync(
            LoginWithFacebookInstantGamesIdRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Signs the user in using an iOS Game Center player identifier, returning a session identifier that can subsequently be
        /// used for API calls which require an authenticated user. Logging in with a Game Center ID is insecure if you do not
        /// include the optional PublicKeyUrl, Salt, Signature, and Timestamp parameters in this request. It is recommended you
        /// require these parameters on all Game Center calls by going to the Apple Add-ons page in the PlayFab Game Manager and
        /// enabling the 'Require secure authentication only for this app' option.
        /// </summary>
        Task<PlayFabResult<LoginResult>> LoginWithGameCenterAsync(
            LoginWithGameCenterRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Signs the user in using their Google account credentials
        /// </summary>
        Task<PlayFabResult<LoginResult>> LoginWithGoogleAccountAsync(
            LoginWithGoogleAccountRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Signs the user in using their Google Play Games account credentials
        /// </summary>
        Task<PlayFabResult<LoginResult>> LoginWithGooglePlayGamesServicesAsync(
            LoginWithGooglePlayGamesServicesRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Signs the user in using the vendor-specific iOS device identifier, returning a session identifier that can subsequently
        /// be used for API calls which require an authenticated user
        /// </summary>
        Task<PlayFabResult<LoginResult>> LoginWithIOSDeviceIDAsync(
            LoginWithIOSDeviceIDRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Signs the user in using a Kongregate player account.
        /// </summary>
        Task<PlayFabResult<LoginResult>> LoginWithKongregateAsync(
            LoginWithKongregateRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Signs in the user with a Nintendo service account token.
        /// </summary>
        Task<PlayFabResult<LoginResult>> LoginWithNintendoServiceAccountAsync(
            LoginWithNintendoServiceAccountRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Signs the user in using a Nintendo Switch Device ID, returning a session identifier that can subsequently be used for
        /// API calls which require an authenticated user
        /// </summary>
        Task<PlayFabResult<LoginResult>> LoginWithNintendoSwitchDeviceIdAsync(
            LoginWithNintendoSwitchDeviceIdRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Logs in a user with an Open ID Connect JWT created by an existing relationship between a title and an Open ID Connect
        /// provider.
        /// </summary>
        Task<PlayFabResult<LoginResult>> LoginWithOpenIdConnectAsync(
            LoginWithOpenIdConnectRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Signs the user into the PlayFab account, returning a session identifier that can subsequently be used for API calls
        /// which require an authenticated user. Unlike most other login API calls, LoginWithPlayFab does not permit the creation of
        /// new accounts via the CreateAccountFlag. Username/Password credentials may be used to create accounts via
        /// RegisterPlayFabUser, or added to existing accounts using AddUsernamePassword.
        /// </summary>
        Task<PlayFabResult<LoginResult>> LoginWithPlayFabAsync(
            LoginWithPlayFabRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Signs the user in using a PlayStation :tm: Network authentication code, returning a session identifier that can
        /// subsequently be used for API calls which require an authenticated user
        /// </summary>
        Task<PlayFabResult<LoginResult>> LoginWithPSNAsync(
            LoginWithPSNRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Signs the user in using a Steam authentication ticket, returning a session identifier that can subsequently be used for
        /// API calls which require an authenticated user
        /// </summary>
        Task<PlayFabResult<LoginResult>> LoginWithSteamAsync(
            LoginWithSteamRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Signs the user in using a Twitch access token.
        /// </summary>
        Task<PlayFabResult<LoginResult>> LoginWithTwitchAsync(
            LoginWithTwitchRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Signs the user in using a Xbox Live Token, returning a session identifier that can subsequently be used for API calls
        /// which require an authenticated user
        /// </summary>
        Task<PlayFabResult<LoginResult>> LoginWithXboxAsync(
            LoginWithXboxRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Opens a new outstanding trade. Note that a given item instance may only be in one open trade at a time.
        /// </summary>
        Task<PlayFabResult<OpenTradeResponse>> OpenTradeAsync(
            OpenTradeRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Selects a payment option for purchase order created via StartPurchase
        /// </summary>
        Task<PlayFabResult<PayForPurchaseResult>> PayForPurchaseAsync(
            PayForPurchaseRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Buys a single item with virtual currency. You must specify both the virtual currency to use to purchase, as
        /// well as what the client believes the price to be. This lets the server fail the purchase if the price has changed.
        /// </summary>
        Task<PlayFabResult<PurchaseItemResult>> PurchaseItemAsync(
            PurchaseItemRequest request,
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
        /// Uses the supplied OAuth code to refresh the internally cached player PlayStation :tm: Network auth token
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> RefreshPSNAuthTokenAsync(
            RefreshPSNAuthTokenRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Registers the iOS device to receive push notifications
        /// </summary>
        Task<PlayFabResult<RegisterForIOSPushNotificationResult>> RegisterForIOSPushNotificationAsync(
            RegisterForIOSPushNotificationRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Registers a new Playfab user account, returning a session identifier that can subsequently be used for API calls which
        /// require an authenticated user. You must supply a username and an email address.
        /// </summary>
        Task<PlayFabResult<RegisterPlayFabUserResult>> RegisterPlayFabUserAsync(
            RegisterPlayFabUserRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Removes a contact email from the player's profile.
        /// </summary>
        Task<PlayFabResult<RemoveContactEmailResult>> RemoveContactEmailAsync(
            RemoveContactEmailRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Removes a specified user from the friend list of the local user
        /// </summary>
        Task<PlayFabResult<RemoveFriendResult>> RemoveFriendAsync(
            RemoveFriendRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Removes the specified generic service identifier from the player's PlayFab account.
        /// </summary>
        Task<PlayFabResult<RemoveGenericIDResult>> RemoveGenericIDAsync(
            RemoveGenericIDRequest request,
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
        /// Report player's ad activity
        /// </summary>
        Task<PlayFabResult<ReportAdActivityResult>> ReportAdActivityAsync(
            ReportAdActivityRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Write a PlayStream event to describe the provided player device information. This API method is not designed to be
        /// called directly by developers. Each PlayFab client SDK will eventually report this information automatically.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> ReportDeviceInfoAsync(
            DeviceInfoRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Submit a report for another player (due to bad bahavior, etc.), so that customer service representatives for the title
        /// can take action concerning potentially toxic players.
        /// </summary>
        Task<PlayFabResult<ReportPlayerClientResult>> ReportPlayerAsync(
            ReportPlayerClientRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Restores all in-app purchases based on the given restore receipt
        /// </summary>
        Task<PlayFabResult<RestoreIOSPurchasesResult>> RestoreIOSPurchasesAsync(
            RestoreIOSPurchasesRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Reward player's ad activity
        /// </summary>
        Task<PlayFabResult<RewardAdActivityResult>> RewardAdActivityAsync(
            RewardAdActivityRequest request,
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
        /// Updates the tag list for a specified user in the friend list of the local user
        /// </summary>
        Task<PlayFabResult<SetFriendTagsResult>> SetFriendTagsAsync(
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
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Creates an order for a list of items from the title catalog
        /// </summary>
        Task<PlayFabResult<StartPurchaseResult>> StartPurchaseAsync(
            StartPurchaseRequest request,
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
        /// Unlinks the related Android device identifier from the user's PlayFab account
        /// </summary>
        Task<PlayFabResult<UnlinkAndroidDeviceIDResult>> UnlinkAndroidDeviceIDAsync(
            UnlinkAndroidDeviceIDRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unlinks the related Apple account from the user's PlayFab account.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> UnlinkAppleAsync(
            UnlinkAppleRequest request,
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
        /// Unlinks the related custom identifier from the user's PlayFab account
        /// </summary>
        Task<PlayFabResult<UnlinkCustomIDResult>> UnlinkCustomIDAsync(
            UnlinkCustomIDRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unlinks the related Facebook account from the user's PlayFab account
        /// </summary>
        Task<PlayFabResult<UnlinkFacebookAccountResult>> UnlinkFacebookAccountAsync(
            UnlinkFacebookAccountRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unlinks the related Facebook Instant Game Ids from the user's PlayFab account
        /// </summary>
        Task<PlayFabResult<UnlinkFacebookInstantGamesIdResult>> UnlinkFacebookInstantGamesIdAsync(
            UnlinkFacebookInstantGamesIdRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unlinks the related Game Center account from the user's PlayFab account
        /// </summary>
        Task<PlayFabResult<UnlinkGameCenterAccountResult>> UnlinkGameCenterAccountAsync(
            UnlinkGameCenterAccountRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unlinks the related Google account from the user's PlayFab account
        /// (https://developers.google.com/android/reference/com/google/android/gms/auth/GoogleAuthUtil#public-methods).
        /// </summary>
        Task<PlayFabResult<UnlinkGoogleAccountResult>> UnlinkGoogleAccountAsync(
            UnlinkGoogleAccountRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unlinks the related Google Play Games account from the user's PlayFab account.
        /// </summary>
        Task<PlayFabResult<UnlinkGooglePlayGamesServicesAccountResult>> UnlinkGooglePlayGamesServicesAccountAsync(
            UnlinkGooglePlayGamesServicesAccountRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unlinks the related iOS device identifier from the user's PlayFab account
        /// </summary>
        Task<PlayFabResult<UnlinkIOSDeviceIDResult>> UnlinkIOSDeviceIDAsync(
            UnlinkIOSDeviceIDRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unlinks the related Kongregate identifier from the user's PlayFab account
        /// </summary>
        Task<PlayFabResult<UnlinkKongregateAccountResult>> UnlinkKongregateAsync(
            UnlinkKongregateAccountRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unlinks the related Nintendo account from the user's PlayFab account.
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
        /// Unlinks an OpenID Connect account from a user's PlayFab account, based on the connection ID of an existing relationship
        /// between a title and an Open ID Connect provider.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> UnlinkOpenIdConnectAsync(
            UnlinkOpenIdConnectRequest request,
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
        /// Unlinks the related Steam account from the user's PlayFab account
        /// </summary>
        Task<PlayFabResult<UnlinkSteamAccountResult>> UnlinkSteamAccountAsync(
            UnlinkSteamAccountRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unlinks the related Twitch account from the user's PlayFab account.
        /// </summary>
        Task<PlayFabResult<UnlinkTwitchAccountResult>> UnlinkTwitchAsync(
            UnlinkTwitchAccountRequest request,
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
        /// version 2._ Opens the specified container, with the specified key (when required), and returns the contents of the
        /// opened container. If the container (and key when relevant) are consumable (RemainingUses > 0), their RemainingUses will
        /// be decremented, consistent with the operation of ConsumeItem.
        /// </summary>
        Task<PlayFabResult<UnlockContainerItemResult>> UnlockContainerInstanceAsync(
            UnlockContainerInstanceRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Searches target inventory for an ItemInstance matching the given CatalogItemId, if necessary unlocks it
        /// using an appropriate key, and returns the contents of the opened container. If the container (and key when relevant) are
        /// consumable (RemainingUses > 0), their RemainingUses will be decremented, consistent with the operation of ConsumeItem.
        /// </summary>
        Task<PlayFabResult<UnlockContainerItemResult>> UnlockContainerItemAsync(
            UnlockContainerItemRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Update the avatar URL of the player
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> UpdateAvatarUrlAsync(
            UpdateAvatarUrlRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Creates and updates the title-specific custom data for the user's character which is readable and writable by the client
        /// </summary>
        Task<PlayFabResult<UpdateCharacterDataResult>> UpdateCharacterDataAsync(
            UpdateCharacterDataRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates the values of the specified title-specific statistics for the specific character. By default, clients are not
        /// permitted to update statistics. Developers may override this setting in the Game Manager > Settings > API Features.
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
        /// Updates the values of the specified title-specific statistics for the user. By default, clients are not permitted to
        /// update statistics. Developers may override this setting in the Game Manager > Settings > API Features.
        /// </summary>
        Task<PlayFabResult<UpdatePlayerStatisticsResult>> UpdatePlayerStatisticsAsync(
            UpdatePlayerStatisticsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Adds, updates, and removes data keys for a shared group object. If the permission is set to Public, all fields updated
        /// or added in this call will be readable by users not in the group. By default, data permissions are set to Private.
        /// Regardless of the permission setting, only members of the group can update the data. Shared Groups are designed for
        /// sharing data between a very small number of players, please see our guide:
        /// https://docs.microsoft.com/gaming/playfab/features/social/groups/using-shared-group-data
        /// </summary>
        Task<PlayFabResult<UpdateSharedGroupDataResult>> UpdateSharedGroupDataAsync(
            UpdateSharedGroupDataRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Creates and updates the title-specific custom data for the user which is readable and writable by the client
        /// </summary>
        Task<PlayFabResult<UpdateUserDataResult>> UpdateUserDataAsync(
            UpdateUserDataRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Creates and updates the publisher-specific custom data for the user which is readable and writable by the client
        /// </summary>
        Task<PlayFabResult<UpdateUserDataResult>> UpdateUserPublisherDataAsync(
            UpdateUserDataRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates the title specific display name for the user
        /// </summary>
        Task<PlayFabResult<UpdateUserTitleDisplayNameResult>> UpdateUserTitleDisplayNameAsync(
            UpdateUserTitleDisplayNameRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Validates with Amazon that the receipt for an Amazon App Store in-app purchase is valid and that it matches
        /// the purchased catalog item
        /// </summary>
        Task<PlayFabResult<ValidateAmazonReceiptResult>> ValidateAmazonIAPReceiptAsync(
            ValidateAmazonReceiptRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Validates a Google Play purchase and gives the corresponding item to the player.
        /// </summary>
        Task<PlayFabResult<ValidateGooglePlayPurchaseResult>> ValidateGooglePlayPurchaseAsync(
            ValidateGooglePlayPurchaseRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Validates with the Apple store that the receipt for an iOS in-app purchase is valid and that it matches the
        /// purchased catalog item
        /// </summary>
        Task<PlayFabResult<ValidateIOSReceiptResult>> ValidateIOSReceiptAsync(
            ValidateIOSReceiptRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Validates with Windows that the receipt for an Windows App Store in-app purchase is valid and that it
        /// matches the purchased catalog item
        /// </summary>
        Task<PlayFabResult<ValidateWindowsReceiptResult>> ValidateWindowsStoreReceiptAsync(
            ValidateWindowsReceiptRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Writes a character-based event into PlayStream.
        /// </summary>
        Task<PlayFabResult<WriteEventResponse>> WriteCharacterEventAsync(
            WriteClientCharacterEventRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Writes a player-based event into PlayStream.
        /// </summary>
        Task<PlayFabResult<WriteEventResponse>> WritePlayerEventAsync(
            WriteClientPlayerEventRequest request,
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
