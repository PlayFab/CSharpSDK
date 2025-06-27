#if !DISABLE_PLAYFABENTITY_API

using PlayFab.LocalizationModels;
using PlayFab.Internal;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayFab
{
    /// <summary>
    /// The Localization APIs give you the tools needed to manage language setup in your title.
    /// </summary>
    public interface IPlayFabLocalizationInstanceAPI
    {
        /// <summary>
        /// Retrieves the list of allowed languages, only accessible by title entities
        /// </summary>
        Task<PlayFabResult<GetLanguageListResponse>> GetLanguageListAsync(
            GetLanguageListRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);
    }
}
#endif
