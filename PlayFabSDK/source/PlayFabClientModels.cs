using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PlayFab.ClientModels
{
	
	
	
	public class AddFriendRequest
	{
		
		
		/// <summary>
		/// PlayFab identifier of the user to attempt to add to the local user's friend list
		/// </summary>
		public string FriendPlayFabId { get; set;}
		
		/// <summary>
		/// PlayFab username of the user to attempt to add to the local user's friend list
		/// </summary>
		public string FriendUsername { get; set;}
		
		/// <summary>
		/// email address of the user to attempt to add to the local user's friend list
		/// </summary>
		public string FriendEmail { get; set;}
		
		/// <summary>
		/// title-specific display name of the user to attempt to add to the local user's friend list
		/// </summary>
		public string FriendTitleDisplayName { get; set;}
		
		
	}
	
	
	
	public class AddFriendResult
	{
		
		
		/// <summary>
		/// was the friend request processed successfully
		/// </summary>
		public bool Created { get; set;}
		
		
	}
	
	
	
	public class AddSharedGroupMembersRequest
	{
		
		
		/// <summary>
		/// unique identifier for the shared group
		/// </summary>
		public string SharedGroupId { get; set;}
		
		/// <summary>
		/// list of PlayFabId identifiers of users to add as members of the shared group
		/// </summary>
		public List<string> PlayFabIds { get; set;}
		
		
	}
	
	
	
	public class AddSharedGroupMembersResult
	{
		
		
		
	}
	
	
	
	public class AddUsernamePasswordRequest
	{
		
		
		public string Username { get; set;}
		
		public string Email { get; set;}
		
		public string Password { get; set;}
		
		
	}
	
	
	
	public class AddUsernamePasswordResult
	{
		
		
		/// <summary>
		/// PlayFab unique user name
		/// </summary>
		public string Username { get; set;}
		
		
	}
	
	
	
	public class AddUserVirtualCurrencyRequest
	{
		
		
		/// <summary>
		/// name of the virtual currency which is to be incremented
		/// </summary>
		public string VirtualCurrency { get; set;}
		
		/// <summary>
		/// amount to be added to the user balance of the specified virtual currency
		/// </summary>
		public int Amount { get; set;}
		
		
	}
	
	
	
	public class AndroidDevicePushNotificationRegistrationRequest
	{
		
		
		/// <summary>
		/// the Registration ID provided by the Google Cloud Messaging service when the title registered to receive push notifications (see the GCM documentation, here: http://developer.android.com/google/gcm/client.html)
		/// </summary>
		public string DeviceToken { get; set;}
		
		/// <summary>
		/// If true, send a test push message immediately after sucessful registration. Defaults to false.
		/// </summary>
		public bool? SendPushNotificationConfirmation { get; set;}
		
		/// <summary>
		/// Message to display when confirming push notification.
		/// </summary>
		public string ConfirmationMessege { get; set;}
		
		
	}
	
	
	
	public class AndroidDevicePushNotificationRegistrationResult
	{
		
		
		
	}
	
	
	
	public class CartItem
	{
		
		
		/// <summary>
		/// unique identifier for the catalog item
		/// </summary>
		public string ItemId { get; set;}
		
		/// <summary>
		/// class name to which catalog item belongs
		/// </summary>
		public string ItemClass { get; set;}
		
		/// <summary>
		/// unique instance identifier for this catalog item
		/// </summary>
		public string ItemInstanceId { get; set;}
		
		/// <summary>
		/// display name for the catalog item
		/// </summary>
		public string DisplayName { get; set;}
		
		/// <summary>
		/// description of the catalog item
		/// </summary>
		public string Description { get; set;}
		
		/// <summary>
		/// the cost of the catalog item for each applicable virtual currency
		/// </summary>
		public Dictionary<string,uint> VirtualCurrencyPrices { get; set;}
		
		/// <summary>
		/// the cost of the catalog item for each applicable real world currency
		/// </summary>
		public Dictionary<string,uint> RealCurrencyPrices { get; set;}
		
		/// <summary>
		/// the amount of each applicable virtual currency which will be received as a result of purchasing this catalog item
		/// </summary>
		public Dictionary<string,uint> VCAmount { get; set;}
		
		
	}
	
	
	
	/// <summary>
	/// A purchasable item from the item catalog
	/// </summary>
	public class CatalogItem : IComparable<CatalogItem>
	{
		
		
		/// <summary>
		/// unique identifier for this item
		/// </summary>
		public string ItemId { get; set;}
		
		/// <summary>
		/// class to which the item belongs
		/// </summary>
		public string ItemClass { get; set;}
		
		/// <summary>
		/// catalog item for this item
		/// </summary>
		public string CatalogVersion { get; set;}
		
		/// <summary>
		/// text name for the item, to show in-game
		/// </summary>
		public string DisplayName { get; set;}
		
		/// <summary>
		/// text description of item, to show in-game
		/// </summary>
		public string Description { get; set;}
		
		/// <summary>
		/// price of this item in virtual currencies and "RM" (the base Real Money purchase price, in USD pennies)
		/// </summary>
		public Dictionary<string,uint> VirtualCurrencyPrices { get; set;}
		
		/// <summary>
		/// override prices for this item for specific currencies
		/// </summary>
		public Dictionary<string,uint> RealCurrencyPrices { get; set;}
		
		/// <summary>
		/// list of item tags
		/// </summary>
		[Unordered]
		public List<string> Tags { get; set;}
		
		/// <summary>
		/// game specific custom data
		/// </summary>
		public string CustomData { get; set;}
		
		/// <summary>
		/// array of ItemId values which are evaluated when any item is added to the player inventory - if all items in this array are present, the this item will also be added to the player inventory
		/// </summary>
		[Unordered]
		public List<string> GrantedIfPlayerHas { get; set;}
		
		/// <summary>
		/// defines the consumable properties (number of uses, timeout) for the item
		/// </summary>
		public CatalogItemConsumableInfo Consumable { get; set;}
		
		/// <summary>
		/// defines the container properties for the item - what items it contains, including random drop tables and virtual currencies, and what item (if any) is required to open it via the UnlockContainerItem API
		/// </summary>
		public CatalogItemContainerInfo Container { get; set;}
		
		/// <summary>
		/// defines the bundle properties for the item - bundles are items which contain other items, including random drop tables and virtual currencies
		/// </summary>
		public CatalogItemBundleInfo Bundle { get; set;}
		
		
		public int CompareTo(CatalogItem other)
        {
            if (other == null || other.ItemId == null) return 1;
            if (ItemId == null) return -1;
            return ItemId.CompareTo(other.ItemId);
        }
		
	}
	
	
	
	public class CatalogItemBundleInfo
	{
		
		
		/// <summary>
		/// unique ItemId values for all items which will be added to the player inventory when the bundle is added
		/// </summary>
		[Unordered]
		public List<string> BundledItems { get; set;}
		
		/// <summary>
		/// unique TableId values for all RandomResultTable objects which are part of the bundle (random tables will be resolved and add the relevant items to the player inventory when the bundle is added)
		/// </summary>
		[Unordered]
		public List<string> BundledResultTables { get; set;}
		
		/// <summary>
		/// virtual currency types and balances which will be added to the player inventory when the bundle is added
		/// </summary>
		public Dictionary<string,uint> BundledVirtualCurrencies { get; set;}
		
		
	}
	
	
	
	public class CatalogItemConsumableInfo
	{
		
		
		/// <summary>
		/// number of times this object can be used, after which it will be removed from the player inventory
		/// </summary>
		public uint? UsageCount { get; set;}
		
		/// <summary>
		/// duration in seconds for how long the item will remain in the player inventory - once elapsed, the item will be removed
		/// </summary>
		public uint? UsagePeriod { get; set;}
		
		/// <summary>
		/// all inventory item instances in the player inventory sharing a non-null UsagePeriodGroup have their UsagePeriod values added together, and share the result - when that period has elapsed, all the items in the group will be removed
		/// </summary>
		public string UsagePeriodGroup { get; set;}
		
		
	}
	
	
	
	/// <summary>
	/// Containers are inventory items that can hold other items defined in the catalog, as well as virtual currency, which is added to the player inventory when the container is unlocked, using the UnlockContainerItem API. The items can be anything defined in the catalog, as well as RandomResultTable objects which will be resolved when the container is unlocked. Containers and their keys should be defined as Consumable (having a limited number of uses) in their catalog defintiions, unless the intent is for the player to be able to re-use them infinitely.
	/// </summary>
	public class CatalogItemContainerInfo
	{
		
		
		/// <summary>
		/// ItemId for the catalog item used to unlock the container, if any (if not specified, a call to UnlockContainerItem will open the container, adding the contents to the player inventory and currency balances)
		/// </summary>
		public string KeyItemId { get; set;}
		
		/// <summary>
		/// unique ItemId values for all items which will be added to the player inventory, once the container has been unlocked
		/// </summary>
		[Unordered]
		public List<string> ItemContents { get; set;}
		
		/// <summary>
		/// unique TableId values for all RandomResultTable objects which are part of the container (once unlocked, random tables will be resolved and add the relevant items to the player inventory)
		/// </summary>
		[Unordered]
		public List<string> ResultTableContents { get; set;}
		
		/// <summary>
		/// virtual currency types and balances which will be added to the player inventory when the container is unlocked
		/// </summary>
		public Dictionary<string,uint> VirtualCurrencyContents { get; set;}
		
		
	}
	
	
	
	public class ConfirmPurchaseRequest
	{
		
		
		/// <summary>
		/// purchase order identifier returned from StartPurchase
		/// </summary>
		public string OrderId { get; set;}
		
		
	}
	
	
	
	public class ConfirmPurchaseResult
	{
		
		
		/// <summary>
		/// purchase order identifier
		/// </summary>
		public string OrderId { get; set;}
		
		/// <summary>
		/// date and time of the purchase
		/// </summary>
		public DateTime PurchaseDate { get; set;}
		
		/// <summary>
		/// array of items purchased
		/// </summary>
		public List<PurchasedItem> Items { get; set;}
		
		
	}
	
	
	
	public class ConsumeItemRequest
	{
		
		
		/// <summary>
		/// unique instance identifier of the item to be consumed
		/// </summary>
		public string ItemInstanceId { get; set;}
		
		/// <summary>
		/// number of uses to consume from the item
		/// </summary>
		public int ConsumeCount { get; set;}
		
		
	}
	
	
	
	public class ConsumeItemResult
	{
		
		
		/// <summary>
		/// unique instance identifier of the item with uses consumed
		/// </summary>
		public string ItemInstanceId { get; set;}
		
		/// <summary>
		/// number of uses remaining on the item
		/// </summary>
		public int RemainingUses { get; set;}
		
		
	}
	
	
	
	public class CreateSharedGroupRequest
	{
		
		
		/// <summary>
		/// unique identifier for the shared group (a random identifier will be assigned, if one is not specified)
		/// </summary>
		public string SharedGroupId { get; set;}
		
		
	}
	
	
	
	public class CreateSharedGroupResult
	{
		
		
		/// <summary>
		/// unique identifier for the shared group
		/// </summary>
		public string SharedGroupId { get; set;}
		
		
	}
	
	
	
	public enum Currency
	{
		USD,
		GBP,
		EUR,
		RUB,
		BRL,
		CIS,
		CAD
	}
	
	
	
	public class CurrentGamesRequest
	{
		
		
		/// <summary>
		/// region to check for game instances
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public Region? Region { get; set;}
		
		/// <summary>
		/// version of build to match against
		/// </summary>
		public string BuildVersion { get; set;}
		
		
	}
	
	
	
	public class CurrentGamesResult
	{
		
		
		/// <summary>
		/// array of games found
		/// </summary>
		public List<GameInfo> Games { get; set;}
		
		/// <summary>
		/// total number of players across all servers
		/// </summary>
		public int PlayerCount { get; set;}
		
		/// <summary>
		/// number of games running
		/// </summary>
		public int GameCount { get; set;}
		
		
	}
	
	
	
	public class EmptyResult
	{
		
		
		
	}
	
	
	
	public class FacebookPlayFabIdPair
	{
		
		
		/// <summary>
		/// unique Facebook identifier for a user
		/// </summary>
		public string FacebookId { get; set;}
		
		/// <summary>
		/// unique PlayFab identifier for a user, or null if no PlayFab account is linked to the Facebook identifier
		/// </summary>
		public string PlayFabId { get; set;}
		
		
	}
	
	
	
	public class FriendInfo
	{
		
		
		/// <summary>
		/// PlayFab unique identifier for this friend
		/// </summary>
		public string FriendPlayFabId { get; set;}
		
		/// <summary>
		/// PlayFab unique username for this friend
		/// </summary>
		public string Username { get; set;}
		
		/// <summary>
		/// title-specific display name for this friend
		/// </summary>
		public string TitleDisplayName { get; set;}
		
		/// <summary>
		/// tags which have been associated with this friend
		/// </summary>
		public List<string> Tags { get; set;}
		
		/// <summary>
		/// unique lobby identifier of the Game Server Instance to which this player is currently connected
		/// </summary>
		public string CurrentMatchmakerLobbyId { get; set;}
		
		/// <summary>
		/// available Facebook information (if the user and PlayFab friend are also connected in Facebook)
		/// </summary>
		public UserFacebookInfo FacebookInfo { get; set;}
		
		/// <summary>
		/// available Steam information (if the user and PlayFab friend are also connected in Steam)
		/// </summary>
		public UserSteamInfo SteamInfo { get; set;}
		
		/// <summary>
		/// available Game Center information (if the user and PlayFab friend are also connected in Game Center)
		/// </summary>
		public UserGameCenterInfo GameCenterInfo { get; set;}
		
		
	}
	
	
	
	public class GameInfo
	{
		
		
		/// <summary>
		/// region to which this server is associated
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public Region? Region { get; set;}
		
		/// <summary>
		/// unique lobby identifier for this game server
		/// </summary>
		public string LobbyID { get; set;}
		
		/// <summary>
		/// build version this server is running
		/// </summary>
		public string BuildVersion { get; set;}
		
		/// <summary>
		/// game mode this server is running
		/// </summary>
		public string GameMode { get; set;}
		
		/// <summary>
		/// maximum players this server can support
		/// </summary>
		public int? MaxPlayers { get; set;}
		
		/// <summary>
		/// array of strings of current player names on this server (note that these are PlayFab usernames, as opposed to title display names)
		/// </summary>
		public List<string> PlayerUserIds { get; set;}
		
		/// <summary>
		/// duration in seconds this server has been running
		/// </summary>
		public uint RunTime { get; set;}
		
		/// <summary>
		/// game specific string denoting server configuration
		/// </summary>
		public string GameServerState { get; set;}
		
		
	}
	
	
	
	public class GameServerRegionsRequest
	{
		
		
		/// <summary>
		/// version of game server for which stats are being requested
		/// </summary>
		public string BuildVersion { get; set;}
		
		public string TitleId { get; set;}
		
		
	}
	
	
	
	public class GameServerRegionsResult
	{
		
		
		/// <summary>
		/// array of regions found matching the request parameters
		/// </summary>
		public List<RegionInfo> Regions { get; set;}
		
		
	}
	
	
	
	public class GetAccountInfoRequest
	{
		
		
		/// <summary>
		/// PlayFabId of the user to load data for. Optional, defaults to yourself if not set.
		/// </summary>
		public string PlayFabId { get; set;}
		
		
	}
	
	
	
	public class GetAccountInfoResult
	{
		
		
		/// <summary>
		/// account information for the local user
		/// </summary>
		public UserAccountInfo AccountInfo { get; set;}
		
		
	}
	
	
	
	public class GetCatalogItemsRequest
	{
		
		
		/// <summary>
		/// which catalog is being requested
		/// </summary>
		public string CatalogVersion { get; set;}
		
		
	}
	
	
	
	public class GetCatalogItemsResult
	{
		
		
		/// <summary>
		/// array of inventory objects
		/// </summary>
		[Unordered(SortProperty="ItemId")]
		public List<CatalogItem> Catalog { get; set;}
		
		
	}
	
	
	
	public class GetCloudScriptUrlRequest
	{
		
		
		/// <summary>
		/// Server version to use. Defaults to 1 if left null
		/// </summary>
		public int? Version { get; set;}
		
		/// <summary>
		/// If true, run against the latest test revision of server logic. Defaults to false if left null
		/// </summary>
		public bool? Testing { get; set;}
		
		
	}
	
	
	
	public class GetCloudScriptUrlResult
	{
		
		
		/// <summary>
		/// Url of the Cloud Script logic server for this title
		/// </summary>
		public string Url { get; set;}
		
		
	}
	
	
	
	public class GetFriendLeaderboardRequest
	{
		
		
		/// <summary>
		/// statistic used to rank friends for this leaderboard
		/// </summary>
		public string StatisticName { get; set;}
		
		/// <summary>
		/// position in the leaderboard to start this listing (defaults to the first entry)
		/// </summary>
		public int StartPosition { get; set;}
		
		/// <summary>
		/// maximum number of entries to retrieve
		/// </summary>
		public int MaxResultsCount { get; set;}
		
		
	}
	
	
	
	public class GetFriendsListRequest
	{
		
		
		/// <summary>
		/// indicates whether Steam service friends should also be included in the response
		/// </summary>
		public bool? IncludeSteamFriends { get; set;}
		
		
	}
	
	
	
	public class GetFriendsListResult
	{
		
		
		/// <summary>
		/// array of friends found
		/// </summary>
		public List<FriendInfo> Friends { get; set;}
		
		
	}
	
	
	
	public class GetLeaderboardAroundCurrentUserRequest
	{
		
		
		/// <summary>
		/// statistic used to rank players for this leaderboard
		/// </summary>
		public string StatisticName { get; set;}
		
		/// <summary>
		/// maximum number of entries to retrieve
		/// </summary>
		public int MaxResultsCount { get; set;}
		
		
	}
	
	
	
	public class GetLeaderboardAroundCurrentUserResult
	{
		
		
		/// <summary>
		/// ordered listing of users and their positions in the requested leaderboard
		/// </summary>
		public List<PlayerLeaderboardEntry> Leaderboard { get; set;}
		
		
	}
	
	
	
	public class GetLeaderboardRequest
	{
		
		
		/// <summary>
		/// statistic used to rank players for this leaderboard
		/// </summary>
		public string StatisticName { get; set;}
		
		/// <summary>
		/// position in the leaderboard to start this listing (defaults to the first entry)
		/// </summary>
		public int StartPosition { get; set;}
		
		/// <summary>
		/// maximum number of entries to retrieve
		/// </summary>
		public int MaxResultsCount { get; set;}
		
		
	}
	
	
	
	public class GetLeaderboardResult
	{
		
		
		/// <summary>
		/// ordered listing of users and their positions in the requested leaderboard
		/// </summary>
		public List<PlayerLeaderboardEntry> Leaderboard { get; set;}
		
		
	}
	
	
	
	public class GetPlayFabIDsFromFacebookIDsRequest
	{
		
		
		/// <summary>
		/// array of unique Facebook identifiers for which the title needs to get PlayFab identifiers
		/// </summary>
		public List<string> FacebookIDs { get; set;}
		
		
	}
	
	
	
	public class GetPlayFabIDsFromFacebookIDsResult
	{
		
		
		/// <summary>
		/// mapping of Facebook identifiers to PlayFab identifiers
		/// </summary>
		public List<FacebookPlayFabIdPair> Data { get; set;}
		
		
	}
	
	
	
	public class GetPublisherDataRequest
	{
		
		
		/// <summary>
		///  array of keys to get back data from the Publisher data blob, set by the admin tools
		/// </summary>
		public List<string> Keys { get; set;}
		
		
	}
	
	
	
	public class GetPublisherDataResult
	{
		
		
		/// <summary>
		/// a dictionary object of key / value pairs
		/// </summary>
		public Dictionary<string,string> Data { get; set;}
		
		
	}
	
	
	
	public class GetSharedGroupDataRequest
	{
		
		
		/// <summary>
		/// unique identifier for the shared group
		/// </summary>
		public string SharedGroupId { get; set;}
		
		/// <summary>
		/// specific keys to retrieve from the shared group (if not specified, all keys will be returned, while an empty array indicates that no keys should be returned)
		/// </summary>
		public List<string> Keys { get; set;}
		
		/// <summary>
		/// if true, return the list of all members of the shared group
		/// </summary>
		public bool? GetMembers { get; set;}
		
		
	}
	
	
	
	public class GetSharedGroupDataResult
	{
		
		
		/// <summary>
		/// data for the requested keys
		/// </summary>
		public Dictionary<string,SharedGroupDataRecord> Data { get; set;}
		
		/// <summary>
		/// list of PlayFabId identifiers for the members of this group, if requested
		/// </summary>
		public List<string> Members { get; set;}
		
		
	}
	
	
	
	public class GetStoreItemsRequest
	{
		
		
		/// <summary>
		/// unqiue identifier for the store which is being requested
		/// </summary>
		public string StoreId { get; set;}
		
		
	}
	
	
	
	public class GetStoreItemsResult
	{
		
		
		/// <summary>
		/// array of store items
		/// </summary>
		[Unordered(SortProperty="ItemId")]
		public List<StoreItem> Store { get; set;}
		
		
	}
	
	
	
	public class GetTitleDataRequest
	{
		
		
		/// <summary>
		///  array of keys to get back data from the TitleData data blob, set by the admin tools
		/// </summary>
		public List<string> Keys { get; set;}
		
		
	}
	
	
	
	public class GetTitleDataResult
	{
		
		
		/// <summary>
		/// a dictionary object of key / value pairs
		/// </summary>
		public Dictionary<string,string> Data { get; set;}
		
		
	}
	
	
	
	public class GetTitleNewsRequest
	{
		
		
		/// <summary>
		/// limits the results to the last n entries (defaults to 10 if not set)
		/// </summary>
		public int? Count { get; set;}
		
		
	}
	
	
	
	public class GetTitleNewsResult
	{
		
		
		/// <summary>
		/// array of news items
		/// </summary>
		public List<TitleNewsItem> News { get; set;}
		
		
	}
	
	
	
	public class GetUserCombinedInfoRequest
	{
		
		
		/// <summary>
		/// PlayFabId of the user to load info about. Defaults to yourself if not set.
		/// </summary>
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// If set to false, account info will not be returned (defaults to true)
		/// </summary>
		public bool? GetAccountInfo { get; set;}
		
		/// <summary>
		/// If set to false, inventory will not be returned (defaults to true). Inventory will never be returned for users other than yourself.
		/// </summary>
		public bool? GetInventory { get; set;}
		
		/// <summary>
		/// If set to false, virtual currency balances will not be returned (defaults to true). Currency balances will never be returned for users other than yourself.
		/// </summary>
		public bool? GetVirtualCurrency { get; set;}
		
		/// <summary>
		/// If set to false, custom user data will not be returned (defaults to true).
		/// </summary>
		public bool? GetUserData { get; set;}
		
		/// <summary>
		/// User custom data keys to return. Leave null to get all keys. For users other than yourself, only public data will be returned.
		/// </summary>
		public List<string> UserDataKeys { get; set;}
		
		/// <summary>
		/// If set to false, read-only user data will not be returned (defaults to true).
		/// </summary>
		public bool? GetReadOnlyData { get; set;}
		
		/// <summary>
		/// User read-only custom data keys to return. Leave null to get all keys. For users other than yourself, only public data will be returned.
		/// </summary>
		public List<string> ReadOnlyDataKeys { get; set;}
		
		
	}
	
	
	
	public class GetUserCombinedInfoResult
	{
		
		
		/// <summary>
		/// PlayFabId of the owner of the combined info
		/// </summary>
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// account information for the user
		/// </summary>
		public UserAccountInfo AccountInfo { get; set;}
		
		/// <summary>
		/// array of inventory items in the user's current inventory
		/// </summary>
		[Unordered(SortProperty="ItemInstanceId")]
		public List<ItemInstance> Inventory { get; set;}
		
		/// <summary>
		/// array of virtual currency balance(s) belonging to the user
		/// </summary>
		public Dictionary<string,int> VirtualCurrency { get; set;}
		
		/// <summary>
		/// user specific custom data
		/// </summary>
		public Dictionary<string,UserDataRecord> Data { get; set;}
		
		/// <summary>
		/// user specific read-only data
		/// </summary>
		public Dictionary<string,UserDataRecord> ReadOnlyData { get; set;}
		
		
	}
	
	
	
	public class GetUserDataRequest
	{
		
		
		/// <summary>
		/// specific keys to search for in the custom user data. Leave null to get all keys.
		/// </summary>
		public List<string> Keys { get; set;}
		
		/// <summary>
		/// PlayFabId of the user to load data for. Optional, defaults to yourself if not set.
		/// </summary>
		public string PlayFabId { get; set;}
		
		
	}
	
	
	
	public class GetUserDataResult
	{
		
		
		/// <summary>
		/// user specific data for this title
		/// </summary>
		public Dictionary<string,UserDataRecord> Data { get; set;}
		
		
	}
	
	
	
	public class GetUserInventoryRequest
	{
		
		
		
	}
	
	
	
	public class GetUserInventoryResult
	{
		
		
		/// <summary>
		/// array of inventory items in the user's current inventory
		/// </summary>
		[Unordered(SortProperty="ItemInstanceId")]
		public List<ItemInstance> Inventory { get; set;}
		
		/// <summary>
		/// array of virtual currency balance(s) belonging to the user
		/// </summary>
		public Dictionary<string,int> VirtualCurrency { get; set;}
		
		
	}
	
	
	
	public class GetUserStatisticsRequest
	{
		
		
		
	}
	
	
	
	public class GetUserStatisticsResult
	{
		
		
		/// <summary>
		/// user statistics for the active title
		/// </summary>
		public Dictionary<string,int> UserStatistics { get; set;}
		
		
	}
	
	
	
	/// <summary>
	/// A unique instance of an item in a user's inventory
	/// </summary>
	public class ItemInstance : IComparable<ItemInstance>
	{
		
		
		/// <summary>
		/// unique identifier for the inventory item, as defined in the catalog
		/// </summary>
		public string ItemId { get; set;}
		
		/// <summary>
		/// unique item identifier for this specific instance of the item
		/// </summary>
		public string ItemInstanceId { get; set;}
		
		/// <summary>
		/// class name for the inventory item, as defined in the catalog
		/// </summary>
		public string ItemClass { get; set;}
		
		/// <summary>
		/// timestamp for when this instance was purchased
		/// </summary>
		public DateTime? PurchaseDate { get; set;}
		
		/// <summary>
		/// timestamp for when this instance will expire
		/// </summary>
		public DateTime? Expiration { get; set;}
		
		/// <summary>
		/// total number of remaining uses, if this is a consumable item
		/// </summary>
		public int? RemainingUses { get; set;}
		
		/// <summary>
		/// game specific comment associated with this instance when it was added to the user inventory
		/// </summary>
		public string Annotation { get; set;}
		
		/// <summary>
		/// catalog version for the inventory item, when this instance was created
		/// </summary>
		public string CatalogVersion { get; set;}
		
		/// <summary>
		/// unique identifier for the parent inventory item, as defined in the catalog, for object which were added from a bundle or container
		/// </summary>
		public string BundleParent { get; set;}
		
		
		public int CompareTo(ItemInstance other)
        {
            if (other == null || other.ItemInstanceId == null) return 1;
            if (ItemInstanceId == null) return -1;
            return ItemInstanceId.CompareTo(other.ItemInstanceId);
        }
		
	}
	
	
	
	public class ItemPuchaseRequest
	{
		
		
		/// <summary>
		/// unique ItemId of the item to purchase
		/// </summary>
		public string ItemId { get; set;}
		
		/// <summary>
		/// how many of this item to purchase
		/// </summary>
		public uint Quantity { get; set;}
		
		/// <summary>
		/// title-specific text concerning this purchase
		/// </summary>
		public string Annotation { get; set;}
		
		/// <summary>
		/// items to be upgraded as a result of this purchase (upgraded items are hidden, as they are "replaced" by the new items)
		/// </summary>
		public List<string> UpgradeFromItems { get; set;}
		
		
	}
	
	
	
	public class LinkAndroidDeviceIDRequest
	{
		
		
		/// <summary>
		/// Android device identifier for the user's device
		/// </summary>
		public string AndroidDeviceId { get; set;}
		
		/// <summary>
		/// specific Operating System version for the user's device
		/// </summary>
		public string OS { get; set;}
		
		/// <summary>
		/// specific model of the user's device
		/// </summary>
		public string AndroidDevice { get; set;}
		
		
	}
	
	
	
	public class LinkAndroidDeviceIDResult
	{
		
		
		
	}
	
	
	
	public class LinkFacebookAccountRequest
	{
		
		
		/// <summary>
		/// unique identifier from Facebook for the user
		/// </summary>
		public string AccessToken { get; set;}
		
		
	}
	
	
	
	public class LinkFacebookAccountResult
	{
		
		
		
	}
	
	
	
	public class LinkGameCenterAccountRequest
	{
		
		
		/// <summary>
		/// Game Center identifier for the player account to be linked
		/// </summary>
		public string GameCenterId { get; set;}
		
		
	}
	
	
	
	public class LinkGameCenterAccountResult
	{
		
		
		
	}
	
	
	
	public class LinkIOSDeviceIDRequest
	{
		
		
		/// <summary>
		/// vendor-specific iOS identifier for the user's device
		/// </summary>
		public string DeviceId { get; set;}
		
		/// <summary>
		/// specific Operating System version for the user's device
		/// </summary>
		public string OS { get; set;}
		
		/// <summary>
		/// specific model of the user's device
		/// </summary>
		public string DeviceModel { get; set;}
		
		
	}
	
	
	
	public class LinkIOSDeviceIDResult
	{
		
		
		
	}
	
	
	
	public class LinkSteamAccountRequest
	{
		
		
		/// <summary>
		/// authentication token for the user, returned as a byte array from Steam, and converted to a string (for example, the byte 0x08 should become "08")
		/// </summary>
		public string SteamTicket { get; set;}
		
		
	}
	
	
	
	public class LinkSteamAccountResult
	{
		
		
		
	}
	
	
	
	public class LogEventRequest
	{
		
		
		/// <summary>
		/// A unique event name which will be used as the table name in the Redshift database. The name will be made lower case, and cannot not contain spaces. The use of underscores is recommended, for readability. Events also cannot match reserved terms. The PlayFab reserved terms are 'log_in' and 'purchase', 'create' and 'request', while the Redshift reserved terms can be found here: http://docs.aws.amazon.com/redshift/latest/dg/r_pg_keywords.html.
		/// </summary>
		public string eventName { get; set;}
		
		/// <summary>
		/// Contains all the data for this event. Event Values can be strings, booleans or numerics (float, double, integer, long) and must be consistent on a per-event basis (if the Value for Key 'A' in Event 'Foo' is an integer the first time it is sent, it must be an integer in all subsequent 'Foo' events). As with event names, Keys must also not use reserved words (see above). Finally, the size of the Body for an event must be less than 32KB (UTF-8 format).
		/// </summary>
		public Dictionary<string,object> Body { get; set;}
		
		
	}
	
	
	
	public class LogEventResult
	{
		
		
		
	}
	
	
	
	public class LoginResult
	{
		
		
		/// <summary>
		/// a unique token authorizing the user and game at the server level, for the current session
		/// </summary>
		public string SessionTicket { get; set;}
		
		/// <summary>
		/// player's unique PlayFabId
		/// </summary>
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// true if the account was newly created on this login
		/// </summary>
		public bool NewlyCreated { get; set;}
		
		
	}
	
	
	
	public class LoginWithAndroidDeviceIDRequest
	{
		
		
		public string TitleId { get; set;}
		
		/// <summary>
		/// Android device identifier for the user's device
		/// </summary>
		public string AndroidDeviceId { get; set;}
		
		/// <summary>
		/// specific Operating System version for the user's device
		/// </summary>
		public string OS { get; set;}
		
		/// <summary>
		/// specific model of the user's device
		/// </summary>
		public string AndroidDevice { get; set;}
		
		/// <summary>
		/// automatically create a PlayFab account if one is not currently linked to this iOS device
		/// </summary>
		public bool? CreateAccount { get; set;}
		
		
	}
	
	
	
	public class LoginWithFacebookRequest
	{
		
		
		public string TitleId { get; set;}
		
		/// <summary>
		/// unique identifier from Facebook for the user
		/// </summary>
		public string AccessToken { get; set;}
		
		/// <summary>
		/// automatically create a PlayFab account if one is not currently linked to this Facebook account
		/// </summary>
		public bool? CreateAccount { get; set;}
		
		
	}
	
	
	
	public class LoginWithGameCenterRequest
	{
		
		
		public string TitleId { get; set;}
		
		/// <summary>
		/// unique Game Center player id
		/// </summary>
		public string PlayerId { get; set;}
		
		/// <summary>
		/// automatically create a PlayFab account if one is not currently linked to this Game Center id
		/// </summary>
		public bool? CreateAccount { get; set;}
		
		
	}
	
	
	
	public class LoginWithGoogleAccountRequest
	{
		
		
		public string TitleId { get; set;}
		
		/// <summary>
		/// unique token from Google Play for the user
		/// </summary>
		public string AccessToken { get; set;}
		
		/// <summary>
		/// automatically create a PlayFab account if one is not currently linked to this Google account
		/// </summary>
		public bool? CreateAccount { get; set;}
		
		
	}
	
	
	
	public class LoginWithIOSDeviceIDRequest
	{
		
		
		public string TitleId { get; set;}
		
		/// <summary>
		/// vendor-specific iOS identifier for the user's device
		/// </summary>
		public string DeviceId { get; set;}
		
		/// <summary>
		/// specific Operating System version for the user's device
		/// </summary>
		public string OS { get; set;}
		
		/// <summary>
		/// specific model of the user's device
		/// </summary>
		public string DeviceModel { get; set;}
		
		/// <summary>
		/// automatically create a PlayFab account if one is not currently linked to this iOS device
		/// </summary>
		public bool? CreateAccount { get; set;}
		
		
	}
	
	
	
	public class LoginWithPlayFabRequest
	{
		
		
		public string TitleId { get; set;}
		
		public string Username { get; set;}
		
		public string Password { get; set;}
		
		
	}
	
	
	
	public class LoginWithSteamRequest
	{
		
		
		public string TitleId { get; set;}
		
		/// <summary>
		/// authentication token for the user, returned as a byte array from Steam, and converted to a string (for example, the byte 0x08 should become "08")
		/// </summary>
		public string SteamTicket { get; set;}
		
		/// <summary>
		/// automatically create a PlayFab account if one is not currently linked to this Steam account
		/// </summary>
		public bool? CreateAccount { get; set;}
		
		
	}
	
	
	
	public class MatchmakeRequest
	{
		
		
		/// <summary>
		/// build version to match against
		/// </summary>
		public string BuildVersion { get; set;}
		
		/// <summary>
		/// region to match make against
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public Region? Region { get; set;}
		
		/// <summary>
		/// game mode to match make against
		/// </summary>
		public string GameMode { get; set;}
		
		/// <summary>
		/// lobby identifier to match make against (used to select a specific server)
		/// </summary>
		public string LobbyId { get; set;}
		
		/// <summary>
		/// [deprecated]
		/// </summary>
		public bool? EnableQueue { get; set;}
		
		
	}
	
	
	
	public class MatchmakeResult
	{
		
		
		/// <summary>
		/// unique lobby identifier of the server matched
		/// </summary>
		public string LobbyID { get; set;}
		
		/// <summary>
		/// IP address of the server
		/// </summary>
		public string ServerHostname { get; set;}
		
		/// <summary>
		/// port number to use for non-http communications with the server
		/// </summary>
		public int? ServerPort { get; set;}
		
		/// <summary>
		/// server authorization ticket (used by RedeemCoupon to validate user insertion into the game)
		/// </summary>
		public string Ticket { get; set;}
		
		/// <summary>
		/// timestamp for when the server will expire, if applicable
		/// </summary>
		public string Expires { get; set;}
		
		/// <summary>
		/// time in milliseconds the application is configured to wait on matchmaking results
		/// </summary>
		public int? PollWaitTimeMS { get; set;}
		
		/// <summary>
		/// result of match making process
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public MatchmakeStatus? Status { get; set;}
		
		
	}
	
	
	
	public enum MatchmakeStatus
	{
		Complete,
		Waiting,
		GameNotFound
	}
	
	
	
	public class ModifyUserVirtualCurrencyResult
	{
		
		
		/// <summary>
		/// name of the virtual currency which was modified
		/// </summary>
		public string VirtualCurrency { get; set;}
		
		/// <summary>
		/// balance of the virtual currency after modification
		/// </summary>
		public int Balance { get; set;}
		
		
	}
	
	
	
	public class PayForPurchaseRequest
	{
		
		
		/// <summary>
		/// purchase order identifier returned from StartPurchase
		/// </summary>
		public string OrderId { get; set;}
		
		/// <summary>
		/// payment provider to use to fund the purchase
		/// </summary>
		public string ProviderName { get; set;}
		
		/// <summary>
		/// currency to use to fund the purchase
		/// </summary>
		public string Currency { get; set;}
		
		
	}
	
	
	
	public class PayForPurchaseResult
	{
		
		
		/// <summary>
		/// purchase order identifier
		/// </summary>
		public string OrderId { get; set;}
		
		/// <summary>
		/// status of the transaction
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public TransactionStatus? Status { get; set;}
		
		/// <summary>
		/// virtual currency cost of the transaction
		/// </summary>
		public Dictionary<string,int> VCAmount { get; set;}
		
		/// <summary>
		/// real world currency for the transaction
		/// </summary>
		public string PurchaseCurrency { get; set;}
		
		/// <summary>
		/// real world cost of the transaction
		/// </summary>
		public uint PurchasePrice { get; set;}
		
		/// <summary>
		/// local credit applied to the transaction (provider specific)
		/// </summary>
		public uint CreditApplied { get; set;}
		
		/// <summary>
		/// provider used for the transaction
		/// </summary>
		public string ProviderData { get; set;}
		
		/// <summary>
		/// url to the purchase provider page that details the purchase
		/// </summary>
		public string PurchaseConfirmationPageURL { get; set;}
		
		/// <summary>
		/// current virtual currency totals for the user
		/// </summary>
		public Dictionary<string,int> VirtualCurrency { get; set;}
		
		
	}
	
	
	
	public class PaymentOption
	{
		
		
		/// <summary>
		/// specific currency to use to fund the purchase
		/// </summary>
		public string Currency { get; set;}
		
		/// <summary>
		/// name of the purchase provider for this option
		/// </summary>
		public string ProviderName { get; set;}
		
		/// <summary>
		/// amount of the specified currency needed for the purchase
		/// </summary>
		public uint Price { get; set;}
		
		/// <summary>
		/// amount of existing credit the user has with the provider
		/// </summary>
		public uint StoreCredit { get; set;}
		
		
	}
	
	
	
	public class PlayerLeaderboardEntry
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user for this leaderboard entry
		/// </summary>
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// title-specific display name of the user for this leaderboard entry
		/// </summary>
		public string DisplayName { get; set;}
		
		/// <summary>
		/// specific value of the user's statistic
		/// </summary>
		public int StatValue { get; set;}
		
		/// <summary>
		/// user's overall position in the leaderboard
		/// </summary>
		public int Position { get; set;}
		
		
	}
	
	
	
	public class PurchasedItem
	{
		
		
		/// <summary>
		/// unique instance identifier for this catalog item
		/// </summary>
		public string ItemInstanceId { get; set;}
		
		/// <summary>
		/// unique identifier for the catalog item
		/// </summary>
		public string ItemId { get; set;}
		
		/// <summary>
		/// catalog version for the item purchased
		/// </summary>
		public string CatalogVersion { get; set;}
		
		/// <summary>
		/// display name for the catalog item
		/// </summary>
		public string DisplayName { get; set;}
		
		/// <summary>
		/// currency type for the cost of the catalog item
		/// </summary>
		public string UnitCurrency { get; set;}
		
		/// <summary>
		/// cost of the catalog item in the given currency
		/// </summary>
		public uint UnitPrice { get; set;}
		
		/// <summary>
		/// array of unique items that were awarded when this catalog item was purchased
		/// </summary>
		public List<string> BundleContents { get; set;}
		
		
	}
	
	
	
	public class PurchaseItemRequest
	{
		
		
		/// <summary>
		/// unique ItemId of the item to purchase
		/// </summary>
		public string ItemId { get; set;}
		
		/// <summary>
		/// virtual currency to use to purchase the item
		/// </summary>
		public string VirtualCurrency { get; set;}
		
		/// <summary>
		/// price the client expects to pay for the item (in case a new catalog or store was uploaded, with new prices)
		/// </summary>
		public int Price { get; set;}
		
		/// <summary>
		/// catalog version for the items to be purchased (defaults to most recent version
		/// </summary>
		public string CatalogVersion { get; set;}
		
		/// <summary>
		/// store to buy this item through. If not set, prices default to those in the catalog.
		/// </summary>
		public string StoreId { get; set;}
		
		
	}
	
	
	
	public class PurchaseItemResult
	{
		
		
		/// <summary>
		/// details for the items purchased
		/// </summary>
		public List<PurchasedItem> Items { get; set;}
		
		
	}
	
	
	
	public class RedeemCouponRequest
	{
		
		
		/// <summary>
		/// generated coupon code to redeem
		/// </summary>
		public string CouponCode { get; set;}
		
		/// <summary>
		/// catalog version of the coupon
		/// </summary>
		public string CatalogVersion { get; set;}
		
		
	}
	
	
	
	public class RedeemCouponResult
	{
		
		
		/// <summary>
		/// items granted to the player as a result of redeeming the coupon
		/// </summary>
		public List<ItemInstance> GrantedItems { get; set;}
		
		
	}
	
	
	
	public class RefreshPSNAuthTokenRequest
	{
		
		
		/// <summary>
		/// Auth code returned by PSN OAuth system
		/// </summary>
		public string AuthCode { get; set;}
		
		
	}
	
	
	
	public enum Region
	{
		USCentral,
		USEast,
		EUWest,
		Singapore,
		Japan,
		Brazil,
		Australia
	}
	
	
	
	public class RegionInfo
	{
		
		
		/// <summary>
		/// unique identifier for the region
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public Region? Region { get; set;}
		
		/// <summary>
		/// name of the region
		/// </summary>
		public string Name { get; set;}
		
		/// <summary>
		/// indicates whether the server specified is available in this region
		/// </summary>
		public bool Available { get; set;}
		
		/// <summary>
		/// url to ping to get roundtrip time
		/// </summary>
		public string PingUrl { get; set;}
		
		
	}
	
	
	
	public class RegisterForIOSPushNotificationRequest
	{
		
		
		/// <summary>
		/// unique token generated by the Apple Push Notification service when the title registered to receive push notifications
		/// </summary>
		public string DeviceToken { get; set;}
		
		/// <summary>
		/// If true, send a test push message immediately after sucessful registration. Defaults to false.
		/// </summary>
		public bool? SendPushNotificationConfirmation { get; set;}
		
		/// <summary>
		/// Message to display when confirming push notification.
		/// </summary>
		public string ConfirmationMessage { get; set;}
		
		
	}
	
	
	
	public class RegisterForIOSPushNotificationResult
	{
		
		
		
	}
	
	
	
	public class RegisterPlayFabUserRequest
	{
		
		
		public string TitleId { get; set;}
		
		public string Username { get; set;}
		
		public string Email { get; set;}
		
		public string Password { get; set;}
		
		/// <summary>
		/// optional string indicating where this user came from (iOS iPhone, Android, etc.)
		/// </summary>
		public string Origination { get; set;}
		
		
	}
	
	
	
	public class RegisterPlayFabUserResult
	{
		
		
		/// <summary>
		/// PlayFab unique identifier for this newly created account
		/// </summary>
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// a unique token identifying the user and game at the server level, for the current session
		/// </summary>
		public string SessionTicket { get; set;}
		
		/// <summary>
		/// PlayFab unique user name
		/// </summary>
		public string Username { get; set;}
		
		
	}
	
	
	
	public class RemoveFriendRequest
	{
		
		
		/// <summary>
		/// PlayFab identifier of the friend account which is to be removed
		/// </summary>
		public string FriendPlayFabId { get; set;}
		
		
	}
	
	
	
	public class RemoveFriendResult
	{
		
		
		
	}
	
	
	
	public class RemoveSharedGroupMembersRequest
	{
		
		
		/// <summary>
		/// unique identifier for the shared group
		/// </summary>
		public string SharedGroupId { get; set;}
		
		/// <summary>
		/// list of PlayFabId identifiers of users to remove from the shared group
		/// </summary>
		public List<string> PlayFabIds { get; set;}
		
		
	}
	
	
	
	public class RemoveSharedGroupMembersResult
	{
		
		
		
	}
	
	
	
	public class ReportPlayerClientRequest
	{
		
		
		/// <summary>
		/// PlayFabId of the reported player
		/// </summary>
		public string ReporteeId { get; set;}
		
		/// <summary>
		/// title player was reported in, optional if report not for specific title
		/// </summary>
		public string TitleId { get; set;}
		
		/// <summary>
		/// Optional additional comment by reporting player
		/// </summary>
		public string Comment { get; set;}
		
		
	}
	
	
	
	public class ReportPlayerClientResult
	{
		
		
		public bool Updated { get; set;}
		
		public int SubmissionsRemaining { get; set;}
		
		
	}
	
	
	
	public class RestoreIOSPurchasesRequest
	{
		
		
		/// <summary>
		/// base64 encoded receipt data, passed back by the App Store as a result of a successful purchase
		/// </summary>
		public string ReceiptData { get; set;}
		
		
	}
	
	
	
	public class RestoreIOSPurchasesResult
	{
		
		
		
	}
	
	
	
	public class RunCloudScriptRequest
	{
		
		
		/// <summary>
		/// server action to trigger
		/// </summary>
		public string ActionId { get; set;}
		
		/// <summary>
		/// parameters to pass into the action (If you use this, don't use ParamsEncoded)
		/// </summary>
		public object Params { get; set;}
		
		/// <summary>
		/// json-encoded parameters to pass into the action (If you use this, don't use Params)
		/// </summary>
		public string ParamsEncoded { get; set;}
		
		
	}
	
	
	
	public class RunCloudScriptResult
	{
		
		
		/// <summary>
		/// id of Cloud Script run
		/// </summary>
		public string ActionId { get; set;}
		
		/// <summary>
		/// version of Cloud Script run
		/// </summary>
		public int Version { get; set;}
		
		/// <summary>
		/// revision of Cloud Script run
		/// </summary>
		public int Revision { get; set;}
		
		/// <summary>
		/// return values from the server action as a dynamic object
		/// </summary>
		public object Results { get; set;}
		
		/// <summary>
		/// return values from the server action as a json encoded string
		/// </summary>
		public string ResultsEncoded { get; set;}
		
		/// <summary>
		/// any log statements generated during the run of this action
		/// </summary>
		public string ActionLog { get; set;}
		
		/// <summary>
		/// time this script took to run, in seconds
		/// </summary>
		public double ExecutionTime { get; set;}
		
		
	}
	
	
	
	public class SendAccountRecoveryEmailRequest
	{
		
		
		public string Email { get; set;}
		
		public string TitleId { get; set;}
		
		
	}
	
	
	
	public class SendAccountRecoveryEmailResult
	{
		
		
		
	}
	
	
	
	public class SetFriendTagsRequest
	{
		
		
		/// <summary>
		/// PlayFab identifier of the friend account to which the tag(s) should be applied
		/// </summary>
		public string FriendPlayFabId { get; set;}
		
		/// <summary>
		/// array of tags to set on the friend account
		/// </summary>
		public List<string> Tags { get; set;}
		
		
	}
	
	
	
	public class SetFriendTagsResult
	{
		
		
		
	}
	
	
	
	public class SharedGroupDataRecord
	{
		
		
		/// <summary>
		/// data stored for the specified group data key
		/// </summary>
		public string Value { get; set;}
		
		/// <summary>
		/// PlayFabId of the user to last update this value
		/// </summary>
		public string LastUpdatedBy { get; set;}
		
		/// <summary>
		/// timestamp for when this data was last updated
		/// </summary>
		public DateTime LastUpdated { get; set;}
		
		/// <summary>
		/// indicates whether this data can be read by all users (public) or only members of the group (private)
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public UserDataPermission? Permission { get; set;}
		
		
	}
	
	
	
	public class StartGameRequest
	{
		
		
		/// <summary>
		/// version information for the build of the game server which is to be started
		/// </summary>
		public string BuildVersion { get; set;}
		
		/// <summary>
		/// the region to associate this server with for match filtering
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public Region Region { get; set;}
		
		/// <summary>
		/// the title-defined game mode this server is to be running (defaults to 0 if there is only one mode)
		/// </summary>
		public string GameMode { get; set;}
		
		/// <summary>
		/// informs the service that a password is associated with this server
		/// </summary>
		public bool PasswordRestricted { get; set;}
		
		/// <summary>
		/// custom command line argument when starting game server process
		/// </summary>
		public string CustomCommandLineData { get; set;}
		
		
	}
	
	
	
	public class StartGameResult
	{
		
		
		/// <summary>
		/// unique identifier for the lobby of the server started
		/// </summary>
		public string LobbyID { get; set;}
		
		/// <summary>
		/// server IP address
		/// </summary>
		public string ServerHostname { get; set;}
		
		/// <summary>
		/// port on the server to be used for communication
		/// </summary>
		public int? ServerPort { get; set;}
		
		/// <summary>
		/// unique identifier for the server
		/// </summary>
		public string Ticket { get; set;}
		
		/// <summary>
		/// timestamp for when the server should expire, if applicable
		/// </summary>
		public string Expires { get; set;}
		
		/// <summary>
		/// password required to log into the server
		/// </summary>
		public string Password { get; set;}
		
		
	}
	
	
	
	public class StartPurchaseRequest
	{
		
		
		/// <summary>
		/// catalog version for the items to be purchased. Defaults to most recent catalog.
		/// </summary>
		public string CatalogVersion { get; set;}
		
		/// <summary>
		/// store through which to purchase items. If not set, prices will be pulled from the catalog itself.
		/// </summary>
		public string StoreId { get; set;}
		
		/// <summary>
		/// the set of items to purchase
		/// </summary>
		public List<ItemPuchaseRequest> Items { get; set;}
		
		
	}
	
	
	
	public class StartPurchaseResult
	{
		
		
		/// <summary>
		/// purchase order identifier
		/// </summary>
		public string OrderId { get; set;}
		
		/// <summary>
		/// cart items to be purchased
		/// </summary>
		public List<CartItem> Contents { get; set;}
		
		/// <summary>
		/// available methods by which the user can pay
		/// </summary>
		public List<PaymentOption> PaymentOptions { get; set;}
		
		/// <summary>
		/// current virtual currency totals for the user
		/// </summary>
		public Dictionary<string,int> VirtualCurrencyBalances { get; set;}
		
		
	}
	
	
	
	/// <summary>
	/// A store entry that list a catalog item at a particular price
	/// </summary>
	public class StoreItem : IComparable<StoreItem>
	{
		
		
		/// <summary>
		/// unique identifier of the item as it exists in the catalog - note that this must exactly match the ItemId from the catalog
		/// </summary>
		public string ItemId { get; set;}
		
		/// <summary>
		/// catalog version for this item
		/// </summary>
		public string CatalogVersion { get; set;}
		
		/// <summary>
		/// price of this item in virtual currencies and "RM" (the base Real Money purchase price, in USD pennies)
		/// </summary>
		public Dictionary<string,uint> VirtualCurrencyPrices { get; set;}
		
		/// <summary>
		/// override prices for this item for specific currencies
		/// </summary>
		public Dictionary<string,uint> RealCurrencyPrices { get; set;}
		
		
		public int CompareTo(StoreItem other)
        {
            if (other == null || other.ItemId == null) return 1;
            if (ItemId == null) return -1;
            return ItemId.CompareTo(other.ItemId);
        }
		
	}
	
	
	
	public class SubtractUserVirtualCurrencyRequest
	{
		
		
		/// <summary>
		/// name of the virtual currency which is to be decremented
		/// </summary>
		public string VirtualCurrency { get; set;}
		
		/// <summary>
		/// amount to be subtracted from the user balance of the specified virtual currency
		/// </summary>
		public int Amount { get; set;}
		
		
	}
	
	
	
	public enum TitleActivationStatus
	{
		None,
		ActivatedTitleKey,
		PendingSteam,
		ActivatedSteam,
		RevokedSteam
	}
	
	
	
	public class TitleNewsItem
	{
		
		
		/// <summary>
		/// date and time when the news items was posted
		/// </summary>
		public DateTime Timestamp { get; set;}
		
		/// <summary>
		/// unique id of this bit of news
		/// </summary>
		public string NewsId { get; set;}
		
		/// <summary>
		/// title of the news item
		/// </summary>
		public string Title { get; set;}
		
		/// <summary>
		/// news item text
		/// </summary>
		public string Body { get; set;}
		
		
	}
	
	
	
	public enum TransactionStatus
	{
		CreateCart,
		Init,
		Approved,
		Succeeded,
		FailedByProvider,
		RefundPending,
		Refunded,
		RefundFailed,
		ChargedBack,
		FailedByUber,
		Revoked,
		TradePending,
		Upgraded,
		Other,
		Failed
	}
	
	
	
	public class UnlinkAndroidDeviceIDRequest
	{
		
		
		
	}
	
	
	
	public class UnlinkAndroidDeviceIDResult
	{
		
		
		
	}
	
	
	
	public class UnlinkFacebookAccountRequest
	{
		
		
		
	}
	
	
	
	public class UnlinkFacebookAccountResult
	{
		
		
		
	}
	
	
	
	public class UnlinkGameCenterAccountRequest
	{
		
		
		
	}
	
	
	
	public class UnlinkGameCenterAccountResult
	{
		
		
		
	}
	
	
	
	public class UnlinkIOSDeviceIDRequest
	{
		
		
		
	}
	
	
	
	public class UnlinkIOSDeviceIDResult
	{
		
		
		
	}
	
	
	
	public class UnlinkSteamAccountRequest
	{
		
		
		
	}
	
	
	
	public class UnlinkSteamAccountResult
	{
		
		
		
	}
	
	
	
	public class UnlockContainerItemRequest
	{
		
		
		/// <summary>
		/// unique identifier of the container to attempt to unlock
		/// </summary>
		public string ContainerItemId { get; set;}
		
		/// <summary>
		/// catalog version of the container
		/// </summary>
		public string CatalogVersion { get; set;}
		
		
	}
	
	
	
	public class UnlockContainerItemResult
	{
		
		
		/// <summary>
		/// unique instance identifier of the container unlocked
		/// </summary>
		public string UnlockedItemInstanceId { get; set;}
		
		/// <summary>
		/// unique instance identifier of the key used to unlock the container, if applicable
		/// </summary>
		public string UnlockedWithItemInstanceId { get; set;}
		
		/// <summary>
		/// items granted to the player as a result of unlocking the container
		/// </summary>
		public List<ItemInstance> GrantedItems { get; set;}
		
		/// <summary>
		/// virtual currency granted to the player as a result of unlocking the container
		/// </summary>
		public Dictionary<string,uint> VirtualCurrency { get; set;}
		
		
	}
	
	
	
	public class UpdateEmailAddressRequest
	{
		
		
		public string Email { get; set;}
		
		
	}
	
	
	
	public class UpdateEmailAddressResult
	{
		
		
		
	}
	
	
	
	public class UpdatePasswordRequest
	{
		
		
		public string Password { get; set;}
		
		
	}
	
	
	
	public class UpdatePasswordResult
	{
		
		
		
	}
	
	
	
	public class UpdateSharedGroupDataRequest
	{
		
		
		/// <summary>
		/// unique identifier for the shared group
		/// </summary>
		public string SharedGroupId { get; set;}
		
		/// <summary>
		/// key value pairs to be stored in the shared group - note that keys will be trimmed of whitespace, must not begin with a '!' character, and that null values will result in the removal of the key from the data set
		/// </summary>
		public Dictionary<string,string> Data { get; set;}
		
		/// <summary>
		/// permission to be applied to all user data keys in this request
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public UserDataPermission? Permission { get; set;}
		
		
	}
	
	
	
	public class UpdateSharedGroupDataResult
	{
		
		
		
	}
	
	
	
	public class UpdateUserDataRequest
	{
		
		
		/// <summary>
		/// data to be written to the user's custom data. A key with a null value will be removed, rather than being set to null.
		/// </summary>
		public Dictionary<string,string> Data { get; set;}
		
		/// <summary>
		/// Permission to be applied to all user data keys written in this request. Defaults to "private" if not set.
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public UserDataPermission? Permission { get; set;}
		
		
	}
	
	
	
	public class UpdateUserDataResult
	{
		
		
		
	}
	
	
	
	public class UpdateUserStatisticsRequest
	{
		
		
		/// <summary>
		/// statistics to be updated with the provided values
		/// </summary>
		public Dictionary<string,int> UserStatistics { get; set;}
		
		
	}
	
	
	
	public class UpdateUserStatisticsResult
	{
		
		
		
	}
	
	
	
	public class UpdateUserTitleDisplayNameRequest
	{
		
		
		/// <summary>
		/// new title display name for the user - must be between 3 and 25 characters
		/// </summary>
		public string DisplayName { get; set;}
		
		
	}
	
	
	
	public class UpdateUserTitleDisplayNameResult
	{
		
		
		/// <summary>
		/// current title display name for the user (this will be the original display name if the rename attempt failed)
		/// </summary>
		public string DisplayName { get; set;}
		
		
	}
	
	
	
	public class UserAccountInfo
	{
		
		
		/// <summary>
		/// unique identifier for the user account
		/// </summary>
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// timestamp indicating when the user account was created
		/// </summary>
		public DateTime Created { get; set;}
		
		/// <summary>
		/// user account name in the PlayFab service
		/// </summary>
		public string Username { get; set;}
		
		/// <summary>
		/// title-specific information for the user account
		/// </summary>
		public UserTitleInfo TitleInfo { get; set;}
		
		/// <summary>
		/// personal information for the user which is considered more sensitive
		/// </summary>
		public UserPrivateAccountInfo PrivateInfo { get; set;}
		
		/// <summary>
		/// user Facebook information, if a Facebook account has been linked
		/// </summary>
		public UserFacebookInfo FacebookInfo { get; set;}
		
		/// <summary>
		/// user Steam information, if a Steam account has been linked
		/// </summary>
		public UserSteamInfo SteamInfo { get; set;}
		
		/// <summary>
		/// user Gamecenter information, if a Gamecenter account has been linked
		/// </summary>
		public UserGameCenterInfo GameCenterInfo { get; set;}
		
		
	}
	
	
	
	public enum UserDataPermission
	{
		Private,
		Public
	}
	
	
	
	public class UserDataRecord
	{
		
		
		/// <summary>
		/// data stored for the specified user data key
		/// </summary>
		public string Value { get; set;}
		
		/// <summary>
		/// timestamp for when this data was last updated
		/// </summary>
		public DateTime LastUpdated { get; set;}
		
		/// <summary>
		/// indicates whether this data can be read by all users (public) or only the user (private)
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public UserDataPermission? Permission { get; set;}
		
		
	}
	
	
	
	public class UserFacebookInfo
	{
		
		
		/// <summary>
		/// Facebook identifier
		/// </summary>
		public string FacebookId { get; set;}
		
		/// <summary>
		/// Facebook username
		/// </summary>
		public string FacebookUsername { get; set;}
		
		/// <summary>
		/// Facebook display name
		/// </summary>
		public string FacebookDisplayname { get; set;}
		
		
	}
	
	
	
	public class UserGameCenterInfo
	{
		
		
		/// <summary>
		/// Gamecenter identifier
		/// </summary>
		public string GameCenterId { get; set;}
		
		
	}
	
	
	
	public enum UserOrigination
	{
		Organic,
		Steam,
		Google,
		Amazon,
		Facebook,
		Kongregate,
		GamersFirst,
		Unknown,
		IOS,
		LoadTest,
		Android,
		PSN,
		GameCenter
	}
	
	
	
	public class UserPrivateAccountInfo
	{
		
		
		/// <summary>
		/// user email address
		/// </summary>
		public string Email { get; set;}
		
		
	}
	
	
	
	public class UserSteamInfo
	{
		
		
		/// <summary>
		/// Steam identifier
		/// </summary>
		public string SteamId { get; set;}
		
		/// <summary>
		/// the country in which the player resides, from Steam data
		/// </summary>
		public string SteamCountry { get; set;}
		
		/// <summary>
		/// currency type set in the user Steam account
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public Currency? SteamCurrency { get; set;}
		
		/// <summary>
		/// what stage of game ownership the user is listed as being in, from Steam
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public TitleActivationStatus? SteamActivationStatus { get; set;}
		
		
	}
	
	
	
	public class UserTitleInfo
	{
		
		
		/// <summary>
		/// name of the user, as it is displayed in-game
		/// </summary>
		public string DisplayName { get; set;}
		
		/// <summary>
		/// source by which the user first joined the game, if known
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public UserOrigination? Origination { get; set;}
		
		/// <summary>
		/// timestamp indicating when the user was first associated with this game (this can differ significantly from when the user first registered with PlayFab)
		/// </summary>
		public DateTime Created { get; set;}
		
		/// <summary>
		/// timestamp for the last user login for this title
		/// </summary>
		public DateTime? LastLogin { get; set;}
		
		/// <summary>
		/// timestamp indicating when the user first signed into this game (this can differ from the Created timestamp, as other events, such as issuing a beta key to the user, can associate the title to the user)
		/// </summary>
		public DateTime? FirstLogin { get; set;}
		
		/// <summary>
		/// boolean indicating whether or not the user is currently banned for a title
		/// </summary>
		public bool? isBanned { get; set;}
		
		
	}
	
	
	
	public class ValidateGooglePlayPurchaseRequest
	{
		
		
		/// <summary>
		/// The original json string returned by the Google Play IAB api
		/// </summary>
		public string ReceiptJson { get; set;}
		
		/// <summary>
		/// The signature returned by the Google Play IAB api
		/// </summary>
		public string Signature { get; set;}
		
		
	}
	
	
	
	public class ValidateGooglePlayPurchaseResult
	{
		
		
		
	}
	
	
	
	public class ValidateIOSReceiptRequest
	{
		
		
		/// <summary>
		/// base64 encoded receipt data, passed back by the App Store as a result of a successful purchase
		/// </summary>
		public string ReceiptData { get; set;}
		
		/// <summary>
		/// currency used for the purchase
		/// </summary>
		public string CurrencyCode { get; set;}
		
		/// <summary>
		/// amount of the stated currency paid for the object
		/// </summary>
		public int PurchasePrice { get; set;}
		
		
	}
	
	
	
	public class ValidateIOSReceiptResult
	{
		
		
		
	}
	
}
