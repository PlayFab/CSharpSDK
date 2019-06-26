#if !DISABLE_PLAYFABCLIENT_API

using PlayFab.ClientModels;
using PlayFab.Internal;
using PlayFab.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayFab
{
    /// <summary>
    /// APIs which provide the full range of PlayFab features available to the client - authentication, account and data
    /// management, inventory, friends, matchmaking, reporting, and platform-specific functionality
    /// </summary>
    public class PlayFabClientInstanceAPI
    {
        public readonly PlayFabApiSettings apiSettings = null;
        public readonly PlayFabAuthenticationContext authenticationContext = null;

        public PlayFabClientInstanceAPI()
        {
            authenticationContext = new PlayFabAuthenticationContext();
        }

        public PlayFabClientInstanceAPI(PlayFabApiSettings settings)
        {
            apiSettings = settings;
            authenticationContext = new PlayFabAuthenticationContext();
        }

        public PlayFabClientInstanceAPI(PlayFabAuthenticationContext context)
        {
            authenticationContext = context ?? new PlayFabAuthenticationContext();
        }

        public PlayFabClientInstanceAPI(PlayFabApiSettings settings, PlayFabAuthenticationContext context)
        {
            apiSettings = settings;
            authenticationContext = context ?? new PlayFabAuthenticationContext();
        }

        /// <summary>
        /// Verify client login.
        /// </summary>
        public bool IsClientLoggedIn()
        {
            return authenticationContext == null ? false : authenticationContext.IsClientLoggedIn();
        }

        /// <summary>
        /// Clear the Client SessionToken which allows this Client to call API calls requiring login.
        /// A new/fresh login will be required after calling this.
        /// </summary>
        public void ForgetAllCredentials()
        {
            authenticationContext?.ForgetAllCredentials();
        }

        /// <summary>
        /// Accepts an open trade (one that has not yet been accepted or cancelled), if the locally signed-in player is in the
        /// allowed player list for the trade, or it is open to all players. If the call is successful, the offered and accepted
        /// items will be swapped between the two players' inventories.
        /// </summary>
        public async Task<PlayFabResult<AcceptTradeResponse>> AcceptTradeAsync(AcceptTradeRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/AcceptTrade", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<AcceptTradeResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<AcceptTradeResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<AcceptTradeResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Adds the PlayFab user, based upon a match against a supplied unique identifier, to the friend list of the local user. At
        /// least one of FriendPlayFabId,FriendUsername,FriendEmail, or FriendTitleDisplayName should be initialized.
        /// </summary>
        public async Task<PlayFabResult<AddFriendResult>> AddFriendAsync(AddFriendRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/AddFriend", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<AddFriendResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<AddFriendResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<AddFriendResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Adds the specified generic service identifier to the player's PlayFab account. This is designed to allow for a PlayFab
        /// ID lookup of any arbitrary service identifier a title wants to add. This identifier should never be used as
        /// authentication credentials, as the intent is that it is easily accessible by other players.
        /// </summary>
        public async Task<PlayFabResult<AddGenericIDResult>> AddGenericIDAsync(AddGenericIDRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/AddGenericID", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<AddGenericIDResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<AddGenericIDResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<AddGenericIDResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Adds or updates a contact email to the player's profile.
        /// </summary>
        public async Task<PlayFabResult<AddOrUpdateContactEmailResult>> AddOrUpdateContactEmailAsync(AddOrUpdateContactEmailRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/AddOrUpdateContactEmail", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<AddOrUpdateContactEmailResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<AddOrUpdateContactEmailResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<AddOrUpdateContactEmailResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Adds users to the set of those able to update both the shared data, as well as the set of users in the group. Only users
        /// in the group can add new members. Shared Groups are designed for sharing data between a very small number of players,
        /// please see our guide: https://api.playfab.com/docs/tutorials/landing-players/shared-groups
        /// </summary>
        public async Task<PlayFabResult<AddSharedGroupMembersResult>> AddSharedGroupMembersAsync(AddSharedGroupMembersRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/AddSharedGroupMembers", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<AddSharedGroupMembersResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<AddSharedGroupMembersResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<AddSharedGroupMembersResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Adds playfab username/password auth to an existing account created via an anonymous auth method, e.g. automatic device
        /// ID login.
        /// </summary>
        public async Task<PlayFabResult<AddUsernamePasswordResult>> AddUsernamePasswordAsync(AddUsernamePasswordRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/AddUsernamePassword", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<AddUsernamePasswordResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<AddUsernamePasswordResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<AddUsernamePasswordResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Increments the user's balance of the specified virtual currency by the stated amount
        /// </summary>
        public async Task<PlayFabResult<ModifyUserVirtualCurrencyResult>> AddUserVirtualCurrencyAsync(AddUserVirtualCurrencyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/AddUserVirtualCurrency", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ModifyUserVirtualCurrencyResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ModifyUserVirtualCurrencyResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ModifyUserVirtualCurrencyResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Registers the Android device to receive push notifications
        /// </summary>
        public async Task<PlayFabResult<AndroidDevicePushNotificationRegistrationResult>> AndroidDevicePushNotificationRegistrationAsync(AndroidDevicePushNotificationRegistrationRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/AndroidDevicePushNotificationRegistration", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<AndroidDevicePushNotificationRegistrationResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<AndroidDevicePushNotificationRegistrationResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<AndroidDevicePushNotificationRegistrationResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Attributes an install for advertisment.
        /// </summary>
        public async Task<PlayFabResult<AttributeInstallResult>> AttributeInstallAsync(AttributeInstallRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/AttributeInstall", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<AttributeInstallResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<AttributeInstallResult>>(resultRawJson);
            var result = resultData.data;
            // Modify AdvertisingIdType:  Prevents us from sending the id multiple times, and allows automated tests to determine id was sent successfully
            if (apiSettings != null) apiSettings.AdvertisingIdType += "_Successful";

            return new PlayFabResult<AttributeInstallResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Cancels an open trade (one that has not yet been accepted or cancelled). Note that only the player who created the trade
        /// can cancel it via this API call, to prevent griefing of the trade system (cancelling trades in order to prevent other
        /// players from accepting them, for trades that can be claimed by more than one player).
        /// </summary>
        public async Task<PlayFabResult<CancelTradeResponse>> CancelTradeAsync(CancelTradeRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/CancelTrade", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<CancelTradeResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<CancelTradeResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<CancelTradeResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Confirms with the payment provider that the purchase was approved (if applicable) and adjusts inventory and virtual
        /// currency balances as appropriate
        /// </summary>
        public async Task<PlayFabResult<ConfirmPurchaseResult>> ConfirmPurchaseAsync(ConfirmPurchaseRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/ConfirmPurchase", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ConfirmPurchaseResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ConfirmPurchaseResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ConfirmPurchaseResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Consume uses of a consumable item. When all uses are consumed, it will be removed from the player's inventory.
        /// </summary>
        public async Task<PlayFabResult<ConsumeItemResult>> ConsumeItemAsync(ConsumeItemRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/ConsumeItem", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ConsumeItemResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ConsumeItemResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ConsumeItemResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Checks for any new consumable entitlements. If any are found, they are consumed and added as PlayFab items
        /// </summary>
        public async Task<PlayFabResult<ConsumePSNEntitlementsResult>> ConsumePSNEntitlementsAsync(ConsumePSNEntitlementsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/ConsumePSNEntitlements", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ConsumePSNEntitlementsResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ConsumePSNEntitlementsResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ConsumePSNEntitlementsResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Grants the player's current entitlements from Xbox Live, consuming all availble items in Xbox and granting them to the
        /// player's PlayFab inventory. This call is idempotent and will not grant previously granted items to the player.
        /// </summary>
        public async Task<PlayFabResult<ConsumeXboxEntitlementsResult>> ConsumeXboxEntitlementsAsync(ConsumeXboxEntitlementsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/ConsumeXboxEntitlements", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ConsumeXboxEntitlementsResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ConsumeXboxEntitlementsResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ConsumeXboxEntitlementsResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Requests the creation of a shared group object, containing key/value pairs which may be updated by all members of the
        /// group. Upon creation, the current user will be the only member of the group. Shared Groups are designed for sharing data
        /// between a very small number of players, please see our guide:
        /// https://docs.microsoft.com/en-us/gaming/playfab/features/social/groups/using-shared-group-data
        /// </summary>
        public async Task<PlayFabResult<CreateSharedGroupResult>> CreateSharedGroupAsync(CreateSharedGroupRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/CreateSharedGroup", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<CreateSharedGroupResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<CreateSharedGroupResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<CreateSharedGroupResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Executes a CloudScript function, with the 'currentPlayerId' set to the PlayFab ID of the authenticated player.
        /// </summary>
        public async Task<PlayFabResult<ExecuteCloudScriptResult>> ExecuteCloudScriptAsync(ExecuteCloudScriptRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/ExecuteCloudScript", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ExecuteCloudScriptResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ExecuteCloudScriptResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ExecuteCloudScriptResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves the user's PlayFab account details
        /// </summary>
        public async Task<PlayFabResult<GetAccountInfoResult>> GetAccountInfoAsync(GetAccountInfoRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/GetAccountInfo", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetAccountInfoResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetAccountInfoResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetAccountInfoResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Lists all of the characters that belong to a specific user. CharacterIds are not globally unique; characterId must be
        /// evaluated with the parent PlayFabId to guarantee uniqueness.
        /// </summary>
        public async Task<PlayFabResult<ListUsersCharactersResult>> GetAllUsersCharactersAsync(ListUsersCharactersRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/GetAllUsersCharacters", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ListUsersCharactersResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ListUsersCharactersResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ListUsersCharactersResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves the specified version of the title's catalog of virtual goods, including all defined properties
        /// </summary>
        public async Task<PlayFabResult<GetCatalogItemsResult>> GetCatalogItemsAsync(GetCatalogItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/GetCatalogItems", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetCatalogItemsResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetCatalogItemsResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetCatalogItemsResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the character which is readable and writable by the client
        /// </summary>
        public async Task<PlayFabResult<GetCharacterDataResult>> GetCharacterDataAsync(GetCharacterDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/GetCharacterData", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetCharacterDataResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetCharacterDataResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetCharacterDataResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves the specified character's current inventory of virtual goods
        /// </summary>
        public async Task<PlayFabResult<GetCharacterInventoryResult>> GetCharacterInventoryAsync(GetCharacterInventoryRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/GetCharacterInventory", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetCharacterInventoryResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetCharacterInventoryResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetCharacterInventoryResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves a list of ranked characters for the given statistic, starting from the indicated point in the leaderboard
        /// </summary>
        public async Task<PlayFabResult<GetCharacterLeaderboardResult>> GetCharacterLeaderboardAsync(GetCharacterLeaderboardRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/GetCharacterLeaderboard", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetCharacterLeaderboardResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetCharacterLeaderboardResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetCharacterLeaderboardResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the character which can only be read by the client
        /// </summary>
        public async Task<PlayFabResult<GetCharacterDataResult>> GetCharacterReadOnlyDataAsync(GetCharacterDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/GetCharacterReadOnlyData", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetCharacterDataResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetCharacterDataResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetCharacterDataResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves the details of all title-specific statistics for the user
        /// </summary>
        public async Task<PlayFabResult<GetCharacterStatisticsResult>> GetCharacterStatisticsAsync(GetCharacterStatisticsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/GetCharacterStatistics", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetCharacterStatisticsResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetCharacterStatisticsResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetCharacterStatisticsResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// This API retrieves a pre-signed URL for accessing a content file for the title. A subsequent HTTP GET to the returned
        /// URL will attempt to download the content. A HEAD query to the returned URL will attempt to retrieve the metadata of the
        /// content. Note that a successful result does not guarantee the existence of this content - if it has not been uploaded,
        /// the query to retrieve the data will fail. See this post for more information:
        /// https://community.playfab.com/hc/en-us/community/posts/205469488-How-to-upload-files-to-PlayFab-s-Content-Service. Also,
        /// please be aware that the Content service is specifically PlayFab's CDN offering, for which standard CDN rates apply.
        /// </summary>
        public async Task<PlayFabResult<GetContentDownloadUrlResult>> GetContentDownloadUrlAsync(GetContentDownloadUrlRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/GetContentDownloadUrl", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetContentDownloadUrlResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetContentDownloadUrlResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetContentDownloadUrlResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Get details about all current running game servers matching the given parameters.
        /// </summary>
        public async Task<PlayFabResult<CurrentGamesResult>> GetCurrentGamesAsync(CurrentGamesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/GetCurrentGames", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<CurrentGamesResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<CurrentGamesResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<CurrentGamesResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves a list of ranked friends of the current player for the given statistic, starting from the indicated point in
        /// the leaderboard
        /// </summary>
        public async Task<PlayFabResult<GetLeaderboardResult>> GetFriendLeaderboardAsync(GetFriendLeaderboardRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/GetFriendLeaderboard", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetLeaderboardResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetLeaderboardResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetLeaderboardResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves a list of ranked friends of the current player for the given statistic, centered on the requested PlayFab
        /// user. If PlayFabId is empty or null will return currently logged in user.
        /// </summary>
        public async Task<PlayFabResult<GetFriendLeaderboardAroundPlayerResult>> GetFriendLeaderboardAroundPlayerAsync(GetFriendLeaderboardAroundPlayerRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/GetFriendLeaderboardAroundPlayer", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetFriendLeaderboardAroundPlayerResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetFriendLeaderboardAroundPlayerResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetFriendLeaderboardAroundPlayerResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves the current friend list for the local user, constrained to users who have PlayFab accounts. Friends from
        /// linked accounts (Facebook, Steam) are also included. You may optionally exclude some linked services' friends.
        /// </summary>
        public async Task<PlayFabResult<GetFriendsListResult>> GetFriendsListAsync(GetFriendsListRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/GetFriendsList", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetFriendsListResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetFriendsListResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetFriendsListResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Get details about the regions hosting game servers matching the given parameters.
        /// </summary>
        public async Task<PlayFabResult<GameServerRegionsResult>> GetGameServerRegionsAsync(GameServerRegionsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/GetGameServerRegions", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GameServerRegionsResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GameServerRegionsResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GameServerRegionsResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves a list of ranked users for the given statistic, starting from the indicated point in the leaderboard
        /// </summary>
        public async Task<PlayFabResult<GetLeaderboardResult>> GetLeaderboardAsync(GetLeaderboardRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/GetLeaderboard", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetLeaderboardResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetLeaderboardResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetLeaderboardResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves a list of ranked characters for the given statistic, centered on the requested Character ID
        /// </summary>
        public async Task<PlayFabResult<GetLeaderboardAroundCharacterResult>> GetLeaderboardAroundCharacterAsync(GetLeaderboardAroundCharacterRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/GetLeaderboardAroundCharacter", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetLeaderboardAroundCharacterResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetLeaderboardAroundCharacterResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetLeaderboardAroundCharacterResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves a list of ranked users for the given statistic, centered on the requested player. If PlayFabId is empty or
        /// null will return currently logged in user.
        /// </summary>
        public async Task<PlayFabResult<GetLeaderboardAroundPlayerResult>> GetLeaderboardAroundPlayerAsync(GetLeaderboardAroundPlayerRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/GetLeaderboardAroundPlayer", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetLeaderboardAroundPlayerResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetLeaderboardAroundPlayerResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetLeaderboardAroundPlayerResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves a list of all of the user's characters for the given statistic.
        /// </summary>
        public async Task<PlayFabResult<GetLeaderboardForUsersCharactersResult>> GetLeaderboardForUserCharactersAsync(GetLeaderboardForUsersCharactersRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/GetLeaderboardForUserCharacters", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetLeaderboardForUsersCharactersResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetLeaderboardForUsersCharactersResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetLeaderboardForUsersCharactersResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// For payments flows where the provider requires playfab (the fulfiller) to initiate the transaction, but the client
        /// completes the rest of the flow. In the Xsolla case, the token returned here will be passed to Xsolla by the client to
        /// create a cart. Poll GetPurchase using the returned OrderId once you've completed the payment.
        /// </summary>
        public async Task<PlayFabResult<GetPaymentTokenResult>> GetPaymentTokenAsync(GetPaymentTokenRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/GetPaymentToken", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetPaymentTokenResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetPaymentTokenResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetPaymentTokenResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Gets a Photon custom authentication token that can be used to securely join the player into a Photon room. See
        /// https://docs.microsoft.com/en-us/gaming/playfab/features/multiplayer/photon/quickstart for more details.
        /// </summary>
        public async Task<PlayFabResult<GetPhotonAuthenticationTokenResult>> GetPhotonAuthenticationTokenAsync(GetPhotonAuthenticationTokenRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/GetPhotonAuthenticationToken", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetPhotonAuthenticationTokenResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetPhotonAuthenticationTokenResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetPhotonAuthenticationTokenResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves all of the user's different kinds of info.
        /// </summary>
        public async Task<PlayFabResult<GetPlayerCombinedInfoResult>> GetPlayerCombinedInfoAsync(GetPlayerCombinedInfoRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/GetPlayerCombinedInfo", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetPlayerCombinedInfoResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetPlayerCombinedInfoResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetPlayerCombinedInfoResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves the player's profile
        /// </summary>
        public async Task<PlayFabResult<GetPlayerProfileResult>> GetPlayerProfileAsync(GetPlayerProfileRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/GetPlayerProfile", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetPlayerProfileResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetPlayerProfileResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetPlayerProfileResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// List all segments that a player currently belongs to at this moment in time.
        /// </summary>
        public async Task<PlayFabResult<GetPlayerSegmentsResult>> GetPlayerSegmentsAsync(GetPlayerSegmentsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/GetPlayerSegments", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetPlayerSegmentsResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetPlayerSegmentsResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetPlayerSegmentsResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves the indicated statistics (current version and values for all statistics, if none are specified), for the local
        /// player.
        /// </summary>
        public async Task<PlayFabResult<GetPlayerStatisticsResult>> GetPlayerStatisticsAsync(GetPlayerStatisticsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/GetPlayerStatistics", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetPlayerStatisticsResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetPlayerStatisticsResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetPlayerStatisticsResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves the information on the available versions of the specified statistic.
        /// </summary>
        public async Task<PlayFabResult<GetPlayerStatisticVersionsResult>> GetPlayerStatisticVersionsAsync(GetPlayerStatisticVersionsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/GetPlayerStatisticVersions", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetPlayerStatisticVersionsResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetPlayerStatisticVersionsResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetPlayerStatisticVersionsResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Get all tags with a given Namespace (optional) from a player profile.
        /// </summary>
        public async Task<PlayFabResult<GetPlayerTagsResult>> GetPlayerTagsAsync(GetPlayerTagsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/GetPlayerTags", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetPlayerTagsResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetPlayerTagsResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetPlayerTagsResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Gets all trades the player has either opened or accepted, optionally filtered by trade status.
        /// </summary>
        public async Task<PlayFabResult<GetPlayerTradesResponse>> GetPlayerTradesAsync(GetPlayerTradesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/GetPlayerTrades", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetPlayerTradesResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetPlayerTradesResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetPlayerTradesResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Facebook identifiers.
        /// </summary>
        public async Task<PlayFabResult<GetPlayFabIDsFromFacebookIDsResult>> GetPlayFabIDsFromFacebookIDsAsync(GetPlayFabIDsFromFacebookIDsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/GetPlayFabIDsFromFacebookIDs", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetPlayFabIDsFromFacebookIDsResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetPlayFabIDsFromFacebookIDsResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetPlayFabIDsFromFacebookIDsResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Facebook Instant Game identifiers.
        /// </summary>
        public async Task<PlayFabResult<GetPlayFabIDsFromFacebookInstantGamesIdsResult>> GetPlayFabIDsFromFacebookInstantGamesIdsAsync(GetPlayFabIDsFromFacebookInstantGamesIdsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/GetPlayFabIDsFromFacebookInstantGamesIds", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetPlayFabIDsFromFacebookInstantGamesIdsResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetPlayFabIDsFromFacebookInstantGamesIdsResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetPlayFabIDsFromFacebookInstantGamesIdsResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Game Center identifiers (referenced in the Game Center
        /// Programming Guide as the Player Identifier).
        /// </summary>
        public async Task<PlayFabResult<GetPlayFabIDsFromGameCenterIDsResult>> GetPlayFabIDsFromGameCenterIDsAsync(GetPlayFabIDsFromGameCenterIDsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/GetPlayFabIDsFromGameCenterIDs", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetPlayFabIDsFromGameCenterIDsResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetPlayFabIDsFromGameCenterIDsResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetPlayFabIDsFromGameCenterIDsResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of generic service identifiers. A generic identifier is the
        /// service name plus the service-specific ID for the player, as specified by the title when the generic identifier was
        /// added to the player account.
        /// </summary>
        public async Task<PlayFabResult<GetPlayFabIDsFromGenericIDsResult>> GetPlayFabIDsFromGenericIDsAsync(GetPlayFabIDsFromGenericIDsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/GetPlayFabIDsFromGenericIDs", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetPlayFabIDsFromGenericIDsResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetPlayFabIDsFromGenericIDsResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetPlayFabIDsFromGenericIDsResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Google identifiers. The Google identifiers are the IDs for
        /// the user accounts, available as "id" in the Google+ People API calls.
        /// </summary>
        public async Task<PlayFabResult<GetPlayFabIDsFromGoogleIDsResult>> GetPlayFabIDsFromGoogleIDsAsync(GetPlayFabIDsFromGoogleIDsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/GetPlayFabIDsFromGoogleIDs", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetPlayFabIDsFromGoogleIDsResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetPlayFabIDsFromGoogleIDsResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetPlayFabIDsFromGoogleIDsResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Kongregate identifiers. The Kongregate identifiers are the
        /// IDs for the user accounts, available as "user_id" from the Kongregate API methods(ex:
        /// http://developers.kongregate.com/docs/client/getUserId).
        /// </summary>
        public async Task<PlayFabResult<GetPlayFabIDsFromKongregateIDsResult>> GetPlayFabIDsFromKongregateIDsAsync(GetPlayFabIDsFromKongregateIDsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/GetPlayFabIDsFromKongregateIDs", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetPlayFabIDsFromKongregateIDsResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetPlayFabIDsFromKongregateIDsResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetPlayFabIDsFromKongregateIDsResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Nintendo Switch identifiers.
        /// </summary>
        public async Task<PlayFabResult<GetPlayFabIDsFromNintendoSwitchDeviceIdsResult>> GetPlayFabIDsFromNintendoSwitchDeviceIdsAsync(GetPlayFabIDsFromNintendoSwitchDeviceIdsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/GetPlayFabIDsFromNintendoSwitchDeviceIds", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetPlayFabIDsFromNintendoSwitchDeviceIdsResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetPlayFabIDsFromNintendoSwitchDeviceIdsResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetPlayFabIDsFromNintendoSwitchDeviceIdsResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of PlayStation Network identifiers.
        /// </summary>
        public async Task<PlayFabResult<GetPlayFabIDsFromPSNAccountIDsResult>> GetPlayFabIDsFromPSNAccountIDsAsync(GetPlayFabIDsFromPSNAccountIDsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/GetPlayFabIDsFromPSNAccountIDs", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetPlayFabIDsFromPSNAccountIDsResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetPlayFabIDsFromPSNAccountIDsResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetPlayFabIDsFromPSNAccountIDsResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Steam identifiers. The Steam identifiers are the profile
        /// IDs for the user accounts, available as SteamId in the Steamworks Community API calls.
        /// </summary>
        public async Task<PlayFabResult<GetPlayFabIDsFromSteamIDsResult>> GetPlayFabIDsFromSteamIDsAsync(GetPlayFabIDsFromSteamIDsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/GetPlayFabIDsFromSteamIDs", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetPlayFabIDsFromSteamIDsResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetPlayFabIDsFromSteamIDsResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetPlayFabIDsFromSteamIDsResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Twitch identifiers. The Twitch identifiers are the IDs for
        /// the user accounts, available as "_id" from the Twitch API methods (ex:
        /// https://github.com/justintv/Twitch-API/blob/master/v3_resources/users.md#get-usersuser).
        /// </summary>
        public async Task<PlayFabResult<GetPlayFabIDsFromTwitchIDsResult>> GetPlayFabIDsFromTwitchIDsAsync(GetPlayFabIDsFromTwitchIDsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/GetPlayFabIDsFromTwitchIDs", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetPlayFabIDsFromTwitchIDsResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetPlayFabIDsFromTwitchIDsResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetPlayFabIDsFromTwitchIDsResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of XboxLive identifiers.
        /// </summary>
        public async Task<PlayFabResult<GetPlayFabIDsFromXboxLiveIDsResult>> GetPlayFabIDsFromXboxLiveIDsAsync(GetPlayFabIDsFromXboxLiveIDsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/GetPlayFabIDsFromXboxLiveIDs", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetPlayFabIDsFromXboxLiveIDsResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetPlayFabIDsFromXboxLiveIDsResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetPlayFabIDsFromXboxLiveIDsResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves the key-value store of custom publisher settings
        /// </summary>
        public async Task<PlayFabResult<GetPublisherDataResult>> GetPublisherDataAsync(GetPublisherDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/GetPublisherData", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetPublisherDataResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetPublisherDataResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetPublisherDataResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves a purchase along with its current PlayFab status. Returns inventory items from the purchase that are still
        /// active.
        /// </summary>
        public async Task<PlayFabResult<GetPurchaseResult>> GetPurchaseAsync(GetPurchaseRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/GetPurchase", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetPurchaseResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetPurchaseResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetPurchaseResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves data stored in a shared group object, as well as the list of members in the group. Non-members of the group
        /// may use this to retrieve group data, including membership, but they will not receive data for keys marked as private.
        /// Shared Groups are designed for sharing data between a very small number of players, please see our guide:
        /// https://api.playfab.com/docs/tutorials/landing-players/shared-groups
        /// </summary>
        public async Task<PlayFabResult<GetSharedGroupDataResult>> GetSharedGroupDataAsync(GetSharedGroupDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/GetSharedGroupData", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetSharedGroupDataResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetSharedGroupDataResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetSharedGroupDataResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves the set of items defined for the specified store, including all prices defined
        /// </summary>
        public async Task<PlayFabResult<GetStoreItemsResult>> GetStoreItemsAsync(GetStoreItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/GetStoreItems", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetStoreItemsResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetStoreItemsResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetStoreItemsResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves the current server time
        /// </summary>
        public async Task<PlayFabResult<GetTimeResult>> GetTimeAsync(GetTimeRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/GetTime", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetTimeResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetTimeResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetTimeResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves the key-value store of custom title settings
        /// </summary>
        public async Task<PlayFabResult<GetTitleDataResult>> GetTitleDataAsync(GetTitleDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/GetTitleData", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetTitleDataResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetTitleDataResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetTitleDataResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves the title news feed, as configured in the developer portal
        /// </summary>
        public async Task<PlayFabResult<GetTitleNewsResult>> GetTitleNewsAsync(GetTitleNewsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/GetTitleNews", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetTitleNewsResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetTitleNewsResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetTitleNewsResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Returns the title's base 64 encoded RSA CSP blob.
        /// </summary>
        public async Task<PlayFabResult<GetTitlePublicKeyResult>> GetTitlePublicKeyAsync(GetTitlePublicKeyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;

            var httpResult = await PlayFabHttp.DoPost("/Client/GetTitlePublicKey", request, null, null, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetTitlePublicKeyResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetTitlePublicKeyResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetTitlePublicKeyResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Gets the current status of an existing trade.
        /// </summary>
        public async Task<PlayFabResult<GetTradeStatusResponse>> GetTradeStatusAsync(GetTradeStatusRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/GetTradeStatus", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetTradeStatusResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetTradeStatusResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetTradeStatusResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public async Task<PlayFabResult<GetUserDataResult>> GetUserDataAsync(GetUserDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/GetUserData", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetUserDataResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetUserDataResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetUserDataResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves the user's current inventory of virtual goods
        /// </summary>
        public async Task<PlayFabResult<GetUserInventoryResult>> GetUserInventoryAsync(GetUserInventoryRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/GetUserInventory", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetUserInventoryResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetUserInventoryResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetUserInventoryResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves the publisher-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public async Task<PlayFabResult<GetUserDataResult>> GetUserPublisherDataAsync(GetUserDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/GetUserPublisherData", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetUserDataResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetUserDataResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetUserDataResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves the publisher-specific custom data for the user which can only be read by the client
        /// </summary>
        public async Task<PlayFabResult<GetUserDataResult>> GetUserPublisherReadOnlyDataAsync(GetUserDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/GetUserPublisherReadOnlyData", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetUserDataResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetUserDataResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetUserDataResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user which can only be read by the client
        /// </summary>
        public async Task<PlayFabResult<GetUserDataResult>> GetUserReadOnlyDataAsync(GetUserDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/GetUserReadOnlyData", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetUserDataResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetUserDataResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetUserDataResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Requests a challenge from the server to be signed by Windows Hello Passport service to authenticate.
        /// </summary>
        public async Task<PlayFabResult<GetWindowsHelloChallengeResponse>> GetWindowsHelloChallengeAsync(GetWindowsHelloChallengeRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;

            var httpResult = await PlayFabHttp.DoPost("/Client/GetWindowsHelloChallenge", request, null, null, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetWindowsHelloChallengeResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetWindowsHelloChallengeResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetWindowsHelloChallengeResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Grants the specified character type to the user. CharacterIds are not globally unique; characterId must be evaluated
        /// with the parent PlayFabId to guarantee uniqueness.
        /// </summary>
        public async Task<PlayFabResult<GrantCharacterToUserResult>> GrantCharacterToUserAsync(GrantCharacterToUserRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/GrantCharacterToUser", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GrantCharacterToUserResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GrantCharacterToUserResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GrantCharacterToUserResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Links the Android device identifier to the user's PlayFab account
        /// </summary>
        public async Task<PlayFabResult<LinkAndroidDeviceIDResult>> LinkAndroidDeviceIDAsync(LinkAndroidDeviceIDRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/LinkAndroidDeviceID", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<LinkAndroidDeviceIDResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<LinkAndroidDeviceIDResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<LinkAndroidDeviceIDResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Links the custom identifier, generated by the title, to the user's PlayFab account
        /// </summary>
        public async Task<PlayFabResult<LinkCustomIDResult>> LinkCustomIDAsync(LinkCustomIDRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/LinkCustomID", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<LinkCustomIDResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<LinkCustomIDResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<LinkCustomIDResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Links the Facebook account associated with the provided Facebook access token to the user's PlayFab account
        /// </summary>
        public async Task<PlayFabResult<LinkFacebookAccountResult>> LinkFacebookAccountAsync(LinkFacebookAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/LinkFacebookAccount", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<LinkFacebookAccountResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<LinkFacebookAccountResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<LinkFacebookAccountResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Links the Facebook Instant Games Id to the user's PlayFab account
        /// </summary>
        public async Task<PlayFabResult<LinkFacebookInstantGamesIdResult>> LinkFacebookInstantGamesIdAsync(LinkFacebookInstantGamesIdRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/LinkFacebookInstantGamesId", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<LinkFacebookInstantGamesIdResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<LinkFacebookInstantGamesIdResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<LinkFacebookInstantGamesIdResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Links the Game Center account associated with the provided Game Center ID to the user's PlayFab account
        /// </summary>
        public async Task<PlayFabResult<LinkGameCenterAccountResult>> LinkGameCenterAccountAsync(LinkGameCenterAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/LinkGameCenterAccount", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<LinkGameCenterAccountResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<LinkGameCenterAccountResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<LinkGameCenterAccountResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Links the currently signed-in user account to their Google account, using their Google account credentials
        /// </summary>
        public async Task<PlayFabResult<LinkGoogleAccountResult>> LinkGoogleAccountAsync(LinkGoogleAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/LinkGoogleAccount", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<LinkGoogleAccountResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<LinkGoogleAccountResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<LinkGoogleAccountResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Links the vendor-specific iOS device identifier to the user's PlayFab account
        /// </summary>
        public async Task<PlayFabResult<LinkIOSDeviceIDResult>> LinkIOSDeviceIDAsync(LinkIOSDeviceIDRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/LinkIOSDeviceID", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<LinkIOSDeviceIDResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<LinkIOSDeviceIDResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<LinkIOSDeviceIDResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Links the Kongregate identifier to the user's PlayFab account
        /// </summary>
        public async Task<PlayFabResult<LinkKongregateAccountResult>> LinkKongregateAsync(LinkKongregateAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/LinkKongregate", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<LinkKongregateAccountResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<LinkKongregateAccountResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<LinkKongregateAccountResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Links the NintendoSwitchDeviceId to the user's PlayFab account
        /// </summary>
        public async Task<PlayFabResult<LinkNintendoSwitchDeviceIdResult>> LinkNintendoSwitchDeviceIdAsync(LinkNintendoSwitchDeviceIdRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/LinkNintendoSwitchDeviceId", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<LinkNintendoSwitchDeviceIdResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<LinkNintendoSwitchDeviceIdResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<LinkNintendoSwitchDeviceIdResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Links an OpenID Connect account to a user's PlayFab account, based on an existing relationship between a title and an
        /// Open ID Connect provider and the OpenId Connect JWT from that provider.
        /// </summary>
        public async Task<PlayFabResult<EmptyResult>> LinkOpenIdConnectAsync(LinkOpenIdConnectRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/LinkOpenIdConnect", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<EmptyResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<EmptyResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<EmptyResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Links the PlayStation Network account associated with the provided access code to the user's PlayFab account
        /// </summary>
        public async Task<PlayFabResult<LinkPSNAccountResult>> LinkPSNAccountAsync(LinkPSNAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/LinkPSNAccount", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<LinkPSNAccountResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<LinkPSNAccountResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<LinkPSNAccountResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Links the Steam account associated with the provided Steam authentication ticket to the user's PlayFab account
        /// </summary>
        public async Task<PlayFabResult<LinkSteamAccountResult>> LinkSteamAccountAsync(LinkSteamAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/LinkSteamAccount", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<LinkSteamAccountResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<LinkSteamAccountResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<LinkSteamAccountResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Links the Twitch account associated with the token to the user's PlayFab account.
        /// </summary>
        public async Task<PlayFabResult<LinkTwitchAccountResult>> LinkTwitchAsync(LinkTwitchAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/LinkTwitch", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<LinkTwitchAccountResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<LinkTwitchAccountResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<LinkTwitchAccountResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Link Windows Hello authentication to the current PlayFab Account
        /// </summary>
        public async Task<PlayFabResult<LinkWindowsHelloAccountResponse>> LinkWindowsHelloAsync(LinkWindowsHelloAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/LinkWindowsHello", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<LinkWindowsHelloAccountResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<LinkWindowsHelloAccountResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<LinkWindowsHelloAccountResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Links the Xbox Live account associated with the provided access code to the user's PlayFab account
        /// </summary>
        public async Task<PlayFabResult<LinkXboxAccountResult>> LinkXboxAccountAsync(LinkXboxAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/LinkXboxAccount", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<LinkXboxAccountResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<LinkXboxAccountResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<LinkXboxAccountResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Signs the user in using the Android device identifier, returning a session identifier that can subsequently be used for
        /// API calls which require an authenticated user
        /// </summary>
        public async Task<PlayFabResult<LoginResult>> LoginWithAndroidDeviceIDAsync(LoginWithAndroidDeviceIDRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (request != null) request.TitleId = request?.TitleId ?? requestSettings.TitleId;
            if (request.TitleId == null) throw new PlayFabException(PlayFabExceptionCode.TitleNotSet, "Must be have PlayFabSettings.staticSettings.TitleId set to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/LoginWithAndroidDeviceID", request, null, null, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<LoginResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<LoginResult>>(resultRawJson);
            var result = resultData.data;
            result.AuthenticationContext = new PlayFabAuthenticationContext(result.SessionTicket, result.EntityToken.EntityToken, result.PlayFabId, result.EntityToken.Entity.Id, result.EntityToken.Entity.Type);
            authenticationContext.CopyFrom(result.AuthenticationContext);
            await MultiStepClientLogin(result.SettingsForUser.NeedsAttribution);

            return new PlayFabResult<LoginResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Signs the user in using a custom unique identifier generated by the title, returning a session identifier that can
        /// subsequently be used for API calls which require an authenticated user
        /// </summary>
        public async Task<PlayFabResult<LoginResult>> LoginWithCustomIDAsync(LoginWithCustomIDRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (request != null) request.TitleId = request?.TitleId ?? requestSettings.TitleId;
            if (request.TitleId == null) throw new PlayFabException(PlayFabExceptionCode.TitleNotSet, "Must be have PlayFabSettings.staticSettings.TitleId set to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/LoginWithCustomID", request, null, null, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<LoginResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<LoginResult>>(resultRawJson);
            var result = resultData.data;
            result.AuthenticationContext = new PlayFabAuthenticationContext(result.SessionTicket, result.EntityToken.EntityToken, result.PlayFabId, result.EntityToken.Entity.Id, result.EntityToken.Entity.Type);
            authenticationContext.CopyFrom(result.AuthenticationContext);
            await MultiStepClientLogin(result.SettingsForUser.NeedsAttribution);

            return new PlayFabResult<LoginResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Signs the user into the PlayFab account, returning a session identifier that can subsequently be used for API calls
        /// which require an authenticated user. Unlike most other login API calls, LoginWithEmailAddress does not permit the
        /// creation of new accounts via the CreateAccountFlag. Email addresses may be used to create accounts via
        /// RegisterPlayFabUser.
        /// </summary>
        public async Task<PlayFabResult<LoginResult>> LoginWithEmailAddressAsync(LoginWithEmailAddressRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (request != null) request.TitleId = request?.TitleId ?? requestSettings.TitleId;
            if (request.TitleId == null) throw new PlayFabException(PlayFabExceptionCode.TitleNotSet, "Must be have PlayFabSettings.staticSettings.TitleId set to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/LoginWithEmailAddress", request, null, null, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<LoginResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<LoginResult>>(resultRawJson);
            var result = resultData.data;
            result.AuthenticationContext = new PlayFabAuthenticationContext(result.SessionTicket, result.EntityToken.EntityToken, result.PlayFabId, result.EntityToken.Entity.Id, result.EntityToken.Entity.Type);
            authenticationContext.CopyFrom(result.AuthenticationContext);
            await MultiStepClientLogin(result.SettingsForUser.NeedsAttribution);

            return new PlayFabResult<LoginResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Signs the user in using a Facebook access token, returning a session identifier that can subsequently be used for API
        /// calls which require an authenticated user
        /// </summary>
        public async Task<PlayFabResult<LoginResult>> LoginWithFacebookAsync(LoginWithFacebookRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (request != null) request.TitleId = request?.TitleId ?? requestSettings.TitleId;
            if (request.TitleId == null) throw new PlayFabException(PlayFabExceptionCode.TitleNotSet, "Must be have PlayFabSettings.staticSettings.TitleId set to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/LoginWithFacebook", request, null, null, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<LoginResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<LoginResult>>(resultRawJson);
            var result = resultData.data;
            result.AuthenticationContext = new PlayFabAuthenticationContext(result.SessionTicket, result.EntityToken.EntityToken, result.PlayFabId, result.EntityToken.Entity.Id, result.EntityToken.Entity.Type);
            authenticationContext.CopyFrom(result.AuthenticationContext);
            await MultiStepClientLogin(result.SettingsForUser.NeedsAttribution);

            return new PlayFabResult<LoginResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Signs the user in using a Facebook Instant Games ID, returning a session identifier that can subsequently be used for
        /// API calls which require an authenticated user. Requires Facebook Instant Games to be configured.
        /// </summary>
        public async Task<PlayFabResult<LoginResult>> LoginWithFacebookInstantGamesIdAsync(LoginWithFacebookInstantGamesIdRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (request != null) request.TitleId = request?.TitleId ?? requestSettings.TitleId;
            if (request.TitleId == null) throw new PlayFabException(PlayFabExceptionCode.TitleNotSet, "Must be have PlayFabSettings.staticSettings.TitleId set to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/LoginWithFacebookInstantGamesId", request, null, null, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<LoginResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<LoginResult>>(resultRawJson);
            var result = resultData.data;
            result.AuthenticationContext = new PlayFabAuthenticationContext(result.SessionTicket, result.EntityToken.EntityToken, result.PlayFabId, result.EntityToken.Entity.Id, result.EntityToken.Entity.Type);
            authenticationContext.CopyFrom(result.AuthenticationContext);
            await MultiStepClientLogin(result.SettingsForUser.NeedsAttribution);

            return new PlayFabResult<LoginResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Signs the user in using an iOS Game Center player identifier, returning a session identifier that can subsequently be
        /// used for API calls which require an authenticated user
        /// </summary>
        public async Task<PlayFabResult<LoginResult>> LoginWithGameCenterAsync(LoginWithGameCenterRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (request != null) request.TitleId = request?.TitleId ?? requestSettings.TitleId;
            if (request.TitleId == null) throw new PlayFabException(PlayFabExceptionCode.TitleNotSet, "Must be have PlayFabSettings.staticSettings.TitleId set to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/LoginWithGameCenter", request, null, null, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<LoginResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<LoginResult>>(resultRawJson);
            var result = resultData.data;
            result.AuthenticationContext = new PlayFabAuthenticationContext(result.SessionTicket, result.EntityToken.EntityToken, result.PlayFabId, result.EntityToken.Entity.Id, result.EntityToken.Entity.Type);
            authenticationContext.CopyFrom(result.AuthenticationContext);
            await MultiStepClientLogin(result.SettingsForUser.NeedsAttribution);

            return new PlayFabResult<LoginResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Signs the user in using their Google account credentials
        /// </summary>
        public async Task<PlayFabResult<LoginResult>> LoginWithGoogleAccountAsync(LoginWithGoogleAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (request != null) request.TitleId = request?.TitleId ?? requestSettings.TitleId;
            if (request.TitleId == null) throw new PlayFabException(PlayFabExceptionCode.TitleNotSet, "Must be have PlayFabSettings.staticSettings.TitleId set to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/LoginWithGoogleAccount", request, null, null, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<LoginResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<LoginResult>>(resultRawJson);
            var result = resultData.data;
            result.AuthenticationContext = new PlayFabAuthenticationContext(result.SessionTicket, result.EntityToken.EntityToken, result.PlayFabId, result.EntityToken.Entity.Id, result.EntityToken.Entity.Type);
            authenticationContext.CopyFrom(result.AuthenticationContext);
            await MultiStepClientLogin(result.SettingsForUser.NeedsAttribution);

            return new PlayFabResult<LoginResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Signs the user in using the vendor-specific iOS device identifier, returning a session identifier that can subsequently
        /// be used for API calls which require an authenticated user
        /// </summary>
        public async Task<PlayFabResult<LoginResult>> LoginWithIOSDeviceIDAsync(LoginWithIOSDeviceIDRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (request != null) request.TitleId = request?.TitleId ?? requestSettings.TitleId;
            if (request.TitleId == null) throw new PlayFabException(PlayFabExceptionCode.TitleNotSet, "Must be have PlayFabSettings.staticSettings.TitleId set to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/LoginWithIOSDeviceID", request, null, null, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<LoginResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<LoginResult>>(resultRawJson);
            var result = resultData.data;
            result.AuthenticationContext = new PlayFabAuthenticationContext(result.SessionTicket, result.EntityToken.EntityToken, result.PlayFabId, result.EntityToken.Entity.Id, result.EntityToken.Entity.Type);
            authenticationContext.CopyFrom(result.AuthenticationContext);
            await MultiStepClientLogin(result.SettingsForUser.NeedsAttribution);

            return new PlayFabResult<LoginResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Signs the user in using a Kongregate player account.
        /// </summary>
        public async Task<PlayFabResult<LoginResult>> LoginWithKongregateAsync(LoginWithKongregateRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (request != null) request.TitleId = request?.TitleId ?? requestSettings.TitleId;
            if (request.TitleId == null) throw new PlayFabException(PlayFabExceptionCode.TitleNotSet, "Must be have PlayFabSettings.staticSettings.TitleId set to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/LoginWithKongregate", request, null, null, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<LoginResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<LoginResult>>(resultRawJson);
            var result = resultData.data;
            result.AuthenticationContext = new PlayFabAuthenticationContext(result.SessionTicket, result.EntityToken.EntityToken, result.PlayFabId, result.EntityToken.Entity.Id, result.EntityToken.Entity.Type);
            authenticationContext.CopyFrom(result.AuthenticationContext);
            await MultiStepClientLogin(result.SettingsForUser.NeedsAttribution);

            return new PlayFabResult<LoginResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Signs the user in using a Nintendo Switch Device ID, returning a session identifier that can subsequently be used for
        /// API calls which require an authenticated user
        /// </summary>
        public async Task<PlayFabResult<LoginResult>> LoginWithNintendoSwitchDeviceIdAsync(LoginWithNintendoSwitchDeviceIdRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (request != null) request.TitleId = request?.TitleId ?? requestSettings.TitleId;
            if (request.TitleId == null) throw new PlayFabException(PlayFabExceptionCode.TitleNotSet, "Must be have PlayFabSettings.staticSettings.TitleId set to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/LoginWithNintendoSwitchDeviceId", request, null, null, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<LoginResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<LoginResult>>(resultRawJson);
            var result = resultData.data;
            result.AuthenticationContext = new PlayFabAuthenticationContext(result.SessionTicket, result.EntityToken.EntityToken, result.PlayFabId, result.EntityToken.Entity.Id, result.EntityToken.Entity.Type);
            authenticationContext.CopyFrom(result.AuthenticationContext);
            await MultiStepClientLogin(result.SettingsForUser.NeedsAttribution);

            return new PlayFabResult<LoginResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Logs in a user with an Open ID Connect JWT created by an existing relationship between a title and an Open ID Connect
        /// provider.
        /// </summary>
        public async Task<PlayFabResult<LoginResult>> LoginWithOpenIdConnectAsync(LoginWithOpenIdConnectRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (request != null) request.TitleId = request?.TitleId ?? requestSettings.TitleId;
            if (request.TitleId == null) throw new PlayFabException(PlayFabExceptionCode.TitleNotSet, "Must be have PlayFabSettings.staticSettings.TitleId set to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/LoginWithOpenIdConnect", request, null, null, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<LoginResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<LoginResult>>(resultRawJson);
            var result = resultData.data;
            result.AuthenticationContext = new PlayFabAuthenticationContext(result.SessionTicket, result.EntityToken.EntityToken, result.PlayFabId, result.EntityToken.Entity.Id, result.EntityToken.Entity.Type);
            authenticationContext.CopyFrom(result.AuthenticationContext);
            await MultiStepClientLogin(result.SettingsForUser.NeedsAttribution);

            return new PlayFabResult<LoginResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Signs the user into the PlayFab account, returning a session identifier that can subsequently be used for API calls
        /// which require an authenticated user. Unlike most other login API calls, LoginWithPlayFab does not permit the creation of
        /// new accounts via the CreateAccountFlag. Username/Password credentials may be used to create accounts via
        /// RegisterPlayFabUser, or added to existing accounts using AddUsernamePassword.
        /// </summary>
        public async Task<PlayFabResult<LoginResult>> LoginWithPlayFabAsync(LoginWithPlayFabRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (request != null) request.TitleId = request?.TitleId ?? requestSettings.TitleId;
            if (request.TitleId == null) throw new PlayFabException(PlayFabExceptionCode.TitleNotSet, "Must be have PlayFabSettings.staticSettings.TitleId set to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/LoginWithPlayFab", request, null, null, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<LoginResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<LoginResult>>(resultRawJson);
            var result = resultData.data;
            result.AuthenticationContext = new PlayFabAuthenticationContext(result.SessionTicket, result.EntityToken.EntityToken, result.PlayFabId, result.EntityToken.Entity.Id, result.EntityToken.Entity.Type);
            authenticationContext.CopyFrom(result.AuthenticationContext);
            await MultiStepClientLogin(result.SettingsForUser.NeedsAttribution);

            return new PlayFabResult<LoginResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Signs the user in using a PlayStation Network authentication code, returning a session identifier that can subsequently
        /// be used for API calls which require an authenticated user
        /// </summary>
        public async Task<PlayFabResult<LoginResult>> LoginWithPSNAsync(LoginWithPSNRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (request != null) request.TitleId = request?.TitleId ?? requestSettings.TitleId;
            if (request.TitleId == null) throw new PlayFabException(PlayFabExceptionCode.TitleNotSet, "Must be have PlayFabSettings.staticSettings.TitleId set to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/LoginWithPSN", request, null, null, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<LoginResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<LoginResult>>(resultRawJson);
            var result = resultData.data;
            result.AuthenticationContext = new PlayFabAuthenticationContext(result.SessionTicket, result.EntityToken.EntityToken, result.PlayFabId, result.EntityToken.Entity.Id, result.EntityToken.Entity.Type);
            authenticationContext.CopyFrom(result.AuthenticationContext);
            await MultiStepClientLogin(result.SettingsForUser.NeedsAttribution);

            return new PlayFabResult<LoginResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Signs the user in using a Steam authentication ticket, returning a session identifier that can subsequently be used for
        /// API calls which require an authenticated user
        /// </summary>
        public async Task<PlayFabResult<LoginResult>> LoginWithSteamAsync(LoginWithSteamRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (request != null) request.TitleId = request?.TitleId ?? requestSettings.TitleId;
            if (request.TitleId == null) throw new PlayFabException(PlayFabExceptionCode.TitleNotSet, "Must be have PlayFabSettings.staticSettings.TitleId set to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/LoginWithSteam", request, null, null, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<LoginResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<LoginResult>>(resultRawJson);
            var result = resultData.data;
            result.AuthenticationContext = new PlayFabAuthenticationContext(result.SessionTicket, result.EntityToken.EntityToken, result.PlayFabId, result.EntityToken.Entity.Id, result.EntityToken.Entity.Type);
            authenticationContext.CopyFrom(result.AuthenticationContext);
            await MultiStepClientLogin(result.SettingsForUser.NeedsAttribution);

            return new PlayFabResult<LoginResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Signs the user in using a Twitch access token.
        /// </summary>
        public async Task<PlayFabResult<LoginResult>> LoginWithTwitchAsync(LoginWithTwitchRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (request != null) request.TitleId = request?.TitleId ?? requestSettings.TitleId;
            if (request.TitleId == null) throw new PlayFabException(PlayFabExceptionCode.TitleNotSet, "Must be have PlayFabSettings.staticSettings.TitleId set to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/LoginWithTwitch", request, null, null, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<LoginResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<LoginResult>>(resultRawJson);
            var result = resultData.data;
            result.AuthenticationContext = new PlayFabAuthenticationContext(result.SessionTicket, result.EntityToken.EntityToken, result.PlayFabId, result.EntityToken.Entity.Id, result.EntityToken.Entity.Type);
            authenticationContext.CopyFrom(result.AuthenticationContext);
            await MultiStepClientLogin(result.SettingsForUser.NeedsAttribution);

            return new PlayFabResult<LoginResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Completes the Windows Hello login flow by returning the signed value of the challange from GetWindowsHelloChallenge.
        /// Windows Hello has a 2 step client to server authentication scheme. Step one is to request from the server a challenge
        /// string. Step two is to request the user sign the string via Windows Hello and then send the signed value back to the
        /// server.
        /// </summary>
        public async Task<PlayFabResult<LoginResult>> LoginWithWindowsHelloAsync(LoginWithWindowsHelloRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (request != null) request.TitleId = request?.TitleId ?? requestSettings.TitleId;
            if (request.TitleId == null) throw new PlayFabException(PlayFabExceptionCode.TitleNotSet, "Must be have PlayFabSettings.staticSettings.TitleId set to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/LoginWithWindowsHello", request, null, null, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<LoginResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<LoginResult>>(resultRawJson);
            var result = resultData.data;
            result.AuthenticationContext = new PlayFabAuthenticationContext(result.SessionTicket, result.EntityToken.EntityToken, result.PlayFabId, result.EntityToken.Entity.Id, result.EntityToken.Entity.Type);
            authenticationContext.CopyFrom(result.AuthenticationContext);
            await MultiStepClientLogin(result.SettingsForUser.NeedsAttribution);

            return new PlayFabResult<LoginResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Signs the user in using a Xbox Live Token, returning a session identifier that can subsequently be used for API calls
        /// which require an authenticated user
        /// </summary>
        public async Task<PlayFabResult<LoginResult>> LoginWithXboxAsync(LoginWithXboxRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (request != null) request.TitleId = request?.TitleId ?? requestSettings.TitleId;
            if (request.TitleId == null) throw new PlayFabException(PlayFabExceptionCode.TitleNotSet, "Must be have PlayFabSettings.staticSettings.TitleId set to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/LoginWithXbox", request, null, null, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<LoginResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<LoginResult>>(resultRawJson);
            var result = resultData.data;
            result.AuthenticationContext = new PlayFabAuthenticationContext(result.SessionTicket, result.EntityToken.EntityToken, result.PlayFabId, result.EntityToken.Entity.Id, result.EntityToken.Entity.Type);
            authenticationContext.CopyFrom(result.AuthenticationContext);
            await MultiStepClientLogin(result.SettingsForUser.NeedsAttribution);

            return new PlayFabResult<LoginResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Attempts to locate a game session matching the given parameters. If the goal is to match the player into a specific
        /// active session, only the LobbyId is required. Otherwise, the BuildVersion, GameMode, and Region are all required
        /// parameters. Note that parameters specified in the search are required (they are not weighting factors). If a slot is
        /// found in a server instance matching the parameters, the slot will be assigned to that player, removing it from the
        /// availabe set. In that case, the information on the game session will be returned, otherwise the Status returned will be
        /// GameNotFound.
        /// </summary>
        public async Task<PlayFabResult<MatchmakeResult>> MatchmakeAsync(MatchmakeRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/Matchmake", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<MatchmakeResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<MatchmakeResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<MatchmakeResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Opens a new outstanding trade. Note that a given item instance may only be in one open trade at a time.
        /// </summary>
        public async Task<PlayFabResult<OpenTradeResponse>> OpenTradeAsync(OpenTradeRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/OpenTrade", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<OpenTradeResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<OpenTradeResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<OpenTradeResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Selects a payment option for purchase order created via StartPurchase
        /// </summary>
        public async Task<PlayFabResult<PayForPurchaseResult>> PayForPurchaseAsync(PayForPurchaseRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/PayForPurchase", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<PayForPurchaseResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<PayForPurchaseResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<PayForPurchaseResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Buys a single item with virtual currency. You must specify both the virtual currency to use to purchase, as well as what
        /// the client believes the price to be. This lets the server fail the purchase if the price has changed.
        /// </summary>
        public async Task<PlayFabResult<PurchaseItemResult>> PurchaseItemAsync(PurchaseItemRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/PurchaseItem", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<PurchaseItemResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<PurchaseItemResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<PurchaseItemResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Adds the virtual goods associated with the coupon to the user's inventory. Coupons can be generated via the
        /// Economy->Catalogs tab in the PlayFab Game Manager.
        /// </summary>
        public async Task<PlayFabResult<RedeemCouponResult>> RedeemCouponAsync(RedeemCouponRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/RedeemCoupon", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<RedeemCouponResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<RedeemCouponResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<RedeemCouponResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Uses the supplied OAuth code to refresh the internally cached player PSN auth token
        /// </summary>
        public async Task<PlayFabResult<EmptyResponse>> RefreshPSNAuthTokenAsync(RefreshPSNAuthTokenRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/RefreshPSNAuthToken", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<EmptyResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<EmptyResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<EmptyResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Registers the iOS device to receive push notifications
        /// </summary>
        public async Task<PlayFabResult<RegisterForIOSPushNotificationResult>> RegisterForIOSPushNotificationAsync(RegisterForIOSPushNotificationRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/RegisterForIOSPushNotification", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<RegisterForIOSPushNotificationResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<RegisterForIOSPushNotificationResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<RegisterForIOSPushNotificationResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Registers a new Playfab user account, returning a session identifier that can subsequently be used for API calls which
        /// require an authenticated user. You must supply either a username or an email address.
        /// </summary>
        public async Task<PlayFabResult<RegisterPlayFabUserResult>> RegisterPlayFabUserAsync(RegisterPlayFabUserRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (request != null) request.TitleId = request?.TitleId ?? requestSettings.TitleId;
            if (request.TitleId == null) throw new PlayFabException(PlayFabExceptionCode.TitleNotSet, "Must be have PlayFabSettings.staticSettings.TitleId set to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/RegisterPlayFabUser", request, null, null, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<RegisterPlayFabUserResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<RegisterPlayFabUserResult>>(resultRawJson);
            var result = resultData.data;
            result.AuthenticationContext = new PlayFabAuthenticationContext(result.SessionTicket, result.EntityToken.EntityToken, result.PlayFabId, result.EntityToken.Entity.Id, result.EntityToken.Entity.Type);
            authenticationContext.CopyFrom(result.AuthenticationContext);
            await MultiStepClientLogin(result.SettingsForUser.NeedsAttribution);

            return new PlayFabResult<RegisterPlayFabUserResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Registers a new PlayFab user account using Windows Hello authentication, returning a session ticket that can
        /// subsequently be used for API calls which require an authenticated user
        /// </summary>
        public async Task<PlayFabResult<LoginResult>> RegisterWithWindowsHelloAsync(RegisterWithWindowsHelloRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (request != null) request.TitleId = request?.TitleId ?? requestSettings.TitleId;
            if (request.TitleId == null) throw new PlayFabException(PlayFabExceptionCode.TitleNotSet, "Must be have PlayFabSettings.staticSettings.TitleId set to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/RegisterWithWindowsHello", request, null, null, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<LoginResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<LoginResult>>(resultRawJson);
            var result = resultData.data;
            result.AuthenticationContext = new PlayFabAuthenticationContext(result.SessionTicket, result.EntityToken.EntityToken, result.PlayFabId, result.EntityToken.Entity.Id, result.EntityToken.Entity.Type);
            authenticationContext.CopyFrom(result.AuthenticationContext);
            await MultiStepClientLogin(result.SettingsForUser.NeedsAttribution);

            return new PlayFabResult<LoginResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Removes a contact email from the player's profile.
        /// </summary>
        public async Task<PlayFabResult<RemoveContactEmailResult>> RemoveContactEmailAsync(RemoveContactEmailRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/RemoveContactEmail", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<RemoveContactEmailResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<RemoveContactEmailResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<RemoveContactEmailResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Removes a specified user from the friend list of the local user
        /// </summary>
        public async Task<PlayFabResult<RemoveFriendResult>> RemoveFriendAsync(RemoveFriendRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/RemoveFriend", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<RemoveFriendResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<RemoveFriendResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<RemoveFriendResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Removes the specified generic service identifier from the player's PlayFab account.
        /// </summary>
        public async Task<PlayFabResult<RemoveGenericIDResult>> RemoveGenericIDAsync(RemoveGenericIDRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/RemoveGenericID", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<RemoveGenericIDResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<RemoveGenericIDResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<RemoveGenericIDResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Removes users from the set of those able to update the shared data and the set of users in the group. Only users in the
        /// group can remove members. If as a result of the call, zero users remain with access, the group and its associated data
        /// will be deleted. Shared Groups are designed for sharing data between a very small number of players, please see our
        /// guide: https://api.playfab.com/docs/tutorials/landing-players/shared-groups
        /// </summary>
        public async Task<PlayFabResult<RemoveSharedGroupMembersResult>> RemoveSharedGroupMembersAsync(RemoveSharedGroupMembersRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/RemoveSharedGroupMembers", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<RemoveSharedGroupMembersResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<RemoveSharedGroupMembersResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<RemoveSharedGroupMembersResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Write a PlayStream event to describe the provided player device information. This API method is not designed to be
        /// called directly by developers. Each PlayFab client SDK will eventually report this information automatically.
        /// </summary>
        public async Task<PlayFabResult<EmptyResponse>> ReportDeviceInfoAsync(DeviceInfoRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/ReportDeviceInfo", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<EmptyResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<EmptyResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<EmptyResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Submit a report for another player (due to bad bahavior, etc.), so that customer service representatives for the title
        /// can take action concerning potentially toxic players.
        /// </summary>
        public async Task<PlayFabResult<ReportPlayerClientResult>> ReportPlayerAsync(ReportPlayerClientRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/ReportPlayer", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ReportPlayerClientResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ReportPlayerClientResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ReportPlayerClientResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Restores all in-app purchases based on the given restore receipt
        /// </summary>
        public async Task<PlayFabResult<RestoreIOSPurchasesResult>> RestoreIOSPurchasesAsync(RestoreIOSPurchasesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/RestoreIOSPurchases", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<RestoreIOSPurchasesResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<RestoreIOSPurchasesResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<RestoreIOSPurchasesResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Forces an email to be sent to the registered email address for the user's account, with a link allowing the user to
        /// change the password.If an account recovery email template ID is provided, an email using the custom email template will
        /// be used.
        /// </summary>
        public async Task<PlayFabResult<SendAccountRecoveryEmailResult>> SendAccountRecoveryEmailAsync(SendAccountRecoveryEmailRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;

            var httpResult = await PlayFabHttp.DoPost("/Client/SendAccountRecoveryEmail", request, null, null, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<SendAccountRecoveryEmailResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<SendAccountRecoveryEmailResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<SendAccountRecoveryEmailResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Updates the tag list for a specified user in the friend list of the local user
        /// </summary>
        public async Task<PlayFabResult<SetFriendTagsResult>> SetFriendTagsAsync(SetFriendTagsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/SetFriendTags", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<SetFriendTagsResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<SetFriendTagsResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<SetFriendTagsResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Sets the player's secret if it is not already set. Player secrets are used to sign API requests. To reset a player's
        /// secret use the Admin or Server API method SetPlayerSecret.
        /// </summary>
        public async Task<PlayFabResult<SetPlayerSecretResult>> SetPlayerSecretAsync(SetPlayerSecretRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/SetPlayerSecret", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<SetPlayerSecretResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<SetPlayerSecretResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<SetPlayerSecretResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Start a new game server with a given configuration, add the current player and return the connection information.
        /// </summary>
        public async Task<PlayFabResult<StartGameResult>> StartGameAsync(StartGameRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/StartGame", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<StartGameResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<StartGameResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<StartGameResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Creates an order for a list of items from the title catalog
        /// </summary>
        public async Task<PlayFabResult<StartPurchaseResult>> StartPurchaseAsync(StartPurchaseRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/StartPurchase", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<StartPurchaseResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<StartPurchaseResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<StartPurchaseResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Decrements the user's balance of the specified virtual currency by the stated amount. It is possible to make a VC
        /// balance negative with this API.
        /// </summary>
        public async Task<PlayFabResult<ModifyUserVirtualCurrencyResult>> SubtractUserVirtualCurrencyAsync(SubtractUserVirtualCurrencyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/SubtractUserVirtualCurrency", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ModifyUserVirtualCurrencyResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ModifyUserVirtualCurrencyResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ModifyUserVirtualCurrencyResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Unlinks the related Android device identifier from the user's PlayFab account
        /// </summary>
        public async Task<PlayFabResult<UnlinkAndroidDeviceIDResult>> UnlinkAndroidDeviceIDAsync(UnlinkAndroidDeviceIDRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/UnlinkAndroidDeviceID", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<UnlinkAndroidDeviceIDResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<UnlinkAndroidDeviceIDResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<UnlinkAndroidDeviceIDResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Unlinks the related custom identifier from the user's PlayFab account
        /// </summary>
        public async Task<PlayFabResult<UnlinkCustomIDResult>> UnlinkCustomIDAsync(UnlinkCustomIDRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/UnlinkCustomID", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<UnlinkCustomIDResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<UnlinkCustomIDResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<UnlinkCustomIDResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Unlinks the related Facebook account from the user's PlayFab account
        /// </summary>
        public async Task<PlayFabResult<UnlinkFacebookAccountResult>> UnlinkFacebookAccountAsync(UnlinkFacebookAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/UnlinkFacebookAccount", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<UnlinkFacebookAccountResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<UnlinkFacebookAccountResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<UnlinkFacebookAccountResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Unlinks the related Facebook Instant Game Ids from the user's PlayFab account
        /// </summary>
        public async Task<PlayFabResult<UnlinkFacebookInstantGamesIdResult>> UnlinkFacebookInstantGamesIdAsync(UnlinkFacebookInstantGamesIdRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/UnlinkFacebookInstantGamesId", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<UnlinkFacebookInstantGamesIdResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<UnlinkFacebookInstantGamesIdResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<UnlinkFacebookInstantGamesIdResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Unlinks the related Game Center account from the user's PlayFab account
        /// </summary>
        public async Task<PlayFabResult<UnlinkGameCenterAccountResult>> UnlinkGameCenterAccountAsync(UnlinkGameCenterAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/UnlinkGameCenterAccount", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<UnlinkGameCenterAccountResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<UnlinkGameCenterAccountResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<UnlinkGameCenterAccountResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Unlinks the related Google account from the user's PlayFab account
        /// (https://developers.google.com/android/reference/com/google/android/gms/auth/GoogleAuthUtil#public-methods).
        /// </summary>
        public async Task<PlayFabResult<UnlinkGoogleAccountResult>> UnlinkGoogleAccountAsync(UnlinkGoogleAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/UnlinkGoogleAccount", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<UnlinkGoogleAccountResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<UnlinkGoogleAccountResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<UnlinkGoogleAccountResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Unlinks the related iOS device identifier from the user's PlayFab account
        /// </summary>
        public async Task<PlayFabResult<UnlinkIOSDeviceIDResult>> UnlinkIOSDeviceIDAsync(UnlinkIOSDeviceIDRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/UnlinkIOSDeviceID", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<UnlinkIOSDeviceIDResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<UnlinkIOSDeviceIDResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<UnlinkIOSDeviceIDResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Unlinks the related Kongregate identifier from the user's PlayFab account
        /// </summary>
        public async Task<PlayFabResult<UnlinkKongregateAccountResult>> UnlinkKongregateAsync(UnlinkKongregateAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/UnlinkKongregate", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<UnlinkKongregateAccountResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<UnlinkKongregateAccountResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<UnlinkKongregateAccountResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Unlinks the related NintendoSwitchDeviceId from the user's PlayFab account
        /// </summary>
        public async Task<PlayFabResult<UnlinkNintendoSwitchDeviceIdResult>> UnlinkNintendoSwitchDeviceIdAsync(UnlinkNintendoSwitchDeviceIdRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/UnlinkNintendoSwitchDeviceId", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<UnlinkNintendoSwitchDeviceIdResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<UnlinkNintendoSwitchDeviceIdResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<UnlinkNintendoSwitchDeviceIdResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Unlinks an OpenID Connect account from a user's PlayFab account, based on the connection ID of an existing relationship
        /// between a title and an Open ID Connect provider.
        /// </summary>
        public async Task<PlayFabResult<EmptyResponse>> UnlinkOpenIdConnectAsync(UninkOpenIdConnectRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/UnlinkOpenIdConnect", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<EmptyResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<EmptyResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<EmptyResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Unlinks the related PSN account from the user's PlayFab account
        /// </summary>
        public async Task<PlayFabResult<UnlinkPSNAccountResult>> UnlinkPSNAccountAsync(UnlinkPSNAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/UnlinkPSNAccount", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<UnlinkPSNAccountResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<UnlinkPSNAccountResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<UnlinkPSNAccountResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Unlinks the related Steam account from the user's PlayFab account
        /// </summary>
        public async Task<PlayFabResult<UnlinkSteamAccountResult>> UnlinkSteamAccountAsync(UnlinkSteamAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/UnlinkSteamAccount", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<UnlinkSteamAccountResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<UnlinkSteamAccountResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<UnlinkSteamAccountResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Unlinks the related Twitch account from the user's PlayFab account.
        /// </summary>
        public async Task<PlayFabResult<UnlinkTwitchAccountResult>> UnlinkTwitchAsync(UnlinkTwitchAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/UnlinkTwitch", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<UnlinkTwitchAccountResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<UnlinkTwitchAccountResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<UnlinkTwitchAccountResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Unlink Windows Hello authentication from the current PlayFab Account
        /// </summary>
        public async Task<PlayFabResult<UnlinkWindowsHelloAccountResponse>> UnlinkWindowsHelloAsync(UnlinkWindowsHelloAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/UnlinkWindowsHello", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<UnlinkWindowsHelloAccountResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<UnlinkWindowsHelloAccountResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<UnlinkWindowsHelloAccountResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Unlinks the related Xbox Live account from the user's PlayFab account
        /// </summary>
        public async Task<PlayFabResult<UnlinkXboxAccountResult>> UnlinkXboxAccountAsync(UnlinkXboxAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/UnlinkXboxAccount", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<UnlinkXboxAccountResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<UnlinkXboxAccountResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<UnlinkXboxAccountResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Opens the specified container, with the specified key (when required), and returns the contents of the opened container.
        /// If the container (and key when relevant) are consumable (RemainingUses > 0), their RemainingUses will be decremented,
        /// consistent with the operation of ConsumeItem.
        /// </summary>
        public async Task<PlayFabResult<UnlockContainerItemResult>> UnlockContainerInstanceAsync(UnlockContainerInstanceRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/UnlockContainerInstance", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<UnlockContainerItemResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<UnlockContainerItemResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<UnlockContainerItemResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Searches target inventory for an ItemInstance matching the given CatalogItemId, if necessary unlocks it using an
        /// appropriate key, and returns the contents of the opened container. If the container (and key when relevant) are
        /// consumable (RemainingUses > 0), their RemainingUses will be decremented, consistent with the operation of ConsumeItem.
        /// </summary>
        public async Task<PlayFabResult<UnlockContainerItemResult>> UnlockContainerItemAsync(UnlockContainerItemRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/UnlockContainerItem", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<UnlockContainerItemResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<UnlockContainerItemResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<UnlockContainerItemResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Update the avatar URL of the player
        /// </summary>
        public async Task<PlayFabResult<EmptyResponse>> UpdateAvatarUrlAsync(UpdateAvatarUrlRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/UpdateAvatarUrl", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<EmptyResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<EmptyResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<EmptyResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Creates and updates the title-specific custom data for the user's character which is readable and writable by the client
        /// </summary>
        public async Task<PlayFabResult<UpdateCharacterDataResult>> UpdateCharacterDataAsync(UpdateCharacterDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/UpdateCharacterData", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<UpdateCharacterDataResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<UpdateCharacterDataResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<UpdateCharacterDataResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Updates the values of the specified title-specific statistics for the specific character. By default, clients are not
        /// permitted to update statistics. Developers may override this setting in the Game Manager > Settings > API Features.
        /// </summary>
        public async Task<PlayFabResult<UpdateCharacterStatisticsResult>> UpdateCharacterStatisticsAsync(UpdateCharacterStatisticsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/UpdateCharacterStatistics", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<UpdateCharacterStatisticsResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<UpdateCharacterStatisticsResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<UpdateCharacterStatisticsResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Updates the values of the specified title-specific statistics for the user. By default, clients are not permitted to
        /// update statistics. Developers may override this setting in the Game Manager > Settings > API Features.
        /// </summary>
        public async Task<PlayFabResult<UpdatePlayerStatisticsResult>> UpdatePlayerStatisticsAsync(UpdatePlayerStatisticsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/UpdatePlayerStatistics", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<UpdatePlayerStatisticsResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<UpdatePlayerStatisticsResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<UpdatePlayerStatisticsResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Adds, updates, and removes data keys for a shared group object. If the permission is set to Public, all fields updated
        /// or added in this call will be readable by users not in the group. By default, data permissions are set to Private.
        /// Regardless of the permission setting, only members of the group can update the data. Shared Groups are designed for
        /// sharing data between a very small number of players, please see our guide:
        /// https://api.playfab.com/docs/tutorials/landing-players/shared-groups
        /// </summary>
        public async Task<PlayFabResult<UpdateSharedGroupDataResult>> UpdateSharedGroupDataAsync(UpdateSharedGroupDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/UpdateSharedGroupData", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<UpdateSharedGroupDataResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<UpdateSharedGroupDataResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<UpdateSharedGroupDataResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Creates and updates the title-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public async Task<PlayFabResult<UpdateUserDataResult>> UpdateUserDataAsync(UpdateUserDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/UpdateUserData", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<UpdateUserDataResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<UpdateUserDataResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<UpdateUserDataResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Creates and updates the publisher-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public async Task<PlayFabResult<UpdateUserDataResult>> UpdateUserPublisherDataAsync(UpdateUserDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/UpdateUserPublisherData", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<UpdateUserDataResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<UpdateUserDataResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<UpdateUserDataResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Updates the title specific display name for the user
        /// </summary>
        public async Task<PlayFabResult<UpdateUserTitleDisplayNameResult>> UpdateUserTitleDisplayNameAsync(UpdateUserTitleDisplayNameRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/UpdateUserTitleDisplayName", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<UpdateUserTitleDisplayNameResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<UpdateUserTitleDisplayNameResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<UpdateUserTitleDisplayNameResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Validates with Amazon that the receipt for an Amazon App Store in-app purchase is valid and that it matches the
        /// purchased catalog item
        /// </summary>
        public async Task<PlayFabResult<ValidateAmazonReceiptResult>> ValidateAmazonIAPReceiptAsync(ValidateAmazonReceiptRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/ValidateAmazonIAPReceipt", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ValidateAmazonReceiptResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ValidateAmazonReceiptResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ValidateAmazonReceiptResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Validates a Google Play purchase and gives the corresponding item to the player.
        /// </summary>
        public async Task<PlayFabResult<ValidateGooglePlayPurchaseResult>> ValidateGooglePlayPurchaseAsync(ValidateGooglePlayPurchaseRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/ValidateGooglePlayPurchase", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ValidateGooglePlayPurchaseResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ValidateGooglePlayPurchaseResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ValidateGooglePlayPurchaseResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Validates with the Apple store that the receipt for an iOS in-app purchase is valid and that it matches the purchased
        /// catalog item
        /// </summary>
        public async Task<PlayFabResult<ValidateIOSReceiptResult>> ValidateIOSReceiptAsync(ValidateIOSReceiptRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/ValidateIOSReceipt", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ValidateIOSReceiptResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ValidateIOSReceiptResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ValidateIOSReceiptResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Validates with Windows that the receipt for an Windows App Store in-app purchase is valid and that it matches the
        /// purchased catalog item
        /// </summary>
        public async Task<PlayFabResult<ValidateWindowsReceiptResult>> ValidateWindowsStoreReceiptAsync(ValidateWindowsReceiptRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/ValidateWindowsStoreReceipt", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ValidateWindowsReceiptResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ValidateWindowsReceiptResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ValidateWindowsReceiptResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Writes a character-based event into PlayStream.
        /// </summary>
        public async Task<PlayFabResult<WriteEventResponse>> WriteCharacterEventAsync(WriteClientCharacterEventRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/WriteCharacterEvent", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<WriteEventResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<WriteEventResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<WriteEventResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Writes a player-based event into PlayStream.
        /// </summary>
        public async Task<PlayFabResult<WriteEventResponse>> WritePlayerEventAsync(WriteClientPlayerEventRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/WritePlayerEvent", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<WriteEventResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<WriteEventResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<WriteEventResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Writes a title-based event into PlayStream.
        /// </summary>
        public async Task<PlayFabResult<WriteEventResponse>> WriteTitleEventAsync(WriteTitleEventRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var context = request?.AuthenticationContext ?? authenticationContext; var clientSessionTicket = context.ClientSessionTicket;
            if (clientSessionTicket == null) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Client/WriteTitleEvent", request, "X-Authorization", clientSessionTicket, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<WriteEventResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<WriteEventResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<WriteEventResponse> { Result = result, CustomData = customData };
        }

        private async Task<PlayFabResult<AttributeInstallResult>> MultiStepClientLogin(bool needsAttribution)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (needsAttribution && !requestSettings.DisableAdvertising && !string.IsNullOrEmpty(requestSettings.AdvertisingIdType) && !string.IsNullOrEmpty(requestSettings.AdvertisingIdValue))
            {
                var request = new AttributeInstallRequest();
                if (requestSettings.AdvertisingIdType == PlayFabSettings.AD_TYPE_IDFA)
                    request.Idfa = requestSettings.AdvertisingIdValue;
                else if (requestSettings.AdvertisingIdType == PlayFabSettings.AD_TYPE_ANDROID_ID)
                    request.Adid = requestSettings.AdvertisingIdValue;
                else
                    return null;
                return await AttributeInstallAsync(request);
            }
            return null;
        }
    }
}
#endif
