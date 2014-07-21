using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PlayFab.ServerModels
{
	
	
	
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
	
	
	
	public class AwardSteamAchievementItem
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user who is to be granted the specified Steam achievement
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// unique Steam achievement name
		/// </summary>
		
		public string AchievementName { get; set;}
		
		/// <summary>
		/// result of the award attempt (only valid on response, not on request)
		/// </summary>
		
		public bool Result { get; set;}
		
	}
	
	
	
	public class AwardSteamAchievementRequest
	{
		
		
		/// <summary>
		/// array of achievements to grant and the users to whom they are to be granted
		/// </summary>
		
		public List<AwardSteamAchievementItem> Achievements { get; set;}
		
	}
	
	
	
	public class AwardSteamAchievementResult
	{
		
		
		/// <summary>
		/// array of achievements granted
		/// </summary>
		
		public List<AwardSteamAchievementItem> AchievementResults { get; set;}
		
	}
	
	
	
	public class CatalogItem
	{
		
		
		/// <summary>
		/// internal item name
		/// </summary>
		
		public string ItemId { get; set;}
		
		/// <summary>
		/// class name to which item belongs
		/// </summary>
		
		public string ItemClass { get; set;}
		
		/// <summary>
		/// catalog item we are working against
		/// </summary>
		
		public string CatalogVersion { get; set;}
		
		/// <summary>
		/// displayable item name
		/// </summary>
		
		public string DisplayName { get; set;}
		
		/// <summary>
		/// text description of item
		/// </summary>
		
		public string Description { get; set;}
		
		/// <summary>
		/// Price of this object in virtual currencies
		/// </summary>
		
		public Dictionary<string,uint> VirtualCurrencyPrices { get; set;}
		
		/// <summary>
		/// Price of this object in real money currencies
		/// </summary>
		
		public Dictionary<string,uint> RealCurrencyPrices { get; set;}
		
		/// <summary>
		/// if this object was dropped, when it was dropped (optional)
		/// </summary>
		
		public DateTime? ReleaseDate { get; set;}
		
		/// <summary>
		/// date this object will no longer be viable (optional)
		/// </summary>
		
		public DateTime? ExpirationDate { get; set;}
		
		/// <summary>
		/// is this a free object?
		/// </summary>
		
		public bool? IsFree { get; set;}
		
		/// <summary>
		/// can we buy this object (might be only gettable by being dropped by a monster)
		/// </summary>
		
		public bool? NotForSale { get; set;}
		
		/// <summary>
		/// can we pass this object to someone else?
		/// </summary>
		
		public bool? NotForTrade { get; set;}
		
		/// <summary>
		/// List of item tags
		/// </summary>
		
		public List<string> Tags { get; set;}
		
		/// <summary>
		/// Game specific custom data field (could be json, xml, etc)
		/// </summary>
		
		public string CustomData { get; set;}
		
		/// <summary>
		/// array of unique item Id's that, if the player already has, will automatically place this item in a players inventory
		/// </summary>
		
		public List<string> GrantedIfPlayerHas { get; set;}
		
		/// <summary>
		/// If set, makes this item consumable and sets consumable properties
		/// </summary>
		
		public CatalogItemConsumableInfo Consumable { get; set;}
		
		/// <summary>
		/// If set, makes this item a container and sets container properties
		/// </summary>
		
		public CatalogItemContainerInfo Container { get; set;}
		
		/// <summary>
		/// If set, makes this item a bundle and sets bundle properties
		/// </summary>
		
		public CatalogItemBundleInfo Bundle { get; set;}
		
	}
	
	
	
	public class CatalogItemBundleInfo
	{
		
		
		/// <summary>
		/// array of Unique item id's that this item will grant you once you have this item in your inventory
		/// </summary>
		
		public List<string> BundledItems { get; set;}
		
		/// <summary>
		/// array of result table id's that this item will reference and randomly create items from
		/// </summary>
		
		public List<string> BundledResultTables { get; set;}
		
		/// <summary>
		/// Virtual currencies contained in this item
		/// </summary>
		
		public Dictionary<string,uint> BundledVirtualCurrencies { get; set;}
		
	}
	
	
	
	public class CatalogItemConsumableInfo
	{
		
		
		/// <summary>
		/// number of times this object can be used
		/// </summary>
		
		public uint UsageCount { get; set;}
		
		/// <summary>
		/// duration of how long this item is viable after player aqquires it (in seconds) (optional)
		/// </summary>
		
		public uint? UsagePeriod { get; set;}
		
		/// <summary>
		/// All items that have the same value in this string get their expiration dates added together.
		/// </summary>
		
		public string UsagePeriodGroup { get; set;}
		
	}
	
	
	
	public class CatalogItemContainerInfo
	{
		
		
		/// <summary>
		/// unique item id that, if in posession, the object unlocks and provides the player with content items
		/// </summary>
		
		public string KeyItemId { get; set;}
		
		/// <summary>
		/// array of Unique item id's that this item will grant you once you have opened it
		/// </summary>
		
		public List<string> ItemContents { get; set;}
		
		/// <summary>
		/// array of result table id's that this item will reference and randomly create items from
		/// </summary>
		
		public List<string> ResultTableContents { get; set;}
		
		/// <summary>
		/// Virtual currencies contained in this item
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
		
		public List<CatalogItem> Catalog { get; set;}
		
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
	
	
	
	public class GetUserAccountInfoRequest
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user whose information is being requested
		/// </summary>
		
		public string PlayFabId { get; set;}
		
	}
	
	
	
	public class GetUserAccountInfoResult
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user whose information was requested
		/// </summary>
		
		public UserAccountInfo UserInfo { get; set;}
		
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
		
		public Dictionary<string,string> Data { get; set;}
		
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
		
		public List<ItemInstance> Inventory { get; set;}
		
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
	
	
	
	public class ItemGrantResult
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
		
		/// <summary>
		/// result of this operation
		/// </summary>
		
		public bool Result { get; set;}
		
	}
	
	
	
	public class ItemInstance
	{
		
		
		/// <summary>
		/// Object name
		/// </summary>
		
		public string ItemId { get; set;}
		
		/// <summary>
		/// unique item id
		/// </summary>
		
		public string ItemInstanceId { get; set;}
		
		/// <summary>
		/// class name object belongs to
		/// </summary>
		
		public string ItemClass { get; set;}
		
		/// <summary>
		/// date purchased
		/// </summary>
		
		public string PurchaseDate { get; set;}
		
		/// <summary>
		/// date object will expire (optional)
		/// </summary>
		
		public string Expiration { get; set;}
		
		/// <summary>
		/// number of remaining uses (optional)
		/// </summary>
		
		public uint? RemainingUses { get; set;}
		
		/// <summary>
		/// game specific comment
		/// </summary>
		
		public string Annotation { get; set;}
		
		/// <summary>
		/// catalog version that this item is part of
		/// </summary>
		
		public string CatalogVersion { get; set;}
		
		/// <summary>
		/// Unique ID of the parent of where this item may have come from (e.g. if it comes from a crate or coupon)
		/// </summary>
		
		public string BundleParent { get; set;}
		
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
	
	
	
	public class NotifyMatchmakerPlayerLeftRequest
	{
		
		
		/// <summary>
		/// unique identifier of the Game Server Instance the user is leaving
		/// </summary>
		
		public string ServerId { get; set;}
		
		/// <summary>
		/// PlayFab unique identifier of the user that is leaving the Game Server Instance
		/// </summary>
		
		public string PlayFabId { get; set;}
		
	}
	
	
	
	public class NotifyMatchmakerPlayerLeftResult
	{
		
		
		/// <summary>
		/// state of user leaving the Game Server Instance
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public PlayerConnectionState? PlayerState { get; set;}
		
	}
	
	
	
	public enum PlayerConnectionState
	{
		Unassigned,
		Connecting,
		Participating,
		Participated,
		Reconnecting
	}
	
	
	
	public class RedeemMatchmakerTicketRequest
	{
		
		
		/// <summary>
		/// server authorization ticket passed back from a call to Matchmake or StartGame
		/// </summary>
		
		public string Ticket { get; set;}
		
		/// <summary>
		/// IP Address of the Game Server Instance that is asking for validation of the authorization ticket
		/// </summary>
		
		public string IP { get; set;}
		
		/// <summary>
		/// unique identifier of the Game Server Instance that is asking for validation of the authorization ticket
		/// </summary>
		
		public string ServerId { get; set;}
		
	}
	
	
	
	public class RedeemMatchmakerTicketResult
	{
		
		
		/// <summary>
		/// boolean indicating whether the ticket was validated by the PlayFab service
		/// </summary>
		
		public bool TicketIsValid { get; set;}
		
		/// <summary>
		/// error value if the ticket was not validated
		/// </summary>
		
		public string Error { get; set;}
		
		/// <summary>
		/// user account information for the user validated
		/// </summary>
		
		public UserAccountInfo UserInfo { get; set;}
		
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
		
		
		/// <summary>
		/// key that was set
		/// </summary>
		
		public string Key { get; set;}
		
		/// <summary>
		/// new value set for key
		/// </summary>
		
		public string Value { get; set;}
		
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
		
	}
	
	
	
	public class UpdateUserDataResult
	{
		
		
	}
	
	
	
	public class UserAccountInfo
	{
		
		
		/// <summary>
		/// unique id for account
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// time / date account was created
		/// </summary>
		
		public DateTime? Created { get; set;}
		
		/// <summary>
		/// account name
		/// </summary>
		
		public string Username { get; set;}
		
		/// <summary>
		/// specific game title information
		/// </summary>
		
		public UserTitleInfo TitleInfo { get; set;}
		
		/// <summary>
		/// user's private account into
		/// </summary>
		
		public UserPrivateAccountInfo PrivateInfo { get; set;}
		
		/// <summary>
		/// facebook information (if linked)
		/// </summary>
		
		public UserFacebookInfo FacebookInfo { get; set;}
		
		/// <summary>
		/// steam information (if linked)
		/// </summary>
		
		public UserSteamInfo SteamInfo { get; set;}
		
		/// <summary>
		/// gamecenter information (if linked)
		/// </summary>
		
		public UserGameCenterInfo GameCenterInfo { get; set;}
		
	}
	
	
	
	public class UserFacebookInfo
	{
		
		
		/// <summary>
		/// facebook id
		/// </summary>
		
		public string FacebookId { get; set;}
		
		/// <summary>
		/// facebook username
		/// </summary>
		
		public string FacebookUsername { get; set;}
		
		/// <summary>
		/// facebook display name
		/// </summary>
		
		public string FacebookDisplayname { get; set;}
		
	}
	
	
	
	public class UserGameCenterInfo
	{
		
		
		/// <summary>
		/// gamecenter id if account is linked
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
		/// Email address
		/// </summary>
		
		public string Email { get; set;}
		
	}
	
	
	
	public class UserSteamInfo
	{
		
		
		/// <summary>
		/// steam id
		/// </summary>
		
		public string SteamId { get; set;}
		
		/// <summary>
		/// if account is linked to steam, this is the country that steam reports the player being in
		/// </summary>
		
		public string SteamCountry { get; set;}
		
		/// <summary>
		/// Currency set in the user's steam account
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public Currency? SteamCurrency { get; set;}
		
		/// <summary>
		/// STEAM specific - what stage of game ownership is the user at with Steam
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public TitleActivationStatus? SteamActivationStatus { get; set;}
		
	}
	
	
	
	public class UserTitleInfo
	{
		
		
		/// <summary>
		/// displayable game name
		/// </summary>
		
		public string DisplayName { get; set;}
		
		/// <summary>
		/// optional value that details where the user originated
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public UserOrigination? Origination { get; set;}
		
		/// <summary>
		/// When this object was created. Title specific reporting for user creation time should be done against this rather than the User created field since account creation can differ significantly between title registration.
		/// </summary>
		
		public DateTime? Created { get; set;}
		
		/// <summary>
		/// Last time the user logged in to this title
		/// </summary>
		
		public DateTime? LastLogin { get; set;}
		
		/// <summary>
		///  Time the user first logged in. This can be different from when the UTD was created. For example we create a UTD when issuing a beta key. An arbitrary amount of time can pass before the user actually logs in.
		/// </summary>
		
		public DateTime? FirstLogin { get; set;}
		
	}
	
}
