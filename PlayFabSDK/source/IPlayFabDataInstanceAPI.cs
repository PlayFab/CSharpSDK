using PlayFab.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayFab
{
    public interface IPlayFabDataInstanceAPI
    {
        bool IsEntityLoggedIn();
        void ForgetAllCredentials();
        Task<PlayFabResult<AbortFileUploadsResponse>> AbortFileUploadsAsync(AbortFileUploadsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<DeleteFilesResponse>> DeleteFilesAsync(DeleteFilesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<FinalizeFileUploadsResponse>> FinalizeFileUploadsAsync(FinalizeFileUploadsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<GetFilesResponse>> GetFilesAsync(GetFilesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<GetObjectsResponse>> GetObjectsAsync(GetObjectsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<InitiateFileUploadsResponse>> InitiateFileUploadsAsync(InitiateFileUploadsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<SetObjectsResponse>> SetObjectsAsync(SetObjectsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
    }
}
