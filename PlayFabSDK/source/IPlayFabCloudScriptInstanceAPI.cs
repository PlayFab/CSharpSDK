using PlayFab.CloudScriptModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayFab
{
    public interface IPlayFabCloudScriptInstanceAPI
    {
        bool IsEntityLoggedIn();
        void ForgetAllCredentials();
        Task<PlayFabResult<ExecuteCloudScriptResult>> ExecuteEntityCloudScriptAsync(ExecuteEntityCloudScriptRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<ExecuteFunctionResult>> ExecuteFunctionAsync(ExecuteFunctionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<GetFunctionResult>> GetFunctionAsync(GetFunctionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<ListEventHubFunctionsResult>> ListEventHubFunctionsAsync(ListFunctionsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<ListFunctionsResult>> ListFunctionsAsync(ListFunctionsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<ListHttpFunctionsResult>> ListHttpFunctionsAsync(ListFunctionsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<ListQueuedFunctionsResult>> ListQueuedFunctionsAsync(ListFunctionsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<EmptyResult>> PostFunctionResultForEntityTriggeredActionAsync(PostFunctionResultForEntityTriggeredActionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<EmptyResult>> PostFunctionResultForFunctionExecutionAsync(PostFunctionResultForFunctionExecutionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<EmptyResult>> PostFunctionResultForPlayerTriggeredActionAsync(PostFunctionResultForPlayerTriggeredActionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<EmptyResult>> PostFunctionResultForScheduledTaskAsync(PostFunctionResultForScheduledTaskRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<EmptyResult>> RegisterEventHubFunctionAsync(RegisterEventHubFunctionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<EmptyResult>> RegisterHttpFunctionAsync(RegisterHttpFunctionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<EmptyResult>> RegisterQueuedFunctionAsync(RegisterQueuedFunctionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<EmptyResult>> UnregisterFunctionAsync(UnregisterFunctionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
    }
}
