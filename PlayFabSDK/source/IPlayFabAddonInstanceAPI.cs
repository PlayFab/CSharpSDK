using PlayFab.AddonModels;
using PlayFab.Internal;
#pragma warning disable 0649
using System;
// This is required for the Obsolete Attribute flag
//  which is not always present in all API's
#pragma warning restore 0649
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayFab
{
    /// <summary>
    /// Interface for PlayFabAddonInstanceAPI, providing APIs for managing addons.
    /// </summary>
    public interface IPlayFabAddonInstanceAPI
    {
        /// <summary>
        /// Checks if an entity is currently logged in.
        /// </summary>
        bool IsEntityLoggedIn();
        /// <summary>
        /// Forgets all stored credentials for the current session.
        /// </summary>
        void ForgetAllCredentials();

        /// <summary>
        /// Creates or updates the Apple addon configuration for the specified entity.
        /// </summary>
        /// <param name="request">The request containing Apple addon configuration details.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response from the service.</returns>
        Task<PlayFabResult<CreateOrUpdateAppleResponse>> CreateOrUpdateAppleAsync(CreateOrUpdateAppleRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        /// <summary>
        /// Creates or updates the Facebook addon configuration for the specified entity.
        /// </summary>
        /// <param name="request">The request containing Facebook addon configuration details.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response from the service.</returns>
        Task<PlayFabResult<CreateOrUpdateFacebookResponse>> CreateOrUpdateFacebookAsync(CreateOrUpdateFacebookRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        /// <summary>
        /// Creates or updates the Facebook Instant Games addon configuration for the specified entity.
        /// </summary>
        /// <param name="request">The request containing Facebook Instant Games addon configuration details.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response from the service.</returns>
        Task<PlayFabResult<CreateOrUpdateFacebookInstantGamesResponse>> CreateOrUpdateFacebookInstantGamesAsync(CreateOrUpdateFacebookInstantGamesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        /// <summary>
        /// Creates or updates the Google addon configuration for the specified entity.
        /// </summary>
        /// <param name="request">The request containing Google addon configuration details.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response from the service.</returns>
        Task<PlayFabResult<CreateOrUpdateGoogleResponse>> CreateOrUpdateGoogleAsync(CreateOrUpdateGoogleRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        /// <summary>
        /// Creates or updates the Kongregate addon configuration for the specified entity.
        /// </summary>
        /// <param name="request">The request containing Kongregate addon configuration details.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response from the service.</returns>
        Task<PlayFabResult<CreateOrUpdateKongregateResponse>> CreateOrUpdateKongregateAsync(CreateOrUpdateKongregateRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        /// <summary>
        /// Creates or updates the Nintendo addon configuration for the specified entity.
        /// </summary>
        /// <param name="request">The request containing Nintendo addon configuration details.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response from the service.</returns>
        Task<PlayFabResult<CreateOrUpdateNintendoResponse>> CreateOrUpdateNintendoAsync(CreateOrUpdateNintendoRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        /// <summary>
        /// Creates or updates the PlayStation Network (PSN) addon configuration for the specified entity.
        /// </summary>
        /// <param name="request">The request containing PSN addon configuration details.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response from the service.</returns>
        Task<PlayFabResult<CreateOrUpdatePSNResponse>> CreateOrUpdatePSNAsync(CreateOrUpdatePSNRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        /// <summary>
        /// Creates or updates the Steam addon configuration for the specified entity.
        /// </summary>
        /// <param name="request">The request containing Steam addon configuration details.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response from the service.</returns>
        Task<PlayFabResult<CreateOrUpdateSteamResponse>> CreateOrUpdateSteamAsync(CreateOrUpdateSteamRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        /// <summary>
        /// Creates or updates the ToxMod addon configuration for the specified entity.
        /// </summary>
        /// <param name="request">The request containing ToxMod addon configuration details.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response from the service.</returns>
        Task<PlayFabResult<CreateOrUpdateToxModResponse>> CreateOrUpdateToxModAsync(CreateOrUpdateToxModRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        /// <summary>
        /// Creates or updates the Twitch addon configuration for the specified entity.
        /// </summary>
        /// <param name="request">The request containing Twitch addon configuration details.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response from the service.</returns>
        Task<PlayFabResult<CreateOrUpdateTwitchResponse>> CreateOrUpdateTwitchAsync(CreateOrUpdateTwitchRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes the Apple addon configuration for the specified entity.
        /// </summary>
        /// <param name="request">The request containing Apple addon deletion details.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response from the service.</returns>
        Task<PlayFabResult<DeleteAppleResponse>> DeleteAppleAsync(DeleteAppleRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        /// <summary>
        /// Deletes the Facebook addon configuration for the specified entity.
        /// </summary>
        /// <param name="request">The request containing Facebook addon deletion details.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response from the service.</returns>
        Task<PlayFabResult<DeleteFacebookResponse>> DeleteFacebookAsync(DeleteFacebookRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        /// <summary>
        /// Deletes the Facebook Instant Games addon configuration for the specified entity.
        /// </summary>
        /// <param name="request">The request containing Facebook Instant Games addon deletion details.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response from the service.</returns>
        Task<PlayFabResult<DeleteFacebookInstantGamesResponse>> DeleteFacebookInstantGamesAsync(DeleteFacebookInstantGamesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        /// <summary>
        /// Deletes the Google addon configuration for the specified entity.
        /// </summary>
        /// <param name="request">The request containing Google addon deletion details.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response from the service.</returns>
        Task<PlayFabResult<DeleteGoogleResponse>> DeleteGoogleAsync(DeleteGoogleRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        /// <summary>
        /// Deletes the Kongregate addon configuration for the specified entity.
        /// </summary>
        /// <param name="request">The request containing Kongregate addon deletion details.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response from the service.</returns>
        Task<PlayFabResult<DeleteKongregateResponse>> DeleteKongregateAsync(DeleteKongregateRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        /// <summary>
        /// Deletes the Nintendo addon configuration for the specified entity.
        /// </summary>
        /// <param name="request">The request containing Nintendo addon deletion details.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response from the service.</returns>
        Task<PlayFabResult<DeleteNintendoResponse>> DeleteNintendoAsync(DeleteNintendoRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        /// <summary>
        /// Deletes the PlayStation Network (PSN) addon configuration for the specified entity.
        /// </summary>
        /// <param name="request">The request containing PSN addon deletion details.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response from the service.</returns>
        Task<PlayFabResult<DeletePSNResponse>> DeletePSNAsync(DeletePSNRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        /// <summary>
        /// Deletes the Steam addon configuration for the specified entity.
        /// </summary>
        /// <param name="request">The request containing Steam addon deletion details.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response from the service.</returns>
        Task<PlayFabResult<DeleteSteamResponse>> DeleteSteamAsync(DeleteSteamRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        /// <summary>
        /// Deletes the ToxMod addon configuration for the specified entity.
        /// </summary>
        /// <param name="request">The request containing ToxMod addon deletion details.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response from the service.</returns>
        Task<PlayFabResult<DeleteToxModResponse>> DeleteToxModAsync(DeleteToxModRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        /// <summary>
        /// Deletes the Twitch addon configuration for the specified entity.
        /// </summary>
        /// <param name="request">The request containing Twitch addon deletion details.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response from the service.</returns>
        Task<PlayFabResult<DeleteTwitchResponse>> DeleteTwitchAsync(DeleteTwitchRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the Apple addon configuration for the specified entity.
        /// </summary>
        /// <param name="request">The request containing Apple addon retrieval details.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response from the service.</returns>
        Task<PlayFabResult<GetAppleResponse>> GetAppleAsync(GetAppleRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        /// <summary>
        /// Gets the Facebook addon configuration for the specified entity.
        /// </summary>
        /// <param name="request">The request containing Facebook addon retrieval details.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response from the service.</returns>
        Task<PlayFabResult<GetFacebookResponse>> GetFacebookAsync(GetFacebookRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        /// <summary>
        /// Gets the Facebook Instant Games addon configuration for the specified entity.
        /// </summary>
        /// <param name="request">The request containing Facebook Instant Games addon retrieval details.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response from the service.</returns>
        Task<PlayFabResult<GetFacebookInstantGamesResponse>> GetFacebookInstantGamesAsync(GetFacebookInstantGamesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        /// <summary>
        /// Gets the Google addon configuration for the specified entity.
        /// </summary>
        /// <param name="request">The request containing Google addon retrieval details.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response from the service.</returns>
        Task<PlayFabResult<GetGoogleResponse>> GetGoogleAsync(GetGoogleRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        /// <summary>
        /// Gets the Kongregate addon configuration for the specified entity.
        /// </summary>
        /// <param name="request">The request containing Kongregate addon retrieval details.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response from the service.</returns>
        Task<PlayFabResult<GetKongregateResponse>> GetKongregateAsync(GetKongregateRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        /// <summary>
        /// Gets the Nintendo addon configuration for the specified entity.
        /// </summary>
        /// <param name="request">The request containing Nintendo addon retrieval details.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response from the service.</returns>
        Task<PlayFabResult<GetNintendoResponse>> GetNintendoAsync(GetNintendoRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        /// <summary>
        /// Gets the PlayStation Network (PSN) addon configuration for the specified entity.
        /// </summary>
        /// <param name="request">The request containing PSN addon retrieval details.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response from the service.</returns>
        Task<PlayFabResult<GetPSNResponse>> GetPSNAsync(GetPSNRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        /// <summary>
        /// Gets the Steam addon configuration for the specified entity.
        /// </summary>
        /// <param name="request">The request containing Steam addon retrieval details.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response from the service.</returns>
        Task<PlayFabResult<GetSteamResponse>> GetSteamAsync(GetSteamRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        /// <summary>
        /// Gets the ToxMod addon configuration for the specified entity.
        /// </summary>
        /// <param name="request">The request containing ToxMod addon retrieval details.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response from the service.</returns>
        Task<PlayFabResult<GetToxModResponse>> GetToxModAsync(GetToxModRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        /// <summary>
        /// Gets the Twitch addon configuration for the specified entity.
        /// </summary>
        /// <param name="request">The request containing Twitch addon retrieval details.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response from the service.</returns>
        Task<PlayFabResult<GetTwitchResponse>> GetTwitchAsync(GetTwitchRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
    }
}
