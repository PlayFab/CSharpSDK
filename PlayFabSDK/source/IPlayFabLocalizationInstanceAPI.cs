using PlayFab.LocalizationModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayFab
{
    /// <summary>
    /// Interface for PlayFabLocalizationInstanceAPI.
    /// </summary>
    public interface IPlayFabLocalizationInstanceAPI
    {
        bool IsEntityLoggedIn();
        void ForgetAllCredentials();
        Task<PlayFabResult<GetLanguageListResponse>> GetLanguageListAsync(GetLanguageListRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
    }
}
