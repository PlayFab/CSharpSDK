using PlayFab.ProfilesModels;
using PlayFab.Internal;
using PlayFab.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayFab
{
    /// <summary>
    /// All PlayFab entities have profiles, which hold top-level properties about the entity. These APIs give you the tools
    /// needed to manage entity profiles.
    /// </summary>
    public class PlayFabProfilesAPI
    {
        /// <summary>
        /// Gets the global title access policy
        /// </summary>
        public static async Task<PlayFabResult<GetGlobalPolicyResponse>> GetGlobalPolicyAsync(GetGlobalPolicyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            if (PlayFabSettings.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Profile/GetGlobalPolicy", request, "X-EntityToken", PlayFabSettings.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetGlobalPolicyResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetGlobalPolicyResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetGlobalPolicyResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves the entity's profile.
        /// </summary>
        public static async Task<PlayFabResult<GetEntityProfileResponse>> GetProfileAsync(GetEntityProfileRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            if (PlayFabSettings.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Profile/GetProfile", request, "X-EntityToken", PlayFabSettings.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetEntityProfileResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetEntityProfileResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetEntityProfileResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves the entity's profile.
        /// </summary>
        public static async Task<PlayFabResult<GetEntityProfilesResponse>> GetProfilesAsync(GetEntityProfilesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            if (PlayFabSettings.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Profile/GetProfiles", request, "X-EntityToken", PlayFabSettings.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetEntityProfilesResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetEntityProfilesResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetEntityProfilesResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Sets the global title access policy
        /// </summary>
        public static async Task<PlayFabResult<SetGlobalPolicyResponse>> SetGlobalPolicyAsync(SetGlobalPolicyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            if (PlayFabSettings.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Profile/SetGlobalPolicy", request, "X-EntityToken", PlayFabSettings.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<SetGlobalPolicyResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<SetGlobalPolicyResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<SetGlobalPolicyResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Updates the entity's language. The precedence hierarchy for communication to the player is Title Player Account
        /// language, Master Player Account language, and then title default language if the first two aren't set or supported.
        /// </summary>
        public static async Task<PlayFabResult<SetProfileLanguageResponse>> SetProfileLanguageAsync(SetProfileLanguageRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            if (PlayFabSettings.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Profile/SetProfileLanguage", request, "X-EntityToken", PlayFabSettings.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<SetProfileLanguageResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<SetProfileLanguageResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<SetProfileLanguageResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Sets the profiles access policy
        /// </summary>
        public static async Task<PlayFabResult<SetEntityProfilePolicyResponse>> SetProfilePolicyAsync(SetEntityProfilePolicyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            if (PlayFabSettings.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Profile/SetProfilePolicy", request, "X-EntityToken", PlayFabSettings.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<SetEntityProfilePolicyResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<SetEntityProfilePolicyResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<SetEntityProfilePolicyResponse> { Result = result, CustomData = customData };
        }

    }
}
