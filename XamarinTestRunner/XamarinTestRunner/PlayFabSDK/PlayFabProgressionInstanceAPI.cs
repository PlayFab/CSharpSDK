#if !DISABLE_PLAYFABENTITY_API

using PlayFab.ProgressionModels;
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
    /// Manage entity statistics Manage entity leaderboards
    /// </summary>
    public class PlayFabProgressionInstanceAPI : IPlayFabProgressionInstanceAPI
    {
        public readonly PlayFabApiSettings apiSettings = null;
        public readonly PlayFabAuthenticationContext authenticationContext = null;

        public PlayFabProgressionInstanceAPI(PlayFabAuthenticationContext context)
        {
            if (context == null)
                throw new PlayFabException(PlayFabExceptionCode.AuthContextRequired, "Context cannot be null, create a PlayFabAuthenticationContext for each player in advance, or get <PlayFabClientInstanceAPI>.authenticationContext");
            authenticationContext = context;
        }

        public PlayFabProgressionInstanceAPI(PlayFabApiSettings settings, PlayFabAuthenticationContext context)
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
        /// Creates a new leaderboard definition.
        /// </summary>
        public async Task<PlayFabResult<EmptyResponse>> CreateLeaderboardDefinitionAsync(CreateLeaderboardDefinitionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Leaderboard/CreateLeaderboardDefinition", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
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
        /// Create a new entity statistic definition.
        /// </summary>
        public async Task<PlayFabResult<EmptyResponse>> CreateStatisticDefinitionAsync(CreateStatisticDefinitionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Statistic/CreateStatisticDefinition", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
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
        /// Deletes a leaderboard definition.
        /// </summary>
        public async Task<PlayFabResult<EmptyResponse>> DeleteLeaderboardDefinitionAsync(DeleteLeaderboardDefinitionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Leaderboard/DeleteLeaderboardDefinition", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
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
        /// Deletes the specified entries from the given leaderboard.
        /// </summary>
        public async Task<PlayFabResult<EmptyResponse>> DeleteLeaderboardEntriesAsync(DeleteLeaderboardEntriesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Leaderboard/DeleteLeaderboardEntries", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
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
        /// Delete an entity statistic definition. Will delete all statistics on entity profiles and leaderboards.
        /// </summary>
        public async Task<PlayFabResult<EmptyResponse>> DeleteStatisticDefinitionAsync(DeleteStatisticDefinitionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Statistic/DeleteStatisticDefinition", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
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
        /// Delete statistics on an entity profile. This will remove all rankings from associated leaderboards.
        /// </summary>
        public async Task<PlayFabResult<DeleteStatisticsResponse>> DeleteStatisticsAsync(DeleteStatisticsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Statistic/DeleteStatistics", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<DeleteStatisticsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<DeleteStatisticsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<DeleteStatisticsResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Get the friend leaderboard for the specified entity. A maximum of 25 friend entries are listed in the leaderboard.
        /// </summary>
        public async Task<PlayFabResult<GetEntityLeaderboardResponse>> GetFriendLeaderboardForEntityAsync(GetFriendLeaderboardForEntityRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Leaderboard/GetFriendLeaderboardForEntity", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetEntityLeaderboardResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetEntityLeaderboardResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetEntityLeaderboardResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Get the leaderboard for a specific entity type and statistic.
        /// </summary>
        public async Task<PlayFabResult<GetEntityLeaderboardResponse>> GetLeaderboardAsync(GetEntityLeaderboardRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Leaderboard/GetLeaderboard", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetEntityLeaderboardResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetEntityLeaderboardResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetEntityLeaderboardResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Get the leaderboard around a specific entity.
        /// </summary>
        public async Task<PlayFabResult<GetEntityLeaderboardResponse>> GetLeaderboardAroundEntityAsync(GetLeaderboardAroundEntityRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Leaderboard/GetLeaderboardAroundEntity", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetEntityLeaderboardResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetEntityLeaderboardResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetEntityLeaderboardResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Gets the specified leaderboard definition.
        /// </summary>
        public async Task<PlayFabResult<GetLeaderboardDefinitionResponse>> GetLeaderboardDefinitionAsync(GetLeaderboardDefinitionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Leaderboard/GetLeaderboardDefinition", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetLeaderboardDefinitionResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetLeaderboardDefinitionResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetLeaderboardDefinitionResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Get the leaderboard limited to a set of entities.
        /// </summary>
        public async Task<PlayFabResult<GetEntityLeaderboardResponse>> GetLeaderboardForEntitiesAsync(GetLeaderboardForEntitiesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Leaderboard/GetLeaderboardForEntities", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetEntityLeaderboardResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetEntityLeaderboardResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetEntityLeaderboardResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Get current statistic definition information
        /// </summary>
        public async Task<PlayFabResult<GetStatisticDefinitionResponse>> GetStatisticDefinitionAsync(GetStatisticDefinitionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Statistic/GetStatisticDefinition", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetStatisticDefinitionResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetStatisticDefinitionResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetStatisticDefinitionResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Gets statistics for the specified entity.
        /// </summary>
        public async Task<PlayFabResult<GetStatisticsResponse>> GetStatisticsAsync(GetStatisticsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Statistic/GetStatistics", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetStatisticsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetStatisticsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetStatisticsResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Gets statistics for the specified collection of entities.
        /// </summary>
        public async Task<PlayFabResult<GetStatisticsForEntitiesResponse>> GetStatisticsForEntitiesAsync(GetStatisticsForEntitiesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Statistic/GetStatisticsForEntities", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetStatisticsForEntitiesResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetStatisticsForEntitiesResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetStatisticsForEntitiesResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Increment a leaderboard version.
        /// </summary>
        public async Task<PlayFabResult<IncrementLeaderboardVersionResponse>> IncrementLeaderboardVersionAsync(IncrementLeaderboardVersionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Leaderboard/IncrementLeaderboardVersion", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<IncrementLeaderboardVersionResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<IncrementLeaderboardVersionResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<IncrementLeaderboardVersionResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Increment an entity statistic definition version.
        /// </summary>
        public async Task<PlayFabResult<IncrementStatisticVersionResponse>> IncrementStatisticVersionAsync(IncrementStatisticVersionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Statistic/IncrementStatisticVersion", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<IncrementStatisticVersionResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<IncrementStatisticVersionResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<IncrementStatisticVersionResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Lists the leaderboard definitions defined for the Title.
        /// </summary>
        public async Task<PlayFabResult<ListLeaderboardDefinitionsResponse>> ListLeaderboardDefinitionsAsync(ListLeaderboardDefinitionsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Leaderboard/ListLeaderboardDefinitions", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ListLeaderboardDefinitionsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ListLeaderboardDefinitionsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ListLeaderboardDefinitionsResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Get all current statistic definitions information
        /// </summary>
        public async Task<PlayFabResult<ListStatisticDefinitionsResponse>> ListStatisticDefinitionsAsync(ListStatisticDefinitionsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Statistic/ListStatisticDefinitions", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ListStatisticDefinitionsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ListStatisticDefinitionsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ListStatisticDefinitionsResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Unlinks an aggregation source from a statistic definition.
        /// </summary>
        public async Task<PlayFabResult<EmptyResponse>> UnlinkAggregationSourceFromStatisticAsync(UnlinkAggregationSourceFromStatisticRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Statistic/UnlinkAggregationSourceFromStatistic", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
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
        /// Unlinks a leaderboard definition from it's linked statistic definition.
        /// </summary>
        public async Task<PlayFabResult<EmptyResponse>> UnlinkLeaderboardFromStatisticAsync(UnlinkLeaderboardFromStatisticRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Leaderboard/UnlinkLeaderboardFromStatistic", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
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
        /// Updates a leaderboard definition.
        /// </summary>
        public async Task<PlayFabResult<EmptyResponse>> UpdateLeaderboardDefinitionAsync(UpdateLeaderboardDefinitionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Leaderboard/UpdateLeaderboardDefinition", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
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
        /// Adds or updates entries on the specified leaderboard.
        /// </summary>
        public async Task<PlayFabResult<EmptyResponse>> UpdateLeaderboardEntriesAsync(UpdateLeaderboardEntriesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Leaderboard/UpdateLeaderboardEntries", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
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
        /// Update an existing entity statistic definition.
        /// </summary>
        public async Task<PlayFabResult<EmptyResponse>> UpdateStatisticDefinitionAsync(UpdateStatisticDefinitionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Statistic/UpdateStatisticDefinition", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
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
        /// Update statistics on an entity profile. Depending on the statistic definition, this may result in entity being ranked on
        /// various leaderboards.
        /// </summary>
        public async Task<PlayFabResult<UpdateStatisticsResponse>> UpdateStatisticsAsync(UpdateStatisticsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? authenticationContext;
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Statistic/UpdateStatistics", request, "X-EntityToken", requestContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<UpdateStatisticsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<UpdateStatisticsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<UpdateStatisticsResponse> { Result = result, CustomData = customData };
        }

}
}
#endif
