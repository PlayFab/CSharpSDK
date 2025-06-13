using PlayFab.ProfilesModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayFab
{
    /// <summary>
    /// Interface for PlayFab Profiles Instance API, providing methods to interact with entity profiles and policies.
    /// </summary>
    public interface IPlayFabProfilesInstanceAPI
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
        /// Retrieves the title access policy that is used before the profile's policy is inspected during a request.
        /// </summary>
        /// <param name="request">The request parameters for retrieving the global policy.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the global policy response.</returns>
        Task<PlayFabResult<GetGlobalPolicyResponse>> GetGlobalPolicyAsync(GetGlobalPolicyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves the profile for a given entity type and identifier.
        /// </summary>
        /// <param name="request">The request parameters for retrieving the entity profile.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the entity profile response.</returns>
        Task<PlayFabResult<GetEntityProfileResponse>> GetProfileAsync(GetEntityProfileRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves all readable profiles properties for a set of entity types and identifiers.
        /// </summary>
        /// <param name="request">The request parameters for retrieving multiple entity profiles.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the entity profiles response.</returns>
        Task<PlayFabResult<GetEntityProfilesResponse>> GetProfilesAsync(GetEntityProfilesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Returns all title player accounts associated with a given master player account id (PlayFab ID).
        /// </summary>
        /// <param name="request">The request parameters for retrieving title players from master player account ids.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response with title player accounts.</returns>
        Task<PlayFabResult<GetTitlePlayersFromMasterPlayerAccountIdsResponse>> GetTitlePlayersFromMasterPlayerAccountIdsAsync(GetTitlePlayersFromMasterPlayerAccountIdsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Returns all title player accounts for a collection of Xbox Live IDs (XUIDs).
        /// </summary>
        /// <param name="request">The request parameters for retrieving title players from Xbox Live IDs.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response with title player accounts.</returns>
        Task<PlayFabResult<GetTitlePlayersFromProviderIDsResponse>> GetTitlePlayersFromXboxLiveIDsAsync(GetTitlePlayersFromXboxLiveIDsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates the display name of an entity profile if the profile's version matches the specified value.
        /// </summary>
        /// <param name="request">The request parameters for setting the display name.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response for the display name update.</returns>
        Task<PlayFabResult<SetDisplayNameResponse>> SetDisplayNameAsync(SetDisplayNameRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates the title access policy that is used before the profile's policy is inspected during a request.
        /// </summary>
        /// <param name="request">The request parameters for setting the global policy.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response for the global policy update.</returns>
        Task<PlayFabResult<SetGlobalPolicyResponse>> SetGlobalPolicyAsync(SetGlobalPolicyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates the language of an entity profile if the profile's version matches the specified value.
        /// </summary>
        /// <param name="request">The request parameters for setting the profile language.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response for the language update.</returns>
        Task<PlayFabResult<SetProfileLanguageResponse>> SetProfileLanguageAsync(SetProfileLanguageRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Sets the access policy statements on the given entity profile, replacing any existing statements.
        /// </summary>
        /// <param name="request">The request parameters for setting the profile policy.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response for the profile policy update.</returns>
        Task<PlayFabResult<SetEntityProfilePolicyResponse>> SetProfilePolicyAsync(SetEntityProfilePolicyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
    }
}
