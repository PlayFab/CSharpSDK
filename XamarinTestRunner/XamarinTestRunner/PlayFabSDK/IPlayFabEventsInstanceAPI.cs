#if !DISABLE_PLAYFABENTITY_API

using PlayFab.EventsModels;
using PlayFab.Internal;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayFab
{
    /// <summary>
    /// Write custom PlayStream and Telemetry events for any PlayFab entity. Telemetry events can be used for analytic,
    /// reporting, or debugging. PlayStream events can do all of that and also trigger custom actions in near real-time.
    /// </summary>
    public interface IPlayFabEventsInstanceAPI
    {
        /// <summary>
        /// Creates a new telemetry key for the title.
        /// </summary>
        Task<PlayFabResult<CreateTelemetryKeyResponse>> CreateTelemetryKeyAsync(
            CreateTelemetryKeyRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes a Data Connection from a title.
        /// </summary>
        Task<PlayFabResult<DeleteDataConnectionResponse>> DeleteDataConnectionAsync(
            DeleteDataConnectionRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes a telemetry key configured for the title.
        /// </summary>
        Task<PlayFabResult<DeleteTelemetryKeyResponse>> DeleteTelemetryKeyAsync(
            DeleteTelemetryKeyRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves a single Data Connection associated with a title.
        /// </summary>
        Task<PlayFabResult<GetDataConnectionResponse>> GetDataConnectionAsync(
            GetDataConnectionRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets information about a telemetry key configured for the title.
        /// </summary>
        Task<PlayFabResult<GetTelemetryKeyResponse>> GetTelemetryKeyAsync(
            GetTelemetryKeyRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves the list of Data Connections associated with a title.
        /// </summary>
        Task<PlayFabResult<ListDataConnectionsResponse>> ListDataConnectionsAsync(
            ListDataConnectionsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists all telemetry keys configured for the title.
        /// </summary>
        Task<PlayFabResult<ListTelemetryKeysResponse>> ListTelemetryKeysAsync(
            ListTelemetryKeysRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Creates or updates a Data Connection on a title.
        /// </summary>
        Task<PlayFabResult<SetDataConnectionResponse>> SetDataConnectionAsync(
            SetDataConnectionRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Sets a Data Connection for the title to either the active or deactivated state.
        /// </summary>
        Task<PlayFabResult<SetDataConnectionActiveResponse>> SetDataConnectionActiveAsync(
            SetDataConnectionActiveRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Sets a telemetry key to the active or deactivated state.
        /// </summary>
        Task<PlayFabResult<SetTelemetryKeyActiveResponse>> SetTelemetryKeyActiveAsync(
            SetTelemetryKeyActiveRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Write batches of entity based events to PlayStream. The namespace of the Event must be 'custom' or start with 'custom.'.
        /// </summary>
        Task<PlayFabResult<WriteEventsResponse>> WriteEventsAsync(
            WriteEventsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Write batches of entity based events to as Telemetry events (bypass PlayStream). The namespace must be 'custom' or start
        /// with 'custom.'
        /// </summary>
        Task<PlayFabResult<WriteEventsResponse>> WriteTelemetryEventsAsync(
            WriteEventsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);
    }
}
#endif
