using PlayFab.Internal;
using System;
using System.Collections.Generic;

namespace PlayFab.AddonModels
{
    public class CreateOrUpdateAppleRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// iOS App Bundle ID obtained after setting up your app in the App Store.
        /// </summary>
        public string AppBundleId ;

        /// <summary>
        /// iOS App Shared Secret obtained after setting up your app in the App Store.
        /// </summary>
        public string AppSharedSecret ;

        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity ;

        /// <summary>
        /// If an error should be returned if the addon already exists.
        /// </summary>
        public bool? ErrorIfExists ;

        /// <summary>
        /// Ignore expiration date for identity tokens. Be aware that when set to true this can invalidate expired tokens in the
        /// case where Apple rotates their signing keys.
        /// </summary>
        public bool? IgnoreExpirationDate ;

        /// <summary>
        /// Require secure authentication only for this app.
        /// </summary>
        public bool? RequireSecureAuthentication ;

    }

    public class CreateOrUpdateAppleResponse : PlayFabResultCommon
    {
    }

    public class CreateOrUpdateFacebookInstantGamesRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Facebook App ID obtained after setting up your app in Facebook Instant Games.
        /// </summary>
        public string AppID ;

        /// <summary>
        /// Facebook App Secret obtained after setting up your app in Facebook Instant Games.
        /// </summary>
        public string AppSecret ;

        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity ;

        /// <summary>
        /// If an error should be returned if the addon already exists.
        /// </summary>
        public bool? ErrorIfExists ;

    }

    public class CreateOrUpdateFacebookInstantGamesResponse : PlayFabResultCommon
    {
    }

    public class CreateOrUpdateFacebookRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Facebook App ID obtained after setting up your app in Facebook.
        /// </summary>
        public string AppID ;

        /// <summary>
        /// Facebook App Secret obtained after setting up your app in Facebook.
        /// </summary>
        public string AppSecret ;

        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity ;

        /// <summary>
        /// If an error should be returned if the addon already exists.
        /// </summary>
        public bool? ErrorIfExists ;

        /// <summary>
        /// Email address for purchase dispute notifications.
        /// </summary>
        public string NotificationEmail ;

    }

    public class CreateOrUpdateFacebookResponse : PlayFabResultCommon
    {
    }

    public class CreateOrUpdateGoogleRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Google App License Key obtained after setting up your app in the Google Play developer portal. Required if using Google
        /// receipt validation.
        /// </summary>
        public string AppLicenseKey ;

        /// <summary>
        /// Google App Package ID obtained after setting up your app in the Google Play developer portal. Required if using Google
        /// receipt validation.
        /// </summary>
        public string AppPackageID ;

        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity ;

        /// <summary>
        /// If an error should be returned if the addon already exists.
        /// </summary>
        public bool? ErrorIfExists ;

        /// <summary>
        /// Google OAuth Client ID obtained through the Google Developer Console by creating a new set of "OAuth Client ID".
        /// Required if using Google Authentication.
        /// </summary>
        public string OAuthClientID ;

        /// <summary>
        /// Google OAuth Client Secret obtained through the Google Developer Console by creating a new set of "OAuth Client ID".
        /// Required if using Google Authentication.
        /// </summary>
        public string OAuthClientSecret ;

        /// <summary>
        /// Authorized Redirect Uri obtained through the Google Developer Console. This currently defaults to
        /// https://oauth.playfab.com/oauth2/google. If you are authenticating players via browser, please update this to your own
        /// domain.
        /// </summary>
        public string OAuthCustomRedirectUri ;

        /// <summary>
        /// Needed to enable pending purchase handling and subscription processing.
        /// </summary>
        public string ServiceAccountKey ;

    }

    public class CreateOrUpdateGoogleResponse : PlayFabResultCommon
    {
    }

    public class CreateOrUpdateKongregateRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity ;

        /// <summary>
        /// If an error should be returned if the addon already exists.
        /// </summary>
        public bool? ErrorIfExists ;

        /// <summary>
        /// Kongregate Secret API Key obtained after setting up your game in your Kongregate developer account.
        /// </summary>
        public string SecretAPIKey ;

    }

    public class CreateOrUpdateKongregateResponse : PlayFabResultCommon
    {
    }

    public class CreateOrUpdateNintendoRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Nintendo Switch Application ID, without the "0x" prefix.
        /// </summary>
        public string ApplicationID ;

        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity ;

        /// <summary>
        /// List of Nintendo Environments, currently supporting up to 4. Needs Catalog enabled.
        /// </summary>
        public List<NintendoEnvironment> Environments ;

        /// <summary>
        /// If an error should be returned if the addon already exists.
        /// </summary>
        public bool? ErrorIfExists ;

    }

    public class CreateOrUpdateNintendoResponse : PlayFabResultCommon
    {
    }

    public class CreateOrUpdatePSNRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Client ID obtained after setting up your game with Sony. This one is associated with the existing PS4 marketplace.
        /// </summary>
        public string ClientID ;

        /// <summary>
        /// Client secret obtained after setting up your game with Sony. This one is associated with the existing PS4 marketplace.
        /// </summary>
        public string ClientSecret ;

        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity ;

        /// <summary>
        /// If an error should be returned if the addon already exists.
        /// </summary>
        public bool? ErrorIfExists ;

        /// <summary>
        /// Client ID obtained after setting up your game with Sony. This one is associated with the modern marketplace, which
        /// includes PS5, cross-generation for PS4, and unified entitlements.
        /// </summary>
        public string NextGenClientID ;

        /// <summary>
        /// Client secret obtained after setting up your game with Sony. This one is associated with the modern marketplace, which
        /// includes PS5, cross-generation for PS4, and unified entitlements.
        /// </summary>
        public string NextGenClientSecret ;

    }

    public class CreateOrUpdatePSNResponse : PlayFabResultCommon
    {
    }

    public class CreateOrUpdateSteamRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Application ID obtained after setting up your app in Valve's developer portal.
        /// </summary>
        public string ApplicationId ;

        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// Enforce usage of AzurePlayFab identity in user authentication tickets.
        /// </summary>
        public bool? EnforceServiceSpecificTickets ;

        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity ;

        /// <summary>
        /// If an error should be returned if the addon already exists.
        /// </summary>
        public bool? ErrorIfExists ;

        /// <summary>
        /// Sercet Key obtained after setting up your app in Valve's developer portal.
        /// </summary>
        public string SecretKey ;

        /// <summary>
        /// Use Steam Payments sandbox endpoint for test transactions.
        /// </summary>
        public bool? UseSandbox ;

    }

    public class CreateOrUpdateSteamResponse : PlayFabResultCommon
    {
    }

    public class CreateOrUpdateToxModRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Account ID obtained after creating your ToxMod developer account.
        /// </summary>
        public string AccountId ;

        /// <summary>
        /// Account Key obtained after creating your ToxMod developer account.
        /// </summary>
        public string AccountKey ;

        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// Whether ToxMod Addon is Enabled by Title.
        /// </summary>
        public bool Enabled ;

        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity ;

        /// <summary>
        /// If an error should be returned if the addon already exists.
        /// </summary>
        public bool? ErrorIfExists ;

    }

    public class CreateOrUpdateToxModResponse : PlayFabResultCommon
    {
    }

    public class CreateOrUpdateTwitchRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Client ID obtained after creating your Twitch developer account.
        /// </summary>
        public string ClientID ;

        /// <summary>
        /// Client Secret obtained after creating your Twitch developer account.
        /// </summary>
        public string ClientSecret ;

        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity ;

        /// <summary>
        /// If an error should be returned if the addon already exists.
        /// </summary>
        public bool? ErrorIfExists ;

    }

    public class CreateOrUpdateTwitchResponse : PlayFabResultCommon
    {
    }

    public class DeleteAppleRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity ;

    }

    public class DeleteAppleResponse : PlayFabResultCommon
    {
    }

    public class DeleteFacebookInstantGamesRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity ;

    }

    public class DeleteFacebookInstantGamesResponse : PlayFabResultCommon
    {
    }

    public class DeleteFacebookRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity ;

    }

    public class DeleteFacebookResponse : PlayFabResultCommon
    {
    }

    public class DeleteGoogleRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity ;

    }

    public class DeleteGoogleResponse : PlayFabResultCommon
    {
    }

    public class DeleteKongregateRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity ;

    }

    public class DeleteKongregateResponse : PlayFabResultCommon
    {
    }

    public class DeleteNintendoRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity ;

    }

    public class DeleteNintendoResponse : PlayFabResultCommon
    {
    }

    public class DeletePSNRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity ;

    }

    public class DeletePSNResponse : PlayFabResultCommon
    {
    }

    public class DeleteSteamRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity ;

    }

    public class DeleteSteamResponse : PlayFabResultCommon
    {
    }

    public class DeleteToxModRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity ;

    }

    public class DeleteToxModResponse : PlayFabResultCommon
    {
    }

    public class DeleteTwitchRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity ;

    }

    public class DeleteTwitchResponse : PlayFabResultCommon
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

    public class GetAppleRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity ;

    }

    public class GetAppleResponse : PlayFabResultCommon
    {
        /// <summary>
        /// iOS App Bundle ID obtained after setting up your app in the App Store.
        /// </summary>
        public string AppBundleId ;

        /// <summary>
        /// Addon status.
        /// </summary>
        public bool Created ;

        /// <summary>
        /// Ignore expiration date for identity tokens.
        /// </summary>
        public bool? IgnoreExpirationDate ;

        /// <summary>
        /// Require secure authentication only for this app.
        /// </summary>
        public bool? RequireSecureAuthentication ;

    }

    public class GetFacebookInstantGamesRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity ;

    }

    public class GetFacebookInstantGamesResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Facebook App ID obtained after setting up your app in Facebook Instant Games.
        /// </summary>
        public string AppID ;

        /// <summary>
        /// Addon status.
        /// </summary>
        public bool Created ;

    }

    public class GetFacebookRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity ;

    }

    public class GetFacebookResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Facebook App ID obtained after setting up your app in Facebook.
        /// </summary>
        public string AppID ;

        /// <summary>
        /// Addon status.
        /// </summary>
        public bool Created ;

        /// <summary>
        /// Email address for purchase dispute notifications.
        /// </summary>
        public string NotificationEmail ;

    }

    public class GetGoogleRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity ;

    }

    public class GetGoogleResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Google App Package ID obtained after setting up your app in the Google Play developer portal. Required if using Google
        /// receipt validation.
        /// </summary>
        public string AppPackageID ;

        /// <summary>
        /// Addon status.
        /// </summary>
        public bool Created ;

        /// <summary>
        /// Google OAuth Client ID obtained through the Google Developer Console by creating a new set of "OAuth Client ID".
        /// Required if using Google Authentication.
        /// </summary>
        public string OAuthClientID ;

        /// <summary>
        /// Authorized Redirect Uri obtained through the Google Developer Console. This currently defaults to
        /// https://oauth.playfab.com/oauth2/google. If you are authenticating players via browser, please update this to your own
        /// domain.
        /// </summary>
        public string OauthCustomRedirectUri ;

    }

    public class GetKongregateRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity ;

    }

    public class GetKongregateResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Addon status.
        /// </summary>
        public bool Created ;

    }

    public class GetNintendoRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity ;

    }

    public class GetNintendoResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Nintendo Switch Application ID, without the "0x" prefix.
        /// </summary>
        public string ApplicationID ;

        /// <summary>
        /// Addon status.
        /// </summary>
        public bool Created ;

        /// <summary>
        /// List of Nintendo Environments, currently supporting up to 4.
        /// </summary>
        public List<NintendoEnvironment> Environments ;

    }

    public class GetPSNRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity ;

    }

    public class GetPSNResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Client ID obtained after setting up your game with Sony. This one is associated with the existing PS4 marketplace.
        /// </summary>
        public string ClientID ;

        /// <summary>
        /// Addon status.
        /// </summary>
        public bool Created ;

        /// <summary>
        /// Client ID obtained after setting up your game with Sony. This one is associated with the modern marketplace, which
        /// includes PS5, cross-generation for PS4, and unified entitlements.
        /// </summary>
        public string NextGenClientID ;

    }

    public class GetSteamRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity ;

    }

    public class GetSteamResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Application ID obtained after setting up your game in Valve's developer portal.
        /// </summary>
        public string ApplicationId ;

        /// <summary>
        /// Addon status.
        /// </summary>
        public bool Created ;

        /// <summary>
        /// Enforce usage of AzurePlayFab identity in user authentication tickets.
        /// </summary>
        public bool? EnforceServiceSpecificTickets ;

        /// <summary>
        /// Use Steam Payments sandbox endpoint for test transactions.
        /// </summary>
        public bool? UseSandbox ;

    }

    public class GetToxModRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity ;

    }

    public class GetToxModResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Account ID obtained after creating your Twitch developer account.
        /// </summary>
        public string AccountId ;

        /// <summary>
        /// Account Key obtained after creating your Twitch developer account.
        /// </summary>
        public string AccountKey ;

        /// <summary>
        /// Addon status.
        /// </summary>
        public bool Created ;

        /// <summary>
        /// Whether the ToxMod Addon is enabled by the title.
        /// </summary>
        public bool Enabled ;

    }

    public class GetTwitchRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity ;

    }

    public class GetTwitchResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Client ID obtained after creating your Twitch developer account.
        /// </summary>
        public string ClientID ;

        /// <summary>
        /// Addon status.
        /// </summary>
        public bool Created ;

    }

    public class NintendoEnvironment
    {
        /// <summary>
        /// Client ID for the Nintendo Environment.
        /// </summary>
        public string ClientID ;

        /// <summary>
        /// Client Secret for the Nintendo Environment.
        /// </summary>
        public string ClientSecret ;

        /// <summary>
        /// ID for the Nintendo Environment.
        /// </summary>
        public string ID ;

    }
}
