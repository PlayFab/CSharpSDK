using PlayFab.AuthenticationModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayFab
{
    public interface IPlayFabAuthenticationInstanceAPI
    {
        bool IsEntityLoggedIn();
        void ForgetAllCredentials();
        Task<PlayFabResult<AuthenticateCustomIdResult>> AuthenticateGameServerWithCustomIdAsync(
            AuthenticateCustomIdRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null
        );
        Task<PlayFabResult<EmptyResponse>> DeleteAsync(
            DeleteRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null
        );
        Task<PlayFabResult<GetEntityTokenResponse>> GetEntityTokenAsync(
            GetEntityTokenRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null
        );
        Task<PlayFabResult<ValidateEntityTokenResponse>> ValidateEntityTokenAsync(
            ValidateEntityTokenRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null
        );
    }
}
