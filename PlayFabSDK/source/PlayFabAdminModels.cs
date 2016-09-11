using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PlayFab.Internal;
using System;
using System.Collections.Generic;

namespace PlayFab.AdminModels
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

    public class AddNewsRequest
    {
        /// <summary>
        /// Time this news was published. If not set, defaults to now.
        /// </summary>
        public DateTime? Timestamp;

        /// <summary>
        /// Title (headline) of the news item
        /// </summary>
        public string Title;

        /// <summary>
        /// Body text of the news
        /// </summary>
        public string Body;

    }

    public class AddNewsResult : PlayFabResultCommon
    {
        /// <summary>
        /// Unique id of the new news item
        /// </summary>
        public string NewsId;

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

    public class AddServerBuildRequest
    {
        /// <summary>
        /// unique identifier for the build executable
        /// </summary>
        public string BuildId;

        /// <summary>
        /// appended to the end of the command line when starting game servers
        /// </summary>
        public string CommandLineTemplate;

        /// <summary>
        /// path to the game server executable. Defaults to gameserver.exe
        /// </summary>
        public string ExecutablePath;

        /// <summary>
        /// server host regions in which this build should be running and available
        /// </summary>
        [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
        public List<Region> ActiveRegions;

        /// <summary>
        /// developer comment(s) for this build
        /// </summary>
        public string Comment;

        /// <summary>
        /// maximum number of game server instances that can run on a single host machine
        /// </summary>
        public int MaxGamesPerHost;

        /// <summary>
        /// minimum capacity of additional game server instances that can be started before the autoscaling service starts new host machines (given the number of current running host machines and game server instances)
        /// </summary>
        public int MinFreeGameSlots;

    }

    public class AddServerBuildResult : PlayFabResultCommon
    {
        /// <summary>
        /// unique identifier for this build executable
        /// </summary>
        public string BuildId;

        /// <summary>
        /// array of regions where this build can used, when it is active
        /// </summary>
        [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
        public List<Region> ActiveRegions;

        /// <summary>
        /// maximum number of game server instances that can run on a single host machine
        /// </summary>
        public int MaxGamesPerHost;

        /// <summary>
        /// minimum capacity of additional game server instances that can be started before the autoscaling service starts new host machines (given the number of current running host machines and game server instances)
        /// </summary>
        public int MinFreeGameSlots;

        /// <summary>
        /// appended to the end of the command line when starting game servers
        /// </summary>
        public string CommandLineTemplate;

        /// <summary>
        /// path to the game server executable. Defaults to gameserver.exe
        /// </summary>
        public string ExecutablePath;

        /// <summary>
        /// developer comment(s) for this build
        /// </summary>
        public string Comment;

        /// <summary>
        /// time this build was last modified (or uploaded, if this build has never been modified)
        /// </summary>
        public DateTime Timestamp;

        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected.
        /// </summary>
        public string TitleId;

        /// <summary>
        /// the current status of the build validation and processing steps
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public GameBuildStatus? Status;

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

    public class AddVirtualCurrencyTypesRequest
    {
        /// <summary>
        /// List of virtual currencies and their initial deposits (the amount a user is granted when signing in for the first time) to the title
        /// </summary>
        public List<VirtualCurrencyData> VirtualCurrencies;

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

    public class BlankResult : PlayFabResultCommon
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
        /// BETA: If true, then only a fixed number can ever be granted.
        /// </summary>
        public bool IsLimitedEdition;

        /// <summary>
        /// BETA: If IsLImitedEdition is true, then this determines amount of the item initially available. Note that this fieldis ignored if the catalog item already existed in this catalog, or the field is less than 1.
        /// </summary>
        public int InitialLimitedEditionCount;

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

    public class CloudScriptFile
    {
        /// <summary>
        /// Name of the javascript file. These names are not used internally by the server, they are only for developer organizational purposes.
        /// </summary>
        public string Filename;

        /// <summary>
        /// Contents of the Cloud Script javascript. Must be string-escaped javascript.
        /// </summary>
        public string FileContents;

    }

    public class CloudScriptVersionStatus
    {
        /// <summary>
        /// Version number
        /// </summary>
        public int Version;

        /// <summary>
        /// Published code revision for this Cloud Script version
        /// </summary>
        public int PublishedRevision;

        /// <summary>
        /// Most recent revision for this Cloud Script version
        /// </summary>
        public int LatestRevision;

    }

    public class ContentInfo
    {
        /// <summary>
        /// Key of the content
        /// </summary>
        public string Key;

        /// <summary>
        /// Size of the content in bytes
        /// </summary>
        public uint Size;

        /// <summary>
        /// Last modified time
        /// </summary>
        public DateTime LastModified;

    }

    public class CreatePlayerStatisticDefinitionRequest
    {
        /// <summary>
        /// unique name of the statistic
        /// </summary>
        public string StatisticName;

        /// <summary>
        /// interval at which the values of the statistic for all players are reset (resets begin at the next interval boundary)
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public StatisticResetIntervalOption? VersionChangeInterval;

        /// <summary>
        /// the aggregation method to use in updating the statistic (defaults to last)
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public StatisticAggregationMethod? AggregationMethod;

    }

    public class CreatePlayerStatisticDefinitionResult : PlayFabResultCommon
    {
        /// <summary>
        /// created statistic definition
        /// </summary>
        public PlayerStatisticDefinition Statistic;

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

    public class DeleteContentRequest
    {
        /// <summary>
        /// Key of the content item to be deleted
        /// </summary>
        public string Key;

    }

    public class DeleteStoreRequest
    {
        /// <summary>
        /// catalog version of the store to delete. If null, uses the default catalog.
        /// </summary>
        public string CatalogVersion;

        /// <summary>
        /// unqiue identifier for the store which is to be deleted
        /// </summary>
        public string StoreId;

    }

    public class DeleteStoreResult : PlayFabResultCommon
    {
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

    
    public enum GameBuildStatus
    {
        Available,
        Validating,
        InvalidBuildPackage,
        Processing,
        FailedToProcess
    }

    public class GameModeInfo
    {
        /// <summary>
        /// specific game mode type
        /// </summary>
        public string Gamemode;

        /// <summary>
        /// minimum user count required for this Game Server Instance to continue (usually 1)
        /// </summary>
        public uint MinPlayerCount;

        /// <summary>
        /// maximum user count a specific Game Server Instance can support
        /// </summary>
        public uint MaxPlayerCount;

        /// <summary>
        /// whether to start as an open session, meaning that players can matchmake into it (defaults to true)
        /// </summary>
        public bool? StartOpen;

    }

    public class GetActionGroupResult : PlayFabResultCommon
    {
        /// <summary>
        /// Action Group name
        /// </summary>
        public string Name;

        /// <summary>
        /// Action Group ID
        /// </summary>
        public string Id;

    }

    public class GetAllActionGroupsRequest
    {
    }

    public class GetAllActionGroupsResult : PlayFabResultCommon
    {
        /// <summary>
        /// List of Action Groups.
        /// </summary>
        public List<GetActionGroupResult> ActionGroups;

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

    public class GetCloudScriptRevisionRequest
    {
        /// <summary>
        /// Version number. If left null, defaults to the latest version
        /// </summary>
        public int? Version;

        /// <summary>
        /// Revision number. If left null, defaults to the latest revision
        /// </summary>
        public int? Revision;

    }

    public class GetCloudScriptRevisionResult : PlayFabResultCommon
    {
        /// <summary>
        /// Version number.
        /// </summary>
        public int Version;

        /// <summary>
        /// Revision number.
        /// </summary>
        public int Revision;

        /// <summary>
        /// Time this revision was created
        /// </summary>
        public DateTime CreatedAt;

        /// <summary>
        /// List of Cloud Script files in this revision.
        /// </summary>
        public List<CloudScriptFile> Files;

        /// <summary>
        /// True if this is the currently published revision
        /// </summary>
        public bool IsPublished;

    }

    public class GetCloudScriptVersionsRequest
    {
    }

    public class GetCloudScriptVersionsResult : PlayFabResultCommon
    {
        /// <summary>
        /// List of versions
        /// </summary>
        public List<CloudScriptVersionStatus> Versions;

    }

    public class GetContentListRequest
    {
        /// <summary>
        /// Limits the response to keys that begin with the specified prefix. You can use prefixes to list contents under a folder, or for a specified version, etc.
        /// </summary>
        public string Prefix;

    }

    public class GetContentListResult : PlayFabResultCommon
    {
        /// <summary>
        /// Number of content items returned. We currently have a maximum of 1000 items limit.
        /// </summary>
        public int ItemCount;

        /// <summary>
        /// The total size of listed contents in bytes.
        /// </summary>
        public uint TotalSize;

        /// <summary>
        /// List of content items.
        /// </summary>
        public List<ContentInfo> Contents;

    }

    public class GetContentUploadUrlRequest
    {
        /// <summary>
        /// Key of the content item to upload, usually formatted as a path, e.g. images/a.png
        /// </summary>
        public string Key;

        /// <summary>
        /// A standard MIME type describing the format of the contents. The same MIME type has to be set in the header when uploading the content. If not specified, the MIME type is 'binary/octet-stream' by default.
        /// </summary>
        public string ContentType;

    }

    public class GetContentUploadUrlResult : PlayFabResultCommon
    {
        /// <summary>
        /// URL for uploading content via HTTP PUT method. The URL will expire in 1 hour.
        /// </summary>
        public string URL;

    }

    public class GetDataReportRequest
    {
        /// <summary>
        /// Report name
        /// </summary>
        public string ReportName;

        /// <summary>
        /// Reporting year (UTC)
        /// </summary>
        public int Year;

        /// <summary>
        /// Reporting month (UTC)
        /// </summary>
        public int Month;

        /// <summary>
        /// Reporting year (UTC)
        /// </summary>
        public int Day;

    }

    public class GetDataReportResult : PlayFabResultCommon
    {
        /// <summary>
        /// The URL where the requested report can be downloaded.
        /// </summary>
        public string DownloadUrl;

    }

    public class GetMatchmakerGameInfoRequest
    {
        /// <summary>
        /// unique identifier of the lobby for which info is being requested
        /// </summary>
        public string LobbyId;

    }

    public class GetMatchmakerGameInfoResult : PlayFabResultCommon
    {
        /// <summary>
        /// unique identifier of the lobby 
        /// </summary>
        public string LobbyId;

        /// <summary>
        /// unique identifier of the Game Server Instance for this lobby
        /// </summary>
        public string TitleId;

        /// <summary>
        /// time when the Game Server Instance was created
        /// </summary>
        public DateTime StartTime;

        /// <summary>
        /// time when Game Server Instance is currently scheduled to end
        /// </summary>
        public DateTime? EndTime;

        /// <summary>
        /// game mode for this Game Server Instance
        /// </summary>
        public string Mode;

        /// <summary>
        /// version identifier of the game server executable binary being run
        /// </summary>
        public string BuildVersion;

        /// <summary>
        /// region in which the Game Server Instance is running
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public Region? Region;

        /// <summary>
        /// array of unique PlayFab identifiers for users currently connected to this Game Server Instance
        /// </summary>
        [Unordered]
        public List<string> Players;

        /// <summary>
        /// IP address for this Game Server Instance
        /// </summary>
        public string ServerAddress;

        /// <summary>
        /// communication port for this Game Server Instance
        /// </summary>
        public uint ServerPort;

    }

    public class GetMatchmakerGameModesRequest
    {
        /// <summary>
        /// previously uploaded build version for which game modes are being requested
        /// </summary>
        public string BuildVersion;

    }

    public class GetMatchmakerGameModesResult : PlayFabResultCommon
    {
        /// <summary>
        /// array of game modes available for the specified build
        /// </summary>
        public List<GameModeInfo> GameModes;

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

    public class GetPlayerStatisticDefinitionsRequest
    {
    }

    public class GetPlayerStatisticDefinitionsResult : PlayFabResultCommon
    {
        /// <summary>
        /// the player statistic definitions for the title
        /// </summary>
        public List<PlayerStatisticDefinition> Statistics;

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
        /// catalog version to fetch tables from. Use default catalog version if null
        /// </summary>
        public string CatalogVersion;

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

    public class GetServerBuildInfoRequest
    {
        /// <summary>
        /// unique identifier of the previously uploaded build executable for which information is being requested
        /// </summary>
        public string BuildId;

    }

    /// <summary>
    /// Information about a particular server build
    /// </summary>
    public class GetServerBuildInfoResult : PlayFabResultCommon, IComparable<GetServerBuildInfoResult>
    {
        /// <summary>
        /// unique identifier for this build executable
        /// </summary>
        public string BuildId;

        /// <summary>
        /// array of regions where this build can used, when it is active
        /// </summary>
        [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
        [Unordered]
        public List<Region> ActiveRegions;

        /// <summary>
        /// maximum number of game server instances that can run on a single host machine
        /// </summary>
        public int MaxGamesPerHost;

        /// <summary>
        /// minimum capacity of additional game server instances that can be started before the autoscaling service starts new host machines (given the number of current running host machines and game server instances)
        /// </summary>
        public int MinFreeGameSlots;

        /// <summary>
        /// developer comment(s) for this build
        /// </summary>
        public string Comment;

        /// <summary>
        /// time this build was last modified (or uploaded, if this build has never been modified)
        /// </summary>
        public DateTime Timestamp;

        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected.
        /// </summary>
        public string TitleId;

        /// <summary>
        /// the current status of the build validation and processing steps
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public GameBuildStatus? Status;

        /// <summary>
        /// error message, if any, about this build
        /// </summary>
        public string ErrorMessage;

        public int CompareTo(GetServerBuildInfoResult other)
        {
            if (other == null || other.BuildId == null) return 1;
            if (BuildId == null) return -1;
            return BuildId.CompareTo(other.BuildId);
        }

    }

    public class GetServerBuildUploadURLRequest
    {
        /// <summary>
        /// unique identifier of the game server build to upload
        /// </summary>
        public string BuildId;

    }

    public class GetServerBuildUploadURLResult : PlayFabResultCommon
    {
        /// <summary>
        /// pre-authorized URL for uploading the game server build package
        /// </summary>
        public string URL;

    }

    public class GetStoreItemsRequest
    {
        /// <summary>
        /// catalog version to store items from. Use default catalog version if null
        /// </summary>
        public string CatalogVersion;

        /// <summary>
        /// Unqiue identifier for the store which is being requested.
        /// </summary>
        public string StoreId;

    }

    public class GetStoreItemsResult : PlayFabResultCommon
    {
        /// <summary>
        /// Array of items which can be purchased from this store.
        /// </summary>
        [Unordered(SortProperty="ItemId")]
        public List<StoreItem> Store;

        /// <summary>
        /// How the store was last updated (Admin or a third party).
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public SourceType? Source;

        /// <summary>
        /// The base catalog that this store is a part of.
        /// </summary>
        public string CatalogVersion;

        /// <summary>
        /// The ID of this store.
        /// </summary>
        public string StoreId;

        /// <summary>
        /// Additional data about the store.
        /// </summary>
        public StoreMarketingModel MarketingData;

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

    public class IncrementPlayerStatisticVersionRequest
    {
        /// <summary>
        /// unique name of the statistic
        /// </summary>
        public string StatisticName;

    }

    public class IncrementPlayerStatisticVersionResult : PlayFabResultCommon
    {
        /// <summary>
        /// version change history of the statistic
        /// </summary>
        public PlayerStatisticVersion StatisticVersion;

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

    public class ListBuildsRequest
    {
    }

    public class ListBuildsResult : PlayFabResultCommon
    {
        /// <summary>
        /// array of uploaded game server builds
        /// </summary>
        [Unordered(SortProperty="BuildId")]
        public List<GetServerBuildInfoResult> Builds;

    }

    public class ListVirtualCurrencyTypesRequest
    {
    }

    public class ListVirtualCurrencyTypesResult : PlayFabResultCommon
    {
        /// <summary>
        /// List of virtual currency names defined for this title
        /// </summary>
        [Unordered]
        public List<VirtualCurrencyData> VirtualCurrencies;

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

    public class LookupUserAccountInfoRequest
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// User email address attached to their account
        /// </summary>
        public string Email;

        /// <summary>
        /// PlayFab username for the account (3-20 characters)
        /// </summary>
        public string Username;

        /// <summary>
        /// Title specific username to match against existing user accounts
        /// </summary>
        public string TitleDisplayName;

    }

    public class LookupUserAccountInfoResult : PlayFabResultCommon
    {
        /// <summary>
        /// User info for the user matching the request
        /// </summary>
        public UserAccountInfo UserInfo;

    }

    public class ModifyMatchmakerGameModesRequest
    {
        /// <summary>
        /// previously uploaded build version for which game modes are being specified
        /// </summary>
        public string BuildVersion;

        /// <summary>
        /// array of game modes (Note: this will replace all game modes for the indicated build version)
        /// </summary>
        public List<GameModeInfo> GameModes;

    }

    public class ModifyMatchmakerGameModesResult : PlayFabResultCommon
    {
    }

    public class ModifyServerBuildRequest
    {
        /// <summary>
        /// unique identifier of the previously uploaded build executable to be updated
        /// </summary>
        public string BuildId;

        /// <summary>
        /// new timestamp
        /// </summary>
        public DateTime? Timestamp;

        /// <summary>
        /// array of regions where this build can used, when it is active
        /// </summary>
        [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
        public List<Region> ActiveRegions;

        /// <summary>
        /// maximum number of game server instances that can run on a single host machine
        /// </summary>
        public int MaxGamesPerHost;

        /// <summary>
        /// minimum capacity of additional game server instances that can be started before the autoscaling service starts new host machines (given the number of current running host machines and game server instances)
        /// </summary>
        public int MinFreeGameSlots;

        /// <summary>
        /// appended to the end of the command line when starting game servers
        /// </summary>
        public string CommandLineTemplate;

        /// <summary>
        /// path to the game server executable. Defaults to gameserver.exe
        /// </summary>
        public string ExecutablePath;

        /// <summary>
        /// developer comment(s) for this build
        /// </summary>
        public string Comment;

    }

    public class ModifyServerBuildResult : PlayFabResultCommon
    {
        /// <summary>
        /// unique identifier for this build executable
        /// </summary>
        public string BuildId;

        /// <summary>
        /// array of regions where this build can used, when it is active
        /// </summary>
        [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
        public List<Region> ActiveRegions;

        /// <summary>
        /// maximum number of game server instances that can run on a single host machine
        /// </summary>
        public int MaxGamesPerHost;

        /// <summary>
        /// minimum capacity of additional game server instances that can be started before the autoscaling service starts new host machines (given the number of current running host machines and game server instances)
        /// </summary>
        public int MinFreeGameSlots;

        /// <summary>
        /// appended to the end of the command line when starting game servers
        /// </summary>
        public string CommandLineTemplate;

        /// <summary>
        /// path to the game server executable. Defaults to gameserver.exe
        /// </summary>
        public string ExecutablePath;

        /// <summary>
        /// developer comment(s) for this build
        /// </summary>
        public string Comment;

        /// <summary>
        /// time this build was last modified (or uploaded, if this build has never been modified)
        /// </summary>
        public DateTime Timestamp;

        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected.
        /// </summary>
        public string TitleId;

        /// <summary>
        /// the current status of the build validation and processing steps
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public GameBuildStatus? Status;

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
        /// A sum of player's total purchases in USD across all currencies.
        /// </summary>
        public uint? TotalValueToDateInUSD;

        /// <summary>
        /// Dictionary of player's total purchases by currency.
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

    public class PlayerStatisticDefinition
    {
        /// <summary>
        /// unique name of the statistic
        /// </summary>
        public string StatisticName;

        /// <summary>
        /// current active version of the statistic, incremented each time the statistic resets
        /// </summary>
        public uint CurrentVersion;

        /// <summary>
        /// interval at which the values of the statistic for all players are reset automatically
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public StatisticResetIntervalOption? VersionChangeInterval;

        /// <summary>
        /// the aggregation method to use in updating the statistic (defaults to last)
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public StatisticAggregationMethod? AggregationMethod;

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

        /// <summary>
        /// status of the process of saving player statistic values of the previous version to a downloadable archive
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public StatisticVersionArchivalStatus? ArchivalStatus;

        /// <summary>
        /// URL for the downloadable archive of player statistic values, if available
        /// </summary>
        public string ArchiveDownloadUrl;

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

    public class RandomResultTable : PlayFabResultCommon
    {
        /// <summary>
        /// Unique name for this drop table
        /// </summary>
        public string TableId;

        /// <summary>
        /// Child nodes that indicate what kind of drop table item this actually is.
        /// </summary>
        public List<ResultTableNode> Nodes;

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

    public class RemoveServerBuildRequest
    {
        /// <summary>
        /// unique identifier of the previously uploaded build executable to be removed
        /// </summary>
        public string BuildId;

    }

    public class RemoveServerBuildResult : PlayFabResultCommon
    {
    }

    public class RemoveVirtualCurrencyTypesRequest
    {
        /// <summary>
        /// List of virtual currencies to delete
        /// </summary>
        public List<VirtualCurrencyData> VirtualCurrencies;

    }

    public class ResetCharacterStatisticsRequest
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

    public class ResetCharacterStatisticsResult : PlayFabResultCommon
    {
    }

    public class ResetUsersRequest
    {
        /// <summary>
        /// Array of users to reset
        /// </summary>
        public List<UserCredentials> Users;

    }

    public class ResetUserStatisticsRequest
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

    }

    public class ResetUserStatisticsResult : PlayFabResultCommon
    {
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

    public class SendAccountRecoveryEmailRequest
    {
        /// <summary>
        /// User email address attached to their account
        /// </summary>
        public string Email;

    }

    public class SendAccountRecoveryEmailResult : PlayFabResultCommon
    {
    }

    public class SetPublishedRevisionRequest
    {
        /// <summary>
        /// Version number
        /// </summary>
        public int Version;

        /// <summary>
        /// Revision to make the current published revision
        /// </summary>
        public int Revision;

    }

    public class SetPublishedRevisionResult : PlayFabResultCommon
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

    public class SetupPushNotificationRequest
    {
        /// <summary>
        /// name of the application sending the message (application names must be made up of only uppercase and lowercase ASCII letters, numbers, underscores, hyphens, and periods, and must be between 1 and 256 characters long)
        /// </summary>
        public string Name;

        /// <summary>
        /// supported notification platforms are Apple Push Notification Service (APNS and APNS_SANDBOX) for iOS and Google Cloud Messaging (GCM) for Android
        /// </summary>
        public string Platform;

        /// <summary>
        /// for APNS, this is the PlatformPrincipal (SSL Certificate)
        /// </summary>
        public string Key;

        /// <summary>
        /// Credential is the Private Key for APNS/APNS_SANDBOX, and the API Key for GCM
        /// </summary>
        public string Credential;

        /// <summary>
        /// replace any existing ARN with the newly generated one. If this is set to false, an error will be returned if notifications have already setup for this platform.
        /// </summary>
        public bool OverwriteOldARN;

    }

    public class SetupPushNotificationResult : PlayFabResultCommon
    {
        /// <summary>
        /// Amazon Resource Name for the created notification topic.
        /// </summary>
        public string ARN;

    }

    
    public enum SourceType
    {
        Admin,
        BackEnd,
        GameClient,
        GameServer,
        Partner,
        Stream
    }

    
    public enum StatisticAggregationMethod
    {
        Last,
        Min,
        Max,
        Sum
    }

    
    public enum StatisticResetIntervalOption
    {
        Never,
        Hour,
        Day,
        Week,
        Month
    }

    
    public enum StatisticVersionArchivalStatus
    {
        NotScheduled,
        Scheduled,
        Queued,
        InProgress,
        Complete
    }

    /// <summary>
    /// A store entry that list a catalog item at a particular price
    /// </summary>
    public class StoreItem : IComparable<StoreItem>
    {
        /// <summary>
        /// Unique identifier of the item as it exists in the catalog - note that this must exactly match the ItemId from the catalog
        /// </summary>
        public string ItemId;

        /// <summary>
        /// Override prices for this item in virtual currencies and "RM" (the base Real Money purchase price, in USD pennies)
        /// </summary>
        public Dictionary<string,uint> VirtualCurrencyPrices;

        /// <summary>
        /// Override prices for this item for specific currencies
        /// </summary>
        public Dictionary<string,uint> RealCurrencyPrices;

        /// <summary>
        /// Store specific custom data. The data only exists as part of this store; it is not transferred to item instances
        /// </summary>
        public object CustomData;

        /// <summary>
        /// Intended display position for this item. Note that 0 is the first position
        /// </summary>
        public uint? DisplayPosition;

        public int CompareTo(StoreItem other)
        {
            if (other == null || other.ItemId == null) return 1;
            if (ItemId == null) return -1;
            return ItemId.CompareTo(other.ItemId);
        }

    }

    /// <summary>
    /// Marketing data about a specific store
    /// </summary>
    public class StoreMarketingModel
    {
        /// <summary>
        /// Display name of a store as it will appear to users.
        /// </summary>
        public string DisplayName;

        /// <summary>
        /// Tagline for a store.
        /// </summary>
        public string Description;

        /// <summary>
        /// Custom data about a store.
        /// </summary>
        public object Metadata;

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

    public class UpdateCatalogItemsRequest
    {
        /// <summary>
        /// Which catalog is being updated. If null, uses the default catalog.
        /// </summary>
        public string CatalogVersion;

        /// <summary>
        /// Should this catalog be set as the default catalog. Defaults to true. If there is currently no default catalog, this will always set it.
        /// </summary>
        public bool? SetAsDefaultCatalog;

        /// <summary>
        /// Array of catalog items to be submitted. Note that while CatalogItem has a parameter for CatalogVersion, it is not required and ignored in this call.
        /// </summary>
        public List<CatalogItem> Catalog;

    }

    public class UpdateCatalogItemsResult : PlayFabResultCommon
    {
    }

    public class UpdateCloudScriptRequest
    {
        /// <summary>
        /// Deprecated - Do not use
        /// </summary>
        [Obsolete("No longer available", true)]
        public int? Version;

        /// <summary>
        /// List of Cloud Script files to upload to create the new revision. Must have at least one file.
        /// </summary>
        public List<CloudScriptFile> Files;

        /// <summary>
        /// Immediately publish the new revision
        /// </summary>
        public bool Publish;

        /// <summary>
        /// PlayFab user ID of the developer initiating the request.
        /// </summary>
        public string DeveloperPlayFabId;

    }

    public class UpdateCloudScriptResult : PlayFabResultCommon
    {
        /// <summary>
        /// Cloud Script version updated
        /// </summary>
        public int Version;

        /// <summary>
        /// New revision number created
        /// </summary>
        public int Revision;

    }

    public class UpdatePlayerStatisticDefinitionRequest
    {
        /// <summary>
        /// unique name of the statistic
        /// </summary>
        public string StatisticName;

        /// <summary>
        /// interval at which the values of the statistic for all players are reset (changes are effective at the next occurance of the new interval boundary)
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public StatisticResetIntervalOption? VersionChangeInterval;

        /// <summary>
        /// the aggregation method to use in updating the statistic (defaults to last)
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public StatisticAggregationMethod? AggregationMethod;

    }

    public class UpdatePlayerStatisticDefinitionResult : PlayFabResultCommon
    {
        /// <summary>
        /// updated statistic definition
        /// </summary>
        public PlayerStatisticDefinition Statistic;

    }

    public class UpdateRandomResultTablesRequest : PlayFabResultCommon
    {
        /// <summary>
        /// which catalog is being updated. If null, update the current default catalog version
        /// </summary>
        public string CatalogVersion;

        /// <summary>
        /// array of random result tables to make available (Note: specifying an existing TableId will result in overwriting that table, while any others will be added to the available set)
        /// </summary>
        public List<RandomResultTable> Tables;

    }

    public class UpdateRandomResultTablesResult : PlayFabResultCommon
    {
    }

    public class UpdateStoreItemsRequest
    {
        /// <summary>
        /// Catalog version of the store to update. If null, uses the default catalog.
        /// </summary>
        public string CatalogVersion;

        /// <summary>
        /// Unique identifier for the store which is to be updated
        /// </summary>
        public string StoreId;

        /// <summary>
        /// Additional data about the store
        /// </summary>
        public StoreMarketingModel MarketingData;

        /// <summary>
        /// Array of store items - references to catalog items, with specific pricing - to be added
        /// </summary>
        public List<StoreItem> Store;

    }

    public class UpdateStoreItemsResult : PlayFabResultCommon
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

    public class UpdateUserTitleDisplayNameRequest
    {
        /// <summary>
        /// PlayFab unique identifier of the user whose title specific display name is to be changed
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// new title display name for the user - must be between 3 and 25 characters
        /// </summary>
        public string DisplayName;

    }

    public class UpdateUserTitleDisplayNameResult : PlayFabResultCommon
    {
        /// <summary>
        /// current title display name for the user (this will be the original display name if the rename attempt failed)
        /// </summary>
        public string DisplayName;

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

    public class UserCredentials
    {
        /// <summary>
        /// Username of user to reset
        /// </summary>
        public string Username;

        /// <summary>
        /// Password for the PlayFab account (6-100 characters)
        /// </summary>
        public string Password;

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

    public class VirtualCurrencyData
    {
        /// <summary>
        /// unique one- or two-character identifier for this currency type (e.g.: "CC", "G")
        /// </summary>
        public string CurrencyCode;

        /// <summary>
        /// friendly name to show in the developer portal, reports, etc.
        /// </summary>
        public string DisplayName;

        /// <summary>
        /// amount to automatically grant users upon first login to the title
        /// </summary>
        public int? InitialDeposit;

        /// <summary>
        /// rate at which the currency automatically be added to over time, in units per day (24 hours)
        /// </summary>
        public int? RechargeRate;

        /// <summary>
        /// maximum amount to which the currency will recharge (cannot exceed MaxAmount, but can be less)
        /// </summary>
        public int? RechargeMax;

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
}
