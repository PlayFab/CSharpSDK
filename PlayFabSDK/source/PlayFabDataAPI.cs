#if !DISABLE_PLAYFABENTITY_API

using PlayFab.DataModels;
using PlayFab.Internal;
using PlayFab.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayFab
{
    /// <summary>
    /// Store arbitrary data associated with an entity. Objects are small (~1KB) JSON-compatible objects which are stored
    /// directly on the entity profile. Objects are made available for use in other PlayFab contexts, such as PlayStream events
    /// and CloudScript functions. Files can efficiently store data of any size or format. Both objects and files support a
    /// flexible permissions system to control read and write access by other entities.
    /// </summary>
    public static class PlayFabDataAPI
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
        /// Abort pending file uploads to an entity's profile.
        /// </summary>
        public static async Task<PlayFabResult<AbortFileUploadsResponse>> AbortFileUploadsAsync(AbortFileUploadsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            if ((request?.AuthenticationContext?.EntityToken ?? PlayFabSettings.staticPlayer.EntityToken) == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/File/AbortFileUploads", request, "X-EntityToken", PlayFabSettings.staticPlayer.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<AbortFileUploadsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<AbortFileUploadsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<AbortFileUploadsResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Delete files on an entity's profile.
        /// </summary>
        public static async Task<PlayFabResult<DeleteFilesResponse>> DeleteFilesAsync(DeleteFilesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            if ((request?.AuthenticationContext?.EntityToken ?? PlayFabSettings.staticPlayer.EntityToken) == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/File/DeleteFiles", request, "X-EntityToken", PlayFabSettings.staticPlayer.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<DeleteFilesResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<DeleteFilesResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<DeleteFilesResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Finalize file uploads to an entity's profile.
        /// </summary>
        public static async Task<PlayFabResult<FinalizeFileUploadsResponse>> FinalizeFileUploadsAsync(FinalizeFileUploadsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            if ((request?.AuthenticationContext?.EntityToken ?? PlayFabSettings.staticPlayer.EntityToken) == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/File/FinalizeFileUploads", request, "X-EntityToken", PlayFabSettings.staticPlayer.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<FinalizeFileUploadsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<FinalizeFileUploadsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<FinalizeFileUploadsResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves file metadata from an entity's profile.
        /// </summary>
        public static async Task<PlayFabResult<GetFilesResponse>> GetFilesAsync(GetFilesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            if ((request?.AuthenticationContext?.EntityToken ?? PlayFabSettings.staticPlayer.EntityToken) == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/File/GetFiles", request, "X-EntityToken", PlayFabSettings.staticPlayer.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetFilesResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetFilesResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetFilesResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves objects from an entity's profile.
        /// </summary>
        public static async Task<PlayFabResult<GetObjectsResponse>> GetObjectsAsync(GetObjectsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            if ((request?.AuthenticationContext?.EntityToken ?? PlayFabSettings.staticPlayer.EntityToken) == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Object/GetObjects", request, "X-EntityToken", PlayFabSettings.staticPlayer.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetObjectsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetObjectsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetObjectsResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Initiates file uploads to an entity's profile.
        /// </summary>
        public static async Task<PlayFabResult<InitiateFileUploadsResponse>> InitiateFileUploadsAsync(InitiateFileUploadsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            if ((request?.AuthenticationContext?.EntityToken ?? PlayFabSettings.staticPlayer.EntityToken) == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/File/InitiateFileUploads", request, "X-EntityToken", PlayFabSettings.staticPlayer.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<InitiateFileUploadsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<InitiateFileUploadsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<InitiateFileUploadsResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Sets objects on an entity's profile.
        /// </summary>
        public static async Task<PlayFabResult<SetObjectsResponse>> SetObjectsAsync(SetObjectsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            if ((request?.AuthenticationContext?.EntityToken ?? PlayFabSettings.staticPlayer.EntityToken) == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Object/SetObjects", request, "X-EntityToken", PlayFabSettings.staticPlayer.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<SetObjectsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<SetObjectsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<SetObjectsResponse> { Result = result, CustomData = customData };
        }
    }
}
#endif
