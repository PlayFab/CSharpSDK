using PlayFab.AuthenticationModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayFab
{
    /// <summary>
    /// Interface for PlayFab Authentication Instance API.
    /// </summary>
    public interface IPlayFabAuthenticationInstanceAPI
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
        /// Authenticates a game server using a custom ID and returns an entity token.
        /// </summary>
        /// <param name="request">The request containing the custom ID and optional custom tags.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers to include in the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the authentication result.</returns>
        Task<PlayFabResult<AuthenticateCustomIdResult>> AuthenticateGameServerWithCustomIdAsync(
            AuthenticateCustomIdRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null
        );

        /// <summary>
        /// Deletes a game server entity.
        /// </summary>
        /// <param name="request">The request containing the entity to delete and optional custom tags.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers to include in the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an empty response.</returns>
        Task<PlayFabResult<EmptyResponse>> DeleteAsync(
            DeleteRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null
        );

        /// <summary>
        /// Retrieves an entity token for the specified entity or the currently logged in entity.
        /// </summary>
        /// <param name="request">The request containing the entity and optional custom tags.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers to include in the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the entity token response.</returns>
        Task<PlayFabResult<GetEntityTokenResponse>> GetEntityTokenAsync(
            GetEntityTokenRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null
        );

        /// <summary>
        /// Validates that the provided entity token has not expired or been revoked.
        /// </summary>
        /// <param name="request">The request containing the entity token and optional custom tags.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers to include in the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the validation response.</returns>
        Task<PlayFabResult<ValidateEntityTokenResponse>> ValidateEntityTokenAsync(
            ValidateEntityTokenRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null
        );
    }
}
