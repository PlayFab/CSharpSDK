#if !DISABLE_PLAYFABENTITY_API

using PlayFab.InsightsModels;
using PlayFab.Internal;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayFab
{
    /// <summary>
    /// Manage the Insights performance level and data storage retention settings.
    /// </summary>
    public interface IPlayFabInsightsInstanceAPI
    {
        /// <summary>
        /// Gets the current values for the Insights performance and data storage retention, list of pending operations, and the
        /// performance and data storage retention limits.
        /// </summary>
        Task<PlayFabResult<InsightsGetDetailsResponse>> GetDetailsAsync(
            InsightsEmptyRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves the range of allowed values for performance and data storage retention values as well as the submeter details
        /// for each performance level.
        /// </summary>
        Task<PlayFabResult<InsightsGetLimitsResponse>> GetLimitsAsync(
            InsightsEmptyRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the status of a SetPerformance or SetStorageRetention operation.
        /// </summary>
        Task<PlayFabResult<InsightsGetOperationStatusResponse>> GetOperationStatusAsync(
            InsightsGetOperationStatusRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets a list of pending SetPerformance and/or SetStorageRetention operations for the title.
        /// </summary>
        Task<PlayFabResult<InsightsGetPendingOperationsResponse>> GetPendingOperationsAsync(
            InsightsGetPendingOperationsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Sets the Insights performance level value for the title.
        /// </summary>
        Task<PlayFabResult<InsightsOperationResponse>> SetPerformanceAsync(
            InsightsSetPerformanceRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Sets the Insights data storage retention days value for the title.
        /// </summary>
        Task<PlayFabResult<InsightsOperationResponse>> SetStorageRetentionAsync(
            InsightsSetStorageRetentionRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);
    }
}
#endif
