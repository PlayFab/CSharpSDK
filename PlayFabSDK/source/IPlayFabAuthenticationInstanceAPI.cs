#if !DISABLE_PLAYFABENTITY_API

using PlayFab.AuthenticationModels;
using PlayFab.Internal;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayFab
{
    /// <summary>
    /// The Authentication APIs provide a convenient way to convert classic authentication responses into entity authentication
    /// models. These APIs will provide you with the entity authentication token needed for subsequent Entity API calls. The
    /// game_server API is designed to create uniquely identifiable game_server entities. The game_server Entity token can be
    /// used to call Matchmaking Lobby and Pubsub for server scenarios.
    /// </summary>
    public interface IPlayFabAuthenticationInstanceAPI
    {
        /// <summary>
        /// Create a game_server entity token and return a new or existing game_server entity.
        /// </summary>
        Task<PlayFabResult<AuthenticateCustomIdResult>> AuthenticateGameServerWithCustomIdAsync(
            AuthenticateCustomIdRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Delete a game_server entity.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> DeleteAsync(
            DeleteRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Method to exchange a legacy AuthenticationTicket or title SecretKey for an Entity Token or to refresh a still valid
        /// Entity Token.
        /// </summary>
        Task<PlayFabResult<GetEntityTokenResponse>> GetEntityTokenAsync(
            GetEntityTokenRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Method for a server to validate a client provided EntityToken. Only callable by the title entity.
        /// </summary>
        Task<PlayFabResult<ValidateEntityTokenResponse>> ValidateEntityTokenAsync(
            ValidateEntityTokenRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);
    }
}
#endif
