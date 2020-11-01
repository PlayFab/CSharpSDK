using PlayFab.Internal;
using System;
using System.Collections.Generic;

namespace PlayFab.CloudScriptModels
{
    public class AdCampaignAttributionModel
    {
        /// <summary>
        /// UTC time stamp of attribution
        /// </summary>
        public DateTime AttributedAt ;

        /// <summary>
        /// Attribution campaign identifier
        /// </summary>
        public string CampaignId ;

        /// <summary>
        /// Attribution network name
        /// </summary>
        public string Platform ;

    }

    public enum CloudScriptRevisionOption
    {
        Live,
        Latest,
        Specific
    }

    public class ContactEmailInfoModel
    {
        /// <summary>
        /// The email address
        /// </summary>
        public string EmailAddress ;

        /// <summary>
        /// The name of the email info data
        /// </summary>
        public string Name ;

        /// <summary>
        /// The verification status of the email
        /// </summary>
        public EmailVerificationStatus? VerificationStatus ;

    }

    public enum ContinentCode
    {
        AF,
        AN,
        AS,
        EU,
        NA,
        OC,
        SA
    }

    public enum CountryCode
    {
        AF,
        AX,
        AL,
        DZ,
        AS,
        AD,
        AO,
        AI,
        AQ,
        AG,
        AR,
        AM,
        AW,
        AU,
        AT,
        AZ,
        BS,
        BH,
        BD,
        BB,
        BY,
        BE,
        BZ,
        BJ,
        BM,
        BT,
        BO,
        BQ,
        BA,
        BW,
        BV,
        BR,
        IO,
        BN,
        BG,
        BF,
        BI,
        KH,
        CM,
        CA,
        CV,
        KY,
        CF,
        TD,
        CL,
        CN,
        CX,
        CC,
        CO,
        KM,
        CG,
        CD,
        CK,
        CR,
        CI,
        HR,
        CU,
        CW,
        CY,
        CZ,
        DK,
        DJ,
        DM,
        DO,
        EC,
        EG,
        SV,
        GQ,
        ER,
        EE,
        ET,
        FK,
        FO,
        FJ,
        FI,
        FR,
        GF,
        PF,
        TF,
        GA,
        GM,
        GE,
        DE,
        GH,
        GI,
        GR,
        GL,
        GD,
        GP,
        GU,
        GT,
        GG,
        GN,
        GW,
        GY,
        HT,
        HM,
        VA,
        HN,
        HK,
        HU,
        IS,
        IN,
        ID,
        IR,
        IQ,
        IE,
        IM,
        IL,
        IT,
        JM,
        JP,
        JE,
        JO,
        KZ,
        KE,
        KI,
        KP,
        KR,
        KW,
        KG,
        LA,
        LV,
        LB,
        LS,
        LR,
        LY,
        LI,
        LT,
        LU,
        MO,
        MK,
        MG,
        MW,
        MY,
        MV,
        ML,
        MT,
        MH,
        MQ,
        MR,
        MU,
        YT,
        MX,
        FM,
        MD,
        MC,
        MN,
        ME,
        MS,
        MA,
        MZ,
        MM,
        NA,
        NR,
        NP,
        NL,
        NC,
        NZ,
        NI,
        NE,
        NG,
        NU,
        NF,
        MP,
        NO,
        OM,
        PK,
        PW,
        PS,
        PA,
        PG,
        PY,
        PE,
        PH,
        PN,
        PL,
        PT,
        PR,
        QA,
        RE,
        RO,
        RU,
        RW,
        BL,
        SH,
        KN,
        LC,
        MF,
        PM,
        VC,
        WS,
        SM,
        ST,
        SA,
        SN,
        RS,
        SC,
        SL,
        SG,
        SX,
        SK,
        SI,
        SB,
        SO,
        ZA,
        GS,
        SS,
        ES,
        LK,
        SD,
        SR,
        SJ,
        SZ,
        SE,
        CH,
        SY,
        TW,
        TJ,
        TZ,
        TH,
        TL,
        TG,
        TK,
        TO,
        TT,
        TN,
        TR,
        TM,
        TC,
        TV,
        UG,
        UA,
        AE,
        GB,
        US,
        UM,
        UY,
        UZ,
        VU,
        VE,
        VN,
        VG,
        VI,
        WF,
        EH,
        YE,
        ZM,
        ZW
    }

