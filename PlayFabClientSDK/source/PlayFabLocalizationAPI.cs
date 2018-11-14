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
    public class PlayFabLocalizationAPI
    {
        /// <summary>
        /// Retrieves the list of allowed languages, only accessible by title entities
        /// </summary>
        public static async Task<PlayFabResult<GetLanguageListResponse>> GetLanguageListAsync(GetLanguageListRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            if (PlayFabSettings.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Locale/GetLanguageList", request, "X-EntityToken", PlayFabSettings.EntityToken, extraHeaders);
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
