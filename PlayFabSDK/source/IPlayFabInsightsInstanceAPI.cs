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
        bool IsEntityLoggedIn();
        void ForgetAllCredentials();
        Task<PlayFabResult<InsightsGetDetailsResponse>> GetDetailsAsync(InsightsEmptyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<InsightsGetLimitsResponse>> GetLimitsAsync(InsightsEmptyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<InsightsGetOperationStatusResponse>> GetOperationStatusAsync(InsightsGetOperationStatusRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<InsightsGetPendingOperationsResponse>> GetPendingOperationsAsync(InsightsGetPendingOperationsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<InsightsOperationResponse>> SetPerformanceAsync(InsightsSetPerformanceRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<InsightsOperationResponse>> SetStorageRetentionAsync(InsightsSetStorageRetentionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
    }
}
