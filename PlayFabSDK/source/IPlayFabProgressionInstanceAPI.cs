using PlayFab.ProgressionModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayFab
{
    /// <summary>
    /// Interface for PlayFab Progression Instance API, providing methods for managing leaderboards and statistics.
    /// </summary>
    public interface IPlayFabProgressionInstanceAPI
    {
        /// <summary>
        /// Checks if the current entity is logged in.
        /// </summary>
        /// <returns>True if the entity is logged in; otherwise, false.</returns>
        bool IsEntityLoggedIn();

        /// <summary>
        /// Forgets all stored credentials for the current entity.
        /// </summary>
        void ForgetAllCredentials();

        /// <summary>
        /// Creates a new leaderboard definition.
        /// </summary>
        /// <param name="request">The request containing leaderboard definition details.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task representing the asynchronous operation, with the result containing an empty response.</returns>
        Task<PlayFabResult<EmptyResponse>> CreateLeaderboardDefinitionAsync(CreateLeaderboardDefinitionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Creates a new statistic definition.
        /// </summary>
        /// <param name="request">The request containing statistic definition details.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task representing the asynchronous operation, with the result containing an empty response.</returns>
        Task<PlayFabResult<EmptyResponse>> CreateStatisticDefinitionAsync(CreateStatisticDefinitionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes a leaderboard definition.
        /// </summary>
        /// <param name="request">The request containing leaderboard definition details to delete.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task representing the asynchronous operation, with the result containing an empty response.</returns>
        Task<PlayFabResult<EmptyResponse>> DeleteLeaderboardDefinitionAsync(DeleteLeaderboardDefinitionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes leaderboard entries.
        /// </summary>
        /// <param name="request">The request containing details of leaderboard entries to delete.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task representing the asynchronous operation, with the result containing an empty response.</returns>
        Task<PlayFabResult<EmptyResponse>> DeleteLeaderboardEntriesAsync(DeleteLeaderboardEntriesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes a statistic definition.
        /// </summary>
        /// <param name="request">The request containing statistic definition details to delete.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task representing the asynchronous operation, with the result containing an empty response.</returns>
        Task<PlayFabResult<EmptyResponse>> DeleteStatisticDefinitionAsync(DeleteStatisticDefinitionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes statistics for an entity.
        /// </summary>
        /// <param name="request">The request containing statistics to delete.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task representing the asynchronous operation, with the result containing the delete statistics response.</returns>
        Task<PlayFabResult<DeleteStatisticsResponse>> DeleteStatisticsAsync(DeleteStatisticsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the friend leaderboard for an entity.
        /// </summary>
        /// <param name="request">The request containing details for retrieving the friend leaderboard.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task representing the asynchronous operation, with the result containing the entity leaderboard response.</returns>
        Task<PlayFabResult<GetEntityLeaderboardResponse>> GetFriendLeaderboardForEntityAsync(GetFriendLeaderboardForEntityRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the leaderboard for an entity.
        /// </summary>
        /// <param name="request">The request containing details for retrieving the leaderboard.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task representing the asynchronous operation, with the result containing the entity leaderboard response.</returns>
        Task<PlayFabResult<GetEntityLeaderboardResponse>> GetLeaderboardAsync(GetEntityLeaderboardRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the leaderboard around a specific entity.
        /// </summary>
        /// <param name="request">The request containing details for retrieving the leaderboard around an entity.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task representing the asynchronous operation, with the result containing the entity leaderboard response.</returns>
        Task<PlayFabResult<GetEntityLeaderboardResponse>> GetLeaderboardAroundEntityAsync(GetLeaderboardAroundEntityRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the definition of a leaderboard.
        /// </summary>
        /// <param name="request">The request containing details for retrieving the leaderboard definition.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task representing the asynchronous operation, with the result containing the leaderboard definition response.</returns>
        Task<PlayFabResult<GetLeaderboardDefinitionResponse>> GetLeaderboardDefinitionAsync(GetLeaderboardDefinitionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the leaderboard for a collection of entities.
        /// </summary>
        /// <param name="request">The request containing details for retrieving the leaderboard for entities.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task representing the asynchronous operation, with the result containing the entity leaderboard response.</returns>
        Task<PlayFabResult<GetEntityLeaderboardResponse>> GetLeaderboardForEntitiesAsync(GetLeaderboardForEntitiesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the definition of a statistic.
        /// </summary>
        /// <param name="request">The request containing details for retrieving the statistic definition.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task representing the asynchronous operation, with the result containing the statistic definition response.</returns>
        Task<PlayFabResult<GetStatisticDefinitionResponse>> GetStatisticDefinitionAsync(GetStatisticDefinitionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets statistics for the current entity.
        /// </summary>
        /// <param name="request">The request containing details for retrieving statistics.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task representing the asynchronous operation, with the result containing the statistics response.</returns>
        Task<PlayFabResult<GetStatisticsResponse>> GetStatisticsAsync(GetStatisticsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets statistics for a collection of entities.
        /// </summary>
        /// <param name="request">The request containing details for retrieving statistics for entities.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task representing the asynchronous operation, with the result containing the statistics for entities response.</returns>
        Task<PlayFabResult<GetStatisticsForEntitiesResponse>> GetStatisticsForEntitiesAsync(GetStatisticsForEntitiesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Increments the version of a leaderboard.
        /// </summary>
        /// <param name="request">The request containing details for incrementing the leaderboard version.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task representing the asynchronous operation, with the result containing the increment leaderboard version response.</returns>
        Task<PlayFabResult<IncrementLeaderboardVersionResponse>> IncrementLeaderboardVersionAsync(IncrementLeaderboardVersionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Increments the version of a statistic.
        /// </summary>
        /// <param name="request">The request containing details for incrementing the statistic version.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task representing the asynchronous operation, with the result containing the increment statistic version response.</returns>
        Task<PlayFabResult<IncrementStatisticVersionResponse>> IncrementStatisticVersionAsync(IncrementStatisticVersionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists all leaderboard definitions for the title.
        /// </summary>
        /// <param name="request">The request containing details for listing leaderboard definitions.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task representing the asynchronous operation, with the result containing the list leaderboard definitions response.</returns>
        Task<PlayFabResult<ListLeaderboardDefinitionsResponse>> ListLeaderboardDefinitionsAsync(ListLeaderboardDefinitionsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists all statistic definitions for the title.
        /// </summary>
        /// <param name="request">The request containing details for listing statistic definitions.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task representing the asynchronous operation, with the result containing the list statistic definitions response.</returns>
        Task<PlayFabResult<ListStatisticDefinitionsResponse>> ListStatisticDefinitionsAsync(ListStatisticDefinitionsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unlinks a leaderboard from a statistic.
        /// </summary>
        /// <param name="request">The request containing details for unlinking the leaderboard from the statistic.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task representing the asynchronous operation, with the result containing an empty response.</returns>
        Task<PlayFabResult<EmptyResponse>> UnlinkLeaderboardFromStatisticAsync(UnlinkLeaderboardFromStatisticRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates a leaderboard definition.
        /// </summary>
        /// <param name="request">The request containing leaderboard definition update details.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task representing the asynchronous operation, with the result containing an empty response.</returns>
        Task<PlayFabResult<EmptyResponse>> UpdateLeaderboardDefinitionAsync(UpdateLeaderboardDefinitionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates leaderboard entries.
        /// </summary>
        /// <param name="request">The request containing leaderboard entries update details.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task representing the asynchronous operation, with the result containing an empty response.</returns>
        Task<PlayFabResult<EmptyResponse>> UpdateLeaderboardEntriesAsync(UpdateLeaderboardEntriesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates a statistic definition.
        /// </summary>
        /// <param name="request">The request containing statistic definition update details.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task representing the asynchronous operation, with the result containing an empty response.</returns>
        Task<PlayFabResult<EmptyResponse>> UpdateStatisticDefinitionAsync(UpdateStatisticDefinitionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates statistics for the current entity.
        /// </summary>
        /// <param name="request">The request containing statistics update details.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task representing the asynchronous operation, with the result containing the update statistics response.</returns>
        Task<PlayFabResult<UpdateStatisticsResponse>> UpdateStatisticsAsync(UpdateStatisticsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
    }
}
