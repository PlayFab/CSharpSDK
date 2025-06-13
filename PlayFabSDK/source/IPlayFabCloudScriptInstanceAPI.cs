using PlayFab.CloudScriptModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayFab
{
    /// <summary>
    /// Interface for PlayFab CloudScript Instance API, providing methods to execute and manage CloudScript and Azure Functions.
    /// </summary>
    public interface IPlayFabCloudScriptInstanceAPI
    {
        /// <summary>
        /// Checks if the entity is currently logged in.
        /// </summary>
        /// <returns>True if the entity is logged in; otherwise, false.</returns>
        bool IsEntityLoggedIn();

        /// <summary>
        /// Forgets all stored credentials for the current entity.
        /// </summary>
        void ForgetAllCredentials();

        /// <summary>
        /// Executes a CloudScript function with the entity profile defined in the request.
        /// </summary>
        /// <param name="request">The request parameters for executing the CloudScript function.</param>
        /// <param name="customData">Optional custom data to associate with the request.</param>
        /// <param name="extraHeaders">Optional extra headers to include in the request.</param>
        /// <returns>A task that represents the asynchronous operation, containing the result of the CloudScript execution.</returns>
        Task<PlayFabResult<ExecuteCloudScriptResult>> ExecuteEntityCloudScriptAsync(ExecuteEntityCloudScriptRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Executes an Azure Function with the profile of the entity defined in the request.
        /// </summary>
        /// <param name="request">The request parameters for executing the Azure Function.</param>
        /// <param name="customData">Optional custom data to associate with the request.</param>
        /// <param name="extraHeaders">Optional extra headers to include in the request.</param>
        /// <returns>A task that represents the asynchronous operation, containing the result of the function execution.</returns>
        Task<PlayFabResult<ExecuteFunctionResult>> ExecuteFunctionAsync(ExecuteFunctionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves information about a registered function.
        /// </summary>
        /// <param name="request">The request parameters for retrieving the function.</param>
        /// <param name="customData">Optional custom data to associate with the request.</param>
        /// <param name="extraHeaders">Optional extra headers to include in the request.</param>
        /// <returns>A task that represents the asynchronous operation, containing the function information.</returns>
        Task<PlayFabResult<GetFunctionResult>> GetFunctionAsync(GetFunctionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists all EventHub triggered functions currently registered for the title.
        /// </summary>
        /// <param name="request">The request parameters for listing EventHub functions.</param>
        /// <param name="customData">Optional custom data to associate with the request.</param>
        /// <param name="extraHeaders">Optional extra headers to include in the request.</param>
        /// <returns>A task that represents the asynchronous operation, containing the list of EventHub functions.</returns>
        Task<PlayFabResult<ListEventHubFunctionsResult>> ListEventHubFunctionsAsync(ListFunctionsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists all functions currently registered for the title.
        /// </summary>
        /// <param name="request">The request parameters for listing functions.</param>
        /// <param name="customData">Optional custom data to associate with the request.</param>
        /// <param name="extraHeaders">Optional extra headers to include in the request.</param>
        /// <returns>A task that represents the asynchronous operation, containing the list of functions.</returns>
        Task<PlayFabResult<ListFunctionsResult>> ListFunctionsAsync(ListFunctionsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists all HTTP triggered functions currently registered for the title.
        /// </summary>
        /// <param name="request">The request parameters for listing HTTP functions.</param>
        /// <param name="customData">Optional custom data to associate with the request.</param>
        /// <param name="extraHeaders">Optional extra headers to include in the request.</param>
        /// <returns>A task that represents the asynchronous operation, containing the list of HTTP functions.</returns>
        Task<PlayFabResult<ListHttpFunctionsResult>> ListHttpFunctionsAsync(ListFunctionsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists all Queue triggered functions currently registered for the title.
        /// </summary>
        /// <param name="request">The request parameters for listing queued functions.</param>
        /// <param name="customData">Optional custom data to associate with the request.</param>
        /// <param name="extraHeaders">Optional extra headers to include in the request.</param>
        /// <returns>A task that represents the asynchronous operation, containing the list of queued functions.</returns>
        Task<PlayFabResult<ListQueuedFunctionsResult>> ListQueuedFunctionsAsync(ListFunctionsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Posts the result of a function execution for an entity triggered action.
        /// </summary>
        /// <param name="request">The request parameters containing the function result.</param>
        /// <param name="customData">Optional custom data to associate with the request.</param>
        /// <param name="extraHeaders">Optional extra headers to include in the request.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task<PlayFabResult<EmptyResult>> PostFunctionResultForEntityTriggeredActionAsync(PostFunctionResultForEntityTriggeredActionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Posts the result of a function execution for a function execution event.
        /// </summary>
        /// <param name="request">The request parameters containing the function result.</param>
        /// <param name="customData">Optional custom data to associate with the request.</param>
        /// <param name="extraHeaders">Optional extra headers to include in the request.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task<PlayFabResult<EmptyResult>> PostFunctionResultForFunctionExecutionAsync(PostFunctionResultForFunctionExecutionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Posts the result of a function execution for a player triggered action.
        /// </summary>
        /// <param name="request">The request parameters containing the function result.</param>
        /// <param name="customData">Optional custom data to associate with the request.</param>
        /// <param name="extraHeaders">Optional extra headers to include in the request.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task<PlayFabResult<EmptyResult>> PostFunctionResultForPlayerTriggeredActionAsync(PostFunctionResultForPlayerTriggeredActionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Posts the result of a function execution for a scheduled task.
        /// </summary>
        /// <param name="request">The request parameters containing the function result.</param>
        /// <param name="customData">Optional custom data to associate with the request.</param>
        /// <param name="extraHeaders">Optional extra headers to include in the request.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task<PlayFabResult<EmptyResult>> PostFunctionResultForScheduledTaskAsync(PostFunctionResultForScheduledTaskRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Registers an EventHub triggered function for the title.
        /// </summary>
        /// <param name="request">The request parameters for registering the EventHub function.</param>
        /// <param name="customData">Optional custom data to associate with the request.</param>
        /// <param name="extraHeaders">Optional extra headers to include in the request.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task<PlayFabResult<EmptyResult>> RegisterEventHubFunctionAsync(RegisterEventHubFunctionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Registers an HTTP triggered function for the title.
        /// </summary>
        /// <param name="request">The request parameters for registering the HTTP function.</param>
        /// <param name="customData">Optional custom data to associate with the request.</param>
        /// <param name="extraHeaders">Optional extra headers to include in the request.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task<PlayFabResult<EmptyResult>> RegisterHttpFunctionAsync(RegisterHttpFunctionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Registers a Queue triggered function for the title.
        /// </summary>
        /// <param name="request">The request parameters for registering the queued function.</param>
        /// <param name="customData">Optional custom data to associate with the request.</param>
        /// <param name="extraHeaders">Optional extra headers to include in the request.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task<PlayFabResult<EmptyResult>> RegisterQueuedFunctionAsync(RegisterQueuedFunctionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unregisters a function from the title.
        /// </summary>
        /// <param name="request">The request parameters for unregistering the function.</param>
        /// <param name="customData">Optional custom data to associate with the request.</param>
        /// <param name="extraHeaders">Optional extra headers to include in the request.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task<PlayFabResult<EmptyResult>> UnregisterFunctionAsync(UnregisterFunctionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
    }
}
