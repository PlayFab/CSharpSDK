using PlayFab.ServerModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayFab
{
    /// <summary>
    /// Interface for PlayFab Server Instance API, providing asynchronous methods for server-side PlayFab operations.
    /// </summary>
    public interface IPlayFabServerInstanceAPI
    {
        /// <summary>
        /// Forgets all stored credentials for the current instance.
        /// </summary>
        void ForgetAllCredentials();

        /// <summary>
        /// Adds virtual currency to a character's balance.
        /// </summary>
        Task<PlayFabResult<ModifyCharacterVirtualCurrencyResult>> AddCharacterVirtualCurrencyAsync(AddCharacterVirtualCurrencyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Adds a friend to the player's friend list.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> AddFriendAsync(AddFriendRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Adds a generic ID to the user's account.
        /// </summary>
        Task<PlayFabResult<EmptyResult>> AddGenericIDAsync(AddGenericIDRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Adds a tag to a player profile.
        /// </summary>
        Task<PlayFabResult<AddPlayerTagResult>> AddPlayerTagAsync(AddPlayerTagRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Adds members to a shared group.
        /// </summary>
        Task<PlayFabResult<AddSharedGroupMembersResult>> AddSharedGroupMembersAsync(AddSharedGroupMembersRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Adds virtual currency to a user's balance.
        /// </summary>
        Task<PlayFabResult<ModifyUserVirtualCurrencyResult>> AddUserVirtualCurrencyAsync(AddUserVirtualCurrencyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Authenticates a session ticket for a user.
        /// </summary>
        Task<PlayFabResult<AuthenticateSessionTicketResult>> AuthenticateSessionTicketAsync(AuthenticateSessionTicketRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Awards Steam achievements to users.
        /// </summary>
        Task<PlayFabResult<AwardSteamAchievementResult>> AwardSteamAchievementAsync(AwardSteamAchievementRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Bans users by PlayFab ID, IP, or MAC address.
        /// </summary>
        Task<PlayFabResult<BanUsersResult>> BanUsersAsync(BanUsersRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Consumes an item from a user's inventory.
        /// </summary>
        Task<PlayFabResult<ConsumeItemResult>> ConsumeItemAsync(ConsumeItemRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Creates a new shared group.
        /// </summary>
        Task<PlayFabResult<CreateSharedGroupResult>> CreateSharedGroupAsync(CreateSharedGroupRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes a character from a user's account.
        /// </summary>
        Task<PlayFabResult<DeleteCharacterFromUserResult>> DeleteCharacterFromUserAsync(DeleteCharacterFromUserRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes a player from the title.
        /// </summary>
        Task<PlayFabResult<DeletePlayerResult>> DeletePlayerAsync(DeletePlayerRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes custom properties for a specified player.
        /// </summary>
        Task<PlayFabResult<DeletePlayerCustomPropertiesResult>> DeletePlayerCustomPropertiesAsync(DeletePlayerCustomPropertiesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes a push notification template.
        /// </summary>
        Task<PlayFabResult<DeletePushNotificationTemplateResult>> DeletePushNotificationTemplateAsync(DeletePushNotificationTemplateRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes a shared group.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> DeleteSharedGroupAsync(DeleteSharedGroupRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Evaluates a random result table.
        /// </summary>
        Task<PlayFabResult<EvaluateRandomResultTableResult>> EvaluateRandomResultTableAsync(EvaluateRandomResultTableRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Executes a Cloud Script function.
        /// </summary>
        Task<PlayFabResult<ExecuteCloudScriptResult>> ExecuteCloudScriptAsync(ExecuteCloudScriptServerRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets all player segments.
        /// </summary>
        Task<PlayFabResult<GetAllSegmentsResult>> GetAllSegmentsAsync(GetAllSegmentsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets all characters for a user.
        /// </summary>
        Task<PlayFabResult<ListUsersCharactersResult>> GetAllUsersCharactersAsync(ListUsersCharactersRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets catalog items for the title.
        /// </summary>
        Task<PlayFabResult<GetCatalogItemsResult>> GetCatalogItemsAsync(GetCatalogItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets character data for a character.
        /// </summary>
        Task<PlayFabResult<GetCharacterDataResult>> GetCharacterDataAsync(GetCharacterDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets internal character data for a character.
        /// </summary>
        Task<PlayFabResult<GetCharacterDataResult>> GetCharacterInternalDataAsync(GetCharacterDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the inventory of a character.
        /// </summary>
        Task<PlayFabResult<GetCharacterInventoryResult>> GetCharacterInventoryAsync(GetCharacterInventoryRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the leaderboard for a character.
        /// </summary>
        Task<PlayFabResult<GetCharacterLeaderboardResult>> GetCharacterLeaderboardAsync(GetCharacterLeaderboardRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets read-only character data for a character.
        /// </summary>
        Task<PlayFabResult<GetCharacterDataResult>> GetCharacterReadOnlyDataAsync(GetCharacterDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets statistics for a character.
        /// </summary>
        Task<PlayFabResult<GetCharacterStatisticsResult>> GetCharacterStatisticsAsync(GetCharacterStatisticsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets a download URL for content.
        /// </summary>
        Task<PlayFabResult<GetContentDownloadUrlResult>> GetContentDownloadUrlAsync(GetContentDownloadUrlRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the leaderboard for a player's friends.
        /// </summary>
        Task<PlayFabResult<GetLeaderboardResult>> GetFriendLeaderboardAsync(GetFriendLeaderboardRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the friends list for a player.
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
        /// Gets the leaderboard around a user.
        /// </summary>
        Task<PlayFabResult<GetLeaderboardAroundUserResult>> GetLeaderboardAroundUserAsync(GetLeaderboardAroundUserRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the leaderboard for all characters of a user.
        /// </summary>
        Task<PlayFabResult<GetLeaderboardForUsersCharactersResult>> GetLeaderboardForUserCharactersAsync(GetLeaderboardForUsersCharactersRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets combined info for a player.
        /// </summary>
        Task<PlayFabResult<GetPlayerCombinedInfoResult>> GetPlayerCombinedInfoAsync(GetPlayerCombinedInfoRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets custom properties for a player.
        /// </summary>
        Task<PlayFabResult<GetPlayerCustomPropertyResult>> GetPlayerCustomPropertyAsync(GetPlayerCustomPropertyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the profile for a player.
        /// </summary>
        Task<PlayFabResult<GetPlayerProfileResult>> GetPlayerProfileAsync(GetPlayerProfileRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the segments for a player.
        /// </summary>
        Task<PlayFabResult<GetPlayerSegmentsResult>> GetPlayerSegmentsAsync(GetPlayersSegmentsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets players in a segment.
        /// </summary>
        Task<PlayFabResult<GetPlayersInSegmentResult>> GetPlayersInSegmentAsync(GetPlayersInSegmentRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets statistics for a player.
        /// </summary>
        Task<PlayFabResult<GetPlayerStatisticsResult>> GetPlayerStatisticsAsync(GetPlayerStatisticsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets statistic versions for a player.
        /// </summary>
        Task<PlayFabResult<GetPlayerStatisticVersionsResult>> GetPlayerStatisticVersionsAsync(GetPlayerStatisticVersionsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets tags for a player.
        /// </summary>
        Task<PlayFabResult<GetPlayerTagsResult>> GetPlayerTagsAsync(GetPlayerTagsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

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
        /// Gets PlayFab IDs from generic IDs.
        /// </summary>
        Task<PlayFabResult<GetPlayFabIDsFromGenericIDsResult>> GetPlayFabIDsFromGenericIDsAsync(GetPlayFabIDsFromGenericIDsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets PlayFab IDs from Nintendo Service Account IDs.
        /// </summary>
        Task<PlayFabResult<GetPlayFabIDsFromNintendoServiceAccountIdsResult>> GetPlayFabIDsFromNintendoServiceAccountIdsAsync(GetPlayFabIDsFromNintendoServiceAccountIdsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets PlayFab IDs from Nintendo Switch Device IDs.
        /// </summary>
        Task<PlayFabResult<GetPlayFabIDsFromNintendoSwitchDeviceIdsResult>> GetPlayFabIDsFromNintendoSwitchDeviceIdsAsync(GetPlayFabIDsFromNintendoSwitchDeviceIdsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets PlayFab IDs from PSN account IDs.
        /// </summary>
        Task<PlayFabResult<GetPlayFabIDsFromPSNAccountIDsResult>> GetPlayFabIDsFromPSNAccountIDsAsync(GetPlayFabIDsFromPSNAccountIDsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets PlayFab IDs from PSN online IDs.
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
        /// Gets random result tables for the title.
        /// </summary>
        Task<PlayFabResult<GetRandomResultTablesResult>> GetRandomResultTablesAsync(GetRandomResultTablesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets server custom IDs from PlayFab IDs.
        /// </summary>
        Task<PlayFabResult<GetServerCustomIDsFromPlayFabIDsResult>> GetServerCustomIDsFromPlayFabIDsAsync(GetServerCustomIDsFromPlayFabIDsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets shared group data.
        /// </summary>
        Task<PlayFabResult<GetSharedGroupDataResult>> GetSharedGroupDataAsync(GetSharedGroupDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets store items for a store.
        /// </summary>
        Task<PlayFabResult<GetStoreItemsResult>> GetStoreItemsAsync(GetStoreItemsServerRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the current time from the PlayFab service.
        /// </summary>
        Task<PlayFabResult<GetTimeResult>> GetTimeAsync(GetTimeRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets title data for the title.
        /// </summary>
        Task<PlayFabResult<GetTitleDataResult>> GetTitleDataAsync(GetTitleDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets internal title data for the title.
        /// </summary>
        Task<PlayFabResult<GetTitleDataResult>> GetTitleInternalDataAsync(GetTitleDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets title news for the title.
        /// </summary>
        Task<PlayFabResult<GetTitleNewsResult>> GetTitleNewsAsync(GetTitleNewsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets user account info.
        /// </summary>
        Task<PlayFabResult<GetUserAccountInfoResult>> GetUserAccountInfoAsync(GetUserAccountInfoRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets user bans for a user.
        /// </summary>
        Task<PlayFabResult<GetUserBansResult>> GetUserBansAsync(GetUserBansRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets user data for a user.
        /// </summary>
        Task<PlayFabResult<GetUserDataResult>> GetUserDataAsync(GetUserDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets internal user data for a user.
        /// </summary>
        Task<PlayFabResult<GetUserDataResult>> GetUserInternalDataAsync(GetUserDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the inventory of a user.
        /// </summary>
        Task<PlayFabResult<GetUserInventoryResult>> GetUserInventoryAsync(GetUserInventoryRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets publisher data for a user.
        /// </summary>
        Task<PlayFabResult<GetUserDataResult>> GetUserPublisherDataAsync(GetUserDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets internal publisher data for a user.
        /// </summary>
        Task<PlayFabResult<GetUserDataResult>> GetUserPublisherInternalDataAsync(GetUserDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets read-only publisher data for a user.
        /// </summary>
        Task<PlayFabResult<GetUserDataResult>> GetUserPublisherReadOnlyDataAsync(GetUserDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets read-only user data for a user.
        /// </summary>
        Task<PlayFabResult<GetUserDataResult>> GetUserReadOnlyDataAsync(GetUserDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Grants a character to a user.
        /// </summary>
        Task<PlayFabResult<GrantCharacterToUserResult>> GrantCharacterToUserAsync(GrantCharacterToUserRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Grants items to a character.
        /// </summary>
        Task<PlayFabResult<GrantItemsToCharacterResult>> GrantItemsToCharacterAsync(GrantItemsToCharacterRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Grants items to a user.
        /// </summary>
        Task<PlayFabResult<GrantItemsToUserResult>> GrantItemsToUserAsync(GrantItemsToUserRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Grants items to multiple users.
        /// </summary>
        Task<PlayFabResult<GrantItemsToUsersResult>> GrantItemsToUsersAsync(GrantItemsToUsersRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Links a Nintendo Service Account to a user.
        /// </summary>
        Task<PlayFabResult<EmptyResult>> LinkNintendoServiceAccountAsync(LinkNintendoServiceAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Links a Nintendo Service Account subject to a user.
        /// </summary>
        Task<PlayFabResult<EmptyResult>> LinkNintendoServiceAccountSubjectAsync(LinkNintendoServiceAccountSubjectRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Links a Nintendo Switch Device ID to a user.
        /// </summary>
        Task<PlayFabResult<LinkNintendoSwitchDeviceIdResult>> LinkNintendoSwitchDeviceIdAsync(LinkNintendoSwitchDeviceIdRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Links a PlayStation Network account to a user.
        /// </summary>
        Task<PlayFabResult<LinkPSNAccountResult>> LinkPSNAccountAsync(LinkPSNAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Links a PlayStation Network ID to a user.
        /// </summary>
        Task<PlayFabResult<LinkPSNIdResponse>> LinkPSNIdAsync(LinkPSNIdRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Links a server custom ID to a user.
        /// </summary>
        Task<PlayFabResult<LinkServerCustomIdResult>> LinkServerCustomIdAsync(LinkServerCustomIdRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Links a Steam ID to a user.
        /// </summary>
        Task<PlayFabResult<LinkSteamIdResult>> LinkSteamIdAsync(LinkSteamIdRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Links an Xbox account to a user.
        /// </summary>
        Task<PlayFabResult<LinkXboxAccountResult>> LinkXboxAccountAsync(LinkXboxAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists custom properties for a player.
        /// </summary>
        Task<PlayFabResult<ListPlayerCustomPropertiesResult>> ListPlayerCustomPropertiesAsync(ListPlayerCustomPropertiesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Logs in a user with an Android device ID.
        /// </summary>
        Task<PlayFabResult<ServerLoginResult>> LoginWithAndroidDeviceIDAsync(LoginWithAndroidDeviceIDRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Logs in a user with a custom ID.
        /// </summary>
        Task<PlayFabResult<ServerLoginResult>> LoginWithCustomIDAsync(LoginWithCustomIDRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Logs in a user with an iOS device ID.
        /// </summary>
        Task<PlayFabResult<ServerLoginResult>> LoginWithIOSDeviceIDAsync(LoginWithIOSDeviceIDRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Logs in a user with a PlayStation Network account.
        /// </summary>
        Task<PlayFabResult<ServerLoginResult>> LoginWithPSNAsync(LoginWithPSNRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Logs in a user with a server custom ID.
        /// </summary>
        Task<PlayFabResult<ServerLoginResult>> LoginWithServerCustomIdAsync(LoginWithServerCustomIdRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Logs in a user with a Steam ID.
        /// </summary>
        Task<PlayFabResult<ServerLoginResult>> LoginWithSteamIdAsync(LoginWithSteamIdRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Logs in a user with an Xbox account.
        /// </summary>
        Task<PlayFabResult<ServerLoginResult>> LoginWithXboxAsync(LoginWithXboxRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Logs in a user with an Xbox ID.
        /// </summary>
        Task<PlayFabResult<ServerLoginResult>> LoginWithXboxIdAsync(LoginWithXboxIdRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Modifies the number of uses for an inventory item.
        /// </summary>
        Task<PlayFabResult<ModifyItemUsesResult>> ModifyItemUsesAsync(ModifyItemUsesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Moves an item from one character to another.
        /// </summary>
        Task<PlayFabResult<MoveItemToCharacterFromCharacterResult>> MoveItemToCharacterFromCharacterAsync(MoveItemToCharacterFromCharacterRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Moves an item from a user to a character.
        /// </summary>
        Task<PlayFabResult<MoveItemToCharacterFromUserResult>> MoveItemToCharacterFromUserAsync(MoveItemToCharacterFromUserRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Moves an item from a character to a user.
        /// </summary>
        Task<PlayFabResult<MoveItemToUserFromCharacterResult>> MoveItemToUserFromCharacterAsync(MoveItemToUserFromCharacterRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Redeems a coupon for a user.
        /// </summary>
        Task<PlayFabResult<RedeemCouponResult>> RedeemCouponAsync(RedeemCouponRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Removes a friend from the player's friend list.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> RemoveFriendAsync(RemoveFriendRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Removes a generic ID from the user's account.
        /// </summary>
        Task<PlayFabResult<EmptyResult>> RemoveGenericIDAsync(RemoveGenericIDRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Removes a tag from a player profile.
        /// </summary>
        Task<PlayFabResult<RemovePlayerTagResult>> RemovePlayerTagAsync(RemovePlayerTagRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Removes members from a shared group.
        /// </summary>
        Task<PlayFabResult<RemoveSharedGroupMembersResult>> RemoveSharedGroupMembersAsync(RemoveSharedGroupMembersRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Reports a player for abusive behavior.
        /// </summary>
        Task<PlayFabResult<ReportPlayerServerResult>> ReportPlayerAsync(ReportPlayerServerRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Revokes all bans for a user.
        /// </summary>
        Task<PlayFabResult<RevokeAllBansForUserResult>> RevokeAllBansForUserAsync(RevokeAllBansForUserRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Revokes bans for users.
        /// </summary>
        Task<PlayFabResult<RevokeBansResult>> RevokeBansAsync(RevokeBansRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Revokes an inventory item from a user.
        /// </summary>
        Task<PlayFabResult<RevokeInventoryResult>> RevokeInventoryItemAsync(RevokeInventoryItemRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Revokes multiple inventory items from users.
        /// </summary>
        Task<PlayFabResult<RevokeInventoryItemsResult>> RevokeInventoryItemsAsync(RevokeInventoryItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Saves a push notification template.
        /// </summary>
        Task<PlayFabResult<SavePushNotificationTemplateResult>> SavePushNotificationTemplateAsync(SavePushNotificationTemplateRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Sends a custom account recovery email.
        /// </summary>
        Task<PlayFabResult<SendCustomAccountRecoveryEmailResult>> SendCustomAccountRecoveryEmailAsync(SendCustomAccountRecoveryEmailRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Sends an email from a template.
        /// </summary>
        Task<PlayFabResult<SendEmailFromTemplateResult>> SendEmailFromTemplateAsync(SendEmailFromTemplateRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Sends a push notification to a user.
        /// </summary>
        Task<PlayFabResult<SendPushNotificationResult>> SendPushNotificationAsync(SendPushNotificationRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Sends a push notification from a template.
        /// </summary>
        Task<PlayFabResult<SendPushNotificationResult>> SendPushNotificationFromTemplateAsync(SendPushNotificationFromTemplateRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Sets tags for a friend.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> SetFriendTagsAsync(SetFriendTagsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Sets a secret for a player.
        /// </summary>
        Task<PlayFabResult<SetPlayerSecretResult>> SetPlayerSecretAsync(SetPlayerSecretRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Sets publisher data for the title.
        /// </summary>
        Task<PlayFabResult<SetPublisherDataResult>> SetPublisherDataAsync(SetPublisherDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Sets title data for the title.
        /// </summary>
        Task<PlayFabResult<SetTitleDataResult>> SetTitleDataAsync(SetTitleDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Sets internal title data for the title.
        /// </summary>
        Task<PlayFabResult<SetTitleDataResult>> SetTitleInternalDataAsync(SetTitleDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Subtracts virtual currency from a character's balance.
        /// </summary>
        Task<PlayFabResult<ModifyCharacterVirtualCurrencyResult>> SubtractCharacterVirtualCurrencyAsync(SubtractCharacterVirtualCurrencyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Subtracts virtual currency from a user's balance.
        /// </summary>
        Task<PlayFabResult<ModifyUserVirtualCurrencyResult>> SubtractUserVirtualCurrencyAsync(SubtractUserVirtualCurrencyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unlinks a Nintendo Service Account from a user.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> UnlinkNintendoServiceAccountAsync(UnlinkNintendoServiceAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unlinks a Nintendo Switch Device ID from a user.
        /// </summary>
        Task<PlayFabResult<UnlinkNintendoSwitchDeviceIdResult>> UnlinkNintendoSwitchDeviceIdAsync(UnlinkNintendoSwitchDeviceIdRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unlinks a PlayStation Network account from a user.
        /// </summary>
        Task<PlayFabResult<UnlinkPSNAccountResult>> UnlinkPSNAccountAsync(UnlinkPSNAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unlinks a server custom ID from a user.
        /// </summary>
        Task<PlayFabResult<UnlinkServerCustomIdResult>> UnlinkServerCustomIdAsync(UnlinkServerCustomIdRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unlinks a Steam ID from a user.
        /// </summary>
        Task<PlayFabResult<UnlinkSteamIdResult>> UnlinkSteamIdAsync(UnlinkSteamIdRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unlinks an Xbox account from a user.
        /// </summary>
        Task<PlayFabResult<UnlinkXboxAccountResult>> UnlinkXboxAccountAsync(UnlinkXboxAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unlocks a container instance for a user.
        /// </summary>
        Task<PlayFabResult<UnlockContainerItemResult>> UnlockContainerInstanceAsync(UnlockContainerInstanceRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unlocks a container item for a user.
        /// </summary>
        Task<PlayFabResult<UnlockContainerItemResult>> UnlockContainerItemAsync(UnlockContainerItemRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates the avatar URL for a user.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> UpdateAvatarUrlAsync(UpdateAvatarUrlRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates bans for users.
        /// </summary>
        Task<PlayFabResult<UpdateBansResult>> UpdateBansAsync(UpdateBansRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates character data for a character.
        /// </summary>
        Task<PlayFabResult<UpdateCharacterDataResult>> UpdateCharacterDataAsync(UpdateCharacterDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates internal character data for a character.
        /// </summary>
        Task<PlayFabResult<UpdateCharacterDataResult>> UpdateCharacterInternalDataAsync(UpdateCharacterDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates read-only character data for a character.
        /// </summary>
        Task<PlayFabResult<UpdateCharacterDataResult>> UpdateCharacterReadOnlyDataAsync(UpdateCharacterDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates statistics for a character.
        /// </summary>
        Task<PlayFabResult<UpdateCharacterStatisticsResult>> UpdateCharacterStatisticsAsync(UpdateCharacterStatisticsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates custom properties for a player.
        /// </summary>
        Task<PlayFabResult<UpdatePlayerCustomPropertiesResult>> UpdatePlayerCustomPropertiesAsync(UpdatePlayerCustomPropertiesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates statistics for a player.
        /// </summary>
        Task<PlayFabResult<UpdatePlayerStatisticsResult>> UpdatePlayerStatisticsAsync(UpdatePlayerStatisticsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates shared group data.
        /// </summary>
        Task<PlayFabResult<UpdateSharedGroupDataResult>> UpdateSharedGroupDataAsync(UpdateSharedGroupDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates user data for a user.
        /// </summary>
        Task<PlayFabResult<UpdateUserDataResult>> UpdateUserDataAsync(UpdateUserDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates internal user data for a user.
        /// </summary>
        Task<PlayFabResult<UpdateUserDataResult>> UpdateUserInternalDataAsync(UpdateUserInternalDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates custom data for a user inventory item.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> UpdateUserInventoryItemCustomDataAsync(UpdateUserInventoryItemDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates publisher data for a user.
        /// </summary>
        Task<PlayFabResult<UpdateUserDataResult>> UpdateUserPublisherDataAsync(UpdateUserDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates internal publisher data for a user.
        /// </summary>
        Task<PlayFabResult<UpdateUserDataResult>> UpdateUserPublisherInternalDataAsync(UpdateUserInternalDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates read-only publisher data for a user.
        /// </summary>
        Task<PlayFabResult<UpdateUserDataResult>> UpdateUserPublisherReadOnlyDataAsync(UpdateUserDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates read-only user data for a user.
        /// </summary>
        Task<PlayFabResult<UpdateUserDataResult>> UpdateUserReadOnlyDataAsync(UpdateUserDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Writes a character event.
        /// </summary>
        Task<PlayFabResult<WriteEventResponse>> WriteCharacterEventAsync(WriteServerCharacterEventRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Writes a player event.
        /// </summary>
        Task<PlayFabResult<WriteEventResponse>> WritePlayerEventAsync(WriteServerPlayerEventRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Writes a title event.
        /// </summary>
        Task<PlayFabResult<WriteEventResponse>> WriteTitleEventAsync(WriteTitleEventRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
    }
}
