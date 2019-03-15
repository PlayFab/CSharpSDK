#if !DISABLE_PLAYFABENTITY_API

using PlayFab.LocalizationModels;
using PlayFab.Internal;
using PlayFab.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayFab
{
    /// <summary>
    /// The Localization APIs give you the tools needed to manage language setup in your title.
    /// </summary>
    public class PlayFabLocalizationInstanceAPI
    {
        private PlayFabApiSettings apiSettings = null;
        private PlayFabAuthenticationContext authenticationContext = null;

        public PlayFabLocalizationInstanceAPI()
        {

        }

        public PlayFabLocalizationInstanceAPI(PlayFabApiSettings settings = null)
        {
            apiSettings = settings;
        }

        public PlayFabLocalizationInstanceAPI(PlayFabAuthenticationContext context = null)
        {
            authenticationContext = context;
        }

        public PlayFabLocalizationInstanceAPI(PlayFabApiSettings settings = null, PlayFabAuthenticationContext context = null)
        {
            apiSettings = settings;
            authenticationContext = context;
        }

        public void SetSettings(PlayFabApiSettings settings)
        {
            apiSettings = settings;
        }

        public PlayFabApiSettings GetSettings()
        {
            return apiSettings;
        }

        public void SetAuthenticationContext(PlayFabAuthenticationContext context)
        {
            authenticationContext = context;
        }

        public PlayFabAuthenticationContext GetAuthenticationContext()
        {
            return authenticationContext;
        }

        /// <summary>
        /// Retrieves the list of allowed languages, only accessible by title entities
        /// </summary>
        public async Task<PlayFabResult<GetLanguageListResponse>> GetLanguageListAsync(GetLanguageListRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            if ((request?.AuthenticationContext?.EntityToken ?? PlayFabSettings.staticPlayer.EntityToken) == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Locale/GetLanguageList", request, "X-EntityToken", PlayFabSettings.staticPlayer.EntityToken, extraHeaders, apiSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetLanguageListResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetLanguageListResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetLanguageListResponse> { Result = result, CustomData = customData };
        }

    }
}
#endif
