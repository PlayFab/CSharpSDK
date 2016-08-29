using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PlayFab.Internal;
using System;
using System.Collections.Generic;

namespace PlayFab.ServerModels
{
    public class AdCampaignAttribution
    {
        /// <summary>
        /// Attribution network name
        /// </summary>
        public string Platform;

        /// <summary>
        /// Attribution campaign identifier
        /// </summary>
        public string CampaignId;

        /// <summary>
        /// UTC time stamp of attribution
        /// </summary>
        public DateTime AttributedAt;

    }

    public class AddCharacterVirtualCurrencyRequest
    {
        /// <summary>
        /// PlayFab unique identifier of the user whose virtual currency balance is to be incremented.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;

        /// <summary>
        /// Name of the virtual currency which is to be incremented.
        /// </summary>
        public string VirtualCurrency;

        /// <summary>
        /// Amount to be added to the character balance of the specified virtual currency. Maximum VC balance is Int32 (2,147,483,647). Any increase over this value will be discarded.
        /// </summary>
        public int Amount;

    }

    public class AddPlayerTagRequest
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Unique tag for player profile.
        /// </summary>
        public string TagName;

    }

    public class AddPlayerTagResult : PlayFabResultCommon
    {
    }

    public class AddSharedGroupMembersRequest
    {
        /// <summary>
        /// Unique identifier for the shared group.
        /// </summary>
        public string SharedGroupId;

        /// <summary>
        /// An array of unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public List<string> PlayFabIds;

    }

    public class AddSharedGroupMembersResult : PlayFabResultCommon
    {
    }

    public class AddUserVirtualCurrencyRequest
    {
        /// <summary>
        /// PlayFab unique identifier of the user whose virtual currency balance is to be increased.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Name of the virtual currency which is to be incremented.
        /// </summary>
        public string VirtualCurrency;

        /// <summary>
        /// Amount to be added to the user balance of the specified virtual currency. Maximum VC balance is Int32 (2,147,483,647). Any increase over this value will be discarded.
        /// </summary>
        public int Amount;

    }

    public class AuthenticateSessionTicketRequest
    {
        /// <summary>
        /// Session ticket as issued by a PlayFab client login API.
        /// </summary>
        public string SessionTicket;

    }

    public class AuthenticateSessionTicketResult : PlayFabResultCommon
    {
        /// <summary>
        /// Account info for the user whose session ticket was supplied.
        /// </summary>
        public UserAccountInfo UserInfo;

    }

    public class AwardSteamAchievementItem
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Unique Steam achievement name.
        /// </summary>
        public string AchievementName;

        /// <summary>
        /// Result of the award attempt (only valid on response, not on request).
        /// </summary>
        public bool Result;

    }

    public class AwardSteamAchievementRequest
    {
        /// <summary>
        /// Array of achievements to grant and the users to whom they are to be granted.
        /// </summary>
        public List<AwardSteamAchievementItem> Achievements;

    }

    public class AwardSteamAchievementResult : PlayFabResultCommon
    {
        /// <summary>
        /// Array of achievements granted.
        /// </summary>
        public List<AwardSteamAchievementItem> AchievementResults;

    }

    /// <summary>
    /// Contains information for a ban.
    /// </summary>
    public class BanInfo
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// The unique Ban Id associated with this ban.
        /// </summary>
        public string BanId;

        /// <summary>
        /// The IP address on which the ban was applied. May affect multiple players.
        /// </summary>
        public string IPAddress;

        /// <summary>
        /// The MAC address on which the ban was applied. May affect multiple players.
        /// </summary>
        public string MACAddress;

        /// <summary>
        /// The time when this ban was applied.
        /// </summary>
        public DateTime? Created;

        /// <summary>
        /// The time when this ban expires. Permanent bans do not have expiration date.
        /// </summary>
        public DateTime? Expires;

        /// <summary>
        /// The reason why this ban was applied.
        /// </summary>
        public string Reason;

        /// <summary>
        /// The active state of this ban. Expired bans may still have this value set to true but they will have no effect.
        /// </summary>
        public bool Active;

    }

    /// <summary>
    /// Represents a single ban request.
    /// </summary>
    public class BanRequest
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// IP address to be banned. May affect multiple players.
        /// </summary>
        public string IPAddress;

        /// <summary>
        /// MAC address to be banned. May affect multiple players.
        /// </summary>
        public string MACAddress;

        /// <summary>
        /// The reason for this ban. Maximum 140 characters.
        /// </summary>
        public string Reason;

        /// <summary>
        /// The duration in hours for the ban. Leave this blank for a permanent ban.
        /// </summary>
        public uint? DurationInHours;

    }

    public class BanUsersRequest
    {
        /// <summary>
        /// List of ban requests to be applied. Maximum 100.
        /// </summary>
        public List<BanRequest> Bans;

    }

    public class BanUsersResult : PlayFabResultCommon
    {
        /// <summary>
        /// Information on the bans that were applied
        /// </summary>
        public List<BanInfo> BanData;

    }

    /// <summary>
    /// A purchasable item from the item catalog
    /// </summary>
    public class CatalogItem : IComparable<CatalogItem>
    {
        /// <summary>
        /// unique identifier for this item
        /// </summary>
        public string ItemId;

        /// <summary>
        /// class to which the item belongs
        /// </summary>
        public string ItemClass;

        /// <summary>
        /// catalog version for this item
        /// </summary>
        public string CatalogVersion;

        /// <summary>
        /// text name for the item, to show in-game
        /// </summary>
        public string DisplayName;

        /// <summary>
        /// text description of item, to show in-game
        /// </summary>
        public string Description;

        /// <summary>
        /// price of this item in virtual currencies and "RM" (the base Real Money purchase price, in USD pennies)
        /// </summary>
        public Dictionary<string,uint> VirtualCurrencyPrices;

        /// <summary>
        /// override prices for this item for specific currencies
        /// </summary>
        public Dictionary<string,uint> RealCurrencyPrices;

        /// <summary>
        /// list of item tags
        /// </summary>
        [Unordered]
        public List<string> Tags;

        /// <summary>
        /// game specific custom data
        /// </summary>
        public string CustomData;

        /// <summary>
        /// defines the consumable properties (number of uses, timeout) for the item
        /// </summary>
        public CatalogItemConsumableInfo Consumable;

        /// <summary>
        /// defines the container properties for the item - what items it contains, including random drop tables and virtual currencies, and what item (if any) is required to open it via the UnlockContainerItem API
        /// </summary>
        public CatalogItemContainerInfo Container;

        /// <summary>
        /// defines the bundle properties for the item - bundles are items which contain other items, including random drop tables and virtual currencies
        /// </summary>
        public CatalogItemBundleInfo Bundle;

        /// <summary>
        /// if true, then an item instance of this type can be used to grant a character to a user.
        /// </summary>
        public bool CanBecomeCharacter;

        /// <summary>
        /// if true, then only one item instance of this type will exist and its remaininguses will be incremented instead. RemainingUses will cap out at Int32.Max (2,147,483,647). All subsequent increases will be discarded
        /// </summary>
        public bool IsStackable;

        /// <summary>
        /// if true, then an item instance of this type can be traded between players using the trading APIs
        /// </summary>
        public bool IsTradable;

        /// <summary>
        /// URL to the item image. For Facebook purchase to display the image on the item purchase page, this must be set to an HTTP URL.
        /// </summary>
        public string ItemImageUrl;

        /// <summary>
        /// if true, then only a fixed number can ever be granted.
        /// </summary>
        public bool IsLimitedEdition;

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
        public List<string> BundledItems;

        /// <summary>
        /// unique TableId values for all RandomResultTable objects which are part of the bundle (random tables will be resolved and add the relevant items to the player inventory when the bundle is added)
        /// </summary>
        [Unordered]
        public List<string> BundledResultTables;

        /// <summary>
        /// virtual currency types and balances which will be added to the player inventory when the bundle is added
        /// </summary>
        public Dictionary<string,uint> BundledVirtualCurrencies;

    }

    public class CatalogItemConsumableInfo
    {
        /// <summary>
        /// number of times this object can be used, after which it will be removed from the player inventory
        /// </summary>
        public uint? UsageCount;

        /// <summary>
        /// duration in seconds for how long the item will remain in the player inventory - once elapsed, the item will be removed
        /// </summary>
        public uint? UsagePeriod;

        /// <summary>
        /// all inventory item instances in the player inventory sharing a non-null UsagePeriodGroup have their UsagePeriod values added together, and share the result - when that period has elapsed, all the items in the group will be removed
        /// </summary>
        public string UsagePeriodGroup;

    }

    /// <summary>
    /// Containers are inventory items that can hold other items defined in the catalog, as well as virtual currency, which is added to the player inventory when the container is unlocked, using the UnlockContainerItem API. The items can be anything defined in the catalog, as well as RandomResultTable objects which will be resolved when the container is unlocked. Containers and their keys should be defined as Consumable (having a limited number of uses) in their catalog defintiions, unless the intent is for the player to be able to re-use them infinitely.
    /// </summary>
    public class CatalogItemContainerInfo
    {
        /// <summary>
        /// ItemId for the catalog item used to unlock the container, if any (if not specified, a call to UnlockContainerItem will open the container, adding the contents to the player inventory and currency balances)
        /// </summary>
        public string KeyItemId;

        /// <summary>
        /// unique ItemId values for all items which will be added to the player inventory, once the container has been unlocked
        /// </summary>
        [Unordered]
        public List<string> ItemContents;

        /// <summary>
        /// unique TableId values for all RandomResultTable objects which are part of the container (once unlocked, random tables will be resolved and add the relevant items to the player inventory)
        /// </summary>
        [Unordered]
        public List<string> ResultTableContents;

        /// <summary>
        /// virtual currency types and balances which will be added to the player inventory when the container is unlocked
        /// </summary>
        public Dictionary<string,uint> VirtualCurrencyContents;

    }

    public class CharacterInventory
    {
        /// <summary>
        /// The id of this character.
        /// </summary>
        public string CharacterId;

        /// <summary>
        /// The inventory of this character.
        /// </summary>
        public List<ItemInstance> Inventory;

    }

    public class CharacterLeaderboardEntry
    {
        /// <summary>
        /// PlayFab unique identifier of the user for this leaderboard entry.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// PlayFab unique identifier of the character that belongs to the user for this leaderboard entry.
        /// </summary>
        public string CharacterId;

        /// <summary>
        /// Title-specific display name of the character for this leaderboard entry.
        /// </summary>
        public string CharacterName;

        /// <summary>
        /// Title-specific display name of the user for this leaderboard entry.
        /// </summary>
        public string DisplayName;

        /// <summary>
        /// Name of the character class for this entry.
        /// </summary>
        public string CharacterType;

        /// <summary>
        /// Specific value of the user's statistic.
        /// </summary>
        public int StatValue;

        /// <summary>
        /// User's overall position in the leaderboard.
        /// </summary>
        public int Position;

    }

    public class CharacterResult : PlayFabResultCommon
    {
        /// <summary>
        /// The id for this character on this player.
        /// </summary>
        public string CharacterId;

        /// <summary>
        /// The name of this character.
        /// </summary>
        public string CharacterName;

        /// <summary>
        /// The type-string that was given to this character on creation.
        /// </summary>
        public string CharacterType;

    }

    
    public enum CloudScriptRevisionOption
    {
        Live,
        Latest,
        Specific
    }

    public class ConsumeItemRequest
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Unique instance identifier of the item to be consumed.
        /// </summary>
        public string ItemInstanceId;

        /// <summary>
        /// Number of uses to consume from the item.
        /// </summary>
        public int ConsumeCount;

        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;

    }

    public class ConsumeItemResult : PlayFabResultCommon
    {
        /// <summary>
        /// Unique instance identifier of the item with uses consumed.
        /// </summary>
        public string ItemInstanceId;

        /// <summary>
        /// Number of uses remaining on the item.
        /// </summary>
        public int RemainingUses;

    }

    public class CreateSharedGroupRequest
    {
        /// <summary>
        /// Unique identifier for the shared group (a random identifier will be assigned, if one is not specified).
        /// </summary>
        public string SharedGroupId;

    }

    public class CreateSharedGroupResult : PlayFabResultCommon
    {
        /// <summary>
        /// Unique identifier for the shared group.
        /// </summary>
        public string SharedGroupId;

    }

    
    public enum Currency
    {
        AED,
        AFN,
        ALL,
        AMD,
        ANG,
        AOA,
        ARS,
        AUD,
        AWG,
        AZN,
        BAM,
        BBD,
        BDT,
        BGN,
        BHD,
        BIF,
        BMD,
        BND,
        BOB,
        BRL,
        BSD,
        BTN,
        BWP,
        BYR,
        BZD,
        CAD,
        CDF,
        CHF,
        CLP,
        CNY,
        COP,
        CRC,
        CUC,
        CUP,
        CVE,
        CZK,
        DJF,
        DKK,
        DOP,
        DZD,
        EGP,
        ERN,
        ETB,
        EUR,
        FJD,
        FKP,
        GBP,
        GEL,
        GGP,
        GHS,
        GIP,
        GMD,
        GNF,
        GTQ,
        GYD,
        HKD,
        HNL,
        HRK,
        HTG,
        HUF,
        IDR,
        ILS,
        IMP,
        INR,
        IQD,
        IRR,
        ISK,
        JEP,
        JMD,
        JOD,
        JPY,
        KES,
        KGS,
        KHR,
        KMF,
        KPW,
        KRW,
        KWD,
        KYD,
        KZT,
        LAK,
        LBP,
        LKR,
        LRD,
        LSL,
        LYD,
        MAD,
        MDL,
        MGA,
        MKD,
        MMK,
        MNT,
        MOP,
        MRO,
        MUR,
        MVR,
        MWK,
        MXN,
        MYR,
        MZN,
        NAD,
        NGN,
        NIO,
        NOK,
        NPR,
        NZD,
        OMR,
        PAB,
        PEN,
        PGK,
        PHP,
        PKR,
        PLN,
        PYG,
        QAR,
        RON,
        RSD,
        RUB,
        RWF,
        SAR,
        SBD,
        SCR,
        SDG,
        SEK,
        SGD,
        SHP,
        SLL,
        SOS,
        SPL,
        SRD,
        STD,
        SVC,
        SYP,
        SZL,
        THB,
        TJS,
        TMT,
        TND,
        TOP,
        TRY,
        TTD,
        TVD,
        TWD,
        TZS,
        UAH,
        UGX,
        USD,
        UYU,
        UZS,
        VEF,
        VND,
        VUV,
        WST,
        XAF,
        XCD,
        XDR,
        XOF,
        XPF,
        YER,
        ZAR,
        ZMW,
        ZWD
    }

    public class DeleteCharacterFromUserRequest
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;

        /// <summary>
        /// If true, the character's inventory will be transferred up to the owning user; otherwise, this request will purge those items.
        /// </summary>
        public bool SaveCharacterInventory;

    }

    public class DeleteCharacterFromUserResult : PlayFabResultCommon
    {
    }

    public class DeleteSharedGroupRequest
    {
        /// <summary>
        /// Unique identifier for the shared group.
        /// </summary>
        public string SharedGroupId;

    }

    public class DeleteUsersRequest
    {
        /// <summary>
        /// An array of unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public List<string> PlayFabIds;

        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected.
        /// </summary>
        public string TitleId;

    }

    public class DeleteUsersResult : PlayFabResultCommon
    {
    }

    public class EmptyResult : PlayFabResultCommon
    {
    }

    public class EvaluateRandomResultTableRequest : PlayFabResultCommon
    {
        /// <summary>
        /// The unique identifier of the Random Result Table to use.
        /// </summary>
        public string TableId;

        /// <summary>
        /// Specifies the catalog version that should be used to evaluate the Random Result Table.  If unspecified, uses default/primary catalog.
        /// </summary>
        public string CatalogVersion;

    }

    public class EvaluateRandomResultTableResult : PlayFabResultCommon
    {
        /// <summary>
        /// Unique identifier for the item returned from the Random Result Table evaluation, for the given catalog.
        /// </summary>
        public string ResultItemId;

    }

    public class ExecuteCloudScriptResult : PlayFabResultCommon
    {
        /// <summary>
        /// The name of the function that executed
        /// </summary>
        public string FunctionName;

        /// <summary>
        /// The revision of the CloudScript that executed
        /// </summary>
        public int Revision;

        /// <summary>
        /// The object returned from the CloudScript function, if any
        /// </summary>
        public object FunctionResult;

        /// <summary>
        /// Entries logged during the function execution. These include both entries logged in the function code using log.info() and log.error() and error entries for API and HTTP request failures.
        /// </summary>
        public List<LogStatement> Logs;

        public double ExecutionTimeSeconds;

        public uint MemoryConsumedBytes;

        /// <summary>
        /// Number of PlayFab API requests issued by the CloudScript function
        /// </summary>
        public int APIRequestsIssued;

        /// <summary>
        /// Number of external HTTP requests issued by the CloudScript function
        /// </summary>
        public int HttpRequestsIssued;

        /// <summary>
        /// Information about the error, if any, that occured during execution
        /// </summary>
        public ScriptExecutionError Error;

    }

    public class ExecuteCloudScriptServerRequest
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// The name of the CloudScript function to execute
        /// </summary>
        public string FunctionName;

        /// <summary>
        /// Object that is passed in to the function as the first argument
        /// </summary>
        public object FunctionParameter;

        /// <summary>
        /// Option for which revision of the CloudScript to execute. 'Latest' executes the most recently created revision, 'Live' executes the current live, published revision, and 'Specific' executes the specified revision. The default value is 'Specific', if the SpeificRevision parameter is specified, otherwise it is 'Live'.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CloudScriptRevisionOption? RevisionSelection;

        /// <summary>
        /// The specivic revision to execute, when RevisionSelection is set to 'Specific'
        /// </summary>
        public int? SpecificRevision;

        /// <summary>
        /// Generate a 'player_executed_cloudscript' PlayStream event containing the results of the function execution and other contextual information. This event will show up in the PlayStream debugger console for the player in Game Manager.
        /// </summary>
        public bool? GeneratePlayStreamEvent;

    }

    public class FacebookPlayFabIdPair
    {
        /// <summary>
        /// Unique Facebook identifier for a user.
        /// </summary>
        public string FacebookId;

        /// <summary>
        /// Unique PlayFab identifier for a user, or null if no PlayFab account is linked to the Facebook identifier.
        /// </summary>
        public string PlayFabId;

    }

    public class FriendInfo
    {
        /// <summary>
        /// PlayFab unique identifier for this friend.
        /// </summary>
        public string FriendPlayFabId;

        /// <summary>
        /// PlayFab unique username for this friend.
        /// </summary>
        public string Username;

        /// <summary>
        /// Title-specific display name for this friend.
        /// </summary>
        public string TitleDisplayName;

        /// <summary>
        /// Tags which have been associated with this friend.
        /// </summary>
        public List<string> Tags;

        /// <summary>
        /// Unique lobby identifier of the Game Server Instance to which this player is currently connected.
        /// </summary>
        public string CurrentMatchmakerLobbyId;

        /// <summary>
        /// Available Facebook information (if the user and PlayFab friend are also connected in Facebook).
        /// </summary>
        public UserFacebookInfo FacebookInfo;

        /// <summary>
        /// Available Steam information (if the user and PlayFab friend are also connected in Steam).
        /// </summary>
        public UserSteamInfo SteamInfo;

        /// <summary>
        /// Available Game Center information (if the user and PlayFab friend are also connected in Game Center).
        /// </summary>
        public UserGameCenterInfo GameCenterInfo;

    }

    
    public enum GameInstanceState
    {
        Open,
        Closed
    }

    public class GetAllSegmentsRequest
    {
    }

    public class GetAllSegmentsResult : PlayFabResultCommon
    {
        /// <summary>
        /// Array of segments for this title.
        /// </summary>
        public List<GetSegmentResult> Segments;

    }

    public class GetCatalogItemsRequest
    {
        /// <summary>
        /// Which catalog is being requested. If null, uses the default catalog.
        /// </summary>
        public string CatalogVersion;

    }

    public class GetCatalogItemsResult : PlayFabResultCommon
    {
        /// <summary>
        /// Array of items which can be purchased.
        /// </summary>
        [Unordered(SortProperty="ItemId")]
        public List<CatalogItem> Catalog;

    }

    public class GetCharacterDataRequest
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;

        /// <summary>
        /// Specific keys to search for in the custom user data.
        /// </summary>
        public List<string> Keys;

        /// <summary>
        /// The version that currently exists according to the caller. The call will return the data for all of the keys if the version in the system is greater than this.
        /// </summary>
        public uint? IfChangedFromDataVersion;

    }

    public class GetCharacterDataResult : PlayFabResultCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Indicates the current version of the data that has been set. This is incremented with every set call for that type of data (read-only, internal, etc). This version can be provided in Get calls to find updated data.
        /// </summary>
        public uint DataVersion;

        /// <summary>
        /// User specific data for this title.
        /// </summary>
        public Dictionary<string,UserDataRecord> Data;

        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;

    }

    public class GetCharacterInventoryRequest
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;

        /// <summary>
        /// Used to limit results to only those from a specific catalog version.
        /// </summary>
        public string CatalogVersion;

    }

    public class GetCharacterInventoryResult : PlayFabResultCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Unique identifier of the character for this inventory.
        /// </summary>
        public string CharacterId;

        /// <summary>
        /// Array of inventory items belonging to the character.
        /// </summary>
        [Unordered(SortProperty="ItemInstanceId")]
        public List<ItemInstance> Inventory;

        /// <summary>
        /// Array of virtual currency balance(s) belonging to the character.
        /// </summary>
        public Dictionary<string,int> VirtualCurrency;

        /// <summary>
        /// Array of remaining times and timestamps for virtual currencies.
        /// </summary>
        public Dictionary<string,VirtualCurrencyRechargeTime> VirtualCurrencyRechargeTimes;

    }

    public class GetCharacterLeaderboardRequest
    {
        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;

        /// <summary>
        /// Optional character type on which to filter the leaderboard entries.
        /// </summary>
        public string CharacterType;

        /// <summary>
        /// Unique identifier for the title-specific statistic for the leaderboard.
        /// </summary>
        public string StatisticName;

        /// <summary>
        /// First entry in the leaderboard to be retrieved.
        /// </summary>
        public int StartPosition;

        /// <summary>
        /// Maximum number of entries to retrieve.
        /// </summary>
        public int MaxResultsCount;

    }

    public class GetCharacterLeaderboardResult : PlayFabResultCommon
    {
        /// <summary>
        /// Ordered list of leaderboard entries.
        /// </summary>
        public List<CharacterLeaderboardEntry> Leaderboard;

    }

    public class GetCharacterStatisticsRequest
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;

    }

    public class GetCharacterStatisticsResult : PlayFabResultCommon
    {
        /// <summary>
        /// PlayFab unique identifier of the user whose character statistics are being returned.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Unique identifier of the character for the statistics.
        /// </summary>
        public string CharacterId;

        /// <summary>
        /// Character statistics for the requested user.
        /// </summary>
        public Dictionary<string,int> CharacterStatistics;

    }

    public class GetContentDownloadUrlRequest
    {
        /// <summary>
        /// Key of the content item to fetch, usually formatted as a path, e.g. images/a.png
        /// </summary>
        public string Key;

        /// <summary>
        /// HTTP method to fetch item - GET or HEAD. Use HEAD when only fetching metadata. Default is GET.
        /// </summary>
        public string HttpMethod;

        /// <summary>
        /// True if download through CDN. CDN provides better download bandwidth and time. However, if you want latest, non-cached version of the content, set this to false. Default is true.
        /// </summary>
        public bool? ThruCDN;

    }

    public class GetContentDownloadUrlResult : PlayFabResultCommon
    {
        /// <summary>
        /// URL for downloading content via HTTP GET or HEAD method. The URL will expire in 1 hour.
        /// </summary>
        public string URL;

    }

    public class GetLeaderboardAroundCharacterRequest
    {
        /// <summary>
        /// Unique identifier for the title-specific statistic for the leaderboard.
        /// </summary>
        public string StatisticName;

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;

        /// <summary>
        /// Optional character type on which to filter the leaderboard entries.
        /// </summary>
        public string CharacterType;

        /// <summary>
        /// Maximum number of entries to retrieve.
        /// </summary>
        public int MaxResultsCount;

    }

    public class GetLeaderboardAroundCharacterResult : PlayFabResultCommon
    {
        /// <summary>
        /// Ordered list of leaderboard entries.
        /// </summary>
        public List<CharacterLeaderboardEntry> Leaderboard;

    }

    public class GetLeaderboardAroundUserRequest
    {
        /// <summary>
        /// Unique identifier for the title-specific statistic for the leaderboard.
        /// </summary>
        public string StatisticName;

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Maximum number of entries to retrieve.
        /// </summary>
        public int MaxResultsCount;

    }

    public class GetLeaderboardAroundUserResult : PlayFabResultCommon
    {
        /// <summary>
        /// Ordered list of leaderboard entries.
        /// </summary>
        public List<PlayerLeaderboardEntry> Leaderboard;

    }

    public class GetLeaderboardForUsersCharactersRequest
    {
        /// <summary>
        /// Unique identifier for the title-specific statistic for the leaderboard.
        /// </summary>
        public string StatisticName;

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Maximum number of entries to retrieve.
        /// </summary>
        public int MaxResultsCount;

    }

    public class GetLeaderboardForUsersCharactersResult : PlayFabResultCommon
    {
        /// <summary>
        /// Ordered list of leaderboard entries.
        /// </summary>
        public List<CharacterLeaderboardEntry> Leaderboard;

    }

    public class GetLeaderboardRequest
    {
        /// <summary>
        /// Unique identifier for the title-specific statistic for the leaderboard.
        /// </summary>
        public string StatisticName;

        /// <summary>
        /// First entry in the leaderboard to be retrieved.
        /// </summary>
        public int StartPosition;

        /// <summary>
        /// Maximum number of entries to retrieve.
        /// </summary>
        public int MaxResultsCount;

    }

    public class GetLeaderboardResult : PlayFabResultCommon
    {
        /// <summary>
        /// Ordered list of leaderboard entries.
        /// </summary>
        public List<PlayerLeaderboardEntry> Leaderboard;

    }

    public class GetPlayerCombinedInfoRequest
    {
        /// <summary>
        /// PlayFabId of the user whose data will be returned
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Flags for which pieces of info to return for the user.
        /// </summary>
        public GetPlayerCombinedInfoRequestParams InfoRequestParameters;

    }

    public class GetPlayerCombinedInfoRequestParams
    {
        /// <summary>
        /// Whether to get the player's account Info. Defaults to false
        /// </summary>
        public bool GetUserAccountInfo;

        /// <summary>
        /// Whether to get the player's inventory. Defaults to false
        /// </summary>
        public bool GetUserInventory;

        /// <summary>
        /// Whether to get the player's virtual currency balances. Defaults to false
        /// </summary>
        public bool GetUserVirtualCurrency;

        /// <summary>
        /// Whether to get the player's custom data. Defaults to false
        /// </summary>
        public bool GetUserData;

        /// <summary>
        /// Specific keys to search for in the custom data. Leave null to get all keys. Has no effect if UserDataKeys is false
        /// </summary>
        public List<string> UserDataKeys;

        /// <summary>
        /// Whether to get the player's read only data. Defaults to false
        /// </summary>
        public bool GetUserReadOnlyData;

        /// <summary>
        /// Specific keys to search for in the custom data. Leave null to get all keys. Has no effect if GetUserReadOnlyData is false
        /// </summary>
        public List<string> UserReadOnlyDataKeys;

        /// <summary>
        /// Whether to get character inventories. Defaults to false.
        /// </summary>
        public bool GetCharacterInventories;

        /// <summary>
        /// Whether to get the list of characters. Defaults to false.
        /// </summary>
        public bool GetCharacterList;

        /// <summary>
        /// Whether to get title data. Defaults to false.
        /// </summary>
        public bool GetTitleData;

        /// <summary>
        /// Specific keys to search for in the custom data. Leave null to get all keys. Has no effect if GetTitleData is false
        /// </summary>
        public List<string> TitleDataKeys;

        /// <summary>
        /// Whether to get player statistics. Defaults to false.
        /// </summary>
        public bool GetPlayerStatistics;

        /// <summary>
        /// Specific statistics to retrieve. Leave null to get all keys. Has no effect if GetPlayerStatistics is false
        /// </summary>
        public List<string> PlayerStatisticNames;

    }

    public class GetPlayerCombinedInfoResult : PlayFabResultCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Results for requested info.
        /// </summary>
        public GetPlayerCombinedInfoResultPayload InfoResultPayload;

    }

    public class GetPlayerCombinedInfoResultPayload : PlayFabResultCommon
    {
        /// <summary>
        /// Account information for the user. This is always retrieved.
        /// </summary>
        public UserAccountInfo AccountInfo;

        /// <summary>
        /// Array of inventory items in the user's current inventory.
        /// </summary>
        [Unordered(SortProperty="ItemInstanceId")]
        public List<ItemInstance> UserInventory;

        /// <summary>
        /// Dictionary of virtual currency balance(s) belonging to the user.
        /// </summary>
        public Dictionary<string,int> UserVirtualCurrency;

        /// <summary>
        /// Dictionary of remaining times and timestamps for virtual currencies.
        /// </summary>
        public Dictionary<string,VirtualCurrencyRechargeTime> UserVirtualCurrencyRechargeTimes;

        /// <summary>
        /// User specific custom data.
        /// </summary>
        public Dictionary<string,UserDataRecord> UserData;

        /// <summary>
        /// The version of the UserData that was returned.
        /// </summary>
        public uint UserDataVersion;

        /// <summary>
        /// User specific read-only data.
        /// </summary>
        public Dictionary<string,UserDataRecord> UserReadOnlyData;

        /// <summary>
        /// The version of the Read-Only UserData that was returned.
        /// </summary>
        public uint UserReadOnlyDataVersion;

        /// <summary>
        /// List of characters for the user.
        /// </summary>
        public List<CharacterResult> CharacterList;

        /// <summary>
        /// Inventories for each character for the user.
        /// </summary>
        public List<CharacterInventory> CharacterInventories;

        /// <summary>
        /// Title data for this title.
        /// </summary>
        public Dictionary<string,string> TitleData;

        /// <summary>
        /// List of statistics for this player.
        /// </summary>
        public List<StatisticValue> PlayerStatistics;

    }

    public class GetPlayerSegmentsResult : PlayFabResultCommon
    {
        /// <summary>
        /// Array of segments the requested player currently belongs to.
        /// </summary>
        public List<GetSegmentResult> Segments;

    }

    public class GetPlayersInSegmentRequest
    {
        /// <summary>
        /// Unique identifier for this segment.
        /// </summary>
        public string SegmentId;

        /// <summary>
        /// Number of seconds to keep the continuation token active. After token expiration it is not possible to continue paging results. Default is 300 (5 minutes). Maximum is 1,800 (30 minutes).
        /// </summary>
        public uint? SecondsToLive;

        /// <summary>
        /// Maximum number of profiles to load. Default is 1,000. Maximum is 10,000.
        /// </summary>
        public uint? MaxBatchSize;

        /// <summary>
        /// Continuation token if retrieving subsequent pages of results.
        /// </summary>
        public string ContinuationToken;

    }

    public class GetPlayersInSegmentResult : PlayFabResultCommon
    {
        /// <summary>
        /// Count of profiles matching this segment.
        /// </summary>
        public int ProfilesInSegment;

        /// <summary>
        /// Continuation token to use to retrieve subsequent pages of results. If token returns null there are no more results.
        /// </summary>
        public string ContinuationToken;

        /// <summary>
        /// Array of player profiles in this segment.
        /// </summary>
        public List<PlayerProfile> PlayerProfiles;

    }

    public class GetPlayersSegmentsRequest
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

    }

    public class GetPlayerStatisticsRequest
    {
        /// <summary>
        /// user for whom statistics are being requested
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// statistics to return
        /// </summary>
        public List<string> StatisticNames;

        /// <summary>
        /// statistics to return, if StatisticNames is not set (only statistics which have a version matching that provided will be returned)
        /// </summary>
        public List<StatisticNameVersion> StatisticNameVersions;

    }

    public class GetPlayerStatisticsResult : PlayFabResultCommon
    {
        /// <summary>
        /// PlayFab unique identifier of the user whose statistics are being returned
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// User statistics for the requested user.
        /// </summary>
        public List<StatisticValue> Statistics;

    }

    public class GetPlayerStatisticVersionsRequest
    {
        /// <summary>
        /// unique name of the statistic
        /// </summary>
        public string StatisticName;

    }

    public class GetPlayerStatisticVersionsResult : PlayFabResultCommon
    {
        /// <summary>
        /// version change history of the statistic
        /// </summary>
        public List<PlayerStatisticVersion> StatisticVersions;

    }

    public class GetPlayerTagsRequest
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Optional namespace to filter results by
        /// </summary>
        public string Namespace;

    }

    public class GetPlayerTagsResult : PlayFabResultCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Canonical tags (including namespace and tag's name) for the requested user
        /// </summary>
        public List<string> Tags;

    }

    public class GetPlayFabIDsFromFacebookIDsRequest
    {
        /// <summary>
        /// Array of unique Facebook identifiers for which the title needs to get PlayFab identifiers.
        /// </summary>
        public List<string> FacebookIDs;

    }

    public class GetPlayFabIDsFromFacebookIDsResult : PlayFabResultCommon
    {
        /// <summary>
        /// Mapping of Facebook identifiers to PlayFab identifiers.
        /// </summary>
        public List<FacebookPlayFabIdPair> Data;

    }

    public class GetPlayFabIDsFromSteamIDsRequest
    {
        /// <summary>
        /// Deprecated: Please use SteamStringIDs
        /// </summary>
        [Obsolete("Use 'SteamStringIDs' instead", false)]
        public List<ulong> SteamIDs;

        /// <summary>
        /// Array of unique Steam identifiers (Steam profile IDs) for which the title needs to get PlayFab identifiers.
        /// </summary>
        public List<string> SteamStringIDs;

    }

    public class GetPlayFabIDsFromSteamIDsResult : PlayFabResultCommon
    {
        /// <summary>
        /// Mapping of Steam identifiers to PlayFab identifiers.
        /// </summary>
        public List<SteamPlayFabIdPair> Data;

    }

    public class GetPublisherDataRequest
    {
        /// <summary>
        ///  array of keys to get back data from the Publisher data blob, set by the admin tools
        /// </summary>
        public List<string> Keys;

    }

    public class GetPublisherDataResult : PlayFabResultCommon
    {
        /// <summary>
        /// a dictionary object of key / value pairs
        /// </summary>
        public Dictionary<string,string> Data;

    }

    public class GetRandomResultTablesRequest : PlayFabResultCommon
    {
        /// <summary>
        /// Specifies the catalog version that should be used to retrieve the Random Result Tables.  If unspecified, uses default/primary catalog.
        /// </summary>
        public string CatalogVersion;

        /// <summary>
        /// The unique identifier of the Random Result Table to use.
        /// </summary>
        public List<string> TableIDs;

    }

    public class GetRandomResultTablesResult : PlayFabResultCommon
    {
        /// <summary>
        /// array of random result tables currently available
        /// </summary>
        public Dictionary<string,RandomResultTableListing> Tables;

    }

    public class GetSegmentResult : PlayFabResultCommon
    {
        /// <summary>
        /// Unique identifier for this segment.
        /// </summary>
        public string Id;

        /// <summary>
        /// Segment name.
        /// </summary>
        public string Name;

        /// <summary>
        /// Identifier of the segments AB Test, if it is attached to one.
        /// </summary>
        public string ABTestParent;

    }

    public class GetSharedGroupDataRequest
    {
        /// <summary>
        /// Unique identifier for the shared group.
        /// </summary>
        public string SharedGroupId;

        /// <summary>
        /// Specific keys to retrieve from the shared group (if not specified, all keys will be returned, while an empty array indicates that no keys should be returned).
        /// </summary>
        public List<string> Keys;

        /// <summary>
        /// If true, return the list of all members of the shared group.
        /// </summary>
        public bool? GetMembers;

    }

    public class GetSharedGroupDataResult : PlayFabResultCommon
    {
        /// <summary>
        /// Data for the requested keys.
        /// </summary>
        public Dictionary<string,SharedGroupDataRecord> Data;

        /// <summary>
        /// List of PlayFabId identifiers for the members of this group, if requested.
        /// </summary>
        public List<string> Members;

    }

    public class GetTitleDataRequest
    {
        /// <summary>
        /// Specific keys to search for in the title data (leave null to get all keys)
        /// </summary>
        public List<string> Keys;

    }

    public class GetTitleDataResult : PlayFabResultCommon
    {
        /// <summary>
        /// a dictionary object of key / value pairs
        /// </summary>
        public Dictionary<string,string> Data;

    }

    public class GetTitleNewsRequest
    {
        /// <summary>
        /// Limits the results to the last n entries. Defaults to 10 if not set.
        /// </summary>
        public int? Count;

    }

    public class GetTitleNewsResult : PlayFabResultCommon
    {
        /// <summary>
        /// Array of news items.
        /// </summary>
        public List<TitleNewsItem> News;

    }

    public class GetUserAccountInfoRequest
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

    }

    public class GetUserAccountInfoResult : PlayFabResultCommon
    {
        /// <summary>
        /// Account details for the user whose information was requested.
        /// </summary>
        public UserAccountInfo UserInfo;

    }

    public class GetUserBansRequest
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

    }

    public class GetUserBansResult : PlayFabResultCommon
    {
        /// <summary>
        /// Information about the bans
        /// </summary>
        public List<BanInfo> BanData;

    }

    public class GetUserDataRequest
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Specific keys to search for in the custom user data.
        /// </summary>
        public List<string> Keys;

        /// <summary>
        /// The version that currently exists according to the caller. The call will return the data for all of the keys if the version in the system is greater than this.
        /// </summary>
        public uint? IfChangedFromDataVersion;

    }

    public class GetUserDataResult : PlayFabResultCommon
    {
        /// <summary>
        /// PlayFab unique identifier of the user whose custom data is being returned.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Indicates the current version of the data that has been set. This is incremented with every set call for that type of data (read-only, internal, etc). This version can be provided in Get calls to find updated data.
        /// </summary>
        public uint DataVersion;

        /// <summary>
        /// User specific data for this title.
        /// </summary>
        public Dictionary<string,UserDataRecord> Data;

    }

    public class GetUserInventoryRequest
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

    }

    public class GetUserInventoryResult : PlayFabResultCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Array of inventory items belonging to the user.
        /// </summary>
        [Unordered(SortProperty="ItemInstanceId")]
        public List<ItemInstance> Inventory;

        /// <summary>
        /// Array of virtual currency balance(s) belonging to the user.
        /// </summary>
        public Dictionary<string,int> VirtualCurrency;

        /// <summary>
        /// Array of remaining times and timestamps for virtual currencies.
        /// </summary>
        public Dictionary<string,VirtualCurrencyRechargeTime> VirtualCurrencyRechargeTimes;

    }

    [Obsolete("No longer available", false)]
    public class GetUserStatisticsRequest
    {
        /// <summary>
        /// User for whom statistics are being requested.
        /// </summary>
        public string PlayFabId;

    }

    [Obsolete("No longer available", false)]
    public class GetUserStatisticsResult : PlayFabResultCommon
    {
        /// <summary>
        /// PlayFab unique identifier of the user whose statistics are being returned.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// User statistics for the requested user.
        /// </summary>
        public Dictionary<string,int> UserStatistics;

    }

    public class GrantCharacterToUserRequest
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Non-unique display name of the character being granted.
        /// </summary>
        public string CharacterName;

        /// <summary>
        /// Type of the character being granted; statistics can be sliced based on this value.
        /// </summary>
        public string CharacterType;

    }

    public class GrantCharacterToUserResult : PlayFabResultCommon
    {
        /// <summary>
        /// Unique identifier tagged to this character.
        /// </summary>
        public string CharacterId;

    }

    /// <summary>
    /// Result of granting an item to a user
    /// </summary>
    public class GrantedItemInstance : IComparable<GrantedItemInstance>
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;

        /// <summary>
        /// Result of this operation.
        /// </summary>
        public bool Result;

        /// <summary>
        /// Unique identifier for the inventory item, as defined in the catalog.
        /// </summary>
        public string ItemId;

        /// <summary>
        /// Unique item identifier for this specific instance of the item.
        /// </summary>
        public string ItemInstanceId;

        /// <summary>
        /// Class name for the inventory item, as defined in the catalog.
        /// </summary>
        public string ItemClass;

        /// <summary>
        /// Timestamp for when this instance was purchased.
        /// </summary>
        public DateTime? PurchaseDate;

        /// <summary>
        /// Timestamp for when this instance will expire.
        /// </summary>
        public DateTime? Expiration;

        /// <summary>
        /// Total number of remaining uses, if this is a consumable item.
        /// </summary>
        public int? RemainingUses;

        /// <summary>
        /// The number of uses that were added or removed to this item in this call.
        /// </summary>
        public int? UsesIncrementedBy;

        /// <summary>
        /// Game specific comment associated with this instance when it was added to the user inventory.
        /// </summary>
        public string Annotation;

        /// <summary>
        /// Catalog version for the inventory item, when this instance was created.
        /// </summary>
        public string CatalogVersion;

        /// <summary>
        /// Unique identifier for the parent inventory item, as defined in the catalog, for object which were added from a bundle or container.
        /// </summary>
        public string BundleParent;

        /// <summary>
        /// CatalogItem.DisplayName at the time this item was purchased.
        /// </summary>
        public string DisplayName;

        /// <summary>
        /// Currency type for the cost of the catalog item.
        /// </summary>
        public string UnitCurrency;

        /// <summary>
        /// Cost of the catalog item in the given currency.
        /// </summary>
        public uint UnitPrice;

        /// <summary>
        /// Array of unique items that were awarded when this catalog item was purchased.
        /// </summary>
        public List<string> BundleContents;

        /// <summary>
        /// A set of custom key-value pairs on the inventory item.
        /// </summary>
        public Dictionary<string,string> CustomData;

        public int CompareTo(GrantedItemInstance other)
        {
            if (other == null || other.ItemInstanceId == null) return 1;
            if (ItemInstanceId == null) return -1;
            return ItemInstanceId.CompareTo(other.ItemInstanceId);
        }

    }

    public class GrantItemsToCharacterRequest
    {
        /// <summary>
        /// Catalog version from which items are to be granted.
        /// </summary>
        public string CatalogVersion;

        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// String detailing any additional information concerning this operation.
        /// </summary>
        public string Annotation;

        /// <summary>
        /// Array of itemIds to grant to the user.
        /// </summary>
        public List<string> ItemIds;

    }

    public class GrantItemsToCharacterResult : PlayFabResultCommon
    {
        /// <summary>
        /// Array of items granted to users.
        /// </summary>
        public List<GrantedItemInstance> ItemGrantResults;

    }

    public class GrantItemsToUserRequest
    {
        /// <summary>
        /// Catalog version from which items are to be granted.
        /// </summary>
        public string CatalogVersion;

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// String detailing any additional information concerning this operation.
        /// </summary>
        public string Annotation;

        /// <summary>
        /// Array of itemIds to grant to the user.
        /// </summary>
        public List<string> ItemIds;

    }

    public class GrantItemsToUserResult : PlayFabResultCommon
    {
        /// <summary>
        /// Array of items granted to users.
        /// </summary>
        public List<GrantedItemInstance> ItemGrantResults;

    }

    public class GrantItemsToUsersRequest
    {
        /// <summary>
        /// Catalog version from which items are to be granted.
        /// </summary>
        public string CatalogVersion;

        /// <summary>
        /// Array of items to grant and the users to whom the items are to be granted.
        /// </summary>
        [Unordered]
        public List<ItemGrant> ItemGrants;

    }

    public class GrantItemsToUsersResult : PlayFabResultCommon
    {
        /// <summary>
        /// Array of items granted to users.
        /// </summary>
        public List<GrantedItemInstance> ItemGrantResults;

    }

    public class ItemGrant
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Unique identifier of the catalog item to be granted to the user.
        /// </summary>
        public string ItemId;

        /// <summary>
        /// String detailing any additional information concerning this operation.
        /// </summary>
        public string Annotation;

        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;

        /// <summary>
        /// Key-value pairs to be written to the custom data. Note that keys are trimmed of whitespace, are limited in size, and may not begin with a '!' character.
        /// </summary>
        public Dictionary<string,string> Data;

        /// <summary>
        /// Optional list of Data-keys to remove from UserData.  Some SDKs cannot insert null-values into Data due to language constraints.  Use this to delete the keys directly.
        /// </summary>
        public List<string> KeysToRemove;

    }

    /// <summary>
    /// A unique instance of an item in a user's inventory. Note, to retrieve additional information for an item instance (such as Tags, Description, or Custom Data that are set on the root catalog item), a call to GetCatalogItems is required. The Item ID of the instance can then be matched to a catalog entry, which contains the additional information. Also note that Custom Data is only set here from a call to UpdateUserInventoryItemCustomData.
    /// </summary>
    public class ItemInstance : IComparable<ItemInstance>
    {
        /// <summary>
        /// Unique identifier for the inventory item, as defined in the catalog.
        /// </summary>
        public string ItemId;

        /// <summary>
        /// Unique item identifier for this specific instance of the item.
        /// </summary>
        public string ItemInstanceId;

        /// <summary>
        /// Class name for the inventory item, as defined in the catalog.
        /// </summary>
        public string ItemClass;

        /// <summary>
        /// Timestamp for when this instance was purchased.
        /// </summary>
        public DateTime? PurchaseDate;

        /// <summary>
        /// Timestamp for when this instance will expire.
        /// </summary>
        public DateTime? Expiration;

        /// <summary>
        /// Total number of remaining uses, if this is a consumable item.
        /// </summary>
        public int? RemainingUses;

        /// <summary>
        /// The number of uses that were added or removed to this item in this call.
        /// </summary>
        public int? UsesIncrementedBy;

        /// <summary>
        /// Game specific comment associated with this instance when it was added to the user inventory.
        /// </summary>
        public string Annotation;

        /// <summary>
        /// Catalog version for the inventory item, when this instance was created.
        /// </summary>
        public string CatalogVersion;

        /// <summary>
        /// Unique identifier for the parent inventory item, as defined in the catalog, for object which were added from a bundle or container.
        /// </summary>
        public string BundleParent;

        /// <summary>
        /// CatalogItem.DisplayName at the time this item was purchased.
        /// </summary>
        public string DisplayName;

        /// <summary>
        /// Currency type for the cost of the catalog item.
        /// </summary>
        public string UnitCurrency;

        /// <summary>
        /// Cost of the catalog item in the given currency.
        /// </summary>
        public uint UnitPrice;

        /// <summary>
        /// Array of unique items that were awarded when this catalog item was purchased.
        /// </summary>
        public List<string> BundleContents;

        /// <summary>
        /// A set of custom key-value pairs on the inventory item.
        /// </summary>
        public Dictionary<string,string> CustomData;

        public int CompareTo(ItemInstance other)
        {
            if (other == null || other.ItemInstanceId == null) return 1;
            if (ItemInstanceId == null) return -1;
            return ItemInstanceId.CompareTo(other.ItemInstanceId);
        }

    }

    public class ListUsersCharactersRequest
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

    }

    public class ListUsersCharactersResult : PlayFabResultCommon
    {
        /// <summary>
        /// The requested list of characters.
        /// </summary>
        public List<CharacterResult> Characters;

    }

    [Obsolete("No longer available", false)]
    public class LogEventRequest
    {
        /// <summary>
        /// PlayFab User Id of the player associated with this event. For non-player associated events, this must be null and EntityId must be set.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// For non player-associated events, a unique ID for the entity associated with this event. For player associated events, this must be null and PlayFabId must be set.
        /// </summary>
        public string EntityId;

        /// <summary>
        /// For non player-associated events, the type of entity associated with this event. For player associated events, this must be null.
        /// </summary>
        public string EntityType;

        /// <summary>
        /// Optional timestamp for this event. If null, the a timestamp is auto-assigned to the event on the server.
        /// </summary>
        public DateTime? Timestamp;

        /// <summary>
        /// A unique event name which will be used as the table name in the Redshift database. The name will be made lower case, and cannot not contain spaces. The use of underscores is recommended, for readability. Events also cannot match reserved terms. The PlayFab reserved terms are 'log_in' and 'purchase', 'create' and 'request', while the Redshift reserved terms can be found here: http://docs.aws.amazon.com/redshift/latest/dg/r_pg_keywords.html.
        /// </summary>
        public string EventName;

        /// <summary>
        /// Contains all the data for this event. Event Values can be strings, booleans or numerics (float, double, integer, long) and must be consistent on a per-event basis (if the Value for Key 'A' in Event 'Foo' is an integer the first time it is sent, it must be an integer in all subsequent 'Foo' events). As with event names, Keys must also not use reserved words (see above). Finally, the size of the Body for an event must be less than 32KB (UTF-8 format).
        /// </summary>
        public Dictionary<string,object> Body;

        /// <summary>
        /// Flag to set event Body as profile details in the Redshift database as well as a standard event.
        /// </summary>
        public bool ProfileSetEvent;

    }

    [Obsolete("No longer available", false)]
    public class LogEventResult : PlayFabResultCommon
    {
    }

    
    public enum LoginIdentityProvider
    {
        Unknown,
        PlayFab,
        Custom,
        GameCenter,
        GooglePlay,
        Steam,
        XBoxLive,
        PSN,
        Kongregate,
        Facebook,
        IOSDevice,
        AndroidDevice,
        Twitch
    }

    public class LogStatement
    {
        /// <summary>
        /// 'Debug', 'Info', or 'Error'
        /// </summary>
        public string Level;

        public string Message;

        /// <summary>
        /// Optional object accompanying the message as contextual information
        /// </summary>
        public object Data;

    }

    public class ModifyCharacterVirtualCurrencyResult : PlayFabResultCommon
    {
        /// <summary>
        /// Name of the virtual currency which was modified.
        /// </summary>
        public string VirtualCurrency;

        /// <summary>
        /// Balance of the virtual currency after modification.
        /// </summary>
        public int Balance;

    }

    public class ModifyItemUsesRequest
    {
        /// <summary>
        /// PlayFab unique identifier of the user whose item is being modified.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Unique instance identifier of the item to be modified.
        /// </summary>
        public string ItemInstanceId;

        /// <summary>
        /// Number of uses to add to the item. Can be negative to remove uses.
        /// </summary>
        public int UsesToAdd;

    }

    public class ModifyItemUsesResult : PlayFabResultCommon
    {
        /// <summary>
        /// Unique instance identifier of the item with uses consumed.
        /// </summary>
        public string ItemInstanceId;

        /// <summary>
        /// Number of uses remaining on the item.
        /// </summary>
        public int RemainingUses;

    }

    public class ModifyUserVirtualCurrencyResult : PlayFabResultCommon
    {
        /// <summary>
        /// User currency was subtracted from.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Name of the virtual currency which was modified.
        /// </summary>
        public string VirtualCurrency;

        /// <summary>
        /// Amount added or subtracted from the user's virtual currency. Maximum VC balance is Int32 (2,147,483,647). Any increase over this value will be discarded.
        /// </summary>
        public int BalanceChange;

        /// <summary>
        /// Balance of the virtual currency after modification.
        /// </summary>
        public int Balance;

    }

    public class MoveItemToCharacterFromCharacterRequest
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Unique identifier of the character that currently has the item.
        /// </summary>
        public string GivingCharacterId;

        /// <summary>
        /// Unique identifier of the character that will be receiving the item.
        /// </summary>
        public string ReceivingCharacterId;

        /// <summary>
        /// Unique PlayFab assigned instance identifier of the item
        /// </summary>
        public string ItemInstanceId;

    }

    public class MoveItemToCharacterFromCharacterResult : PlayFabResultCommon
    {
    }

    public class MoveItemToCharacterFromUserRequest
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;

        /// <summary>
        /// Unique PlayFab assigned instance identifier of the item
        /// </summary>
        public string ItemInstanceId;

    }

    public class MoveItemToCharacterFromUserResult : PlayFabResultCommon
    {
    }

    public class MoveItemToUserFromCharacterRequest
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;

        /// <summary>
        /// Unique PlayFab assigned instance identifier of the item
        /// </summary>
        public string ItemInstanceId;

    }

    public class MoveItemToUserFromCharacterResult : PlayFabResultCommon
    {
    }

    public class NotifyMatchmakerPlayerLeftRequest
    {
        /// <summary>
        /// Unique identifier of the Game Instance the user is leaving.
        /// </summary>
        public string LobbyId;

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

    }

    public class NotifyMatchmakerPlayerLeftResult : PlayFabResultCommon
    {
        /// <summary>
        /// State of user leaving the Game Server Instance.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public PlayerConnectionState? PlayerState;

    }

    
    public enum PlayerConnectionState
    {
        Unassigned,
        Connecting,
        Participating,
        Participated,
        Reconnecting
    }

    public class PlayerLeaderboardEntry
    {
        /// <summary>
        /// PlayFab unique identifier of the user for this leaderboard entry.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Title-specific display name of the user for this leaderboard entry.
        /// </summary>
        public string DisplayName;

        /// <summary>
        /// Specific value of the user's statistic.
        /// </summary>
        public int StatValue;

        /// <summary>
        /// User's overall position in the leaderboard.
        /// </summary>
        public int Position;

    }

    public class PlayerLinkedAccount
    {
        /// <summary>
        /// Authentication platform
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public LoginIdentityProvider? Platform;

        /// <summary>
        /// Platform user identifier
        /// </summary>
        public string PlatformUserId;

        /// <summary>
        /// Linked account's username
        /// </summary>
        public string Username;

        /// <summary>
        /// Linked account's email
        /// </summary>
        public string Email;

    }

    public class PlayerProfile
    {
        /// <summary>
        /// PlayFab Player ID
        /// </summary>
        public string PlayerId;

        /// <summary>
        /// Title ID this profile applies to
        /// </summary>
        public string TitleId;

        /// <summary>
        /// Player Display Name
        /// </summary>
        public string DisplayName;

        /// <summary>
        /// Publisher this player belongs to
        /// </summary>
        public string PublisherId;

        /// <summary>
        /// Player account origination
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public LoginIdentityProvider? Origination;

        /// <summary>
        /// Player record created
        /// </summary>
        public DateTime? Created;

        /// <summary>
        /// Last login
        /// </summary>
        public DateTime? LastLogin;

        /// <summary>
        /// Banned until UTC Date. If permanent ban this is set for 20 years after the original ban date.
        /// </summary>
        public DateTime? BannedUntil;

        /// <summary>
        /// Dictionary of player's statistics using only the latest version's value
        /// </summary>
        public Dictionary<string,int> Statistics;

        /// <summary>
        /// Dictionary of player's total currency purchases. The key VTD is a sum of all player_realmoney_purchase events OrderTotals.
        /// </summary>
        public Dictionary<string,uint> ValuesToDate;

        /// <summary>
        /// List of player's tags for segmentation.
        /// </summary>
        public List<string> Tags;

        /// <summary>
        /// Dictionary of player's virtual currency balances
        /// </summary>
        public Dictionary<string,int> VirtualCurrencyBalances;

        /// <summary>
        /// Array of ad campaigns player has been attributed to
        /// </summary>
        public List<AdCampaignAttribution> AdCampaignAttributions;

        /// <summary>
        /// Array of configured push notification end points
        /// </summary>
        public List<PushNotificationRegistration> PushNotificationRegistrations;

        /// <summary>
        /// Array of third party accounts linked to this player
        /// </summary>
        public List<PlayerLinkedAccount> LinkedAccounts;

        /// <summary>
        /// Array of player statistics
        /// </summary>
        public List<PlayerStatistic> PlayerStatistics;

    }

    public class PlayerStatistic
    {
        /// <summary>
        /// Statistic ID
        /// </summary>
        public string Id;

        /// <summary>
        /// Statistic version (0 if not a versioned statistic)
        /// </summary>
        public int StatisticVersion;

        /// <summary>
        /// Current statistic value
        /// </summary>
        public int StatisticValue;

        /// <summary>
        /// Statistic name
        /// </summary>
        public string Name;

    }

    public class PlayerStatisticVersion
    {
        /// <summary>
        /// name of the statistic when the version became active
        /// </summary>
        public string StatisticName;

        /// <summary>
        /// version of the statistic
        /// </summary>
        public uint Version;

        /// <summary>
        /// time at which the statistic version was scheduled to become active, based on the configured ResetInterval
        /// </summary>
        public DateTime? ScheduledActivationTime;

        /// <summary>
        /// time when the statistic version became active
        /// </summary>
        public DateTime ActivationTime;

        /// <summary>
        /// time at which the statistic version was scheduled to become inactive, based on the configured ResetInterval
        /// </summary>
        public DateTime? ScheduledDeactivationTime;

        /// <summary>
        /// time when the statistic version became inactive due to statistic version incrementing
        /// </summary>
        public DateTime? DeactivationTime;

    }

    
    public enum PushNotificationPlatform
    {
        ApplePushNotificationService,
        GoogleCloudMessaging
    }

    public class PushNotificationRegistration
    {
        /// <summary>
        /// Push notification platform
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public PushNotificationPlatform? Platform;

        /// <summary>
        /// Notification configured endpoint
        /// </summary>
        public string NotificationEndpointARN;

    }

    public class RandomResultTableListing : PlayFabResultCommon
    {
        /// <summary>
        /// Catalog version this table is associated with
        /// </summary>
        public string CatalogVersion;

        /// <summary>
        /// Unique name for this drop table
        /// </summary>
        public string TableId;

        /// <summary>
        /// Child nodes that indicate what kind of drop table item this actually is.
        /// </summary>
        public List<ResultTableNode> Nodes;

    }

    public class RedeemCouponRequest
    {
        /// <summary>
        /// Generated coupon code to redeem.
        /// </summary>
        public string CouponCode;

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Catalog version of the coupon.
        /// </summary>
        public string CatalogVersion;

    }

    public class RedeemCouponResult : PlayFabResultCommon
    {
        /// <summary>
        /// Items granted to the player as a result of redeeming the coupon.
        /// </summary>
        public List<ItemInstance> GrantedItems;

    }

    public class RedeemMatchmakerTicketRequest
    {
        /// <summary>
        /// Server authorization ticket passed back from a call to Matchmake or StartGame.
        /// </summary>
        public string Ticket;

        /// <summary>
        /// Unique identifier of the Game Server Instance that is asking for validation of the authorization ticket.
        /// </summary>
        public string LobbyId;

    }

    public class RedeemMatchmakerTicketResult : PlayFabResultCommon
    {
        /// <summary>
        /// Boolean indicating whether the ticket was validated by the PlayFab service.
        /// </summary>
        public bool TicketIsValid;

        /// <summary>
        /// Error value if the ticket was not validated.
        /// </summary>
        public string Error;

        /// <summary>
        /// User account information for the user validated.
        /// </summary>
        public UserAccountInfo UserInfo;

    }

    public class RemovePlayerTagRequest
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Unique tag for player profile.
        /// </summary>
        public string TagName;

    }

    public class RemovePlayerTagResult : PlayFabResultCommon
    {
    }

    public class RemoveSharedGroupMembersRequest
    {
        /// <summary>
        /// Unique identifier for the shared group.
        /// </summary>
        public string SharedGroupId;

        /// <summary>
        /// An array of unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public List<string> PlayFabIds;

    }

    public class RemoveSharedGroupMembersResult : PlayFabResultCommon
    {
    }

    public class ReportPlayerServerRequest
    {
        /// <summary>
        /// PlayFabId of the reporting player.
        /// </summary>
        public string ReporterId;

        /// <summary>
        /// PlayFabId of the reported player.
        /// </summary>
        public string ReporteeId;

        /// <summary>
        /// Title player was reported in, optional if report not for specific title.
        /// </summary>
        public string TitleId;

        /// <summary>
        /// Optional additional comment by reporting player.
        /// </summary>
        public string Comment;

    }

    public class ReportPlayerServerResult : PlayFabResultCommon
    {
        /// <summary>
        /// Indicates whether this action completed successfully.
        /// </summary>
        public bool Updated;

        /// <summary>
        /// The number of remaining reports which may be filed today by this reporting player.
        /// </summary>
        public int SubmissionsRemaining;

    }

    public class ResultTableNode : PlayFabResultCommon
    {
        /// <summary>
        /// Whether this entry in the table is an item or a link to another table
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ResultTableNodeType ResultItemType;

        /// <summary>
        /// Either an ItemId, or the TableId of another random result table
        /// </summary>
        public string ResultItem;

        /// <summary>
        /// How likely this is to be rolled - larger numbers add more weight
        /// </summary>
        public int Weight;

    }

    
    public enum ResultTableNodeType
    {
        ItemId,
        TableId
    }

    public class RevokeAllBansForUserRequest
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

    }

    public class RevokeAllBansForUserResult : PlayFabResultCommon
    {
        /// <summary>
        /// Information on the bans that were revoked.
        /// </summary>
        public List<BanInfo> BanData;

    }

    public class RevokeBansRequest
    {
        /// <summary>
        /// Ids of the bans to be revoked. Maximum 100.
        /// </summary>
        public List<string> BanIds;

    }

    public class RevokeBansResult : PlayFabResultCommon
    {
        /// <summary>
        /// Information on the bans that were revoked
        /// </summary>
        public List<BanInfo> BanData;

    }

    public class RevokeInventoryItemRequest
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;

        /// <summary>
        /// Unique PlayFab assigned instance identifier of the item
        /// </summary>
        public string ItemInstanceId;

    }

    public class RevokeInventoryResult : PlayFabResultCommon
    {
    }

    public class ScriptExecutionError
    {
        /// <summary>
        /// Error code, such as CloudScriptNotFound, JavascriptException, CloudScriptFunctionArgumentSizeExceeded, CloudScriptAPIRequestCountExceeded, CloudScriptAPIRequestError, or CloudScriptHTTPRequestError
        /// </summary>
        public string Error;

        /// <summary>
        /// Details about the error
        /// </summary>
        public string Message;

        /// <summary>
        /// Point during the execution of the script at which the error occurred, if any
        /// </summary>
        public string StackTrace;

    }

    public class SendPushNotificationRequest
    {
        /// <summary>
        /// PlayFabId of the recipient of the push notification.
        /// </summary>
        public string Recipient;

        /// <summary>
        /// Text of message to send.
        /// </summary>
        public string Message;

        /// <summary>
        /// Subject of message to send (may not be displayed in all platforms.
        /// </summary>
        public string Subject;

    }

    public class SendPushNotificationResult : PlayFabResultCommon
    {
    }

    public class SetGameServerInstanceDataRequest
    {
        /// <summary>
        /// Unique identifier of the Game Instance to be updated.
        /// </summary>
        public string LobbyId;

        /// <summary>
        /// Custom data to set for the specified game server instance.
        /// </summary>
        public string GameServerData;

    }

    public class SetGameServerInstanceDataResult : PlayFabResultCommon
    {
    }

    public class SetGameServerInstanceStateRequest
    {
        /// <summary>
        /// Unique identifier of the Game Instance to be updated.
        /// </summary>
        public string LobbyId;

        /// <summary>
        /// State to set for the specified game server instance.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public GameInstanceState State;

    }

    public class SetGameServerInstanceStateResult : PlayFabResultCommon
    {
    }

    public class SetPublisherDataRequest
    {
        /// <summary>
        /// key we want to set a value on (note, this is additive - will only replace an existing key's value if they are the same name.) Keys are trimmed of whitespace. Keys may not begin with the '!' character.
        /// </summary>
        public string Key;

        /// <summary>
        /// new value to set. Set to null to remove a value
        /// </summary>
        public string Value;

    }

    public class SetPublisherDataResult : PlayFabResultCommon
    {
    }

    public class SetTitleDataRequest
    {
        /// <summary>
        /// key we want to set a value on (note, this is additive - will only replace an existing key's value if they are the same name.) Keys are trimmed of whitespace. Keys may not begin with the '!' character.
        /// </summary>
        public string Key;

        /// <summary>
        /// new value to set. Set to null to remove a value
        /// </summary>
        public string Value;

    }

    public class SetTitleDataResult : PlayFabResultCommon
    {
    }

    public class SharedGroupDataRecord
    {
        /// <summary>
        /// Data stored for the specified group data key.
        /// </summary>
        public string Value;

        /// <summary>
        /// PlayFabId of the user to last update this value.
        /// </summary>
        public string LastUpdatedBy;

        /// <summary>
        /// Timestamp for when this data was last updated.
        /// </summary>
        public DateTime LastUpdated;

        /// <summary>
        /// Indicates whether this data can be read by all users (public) or only members of the group (private).
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public UserDataPermission? Permission;

    }

    public class StatisticNameVersion
    {
        /// <summary>
        /// unique name of the statistic
        /// </summary>
        public string StatisticName;

        /// <summary>
        /// the version of the statistic to be returned
        /// </summary>
        public uint Version;

    }

    public class StatisticUpdate
    {
        /// <summary>
        /// unique name of the statistic
        /// </summary>
        public string StatisticName;

        /// <summary>
        /// for updates to an existing statistic value for a player, the version of the statistic when it was loaded. Null when setting the statistic value for the first time.
        /// </summary>
        public uint? Version;

        /// <summary>
        /// statistic value for the player
        /// </summary>
        public int Value;

    }

    public class StatisticValue
    {
        /// <summary>
        /// unique name of the statistic
        /// </summary>
        public string StatisticName;

        /// <summary>
        /// statistic value for the player
        /// </summary>
        public int Value;

        /// <summary>
        /// for updates to an existing statistic value for a player, the version of the statistic when it was loaded
        /// </summary>
        public uint Version;

    }

    public class SteamPlayFabIdPair
    {
        /// <summary>
        /// Deprecated: Please use SteamStringId
        /// </summary>
        [Obsolete("Use 'SteamStringId' instead", false)]
        public ulong SteamId;

        /// <summary>
        /// Unique Steam identifier for a user.
        /// </summary>
        public string SteamStringId;

        /// <summary>
        /// Unique PlayFab identifier for a user, or null if no PlayFab account is linked to the Steam identifier.
        /// </summary>
        public string PlayFabId;

    }

    public class SubtractCharacterVirtualCurrencyRequest
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;

        /// <summary>
        /// Name of the virtual currency which is to be decremented.
        /// </summary>
        public string VirtualCurrency;

        /// <summary>
        /// Amount to be subtracted from the user balance of the specified virtual currency.
        /// </summary>
        public int Amount;

    }

    public class SubtractUserVirtualCurrencyRequest
    {
        /// <summary>
        /// PlayFab unique identifier of the user whose virtual currency balance is to be decreased.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Name of the virtual currency which is to be decremented.
        /// </summary>
        public string VirtualCurrency;

        /// <summary>
        /// Amount to be subtracted from the user balance of the specified virtual currency.
        /// </summary>
        public int Amount;

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
        /// Date and time when the news items was posted.
        /// </summary>
        public DateTime Timestamp;

        /// <summary>
        /// Unique identifier of news item.
        /// </summary>
        public string NewsId;

        /// <summary>
        /// Title of the news item.
        /// </summary>
        public string Title;

        /// <summary>
        /// News item text.
        /// </summary>
        public string Body;

    }

    public class UnlockContainerInstanceRequest
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;

        /// <summary>
        /// ItemInstanceId of the container to unlock.
        /// </summary>
        public string ContainerItemInstanceId;

        /// <summary>
        /// ItemInstanceId of the key that will be consumed by unlocking this container.  If the container requires a key, this parameter is required.
        /// </summary>
        public string KeyItemInstanceId;

        /// <summary>
        /// Specifies the catalog version that should be used to determine container contents.  If unspecified, uses catalog associated with the item instance.
        /// </summary>
        public string CatalogVersion;

    }

    public class UnlockContainerItemRequest
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;

        /// <summary>
        /// Catalog ItemId of the container type to unlock.
        /// </summary>
        public string ContainerItemId;

        /// <summary>
        /// Specifies the catalog version that should be used to determine container contents.  If unspecified, uses default/primary catalog.
        /// </summary>
        public string CatalogVersion;

    }

    public class UnlockContainerItemResult : PlayFabResultCommon
    {
        /// <summary>
        /// Unique instance identifier of the container unlocked.
        /// </summary>
        public string UnlockedItemInstanceId;

        /// <summary>
        /// Unique instance identifier of the key used to unlock the container, if applicable.
        /// </summary>
        public string UnlockedWithItemInstanceId;

        /// <summary>
        /// Items granted to the player as a result of unlocking the container.
        /// </summary>
        public List<ItemInstance> GrantedItems;

        /// <summary>
        /// Virtual currency granted to the player as a result of unlocking the container.
        /// </summary>
        public Dictionary<string,uint> VirtualCurrency;

    }

    /// <summary>
    /// Represents a single update ban request.
    /// </summary>
    public class UpdateBanRequest
    {
        /// <summary>
        /// The id of the ban to be updated.
        /// </summary>
        public string BanId;

        /// <summary>
        /// The updated reason for the ban to be updated. Maximum 140 characters. Null for no change.
        /// </summary>
        public string Reason;

        /// <summary>
        /// The updated expiration date for the ban. Null for no change.
        /// </summary>
        public DateTime? Expires;

        /// <summary>
        /// The updated IP address for the ban. Null for no change.
        /// </summary>
        public string IPAddress;

        /// <summary>
        /// The updated MAC address for the ban. Null for no change.
        /// </summary>
        public string MACAddress;

        /// <summary>
        /// Whether to make this ban permanent. Set to true to make this ban permanent. This will not modify Active state.
        /// </summary>
        public bool? Permanent;

        /// <summary>
        /// The updated active state for the ban. Null for no change.
        /// </summary>
        public bool? Active;

    }

    public class UpdateBansRequest
    {
        /// <summary>
        /// List of bans to be updated. Maximum 100.
        /// </summary>
        public List<UpdateBanRequest> Bans;

    }

    public class UpdateBansResult : PlayFabResultCommon
    {
        /// <summary>
        /// Information on the bans that were updated
        /// </summary>
        public List<BanInfo> BanData;

    }

    public class UpdateCharacterDataRequest
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;

        /// <summary>
        /// Key-value pairs to be written to the custom data. Note that keys are trimmed of whitespace, are limited in size, and may not begin with a '!' character.
        /// </summary>
        public Dictionary<string,string> Data;

        /// <summary>
        /// Optional list of Data-keys to remove from UserData.  Some SDKs cannot insert null-values into Data due to language constraints.  Use this to delete the keys directly.
        /// </summary>
        public List<string> KeysToRemove;

        /// <summary>
        /// Permission to be applied to all user data keys written in this request. Defaults to "private" if not set.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public UserDataPermission? Permission;

    }

    public class UpdateCharacterDataResult : PlayFabResultCommon
    {
        /// <summary>
        /// Indicates the current version of the data that has been set. This is incremented with every set call for that type of data (read-only, internal, etc). This version can be provided in Get calls to find updated data.
        /// </summary>
        public uint DataVersion;

    }

    public class UpdateCharacterStatisticsRequest
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;

        /// <summary>
        /// Statistics to be updated with the provided values.
        /// </summary>
        public Dictionary<string,int> CharacterStatistics;

    }

    public class UpdateCharacterStatisticsResult : PlayFabResultCommon
    {
    }

    public class UpdatePlayerStatisticsRequest
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Statistics to be updated with the provided values
        /// </summary>
        public List<StatisticUpdate> Statistics;

    }

    public class UpdatePlayerStatisticsResult : PlayFabResultCommon
    {
    }

    public class UpdateSharedGroupDataRequest
    {
        /// <summary>
        /// Unique identifier for the shared group.
        /// </summary>
        public string SharedGroupId;

        /// <summary>
        /// Key-value pairs to be written to the custom data. Note that keys are trimmed of whitespace, are limited in size, and may not begin with a '!' character.
        /// </summary>
        public Dictionary<string,string> Data;

        /// <summary>
        /// Optional list of Data-keys to remove from UserData.  Some SDKs cannot insert null-values into Data due to language constraints.  Use this to delete the keys directly.
        /// </summary>
        public List<string> KeysToRemove;

        /// <summary>
        /// Permission to be applied to all user data keys in this request.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public UserDataPermission? Permission;

    }

    public class UpdateSharedGroupDataResult : PlayFabResultCommon
    {
    }

    public class UpdateUserDataRequest
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Key-value pairs to be written to the custom data. Note that keys are trimmed of whitespace, are limited in size, and may not begin with a '!' character.
        /// </summary>
        public Dictionary<string,string> Data;

        /// <summary>
        /// Optional list of Data-keys to remove from UserData.  Some SDKs cannot insert null-values into Data due to language constraints.  Use this to delete the keys directly.
        /// </summary>
        public List<string> KeysToRemove;

        /// <summary>
        /// Permission to be applied to all user data keys written in this request. Defaults to "private" if not set.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public UserDataPermission? Permission;

    }

    public class UpdateUserDataResult : PlayFabResultCommon
    {
        /// <summary>
        /// Indicates the current version of the data that has been set. This is incremented with every set call for that type of data (read-only, internal, etc). This version can be provided in Get calls to find updated data.
        /// </summary>
        public uint DataVersion;

    }

    public class UpdateUserInternalDataRequest
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Key-value pairs to be written to the custom data. Note that keys are trimmed of whitespace, are limited in size, and may not begin with a '!' character.
        /// </summary>
        public Dictionary<string,string> Data;

        /// <summary>
        /// Optional list of Data-keys to remove from UserData.  Some SDKs cannot insert null-values into Data due to language constraints.  Use this to delete the keys directly.
        /// </summary>
        public List<string> KeysToRemove;

    }

    public class UpdateUserInventoryItemDataRequest
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;

        /// <summary>
        /// Unique PlayFab assigned instance identifier of the item
        /// </summary>
        public string ItemInstanceId;

        /// <summary>
        /// Key-value pairs to be written to the custom data. Note that keys are trimmed of whitespace, are limited in size, and may not begin with a '!' character.
        /// </summary>
        public Dictionary<string,string> Data;

        /// <summary>
        /// Optional list of Data-keys to remove from UserData.  Some SDKs cannot insert null-values into Data due to language constraints.  Use this to delete the keys directly.
        /// </summary>
        public List<string> KeysToRemove;

    }

    [Obsolete("No longer available", false)]
    public class UpdateUserStatisticsRequest
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Statistics to be updated with the provided values.
        /// </summary>
        public Dictionary<string,int> UserStatistics;

    }

    [Obsolete("No longer available", false)]
    public class UpdateUserStatisticsResult : PlayFabResultCommon
    {
    }

    public class UserAccountInfo
    {
        /// <summary>
        /// Unique identifier for the user account
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Timestamp indicating when the user account was created
        /// </summary>
        public DateTime Created;

        /// <summary>
        /// User account name in the PlayFab service
        /// </summary>
        public string Username;

        /// <summary>
        /// Title-specific information for the user account
        /// </summary>
        public UserTitleInfo TitleInfo;

        /// <summary>
        /// Personal information for the user which is considered more sensitive
        /// </summary>
        public UserPrivateAccountInfo PrivateInfo;

        /// <summary>
        /// User Facebook information, if a Facebook account has been linked
        /// </summary>
        public UserFacebookInfo FacebookInfo;

        /// <summary>
        /// User Steam information, if a Steam account has been linked
        /// </summary>
        public UserSteamInfo SteamInfo;

        /// <summary>
        /// User Gamecenter information, if a Gamecenter account has been linked
        /// </summary>
        public UserGameCenterInfo GameCenterInfo;

        /// <summary>
        /// User iOS device information, if an iOS device has been linked
        /// </summary>
        public UserIosDeviceInfo IosDeviceInfo;

        /// <summary>
        /// User Android device information, if an Android device has been linked
        /// </summary>
        public UserAndroidDeviceInfo AndroidDeviceInfo;

        /// <summary>
        /// User Kongregate account information, if a Kongregate account has been linked
        /// </summary>
        public UserKongregateInfo KongregateInfo;

        /// <summary>
        /// User Twitch account information, if a Twitch account has been linked
        /// </summary>
        public UserTwitchInfo TwitchInfo;

        /// <summary>
        /// User PSN account information, if a PSN account has been linked
        /// </summary>
        public UserPsnInfo PsnInfo;

        /// <summary>
        /// User Google account information, if a Google account has been linked
        /// </summary>
        public UserGoogleInfo GoogleInfo;

        /// <summary>
        /// User XBox account information, if a XBox account has been linked
        /// </summary>
        public UserXboxInfo XboxInfo;

        /// <summary>
        /// Custom ID information, if a custom ID has been assigned
        /// </summary>
        public UserCustomIdInfo CustomIdInfo;

    }

    public class UserAndroidDeviceInfo
    {
        /// <summary>
        /// Android device ID
        /// </summary>
        public string AndroidDeviceId;

    }

    public class UserCustomIdInfo
    {
        /// <summary>
        /// Custom ID
        /// </summary>
        public string CustomId;

    }

    
    /// <summary>
    /// Indicates whether a given data key is private (readable only by the player) or public (readable by all players). When a player makes a GetUserData request about another player, only keys marked Public will be returned.
    /// </summary>
    public enum UserDataPermission
    {
        Private,
        Public
    }

    public class UserDataRecord
    {
        /// <summary>
        /// Data stored for the specified user data key.
        /// </summary>
        public string Value;

        /// <summary>
        /// Timestamp for when this data was last updated.
        /// </summary>
        public DateTime LastUpdated;

        /// <summary>
        /// Indicates whether this data can be read by all users (public) or only the user (private). This is used for GetUserData requests being made by one player about another player.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public UserDataPermission? Permission;

    }

    public class UserFacebookInfo
    {
        /// <summary>
        /// Facebook identifier
        /// </summary>
        public string FacebookId;

        /// <summary>
        /// Facebook full name
        /// </summary>
        public string FullName;

    }

    public class UserGameCenterInfo
    {
        /// <summary>
        /// Gamecenter identifier
        /// </summary>
        public string GameCenterId;

    }

    public class UserGoogleInfo
    {
        /// <summary>
        /// Google ID
        /// </summary>
        public string GoogleId;

        /// <summary>
        /// Email address of the Google account
        /// </summary>
        public string GoogleEmail;

        /// <summary>
        /// Locale of the Google account
        /// </summary>
        public string GoogleLocale;

        /// <summary>
        /// Gender information of the Google account
        /// </summary>
        public string GoogleGender;

    }

    public class UserIosDeviceInfo
    {
        /// <summary>
        /// iOS device ID
        /// </summary>
        public string IosDeviceId;

    }

    public class UserKongregateInfo
    {
        /// <summary>
        /// Kongregate ID
        /// </summary>
        public string KongregateId;

        /// <summary>
        /// Kongregate Username
        /// </summary>
        public string KongregateName;

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
        GameCenter,
        CustomId,
        XboxLive,
        Parse,
        Twitch
    }

    public class UserPrivateAccountInfo
    {
        /// <summary>
        /// user email address
        /// </summary>
        public string Email;

    }

    public class UserPsnInfo
    {
        /// <summary>
        /// PSN account ID
        /// </summary>
        public string PsnAccountId;

        /// <summary>
        /// PSN online ID
        /// </summary>
        public string PsnOnlineId;

    }

    public class UserSteamInfo
    {
        /// <summary>
        /// Steam identifier
        /// </summary>
        public string SteamId;

        /// <summary>
        /// the country in which the player resides, from Steam data
        /// </summary>
        public string SteamCountry;

        /// <summary>
        /// currency type set in the user Steam account
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public Currency? SteamCurrency;

        /// <summary>
        /// what stage of game ownership the user is listed as being in, from Steam
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public TitleActivationStatus? SteamActivationStatus;

    }

    public class UserTitleInfo
    {
        /// <summary>
        /// name of the user, as it is displayed in-game
        /// </summary>
        public string DisplayName;

        /// <summary>
        /// source by which the user first joined the game, if known
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public UserOrigination? Origination;

        /// <summary>
        /// timestamp indicating when the user was first associated with this game (this can differ significantly from when the user first registered with PlayFab)
        /// </summary>
        public DateTime Created;

        /// <summary>
        /// timestamp for the last user login for this title
        /// </summary>
        public DateTime? LastLogin;

        /// <summary>
        /// timestamp indicating when the user first signed into this game (this can differ from the Created timestamp, as other events, such as issuing a beta key to the user, can associate the title to the user)
        /// </summary>
        public DateTime? FirstLogin;

        /// <summary>
        /// boolean indicating whether or not the user is currently banned for a title
        /// </summary>
        public bool? isBanned;

    }

    public class UserTwitchInfo
    {
        /// <summary>
        /// Twitch ID
        /// </summary>
        public string TwitchId;

        /// <summary>
        /// Twitch Username
        /// </summary>
        public string TwitchUserName;

    }

    public class UserXboxInfo
    {
        /// <summary>
        /// XBox user ID
        /// </summary>
        public string XboxUserId;

    }

    public class VirtualCurrencyRechargeTime
    {
        /// <summary>
        /// Time remaining (in seconds) before the next recharge increment of the virtual currency.
        /// </summary>
        public int SecondsToRecharge;

        /// <summary>
        /// Server timestamp in UTC indicating the next time the virtual currency will be incremented.
        /// </summary>
        public DateTime RechargeTime;

        /// <summary>
        /// Maximum value to which the regenerating currency will automatically increment. Note that it can exceed this value through use of the AddUserVirtualCurrency API call. However, it will not regenerate automatically until it has fallen below this value.
        /// </summary>
        public int RechargeMax;

    }

    public class WriteEventResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The unique identifier of the event. This can be used to retrieve the event's properties using the GetEvent API. The values of this identifier consist of ASCII characters and are not constrained to any particular format.
        /// </summary>
        public string EventId;

    }

    public class WriteServerCharacterEventRequest
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;

        /// <summary>
        /// The name of the event, within the namespace scoped to the title. The naming convention is up to the caller, but it commonly follows the subject_verb_object pattern (e.g. player_logged_in).
        /// </summary>
        public string EventName;

        /// <summary>
        /// The time (in UTC) associated with this event. The value dafaults to the current time.
        /// </summary>
        public DateTime? Timestamp;

        /// <summary>
        /// Custom event properties. Each property consists of a name (string) and a value (JSON object).
        /// </summary>
        public Dictionary<string,object> Body;

    }

    public class WriteServerPlayerEventRequest
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// The name of the event, within the namespace scoped to the title. The naming convention is up to the caller, but it commonly follows the subject_verb_object pattern (e.g. player_logged_in).
        /// </summary>
        public string EventName;

        /// <summary>
        /// The time (in UTC) associated with this event. The value dafaults to the current time.
        /// </summary>
        public DateTime? Timestamp;

        /// <summary>
        /// Custom data properties associated with the event. Each property consists of a name (string) and a value (JSON object).
        /// </summary>
        public Dictionary<string,object> Body;

    }

    public class WriteTitleEventRequest
    {
        /// <summary>
        /// The name of the event, within the namespace scoped to the title. The naming convention is up to the caller, but it commonly follows the subject_verb_object pattern (e.g. player_logged_in).
        /// </summary>
        public string EventName;

        /// <summary>
        /// The time (in UTC) associated with this event. The value dafaults to the current time.
        /// </summary>
        public DateTime? Timestamp;

        /// <summary>
        /// Custom event properties. Each property consists of a name (string) and a value (JSON object).
        /// </summary>
        public Dictionary<string,object> Body;

    }
}
