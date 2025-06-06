#if ENABLE_PLAYFABADMIN_API

using PlayFab.AdminModels;
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
    /// APIs for managing title configurations, uploaded Game Server code executables, and user data
    /// </summary>
    public class PlayFabAdminInstanceAPI
    {
        public readonly PlayFabApiSettings apiSettings = null;
        public readonly PlayFabAuthenticationContext authenticationContext = null;

        public PlayFabAdminInstanceAPI() { }

        public PlayFabAdminInstanceAPI(PlayFabApiSettings settings)
        {
            apiSettings = settings;
        }

        public PlayFabAdminInstanceAPI(PlayFabAuthenticationContext context)
        {
            authenticationContext = context;
        }

        public PlayFabAdminInstanceAPI(PlayFabApiSettings settings, PlayFabAuthenticationContext context)
        {
            apiSettings = settings;
            authenticationContext = context;
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
        /// Abort an ongoing task instance.
        /// </summary>
        public async Task<PlayFabResult<EmptyResponse>> AbortTaskInstanceAsync(AbortTaskInstanceRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/AbortTaskInstance", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
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
        /// Update news item to include localized version
        /// </summary>
        public async Task<PlayFabResult<AddLocalizedNewsResult>> AddLocalizedNewsAsync(AddLocalizedNewsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/AddLocalizedNews", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<AddLocalizedNewsResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<AddLocalizedNewsResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<AddLocalizedNewsResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Adds a new news item to the title's news feed
        /// </summary>
        public async Task<PlayFabResult<AddNewsResult>> AddNewsAsync(AddNewsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/AddNews", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<AddNewsResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<AddNewsResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<AddNewsResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Adds a given tag to a player profile. The tag's namespace is automatically generated based on the source of the tag.
        /// </summary>
        public async Task<PlayFabResult<AddPlayerTagResult>> AddPlayerTagAsync(AddPlayerTagRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/AddPlayerTag", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
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
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Increments the specified virtual currency by the stated amount
        /// </summary>
        public async Task<PlayFabResult<ModifyUserVirtualCurrencyResult>> AddUserVirtualCurrencyAsync(AddUserVirtualCurrencyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/AddUserVirtualCurrency", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
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
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Adds one or more virtual currencies to the set defined for the title. Virtual Currencies have a maximum
        /// value of 2,147,483,647 when granted to a player. Any value over that will be discarded.
        /// </summary>
        public async Task<PlayFabResult<BlankResult>> AddVirtualCurrencyTypesAsync(AddVirtualCurrencyTypesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/AddVirtualCurrencyTypes", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<BlankResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<BlankResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<BlankResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Bans users by PlayFab ID with optional IP address, or MAC address for the provided game.
        /// </summary>
        public async Task<PlayFabResult<BanUsersResult>> BanUsersAsync(BanUsersRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/BanUsers", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
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
        /// version 2._ Checks the global count for the limited edition item.
        /// </summary>
        public async Task<PlayFabResult<CheckLimitedEditionItemAvailabilityResult>> CheckLimitedEditionItemAvailabilityAsync(CheckLimitedEditionItemAvailabilityRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/CheckLimitedEditionItemAvailability", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<CheckLimitedEditionItemAvailabilityResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<CheckLimitedEditionItemAvailabilityResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<CheckLimitedEditionItemAvailabilityResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Create an ActionsOnPlayersInSegment task, which iterates through all players in a segment to execute action.
        /// </summary>
        public async Task<PlayFabResult<CreateTaskResult>> CreateActionsOnPlayersInSegmentTaskAsync(CreateActionsOnPlayerSegmentTaskRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/CreateActionsOnPlayersInSegmentTask", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<CreateTaskResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<CreateTaskResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<CreateTaskResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Create a CloudScript task, which can run a CloudScript on a schedule.
        /// </summary>
        public async Task<PlayFabResult<CreateTaskResult>> CreateCloudScriptTaskAsync(CreateCloudScriptTaskRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/CreateCloudScriptTask", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<CreateTaskResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<CreateTaskResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<CreateTaskResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Create a Insights Scheduled Scaling task, which can scale Insights Performance Units on a schedule
        /// </summary>
        public async Task<PlayFabResult<CreateTaskResult>> CreateInsightsScheduledScalingTaskAsync(CreateInsightsScheduledScalingTaskRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/CreateInsightsScheduledScalingTask", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<CreateTaskResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<CreateTaskResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<CreateTaskResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Registers a relationship between a title and an Open ID Connect provider.
        /// </summary>
        public async Task<PlayFabResult<EmptyResponse>> CreateOpenIdConnectionAsync(CreateOpenIdConnectionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/CreateOpenIdConnection", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
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
        /// Creates a new Player Shared Secret Key. It may take up to 5 minutes for this key to become generally available after
        /// this API returns.
        /// </summary>
        public async Task<PlayFabResult<CreatePlayerSharedSecretResult>> CreatePlayerSharedSecretAsync(CreatePlayerSharedSecretRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/CreatePlayerSharedSecret", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<CreatePlayerSharedSecretResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<CreatePlayerSharedSecretResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<CreatePlayerSharedSecretResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Adds a new player statistic configuration to the title, optionally allowing the developer to specify a reset interval
        /// and an aggregation method.
        /// </summary>
        public async Task<PlayFabResult<CreatePlayerStatisticDefinitionResult>> CreatePlayerStatisticDefinitionAsync(CreatePlayerStatisticDefinitionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/CreatePlayerStatisticDefinition", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<CreatePlayerStatisticDefinitionResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<CreatePlayerStatisticDefinitionResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<CreatePlayerStatisticDefinitionResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Creates a new player segment by defining the conditions on player properties. Also, create actions to target the player
        /// segments for a title.
        /// </summary>
        public async Task<PlayFabResult<CreateSegmentResponse>> CreateSegmentAsync(CreateSegmentRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/CreateSegment", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<CreateSegmentResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<CreateSegmentResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<CreateSegmentResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Delete a content file from the title. When deleting a file that does not exist, it returns success.
        /// </summary>
        public async Task<PlayFabResult<BlankResult>> DeleteContentAsync(DeleteContentRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/DeleteContent", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<BlankResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<BlankResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<BlankResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Removes a master player account entirely from all titles and deletes all associated data
        /// </summary>
        public async Task<PlayFabResult<DeleteMasterPlayerAccountResult>> DeleteMasterPlayerAccountAsync(DeleteMasterPlayerAccountRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/DeleteMasterPlayerAccount", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<DeleteMasterPlayerAccountResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<DeleteMasterPlayerAccountResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<DeleteMasterPlayerAccountResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Deletes PlayStream and telemetry event data associated with the master player account from PlayFab storage
        /// </summary>
        public async Task<PlayFabResult<DeleteMasterPlayerEventDataResult>> DeleteMasterPlayerEventDataAsync(DeleteMasterPlayerEventDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/DeleteMasterPlayerEventData", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<DeleteMasterPlayerEventDataResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<DeleteMasterPlayerEventDataResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<DeleteMasterPlayerEventDataResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Deletes a player's subscription
        /// </summary>
        public async Task<PlayFabResult<DeleteMembershipSubscriptionResult>> DeleteMembershipSubscriptionAsync(DeleteMembershipSubscriptionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/DeleteMembershipSubscription", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<DeleteMembershipSubscriptionResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<DeleteMembershipSubscriptionResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<DeleteMembershipSubscriptionResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Removes a relationship between a title and an OpenID Connect provider.
        /// </summary>
        public async Task<PlayFabResult<EmptyResponse>> DeleteOpenIdConnectionAsync(DeleteOpenIdConnectionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/DeleteOpenIdConnection", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
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
        /// Removes a user's player account from a title and deletes all associated data
        /// </summary>
        public async Task<PlayFabResult<DeletePlayerResult>> DeletePlayerAsync(DeletePlayerRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/DeletePlayer", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
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
        public async Task<PlayFabResult<DeletePlayerCustomPropertiesResult>> DeletePlayerCustomPropertiesAsync(DeletePlayerCustomPropertiesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/DeletePlayerCustomProperties", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
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
        /// Deletes an existing Player Shared Secret Key. It may take up to 5 minutes for this delete to be reflected after this API
        /// returns.
        /// </summary>
        public async Task<PlayFabResult<DeletePlayerSharedSecretResult>> DeletePlayerSharedSecretAsync(DeletePlayerSharedSecretRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/DeletePlayerSharedSecret", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<DeletePlayerSharedSecretResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<DeletePlayerSharedSecretResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<DeletePlayerSharedSecretResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Deletes an existing player segment and its associated action(s) for a title.
        /// </summary>
        public async Task<PlayFabResult<DeleteSegmentsResponse>> DeleteSegmentAsync(DeleteSegmentRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/DeleteSegment", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<DeleteSegmentsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<DeleteSegmentsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<DeleteSegmentsResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Deletes an existing virtual item store
        /// </summary>
        public async Task<PlayFabResult<DeleteStoreResult>> DeleteStoreAsync(DeleteStoreRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/DeleteStore", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<DeleteStoreResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<DeleteStoreResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<DeleteStoreResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Delete a task.
        /// </summary>
        public async Task<PlayFabResult<EmptyResponse>> DeleteTaskAsync(DeleteTaskRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/DeleteTask", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
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
        /// Permanently deletes a title and all associated configuration
        /// </summary>
        public async Task<PlayFabResult<DeleteTitleResult>> DeleteTitleAsync(DeleteTitleRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/DeleteTitle", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<DeleteTitleResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<DeleteTitleResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<DeleteTitleResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Deletes a specified set of title data overrides.
        /// </summary>
        public async Task<PlayFabResult<DeleteTitleDataOverrideResult>> DeleteTitleDataOverrideAsync(DeleteTitleDataOverrideRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/DeleteTitleDataOverride", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<DeleteTitleDataOverrideResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<DeleteTitleDataOverrideResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<DeleteTitleDataOverrideResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Exports all associated data of a master player account
        /// </summary>
        public async Task<PlayFabResult<ExportMasterPlayerDataResult>> ExportMasterPlayerDataAsync(ExportMasterPlayerDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/ExportMasterPlayerData", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ExportMasterPlayerDataResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ExportMasterPlayerDataResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ExportMasterPlayerDataResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Starts an export for the player profiles in a segment. This API creates a snapshot of all the player profiles which
        /// match the segment definition at the time of the API call. Profiles which change while an export is in progress will not
        /// be reflected in the results.
        /// </summary>
        public async Task<PlayFabResult<ExportPlayersInSegmentResult>> ExportPlayersInSegmentAsync(ExportPlayersInSegmentRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/ExportPlayersInSegment", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ExportPlayersInSegmentResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ExportPlayersInSegmentResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ExportPlayersInSegmentResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Get information about a ActionsOnPlayersInSegment task instance.
        /// </summary>
        public async Task<PlayFabResult<GetActionsOnPlayersInSegmentTaskInstanceResult>> GetActionsOnPlayersInSegmentTaskInstanceAsync(GetTaskInstanceRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/GetActionsOnPlayersInSegmentTaskInstance", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetActionsOnPlayersInSegmentTaskInstanceResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetActionsOnPlayersInSegmentTaskInstanceResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetActionsOnPlayersInSegmentTaskInstanceResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves an array of player segment definitions. Results from this can be used in subsequent API calls such as
        /// GetPlayersInSegment which requires a Segment ID. While segment names can change the ID for that segment will not change.
        /// </summary>
        public async Task<PlayFabResult<GetAllSegmentsResult>> GetAllSegmentsAsync(GetAllSegmentsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/GetAllSegments", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
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
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Retrieves the specified version of the title's catalog of virtual goods, including all defined properties
        /// </summary>
        public async Task<PlayFabResult<GetCatalogItemsResult>> GetCatalogItemsAsync(GetCatalogItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/GetCatalogItems", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
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
        /// Gets the contents and information of a specific Cloud Script revision.
        /// </summary>
        public async Task<PlayFabResult<GetCloudScriptRevisionResult>> GetCloudScriptRevisionAsync(GetCloudScriptRevisionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/GetCloudScriptRevision", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetCloudScriptRevisionResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetCloudScriptRevisionResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetCloudScriptRevisionResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Get detail information about a CloudScript task instance.
        /// </summary>
        public async Task<PlayFabResult<GetCloudScriptTaskInstanceResult>> GetCloudScriptTaskInstanceAsync(GetTaskInstanceRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/GetCloudScriptTaskInstance", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetCloudScriptTaskInstanceResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetCloudScriptTaskInstanceResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetCloudScriptTaskInstanceResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Lists all the current cloud script versions. For each version, information about the current published and latest
        /// revisions is also listed.
        /// </summary>
        public async Task<PlayFabResult<GetCloudScriptVersionsResult>> GetCloudScriptVersionsAsync(GetCloudScriptVersionsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/GetCloudScriptVersions", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetCloudScriptVersionsResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetCloudScriptVersionsResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetCloudScriptVersionsResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// List all contents of the title and get statistics such as size
        /// </summary>
        public async Task<PlayFabResult<GetContentListResult>> GetContentListAsync(GetContentListRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/GetContentList", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetContentListResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetContentListResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetContentListResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves the pre-signed URL for uploading a content file. A subsequent HTTP PUT to the returned URL uploads the
        /// content. Also, please be aware that the Content service is specifically PlayFab's CDN offering, for which standard CDN
        /// rates apply.
        /// </summary>
        public async Task<PlayFabResult<GetContentUploadUrlResult>> GetContentUploadUrlAsync(GetContentUploadUrlRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/GetContentUploadUrl", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetContentUploadUrlResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetContentUploadUrlResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetContentUploadUrlResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves a download URL for the requested report
        /// </summary>
        public async Task<PlayFabResult<GetDataReportResult>> GetDataReportAsync(GetDataReportRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/GetDataReport", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetDataReportResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetDataReportResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetDataReportResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Get the list of titles that the player has played
        /// </summary>
        public async Task<PlayFabResult<GetPlayedTitleListResult>> GetPlayedTitleListAsync(GetPlayedTitleListRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/GetPlayedTitleList", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetPlayedTitleListResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetPlayedTitleListResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetPlayedTitleListResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves a title-specific custom property value for a player.
        /// </summary>
        public async Task<PlayFabResult<GetPlayerCustomPropertyResult>> GetPlayerCustomPropertyAsync(GetPlayerCustomPropertyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/GetPlayerCustomProperty", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
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
        /// Gets a player's ID from an auth token.
        /// </summary>
        public async Task<PlayFabResult<GetPlayerIdFromAuthTokenResult>> GetPlayerIdFromAuthTokenAsync(GetPlayerIdFromAuthTokenRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/GetPlayerIdFromAuthToken", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetPlayerIdFromAuthTokenResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetPlayerIdFromAuthTokenResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetPlayerIdFromAuthTokenResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves the player's profile
        /// </summary>
        public async Task<PlayFabResult<GetPlayerProfileResult>> GetPlayerProfileAsync(GetPlayerProfileRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/GetPlayerProfile", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
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
        public async Task<PlayFabResult<GetPlayerSegmentsResult>> GetPlayerSegmentsAsync(GetPlayersSegmentsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/GetPlayerSegments", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
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
        /// Returns all Player Shared Secret Keys including disabled and expired.
        /// </summary>
        public async Task<PlayFabResult<GetPlayerSharedSecretsResult>> GetPlayerSharedSecretsAsync(GetPlayerSharedSecretsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/GetPlayerSharedSecrets", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetPlayerSharedSecretsResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetPlayerSharedSecretsResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetPlayerSharedSecretsResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Allows for paging through all players in a given segment. This API creates a snapshot of all player profiles that match
        /// the segment definition at the time of its creation and lives through the Total Seconds to Live, refreshing its life span
        /// on each subsequent use of the Continuation Token. Profiles that change during the course of paging will not be reflected
        /// in the results. AB Test segments are currently not supported by this operation. NOTE: This API is limited to being
        /// called 30 times in one minute. You will be returned an error if you exceed this threshold.
        /// </summary>
        public async Task<PlayFabResult<GetPlayersInSegmentResult>> GetPlayersInSegmentAsync(GetPlayersInSegmentRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/GetPlayersInSegment", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
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
        /// Retrieves the configuration information for all player statistics defined in the title, regardless of whether they have
        /// a reset interval.
        /// </summary>
        public async Task<PlayFabResult<GetPlayerStatisticDefinitionsResult>> GetPlayerStatisticDefinitionsAsync(GetPlayerStatisticDefinitionsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/GetPlayerStatisticDefinitions", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetPlayerStatisticDefinitionsResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetPlayerStatisticDefinitionsResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetPlayerStatisticDefinitionsResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves the information on the available versions of the specified statistic.
        /// </summary>
        public async Task<PlayFabResult<GetPlayerStatisticVersionsResult>> GetPlayerStatisticVersionsAsync(GetPlayerStatisticVersionsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/GetPlayerStatisticVersions", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
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
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/GetPlayerTags", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
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
        /// Gets the requested policy.
        /// </summary>
        public async Task<PlayFabResult<GetPolicyResponse>> GetPolicyAsync(GetPolicyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/GetPolicy", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetPolicyResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetPolicyResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetPolicyResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves the key-value store of custom publisher settings
        /// </summary>
        public async Task<PlayFabResult<GetPublisherDataResult>> GetPublisherDataAsync(GetPublisherDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/GetPublisherData", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
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
        /// version 2._ Retrieves the random drop table configuration for the title
        /// </summary>
        public async Task<PlayFabResult<GetRandomResultTablesResult>> GetRandomResultTablesAsync(GetRandomResultTablesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/GetRandomResultTables", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
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
        /// Retrieves the result of an export started by ExportPlayersInSegment API. If the ExportPlayersInSegment is successful and
        /// complete, this API returns the IndexUrl from which the index file can be downloaded. The index file has a list of urls
        /// from which the files containing the player profile data can be downloaded. Otherwise, it returns the current 'State' of
        /// the export
        /// </summary>
        public async Task<PlayFabResult<GetPlayersInSegmentExportResponse>> GetSegmentExportAsync(GetPlayersInSegmentExportRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/GetSegmentExport", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetPlayersInSegmentExportResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetPlayersInSegmentExportResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetPlayersInSegmentExportResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Get detail information of a segment and its associated definition(s) and action(s) for a title.
        /// </summary>
        public async Task<PlayFabResult<GetSegmentsResponse>> GetSegmentsAsync(GetSegmentsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/GetSegments", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetSegmentsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetSegmentsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetSegmentsResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Retrieves the set of items defined for the specified store, including all prices defined
        /// </summary>
        public async Task<PlayFabResult<GetStoreItemsResult>> GetStoreItemsAsync(GetStoreItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/GetStoreItems", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
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
        /// Query for task instances by task, status, or time range.
        /// </summary>
        public async Task<PlayFabResult<GetTaskInstancesResult>> GetTaskInstancesAsync(GetTaskInstancesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/GetTaskInstances", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetTaskInstancesResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetTaskInstancesResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetTaskInstancesResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Get definition information on a specified task or all tasks within a title.
        /// </summary>
        public async Task<PlayFabResult<GetTasksResult>> GetTasksAsync(GetTasksRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/GetTasks", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetTasksResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetTasksResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetTasksResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves the key-value store of custom title settings which can be read by the client
        /// </summary>
        public async Task<PlayFabResult<GetTitleDataResult>> GetTitleDataAsync(GetTitleDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/GetTitleData", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
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
        /// Retrieves the key-value store of custom title settings which cannot be read by the client
        /// </summary>
        public async Task<PlayFabResult<GetTitleDataResult>> GetTitleInternalDataAsync(GetTitleDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/GetTitleInternalData", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
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
        /// Retrieves the relevant details for a specified user, based upon a match against a supplied unique identifier
        /// </summary>
        public async Task<PlayFabResult<LookupUserAccountInfoResult>> GetUserAccountInfoAsync(LookupUserAccountInfoRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/GetUserAccountInfo", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<LookupUserAccountInfoResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<LookupUserAccountInfoResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<LookupUserAccountInfoResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Gets all bans for a user.
        /// </summary>
        public async Task<PlayFabResult<GetUserBansResult>> GetUserBansAsync(GetUserBansRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/GetUserBans", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
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
        public async Task<PlayFabResult<GetUserDataResult>> GetUserDataAsync(GetUserDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/GetUserData", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
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
        public async Task<PlayFabResult<GetUserDataResult>> GetUserInternalDataAsync(GetUserDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/GetUserInternalData", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
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
        public async Task<PlayFabResult<GetUserInventoryResult>> GetUserInventoryAsync(GetUserInventoryRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/GetUserInventory", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
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
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/GetUserPublisherData", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
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
        public async Task<PlayFabResult<GetUserDataResult>> GetUserPublisherInternalDataAsync(GetUserDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/GetUserPublisherInternalData", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
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
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/GetUserPublisherReadOnlyData", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
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
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/GetUserReadOnlyData", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
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
        /// version 2._ Adds the specified items to the specified user inventories
        /// </summary>
        public async Task<PlayFabResult<GrantItemsToUsersResult>> GrantItemsToUsersAsync(GrantItemsToUsersRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/GrantItemsToUsers", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
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
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Increases the global count for the given scarce resource.
        /// </summary>
        public async Task<PlayFabResult<IncrementLimitedEditionItemAvailabilityResult>> IncrementLimitedEditionItemAvailabilityAsync(IncrementLimitedEditionItemAvailabilityRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/IncrementLimitedEditionItemAvailability", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<IncrementLimitedEditionItemAvailabilityResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<IncrementLimitedEditionItemAvailabilityResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<IncrementLimitedEditionItemAvailabilityResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Resets the indicated statistic, removing all player entries for it and backing up the old values.
        /// </summary>
        public async Task<PlayFabResult<IncrementPlayerStatisticVersionResult>> IncrementPlayerStatisticVersionAsync(IncrementPlayerStatisticVersionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/IncrementPlayerStatisticVersion", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<IncrementPlayerStatisticVersionResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<IncrementPlayerStatisticVersionResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<IncrementPlayerStatisticVersionResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves a list of all Open ID Connect providers registered to a title.
        /// </summary>
        public async Task<PlayFabResult<ListOpenIdConnectionResponse>> ListOpenIdConnectionAsync(ListOpenIdConnectionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/ListOpenIdConnection", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ListOpenIdConnectionResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ListOpenIdConnectionResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ListOpenIdConnectionResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves title-specific custom property values for a player.
        /// </summary>
        public async Task<PlayFabResult<ListPlayerCustomPropertiesResult>> ListPlayerCustomPropertiesAsync(ListPlayerCustomPropertiesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/ListPlayerCustomProperties", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
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
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Retuns the list of all defined virtual currencies for the title
        /// </summary>
        public async Task<PlayFabResult<ListVirtualCurrencyTypesResult>> ListVirtualCurrencyTypesAsync(ListVirtualCurrencyTypesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/ListVirtualCurrencyTypes", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ListVirtualCurrencyTypesResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ListVirtualCurrencyTypesResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ListVirtualCurrencyTypesResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Attempts to process an order refund through the original real money payment provider.
        /// </summary>
        public async Task<PlayFabResult<RefundPurchaseResponse>> RefundPurchaseAsync(RefundPurchaseRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/RefundPurchase", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<RefundPurchaseResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<RefundPurchaseResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<RefundPurchaseResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Remove a given tag from a player profile. The tag's namespace is automatically generated based on the source of the tag.
        /// </summary>
        public async Task<PlayFabResult<RemovePlayerTagResult>> RemovePlayerTagAsync(RemovePlayerTagRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/RemovePlayerTag", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
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
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Removes one or more virtual currencies from the set defined for the title.
        /// </summary>
        public async Task<PlayFabResult<BlankResult>> RemoveVirtualCurrencyTypesAsync(RemoveVirtualCurrencyTypesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/RemoveVirtualCurrencyTypes", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<BlankResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<BlankResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<BlankResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Completely removes all statistics for the specified character, for the current game
        /// </summary>
        public async Task<PlayFabResult<ResetCharacterStatisticsResult>> ResetCharacterStatisticsAsync(ResetCharacterStatisticsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/ResetCharacterStatistics", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ResetCharacterStatisticsResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ResetCharacterStatisticsResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ResetCharacterStatisticsResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Reset a player's password for a given title.
        /// </summary>
        public async Task<PlayFabResult<ResetPasswordResult>> ResetPasswordAsync(ResetPasswordRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/ResetPassword", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ResetPasswordResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ResetPasswordResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ResetPasswordResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Completely removes all statistics for the specified user, for the current game
        /// </summary>
        public async Task<PlayFabResult<ResetUserStatisticsResult>> ResetUserStatisticsAsync(ResetUserStatisticsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/ResetUserStatistics", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ResetUserStatisticsResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ResetUserStatisticsResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ResetUserStatisticsResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Attempts to resolve a dispute with the original order's payment provider.
        /// </summary>
        public async Task<PlayFabResult<ResolvePurchaseDisputeResponse>> ResolvePurchaseDisputeAsync(ResolvePurchaseDisputeRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/ResolvePurchaseDispute", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ResolvePurchaseDisputeResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ResolvePurchaseDisputeResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ResolvePurchaseDisputeResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Revoke all active bans for a user.
        /// </summary>
        public async Task<PlayFabResult<RevokeAllBansForUserResult>> RevokeAllBansForUserAsync(RevokeAllBansForUserRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/RevokeAllBansForUser", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
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
        public async Task<PlayFabResult<RevokeBansResult>> RevokeBansAsync(RevokeBansRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/RevokeBans", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
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
        public async Task<PlayFabResult<RevokeInventoryResult>> RevokeInventoryItemAsync(RevokeInventoryItemRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/RevokeInventoryItem", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
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
        public async Task<PlayFabResult<RevokeInventoryItemsResult>> RevokeInventoryItemsAsync(RevokeInventoryItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/RevokeInventoryItems", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
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
        /// Run a task immediately regardless of its schedule.
        /// </summary>
        public async Task<PlayFabResult<RunTaskResult>> RunTaskAsync(RunTaskRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/RunTask", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<RunTaskResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<RunTaskResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<RunTaskResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Forces an email to be sent to the registered email address for the user's account, with a link allowing the user to
        /// change the password.If an account recovery email template ID is provided, an email using the custom email template will
        /// be used.
        /// </summary>
        public async Task<PlayFabResult<SendAccountRecoveryEmailResult>> SendAccountRecoveryEmailAsync(SendAccountRecoveryEmailRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/SendAccountRecoveryEmail", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
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
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Creates the catalog configuration of all virtual goods for the specified catalog version
        /// </summary>
        public async Task<PlayFabResult<UpdateCatalogItemsResult>> SetCatalogItemsAsync(UpdateCatalogItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/SetCatalogItems", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<UpdateCatalogItemsResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<UpdateCatalogItemsResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<UpdateCatalogItemsResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Sets the override expiration for a membership subscription
        /// </summary>
        public async Task<PlayFabResult<SetMembershipOverrideResult>> SetMembershipOverrideAsync(SetMembershipOverrideRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/SetMembershipOverride", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<SetMembershipOverrideResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<SetMembershipOverrideResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<SetMembershipOverrideResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Sets or resets the player's secret. Player secrets are used to sign API requests.
        /// </summary>
        public async Task<PlayFabResult<SetPlayerSecretResult>> SetPlayerSecretAsync(SetPlayerSecretRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/SetPlayerSecret", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
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
        /// Sets the currently published revision of a title Cloud Script
        /// </summary>
        public async Task<PlayFabResult<SetPublishedRevisionResult>> SetPublishedRevisionAsync(SetPublishedRevisionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/SetPublishedRevision", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<SetPublishedRevisionResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<SetPublishedRevisionResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<SetPublishedRevisionResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Updates the key-value store of custom publisher settings
        /// </summary>
        public async Task<PlayFabResult<SetPublisherDataResult>> SetPublisherDataAsync(SetPublisherDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/SetPublisherData", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
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
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Sets all the items in one virtual store
        /// </summary>
        public async Task<PlayFabResult<UpdateStoreItemsResult>> SetStoreItemsAsync(UpdateStoreItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/SetStoreItems", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<UpdateStoreItemsResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<UpdateStoreItemsResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<UpdateStoreItemsResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Creates and updates the key-value store of custom title settings which can be read by the client. For example, a
        /// developer could choose to store values which modify the user experience, such as enemy spawn rates, weapon strengths,
        /// movement speeds, etc. This allows a developer to update the title without the need to create, test, and ship a new
        /// build.
        /// </summary>
        public async Task<PlayFabResult<SetTitleDataResult>> SetTitleDataAsync(SetTitleDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/SetTitleData", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
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
        /// Set and delete key-value pairs in a title data override instance.
        /// </summary>
        public async Task<PlayFabResult<SetTitleDataAndOverridesResult>> SetTitleDataAndOverridesAsync(SetTitleDataAndOverridesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/SetTitleDataAndOverrides", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<SetTitleDataAndOverridesResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<SetTitleDataAndOverridesResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<SetTitleDataAndOverridesResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Updates the key-value store of custom title settings which cannot be read by the client. These values can be used to
        /// tweak settings used by game servers and Cloud Scripts without the need to update and re-deploy.
        /// </summary>
        public async Task<PlayFabResult<SetTitleDataResult>> SetTitleInternalDataAsync(SetTitleDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/SetTitleInternalData", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
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
        /// Sets the Amazon Resource Name (ARN) for iOS and Android push notifications. Documentation on the exact restrictions can
        /// be found at: http://docs.aws.amazon.com/sns/latest/api/API_CreatePlatformApplication.html. Currently, Amazon device
        /// Messaging is not supported.
        /// </summary>
        public async Task<PlayFabResult<SetupPushNotificationResult>> SetupPushNotificationAsync(SetupPushNotificationRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/SetupPushNotification", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<SetupPushNotificationResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<SetupPushNotificationResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<SetupPushNotificationResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Decrements the specified virtual currency by the stated amount
        /// </summary>
        public async Task<PlayFabResult<ModifyUserVirtualCurrencyResult>> SubtractUserVirtualCurrencyAsync(SubtractUserVirtualCurrencyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/SubtractUserVirtualCurrency", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
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
        /// Updates information of a list of existing bans specified with Ban Ids.
        /// </summary>
        public async Task<PlayFabResult<UpdateBansResult>> UpdateBansAsync(UpdateBansRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/UpdateBans", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
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
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Updates the catalog configuration for virtual goods in the specified catalog version
        /// </summary>
        public async Task<PlayFabResult<UpdateCatalogItemsResult>> UpdateCatalogItemsAsync(UpdateCatalogItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/UpdateCatalogItems", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<UpdateCatalogItemsResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<UpdateCatalogItemsResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<UpdateCatalogItemsResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Creates a new Cloud Script revision and uploads source code to it. Note that at this time, only one file should be
        /// submitted in the revision.
        /// </summary>
        public async Task<PlayFabResult<UpdateCloudScriptResult>> UpdateCloudScriptAsync(UpdateCloudScriptRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/UpdateCloudScript", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<UpdateCloudScriptResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<UpdateCloudScriptResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<UpdateCloudScriptResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Modifies data and credentials for an existing relationship between a title and an Open ID Connect provider
        /// </summary>
        public async Task<PlayFabResult<EmptyResponse>> UpdateOpenIdConnectionAsync(UpdateOpenIdConnectionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/UpdateOpenIdConnection", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
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
        /// Updates the title-specific custom property values for a player
        /// </summary>
        public async Task<PlayFabResult<UpdatePlayerCustomPropertiesResult>> UpdatePlayerCustomPropertiesAsync(UpdatePlayerCustomPropertiesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/UpdatePlayerCustomProperties", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
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
        /// Updates a existing Player Shared Secret Key. It may take up to 5 minutes for this update to become generally available
        /// after this API returns.
        /// </summary>
        public async Task<PlayFabResult<UpdatePlayerSharedSecretResult>> UpdatePlayerSharedSecretAsync(UpdatePlayerSharedSecretRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/UpdatePlayerSharedSecret", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<UpdatePlayerSharedSecretResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<UpdatePlayerSharedSecretResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<UpdatePlayerSharedSecretResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Updates a player statistic configuration for the title, optionally allowing the developer to specify a reset interval.
        /// </summary>
        public async Task<PlayFabResult<UpdatePlayerStatisticDefinitionResult>> UpdatePlayerStatisticDefinitionAsync(UpdatePlayerStatisticDefinitionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/UpdatePlayerStatisticDefinition", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<UpdatePlayerStatisticDefinitionResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<UpdatePlayerStatisticDefinitionResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<UpdatePlayerStatisticDefinitionResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Changes a policy for a title
        /// </summary>
        public async Task<PlayFabResult<UpdatePolicyResponse>> UpdatePolicyAsync(UpdatePolicyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/UpdatePolicy", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<UpdatePolicyResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<UpdatePolicyResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<UpdatePolicyResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Updates the random drop table configuration for the title
        /// </summary>
        public async Task<PlayFabResult<UpdateRandomResultTablesResult>> UpdateRandomResultTablesAsync(UpdateRandomResultTablesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/UpdateRandomResultTables", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<UpdateRandomResultTablesResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<UpdateRandomResultTablesResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<UpdateRandomResultTablesResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Updates an existing player segment and its associated definition(s) and action(s) for a title.
        /// </summary>
        public async Task<PlayFabResult<UpdateSegmentResponse>> UpdateSegmentAsync(UpdateSegmentRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/UpdateSegment", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<UpdateSegmentResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<UpdateSegmentResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<UpdateSegmentResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// _NOTE: This is a Legacy Economy API, and is in bugfix-only mode. All new Economy features are being developed only for
        /// version 2._ Updates an existing virtual item store with new or modified items
        /// </summary>
        public async Task<PlayFabResult<UpdateStoreItemsResult>> UpdateStoreItemsAsync(UpdateStoreItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/UpdateStoreItems", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<UpdateStoreItemsResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<UpdateStoreItemsResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<UpdateStoreItemsResult> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Update an existing task.
        /// </summary>
        public async Task<PlayFabResult<EmptyResponse>> UpdateTaskAsync(UpdateTaskRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/UpdateTask", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
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
        /// Updates the title-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public async Task<PlayFabResult<UpdateUserDataResult>> UpdateUserDataAsync(UpdateUserDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/UpdateUserData", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
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
        public async Task<PlayFabResult<UpdateUserDataResult>> UpdateUserInternalDataAsync(UpdateUserInternalDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/UpdateUserInternalData", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
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
        /// Updates the publisher-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public async Task<PlayFabResult<UpdateUserDataResult>> UpdateUserPublisherDataAsync(UpdateUserDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/UpdateUserPublisherData", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
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
        public async Task<PlayFabResult<UpdateUserDataResult>> UpdateUserPublisherInternalDataAsync(UpdateUserInternalDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/UpdateUserPublisherInternalData", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
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
        public async Task<PlayFabResult<UpdateUserDataResult>> UpdateUserPublisherReadOnlyDataAsync(UpdateUserDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/UpdateUserPublisherReadOnlyData", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
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
        public async Task<PlayFabResult<UpdateUserDataResult>> UpdateUserReadOnlyDataAsync(UpdateUserDataRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/UpdateUserReadOnlyData", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
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
        /// Updates the title specific display name for a user
        /// </summary>
        public async Task<PlayFabResult<UpdateUserTitleDisplayNameResult>> UpdateUserTitleDisplayNameAsync(UpdateUserTitleDisplayNameRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey must be set in your local or global settings to call this method");

            var httpResult = await PlayFabHttp.DoPost("/Admin/UpdateUserTitleDisplayName", request, "X-SecretKey", requestSettings.DeveloperSecretKey, extraHeaders, requestSettings);
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

}
}
#endif
