#if !DISABLE_PLAYFABENTITY_API

using PlayFab.ExperimentationModels;
using PlayFab.Internal;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayFab
{
    /// <summary>
    /// APIs for managing experiments.
    /// </summary>
    public interface IPlayFabExperimentationInstanceAPI
    {
        /// <summary>
        /// Creates a new experiment exclusion group for a title.
        /// </summary>
        Task<PlayFabResult<CreateExclusionGroupResult>> CreateExclusionGroupAsync(
            CreateExclusionGroupRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Creates a new experiment for a title.
        /// </summary>
        Task<PlayFabResult<CreateExperimentResult>> CreateExperimentAsync(
            CreateExperimentRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes an existing exclusion group for a title.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> DeleteExclusionGroupAsync(
            DeleteExclusionGroupRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes an existing experiment for a title.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> DeleteExperimentAsync(
            DeleteExperimentRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the details of all exclusion groups for a title.
        /// </summary>
        Task<PlayFabResult<GetExclusionGroupsResult>> GetExclusionGroupsAsync(
            GetExclusionGroupsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the details of all exclusion groups for a title.
        /// </summary>
        Task<PlayFabResult<GetExclusionGroupTrafficResult>> GetExclusionGroupTrafficAsync(
            GetExclusionGroupTrafficRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the details of all experiments for a title.
        /// </summary>
        Task<PlayFabResult<GetExperimentsResult>> GetExperimentsAsync(
            GetExperimentsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the latest scorecard of the experiment for the title.
        /// </summary>
        Task<PlayFabResult<GetLatestScorecardResult>> GetLatestScorecardAsync(
            GetLatestScorecardRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the treatment assignments for a player for every running experiment in the title.
        /// </summary>
        Task<PlayFabResult<GetTreatmentAssignmentResult>> GetTreatmentAssignmentAsync(
            GetTreatmentAssignmentRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Starts an existing experiment for a title.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> StartExperimentAsync(
            StartExperimentRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Stops an existing experiment for a title.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> StopExperimentAsync(
            StopExperimentRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates an existing exclusion group for a title.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> UpdateExclusionGroupAsync(
            UpdateExclusionGroupRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates an existing experiment for a title.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> UpdateExperimentAsync(
            UpdateExperimentRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);
    }
}
#endif