    public enum EmailVerificationStatus
    {
        Unverified,
        Pending,
        Confirmed
    }

    public class EmptyResult : PlayFabResultCommon
    {
    }

    /// <summary>
    /// Combined entity type and ID structure which uniquely identifies a single entity.
    /// </summary>
    public class EntityKey
    {
        /// <summary>
        /// Unique ID of the entity.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Entity type. See https://docs.microsoft.com/gaming/playfab/features/data/entities/available-built-in-entity-types
        /// </summary>
        public string Type { get; set; }

    }

    public class ExecuteCloudScriptResult : PlayFabResultCommon
    {
        /// <summary>
        /// Number of PlayFab API requests issued by the CloudScript function
        /// </summary>
        public int APIRequestsIssued ;

        /// <summary>
        /// Information about the error, if any, that occurred during execution
        /// </summary>
        public ScriptExecutionError Error ;

        public double ExecutionTimeSeconds ;

        /// <summary>
        /// The name of the function that executed
        /// </summary>
        public string FunctionName ;

        /// <summary>
        /// The object returned from the CloudScript function, if any
        /// </summary>
        public object FunctionResult ;

        /// <summary>
        /// Flag indicating if the FunctionResult was too large and was subsequently dropped from this event. This only occurs if
        /// the total event size is larger than 350KB.
        /// </summary>
        public bool? FunctionResultTooLarge ;

        /// <summary>
        /// Number of external HTTP requests issued by the CloudScript function
        /// </summary>
        public int HttpRequestsIssued ;

        /// <summary>
        /// Entries logged during the function execution. These include both entries logged in the function code using log.info()
        /// and log.error() and error entries for API and HTTP request failures.
        /// </summary>
        public List<LogStatement> Logs ;

        /// <summary>
        /// Flag indicating if the logs were too large and were subsequently dropped from this event. This only occurs if the total
        /// event size is larger than 350KB after the FunctionResult was removed.
        /// </summary>
        public bool? LogsTooLarge ;

        public uint MemoryConsumedBytes ;

        /// <summary>
        /// Processor time consumed while executing the function. This does not include time spent waiting on API calls or HTTP
        /// requests.
        /// </summary>
        public double ProcessorTimeSeconds ;

        /// <summary>
        /// The revision of the CloudScript that executed
        /// </summary>
        public int Revision ;

    }

    /// <summary>
    /// Executes CloudScript with the entity profile that is defined in the request.
    /// </summary>
    public class ExecuteEntityCloudScriptRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity ;

        /// <summary>
        /// The name of the CloudScript function to execute
        /// </summary>
        public string FunctionName ;

        /// <summary>
        /// Object that is passed in to the function as the first argument
        /// </summary>
        public object FunctionParameter ;

        /// <summary>
        /// Generate a 'entity_executed_cloudscript' PlayStream event containing the results of the function execution and other
        /// contextual information. This event will show up in the PlayStream debugger console for the player in Game Manager.
        /// </summary>
        public bool? GeneratePlayStreamEvent ;

        /// <summary>
        /// Option for which revision of the CloudScript to execute. 'Latest' executes the most recently created revision, 'Live'
        /// executes the current live, published revision, and 'Specific' executes the specified revision. The default value is
        /// 'Specific', if the SpecificRevision parameter is specified, otherwise it is 'Live'.
        /// </summary>
        public CloudScriptRevisionOption? RevisionSelection ;

