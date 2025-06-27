#if !DISABLE_PLAYFABENTITY_API

using PlayFab.AddonModels;
using PlayFab.Internal;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayFab
{
    /// <summary>
    /// APIs for managing addons.
    /// </summary>
    public interface IPlayFabAddonInstanceAPI
    {
        /// <summary>
        /// Creates the Apple addon on a title, or updates it if it already exists.
        /// </summary>
        Task<PlayFabResult<CreateOrUpdateAppleResponse>> CreateOrUpdateAppleAsync(
            CreateOrUpdateAppleRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Creates the Facebook addon on a title, or updates it if it already exists.
        /// </summary>
        Task<PlayFabResult<CreateOrUpdateFacebookResponse>> CreateOrUpdateFacebookAsync(
            CreateOrUpdateFacebookRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Creates the Facebook Instant Games addon on a title, or updates it if it already exists.
        /// </summary>
        Task<PlayFabResult<CreateOrUpdateFacebookInstantGamesResponse>> CreateOrUpdateFacebookInstantGamesAsync(
            CreateOrUpdateFacebookInstantGamesRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Creates the Google addon on a title, or updates it if it already exists.
        /// </summary>
        Task<PlayFabResult<CreateOrUpdateGoogleResponse>> CreateOrUpdateGoogleAsync(
            CreateOrUpdateGoogleRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Creates the Kongregate addon on a title, or updates it if it already exists.
        /// </summary>
        Task<PlayFabResult<CreateOrUpdateKongregateResponse>> CreateOrUpdateKongregateAsync(
            CreateOrUpdateKongregateRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Creates the Nintendo addon on a title, or updates it if it already exists.
        /// </summary>
        Task<PlayFabResult<CreateOrUpdateNintendoResponse>> CreateOrUpdateNintendoAsync(
            CreateOrUpdateNintendoRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Creates the PSN addon on a title, or updates it if it already exists.
        /// </summary>
        Task<PlayFabResult<CreateOrUpdatePSNResponse>> CreateOrUpdatePSNAsync(
            CreateOrUpdatePSNRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Creates the Steam addon on a title, or updates it if it already exists.
        /// </summary>
        Task<PlayFabResult<CreateOrUpdateSteamResponse>> CreateOrUpdateSteamAsync(
            CreateOrUpdateSteamRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Creates the ToxMod addon on a title, or updates it if it already exists.
        /// </summary>
        Task<PlayFabResult<CreateOrUpdateToxModResponse>> CreateOrUpdateToxModAsync(
            CreateOrUpdateToxModRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Creates the Twitch addon on a title, or updates it if it already exists.
        /// </summary>
        Task<PlayFabResult<CreateOrUpdateTwitchResponse>> CreateOrUpdateTwitchAsync(
            CreateOrUpdateTwitchRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes the Apple addon on a title.
        /// </summary>
        Task<PlayFabResult<DeleteAppleResponse>> DeleteAppleAsync(
            DeleteAppleRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes the Facebook addon on a title.
        /// </summary>
        Task<PlayFabResult<DeleteFacebookResponse>> DeleteFacebookAsync(
            DeleteFacebookRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes the Facebook addon on a title.
        /// </summary>
        Task<PlayFabResult<DeleteFacebookInstantGamesResponse>> DeleteFacebookInstantGamesAsync(
            DeleteFacebookInstantGamesRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes the Google addon on a title.
        /// </summary>
        Task<PlayFabResult<DeleteGoogleResponse>> DeleteGoogleAsync(
            DeleteGoogleRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes the Kongregate addon on a title.
        /// </summary>
        Task<PlayFabResult<DeleteKongregateResponse>> DeleteKongregateAsync(
            DeleteKongregateRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes the Nintendo addon on a title.
        /// </summary>
        Task<PlayFabResult<DeleteNintendoResponse>> DeleteNintendoAsync(
            DeleteNintendoRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes the PSN addon on a title.
        /// </summary>
        Task<PlayFabResult<DeletePSNResponse>> DeletePSNAsync(
            DeletePSNRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes the Steam addon on a title.
        /// </summary>
        Task<PlayFabResult<DeleteSteamResponse>> DeleteSteamAsync(
            DeleteSteamRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes the ToxMod addon on a title.
        /// </summary>
        Task<PlayFabResult<DeleteToxModResponse>> DeleteToxModAsync(
            DeleteToxModRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes the Twitch addon on a title.
        /// </summary>
        Task<PlayFabResult<DeleteTwitchResponse>> DeleteTwitchAsync(
            DeleteTwitchRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets information of the Apple addon on a title, omits secrets.
        /// </summary>
        Task<PlayFabResult<GetAppleResponse>> GetAppleAsync(
            GetAppleRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets information of the Facebook addon on a title, omits secrets.
        /// </summary>
        Task<PlayFabResult<GetFacebookResponse>> GetFacebookAsync(
            GetFacebookRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets information of the Facebook Instant Games addon on a title, omits secrets.
        /// </summary>
        Task<PlayFabResult<GetFacebookInstantGamesResponse>> GetFacebookInstantGamesAsync(
            GetFacebookInstantGamesRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets information of the Google addon on a title, omits secrets.
        /// </summary>
        Task<PlayFabResult<GetGoogleResponse>> GetGoogleAsync(
            GetGoogleRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets information of the Kongregate addon on a title, omits secrets.
        /// </summary>
        Task<PlayFabResult<GetKongregateResponse>> GetKongregateAsync(
            GetKongregateRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets information of the Nintendo addon on a title, omits secrets.
        /// </summary>
        Task<PlayFabResult<GetNintendoResponse>> GetNintendoAsync(
            GetNintendoRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets information of the PSN addon on a title, omits secrets.
        /// </summary>
        Task<PlayFabResult<GetPSNResponse>> GetPSNAsync(
            GetPSNRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets information of the Steam addon on a title, omits secrets.
        /// </summary>
        Task<PlayFabResult<GetSteamResponse>> GetSteamAsync(
            GetSteamRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets information of the ToxMod addon on a title, omits secrets.
        /// </summary>
        Task<PlayFabResult<GetToxModResponse>> GetToxModAsync(
            GetToxModRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets information of the Twitch addon on a title, omits secrets.
        /// </summary>
        Task<PlayFabResult<GetTwitchResponse>> GetTwitchAsync(
            GetTwitchRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);
    }
}
#endif
