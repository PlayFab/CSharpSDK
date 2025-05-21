using PlayFab.InsightsModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayFab
{
    /// <summary>
    /// Interface for PlayFabInsightsInstanceAPI.
    /// </summary>
    public interface IPlayFabInsightsInstanceAPI
    {
        /// <summary>
        /// Checks if the entity is currently logged in.
        /// </summary>
        /// <returns>True if the entity is logged in; otherwise, false.</returns>
        bool IsEntityLoggedIn();

        /// <summary>
        /// Forgets all stored credentials for the current entity.
        /// </summary>
        void ForgetAllCredentials();

        /// <summary>
        /// Retrieves the current Insights details for the title.
        /// </summary>
        /// <param name="request">The request parameters for getting Insights details.</param>
        /// <param name="customData">Optional custom data to associate with the request.</param>
        /// <param name="extraHeaders">Optional extra headers to include in the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the Insights details response.</returns>
        Task<PlayFabResult<InsightsGetDetailsResponse>> GetDetailsAsync(InsightsEmptyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves the limits for Insights performance and storage retention.
        /// </summary>
        /// <param name="request">The request parameters for getting Insights limits.</param>
        /// <param name="customData">Optional custom data to associate with the request.</param>
        /// <param name="extraHeaders">Optional extra headers to include in the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the Insights limits response.</returns>
        Task<PlayFabResult<InsightsGetLimitsResponse>> GetLimitsAsync(InsightsEmptyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the current status for the requested Insights operation.
        /// </summary>
        /// <param name="request">The request parameters for getting operation status.</param>
        /// <param name="customData">Optional custom data to associate with the request.</param>
        /// <param name="extraHeaders">Optional extra headers to include in the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the operation status response.</returns>
        Task<PlayFabResult<InsightsGetOperationStatusResponse>> GetOperationStatusAsync(InsightsGetOperationStatusRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets a list of pending Insights operations for the title.
        /// </summary>
        /// <param name="request">The request parameters for getting pending operations.</param>
        /// <param name="customData">Optional custom data to associate with the request.</param>
        /// <param name="extraHeaders">Optional extra headers to include in the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the pending operations response.</returns>
        Task<PlayFabResult<InsightsGetPendingOperationsResponse>> GetPendingOperationsAsync(InsightsGetPendingOperationsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Sets the Insights performance level to the requested value.
        /// </summary>
        /// <param name="request">The request parameters for setting performance level.</param>
        /// <param name="customData">Optional custom data to associate with the request.</param>
        /// <param name="extraHeaders">Optional extra headers to include in the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the operation response.</returns>
        Task<PlayFabResult<InsightsOperationResponse>> SetPerformanceAsync(InsightsSetPerformanceRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Sets the Insights data storage retention to the requested value.
        /// </summary>
        /// <param name="request">The request parameters for setting storage retention.</param>
        /// <param name="customData">Optional custom data to associate with the request.</param>
        /// <param name="extraHeaders">Optional extra headers to include in the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the operation response.</returns>
        Task<PlayFabResult<InsightsOperationResponse>> SetStorageRetentionAsync(InsightsSetStorageRetentionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
    }
}
