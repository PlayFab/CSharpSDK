using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PlayFab.AdminModels
{
	
	
	
	public class AddNewsRequest
	{
		
		
		/// <summary>
		/// Time this news was published. If not set, defaults to now.
		/// </summary>
		public DateTime? Timestamp { get; set;}
		
		/// <summary>
		/// Title (headline) of the news item
		/// </summary>
		public string Title { get; set;}
		
		/// <summary>
		/// Body text of the news
		/// </summary>
		public string Body { get; set;}
		
		
	}
	
	
	
	public class AddNewsResult
	{
		
		
		/// <summary>
		/// Unique id of the new news item
		/// </summary>
		public string NewsId { get; set;}
		
		
	}
	
	
	
	public class AddServerBuildRequest
	{
		
		
		/// <summary>
		/// unique identifier for the build executable
		/// </summary>
		public string BuildId { get; set;}
		
		/// <summary>
		/// date and time to apply (stamp) to this build (usually current time/date)
		/// </summary>
		public DateTime? Timestamp { get; set;}
		
		/// <summary>
		/// is this build currently allowed to be used
		/// </summary>
		public bool Active { get; set;}
		
		/// <summary>
		/// is this build intended to run on dedicated ("bare metal") servers
		/// </summary>
		public bool DedicatedServerEligible { get; set;}
		
		/// <summary>
		/// Server host regions in which this build can be used
		/// </summary>
		public List<string> ActiveRegions { get; set;}
		
		/// <summary>
		/// developer comment(s) for this build
		/// </summary>
		public string Comment { get; set;}
		
		
	}
	
	
	
	public class AddServerBuildResult
	{
		
		
		/// <summary>
		/// unique identifier for this build executable
		/// </summary>
		public string BuildId { get; set;}
		
		/// <summary>
		/// is this build currently allowed to be used
		/// </summary>
		public bool Active { get; set;}
		
		/// <summary>
		/// array of regions where this build can used, when it is active
		/// </summary>
		public List<string> ActiveRegions { get; set;}
		
		/// <summary>
		/// developer comment(s) for this build
		/// </summary>
		public string Comment { get; set;}
		
		/// <summary>
		/// time this build was last modified (or uploaded, if this build has never been modified)
		/// </summary>
		public DateTime Timestamp { get; set;}
		
		/// <summary>
		/// the unique identifier for the title, found in the URL on the PlayFab developer site as "TitleId=[n]" when a title has been selected
		/// </summary>
		public string TitleId { get; set;}
		
		
	}
	
	
	
	public class AddUserVirtualCurrencyRequest
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user whose virtual currency balance is to be incremented
		/// </summary>
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// name of the virtual currency which is to be incremented
		/// </summary>
		public string VirtualCurrency { get; set;}
		
		/// <summary>
		/// amount to be added to the user balance of the specified virtual currency
		/// </summary>
		public int Amount { get; set;}
		
		
	}
	
	
	
	public class AddVirtualCurrencyTypesRequest
	{
		
		
		/// <summary>
		/// List of virtual currency names to add as valid virtual currencies for this title
		/// </summary>
		public List<string> VirtualCurrencyIds { get; set;}
		
		
	}
	
	
	
	public class BlankResult
	{
		
		
		
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
		/// the date this item becomes available for purchase
		/// </summary>
		public DateTime? ReleaseDate { get; set;}
		
		/// <summary>
		/// the date this item will no longer be available for purchase
		/// </summary>
		public DateTime? ExpirationDate { get; set;}
		
		/// <summary>
		/// (deprecated)
		/// </summary>
		public bool? IsFree { get; set;}
		
		/// <summary>
		/// can this item be purchased (if not, it can still be granted by a server-based operation, such as a loot drop from a monster)
		/// </summary>
		public bool? NotForSale { get; set;}
		
		/// <summary>
		/// can an instance of this item be exchanged between players?
		/// </summary>
		public bool? NotForTrade { get; set;}
		
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
		/// defines the container properties for the item - containers are items which include contain other items, including random drop tables and virtual currencies, and which require a "key" item to open
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
		public uint UsageCount { get; set;}
		
		/// <summary>
		/// duration in seconds for how long the item will remain in the player inventory - once elapsed, the item will be removed
		/// </summary>
		public uint? UsagePeriod { get; set;}
		
		/// <summary>
		/// all inventory item instances in the player inventory sharing a non-null UsagePeriodGroup have their UsagePeriod values added together, and share the result - when that period has elapsed, all the items in the group will be removed
		/// </summary>
		public string UsagePeriodGroup { get; set;}
		
		
	}
	
	
	
	public class CatalogItemContainerInfo
	{
		
		
		/// <summary>
		/// unique ItemId which is required to unlock the container (items in the container will not be added to the player inventory until it is unlocked)
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
	
	
	
	public class GameModeInfo
	{
		
		
		/// <summary>
		/// specific game mode type
		/// </summary>
		public string Gamemode { get; set;}
		
		/// <summary>
		/// minimum user count required for this Game Server Instance to continue (usually 1)
		/// </summary>
		public uint MinPlayerCount { get; set;}
		
		/// <summary>
		/// maximum user count a specific Game Server Instance can support
		/// </summary>
		public uint MaxPlayerCount { get; set;}
		
		/// <summary>
		/// performance cost of a Game Server Instance on a given server TODO what are the values expected?
		/// </summary>
		public float PerfCostPerGame { get; set;}
		
		
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
		/// array of items which can be purchased
		/// </summary>
		[Unordered(SortProperty="ItemId")]
		public List<CatalogItem> Catalog { get; set;}
		
		
	}
	
	
	
	public class GetMatchmakerGameInfoRequest
	{
		
		
		/// <summary>
		/// unique identifier of the lobby for which info is being requested
		/// </summary>
		public string LobbyId { get; set;}
		
		
	}
	
	
	
	public class GetMatchmakerGameInfoResult
	{
		
		
		/// <summary>
		/// unique identifier of the lobby 
		/// </summary>
		public string LobbyId { get; set;}
		
		/// <summary>
		/// unique identifier of the Game Server Instance for this lobby
		/// </summary>
		public string TitleId { get; set;}
		
		/// <summary>
		/// time when the Game Server Instance was created
		/// </summary>
		public DateTime StartTime { get; set;}
		
		/// <summary>
		/// time when Game Server Instance is currently scheduled to end
		/// </summary>
		public DateTime? EndTime { get; set;}
		
		/// <summary>
		/// game mode for this Game Server Instance
		/// </summary>
		public string Mode { get; set;}
		
		/// <summary>
		/// version identifier of the game server executable binary being run
		/// </summary>
		public string BuildVersion { get; set;}
		
		/// <summary>
		/// region in which the Game Server Instance is running
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public Region? Region { get; set;}
		
		/// <summary>
		/// array of unique PlayFab identifiers for users currently connected to this Game Server Instance
		/// </summary>
		[Unordered]
		public List<string> Players { get; set;}
		
		/// <summary>
		/// IP address for this Game Server Instance
		/// </summary>
		public string ServerAddress { get; set;}
		
		/// <summary>
		/// communication port for this Game Server Instance
		/// </summary>
		public uint ServerPort { get; set;}
		
		/// <summary>
		/// output log from this Game Server Instance
		/// </summary>
		public string StdOutLog { get; set;}
		
		/// <summary>
		/// error log from this Game Server Instance
		/// </summary>
		public string StdErrLog { get; set;}
		
		
	}
	
	
	
	public class GetMatchmakerGameModesRequest
	{
		
		
		/// <summary>
		/// previously uploaded build version for which game modes are being requested
		/// </summary>
		public string BuildVersion { get; set;}
		
		
	}
	
	
	
	public class GetMatchmakerGameModesResult
	{
		
		
		/// <summary>
		/// array of game modes available for the specified build
		/// </summary>
		public List<GameModeInfo> GameModes { get; set;}
		
		
	}
	
	
	
	public class GetRandomResultTablesRequest
	{
		
		
		
	}
	
	
	
	public class GetRandomResultTablesResult
	{
		
		
		/// <summary>
		/// array of random result tables currently available
		/// </summary>
		public Dictionary<string,RandomResultTable> Tables { get; set;}
		
		
	}
	
	
	
	public class GetServerBuildInfoRequest
	{
		
		
		/// <summary>
		/// unique identifier of the previously uploaded build executable for which information is being requested
		/// </summary>
		public string BuildId { get; set;}
		
		
	}
	
	
	
	/// <summary>
	/// Information about particular server build
	/// </summary>
	public class GetServerBuildInfoResult : IComparable<GetServerBuildInfoResult>
	{
		
		
		/// <summary>
		/// unique identifier for this build executable
		/// </summary>
		public string BuildId { get; set;}
		
		/// <summary>
		/// is this build currently allowed to be used
		/// </summary>
		public bool Active { get; set;}
		
		/// <summary>
		/// array of regions where this build can used, when it is active
		/// </summary>
		[Unordered]
		public List<string> ActiveRegions { get; set;}
		
		/// <summary>
		/// developer comment(s) for this build
		/// </summary>
		public string Comment { get; set;}
		
		/// <summary>
		/// time this build was last modified (or uploaded, if this build has never been modified)
		/// </summary>
		public DateTime Timestamp { get; set;}
		
		/// <summary>
		/// the unique identifier for the title, found in the URL on the PlayFab developer site as "TitleId=[n]" when a title has been selected
		/// </summary>
		public string TitleId { get; set;}
		
		
		public int CompareTo(GetServerBuildInfoResult other)
        {
            if (other == null || other.BuildId == null) return 1;
            if (BuildId == null) return -1;
            return BuildId.CompareTo(other.BuildId);
        }
		
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
	
	
	
	public class GetUserDataRequest
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user whose custom data is being requested
		/// </summary>
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// specific keys to search for in the custom user data
		/// </summary>
		public List<string> Keys { get; set;}
		
		
	}
	
	
	
	public class GetUserDataResult
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user whose custom data is being returned
		/// </summary>
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// user specific data for this title
		/// </summary>
		public Dictionary<string,UserDataRecord> Data { get; set;}
		
		
	}
	
	
	
	public class GetUserInventoryRequest
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user whose inventory is being requested
		/// </summary>
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// used to limit results to only those from a specific catalog version
		/// </summary>
		public string CatalogVersion { get; set;}
		
		
	}
	
	
	
	public class GetUserInventoryResult
	{
		
		
		/// <summary>
		/// array of inventory items belonging to the user
		/// </summary>
		[Unordered(SortProperty="ItemInstanceId")]
		public List<ItemInstance> Inventory { get; set;}
		
		/// <summary>
		/// array of virtual currency balance(s) belonging to the user
		/// </summary>
		public Dictionary<string,int> VirtualCurrency { get; set;}
		
		
	}
	
	
	
	public class GrantItemsToUsersRequest
	{
		
		
		/// <summary>
		/// catalog version from which items are to be granted
		/// </summary>
		public string CatalogVersion { get; set;}
		
		/// <summary>
		/// array of items to grant and the users to whom the items are to be granted
		/// </summary>
		[Unordered]
		public List<ItemGrant> ItemGrants { get; set;}
		
		
	}
	
	
	
	public class GrantItemsToUsersResult
	{
		
		
		/// <summary>
		/// array of items granted to users
		/// </summary>
		public List<ItemGrantResult> ItemGrantResults { get; set;}
		
		
	}
	
	
	
	public class ItemGrant
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user to whom the catalog item is to be granted
		/// </summary>
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// unique identifier of the catalog item to be granted to the user
		/// </summary>
		public string ItemId { get; set;}
		
		/// <summary>
		/// string detailing any additional information concerning this operation
		/// </summary>
		public string Annotation { get; set;}
		
		
	}
	
	
	
	/// <summary>
	/// Result of granting an item to a user
	/// </summary>
	public class ItemGrantResult : IComparable<ItemGrantResult>
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user to whom the catalog item is to be granted
		/// </summary>
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// unique identifier of the catalog item to be granted to the user
		/// </summary>
		public string ItemId { get; set;}
		
		/// <summary>
		/// unique instance Id of the granted item
		/// </summary>
		public string ItemInstanceId { get; set;}
		
		/// <summary>
		/// string detailing any additional information concerning this operation
		/// </summary>
		public string Annotation { get; set;}
		
		/// <summary>
		/// result of this operation
		/// </summary>
		public bool Result { get; set;}
		
		
		public int CompareTo(ItemGrantResult other)
        {
            if (other == null || other.ItemInstanceId == null) return 1;
            if (ItemInstanceId == null) return -1;
            return ItemInstanceId.CompareTo(other.ItemInstanceId);
        }
		
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
		public string PurchaseDate { get; set;}
		
		/// <summary>
		/// timestamp for when this instance will expire
		/// </summary>
		public string Expiration { get; set;}
		
		/// <summary>
		/// total number of remaining uses, if this is a consumable item
		/// </summary>
		public uint? RemainingUses { get; set;}
		
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
	
	
	
	public class ListBuildsRequest
	{
		
		
		
	}
	
	
	
	public class ListBuildsResult
	{
		
		
		/// <summary>
		/// array of uploaded builds
		/// </summary>
		[Unordered(SortProperty="BuildId")]
		public List<GetServerBuildInfoResult> Builds { get; set;}
		
		
	}
	
	
	
	public class ListVirtualCurrencyTypesRequest
	{
		
		
		
	}
	
	
	
	public class ListVirtualCurrencyTypesResult
	{
		
		
		/// <summary>
		/// List of virtual currency names defined for this title
		/// </summary>
		[Unordered]
		public List<string> VirtualCurrencyIds { get; set;}
		
		
	}
	
	
	
	public class LookupUserAccountInfoRequest
	{
		
		
		/// <summary>
		/// PlayFab unique identifier to match against existing user accounts
		/// </summary>
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// email address to match against existing user accounts
		/// </summary>
		public string Email { get; set;}
		
		/// <summary>
		/// PlayFab username to match against existing user accounts
		/// </summary>
		public string Username { get; set;}
		
		/// <summary>
		/// title-specific username to match against existing user accounts
		/// </summary>
		public string TitleDisplayName { get; set;}
		
		
	}
	
	
	
	public class LookupUserAccountInfoResult
	{
		
		
		/// <summary>
		/// user info for the user matching the request
		/// </summary>
		public UserAccountInfo UserInfo { get; set;}
		
		
	}
	
	
	
	public class ModifyMatchmakerGameModesRequest
	{
		
		
		/// <summary>
		/// previously uploaded build version for which game modes are being specified
		/// </summary>
		public string BuildVersion { get; set;}
		
		/// <summary>
		/// array of game modes (Note: this will replace all game modes for the indicated build version)
		/// </summary>
		public List<GameModeInfo> GameModes { get; set;}
		
		
	}
	
	
	
	public class ModifyMatchmakerGameModesResult
	{
		
		
		
	}
	
	
	
	public class ModifyServerBuildRequest
	{
		
		
		/// <summary>
		/// unique identifier of the previously uploaded build executable to be updated
		/// </summary>
		public string BuildId { get; set;}
		
		/// <summary>
		/// new timestamp
		/// </summary>
		public DateTime? Timestamp { get; set;}
		
		/// <summary>
		/// is this build currently allowed to be used
		/// </summary>
		public bool? Active { get; set;}
		
		/// <summary>
		/// array of regions where this build can used, when it is active
		/// </summary>
		public List<string> ActiveRegions { get; set;}
		
		/// <summary>
		/// developer comment(s) for this build
		/// </summary>
		public string Comment { get; set;}
		
		
	}
	
	
	
	public class ModifyServerBuildResult
	{
		
		
		/// <summary>
		/// unique identifier for this build executable
		/// </summary>
		public string BuildId { get; set;}
		
		/// <summary>
		/// is this build currently allowed to be used
		/// </summary>
		public bool Active { get; set;}
		
		/// <summary>
		/// array of regions where this build can used, when it is active
		/// </summary>
		public List<string> ActiveRegions { get; set;}
		
		/// <summary>
		/// developer comment(s) for this build
		/// </summary>
		public string Comment { get; set;}
		
		/// <summary>
		/// time this build was last modified (or uploaded, if this build has never been modified)
		/// </summary>
		public DateTime Timestamp { get; set;}
		
		/// <summary>
		/// the unique identifier for the title, found in the URL on the PlayFab developer site as "TitleId=[n]" when a title has been selected
		/// </summary>
		public string TitleId { get; set;}
		
		
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
	
	
	
	public class RandomResultTable
	{
		
		
		/// <summary>
		/// Unique name for this drop table
		/// </summary>
		public string TableId { get; set;}
		
		/// <summary>
		/// Child nodes that indicate what kind of drop table item this actually is.
		/// </summary>
		public List<ResultTableNode> Nodes { get; set;}
		
		
	}
	
	
	
	public enum Region
	{
		USWest,
		USCentral,
		USEast,
		EUWest,
		APSouthEast,
		APNorthEast,
		SAEast,
		Australia,
		China,
		UberLan
	}
	
	
	
	public class RemoveServerBuildRequest
	{
		
		
		/// <summary>
		/// unique identifier of the previously uploaded build executable to be removed
		/// </summary>
		public string BuildId { get; set;}
		
		
	}
	
	
	
	public class RemoveServerBuildResult
	{
		
		
		/// <summary>
		/// unique identifier of the previously uploaded build executable to be removed
		/// </summary>
		public string BuildId { get; set;}
		
		
	}
	
	
	
	public class RemoveTitleDataRequest
	{
		
		
		/// <summary>
		/// key we want to remove
		/// </summary>
		public string Key { get; set;}
		
		
	}
	
	
	
	public class RemoveTitleDataResult
	{
		
		
		
	}
	
	
	
	public class ResetUserStatisticsRequest
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user whose statistics are to be reset
		/// </summary>
		public string PlayFabId { get; set;}
		
		
	}
	
	
	
	public class ResetUserStatisticsResult
	{
		
		
		
	}
	
	
	
	public class ResultTableNode
	{
		
		
		/// <summary>
		/// Whether this entry in the table is an item or a link to another table
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public ResultTableNodeType ResultItemType { get; set;}
		
		/// <summary>
		/// Either an ItemId, or the TableId of another random result table
		/// </summary>
		public string ResultItem { get; set;}
		
		/// <summary>
		/// How likely this is to be rolled - larger numbers add more weight
		/// </summary>
		public int Weight { get; set;}
		
		
	}
	
	
	
	public enum ResultTableNodeType
	{
		ItemId,
		TableId
	}
	
	
	
	public class RevokeInventoryItemRequest
	{
		
		
		/// <summary>
		/// unique PlayFab identifier for the user account which is to have the specified item removed
		/// </summary>
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// unique PlayFab identifier for the item instance to be removed
		/// </summary>
		public string ItemInstanceId { get; set;}
		
		
	}
	
	
	
	public class RevokeInventoryResult
	{
		
		
		
	}
	
	
	
	public class SendAccountRecoveryEmailRequest
	{
		
		
		/// <summary>
		/// email address to match against existing user accounts
		/// </summary>
		public string Email { get; set;}
		
		
	}
	
	
	
	public class SendAccountRecoveryEmailResult
	{
		
		
		
	}
	
	
	
	public class SetTitleDataRequest
	{
		
		
		/// <summary>
		/// key we want to set a value on (note, this is additive - will only replace an existing key's value if they are the same name
		/// </summary>
		public string Key { get; set;}
		
		/// <summary>
		/// new value to set
		/// </summary>
		public string Value { get; set;}
		
		
	}
	
	
	
	public class SetTitleDataResult
	{
		
		
		
	}
	
	
	
	public class SubtractUserVirtualCurrencyRequest
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user whose virtual currency balance is to be decremented
		/// </summary>
		public string PlayFabId { get; set;}
		
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
	
	
	
	public class UpdateCatalogItemsRequest
	{
		
		
		/// <summary>
		/// which catalog is being updated
		/// </summary>
		public string CatalogVersion { get; set;}
		
		/// <summary>
		/// array of catalog items to be submitted
		/// </summary>
		public List<CatalogItem> CatalogItems { get; set;}
		
		
	}
	
	
	
	public class UpdateCatalogItemsResult
	{
		
		
		
	}
	
	
	
	public class UpdateRandomResultTablesRequest
	{
		
		
		/// <summary>
		/// array of random result tables to make available (Note: specifying an existing TableId will result in overwriting that table, while any others will be added to the available set)
		/// </summary>
		public List<RandomResultTable> Tables { get; set;}
		
		
	}
	
	
	
	public class UpdateRandomResultTablesResult
	{
		
		
		
	}
	
	
	
	public class UpdateUserDataRequest
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user whose custom data is being updated
		/// </summary>
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// data to be written to the user's custom data
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
	
	
	
	public class UpdateUserTitleDisplayNameRequest
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user whose title specific display name is to be changed
		/// </summary>
		public string PlayFabId { get; set;}
		
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
		/// user-supplied data for this user data key
		/// </summary>
		public string Value { get; set;}
		
		/// <summary>
		/// timestamp indicating when this data was last updated
		/// </summary>
		public DateTime LastUpdated { get; set;}
		
		/// <summary>
		/// Permissions on this data key
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
		Android
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
		/// name of the game, as it is displayed in-game
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
		
		
	}
	
}
