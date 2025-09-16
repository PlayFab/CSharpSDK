#if !DISABLE_PLAYFABENTITY_API

using PlayFab.ProgressionModels;
using PlayFab.Internal;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayFab
{
    /// <summary>
    /// Manage entity statistics Manage entity leaderboards
    /// </summary>
    public interface IPlayFabProgressionInstanceAPI
    {
        /// <summary>
        /// Creates a new leaderboard definition.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> CreateLeaderboardDefinitionAsync(
            CreateLeaderboardDefinitionRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Create a new entity statistic definition.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> CreateStatisticDefinitionAsync(
            CreateStatisticDefinitionRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes a leaderboard definition.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> DeleteLeaderboardDefinitionAsync(
            DeleteLeaderboardDefinitionRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes the specified entries from the given leaderboard.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> DeleteLeaderboardEntriesAsync(
            DeleteLeaderboardEntriesRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Delete an entity statistic definition. Will delete all statistics on entity profiles and leaderboards.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> DeleteStatisticDefinitionAsync(
            DeleteStatisticDefinitionRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Delete statistics on an entity profile. This will remove all rankings from associated leaderboards.
        /// </summary>
        Task<PlayFabResult<DeleteStatisticsResponse>> DeleteStatisticsAsync(
            DeleteStatisticsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Get the friend leaderboard for the specified entity. A maximum of 25 friend entries are listed in the leaderboard.
        /// </summary>
        Task<PlayFabResult<GetEntityLeaderboardResponse>> GetFriendLeaderboardForEntityAsync(
            GetFriendLeaderboardForEntityRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Get the leaderboard for a specific entity type and statistic.
        /// </summary>
        Task<PlayFabResult<GetEntityLeaderboardResponse>> GetLeaderboardAsync(
            GetEntityLeaderboardRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Get the leaderboard around a specific entity.
        /// </summary>
        Task<PlayFabResult<GetEntityLeaderboardResponse>> GetLeaderboardAroundEntityAsync(
            GetLeaderboardAroundEntityRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the specified leaderboard definition.
        /// </summary>
        Task<PlayFabResult<GetLeaderboardDefinitionResponse>> GetLeaderboardDefinitionAsync(
            GetLeaderboardDefinitionRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Get the leaderboard limited to a set of entities.
        /// </summary>
        Task<PlayFabResult<GetEntityLeaderboardResponse>> GetLeaderboardForEntitiesAsync(
            GetLeaderboardForEntitiesRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Get current statistic definition information
        /// </summary>
        Task<PlayFabResult<GetStatisticDefinitionResponse>> GetStatisticDefinitionAsync(
            GetStatisticDefinitionRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets statistics for the specified entity.
        /// </summary>
        Task<PlayFabResult<GetStatisticsResponse>> GetStatisticsAsync(
            GetStatisticsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets statistics for the specified collection of entities.
        /// </summary>
        Task<PlayFabResult<GetStatisticsForEntitiesResponse>> GetStatisticsForEntitiesAsync(
            GetStatisticsForEntitiesRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Increment a leaderboard version.
        /// </summary>
        Task<PlayFabResult<IncrementLeaderboardVersionResponse>> IncrementLeaderboardVersionAsync(
            IncrementLeaderboardVersionRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Increment an entity statistic definition version.
        /// </summary>
        Task<PlayFabResult<IncrementStatisticVersionResponse>> IncrementStatisticVersionAsync(
            IncrementStatisticVersionRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists the leaderboard definitions defined for the Title.
        /// </summary>
        Task<PlayFabResult<ListLeaderboardDefinitionsResponse>> ListLeaderboardDefinitionsAsync(
            ListLeaderboardDefinitionsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Get all current statistic definitions information
        /// </summary>
        Task<PlayFabResult<ListStatisticDefinitionsResponse>> ListStatisticDefinitionsAsync(
            ListStatisticDefinitionsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unlinks an aggregation source from a statistic definition.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> UnlinkAggregationSourceFromStatisticAsync(
            UnlinkAggregationSourceFromStatisticRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unlinks a leaderboard definition from it's linked statistic definition.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> UnlinkLeaderboardFromStatisticAsync(
            UnlinkLeaderboardFromStatisticRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates a leaderboard definition.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> UpdateLeaderboardDefinitionAsync(
            UpdateLeaderboardDefinitionRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Adds or updates entries on the specified leaderboard.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> UpdateLeaderboardEntriesAsync(
            UpdateLeaderboardEntriesRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Update an existing entity statistic definition.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> UpdateStatisticDefinitionAsync(
            UpdateStatisticDefinitionRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Update statistics on an entity profile. Depending on the statistic definition, this may result in entity being ranked on
        /// various leaderboards.
        /// </summary>
        Task<PlayFabResult<UpdateStatisticsResponse>> UpdateStatisticsAsync(
            UpdateStatisticsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);
    }
}
#endif
