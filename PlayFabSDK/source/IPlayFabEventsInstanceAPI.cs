using PlayFab.EventsModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayFab
{
    /// <summary>
    /// Interface for PlayFab Events Instance API, providing methods to manage telemetry keys, data connections, and event writing.
    /// </summary>
    public interface IPlayFabEventsInstanceAPI
    {
        /// <summary>
        /// Checks if an entity is currently logged in.
        /// </summary>
        /// <returns>True if an entity is logged in; otherwise, false.</returns>
        bool IsEntityLoggedIn();

        /// <summary>
        /// Forgets all stored credentials for the current entity.
        /// </summary>
        void ForgetAllCredentials();

        /// <summary>
        /// Creates a new telemetry key for the title.
        /// </summary>
        /// <param name="request">The request containing telemetry key creation details.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response with the new telemetry key details.</returns>
        Task<PlayFabResult<CreateTelemetryKeyResponse>> CreateTelemetryKeyAsync(CreateTelemetryKeyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes a data connection by name.
        /// </summary>
        /// <param name="request">The request containing the name of the data connection to delete.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response indicating if the connection was deleted.</returns>
        Task<PlayFabResult<DeleteDataConnectionResponse>> DeleteDataConnectionAsync(DeleteDataConnectionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes a telemetry key by name.
        /// </summary>
        /// <param name="request">The request containing the name of the telemetry key to delete.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response indicating if the key was deleted.</returns>
        Task<PlayFabResult<DeleteTelemetryKeyResponse>> DeleteTelemetryKeyAsync(DeleteTelemetryKeyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves a data connection by name.
        /// </summary>
        /// <param name="request">The request containing the name of the data connection to retrieve.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response with the data connection details.</returns>
        Task<PlayFabResult<GetDataConnectionResponse>> GetDataConnectionAsync(GetDataConnectionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves a telemetry key by name.
        /// </summary>
        /// <param name="request">The request containing the name of the telemetry key to retrieve.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response with the telemetry key details.</returns>
        Task<PlayFabResult<GetTelemetryKeyResponse>> GetTelemetryKeyAsync(GetTelemetryKeyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists all data connections for the title.
        /// </summary>
        /// <param name="request">The request for listing data connections.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response with the list of data connections.</returns>
        Task<PlayFabResult<ListDataConnectionsResponse>> ListDataConnectionsAsync(ListDataConnectionsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists all telemetry keys for the title.
        /// </summary>
        /// <param name="request">The request for listing telemetry keys.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response with the list of telemetry keys.</returns>
        Task<PlayFabResult<ListTelemetryKeysResponse>> ListTelemetryKeysAsync(ListTelemetryKeysRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Sets or updates a data connection for the title.
        /// </summary>
        /// <param name="request">The request containing data connection settings.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response with the updated data connection details.</returns>
        Task<PlayFabResult<SetDataConnectionResponse>> SetDataConnectionAsync(SetDataConnectionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Sets the active state of a data connection.
        /// </summary>
        /// <param name="request">The request containing the data connection name and desired active state.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response with the updated data connection state.</returns>
        Task<PlayFabResult<SetDataConnectionActiveResponse>> SetDataConnectionActiveAsync(SetDataConnectionActiveRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Sets the active state of a telemetry key.
        /// </summary>
        /// <param name="request">The request containing the telemetry key name and desired active state.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response with the updated telemetry key state.</returns>
        Task<PlayFabResult<SetTelemetryKeyActiveResponse>> SetTelemetryKeyActiveAsync(SetTelemetryKeyActiveRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Writes a collection of events to PlayFab.
        /// </summary>
        /// <param name="request">The request containing the events to write.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response with event write results.</returns>
        Task<PlayFabResult<WriteEventsResponse>> WriteEventsAsync(WriteEventsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Writes a collection of telemetry events to PlayFab using the default telemetry key.
        /// </summary>
        /// <param name="request">The request containing the telemetry events to write.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response with telemetry event write results.</returns>
        Task<PlayFabResult<WriteEventsResponse>> WriteTelemetryEventsAsync(WriteEventsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Writes a collection of telemetry events to PlayFab using a specified telemetry key.
        /// </summary>
        /// <param name="request">The request containing the telemetry events to write.</param>
        /// <param name="telemetryKey">The telemetry key to use for writing events.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response with telemetry event write results.</returns>
        Task<PlayFabResult<WriteEventsResponse>> WriteTelemetryEventsAsync(WriteEventsRequest request, string telemetryKey, object customData = null, Dictionary<string, string> extraHeaders = null);
    }
}
