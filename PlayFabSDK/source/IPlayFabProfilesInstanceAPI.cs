#if !DISABLE_PLAYFABENTITY_API

using PlayFab.ProfilesModels;
using PlayFab.Internal;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayFab
{
    /// <summary>
    /// All PlayFab entities have profiles, which hold top-level properties about the entity. These APIs give you the tools
    /// needed to manage entity profiles.
    /// </summary>
    public interface IPlayFabProfilesInstanceAPI
    {
        /// <summary>
        /// Gets the global title access policy
        /// </summary>
        Task<PlayFabResult<GetGlobalPolicyResponse>> GetGlobalPolicyAsync(
            GetGlobalPolicyRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves the entity's profile.
        /// </summary>
        Task<PlayFabResult<GetEntityProfileResponse>> GetProfileAsync(
            GetEntityProfileRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves the entity's profile.
        /// </summary>
        Task<PlayFabResult<GetEntityProfilesResponse>> GetProfilesAsync(
            GetEntityProfilesRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves the title player accounts associated with the given master player account.
        /// </summary>
        Task<PlayFabResult<GetTitlePlayersFromMasterPlayerAccountIdsResponse>> GetTitlePlayersFromMasterPlayerAccountIdsAsync(
            GetTitlePlayersFromMasterPlayerAccountIdsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves the title player accounts associated with the given XUIDs.
        /// </summary>
        Task<PlayFabResult<GetTitlePlayersFromProviderIDsResponse>> GetTitlePlayersFromXboxLiveIDsAsync(
            GetTitlePlayersFromXboxLiveIDsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Update the display name of the entity
        /// </summary>
        Task<PlayFabResult<SetDisplayNameResponse>> SetDisplayNameAsync(
            SetDisplayNameRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Sets the global title access policy
        /// </summary>
        Task<PlayFabResult<SetGlobalPolicyResponse>> SetGlobalPolicyAsync(
            SetGlobalPolicyRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates the entity's language. The precedence hierarchy for communication to the player is Title Player Account
        /// language, Master Player Account language, and then title default language if the first two aren't set or supported.
        /// </summary>
        Task<PlayFabResult<SetProfileLanguageResponse>> SetProfileLanguageAsync(
            SetProfileLanguageRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Sets the profiles access policy
        /// </summary>
        Task<PlayFabResult<SetEntityProfilePolicyResponse>> SetProfilePolicyAsync(
            SetEntityProfilePolicyRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);
    }
}
#endif
