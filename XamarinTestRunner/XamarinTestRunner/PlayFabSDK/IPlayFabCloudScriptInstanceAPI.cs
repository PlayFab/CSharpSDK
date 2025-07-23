#if !DISABLE_PLAYFABENTITY_API

using PlayFab.CloudScriptModels;
using PlayFab.Internal;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayFab
{
    /// <summary>
    /// API methods for executing CloudScript using an Entity Profile
    /// </summary>
    public interface IPlayFabCloudScriptInstanceAPI
    {
        /// <summary>
        /// Cloud Script is one of PlayFab's most versatile features. It allows client code to request execution of any kind of
        /// custom server-side functionality you can implement, and it can be used in conjunction with virtually anything.
        /// </summary>
        Task<PlayFabResult<ExecuteCloudScriptResult>> ExecuteEntityCloudScriptAsync(
            ExecuteEntityCloudScriptRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Cloud Script is one of PlayFab's most versatile features. It allows client code to request execution of any kind of
        /// custom server-side functionality you can implement, and it can be used in conjunction with virtually anything.
        /// </summary>
        Task<PlayFabResult<ExecuteFunctionResult>> ExecuteFunctionAsync(
            ExecuteFunctionRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets registered Azure Functions for a given title id and function name.
        /// </summary>
        Task<PlayFabResult<GetFunctionResult>> GetFunctionAsync(
            GetFunctionRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists all currently registered Event Hub triggered Azure Functions for a given title.
        /// </summary>
        Task<PlayFabResult<ListEventHubFunctionsResult>> ListEventHubFunctionsAsync(
            ListFunctionsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists all currently registered Azure Functions for a given title.
        /// </summary>
        Task<PlayFabResult<ListFunctionsResult>> ListFunctionsAsync(
            ListFunctionsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists all currently registered HTTP triggered Azure Functions for a given title.
        /// </summary>
        Task<PlayFabResult<ListHttpFunctionsResult>> ListHttpFunctionsAsync(
            ListFunctionsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists all currently registered Queue triggered Azure Functions for a given title.
        /// </summary>
        Task<PlayFabResult<ListQueuedFunctionsResult>> ListQueuedFunctionsAsync(
            ListFunctionsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Generate an entity PlayStream event for the provided function result.
        /// </summary>
        Task<PlayFabResult<EmptyResult>> PostFunctionResultForEntityTriggeredActionAsync(
            PostFunctionResultForEntityTriggeredActionRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Generate an entity PlayStream event for the provided function result.
        /// </summary>
        Task<PlayFabResult<EmptyResult>> PostFunctionResultForFunctionExecutionAsync(
            PostFunctionResultForFunctionExecutionRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Generate a player PlayStream event for the provided function result.
        /// </summary>
        Task<PlayFabResult<EmptyResult>> PostFunctionResultForPlayerTriggeredActionAsync(
            PostFunctionResultForPlayerTriggeredActionRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Generate a PlayStream event for the provided function result.
        /// </summary>
        Task<PlayFabResult<EmptyResult>> PostFunctionResultForScheduledTaskAsync(
            PostFunctionResultForScheduledTaskRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Registers an event hub triggered Azure Function with a title.
        /// </summary>
        Task<PlayFabResult<EmptyResult>> RegisterEventHubFunctionAsync(
            RegisterEventHubFunctionRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Registers an HTTP triggered Azure function with a title.
        /// </summary>
        Task<PlayFabResult<EmptyResult>> RegisterHttpFunctionAsync(
            RegisterHttpFunctionRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Registers a queue triggered Azure Function with a title.
        /// </summary>
        Task<PlayFabResult<EmptyResult>> RegisterQueuedFunctionAsync(
            RegisterQueuedFunctionRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unregisters an Azure Function with a title.
        /// </summary>
        Task<PlayFabResult<EmptyResult>> UnregisterFunctionAsync(
            UnregisterFunctionRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);
    }
}
#endif
