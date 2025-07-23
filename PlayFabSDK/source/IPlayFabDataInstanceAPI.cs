#if !DISABLE_PLAYFABENTITY_API

using PlayFab.DataModels;
using PlayFab.Internal;
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
    public interface IPlayFabDataInstanceAPI
    {
        /// <summary>
        /// Abort pending file uploads to an entity's profile.
        /// </summary>
        Task<PlayFabResult<AbortFileUploadsResponse>> AbortFileUploadsAsync(
            AbortFileUploadsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Delete files on an entity's profile.
        /// </summary>
        Task<PlayFabResult<DeleteFilesResponse>> DeleteFilesAsync(
            DeleteFilesRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Finalize file uploads to an entity's profile.
        /// </summary>
        Task<PlayFabResult<FinalizeFileUploadsResponse>> FinalizeFileUploadsAsync(
            FinalizeFileUploadsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves file metadata from an entity's profile.
        /// </summary>
        Task<PlayFabResult<GetFilesResponse>> GetFilesAsync(
            GetFilesRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves objects from an entity's profile.
        /// </summary>
        Task<PlayFabResult<GetObjectsResponse>> GetObjectsAsync(
            GetObjectsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Initiates file uploads to an entity's profile.
        /// </summary>
        Task<PlayFabResult<InitiateFileUploadsResponse>> InitiateFileUploadsAsync(
            InitiateFileUploadsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Sets objects on an entity's profile.
        /// </summary>
        Task<PlayFabResult<SetObjectsResponse>> SetObjectsAsync(
            SetObjectsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);
    }
}
#endif
