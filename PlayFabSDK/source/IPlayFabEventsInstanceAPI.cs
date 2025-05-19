using PlayFab.EventsModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayFab
{
    public interface IPlayFabEventsInstanceAPI
    {
        bool IsEntityLoggedIn();
        void ForgetAllCredentials();
        Task<PlayFabResult<CreateTelemetryKeyResponse>> CreateTelemetryKeyAsync(CreateTelemetryKeyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<DeleteDataConnectionResponse>> DeleteDataConnectionAsync(DeleteDataConnectionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<DeleteTelemetryKeyResponse>> DeleteTelemetryKeyAsync(DeleteTelemetryKeyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<GetDataConnectionResponse>> GetDataConnectionAsync(GetDataConnectionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<GetTelemetryKeyResponse>> GetTelemetryKeyAsync(GetTelemetryKeyRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<ListDataConnectionsResponse>> ListDataConnectionsAsync(ListDataConnectionsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<ListTelemetryKeysResponse>> ListTelemetryKeysAsync(ListTelemetryKeysRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<SetDataConnectionResponse>> SetDataConnectionAsync(SetDataConnectionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<SetDataConnectionActiveResponse>> SetDataConnectionActiveAsync(SetDataConnectionActiveRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<SetTelemetryKeyActiveResponse>> SetTelemetryKeyActiveAsync(SetTelemetryKeyActiveRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<WriteEventsResponse>> WriteEventsAsync(WriteEventsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<WriteEventsResponse>> WriteTelemetryEventsAsync(WriteEventsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<WriteEventsResponse>> WriteTelemetryEventsAsync(WriteEventsRequest request, string telemetryKey, object customData = null, Dictionary<string, string> extraHeaders = null);
    }
}
