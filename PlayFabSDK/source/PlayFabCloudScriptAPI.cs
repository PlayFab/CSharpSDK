using PlayFab.CloudScriptModels;
using PlayFab.Internal;
using PlayFab.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayFab
{
    /// <summary>
    /// API methods for executing CloudScript using an Entity Profile
    /// </summary>
    public class PlayFabCloudScriptAPI
    {
        /// <summary>
        /// Cloud Script is one of PlayFab's most versatile features. It allows client code to request execution of any kind of
        /// custom server-side functionality you can implement, and it can be used in conjunction with virtually anything.
        /// </summary>
        public static async Task<PlayFabResult<ExecuteCloudScriptResult>> ExecuteEntityCloudScriptAsync(ExecuteEntityCloudScriptRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            if (PlayFabSettings.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/CloudScript/ExecuteEntityCloudScript", request, "X-EntityToken", PlayFabSettings.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ExecuteCloudScriptResult> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ExecuteCloudScriptResult>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ExecuteCloudScriptResult> { Result = result, CustomData = customData };
        }

    }
}
