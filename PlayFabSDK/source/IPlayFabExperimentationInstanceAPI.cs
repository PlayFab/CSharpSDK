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
        /// <summary>
        /// Checks if an entity is currently logged in.
        /// </summary>
        /// <returns>True if an entity is logged in; otherwise, false.</returns>
        bool IsEntityLoggedIn();

        /// <summary>
        /// Forgets all stored credentials for the current entity.
        /// </summary>
        void ForgetAllCredentials();

        /// <summary>
        /// Creates a new exclusion group for the title.
        /// </summary>
        /// <param name="request">The request parameters for creating the exclusion group.</param>
        /// <param name="customData">Optional custom data associated with the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the result of the create exclusion group operation.</returns>
        Task<PlayFabResult<CreateExclusionGroupResult>> CreateExclusionGroupAsync(CreateExclusionGroupRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Creates a new experiment for the title.
        /// </summary>
        /// <param name="request">The request parameters for creating the experiment.</param>
        /// <param name="customData">Optional custom data associated with the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the result of the create experiment operation.</returns>
        Task<PlayFabResult<CreateExperimentResult>> CreateExperimentAsync(CreateExperimentRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes an exclusion group.
        /// </summary>
        /// <param name="request">The request parameters for deleting the exclusion group.</param>
        /// <param name="customData">Optional custom data associated with the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the result of the delete exclusion group operation.</returns>
        Task<PlayFabResult<EmptyResponse>> DeleteExclusionGroupAsync(DeleteExclusionGroupRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes an experiment. The experiment must be stopped before it can be deleted.
        /// </summary>
        /// <param name="request">The request parameters for deleting the experiment.</param>
        /// <param name="customData">Optional custom data associated with the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the result of the delete experiment operation.</returns>
        Task<PlayFabResult<EmptyResponse>> DeleteExperimentAsync(DeleteExperimentRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the list of all exclusion groups for a title.
        /// </summary>
        /// <param name="request">The request parameters for retrieving exclusion groups.</param>
        /// <param name="customData">Optional custom data associated with the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the list of exclusion groups.</returns>
        Task<PlayFabResult<GetExclusionGroupsResult>> GetExclusionGroupsAsync(GetExclusionGroupsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the list of traffic allocations for a specific exclusion group.
        /// </summary>
        /// <param name="request">The request parameters for retrieving exclusion group traffic.</param>
        /// <param name="customData">Optional custom data associated with the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the traffic allocations for the exclusion group.</returns>
        Task<PlayFabResult<GetExclusionGroupTrafficResult>> GetExclusionGroupTrafficAsync(GetExclusionGroupTrafficRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the list of all experiments for a title, including scheduled, started, stopped, or completed experiments.
        /// </summary>
        /// <param name="request">The request parameters for retrieving experiments.</param>
        /// <param name="customData">Optional custom data associated with the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the list of experiments.</returns>
        Task<PlayFabResult<GetExperimentsResult>> GetExperimentsAsync(GetExperimentsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the latest available scorecard for an experiment.
        /// </summary>
        /// <param name="request">The request parameters for retrieving the latest scorecard.</param>
        /// <param name="customData">Optional custom data associated with the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the latest scorecard for the experiment.</returns>
        Task<PlayFabResult<GetLatestScorecardResult>> GetLatestScorecardAsync(GetLatestScorecardRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the treatment variants and variables assigned to the entity across all running experiments.
        /// </summary>
        /// <param name="request">The request parameters for retrieving treatment assignments.</param>
        /// <param name="customData">Optional custom data associated with the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the treatment assignment for the entity.</returns>
        Task<PlayFabResult<GetTreatmentAssignmentResult>> GetTreatmentAssignmentAsync(GetTreatmentAssignmentRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Starts an experiment.
        /// </summary>
        /// <param name="request">The request parameters for starting the experiment.</param>
        /// <param name="customData">Optional custom data associated with the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the result of the start experiment operation.</returns>
        Task<PlayFabResult<EmptyResponse>> StartExperimentAsync(StartExperimentRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Stops a running experiment.
        /// </summary>
        /// <param name="request">The request parameters for stopping the experiment.</param>
        /// <param name="customData">Optional custom data associated with the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the result of the stop experiment operation.</returns>
        Task<PlayFabResult<EmptyResponse>> StopExperimentAsync(StopExperimentRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates an exclusion group.
        /// </summary>
        /// <param name="request">The request parameters for updating the exclusion group.</param>
        /// <param name="customData">Optional custom data associated with the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the result of the update exclusion group operation.</returns>
        Task<PlayFabResult<EmptyResponse>> UpdateExclusionGroupAsync(UpdateExclusionGroupRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates an experiment. If the experiment is already running, only the description and duration properties can be updated.
        /// </summary>
        /// <param name="request">The request parameters for updating the experiment.</param>
        /// <param name="customData">Optional custom data associated with the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the result of the update experiment operation.</returns>
        Task<PlayFabResult<EmptyResponse>> UpdateExperimentAsync(UpdateExperimentRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
    }
}
