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
        /// Retrieves the list of allowed languages for the title in BCP47 two-letter format.
        /// </summary>
        /// <param name="request">The request parameters for getting the language list.</param>
        /// <param name="customData">Optional custom data to associate with the request.</param>
        /// <param name="extraHeaders">Optional extra headers to include in the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the language list response.</returns>
        Task<PlayFabResult<GetLanguageListResponse>> GetLanguageListAsync(GetLanguageListRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
    }
}
