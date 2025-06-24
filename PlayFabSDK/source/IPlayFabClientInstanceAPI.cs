
using PlayFab.ClientModels;
using PlayFab.Internal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayFab 
{
    public interface IPlayFabClientInstanceAPI
    {
        /// <summary>
        /// Returns true if the client is currently logged in.
        /// </summary>
        bool IsClientLoggedIn();

        /// <summary>
        /// Forgets all stored credentials for the client, logging out the current user.
        /// </summary>
        void ForgetAllCredentials();

        /// <summary>
        /// Accepts an open trade for the player.
        /// </summary>
        Task<PlayFabResult<AcceptTradeResponse>> AcceptTradeAsync(AcceptTradeRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Adds a new friend to the player's friend list.
        /// </summary>
        Task<PlayFabResult<AddFriendResult>> AddFriendAsync(AddFriendRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Adds a generic identifier to the player's account.
        /// </summary>
        Task<PlayFabResult<AddGenericIDResult>> AddGenericIDAsync(AddGenericIDRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Adds or updates the contact email for the player.
        /// </summary>
        Task<PlayFabResult<AddOrUpdateContactEmailResult>> AddOrUpdateContactEmailAsync(AddOrUpdateContactEmailRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Adds members to a shared group.
        /// </summary>
        Task<PlayFabResult<AddSharedGroupMembersResult>> AddSharedGroupMembersAsync(AddSharedGroupMembersRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Adds a username and password to the player's account.
        /// </summary>
        Task<PlayFabResult<AddUsernamePasswordResult>> AddUsernamePasswordAsync(AddUsernamePasswordRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Adds virtual currency to the user's account.
        /// </summary>
        Task<PlayFabResult<ModifyUserVirtualCurrencyResult>> AddUserVirtualCurrencyAsync(AddUserVirtualCurrencyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Registers the Android device for push notifications.
        /// </summary>
        Task<PlayFabResult<AndroidDevicePushNotificationRegistrationResult>> AndroidDevicePushNotificationRegistrationAsync(AndroidDevicePushNotificationRegistrationRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Attributes an install for the device.
        /// </summary>
        Task<PlayFabResult<AttributeInstallResult>> AttributeInstallAsync(AttributeInstallRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Cancels an open trade.
        /// </summary>
        Task<PlayFabResult<CancelTradeResponse>> CancelTradeAsync(CancelTradeRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Confirms a purchase for the player.
        /// </summary>
        Task<PlayFabResult<ConfirmPurchaseResult>> ConfirmPurchaseAsync(ConfirmPurchaseRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Consumes an item from the player's inventory.
        /// </summary>
        Task<PlayFabResult<ConsumeItemResult>> ConsumeItemAsync(ConsumeItemRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Consumes Microsoft Store entitlements for the player.
        /// </summary>
        Task<PlayFabResult<ConsumeMicrosoftStoreEntitlementsResponse>> ConsumeMicrosoftStoreEntitlementsAsync(ConsumeMicrosoftStoreEntitlementsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Consumes PlayStation 5 entitlements for the player.
        /// </summary>
        Task<PlayFabResult<ConsumePS5EntitlementsResult>> ConsumePS5EntitlementsAsync(ConsumePS5EntitlementsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Consumes PlayStation Network entitlements for the player.
        /// </summary>
        Task<PlayFabResult<ConsumePSNEntitlementsResult>> ConsumePSNEntitlementsAsync(ConsumePSNEntitlementsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Consumes Xbox entitlements for the player.
        /// </summary>
        Task<PlayFabResult<ConsumeXboxEntitlementsResult>> ConsumeXboxEntitlementsAsync(ConsumeXboxEntitlementsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Creates a new shared group.
        /// </summary>
        Task<PlayFabResult<CreateSharedGroupResult>> CreateSharedGroupAsync(CreateSharedGroupRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes custom properties for the specified player.
        /// </summary>
        Task<PlayFabResult<DeletePlayerCustomPropertiesResult>> DeletePlayerCustomPropertiesAsync(DeletePlayerCustomPropertiesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Executes a Cloud Script function.
        /// </summary>
        Task<PlayFabResult<ExecuteCloudScriptResult>> ExecuteCloudScriptAsync(ExecuteCloudScriptRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets account information for the player.
        /// </summary>
        Task<PlayFabResult<GetAccountInfoResult>> GetAccountInfoAsync(GetAccountInfoRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets ad placements for the player.
        /// </summary>
        Task<PlayFabResult<GetAdPlacementsResult>> GetAdPlacementsAsync(GetAdPlacementsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets all characters for the user.
        /// </summary>
        Task<PlayFabResult<ListUsersCharactersResult>> GetAllUsersCharactersAsync(ListUsersCharactersRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets catalog items for the title.
        /// </summary>
        Task<PlayFabResult<GetCatalogItemsResult>> GetCatalogItemsAsync(GetCatalogItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets character data for the specified character.
        /// </summary>
        Task<PlayFabResult<GetCharacterDataResult>> GetCharacterDataAsync(GetCharacterDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the inventory for a character.
        /// </summary>
        Task<PlayFabResult<GetCharacterInventoryResult>> GetCharacterInventoryAsync(GetCharacterInventoryRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the leaderboard for a character.
        /// </summary>
        Task<PlayFabResult<GetCharacterLeaderboardResult>> GetCharacterLeaderboardAsync(GetCharacterLeaderboardRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets read-only character data for the specified character.
        /// </summary>
        Task<PlayFabResult<GetCharacterDataResult>> GetCharacterReadOnlyDataAsync(GetCharacterDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets character statistics for the specified character.
        /// </summary>
        Task<PlayFabResult<GetCharacterStatisticsResult>> GetCharacterStatisticsAsync(GetCharacterStatisticsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets a download URL for content.
        /// </summary>
        Task<PlayFabResult<GetContentDownloadUrlResult>> GetContentDownloadUrlAsync(GetContentDownloadUrlRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the friend leaderboard for the player.
        /// </summary>
        Task<PlayFabResult<GetLeaderboardResult>> GetFriendLeaderboardAsync(GetFriendLeaderboardRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the friend leaderboard around the player.
        /// </summary>
        Task<PlayFabResult<GetFriendLeaderboardAroundPlayerResult>> GetFriendLeaderboardAroundPlayerAsync(GetFriendLeaderboardAroundPlayerRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the player's friends list.
        /// </summary>
        Task<PlayFabResult<GetFriendsListResult>> GetFriendsListAsync(GetFriendsListRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the leaderboard for the title.
        /// </summary>
        Task<PlayFabResult<GetLeaderboardResult>> GetLeaderboardAsync(GetLeaderboardRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the leaderboard around a character.
        /// </summary>
        Task<PlayFabResult<GetLeaderboardAroundCharacterResult>> GetLeaderboardAroundCharacterAsync(GetLeaderboardAroundCharacterRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the leaderboard around the player.
        /// </summary>
        Task<PlayFabResult<GetLeaderboardAroundPlayerResult>> GetLeaderboardAroundPlayerAsync(GetLeaderboardAroundPlayerRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the leaderboard for the user's characters.
        /// </summary>
        Task<PlayFabResult<GetLeaderboardForUsersCharactersResult>> GetLeaderboardForUserCharactersAsync(GetLeaderboardForUsersCharactersRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets a payment token for the player.
        /// </summary>
        Task<PlayFabResult<GetPaymentTokenResult>> GetPaymentTokenAsync(GetPaymentTokenRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets a Photon authentication token for the player.
        /// </summary>
        Task<PlayFabResult<GetPhotonAuthenticationTokenResult>> GetPhotonAuthenticationTokenAsync(GetPhotonAuthenticationTokenRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets combined info for the player.
        /// </summary>
        Task<PlayFabResult<GetPlayerCombinedInfoResult>> GetPlayerCombinedInfoAsync(GetPlayerCombinedInfoRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets custom properties for the player.
        /// </summary>
        Task<PlayFabResult<GetPlayerCustomPropertyResult>> GetPlayerCustomPropertyAsync(GetPlayerCustomPropertyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the player profile.
        /// </summary>
        Task<PlayFabResult<GetPlayerProfileResult>> GetPlayerProfileAsync(GetPlayerProfileRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the player segments.
        /// </summary>
        Task<PlayFabResult<GetPlayerSegmentsResult>> GetPlayerSegmentsAsync(GetPlayerSegmentsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the player statistics.
        /// </summary>
        Task<PlayFabResult<GetPlayerStatisticsResult>> GetPlayerStatisticsAsync(GetPlayerStatisticsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the player statistic versions.
        /// </summary>
        Task<PlayFabResult<GetPlayerStatisticVersionsResult>> GetPlayerStatisticVersionsAsync(GetPlayerStatisticVersionsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the player tags.
        /// </summary>
        Task<PlayFabResult<GetPlayerTagsResult>> GetPlayerTagsAsync(GetPlayerTagsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the player trades.
        /// </summary>
        Task<PlayFabResult<GetPlayerTradesResponse>> GetPlayerTradesAsync(GetPlayerTradesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets PlayFab IDs from BattleNet account IDs.
        /// </summary>
        Task<PlayFabResult<GetPlayFabIDsFromBattleNetAccountIdsResult>> GetPlayFabIDsFromBattleNetAccountIdsAsync(GetPlayFabIDsFromBattleNetAccountIdsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets PlayFab IDs from Facebook IDs.
        /// </summary>
        Task<PlayFabResult<GetPlayFabIDsFromFacebookIDsResult>> GetPlayFabIDsFromFacebookIDsAsync(GetPlayFabIDsFromFacebookIDsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets PlayFab IDs from Facebook Instant Games IDs.
        /// </summary>
        Task<PlayFabResult<GetPlayFabIDsFromFacebookInstantGamesIdsResult>> GetPlayFabIDsFromFacebookInstantGamesIdsAsync(GetPlayFabIDsFromFacebookInstantGamesIdsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets PlayFab IDs from Game Center IDs.
        /// </summary>
        Task<PlayFabResult<GetPlayFabIDsFromGameCenterIDsResult>> GetPlayFabIDsFromGameCenterIDsAsync(GetPlayFabIDsFromGameCenterIDsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets PlayFab IDs from generic IDs.
        /// </summary>
        Task<PlayFabResult<GetPlayFabIDsFromGenericIDsResult>> GetPlayFabIDsFromGenericIDsAsync(GetPlayFabIDsFromGenericIDsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets PlayFab IDs from Google IDs.
        /// </summary>
        Task<PlayFabResult<GetPlayFabIDsFromGoogleIDsResult>> GetPlayFabIDsFromGoogleIDsAsync(GetPlayFabIDsFromGoogleIDsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets PlayFab IDs from Google Play Games player IDs.
        /// </summary>
        Task<PlayFabResult<GetPlayFabIDsFromGooglePlayGamesPlayerIDsResult>> GetPlayFabIDsFromGooglePlayGamesPlayerIDsAsync(GetPlayFabIDsFromGooglePlayGamesPlayerIDsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets PlayFab IDs from Kongregate IDs.
        /// </summary>
        Task<PlayFabResult<GetPlayFabIDsFromKongregateIDsResult>> GetPlayFabIDsFromKongregateIDsAsync(GetPlayFabIDsFromKongregateIDsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets PlayFab IDs from Nintendo Service Account IDs.
        /// </summary>
        Task<PlayFabResult<GetPlayFabIDsFromNintendoServiceAccountIdsResult>> GetPlayFabIDsFromNintendoServiceAccountIdsAsync(GetPlayFabIDsFromNintendoServiceAccountIdsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets PlayFab IDs from Nintendo Switch device IDs.
        /// </summary>
        Task<PlayFabResult<GetPlayFabIDsFromNintendoSwitchDeviceIdsResult>> GetPlayFabIDsFromNintendoSwitchDeviceIdsAsync(GetPlayFabIDsFromNintendoSwitchDeviceIdsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets PlayFab IDs from PlayStation Network account IDs.
        /// </summary>
        Task<PlayFabResult<GetPlayFabIDsFromPSNAccountIDsResult>> GetPlayFabIDsFromPSNAccountIDsAsync(GetPlayFabIDsFromPSNAccountIDsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets PlayFab IDs from PlayStation Network online IDs.
        /// </summary>
        Task<PlayFabResult<GetPlayFabIDsFromPSNOnlineIDsResult>> GetPlayFabIDsFromPSNOnlineIDsAsync(GetPlayFabIDsFromPSNOnlineIDsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets PlayFab IDs from Steam IDs.
        /// </summary>
        Task<PlayFabResult<GetPlayFabIDsFromSteamIDsResult>> GetPlayFabIDsFromSteamIDsAsync(GetPlayFabIDsFromSteamIDsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets PlayFab IDs from Steam names.
        /// </summary>
        Task<PlayFabResult<GetPlayFabIDsFromSteamNamesResult>> GetPlayFabIDsFromSteamNamesAsync(GetPlayFabIDsFromSteamNamesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets PlayFab IDs from Twitch IDs.
        /// </summary>
        Task<PlayFabResult<GetPlayFabIDsFromTwitchIDsResult>> GetPlayFabIDsFromTwitchIDsAsync(GetPlayFabIDsFromTwitchIDsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets PlayFab IDs from Xbox Live IDs.
        /// </summary>
        Task<PlayFabResult<GetPlayFabIDsFromXboxLiveIDsResult>> GetPlayFabIDsFromXboxLiveIDsAsync(GetPlayFabIDsFromXboxLiveIDsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets publisher data for the title.
        /// </summary>
        Task<PlayFabResult<GetPublisherDataResult>> GetPublisherDataAsync(GetPublisherDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets a purchase for the player.
        /// </summary>
        Task<PlayFabResult<GetPurchaseResult>> GetPurchaseAsync(GetPurchaseRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets shared group data.
        /// </summary>
        Task<PlayFabResult<GetSharedGroupDataResult>> GetSharedGroupDataAsync(GetSharedGroupDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets store items for the title.
        /// </summary>
        Task<PlayFabResult<GetStoreItemsResult>> GetStoreItemsAsync(GetStoreItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the current time from the server.
        /// </summary>
        Task<PlayFabResult<GetTimeResult>> GetTimeAsync(GetTimeRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets title data for the title.
        /// </summary>
        Task<PlayFabResult<GetTitleDataResult>> GetTitleDataAsync(GetTitleDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets title news for the title.
        /// </summary>
        Task<PlayFabResult<GetTitleNewsResult>> GetTitleNewsAsync(GetTitleNewsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the public key for the title.
        /// </summary>
        Task<PlayFabResult<GetTitlePublicKeyResult>> GetTitlePublicKeyAsync(GetTitlePublicKeyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the status of a trade.
        /// </summary>
        Task<PlayFabResult<GetTradeStatusResponse>> GetTradeStatusAsync(GetTradeStatusRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets user data for the player.
        /// </summary>
        Task<PlayFabResult<GetUserDataResult>> GetUserDataAsync(GetUserDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the user's inventory.
        /// </summary>
        Task<PlayFabResult<GetUserInventoryResult>> GetUserInventoryAsync(GetUserInventoryRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets publisher data for the user.
        /// </summary>
        Task<PlayFabResult<GetUserDataResult>> GetUserPublisherDataAsync(GetUserDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets publisher read-only data for the user.
        /// </summary>
        Task<PlayFabResult<GetUserDataResult>> GetUserPublisherReadOnlyDataAsync(GetUserDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets read-only data for the user.
        /// </summary>
        Task<PlayFabResult<GetUserDataResult>> GetUserReadOnlyDataAsync(GetUserDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Grants a character to the user.
        /// </summary>
        Task<PlayFabResult<GrantCharacterToUserResult>> GrantCharacterToUserAsync(GrantCharacterToUserRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Links an Android device ID to the player's account.
        /// </summary>
        Task<PlayFabResult<LinkAndroidDeviceIDResult>> LinkAndroidDeviceIDAsync(LinkAndroidDeviceIDRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Links an Apple account to the player's account.
        /// </summary>
        Task<PlayFabResult<EmptyResult>> LinkAppleAsync(LinkAppleRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Links a Battle.net account to the player's account.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> LinkBattleNetAsync(LinkBattleNetRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Links a custom ID to the player's account.
        /// </summary>
        Task<PlayFabResult<LinkCustomIDResult>> LinkCustomIDAsync(LinkCustomIDRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Links a Facebook account to the player's account.
        /// </summary>
        Task<PlayFabResult<LinkFacebookAccountResult>> LinkFacebookAccountAsync(LinkFacebookAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Links a Facebook Instant Games ID to the player's account.
        /// </summary>
        Task<PlayFabResult<LinkFacebookInstantGamesIdResult>> LinkFacebookInstantGamesIdAsync(LinkFacebookInstantGamesIdRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Links a Game Center account to the player's account.
        /// </summary>
        Task<PlayFabResult<LinkGameCenterAccountResult>> LinkGameCenterAccountAsync(LinkGameCenterAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Links a Google account to the player's account.
        /// </summary>
        Task<PlayFabResult<LinkGoogleAccountResult>> LinkGoogleAccountAsync(LinkGoogleAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Links a Google Play Games Services account to the player's account.
        /// </summary>
        Task<PlayFabResult<LinkGooglePlayGamesServicesAccountResult>> LinkGooglePlayGamesServicesAccountAsync(LinkGooglePlayGamesServicesAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Links an iOS device ID to the player's account.
        /// </summary>
        Task<PlayFabResult<LinkIOSDeviceIDResult>> LinkIOSDeviceIDAsync(LinkIOSDeviceIDRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Links a Kongregate account to the player's account.
        /// </summary>
        Task<PlayFabResult<LinkKongregateAccountResult>> LinkKongregateAsync(LinkKongregateAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Links a Nintendo Service Account to the player's account.
        /// </summary>
        Task<PlayFabResult<EmptyResult>> LinkNintendoServiceAccountAsync(LinkNintendoServiceAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Links a Nintendo Switch device ID to the player's account.
        /// </summary>
        Task<PlayFabResult<LinkNintendoSwitchDeviceIdResult>> LinkNintendoSwitchDeviceIdAsync(LinkNintendoSwitchDeviceIdRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Links an OpenID Connect account to the player's account.
        /// </summary>
        Task<PlayFabResult<EmptyResult>> LinkOpenIdConnectAsync(LinkOpenIdConnectRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Links a PlayStation Network account to the player's account.
        /// </summary>
        Task<PlayFabResult<LinkPSNAccountResult>> LinkPSNAccountAsync(LinkPSNAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Links a Steam account to the player's account.
        /// </summary>
        Task<PlayFabResult<LinkSteamAccountResult>> LinkSteamAccountAsync(LinkSteamAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Links a Twitch account to the player's account.
        /// </summary>
        Task<PlayFabResult<LinkTwitchAccountResult>> LinkTwitchAsync(LinkTwitchAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Links an Xbox account to the player's account.
        /// </summary>
        Task<PlayFabResult<LinkXboxAccountResult>> LinkXboxAccountAsync(LinkXboxAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists custom properties for the player.
        /// </summary>
        Task<PlayFabResult<ListPlayerCustomPropertiesResult>> ListPlayerCustomPropertiesAsync(ListPlayerCustomPropertiesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Logs in a player with an Android device ID.
        /// </summary>
        Task<PlayFabResult<LoginResult>> LoginWithAndroidDeviceIDAsync(LoginWithAndroidDeviceIDRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Logs in a player with an Apple account.
        /// </summary>
        Task<PlayFabResult<LoginResult>> LoginWithAppleAsync(LoginWithAppleRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Logs in a player with a Battle.net account.
        /// </summary>
        Task<PlayFabResult<LoginResult>> LoginWithBattleNetAsync(LoginWithBattleNetRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Logs in a player with a custom ID.
        /// </summary>
        Task<PlayFabResult<LoginResult>> LoginWithCustomIDAsync(LoginWithCustomIDRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Logs in a player with an email address.
        /// </summary>
        Task<PlayFabResult<LoginResult>> LoginWithEmailAddressAsync(LoginWithEmailAddressRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Logs in a player with a Facebook account.
        /// </summary>
        Task<PlayFabResult<LoginResult>> LoginWithFacebookAsync(LoginWithFacebookRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Logs in a player with a Facebook Instant Games ID.
        /// </summary>
        Task<PlayFabResult<LoginResult>> LoginWithFacebookInstantGamesIdAsync(LoginWithFacebookInstantGamesIdRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Logs in a player with a Game Center account.
        /// </summary>
        Task<PlayFabResult<LoginResult>> LoginWithGameCenterAsync(LoginWithGameCenterRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Logs in a player with a Google account.
        /// </summary>
        Task<PlayFabResult<LoginResult>> LoginWithGoogleAccountAsync(LoginWithGoogleAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Logs in a player with a Google Play Games Services account.
        /// </summary>
        Task<PlayFabResult<LoginResult>> LoginWithGooglePlayGamesServicesAsync(LoginWithGooglePlayGamesServicesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Logs in a player with an iOS device ID.
        /// </summary>
        Task<PlayFabResult<LoginResult>> LoginWithIOSDeviceIDAsync(LoginWithIOSDeviceIDRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Logs in a player with a Kongregate account.
        /// </summary>
        Task<PlayFabResult<LoginResult>> LoginWithKongregateAsync(LoginWithKongregateRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Logs in a player with a Nintendo Service Account.
        /// </summary>
        Task<PlayFabResult<LoginResult>> LoginWithNintendoServiceAccountAsync(LoginWithNintendoServiceAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Logs in a player with a Nintendo Switch device ID.
        /// </summary>
        Task<PlayFabResult<LoginResult>> LoginWithNintendoSwitchDeviceIdAsync(LoginWithNintendoSwitchDeviceIdRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Logs in a player with an OpenID Connect account.
        /// </summary>
        Task<PlayFabResult<LoginResult>> LoginWithOpenIdConnectAsync(LoginWithOpenIdConnectRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Logs in a player with a PlayFab account.
        /// </summary>
        Task<PlayFabResult<LoginResult>> LoginWithPlayFabAsync(LoginWithPlayFabRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Logs in a player with a PlayStation Network account.
        /// </summary>
        Task<PlayFabResult<LoginResult>> LoginWithPSNAsync(LoginWithPSNRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Logs in a player with a Steam account.
        /// </summary>
        Task<PlayFabResult<LoginResult>> LoginWithSteamAsync(LoginWithSteamRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Logs in a player with a Twitch account.
        /// </summary>
        Task<PlayFabResult<LoginResult>> LoginWithTwitchAsync(LoginWithTwitchRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Logs in a player with an Xbox account.
        /// </summary>
        Task<PlayFabResult<LoginResult>> LoginWithXboxAsync(LoginWithXboxRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Opens a trade for the player.
        /// </summary>
        Task<PlayFabResult<OpenTradeResponse>> OpenTradeAsync(OpenTradeRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Pays for a purchase for the player.
        /// </summary>
        Task<PlayFabResult<PayForPurchaseResult>> PayForPurchaseAsync(PayForPurchaseRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Purchases an item for the player.
        /// </summary>
        Task<PlayFabResult<PurchaseItemResult>> PurchaseItemAsync(PurchaseItemRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Redeems a coupon for the player.
        /// </summary>
        Task<PlayFabResult<RedeemCouponResult>> RedeemCouponAsync(RedeemCouponRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Refreshes the PlayStation Network authentication token.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> RefreshPSNAuthTokenAsync(RefreshPSNAuthTokenRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Registers the player for iOS push notifications.
        /// </summary>
        Task<PlayFabResult<RegisterForIOSPushNotificationResult>> RegisterForIOSPushNotificationAsync(RegisterForIOSPushNotificationRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Registers a new PlayFab user.
        /// </summary>
        Task<PlayFabResult<RegisterPlayFabUserResult>> RegisterPlayFabUserAsync(RegisterPlayFabUserRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Removes the contact email from the player's account.
        /// </summary>
        Task<PlayFabResult<RemoveContactEmailResult>> RemoveContactEmailAsync(RemoveContactEmailRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Removes a friend from the player's friend list.
        /// </summary>
        Task<PlayFabResult<RemoveFriendResult>> RemoveFriendAsync(RemoveFriendRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Removes a generic identifier from the player's account.
        /// </summary>
        Task<PlayFabResult<RemoveGenericIDResult>> RemoveGenericIDAsync(RemoveGenericIDRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Removes members from a shared group.
        /// </summary>
        Task<PlayFabResult<RemoveSharedGroupMembersResult>> RemoveSharedGroupMembersAsync(RemoveSharedGroupMembersRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Reports ad activity for the player.
        /// </summary>
        Task<PlayFabResult<ReportAdActivityResult>> ReportAdActivityAsync(ReportAdActivityRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Reports device information for the player.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> ReportDeviceInfoAsync(DeviceInfoRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Reports another player for abusive behavior.
        /// </summary>
        Task<PlayFabResult<ReportPlayerClientResult>> ReportPlayerAsync(ReportPlayerClientRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Restores iOS purchases for the player.
        /// </summary>
        Task<PlayFabResult<RestoreIOSPurchasesResult>> RestoreIOSPurchasesAsync(RestoreIOSPurchasesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Rewards ad activity for the player.
        /// </summary>
        Task<PlayFabResult<RewardAdActivityResult>> RewardAdActivityAsync(RewardAdActivityRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Sends an account recovery email to the player.
        /// </summary>
        Task<PlayFabResult<SendAccountRecoveryEmailResult>> SendAccountRecoveryEmailAsync(SendAccountRecoveryEmailRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Sets friend tags for the player.
        /// </summary>
        Task<PlayFabResult<SetFriendTagsResult>> SetFriendTagsAsync(SetFriendTagsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Sets a player secret for the player.
        /// </summary>
        Task<PlayFabResult<SetPlayerSecretResult>> SetPlayerSecretAsync(SetPlayerSecretRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Starts a purchase for the player.
        /// </summary>
        Task<PlayFabResult<StartPurchaseResult>> StartPurchaseAsync(StartPurchaseRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Subtracts virtual currency from the user's account.
        /// </summary>
        Task<PlayFabResult<ModifyUserVirtualCurrencyResult>> SubtractUserVirtualCurrencyAsync(SubtractUserVirtualCurrencyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unlinks an Android device ID from the player's account.
        /// </summary>
        Task<PlayFabResult<UnlinkAndroidDeviceIDResult>> UnlinkAndroidDeviceIDAsync(UnlinkAndroidDeviceIDRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unlinks an Apple account from the player's account.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> UnlinkAppleAsync(UnlinkAppleRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unlinks a Battle.net account from the player's account.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> UnlinkBattleNetAsync(UnlinkBattleNetRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unlinks a custom ID from the player's account.
        /// </summary>
        Task<PlayFabResult<UnlinkCustomIDResult>> UnlinkCustomIDAsync(UnlinkCustomIDRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unlinks a Facebook account from the player's account.
        /// </summary>
        Task<PlayFabResult<UnlinkFacebookAccountResult>> UnlinkFacebookAccountAsync(UnlinkFacebookAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unlinks a Facebook Instant Games ID from the player's account.
        /// </summary>
        Task<PlayFabResult<UnlinkFacebookInstantGamesIdResult>> UnlinkFacebookInstantGamesIdAsync(UnlinkFacebookInstantGamesIdRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unlinks a Game Center account from the player's account.
        /// </summary>
        Task<PlayFabResult<UnlinkGameCenterAccountResult>> UnlinkGameCenterAccountAsync(UnlinkGameCenterAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unlinks a Google account from the player's account.
        /// </summary>
        Task<PlayFabResult<UnlinkGoogleAccountResult>> UnlinkGoogleAccountAsync(UnlinkGoogleAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unlinks a Google Play Games Services account from the player's account.
        /// </summary>
        Task<PlayFabResult<UnlinkGooglePlayGamesServicesAccountResult>> UnlinkGooglePlayGamesServicesAccountAsync(UnlinkGooglePlayGamesServicesAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unlinks an iOS device ID from the player's account.
        /// </summary>
        Task<PlayFabResult<UnlinkIOSDeviceIDResult>> UnlinkIOSDeviceIDAsync(UnlinkIOSDeviceIDRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unlinks a Kongregate account from the player's account.
        /// </summary>
        Task<PlayFabResult<UnlinkKongregateAccountResult>> UnlinkKongregateAsync(UnlinkKongregateAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unlinks a Nintendo Service Account from the player's account.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> UnlinkNintendoServiceAccountAsync(UnlinkNintendoServiceAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unlinks a Nintendo Switch device ID from the player's account.
        /// </summary>
        Task<PlayFabResult<UnlinkNintendoSwitchDeviceIdResult>> UnlinkNintendoSwitchDeviceIdAsync(UnlinkNintendoSwitchDeviceIdRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unlinks an OpenID Connect account from the player's account.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> UnlinkOpenIdConnectAsync(UnlinkOpenIdConnectRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unlinks a PlayStation Network account from the player's account.
        /// </summary>
        Task<PlayFabResult<UnlinkPSNAccountResult>> UnlinkPSNAccountAsync(UnlinkPSNAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unlinks a Steam account from the player's account.
        /// </summary>
        Task<PlayFabResult<UnlinkSteamAccountResult>> UnlinkSteamAccountAsync(UnlinkSteamAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unlinks a Twitch account from the player's account.
        /// </summary>
        Task<PlayFabResult<UnlinkTwitchAccountResult>> UnlinkTwitchAsync(UnlinkTwitchAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unlinks an Xbox account from the player's account.
        /// </summary>
        Task<PlayFabResult<UnlinkXboxAccountResult>> UnlinkXboxAccountAsync(UnlinkXboxAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unlocks a container instance for the player.
        /// </summary>
        Task<PlayFabResult<UnlockContainerItemResult>> UnlockContainerInstanceAsync(UnlockContainerInstanceRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unlocks a container item for the player.
        /// </summary>
        Task<PlayFabResult<UnlockContainerItemResult>> UnlockContainerItemAsync(UnlockContainerItemRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates the avatar URL for the player.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> UpdateAvatarUrlAsync(UpdateAvatarUrlRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates character data for the specified character.
        /// </summary>
        Task<PlayFabResult<UpdateCharacterDataResult>> UpdateCharacterDataAsync(UpdateCharacterDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates character statistics for the specified character.
        /// </summary>
        Task<PlayFabResult<UpdateCharacterStatisticsResult>> UpdateCharacterStatisticsAsync(UpdateCharacterStatisticsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates custom properties for the player.
        /// </summary>
        Task<PlayFabResult<UpdatePlayerCustomPropertiesResult>> UpdatePlayerCustomPropertiesAsync(UpdatePlayerCustomPropertiesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates player statistics for the player.
        /// </summary>
        Task<PlayFabResult<UpdatePlayerStatisticsResult>> UpdatePlayerStatisticsAsync(UpdatePlayerStatisticsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates shared group data.
        /// </summary>
        Task<PlayFabResult<UpdateSharedGroupDataResult>> UpdateSharedGroupDataAsync(UpdateSharedGroupDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates user data for the player.
        /// </summary>
        Task<PlayFabResult<UpdateUserDataResult>> UpdateUserDataAsync(UpdateUserDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates publisher data for the user.
        /// </summary>
        Task<PlayFabResult<UpdateUserDataResult>> UpdateUserPublisherDataAsync(UpdateUserDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates the user's title display name.
        /// </summary>
        Task<PlayFabResult<UpdateUserTitleDisplayNameResult>> UpdateUserTitleDisplayNameAsync(UpdateUserTitleDisplayNameRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Validates an Amazon IAP receipt.
        /// </summary>
        Task<PlayFabResult<ValidateAmazonReceiptResult>> ValidateAmazonIAPReceiptAsync(ValidateAmazonReceiptRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Validates a Google Play purchase.
        /// </summary>
        Task<PlayFabResult<ValidateGooglePlayPurchaseResult>> ValidateGooglePlayPurchaseAsync(ValidateGooglePlayPurchaseRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Validates an iOS receipt.
        /// </summary>
        Task<PlayFabResult<ValidateIOSReceiptResult>> ValidateIOSReceiptAsync(ValidateIOSReceiptRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Validates a Windows Store receipt.
        /// </summary>
        Task<PlayFabResult<ValidateWindowsReceiptResult>> ValidateWindowsStoreReceiptAsync(ValidateWindowsReceiptRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Writes a character event.
        /// </summary>
        Task<PlayFabResult<WriteEventResponse>> WriteCharacterEventAsync(WriteClientCharacterEventRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Writes a player event.
        /// </summary>
        Task<PlayFabResult<WriteEventResponse>> WritePlayerEventAsync(WriteClientPlayerEventRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Writes a title event.
        /// </summary>
        Task<PlayFabResult<WriteEventResponse>> WriteTitleEventAsync(WriteTitleEventRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
    }
}