        /// <summary>
        /// The specific revision to execute, when RevisionSelection is set to 'Specific'
        /// </summary>
        public int? SpecificRevision ;

    }

    /// <summary>
    /// Executes an Azure Function with the profile of the entity that is defined in the request.
    /// </summary>
    public class ExecuteFunctionRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags { get; set; }

        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity { get; set; }

        /// <summary>
        /// The name of the CloudScript function to execute
        /// </summary>
        public string FunctionName { get; set; }

        /// <summary>
        /// Object that is passed in to the function as the FunctionArgument field of the FunctionExecutionContext data structure
        /// </summary>
        public object FunctionParameter { get; set; }

        /// <summary>
        /// Generate a 'entity_executed_cloudscript_function' PlayStream event containing the results of the function execution and
        /// other contextual information. This event will show up in the PlayStream debugger console for the player in Game Manager.
        /// </summary>
        public bool? GeneratePlayStreamEvent { get; set; }

    }

    public class ExecuteFunctionResult : PlayFabResultCommon
    {
        /// <summary>
        /// Error from the CloudScript Azure Function.
        /// </summary>
        public FunctionExecutionError Error ;

        /// <summary>
        /// The amount of time the function took to execute
        /// </summary>
        public int ExecutionTimeMilliseconds ;

        /// <summary>
        /// The name of the function that executed
        /// </summary>
        public string FunctionName ;

        /// <summary>
        /// The object returned from the function, if any
        /// </summary>
        public object FunctionResult ;

        /// <summary>
        /// Flag indicating if the FunctionResult was too large and was subsequently dropped from this event.
        /// </summary>
        public bool? FunctionResultTooLarge ;

    }

    public class FunctionExecutionError
    {
        /// <summary>
        /// Error code, such as CloudScriptAzureFunctionsExecutionTimeLimitExceeded, CloudScriptAzureFunctionsArgumentSizeExceeded,
        /// CloudScriptAzureFunctionsReturnSizeExceeded or CloudScriptAzureFunctionsHTTPRequestError
        /// </summary>
        public string Error ;

        /// <summary>
        /// Details about the error
        /// </summary>
        public string Message ;

        /// <summary>
        /// Point during the execution of the function at which the error occurred, if any
        /// </summary>
        public string StackTrace ;

    }

    public class FunctionModel
    {
        /// <summary>
        /// The address of the function.
        /// </summary>
        public string FunctionAddress ;

        /// <summary>
        /// The name the function was registered under.
        /// </summary>
        public string FunctionName ;

        /// <summary>
        /// The trigger type for the function.
        /// </summary>
        public string TriggerType ;

    }

    public class HttpFunctionModel
    {
        /// <summary>
        /// The name the function was registered under.
        /// </summary>
        public string FunctionName ;

        /// <summary>
        /// The URL of the function.
        /// </summary>
        public string FunctionUrl ;

    }

    public class LinkedPlatformAccountModel
    {
        /// <summary>
        /// Linked account email of the user on the platform, if available
        /// </summary>
        public string Email ;

        /// <summary>
        /// Authentication platform
        /// </summary>
        public LoginIdentityProvider? Platform ;

        /// <summary>
        /// Unique account identifier of the user on the platform
        /// </summary>
        public string PlatformUserId ;

        /// <summary>
        /// Linked account username of the user on the platform, if available
        /// </summary>
        public string Username ;

    }

    /// <summary>
    /// A title can have many functions, ListHttpFunctions will return a list of all the currently registered HTTP triggered
    /// functions for a given title.
    /// </summary>
    public class ListFunctionsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

    }

    public class ListFunctionsResult : PlayFabResultCommon
    {
        /// <summary>
        /// The list of functions that are currently registered for the title.
        /// </summary>
        public List<FunctionModel> Functions ;

    }

    public class ListHttpFunctionsResult : PlayFabResultCommon
    {
        /// <summary>
        /// The list of HTTP triggered functions that are currently registered for the title.
        /// </summary>
        public List<HttpFunctionModel> Functions ;

    }

    public class ListQueuedFunctionsResult : PlayFabResultCommon
    {
        /// <summary>
        /// The list of Queue triggered functions that are currently registered for the title.
        /// </summary>
        public List<QueuedFunctionModel> Functions ;

    }

    public class LocationModel
    {
        /// <summary>
        /// City name.
        /// </summary>
        public string City ;

        /// <summary>
        /// The two-character continent code for this location
        /// </summary>
        public ContinentCode? ContinentCode ;

        /// <summary>
        /// The two-character ISO 3166-1 country code for the country associated with the location
        /// </summary>
        public CountryCode? CountryCode ;

        /// <summary>
        /// Latitude coordinate of the geographic location.
        /// </summary>
        public double? Latitude ;

        /// <summary>
        /// Longitude coordinate of the geographic location.
        /// </summary>
        public double? Longitude ;

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
        Twitch,
        WindowsHello,
        GameServer,
        CustomServer,
        NintendoSwitch,
        FacebookInstantGames,
        OpenIdConnect,
        Apple,
        NintendoSwitchAccount
    }

    public class LogStatement
    {
        /// <summary>
        /// Optional object accompanying the message as contextual information
        /// </summary>
        public object Data ;

        /// <summary>
        /// 'Debug', 'Info', or 'Error'
        /// </summary>
        public string Level ;

        public string Message ;

    }

    public class MembershipModel
    {
        /// <summary>
        /// Whether this membership is active. That is, whether the MembershipExpiration time has been reached.
        /// </summary>
        public bool IsActive ;

        /// <summary>
        /// The time this membership expires
        /// </summary>
        public DateTime MembershipExpiration ;

        /// <summary>
        /// The id of the membership
        /// </summary>
        public string MembershipId ;

        /// <summary>
        /// Membership expirations can be explicitly overridden (via game manager or the admin api). If this membership has been
        /// overridden, this will be the new expiration time.
        /// </summary>
        public DateTime? OverrideExpiration ;

        /// <summary>
        /// The list of subscriptions that this player has for this membership
        /// </summary>
        public List<SubscriptionModel> Subscriptions ;

    }

    /// <summary>
    /// Identifier by either name or ID. Note that a name may change due to renaming, or reused after being deleted. ID is
    /// immutable and unique.
    /// </summary>
    public class NameIdentifier
    {
        /// <summary>
        /// Id Identifier, if present
        /// </summary>
        public string Id ;

        /// <summary>
        /// Name Identifier, if present
        /// </summary>
        public string Name ;

    }

    public class PlayerProfileModel
    {
        /// <summary>
        /// List of advertising campaigns the player has been attributed to
        /// </summary>
        public List<AdCampaignAttributionModel> AdCampaignAttributions ;

        /// <summary>
        /// URL of the player's avatar image
        /// </summary>
        public string AvatarUrl ;

        /// <summary>
        /// If the player is currently banned, the UTC Date when the ban expires
        /// </summary>
        public DateTime? BannedUntil ;

        /// <summary>
        /// List of all contact email info associated with the player account
        /// </summary>
        public List<ContactEmailInfoModel> ContactEmailAddresses ;

        /// <summary>
        /// Player record created
        /// </summary>
        public DateTime? Created ;

        /// <summary>
        /// Player display name
        /// </summary>
        public string DisplayName ;

        /// <summary>
        /// List of experiment variants for the player.
        /// </summary>
        public List<string> ExperimentVariants ;

        /// <summary>
        /// UTC time when the player most recently logged in to the title
        /// </summary>
        public DateTime? LastLogin ;

        /// <summary>
        /// List of all authentication systems linked to this player account
        /// </summary>
        public List<LinkedPlatformAccountModel> LinkedAccounts ;

        /// <summary>
        /// List of geographic locations from which the player has logged in to the title
        /// </summary>
        public List<LocationModel> Locations ;

        /// <summary>
        /// List of memberships for the player, along with whether are expired.
        /// </summary>
        public List<MembershipModel> Memberships ;

        /// <summary>
        /// Player account origination
        /// </summary>
        public LoginIdentityProvider? Origination ;

        /// <summary>
        /// PlayFab player account unique identifier
        /// </summary>
        public string PlayerId ;

        /// <summary>
        /// Publisher this player belongs to
        /// </summary>
        public string PublisherId ;

        /// <summary>
        /// List of configured end points registered for sending the player push notifications
        /// </summary>
        public List<PushNotificationRegistrationModel> PushNotificationRegistrations ;

        /// <summary>
        /// List of leaderboard statistic values for the player
        /// </summary>
        public List<StatisticModel> Statistics ;

        /// <summary>
        /// List of player's tags for segmentation
        /// </summary>
        public List<TagModel> Tags ;

        /// <summary>
        /// Title ID this player profile applies to
        /// </summary>
        public string TitleId ;

        /// <summary>
        /// Sum of the player's purchases made with real-money currencies, converted to US dollars equivalent and represented as a
        /// whole number of cents (1/100 USD). For example, 999 indicates nine dollars and ninety-nine cents.
        /// </summary>
        public uint? TotalValueToDateInUSD ;

        /// <summary>
        /// List of the player's lifetime purchase totals, summed by real-money currency
        /// </summary>
        public List<ValueToDateModel> ValuesToDate ;

    }

    public class PlayStreamEventEnvelopeModel
    {
        /// <summary>
        /// The ID of the entity the event is about.
        /// </summary>
        public string EntityId ;

        /// <summary>
        /// The type of the entity the event is about.
        /// </summary>
        public string EntityType ;

        /// <summary>
        /// Data specific to this event.
        /// </summary>
        public string EventData ;

        /// <summary>
        /// The name of the event.
        /// </summary>
        public string EventName ;

        /// <summary>
        /// The namespace of the event.
        /// </summary>
        public string EventNamespace ;

        /// <summary>
        /// Settings for the event.
        /// </summary>
        public string EventSettings ;

    }

    public class PostFunctionResultForEntityTriggeredActionRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity ;

        /// <summary>
        /// The result of the function execution.
        /// </summary>
        public ExecuteFunctionResult FunctionResult ;

    }

    public class PostFunctionResultForFunctionExecutionRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity ;

        /// <summary>
        /// The result of the function execution.
        /// </summary>
        public ExecuteFunctionResult FunctionResult ;

    }

    public class PostFunctionResultForPlayerTriggeredActionRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity ;

        /// <summary>
        /// The result of the function execution.
        /// </summary>
        public ExecuteFunctionResult FunctionResult ;

        /// <summary>
        /// The player profile the function was invoked with.
        /// </summary>
        public PlayerProfileModel PlayerProfile ;

        /// <summary>
        /// The triggering PlayStream event, if any, that caused the function to be invoked.
        /// </summary>
        public PlayStreamEventEnvelopeModel PlayStreamEventEnvelope ;

    }

    public class PostFunctionResultForScheduledTaskRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity ;

        /// <summary>
        /// The result of the function execution
        /// </summary>
        public ExecuteFunctionResult FunctionResult ;

        /// <summary>
        /// The id of the scheduled task that invoked the function.
        /// </summary>
        public NameIdentifier ScheduledTaskId ;

    }

    public enum PushNotificationPlatform
    {
        ApplePushNotificationService,
        GoogleCloudMessaging
    }

    public class PushNotificationRegistrationModel
    {
        /// <summary>
        /// Notification configured endpoint
        /// </summary>
        public string NotificationEndpointARN ;

        /// <summary>
        /// Push notification platform
        /// </summary>
        public PushNotificationPlatform? Platform ;

    }

    public class QueuedFunctionModel
    {
        /// <summary>
        /// The connection string for the Azure Storage Account that hosts the queue.
        /// </summary>
        public string ConnectionString ;

        /// <summary>
        /// The name the function was registered under.
        /// </summary>
        public string FunctionName ;

        /// <summary>
        /// The name of the queue that triggers the Azure Function.
        /// </summary>
        public string QueueName ;

    }

    public class RegisterHttpFunctionRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The name of the function to register
        /// </summary>
        public string FunctionName ;

        /// <summary>
        /// Full URL for Azure Function that implements the function.
        /// </summary>
        public string FunctionUrl ;

    }

    /// <summary>
    /// A title can have many functions, RegisterQueuedFunction associates a function name with a queue name and connection
    /// string.
    /// </summary>
    public class RegisterQueuedFunctionRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// A connection string for the storage account that hosts the queue for the Azure Function.
        /// </summary>
        public string ConnectionString ;

        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The name of the function to register
        /// </summary>
        public string FunctionName ;

        /// <summary>
        /// The name of the queue for the Azure Function.
        /// </summary>
        public string QueueName ;

    }

    public class ScriptExecutionError
    {
        /// <summary>
        /// Error code, such as CloudScriptNotFound, JavascriptException, CloudScriptFunctionArgumentSizeExceeded,
        /// CloudScriptAPIRequestCountExceeded, CloudScriptAPIRequestError, or CloudScriptHTTPRequestError
        /// </summary>
        public string Error ;

        /// <summary>
        /// Details about the error
        /// </summary>
        public string Message ;

        /// <summary>
        /// Point during the execution of the script at which the error occurred, if any
        /// </summary>
        public string StackTrace ;

    }

    public class StatisticModel
    {
        /// <summary>
        /// Statistic name
        /// </summary>
        public string Name ;

        /// <summary>
        /// Statistic value
        /// </summary>
        public int Value ;

        /// <summary>
        /// Statistic version (0 if not a versioned statistic)
        /// </summary>
        public int Version ;

    }

    public class SubscriptionModel
    {
        /// <summary>
        /// When this subscription expires.
        /// </summary>
        public DateTime Expiration ;

        /// <summary>
        /// The time the subscription was orignially purchased
        /// </summary>
        public DateTime InitialSubscriptionTime ;

        /// <summary>
        /// Whether this subscription is currently active. That is, if Expiration > now.
        /// </summary>
        public bool IsActive ;

        /// <summary>
        /// The status of this subscription, according to the subscription provider.
        /// </summary>
        public SubscriptionProviderStatus? Status ;

        /// <summary>
        /// The id for this subscription
        /// </summary>
        public string SubscriptionId ;

        /// <summary>
        /// The item id for this subscription from the primary catalog
        /// </summary>
        public string SubscriptionItemId ;

        /// <summary>
        /// The provider for this subscription. Apple or Google Play are supported today.
        /// </summary>
        public string SubscriptionProvider ;

    }

    public enum SubscriptionProviderStatus
    {
        NoError,
        Cancelled,
        UnknownError,
        BillingError,
        ProductUnavailable,
        CustomerDidNotAcceptPriceChange,
        FreeTrial,
        PaymentPending
    }

    public class TagModel
    {
        /// <summary>
        /// Full value of the tag, including namespace
        /// </summary>
        public string TagValue ;

    }

    public enum TriggerType
    {
        HTTP,
        Queue
    }

    public class UnregisterFunctionRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The name of the function to unregister
        /// </summary>
        public string FunctionName ;

    }

    public class ValueToDateModel
    {
        /// <summary>
        /// ISO 4217 code of the currency used in the purchases
        /// </summary>
        public string Currency ;

        /// <summary>
        /// Total value of the purchases in a whole number of 1/100 monetary units. For example, 999 indicates nine dollars and
        /// ninety-nine cents when Currency is 'USD')
        /// </summary>
        public uint TotalValue ;

        /// <summary>
        /// Total value of the purchases in a string representation of decimal monetary units. For example, '9.99' indicates nine
        /// dollars and ninety-nine cents when Currency is 'USD'.
        /// </summary>
        public string TotalValueAsDecimal ;

    }
}
