using PlayFab.MultiplayerModels;
using PlayFab.Internal;
using PlayFab.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayFab
{
    /// <summary>
    /// API methods for managing multiplayer servers.
    /// </summary>
    public class PlayFabMultiplayerAPI
    {
        /// <summary>
        /// Creates a multiplayer server build with a custom container.
        /// </summary>
        public static async Task<PlayFabResult<CreateBuildWithCustomContainerResponse>> CreateBuildWithCustomContainerAsync(CreateBuildWithCustomContainerRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            if (PlayFabSettings.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/CreateBuildWithCustomContainer", request, "X-EntityToken", PlayFabSettings.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<CreateBuildWithCustomContainerResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<CreateBuildWithCustomContainerResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<CreateBuildWithCustomContainerResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Creates a multiplayer server build with a managed container.
        /// </summary>
        public static async Task<PlayFabResult<CreateBuildWithManagedContainerResponse>> CreateBuildWithManagedContainerAsync(CreateBuildWithManagedContainerRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            if (PlayFabSettings.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/CreateBuildWithManagedContainer", request, "X-EntityToken", PlayFabSettings.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<CreateBuildWithManagedContainerResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<CreateBuildWithManagedContainerResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<CreateBuildWithManagedContainerResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Creates a remote user to log on to a VM for a multiplayer server build.
        /// </summary>
        public static async Task<PlayFabResult<CreateRemoteUserResponse>> CreateRemoteUserAsync(CreateRemoteUserRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            if (PlayFabSettings.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/CreateRemoteUser", request, "X-EntityToken", PlayFabSettings.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<CreateRemoteUserResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<CreateRemoteUserResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<CreateRemoteUserResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Deletes a multiplayer server game asset for a title.
        /// </summary>
        public static async Task<PlayFabResult<EmptyResponse>> DeleteAssetAsync(DeleteAssetRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            if (PlayFabSettings.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/DeleteAsset", request, "X-EntityToken", PlayFabSettings.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<EmptyResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<EmptyResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<EmptyResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Deletes a multiplayer server build.
        /// </summary>
        public static async Task<PlayFabResult<EmptyResponse>> DeleteBuildAsync(DeleteBuildRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            if (PlayFabSettings.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/DeleteBuild", request, "X-EntityToken", PlayFabSettings.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<EmptyResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<EmptyResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<EmptyResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Deletes a multiplayer server game certificate.
        /// </summary>
        public static async Task<PlayFabResult<EmptyResponse>> DeleteCertificateAsync(DeleteCertificateRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            if (PlayFabSettings.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/DeleteCertificate", request, "X-EntityToken", PlayFabSettings.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<EmptyResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<EmptyResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<EmptyResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Deletes a remote user to log on to a VM for a multiplayer server build.
        /// </summary>
        public static async Task<PlayFabResult<EmptyResponse>> DeleteRemoteUserAsync(DeleteRemoteUserRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            if (PlayFabSettings.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/DeleteRemoteUser", request, "X-EntityToken", PlayFabSettings.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<EmptyResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<EmptyResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<EmptyResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Enables the multiplayer server feature for a title.
        /// </summary>
        public static async Task<PlayFabResult<EnableMultiplayerServersForTitleResponse>> EnableMultiplayerServersForTitleAsync(EnableMultiplayerServersForTitleRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            if (PlayFabSettings.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/EnableMultiplayerServersForTitle", request, "X-EntityToken", PlayFabSettings.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<EnableMultiplayerServersForTitleResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<EnableMultiplayerServersForTitleResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<EnableMultiplayerServersForTitleResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Gets the URL to upload assets to.
        /// </summary>
        public static async Task<PlayFabResult<GetAssetUploadUrlResponse>> GetAssetUploadUrlAsync(GetAssetUploadUrlRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            if (PlayFabSettings.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/GetAssetUploadUrl", request, "X-EntityToken", PlayFabSettings.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetAssetUploadUrlResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetAssetUploadUrlResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetAssetUploadUrlResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Gets a multiplayer server build.
        /// </summary>
        public static async Task<PlayFabResult<GetBuildResponse>> GetBuildAsync(GetBuildRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            if (PlayFabSettings.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/GetBuild", request, "X-EntityToken", PlayFabSettings.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetBuildResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetBuildResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetBuildResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Gets the credentials to the container registry.
        /// </summary>
        public static async Task<PlayFabResult<GetContainerRegistryCredentialsResponse>> GetContainerRegistryCredentialsAsync(GetContainerRegistryCredentialsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            if (PlayFabSettings.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/GetContainerRegistryCredentials", request, "X-EntityToken", PlayFabSettings.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetContainerRegistryCredentialsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetContainerRegistryCredentialsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetContainerRegistryCredentialsResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Gets multiplayer server session details for a build.
        /// </summary>
        public static async Task<PlayFabResult<GetMultiplayerServerDetailsResponse>> GetMultiplayerServerDetailsAsync(GetMultiplayerServerDetailsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            if (PlayFabSettings.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/GetMultiplayerServerDetails", request, "X-EntityToken", PlayFabSettings.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetMultiplayerServerDetailsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetMultiplayerServerDetailsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetMultiplayerServerDetailsResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Gets a remote login endpoint to a VM that is hosting a multiplayer server build.
        /// </summary>
        public static async Task<PlayFabResult<GetRemoteLoginEndpointResponse>> GetRemoteLoginEndpointAsync(GetRemoteLoginEndpointRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            if (PlayFabSettings.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/GetRemoteLoginEndpoint", request, "X-EntityToken", PlayFabSettings.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetRemoteLoginEndpointResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetRemoteLoginEndpointResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetRemoteLoginEndpointResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Gets the status of whether a title is enabled for the multiplayer server feature.
        /// </summary>
        public static async Task<PlayFabResult<GetTitleEnabledForMultiplayerServersStatusResponse>> GetTitleEnabledForMultiplayerServersStatusAsync(GetTitleEnabledForMultiplayerServersStatusRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            if (PlayFabSettings.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/GetTitleEnabledForMultiplayerServersStatus", request, "X-EntityToken", PlayFabSettings.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetTitleEnabledForMultiplayerServersStatusResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetTitleEnabledForMultiplayerServersStatusResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetTitleEnabledForMultiplayerServersStatusResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Lists archived multiplayer server sessions for a build.
        /// </summary>
        public static async Task<PlayFabResult<ListMultiplayerServersResponse>> ListArchivedMultiplayerServersAsync(ListMultiplayerServersRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            if (PlayFabSettings.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/ListArchivedMultiplayerServers", request, "X-EntityToken", PlayFabSettings.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ListMultiplayerServersResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ListMultiplayerServersResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ListMultiplayerServersResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Lists multiplayer server game assets for a title.
        /// </summary>
        public static async Task<PlayFabResult<ListAssetSummariesResponse>> ListAssetSummariesAsync(ListAssetSummariesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            if (PlayFabSettings.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/ListAssetSummaries", request, "X-EntityToken", PlayFabSettings.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ListAssetSummariesResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ListAssetSummariesResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ListAssetSummariesResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Lists summarized details of all multiplayer server builds for a title.
        /// </summary>
        public static async Task<PlayFabResult<ListBuildSummariesResponse>> ListBuildSummariesAsync(ListBuildSummariesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            if (PlayFabSettings.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/ListBuildSummaries", request, "X-EntityToken", PlayFabSettings.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ListBuildSummariesResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ListBuildSummariesResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ListBuildSummariesResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Lists multiplayer server game certificates for a title.
        /// </summary>
        public static async Task<PlayFabResult<ListCertificateSummariesResponse>> ListCertificateSummariesAsync(ListCertificateSummariesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            if (PlayFabSettings.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/ListCertificateSummaries", request, "X-EntityToken", PlayFabSettings.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ListCertificateSummariesResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ListCertificateSummariesResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ListCertificateSummariesResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Lists custom container images for a title.
        /// </summary>
        public static async Task<PlayFabResult<ListContainerImagesResponse>> ListContainerImagesAsync(ListContainerImagesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            if (PlayFabSettings.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/ListContainerImages", request, "X-EntityToken", PlayFabSettings.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ListContainerImagesResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ListContainerImagesResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ListContainerImagesResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Lists the tags for a custom container image.
        /// </summary>
        public static async Task<PlayFabResult<ListContainerImageTagsResponse>> ListContainerImageTagsAsync(ListContainerImageTagsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            if (PlayFabSettings.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/ListContainerImageTags", request, "X-EntityToken", PlayFabSettings.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ListContainerImageTagsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ListContainerImageTagsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ListContainerImageTagsResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Lists multiplayer server sessions for a build.
        /// </summary>
        public static async Task<PlayFabResult<ListMultiplayerServersResponse>> ListMultiplayerServersAsync(ListMultiplayerServersRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            if (PlayFabSettings.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/ListMultiplayerServers", request, "X-EntityToken", PlayFabSettings.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ListMultiplayerServersResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ListMultiplayerServersResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ListMultiplayerServersResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Lists quality of service servers.
        /// </summary>
        public static async Task<PlayFabResult<ListQosServersResponse>> ListQosServersAsync(ListQosServersRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {

            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/ListQosServers", request, null, null, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ListQosServersResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ListQosServersResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ListQosServersResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Lists virtual machines for a title.
        /// </summary>
        public static async Task<PlayFabResult<ListVirtualMachineSummariesResponse>> ListVirtualMachineSummariesAsync(ListVirtualMachineSummariesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            if (PlayFabSettings.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/ListVirtualMachineSummaries", request, "X-EntityToken", PlayFabSettings.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ListVirtualMachineSummariesResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ListVirtualMachineSummariesResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ListVirtualMachineSummariesResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Request a multiplayer server session. Accepts tokens for title and if game client accesss is enabled, allows game client
        /// to request a server with player entity token.
        /// </summary>
        public static async Task<PlayFabResult<RequestMultiplayerServerResponse>> RequestMultiplayerServerAsync(RequestMultiplayerServerRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            if (PlayFabSettings.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/RequestMultiplayerServer", request, "X-EntityToken", PlayFabSettings.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<RequestMultiplayerServerResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<RequestMultiplayerServerResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<RequestMultiplayerServerResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Rolls over the credentials to the container registry.
        /// </summary>
        public static async Task<PlayFabResult<RolloverContainerRegistryCredentialsResponse>> RolloverContainerRegistryCredentialsAsync(RolloverContainerRegistryCredentialsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            if (PlayFabSettings.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/RolloverContainerRegistryCredentials", request, "X-EntityToken", PlayFabSettings.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<RolloverContainerRegistryCredentialsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<RolloverContainerRegistryCredentialsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<RolloverContainerRegistryCredentialsResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Shuts down a multiplayer server session.
        /// </summary>
        public static async Task<PlayFabResult<EmptyResponse>> ShutdownMultiplayerServerAsync(ShutdownMultiplayerServerRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            if (PlayFabSettings.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/ShutdownMultiplayerServer", request, "X-EntityToken", PlayFabSettings.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<EmptyResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<EmptyResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<EmptyResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Updates a multiplayer server build's regions.
        /// </summary>
        public static async Task<PlayFabResult<EmptyResponse>> UpdateBuildRegionsAsync(UpdateBuildRegionsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            if (PlayFabSettings.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/UpdateBuildRegions", request, "X-EntityToken", PlayFabSettings.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<EmptyResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<EmptyResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<EmptyResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Uploads a multiplayer server game certificate.
        /// </summary>
        public static async Task<PlayFabResult<EmptyResponse>> UploadCertificateAsync(UploadCertificateRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            if (PlayFabSettings.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/MultiplayerServer/UploadCertificate", request, "X-EntityToken", PlayFabSettings.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<EmptyResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<EmptyResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<EmptyResponse> { Result = result, CustomData = customData };
        }

    }
}
