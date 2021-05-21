#if !DISABLE_PLAYFABENTITY_API

using PlayFab.InsightsModels;
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
    /// Manage the Insights performance level and data storage retention settings.
    /// </summary>
    public class PlayFabInsightsInstanceAPI
    {
        public readonly PlayFabApiSettings apiSettings = null;
        public readonly PlayFabAuthenticationContext authenticationContext = null;

        public PlayFabInsightsInstanceAPI(PlayFabAuthenticationContext context)
        {
            if (context == null)
                throw new PlayFabException(PlayFabExceptionCode.AuthContextRequired, "Context cannot be null, create a PlayFabAuthenticationContext for each player in advance, or get <PlayFabClientInstanceAPI>.authenticationContext");
            authenticationContext = context;
        }

        public PlayFabInsightsInstanceAPI(PlayFabApiSettings settings, PlayFabAuthenticationContext context)
        {
            if (context == null)
                throw new PlayFabException(PlayFabExceptionCode.AuthContextRequired, "Context cannot be null, create a PlayFabAuthenticationContext for each player in advance, or get <PlayFabClientInstanceAPI>.authenticationContext");
            apiSettings = settings;
            authenticationContext = context;
        }

        /// <summary>
        /// Verify entity login.
        /// </summary>
        public bool IsEntityLoggedIn()
        {
            return authenticationContext == null ? false : authenticationContext.IsEntityLoggedIn();
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
        /// Gets the current values for the Insights performance and data storage retention, list of pending operations, and the
        /// performance and data storage retention limits.
        /// </summary>
        public async Task<PlayFabResult<InsightsGetDetailsResponse>> GetDetailsAsync(InsightsEmptyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Insights/GetDetails", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<InsightsGetDetailsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<InsightsGetDetailsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<InsightsGetDetailsResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves the range of allowed values for performance and data storage retention values as well as the submeter details
        /// for each performance level.
        /// </summary>
        public async Task<PlayFabResult<InsightsGetLimitsResponse>> GetLimitsAsync(InsightsEmptyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Insights/GetLimits", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<InsightsGetLimitsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<InsightsGetLimitsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<InsightsGetLimitsResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Gets the status of a SetPerformance or SetStorageRetention operation.
        /// </summary>
        public async Task<PlayFabResult<InsightsGetOperationStatusResponse>> GetOperationStatusAsync(InsightsGetOperationStatusRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Insights/GetOperationStatus", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<InsightsGetOperationStatusResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<InsightsGetOperationStatusResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<InsightsGetOperationStatusResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Gets a list of pending SetPerformance and/or SetStorageRetention operations for the title.
        /// </summary>
        public async Task<PlayFabResult<InsightsGetPendingOperationsResponse>> GetPendingOperationsAsync(InsightsGetPendingOperationsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Insights/GetPendingOperations", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<InsightsGetPendingOperationsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<InsightsGetPendingOperationsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<InsightsGetPendingOperationsResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Sets the Insights performance level value for the title.
        /// </summary>
        public async Task<PlayFabResult<InsightsOperationResponse>> SetPerformanceAsync(InsightsSetPerformanceRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Insights/SetPerformance", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<InsightsOperationResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<InsightsOperationResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<InsightsOperationResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Sets the Insights data storage retention days value for the title.
        /// </summary>
        public async Task<PlayFabResult<InsightsOperationResponse>> SetStorageRetentionAsync(InsightsSetStorageRetentionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Insights/SetStorageRetention", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<InsightsOperationResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<InsightsOperationResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<InsightsOperationResponse> { Result = result, CustomData = customData };
        }

}
}
#endif
