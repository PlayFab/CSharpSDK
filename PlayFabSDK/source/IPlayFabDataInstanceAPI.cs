using PlayFab.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayFab
{
    public interface IPlayFabDataInstanceAPI
    {
        /// <summary>
        /// Determines if the entity is currently logged in.
        /// </summary>
        /// <returns>True if the entity is logged in; otherwise, false.</returns>
        bool IsEntityLoggedIn();

        /// <summary>
        /// Forgets all stored credentials for the current entity.
        /// </summary>
        void ForgetAllCredentials();

        /// <summary>
        /// Aborts the pending upload of the requested files.
        /// </summary>
        /// <param name="request">The request containing file names and entity information.</param>
        /// <param name="customData">Optional custom data to associate with the request.</param>
        /// <param name="extraHeaders">Optional extra headers to include in the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the abort file uploads response.</returns>
        Task<PlayFabResult<AbortFileUploadsResponse>> AbortFileUploadsAsync(AbortFileUploadsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes the requested files from the entity's profile.
        /// </summary>
        /// <param name="request">The request containing file names and entity information.</param>
        /// <param name="customData">Optional custom data to associate with the request.</param>
        /// <param name="extraHeaders">Optional extra headers to include in the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the delete files response.</returns>
        Task<PlayFabResult<DeleteFilesResponse>> DeleteFilesAsync(DeleteFilesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Finalizes the upload of the requested files, verifying successful upload and moving file pointers from pending to live.
        /// </summary>
        /// <param name="request">The request containing file names and entity information.</param>
        /// <param name="customData">Optional custom data to associate with the request.</param>
        /// <param name="extraHeaders">Optional extra headers to include in the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the finalize file uploads response.</returns>
        Task<PlayFabResult<FinalizeFileUploadsResponse>> FinalizeFileUploadsAsync(FinalizeFileUploadsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Returns URLs that may be used to download the files for a profile for a limited length of time.
        /// </summary>
        /// <param name="request">The request containing entity information.</param>
        /// <param name="customData">Optional custom data to associate with the request.</param>
        /// <param name="extraHeaders">Optional extra headers to include in the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the get files response.</returns>
        Task<PlayFabResult<GetFilesResponse>> GetFilesAsync(GetFilesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets JSON objects from an entity profile and returns them.
        /// </summary>
        /// <param name="request">The request containing entity information and object retrieval options.</param>
        /// <param name="customData">Optional custom data to associate with the request.</param>
        /// <param name="extraHeaders">Optional extra headers to include in the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the get objects response.</returns>
        Task<PlayFabResult<GetObjectsResponse>> GetObjectsAsync(GetObjectsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Returns URLs that may be used to upload the files for a profile for a limited length of time.
        /// </summary>
        /// <param name="request">The request containing file names and entity information.</param>
        /// <param name="customData">Optional custom data to associate with the request.</param>
        /// <param name="extraHeaders">Optional extra headers to include in the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the initiate file uploads response.</returns>
        Task<PlayFabResult<InitiateFileUploadsResponse>> InitiateFileUploadsAsync(InitiateFileUploadsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Sets JSON objects on the requested entity profile.
        /// </summary>
        /// <param name="request">The request containing objects to set and entity information.</param>
        /// <param name="customData">Optional custom data to associate with the request.</param>
        /// <param name="extraHeaders">Optional extra headers to include in the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the set objects response.</returns>
        Task<PlayFabResult<SetObjectsResponse>> SetObjectsAsync(SetObjectsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
    }
}
