using PlayFab.ProfilesModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayFab
{
    public interface IPlayFabProfilesInstanceAPI
    {
        bool IsEntityLoggedIn();
        void ForgetAllCredentials();
        Task<PlayFabResult<GetGlobalPolicyResponse>> GetGlobalPolicyAsync(GetGlobalPolicyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<GetEntityProfileResponse>> GetProfileAsync(GetEntityProfileRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<GetEntityProfilesResponse>> GetProfilesAsync(GetEntityProfilesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<GetTitlePlayersFromMasterPlayerAccountIdsResponse>> GetTitlePlayersFromMasterPlayerAccountIdsAsync(GetTitlePlayersFromMasterPlayerAccountIdsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<GetTitlePlayersFromProviderIDsResponse>> GetTitlePlayersFromXboxLiveIDsAsync(GetTitlePlayersFromXboxLiveIDsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<SetDisplayNameResponse>> SetDisplayNameAsync(SetDisplayNameRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<SetGlobalPolicyResponse>> SetGlobalPolicyAsync(SetGlobalPolicyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<SetProfileLanguageResponse>> SetProfileLanguageAsync(SetProfileLanguageRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<SetEntityProfilePolicyResponse>> SetProfilePolicyAsync(SetEntityProfilePolicyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
    }
}
