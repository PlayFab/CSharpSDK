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
        bool IsEntityLoggedIn();
        void ForgetAllCredentials();

        Task<PlayFabResult<CreateOrUpdateAppleResponse>> CreateOrUpdateAppleAsync(CreateOrUpdateAppleRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<CreateOrUpdateFacebookResponse>> CreateOrUpdateFacebookAsync(CreateOrUpdateFacebookRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<CreateOrUpdateFacebookInstantGamesResponse>> CreateOrUpdateFacebookInstantGamesAsync(CreateOrUpdateFacebookInstantGamesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<CreateOrUpdateGoogleResponse>> CreateOrUpdateGoogleAsync(CreateOrUpdateGoogleRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<CreateOrUpdateKongregateResponse>> CreateOrUpdateKongregateAsync(CreateOrUpdateKongregateRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<CreateOrUpdateNintendoResponse>> CreateOrUpdateNintendoAsync(CreateOrUpdateNintendoRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<CreateOrUpdatePSNResponse>> CreateOrUpdatePSNAsync(CreateOrUpdatePSNRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<CreateOrUpdateSteamResponse>> CreateOrUpdateSteamAsync(CreateOrUpdateSteamRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<CreateOrUpdateToxModResponse>> CreateOrUpdateToxModAsync(CreateOrUpdateToxModRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<CreateOrUpdateTwitchResponse>> CreateOrUpdateTwitchAsync(CreateOrUpdateTwitchRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        Task<PlayFabResult<DeleteAppleResponse>> DeleteAppleAsync(DeleteAppleRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<DeleteFacebookResponse>> DeleteFacebookAsync(DeleteFacebookRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<DeleteFacebookInstantGamesResponse>> DeleteFacebookInstantGamesAsync(DeleteFacebookInstantGamesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<DeleteGoogleResponse>> DeleteGoogleAsync(DeleteGoogleRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<DeleteKongregateResponse>> DeleteKongregateAsync(DeleteKongregateRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<DeleteNintendoResponse>> DeleteNintendoAsync(DeleteNintendoRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<DeletePSNResponse>> DeletePSNAsync(DeletePSNRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<DeleteSteamResponse>> DeleteSteamAsync(DeleteSteamRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<DeleteToxModResponse>> DeleteToxModAsync(DeleteToxModRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<DeleteTwitchResponse>> DeleteTwitchAsync(DeleteTwitchRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        Task<PlayFabResult<GetAppleResponse>> GetAppleAsync(GetAppleRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<GetFacebookResponse>> GetFacebookAsync(GetFacebookRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<GetFacebookInstantGamesResponse>> GetFacebookInstantGamesAsync(GetFacebookInstantGamesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<GetGoogleResponse>> GetGoogleAsync(GetGoogleRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<GetKongregateResponse>> GetKongregateAsync(GetKongregateRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<GetNintendoResponse>> GetNintendoAsync(GetNintendoRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<GetPSNResponse>> GetPSNAsync(GetPSNRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<GetSteamResponse>> GetSteamAsync(GetSteamRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<GetToxModResponse>> GetToxModAsync(GetToxModRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<GetTwitchResponse>> GetTwitchAsync(GetTwitchRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
    }
}
