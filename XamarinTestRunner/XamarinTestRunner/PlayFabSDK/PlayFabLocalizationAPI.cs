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
    public static class PlayFabLocalizationAPI
    {
        /// <summary>
        /// Verify entity login.
        /// </summary>
        public static bool IsEntityLoggedIn()
        {
            return PlayFabSettings.staticPlayer.IsEntityLoggedIn();
        }

        /// <summary>
        /// Clear the Client SessionToken which allows this Client to call API calls requiring login.
        /// A new/fresh login will be required after calling this.
        /// </summary>
        public static void ForgetAllCredentials()
        {
            PlayFabSettings.staticPlayer.ForgetAllCredentials();
        }

        /// <summary>
        /// Retrieves the list of allowed languages, only accessible by title entities
        /// </summary>
        public static async Task<PlayFabResult<GetLanguageListResponse>> GetLanguageListAsync(GetLanguageListRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            if ((request?.AuthenticationContext?.EntityToken ?? PlayFabSettings.staticPlayer.EntityToken) == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Locale/GetLanguageList", request, "X-EntityToken", PlayFabSettings.staticPlayer.EntityToken, extraHeaders);
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
