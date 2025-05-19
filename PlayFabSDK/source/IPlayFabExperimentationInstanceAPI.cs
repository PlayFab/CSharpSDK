using PlayFab.ExperimentationModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayFab
{
    /// <summary>
    /// Interface for PlayFabExperimentationInstanceAPI.
    /// </summary>
    public interface IPlayFabExperimentationInstanceAPI
    {
        bool IsEntityLoggedIn();
        void ForgetAllCredentials();
        Task<PlayFabResult<CreateExclusionGroupResult>> CreateExclusionGroupAsync(CreateExclusionGroupRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<CreateExperimentResult>> CreateExperimentAsync(CreateExperimentRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<EmptyResponse>> DeleteExclusionGroupAsync(DeleteExclusionGroupRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<EmptyResponse>> DeleteExperimentAsync(DeleteExperimentRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<GetExclusionGroupsResult>> GetExclusionGroupsAsync(GetExclusionGroupsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<GetExclusionGroupTrafficResult>> GetExclusionGroupTrafficAsync(GetExclusionGroupTrafficRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<GetExperimentsResult>> GetExperimentsAsync(GetExperimentsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<GetLatestScorecardResult>> GetLatestScorecardAsync(GetLatestScorecardRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<GetTreatmentAssignmentResult>> GetTreatmentAssignmentAsync(GetTreatmentAssignmentRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<EmptyResponse>> StartExperimentAsync(StartExperimentRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<EmptyResponse>> StopExperimentAsync(StopExperimentRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<EmptyResponse>> UpdateExclusionGroupAsync(UpdateExclusionGroupRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<EmptyResponse>> UpdateExperimentAsync(UpdateExperimentRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
    }
}
