#if ENABLE_PLAYFABSERVER_API && !DISABLE_PLAYFAB_STATIC_API

using PlayFab.ServerModels;
using PlayFab.Internal;
#pragma warning disable 0649
using System;
// This is required for the Obsolete Attribute flag
//  which is not always present in all API's
#pragma warning restore 0649
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayFab
{
    /// <summary>
    /// Provides functionality to allow external (developer-controlled) servers to interact with user inventories and data in a
    /// trusted manner, and to handle matchmaking and client connection orchestration
    /// </summary>
    public static class PlayFabServerAPI
    {
        /// <summary>
        /// Clear the Client SessionToken which allows this Client to call API calls requiring login.
        /// A new/fresh login will be required after calling this.
        /// </summary>
        public static void ForgetAllCredentials()
        {
            PlayFabSettings.staticPlayer.ForgetAllCredentials();
        }

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Increments the character's balance of the specified virtual currency by the stated amount
        /// </summary>
        public static async Task<PlayFabResult<ModifyCharacterVirtualCurrencyResult>> AddCharacterVirtualCurrencyAsync(AddCharacterVirtualCurrencyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/AddCharacterVirtualCurrency", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ModifyCharacterVirtualCurrencyResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ModifyCharacterVirtualCurrencyResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ModifyCharacterVirtualCurrencyResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Adds the Friend user to the friendlist of the user with PlayFabId. At least one of
        /// FriendPlayFabId,FriendUsername,FriendEmail, or FriendTitleDisplayName should be initialized.
        /// </summary>
        public static async Task<PlayFabResult<EmptyResponse>> AddFriendAsync(AddFriendRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/AddFriend", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Adds the specified generic service identifier to the player's PlayFab account. This is designed to allow for a PlayFab
        /// ID lookup of any arbitrary service identifier a title wants to add. This identifier should never be used as
        /// authentication credentials, as the intent is that it is easily accessible by other players.
        /// </summary>
        public static async Task<PlayFabResult<EmptyResult>> AddGenericIDAsync(AddGenericIDRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/AddGenericID", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Adds a given tag to a player profile. The tag's namespace is automatically generated based on the source of the tag.
        /// </summary>
        public static async Task<PlayFabResult<AddPlayerTagResult>> AddPlayerTagAsync(AddPlayerTagRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/AddPlayerTag", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<AddPlayerTagResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<AddPlayerTagResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<AddPlayerTagResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Adds users to the set of those able to update both the shared data, as well as the set of users in the group. Only users
        /// in the group (and the server) can add new members. Shared Groups are designed for sharing data between a very small
        /// number of players, please see our guide:
        /// https://docs.microsoft.com/gaming/playfab/features/social/groups/using-shared-group-data
        /// </summary>
        public static async Task<PlayFabResult<AddSharedGroupMembersResult>> AddSharedGroupMembersAsync(AddSharedGroupMembersRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/AddSharedGroupMembers", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Increments the user's balance of the specified virtual currency by the stated amount
        /// </summary>
        public static async Task<PlayFabResult<ModifyUserVirtualCurrencyResult>> AddUserVirtualCurrencyAsync(AddUserVirtualCurrencyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/AddUserVirtualCurrency", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Validated a client's session ticket, and if successful, returns details for that user
        /// </summary>
        public static async Task<PlayFabResult<AuthenticateSessionTicketResult>> AuthenticateSessionTicketAsync(AuthenticateSessionTicketRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/AuthenticateSessionTicket", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<AuthenticateSessionTicketResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<AuthenticateSessionTicketResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<AuthenticateSessionTicketResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Awards the specified users the specified Steam achievements
        /// </summary>
        public static async Task<PlayFabResult<AwardSteamAchievementResult>> AwardSteamAchievementAsync(AwardSteamAchievementRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/AwardSteamAchievement", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<AwardSteamAchievementResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<AwardSteamAchievementResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<AwardSteamAchievementResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Bans users by PlayFab ID with optional IP address, or MAC address for the provided game.
        /// </summary>
        public static async Task<PlayFabResult<BanUsersResult>> BanUsersAsync(BanUsersRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/BanUsers", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<BanUsersResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<BanUsersResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<BanUsersResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Consume uses of a consumable item. When all uses are consumed, it will be removed from the player's
        /// inventory.
        /// </summary>
        public static async Task<PlayFabResult<ConsumeItemResult>> ConsumeItemAsync(ConsumeItemRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/ConsumeItem", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Requests the creation of a shared group object, containing key/value pairs which may be updated by all members of the
        /// group. When created by a server, the group will initially have no members. Shared Groups are designed for sharing data
        /// between a very small number of players, please see our guide:
        /// https://docs.microsoft.com/gaming/playfab/features/social/groups/using-shared-group-data
        /// </summary>
        public static async Task<PlayFabResult<CreateSharedGroupResult>> CreateSharedGroupAsync(CreateSharedGroupRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/CreateSharedGroup", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Deletes the specific character ID from the specified user.
        /// </summary>
        public static async Task<PlayFabResult<DeleteCharacterFromUserResult>> DeleteCharacterFromUserAsync(DeleteCharacterFromUserRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/DeleteCharacterFromUser", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<DeleteCharacterFromUserResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<DeleteCharacterFromUserResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<DeleteCharacterFromUserResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Removes a user's player account from a title and deletes all associated data
        /// </summary>
        public static async Task<PlayFabResult<DeletePlayerResult>> DeletePlayerAsync(DeletePlayerRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/DeletePlayer", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<DeletePlayerResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<DeletePlayerResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<DeletePlayerResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Deletes title-specific custom properties for a player
        /// </summary>
        public static async Task<PlayFabResult<DeletePlayerCustomPropertiesResult>> DeletePlayerCustomPropertiesAsync(DeletePlayerCustomPropertiesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/DeletePlayerCustomProperties", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<DeletePlayerCustomPropertiesResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<DeletePlayerCustomPropertiesResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<DeletePlayerCustomPropertiesResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Deletes push notification template for title
        /// </summary>
        public static async Task<PlayFabResult<DeletePushNotificationTemplateResult>> DeletePushNotificationTemplateAsync(DeletePushNotificationTemplateRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/DeletePushNotificationTemplate", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<DeletePushNotificationTemplateResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<DeletePushNotificationTemplateResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<DeletePushNotificationTemplateResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Deletes a shared group, freeing up the shared group ID to be reused for a new group. Shared Groups are designed for
        /// sharing data between a very small number of players, please see our guide:
        /// https://docs.microsoft.com/gaming/playfab/features/social/groups/using-shared-group-data
        /// </summary>
        public static async Task<PlayFabResult<EmptyResponse>> DeleteSharedGroupAsync(DeleteSharedGroupRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/DeleteSharedGroup", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Returns the result of an evaluation of a Random Result Table - the ItemId from the game Catalog which would
        /// have been added to the player inventory, if the Random Result Table were added via a Bundle or a call to
        /// UnlockContainer.
        /// </summary>
        public static async Task<PlayFabResult<EvaluateRandomResultTableResult>> EvaluateRandomResultTableAsync(EvaluateRandomResultTableRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/EvaluateRandomResultTable", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<EvaluateRandomResultTableResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<EvaluateRandomResultTableResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<EvaluateRandomResultTableResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Executes a CloudScript function, with the 'currentPlayerId' set to the PlayFab ID of the authenticated player. The
        /// PlayFab ID is the entity ID of the player's master_player_account entity.
        /// </summary>
        public static async Task<PlayFabResult<ExecuteCloudScriptResult>> ExecuteCloudScriptAsync(ExecuteCloudScriptServerRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/ExecuteCloudScript", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Retrieves an array of player segment definitions. Results from this can be used in subsequent API calls such as
        /// GetPlayersInSegment which requires a Segment ID. While segment names can change the ID for that segment will not change.
        /// </summary>
        public static async Task<PlayFabResult<GetAllSegmentsResult>> GetAllSegmentsAsync(GetAllSegmentsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GetAllSegments", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetAllSegmentsResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetAllSegmentsResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetAllSegmentsResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Lists all of the characters that belong to a specific user. CharacterIds are not globally unique; characterId must be
        /// evaluated with the parent PlayFabId to guarantee uniqueness.
        /// </summary>
        public static async Task<PlayFabResult<ListUsersCharactersResult>> GetAllUsersCharactersAsync(ListUsersCharactersRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GetAllUsersCharacters", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Retrieves the specified version of the title's catalog of virtual goods, including all defined properties
        /// </summary>
        public static async Task<PlayFabResult<GetCatalogItemsResult>> GetCatalogItemsAsync(GetCatalogItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GetCatalogItems", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Retrieves the title-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static async Task<PlayFabResult<GetCharacterDataResult>> GetCharacterDataAsync(GetCharacterDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GetCharacterData", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Retrieves the title-specific custom data for the user's character which cannot be accessed by the client
        /// </summary>
        public static async Task<PlayFabResult<GetCharacterDataResult>> GetCharacterInternalDataAsync(GetCharacterDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GetCharacterInternalData", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Retrieves the specified character's current inventory of virtual goods
        /// </summary>
        public static async Task<PlayFabResult<GetCharacterInventoryResult>> GetCharacterInventoryAsync(GetCharacterInventoryRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GetCharacterInventory", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        public static async Task<PlayFabResult<GetCharacterLeaderboardResult>> GetCharacterLeaderboardAsync(GetCharacterLeaderboardRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GetCharacterLeaderboard", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Retrieves the title-specific custom data for the user's character which can only be read by the client
        /// </summary>
        public static async Task<PlayFabResult<GetCharacterDataResult>> GetCharacterReadOnlyDataAsync(GetCharacterDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GetCharacterReadOnlyData", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Retrieves the details of all title-specific statistics for the specific character
        /// </summary>
        public static async Task<PlayFabResult<GetCharacterStatisticsResult>> GetCharacterStatisticsAsync(GetCharacterStatisticsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GetCharacterStatistics", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// https://community.playfab.com/hc/community/posts/205469488-How-to-upload-files-to-PlayFab-s-Content-Service. Also,
        /// please be aware that the Content service is specifically PlayFab's CDN offering, for which standard CDN rates apply.
        /// </summary>
        public static async Task<PlayFabResult<GetContentDownloadUrlResult>> GetContentDownloadUrlAsync(GetContentDownloadUrlRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GetContentDownloadUrl", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Retrieves a list of ranked friends of the given player for the given statistic, starting from the indicated point in the
        /// leaderboard
        /// </summary>
        public static async Task<PlayFabResult<GetLeaderboardResult>> GetFriendLeaderboardAsync(GetFriendLeaderboardRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GetFriendLeaderboard", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Retrieves the current friends for the user with PlayFabId, constrained to users who have PlayFab accounts. Friends from
        /// linked accounts (Facebook, Steam) are also included. You may optionally exclude some linked services' friends.
        /// </summary>
        public static async Task<PlayFabResult<GetFriendsListResult>> GetFriendsListAsync(GetFriendsListRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GetFriendsList", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Retrieves a list of ranked users for the given statistic, starting from the indicated point in the leaderboard
        /// </summary>
        public static async Task<PlayFabResult<GetLeaderboardResult>> GetLeaderboardAsync(GetLeaderboardRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GetLeaderboard", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Retrieves a list of ranked characters for the given statistic, centered on the requested user
        /// </summary>
        public static async Task<PlayFabResult<GetLeaderboardAroundCharacterResult>> GetLeaderboardAroundCharacterAsync(GetLeaderboardAroundCharacterRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GetLeaderboardAroundCharacter", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Retrieves a list of ranked users for the given statistic, centered on the currently signed-in user
        /// </summary>
        public static async Task<PlayFabResult<GetLeaderboardAroundUserResult>> GetLeaderboardAroundUserAsync(GetLeaderboardAroundUserRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GetLeaderboardAroundUser", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetLeaderboardAroundUserResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetLeaderboardAroundUserResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetLeaderboardAroundUserResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves a list of all of the user's characters for the given statistic.
        /// </summary>
        public static async Task<PlayFabResult<GetLeaderboardForUsersCharactersResult>> GetLeaderboardForUserCharactersAsync(GetLeaderboardForUsersCharactersRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GetLeaderboardForUserCharacters", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Returns whatever info is requested in the response for the user. Note that PII (like email address, facebook id) may be
        /// returned. All parameters default to false.
        /// </summary>
        public static async Task<PlayFabResult<GetPlayerCombinedInfoResult>> GetPlayerCombinedInfoAsync(GetPlayerCombinedInfoRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GetPlayerCombinedInfo", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Retrieves a title-specific custom property value for a player.
        /// </summary>
        public static async Task<PlayFabResult<GetPlayerCustomPropertyResult>> GetPlayerCustomPropertyAsync(GetPlayerCustomPropertyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GetPlayerCustomProperty", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetPlayerCustomPropertyResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetPlayerCustomPropertyResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetPlayerCustomPropertyResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves the player's profile
        /// </summary>
        public static async Task<PlayFabResult<GetPlayerProfileResult>> GetPlayerProfileAsync(GetPlayerProfileRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GetPlayerProfile", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        public static async Task<PlayFabResult<GetPlayerSegmentsResult>> GetPlayerSegmentsAsync(GetPlayersSegmentsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GetPlayerSegments", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Allows for paging through all players in a given segment. This API creates a snapshot of all player profiles that match
        /// the segment definition at the time of its creation and lives through the Total Seconds to Live, refreshing its life span
        /// on each subsequent use of the Continuation Token. Profiles that change during the course of paging will not be reflected
        /// in the results. AB Test segments are currently not supported by this operation. NOTE: This API is limited to being
        /// called 30 times in one minute. You will be returned an error if you exceed this threshold.
        /// </summary>
        public static async Task<PlayFabResult<GetPlayersInSegmentResult>> GetPlayersInSegmentAsync(GetPlayersInSegmentRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GetPlayersInSegment", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetPlayersInSegmentResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetPlayersInSegmentResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetPlayersInSegmentResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves the current version and values for the indicated statistics, for the local player.
        /// </summary>
        public static async Task<PlayFabResult<GetPlayerStatisticsResult>> GetPlayerStatisticsAsync(GetPlayerStatisticsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GetPlayerStatistics", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        public static async Task<PlayFabResult<GetPlayerStatisticVersionsResult>> GetPlayerStatisticVersionsAsync(GetPlayerStatisticVersionsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GetPlayerStatisticVersions", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        public static async Task<PlayFabResult<GetPlayerTagsResult>> GetPlayerTagsAsync(GetPlayerTagsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GetPlayerTags", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Retrieves the unique PlayFab identifiers for the given set of Battle.net account identifiers.
        /// </summary>
        public static async Task<PlayFabResult<GetPlayFabIDsFromBattleNetAccountIdsResult>> GetPlayFabIDsFromBattleNetAccountIdsAsync(GetPlayFabIDsFromBattleNetAccountIdsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GetPlayFabIDsFromBattleNetAccountIds", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetPlayFabIDsFromBattleNetAccountIdsResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetPlayFabIDsFromBattleNetAccountIdsResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetPlayFabIDsFromBattleNetAccountIdsResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Facebook identifiers.
        /// </summary>
        public static async Task<PlayFabResult<GetPlayFabIDsFromFacebookIDsResult>> GetPlayFabIDsFromFacebookIDsAsync(GetPlayFabIDsFromFacebookIDsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GetPlayFabIDsFromFacebookIDs", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Retrieves the unique PlayFab identifiers for the given set of Facebook Instant Games identifiers.
        /// </summary>
        public static async Task<PlayFabResult<GetPlayFabIDsFromFacebookInstantGamesIdsResult>> GetPlayFabIDsFromFacebookInstantGamesIdsAsync(GetPlayFabIDsFromFacebookInstantGamesIdsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GetPlayFabIDsFromFacebookInstantGamesIds", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Retrieves the unique PlayFab identifiers for the given set of generic service identifiers. A generic identifier is the
        /// service name plus the service-specific ID for the player, as specified by the title when the generic identifier was
        /// added to the player account.
        /// </summary>
        public static async Task<PlayFabResult<GetPlayFabIDsFromGenericIDsResult>> GetPlayFabIDsFromGenericIDsAsync(GetPlayFabIDsFromGenericIDsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GetPlayFabIDsFromGenericIDs", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Retrieves the unique PlayFab identifiers for the given set of Nintendo Service Account identifiers.
        /// </summary>
        public static async Task<PlayFabResult<GetPlayFabIDsFromNintendoServiceAccountIdsResult>> GetPlayFabIDsFromNintendoServiceAccountIdsAsync(GetPlayFabIDsFromNintendoServiceAccountIdsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GetPlayFabIDsFromNintendoServiceAccountIds", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetPlayFabIDsFromNintendoServiceAccountIdsResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetPlayFabIDsFromNintendoServiceAccountIdsResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetPlayFabIDsFromNintendoServiceAccountIdsResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Nintendo Switch Device identifiers.
        /// </summary>
        public static async Task<PlayFabResult<GetPlayFabIDsFromNintendoSwitchDeviceIdsResult>> GetPlayFabIDsFromNintendoSwitchDeviceIdsAsync(GetPlayFabIDsFromNintendoSwitchDeviceIdsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GetPlayFabIDsFromNintendoSwitchDeviceIds", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Retrieves the unique PlayFab identifiers for the given set of PlayStation :tm: Network identifiers.
        /// </summary>
        public static async Task<PlayFabResult<GetPlayFabIDsFromPSNAccountIDsResult>> GetPlayFabIDsFromPSNAccountIDsAsync(GetPlayFabIDsFromPSNAccountIDsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GetPlayFabIDsFromPSNAccountIDs", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Retrieves the unique PlayFab identifiers for the given set of PlayStation :tm: Network identifiers.
        /// </summary>
        public static async Task<PlayFabResult<GetPlayFabIDsFromPSNOnlineIDsResult>> GetPlayFabIDsFromPSNOnlineIDsAsync(GetPlayFabIDsFromPSNOnlineIDsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GetPlayFabIDsFromPSNOnlineIDs", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetPlayFabIDsFromPSNOnlineIDsResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetPlayFabIDsFromPSNOnlineIDsResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetPlayFabIDsFromPSNOnlineIDsResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Steam identifiers. The Steam identifiers are the profile
        /// IDs for the user accounts, available as SteamId in the Steamworks Community API calls.
        /// </summary>
        public static async Task<PlayFabResult<GetPlayFabIDsFromSteamIDsResult>> GetPlayFabIDsFromSteamIDsAsync(GetPlayFabIDsFromSteamIDsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GetPlayFabIDsFromSteamIDs", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Retrieves the unique PlayFab identifiers for the given set of Steam identifiers. The Steam identifiers are persona
        /// names.
        /// </summary>
        public static async Task<PlayFabResult<GetPlayFabIDsFromSteamNamesResult>> GetPlayFabIDsFromSteamNamesAsync(GetPlayFabIDsFromSteamNamesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GetPlayFabIDsFromSteamNames", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetPlayFabIDsFromSteamNamesResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetPlayFabIDsFromSteamNamesResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetPlayFabIDsFromSteamNamesResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Twitch identifiers. The Twitch identifiers are the IDs for
        /// the user accounts, available as "_id" from the Twitch API methods (ex:
        /// https://github.com/justintv/Twitch-API/blob/master/v3_resources/users.md#get-usersuser).
        /// </summary>
        public static async Task<PlayFabResult<GetPlayFabIDsFromTwitchIDsResult>> GetPlayFabIDsFromTwitchIDsAsync(GetPlayFabIDsFromTwitchIDsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GetPlayFabIDsFromTwitchIDs", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        public static async Task<PlayFabResult<GetPlayFabIDsFromXboxLiveIDsResult>> GetPlayFabIDsFromXboxLiveIDsAsync(GetPlayFabIDsFromXboxLiveIDsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GetPlayFabIDsFromXboxLiveIDs", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        public static async Task<PlayFabResult<GetPublisherDataResult>> GetPublisherDataAsync(GetPublisherDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GetPublisherData", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Retrieves the configuration information for the specified random results tables for the title, including all
        /// ItemId values and weights
        /// </summary>
        public static async Task<PlayFabResult<GetRandomResultTablesResult>> GetRandomResultTablesAsync(GetRandomResultTablesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GetRandomResultTables", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetRandomResultTablesResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetRandomResultTablesResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetRandomResultTablesResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves the associated PlayFab account identifiers for the given set of server custom identifiers.
        /// </summary>
        public static async Task<PlayFabResult<GetServerCustomIDsFromPlayFabIDsResult>> GetServerCustomIDsFromPlayFabIDsAsync(GetServerCustomIDsFromPlayFabIDsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GetServerCustomIDsFromPlayFabIDs", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetServerCustomIDsFromPlayFabIDsResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetServerCustomIDsFromPlayFabIDsResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetServerCustomIDsFromPlayFabIDsResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves data stored in a shared group object, as well as the list of members in the group. The server can access all
        /// public and private group data. Shared Groups are designed for sharing data between a very small number of players,
        /// please see our guide: https://docs.microsoft.com/gaming/playfab/features/social/groups/using-shared-group-data
        /// </summary>
        public static async Task<PlayFabResult<GetSharedGroupDataResult>> GetSharedGroupDataAsync(GetSharedGroupDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GetSharedGroupData", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Retrieves the set of items defined for the specified store, including all prices defined, for the specified
        /// player
        /// </summary>
        public static async Task<PlayFabResult<GetStoreItemsResult>> GetStoreItemsAsync(GetStoreItemsServerRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GetStoreItems", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        public static async Task<PlayFabResult<GetTimeResult>> GetTimeAsync(GetTimeRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GetTime", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        public static async Task<PlayFabResult<GetTitleDataResult>> GetTitleDataAsync(GetTitleDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GetTitleData", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Retrieves the key-value store of custom internal title settings
        /// </summary>
        public static async Task<PlayFabResult<GetTitleDataResult>> GetTitleInternalDataAsync(GetTitleDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GetTitleInternalData", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        public static async Task<PlayFabResult<GetTitleNewsResult>> GetTitleNewsAsync(GetTitleNewsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GetTitleNews", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Retrieves the relevant details for a specified user
        /// </summary>
        public static async Task<PlayFabResult<GetUserAccountInfoResult>> GetUserAccountInfoAsync(GetUserAccountInfoRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GetUserAccountInfo", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetUserAccountInfoResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetUserAccountInfoResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetUserAccountInfoResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Gets all bans for a user.
        /// </summary>
        public static async Task<PlayFabResult<GetUserBansResult>> GetUserBansAsync(GetUserBansRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GetUserBans", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetUserBansResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetUserBansResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetUserBansResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static async Task<PlayFabResult<GetUserDataResult>> GetUserDataAsync(GetUserDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GetUserData", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Retrieves the title-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        public static async Task<PlayFabResult<GetUserDataResult>> GetUserInternalDataAsync(GetUserDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GetUserInternalData", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Retrieves the specified user's current inventory of virtual goods
        /// </summary>
        public static async Task<PlayFabResult<GetUserInventoryResult>> GetUserInventoryAsync(GetUserInventoryRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GetUserInventory", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        public static async Task<PlayFabResult<GetUserDataResult>> GetUserPublisherDataAsync(GetUserDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GetUserPublisherData", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Retrieves the publisher-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        public static async Task<PlayFabResult<GetUserDataResult>> GetUserPublisherInternalDataAsync(GetUserDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GetUserPublisherInternalData", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        public static async Task<PlayFabResult<GetUserDataResult>> GetUserPublisherReadOnlyDataAsync(GetUserDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GetUserPublisherReadOnlyData", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        public static async Task<PlayFabResult<GetUserDataResult>> GetUserReadOnlyDataAsync(GetUserDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GetUserReadOnlyData", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Grants the specified character type to the user. CharacterIds are not globally unique; characterId must be evaluated
        /// with the parent PlayFabId to guarantee uniqueness.
        /// </summary>
        public static async Task<PlayFabResult<GrantCharacterToUserResult>> GrantCharacterToUserAsync(GrantCharacterToUserRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GrantCharacterToUser", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Adds the specified items to the specified character's inventory
        /// </summary>
        public static async Task<PlayFabResult<GrantItemsToCharacterResult>> GrantItemsToCharacterAsync(GrantItemsToCharacterRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GrantItemsToCharacter", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GrantItemsToCharacterResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GrantItemsToCharacterResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GrantItemsToCharacterResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Adds the specified items to the specified user's inventory
        /// </summary>
        public static async Task<PlayFabResult<GrantItemsToUserResult>> GrantItemsToUserAsync(GrantItemsToUserRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GrantItemsToUser", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GrantItemsToUserResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GrantItemsToUserResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GrantItemsToUserResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Adds the specified items to the specified user inventories
        /// </summary>
        public static async Task<PlayFabResult<GrantItemsToUsersResult>> GrantItemsToUsersAsync(GrantItemsToUsersRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/GrantItemsToUsers", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GrantItemsToUsersResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GrantItemsToUsersResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GrantItemsToUsersResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Links the Battle.net account associated with the token to the user's PlayFab account.
        /// </summary>
        public static async Task<PlayFabResult<EmptyResult>> LinkBattleNetAccountAsync(LinkBattleNetAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/LinkBattleNetAccount", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Links the Nintendo account associated with the token to the user's PlayFab account
        /// </summary>
        public static async Task<PlayFabResult<EmptyResult>> LinkNintendoServiceAccountAsync(LinkNintendoServiceAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/LinkNintendoServiceAccount", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Links the Nintendo account associated with the Nintendo Service Account subject or id to the user's PlayFab account
        /// </summary>
        public static async Task<PlayFabResult<EmptyResult>> LinkNintendoServiceAccountSubjectAsync(LinkNintendoServiceAccountSubjectRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/LinkNintendoServiceAccountSubject", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Links the NintendoSwitchDeviceId to the user's PlayFab account
        /// </summary>
        public static async Task<PlayFabResult<LinkNintendoSwitchDeviceIdResult>> LinkNintendoSwitchDeviceIdAsync(LinkNintendoSwitchDeviceIdRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/LinkNintendoSwitchDeviceId", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Links the PlayStation :tm: Network account associated with the provided access code to the user's PlayFab account
        /// </summary>
        public static async Task<PlayFabResult<LinkPSNAccountResult>> LinkPSNAccountAsync(LinkPSNAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/LinkPSNAccount", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Links the PlayStation :tm: Network account associated with the provided user id to the user's PlayFab account
        /// </summary>
        public static async Task<PlayFabResult<LinkPSNIdResponse>> LinkPSNIdAsync(LinkPSNIdRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/LinkPSNId", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<LinkPSNIdResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<LinkPSNIdResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<LinkPSNIdResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Links the custom server identifier, generated by the title, to the user's PlayFab account.
        /// </summary>
        public static async Task<PlayFabResult<LinkServerCustomIdResult>> LinkServerCustomIdAsync(LinkServerCustomIdRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/LinkServerCustomId", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<LinkServerCustomIdResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<LinkServerCustomIdResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<LinkServerCustomIdResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Links the Steam account associated with the provided Steam ID to the user's PlayFab account
        /// </summary>
        public static async Task<PlayFabResult<LinkSteamIdResult>> LinkSteamIdAsync(LinkSteamIdRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/LinkSteamId", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<LinkSteamIdResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<LinkSteamIdResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<LinkSteamIdResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Links the Xbox Live account associated with the provided access code to the user's PlayFab account
        /// </summary>
        public static async Task<PlayFabResult<LinkXboxAccountResult>> LinkXboxAccountAsync(LinkXboxAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/LinkXboxAccount", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Retrieves title-specific custom property values for a player.
        /// </summary>
        public static async Task<PlayFabResult<ListPlayerCustomPropertiesResult>> ListPlayerCustomPropertiesAsync(ListPlayerCustomPropertiesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/ListPlayerCustomProperties", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ListPlayerCustomPropertiesResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ListPlayerCustomPropertiesResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ListPlayerCustomPropertiesResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Signs the user in using the Android device identifier, returning a session identifier that can subsequently be used for
        /// API calls which require an authenticated user
        /// </summary>
        public static async Task<PlayFabResult<ServerLoginResult>> LoginWithAndroidDeviceIDAsync(LoginWithAndroidDeviceIDRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/LoginWithAndroidDeviceID", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ServerLoginResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ServerLoginResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ServerLoginResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Sign in the user with a Battle.net identity token
        /// </summary>
        public static async Task<PlayFabResult<ServerLoginResult>> LoginWithBattleNetAsync(LoginWithBattleNetRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/LoginWithBattleNet", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ServerLoginResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ServerLoginResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ServerLoginResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Signs the user in using a custom unique identifier generated by the title, returning a session identifier that can
        /// subsequently be used for API calls which require an authenticated user
        /// </summary>
        public static async Task<PlayFabResult<ServerLoginResult>> LoginWithCustomIDAsync(LoginWithCustomIDRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/LoginWithCustomID", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ServerLoginResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ServerLoginResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ServerLoginResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Signs the user in using the iOS device identifier, returning a session identifier that can subsequently be used for API
        /// calls which require an authenticated user
        /// </summary>
        public static async Task<PlayFabResult<ServerLoginResult>> LoginWithIOSDeviceIDAsync(LoginWithIOSDeviceIDRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/LoginWithIOSDeviceID", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ServerLoginResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ServerLoginResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ServerLoginResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Signs the user in using a PlayStation :tm: Network authentication code, returning a session identifier that can
        /// subsequently be used for API calls which require an authenticated user
        /// </summary>
        public static async Task<PlayFabResult<ServerLoginResult>> LoginWithPSNAsync(LoginWithPSNRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/LoginWithPSN", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ServerLoginResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ServerLoginResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ServerLoginResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Securely login a game client from an external server backend using a custom identifier for that player. Server Custom ID
        /// and Client Custom ID are mutually exclusive and cannot be used to retrieve the same player account.
        /// </summary>
        public static async Task<PlayFabResult<ServerLoginResult>> LoginWithServerCustomIdAsync(LoginWithServerCustomIdRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/LoginWithServerCustomId", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ServerLoginResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ServerLoginResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ServerLoginResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Signs the user in using an Steam ID, returning a session identifier that can subsequently be used for API calls which
        /// require an authenticated user
        /// </summary>
        public static async Task<PlayFabResult<ServerLoginResult>> LoginWithSteamIdAsync(LoginWithSteamIdRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/LoginWithSteamId", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ServerLoginResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ServerLoginResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ServerLoginResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Signs the user in using a Xbox Live Token from an external server backend, returning a session identifier that can
        /// subsequently be used for API calls which require an authenticated user
        /// </summary>
        public static async Task<PlayFabResult<ServerLoginResult>> LoginWithXboxAsync(LoginWithXboxRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/LoginWithXbox", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ServerLoginResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ServerLoginResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ServerLoginResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Signs the user in using an Xbox ID and Sandbox ID, returning a session identifier that can subsequently be used for API
        /// calls which require an authenticated user
        /// </summary>
        public static async Task<PlayFabResult<ServerLoginResult>> LoginWithXboxIdAsync(LoginWithXboxIdRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/LoginWithXboxId", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ServerLoginResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ServerLoginResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ServerLoginResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Modifies the number of remaining uses of a player's inventory item
        /// </summary>
        public static async Task<PlayFabResult<ModifyItemUsesResult>> ModifyItemUsesAsync(ModifyItemUsesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/ModifyItemUses", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ModifyItemUsesResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ModifyItemUsesResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ModifyItemUsesResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Moves an item from a character's inventory into another of the users's character's inventory.
        /// </summary>
        public static async Task<PlayFabResult<MoveItemToCharacterFromCharacterResult>> MoveItemToCharacterFromCharacterAsync(MoveItemToCharacterFromCharacterRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/MoveItemToCharacterFromCharacter", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<MoveItemToCharacterFromCharacterResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<MoveItemToCharacterFromCharacterResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<MoveItemToCharacterFromCharacterResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Moves an item from a user's inventory into their character's inventory.
        /// </summary>
        public static async Task<PlayFabResult<MoveItemToCharacterFromUserResult>> MoveItemToCharacterFromUserAsync(MoveItemToCharacterFromUserRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/MoveItemToCharacterFromUser", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<MoveItemToCharacterFromUserResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<MoveItemToCharacterFromUserResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<MoveItemToCharacterFromUserResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Moves an item from a character's inventory into the owning user's inventory.
        /// </summary>
        public static async Task<PlayFabResult<MoveItemToUserFromCharacterResult>> MoveItemToUserFromCharacterAsync(MoveItemToUserFromCharacterRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/MoveItemToUserFromCharacter", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<MoveItemToUserFromCharacterResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<MoveItemToUserFromCharacterResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<MoveItemToUserFromCharacterResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Adds the virtual goods associated with the coupon to the user's inventory. Coupons can be generated via the
        /// Economy->Catalogs tab in the PlayFab Game Manager.
        /// </summary>
        public static async Task<PlayFabResult<RedeemCouponResult>> RedeemCouponAsync(RedeemCouponRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/RedeemCoupon", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Removes the specified friend from the the user's friend list
        /// </summary>
        public static async Task<PlayFabResult<EmptyResponse>> RemoveFriendAsync(RemoveFriendRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/RemoveFriend", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Removes the specified generic service identifier from the player's PlayFab account.
        /// </summary>
        public static async Task<PlayFabResult<EmptyResult>> RemoveGenericIDAsync(RemoveGenericIDRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/RemoveGenericID", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Remove a given tag from a player profile. The tag's namespace is automatically generated based on the source of the tag.
        /// </summary>
        public static async Task<PlayFabResult<RemovePlayerTagResult>> RemovePlayerTagAsync(RemovePlayerTagRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/RemovePlayerTag", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<RemovePlayerTagResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<RemovePlayerTagResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<RemovePlayerTagResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Removes users from the set of those able to update the shared data and the set of users in the group. Only users in the
        /// group can remove members. If as a result of the call, zero users remain with access, the group and its associated data
        /// will be deleted. Shared Groups are designed for sharing data between a very small number of players, please see our
        /// guide: https://docs.microsoft.com/gaming/playfab/features/social/groups/using-shared-group-data
        /// </summary>
        public static async Task<PlayFabResult<RemoveSharedGroupMembersResult>> RemoveSharedGroupMembersAsync(RemoveSharedGroupMembersRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/RemoveSharedGroupMembers", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Submit a report about a player (due to bad bahavior, etc.) on behalf of another player, so that customer service
        /// representatives for the title can take action concerning potentially toxic players.
        /// </summary>
        public static async Task<PlayFabResult<ReportPlayerServerResult>> ReportPlayerAsync(ReportPlayerServerRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/ReportPlayer", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ReportPlayerServerResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ReportPlayerServerResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ReportPlayerServerResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Revoke all active bans for a user.
        /// </summary>
        public static async Task<PlayFabResult<RevokeAllBansForUserResult>> RevokeAllBansForUserAsync(RevokeAllBansForUserRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/RevokeAllBansForUser", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<RevokeAllBansForUserResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<RevokeAllBansForUserResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<RevokeAllBansForUserResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Revoke all active bans specified with BanId.
        /// </summary>
        public static async Task<PlayFabResult<RevokeBansResult>> RevokeBansAsync(RevokeBansRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/RevokeBans", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<RevokeBansResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<RevokeBansResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<RevokeBansResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Revokes access to an item in a user's inventory
        /// </summary>
        public static async Task<PlayFabResult<RevokeInventoryResult>> RevokeInventoryItemAsync(RevokeInventoryItemRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/RevokeInventoryItem", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<RevokeInventoryResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<RevokeInventoryResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<RevokeInventoryResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Revokes access for up to 25 items across multiple users and characters.
        /// </summary>
        public static async Task<PlayFabResult<RevokeInventoryItemsResult>> RevokeInventoryItemsAsync(RevokeInventoryItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/RevokeInventoryItems", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<RevokeInventoryItemsResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<RevokeInventoryItemsResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<RevokeInventoryItemsResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Saves push notification template for title
        /// </summary>
        public static async Task<PlayFabResult<SavePushNotificationTemplateResult>> SavePushNotificationTemplateAsync(SavePushNotificationTemplateRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/SavePushNotificationTemplate", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<SavePushNotificationTemplateResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<SavePushNotificationTemplateResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<SavePushNotificationTemplateResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Forces an email to be sent to the registered contact email address for the user's account based on an account recovery
        /// email template
        /// </summary>
        public static async Task<PlayFabResult<SendCustomAccountRecoveryEmailResult>> SendCustomAccountRecoveryEmailAsync(SendCustomAccountRecoveryEmailRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/SendCustomAccountRecoveryEmail", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<SendCustomAccountRecoveryEmailResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<SendCustomAccountRecoveryEmailResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<SendCustomAccountRecoveryEmailResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Sends an email based on an email template to a player's contact email
        /// </summary>
        public static async Task<PlayFabResult<SendEmailFromTemplateResult>> SendEmailFromTemplateAsync(SendEmailFromTemplateRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/SendEmailFromTemplate", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<SendEmailFromTemplateResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<SendEmailFromTemplateResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<SendEmailFromTemplateResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Sends an iOS/Android Push Notification to a specific user, if that user's device has been configured for Push
        /// Notifications in PlayFab. If a user has linked both Android and iOS devices, both will be notified.
        /// </summary>
        public static async Task<PlayFabResult<SendPushNotificationResult>> SendPushNotificationAsync(SendPushNotificationRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/SendPushNotification", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<SendPushNotificationResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<SendPushNotificationResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<SendPushNotificationResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Sends an iOS/Android Push Notification template to a specific user, if that user's device has been configured for Push
        /// Notifications in PlayFab. If a user has linked both Android and iOS devices, both will be notified.
        /// </summary>
        public static async Task<PlayFabResult<SendPushNotificationResult>> SendPushNotificationFromTemplateAsync(SendPushNotificationFromTemplateRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/SendPushNotificationFromTemplate", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<SendPushNotificationResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<SendPushNotificationResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<SendPushNotificationResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Updates the tag list for a specified user in the friend list of another user
        /// </summary>
        public static async Task<PlayFabResult<EmptyResponse>> SetFriendTagsAsync(SetFriendTagsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/SetFriendTags", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Sets the player's secret if it is not already set. Player secrets are used to sign API requests. To reset a player's
        /// secret use the Admin or Server API method SetPlayerSecret.
        /// </summary>
        public static async Task<PlayFabResult<SetPlayerSecretResult>> SetPlayerSecretAsync(SetPlayerSecretRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/SetPlayerSecret", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Updates the key-value store of custom publisher settings
        /// </summary>
        public static async Task<PlayFabResult<SetPublisherDataResult>> SetPublisherDataAsync(SetPublisherDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/SetPublisherData", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<SetPublisherDataResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<SetPublisherDataResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<SetPublisherDataResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Updates the key-value store of custom title settings
        /// </summary>
        public static async Task<PlayFabResult<SetTitleDataResult>> SetTitleDataAsync(SetTitleDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/SetTitleData", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<SetTitleDataResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<SetTitleDataResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<SetTitleDataResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Updates the key-value store of custom title settings
        /// </summary>
        public static async Task<PlayFabResult<SetTitleDataResult>> SetTitleInternalDataAsync(SetTitleDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/SetTitleInternalData", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<SetTitleDataResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<SetTitleDataResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<SetTitleDataResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Decrements the character's balance of the specified virtual currency by the stated amount. It is possible to
        /// make a VC balance negative with this API.
        /// </summary>
        public static async Task<PlayFabResult<ModifyCharacterVirtualCurrencyResult>> SubtractCharacterVirtualCurrencyAsync(SubtractCharacterVirtualCurrencyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/SubtractCharacterVirtualCurrency", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ModifyCharacterVirtualCurrencyResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ModifyCharacterVirtualCurrencyResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ModifyCharacterVirtualCurrencyResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Decrements the user's balance of the specified virtual currency by the stated amount. It is possible to make
        /// a VC balance negative with this API.
        /// </summary>
        public static async Task<PlayFabResult<ModifyUserVirtualCurrencyResult>> SubtractUserVirtualCurrencyAsync(SubtractUserVirtualCurrencyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/SubtractUserVirtualCurrency", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Unlinks the related Battle.net account from the user's PlayFab account.
        /// </summary>
        public static async Task<PlayFabResult<EmptyResponse>> UnlinkBattleNetAccountAsync(UnlinkBattleNetAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/UnlinkBattleNetAccount", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Unlinks the related Nintendo account from the user's PlayFab account
        /// </summary>
        public static async Task<PlayFabResult<EmptyResponse>> UnlinkNintendoServiceAccountAsync(UnlinkNintendoServiceAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/UnlinkNintendoServiceAccount", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Unlinks the related NintendoSwitchDeviceId from the user's PlayFab account
        /// </summary>
        public static async Task<PlayFabResult<UnlinkNintendoSwitchDeviceIdResult>> UnlinkNintendoSwitchDeviceIdAsync(UnlinkNintendoSwitchDeviceIdRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/UnlinkNintendoSwitchDeviceId", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Unlinks the related PlayStation :tm: Network account from the user's PlayFab account
        /// </summary>
        public static async Task<PlayFabResult<UnlinkPSNAccountResult>> UnlinkPSNAccountAsync(UnlinkPSNAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/UnlinkPSNAccount", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Unlinks the custom server identifier from the user's PlayFab account.
        /// </summary>
        public static async Task<PlayFabResult<UnlinkServerCustomIdResult>> UnlinkServerCustomIdAsync(UnlinkServerCustomIdRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/UnlinkServerCustomId", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<UnlinkServerCustomIdResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<UnlinkServerCustomIdResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<UnlinkServerCustomIdResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Unlinks the Steam account associated with the provided Steam ID to the user's PlayFab account
        /// </summary>
        public static async Task<PlayFabResult<UnlinkSteamIdResult>> UnlinkSteamIdAsync(UnlinkSteamIdRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/UnlinkSteamId", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<UnlinkSteamIdResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<UnlinkSteamIdResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<UnlinkSteamIdResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Unlinks the related Xbox Live account from the user's PlayFab account
        /// </summary>
        public static async Task<PlayFabResult<UnlinkXboxAccountResult>> UnlinkXboxAccountAsync(UnlinkXboxAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/UnlinkXboxAccount", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Opens a specific container (ContainerItemInstanceId), with a specific key (KeyItemInstanceId, when
        /// required), and returns the contents of the opened container. If the container (and key when relevant) are consumable
        /// (RemainingUses > 0), their RemainingUses will be decremented, consistent with the operation of ConsumeItem.
        /// </summary>
        public static async Task<PlayFabResult<UnlockContainerItemResult>> UnlockContainerInstanceAsync(UnlockContainerInstanceRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/UnlockContainerInstance", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Searches Player or Character inventory for any ItemInstance matching the given CatalogItemId, if necessary
        /// unlocks it using any appropriate key, and returns the contents of the opened container. If the container (and key when
        /// relevant) are consumable (RemainingUses > 0), their RemainingUses will be decremented, consistent with the operation of
        /// ConsumeItem.
        /// </summary>
        public static async Task<PlayFabResult<UnlockContainerItemResult>> UnlockContainerItemAsync(UnlockContainerItemRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/UnlockContainerItem", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Update the avatar URL of the specified player
        /// </summary>
        public static async Task<PlayFabResult<EmptyResponse>> UpdateAvatarUrlAsync(UpdateAvatarUrlRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/UpdateAvatarUrl", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Updates information of a list of existing bans specified with Ban Ids.
        /// </summary>
        public static async Task<PlayFabResult<UpdateBansResult>> UpdateBansAsync(UpdateBansRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/UpdateBans", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<UpdateBansResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<UpdateBansResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<UpdateBansResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Updates the title-specific custom data for the user's character which is readable and writable by the client
        /// </summary>
        public static async Task<PlayFabResult<UpdateCharacterDataResult>> UpdateCharacterDataAsync(UpdateCharacterDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/UpdateCharacterData", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Updates the title-specific custom data for the user's character which cannot be accessed by the client
        /// </summary>
        public static async Task<PlayFabResult<UpdateCharacterDataResult>> UpdateCharacterInternalDataAsync(UpdateCharacterDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/UpdateCharacterInternalData", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Updates the title-specific custom data for the user's character which can only be read by the client
        /// </summary>
        public static async Task<PlayFabResult<UpdateCharacterDataResult>> UpdateCharacterReadOnlyDataAsync(UpdateCharacterDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/UpdateCharacterReadOnlyData", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Updates the values of the specified title-specific statistics for the specific character
        /// </summary>
        public static async Task<PlayFabResult<UpdateCharacterStatisticsResult>> UpdateCharacterStatisticsAsync(UpdateCharacterStatisticsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/UpdateCharacterStatistics", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Updates the title-specific custom property values for a player
        /// </summary>
        public static async Task<PlayFabResult<UpdatePlayerCustomPropertiesResult>> UpdatePlayerCustomPropertiesAsync(UpdatePlayerCustomPropertiesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/UpdatePlayerCustomProperties", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<UpdatePlayerCustomPropertiesResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<UpdatePlayerCustomPropertiesResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<UpdatePlayerCustomPropertiesResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Updates the values of the specified title-specific statistics for the user
        /// </summary>
        public static async Task<PlayFabResult<UpdatePlayerStatisticsResult>> UpdatePlayerStatisticsAsync(UpdatePlayerStatisticsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/UpdatePlayerStatistics", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Regardless of the permission setting, only members of the group (and the server) can update the data. Shared Groups are
        /// designed for sharing data between a very small number of players, please see our guide:
        /// https://docs.microsoft.com/gaming/playfab/features/social/groups/using-shared-group-data
        /// </summary>
        public static async Task<PlayFabResult<UpdateSharedGroupDataResult>> UpdateSharedGroupDataAsync(UpdateSharedGroupDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/UpdateSharedGroupData", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Updates the title-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static async Task<PlayFabResult<UpdateUserDataResult>> UpdateUserDataAsync(UpdateUserDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/UpdateUserData", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Updates the title-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        public static async Task<PlayFabResult<UpdateUserDataResult>> UpdateUserInternalDataAsync(UpdateUserInternalDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/UpdateUserInternalData", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Updates the key-value pair data tagged to the specified item, which is read-only from the client.
        /// </summary>
        public static async Task<PlayFabResult<EmptyResponse>> UpdateUserInventoryItemCustomDataAsync(UpdateUserInventoryItemDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/UpdateUserInventoryItemCustomData", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Updates the publisher-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static async Task<PlayFabResult<UpdateUserDataResult>> UpdateUserPublisherDataAsync(UpdateUserDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/UpdateUserPublisherData", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Updates the publisher-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        public static async Task<PlayFabResult<UpdateUserDataResult>> UpdateUserPublisherInternalDataAsync(UpdateUserInternalDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/UpdateUserPublisherInternalData", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Updates the publisher-specific custom data for the user which can only be read by the client
        /// </summary>
        public static async Task<PlayFabResult<UpdateUserDataResult>> UpdateUserPublisherReadOnlyDataAsync(UpdateUserDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/UpdateUserPublisherReadOnlyData", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Updates the title-specific custom data for the user which can only be read by the client
        /// </summary>
        public static async Task<PlayFabResult<UpdateUserDataResult>> UpdateUserReadOnlyDataAsync(UpdateUserDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/UpdateUserReadOnlyData", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        /// Writes a character-based event into PlayStream.
        /// </summary>
        public static async Task<PlayFabResult<WriteEventResponse>> WriteCharacterEventAsync(WriteServerCharacterEventRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/WriteCharacterEvent", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        public static async Task<PlayFabResult<WriteEventResponse>> WritePlayerEventAsync(WriteServerPlayerEventRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/WritePlayerEvent", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
        public static async Task<PlayFabResult<WriteEventResponse>> WriteTitleEventAsync(WriteTitleEventRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");


            var httpResult = await PlayFabHttp.DoPost("/Server/WriteTitleEvent", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders);
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
}
}
#endif
