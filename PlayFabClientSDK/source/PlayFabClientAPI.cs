using System;
using System.IO;
using System.Threading.Tasks;

using Newtonsoft.Json;

using PlayFab.Internal;
using PlayFab.ClientModels;


namespace PlayFab
{

	
	/// <summary>
	/// APIs which provide the full range of PlayFab features available to the client - authentication, account and data management, inventory, friends, matchmaking, reporting, and platform-specific functionality
	/// </summary>
    public class PlayFabClientAPI
    {
		
		
		/// <summary>
		/// Signs the user in using the Android device identifier, returning a session identifier that can subsequently be used for API calls which require an authenticated user
		/// </summary>
        public static async Task<PlayFabResult<LoginResult>> LoginWithAndroidDeviceIDAsync(LoginWithAndroidDeviceIDRequest request)
        {
            request.TitleId = PlayFabSettings.TitleId ?? request.TitleId;
			if(request.TitleId == null) throw new Exception ("Must be have PlayFabSettings.TitleId set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Client/LoginWithAndroidDeviceID", request, null, null);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<LoginResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<LoginResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			LoginResult result = resultData.data;
			AuthKey = result.SessionTicket ?? AuthKey;

			
            return new PlayFabResult<LoginResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Signs the user in using a Facebook access token, returning a session identifier that can subsequently be used for API calls which require an authenticated user
		/// </summary>
        public static async Task<PlayFabResult<LoginResult>> LoginWithFacebookAsync(LoginWithFacebookRequest request)
        {
            request.TitleId = PlayFabSettings.TitleId ?? request.TitleId;
			if(request.TitleId == null) throw new Exception ("Must be have PlayFabSettings.TitleId set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Client/LoginWithFacebook", request, null, null);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<LoginResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<LoginResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			LoginResult result = resultData.data;
			AuthKey = result.SessionTicket ?? AuthKey;

			
            return new PlayFabResult<LoginResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Signs the user in using a Google account access token, returning a session identifier that can subsequently be used for API calls which require an authenticated user
		/// </summary>
        public static async Task<PlayFabResult<LoginResult>> LoginWithGoogleAccountAsync(LoginWithGoogleAccountRequest request)
        {
            request.TitleId = PlayFabSettings.TitleId ?? request.TitleId;
			if(request.TitleId == null) throw new Exception ("Must be have PlayFabSettings.TitleId set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Client/LoginWithGoogleAccount", request, null, null);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<LoginResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<LoginResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			LoginResult result = resultData.data;
			AuthKey = result.SessionTicket ?? AuthKey;

			
            return new PlayFabResult<LoginResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Signs the user in using the vendor-specific iOS device identifier, returning a session identifier that can subsequently be used for API calls which require an authenticated user
		/// </summary>
        public static async Task<PlayFabResult<LoginResult>> LoginWithIOSDeviceIDAsync(LoginWithIOSDeviceIDRequest request)
        {
            request.TitleId = PlayFabSettings.TitleId ?? request.TitleId;
			if(request.TitleId == null) throw new Exception ("Must be have PlayFabSettings.TitleId set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Client/LoginWithIOSDeviceID", request, null, null);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<LoginResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<LoginResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			LoginResult result = resultData.data;
			AuthKey = result.SessionTicket ?? AuthKey;

			
            return new PlayFabResult<LoginResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Signs the user into the PlayFab account, returning a session identifier that can subsequently be used for API calls which require an authenticated user
		/// </summary>
        public static async Task<PlayFabResult<LoginResult>> LoginWithPlayFabAsync(LoginWithPlayFabRequest request)
        {
            request.TitleId = PlayFabSettings.TitleId ?? request.TitleId;
			if(request.TitleId == null) throw new Exception ("Must be have PlayFabSettings.TitleId set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Client/LoginWithPlayFab", request, null, null);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<LoginResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<LoginResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			LoginResult result = resultData.data;
			AuthKey = result.SessionTicket ?? AuthKey;

			
            return new PlayFabResult<LoginResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Signs the user in using a Steam authentication ticket, returning a session identifier that can subsequently be used for API calls which require an authenticated user
		/// </summary>
        public static async Task<PlayFabResult<LoginResult>> LoginWithSteamAsync(LoginWithSteamRequest request)
        {
            request.TitleId = PlayFabSettings.TitleId ?? request.TitleId;
			if(request.TitleId == null) throw new Exception ("Must be have PlayFabSettings.TitleId set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Client/LoginWithSteam", request, null, null);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<LoginResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<LoginResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			LoginResult result = resultData.data;
			AuthKey = result.SessionTicket ?? AuthKey;

			
            return new PlayFabResult<LoginResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Registers a new Playfab user account, returning a session identifier that can subsequently be used for API calls which require an authenticated user
		/// </summary>
        public static async Task<PlayFabResult<RegisterPlayFabUserResult>> RegisterPlayFabUserAsync(RegisterPlayFabUserRequest request)
        {
            request.TitleId = PlayFabSettings.TitleId ?? request.TitleId;
			if(request.TitleId == null) throw new Exception ("Must be have PlayFabSettings.TitleId set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Client/RegisterPlayFabUser", request, null, null);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<RegisterPlayFabUserResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<RegisterPlayFabUserResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			RegisterPlayFabUserResult result = resultData.data;
			AuthKey = result.SessionTicket ?? AuthKey;

			
            return new PlayFabResult<RegisterPlayFabUserResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Forces an email to be sent to the registered email address for the user's account, with a link allowing the user to change the password
		/// </summary>
        public static async Task<PlayFabResult<SendAccountRecoveryEmailResult>> SendAccountRecoveryEmailAsync(SendAccountRecoveryEmailRequest request)
        {
            
            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Client/SendAccountRecoveryEmail", request, null, null);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<SendAccountRecoveryEmailResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<SendAccountRecoveryEmailResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			SendAccountRecoveryEmailResult result = resultData.data;
			
			
            return new PlayFabResult<SendAccountRecoveryEmailResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Retrieves the user's PlayFab account details
		/// </summary>
        public static async Task<PlayFabResult<GetAccountInfoResult>> GetAccountInfoAsync(GetAccountInfoRequest request)
        {
            if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Client/GetAccountInfo", request, "X-Authorization", AuthKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<GetAccountInfoResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<GetAccountInfoResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			GetAccountInfoResult result = resultData.data;
			
			
            return new PlayFabResult<GetAccountInfoResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Links the Facebook account associated with the provided Facebook access token to the user's PlayFab account
		/// </summary>
        public static async Task<PlayFabResult<LinkFacebookAccountResult>> LinkFacebookAccountAsync(LinkFacebookAccountRequest request)
        {
            if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Client/LinkFacebookAccount", request, "X-Authorization", AuthKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<LinkFacebookAccountResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<LinkFacebookAccountResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			LinkFacebookAccountResult result = resultData.data;
			
			
            return new PlayFabResult<LinkFacebookAccountResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Links the Game Center account associated with the provided Game Center ID to the user's PlayFab account
		/// </summary>
        public static async Task<PlayFabResult<LinkGameCenterAccountResult>> LinkGameCenterAccountAsync(LinkGameCenterAccountRequest request)
        {
            if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Client/LinkGameCenterAccount", request, "X-Authorization", AuthKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<LinkGameCenterAccountResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<LinkGameCenterAccountResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			LinkGameCenterAccountResult result = resultData.data;
			
			
            return new PlayFabResult<LinkGameCenterAccountResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Links the Steam account associated with the provided Steam authentication ticket to the user's PlayFab account
		/// </summary>
        public static async Task<PlayFabResult<LinkSteamAccountResult>> LinkSteamAccountAsync(LinkSteamAccountRequest request)
        {
            if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Client/LinkSteamAccount", request, "X-Authorization", AuthKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<LinkSteamAccountResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<LinkSteamAccountResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			LinkSteamAccountResult result = resultData.data;
			
			
            return new PlayFabResult<LinkSteamAccountResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Unlinks the related Facebook account from the user's PlayFab account
		/// </summary>
        public static async Task<PlayFabResult<UnlinkFacebookAccountResult>> UnlinkFacebookAccountAsync(UnlinkFacebookAccountRequest request)
        {
            if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Client/UnlinkFacebookAccount", request, "X-Authorization", AuthKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<UnlinkFacebookAccountResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<UnlinkFacebookAccountResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			UnlinkFacebookAccountResult result = resultData.data;
			
			
            return new PlayFabResult<UnlinkFacebookAccountResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Unlinks the related Game Center account from the user's PlayFab account
		/// </summary>
        public static async Task<PlayFabResult<UnlinkGameCenterAccountResult>> UnlinkGameCenterAccountAsync(UnlinkGameCenterAccountRequest request)
        {
            if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Client/UnlinkGameCenterAccount", request, "X-Authorization", AuthKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<UnlinkGameCenterAccountResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<UnlinkGameCenterAccountResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			UnlinkGameCenterAccountResult result = resultData.data;
			
			
            return new PlayFabResult<UnlinkGameCenterAccountResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Unlinks the related Steam account from the user's PlayFab account
		/// </summary>
        public static async Task<PlayFabResult<UnlinkSteamAccountResult>> UnlinkSteamAccountAsync(LinkSteamAccountRequest request)
        {
            if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Client/UnlinkSteamAccount", request, "X-Authorization", AuthKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<UnlinkSteamAccountResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<UnlinkSteamAccountResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			UnlinkSteamAccountResult result = resultData.data;
			
			
            return new PlayFabResult<UnlinkSteamAccountResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Updates the local user's email address in PlayFab
		/// </summary>
        public static async Task<PlayFabResult<UpdateEmailAddressResult>> UpdateEmailAddressAsync(UpdateEmailAddressRequest request)
        {
            if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Client/UpdateEmailAddress", request, "X-Authorization", AuthKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<UpdateEmailAddressResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<UpdateEmailAddressResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			UpdateEmailAddressResult result = resultData.data;
			
			
            return new PlayFabResult<UpdateEmailAddressResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Updates the local user's password in PlayFab
		/// </summary>
        public static async Task<PlayFabResult<UpdatePasswordResult>> UpdatePasswordAsync(UpdatePasswordRequest request)
        {
            if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Client/UpdatePassword", request, "X-Authorization", AuthKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<UpdatePasswordResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<UpdatePasswordResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			UpdatePasswordResult result = resultData.data;
			
			
            return new PlayFabResult<UpdatePasswordResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Updates the title specific display name for the user
		/// </summary>
        public static async Task<PlayFabResult<UpdateUserTitleDisplayNameResult>> UpdateUserTitleDisplayNameAsync(UpdateUserTitleDisplayNameRequest request)
        {
            if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Client/UpdateUserTitleDisplayName", request, "X-Authorization", AuthKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<UpdateUserTitleDisplayNameResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<UpdateUserTitleDisplayNameResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			UpdateUserTitleDisplayNameResult result = resultData.data;
			
			
            return new PlayFabResult<UpdateUserTitleDisplayNameResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Retrieves the title-specific custom data for the user which is readable and writable by the client
		/// </summary>
        public static async Task<PlayFabResult<GetUserDataResult>> GetUserDataAsync(GetUserDataRequest request)
        {
            if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Client/GetUserData", request, "X-Authorization", AuthKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<GetUserDataResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<GetUserDataResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			GetUserDataResult result = resultData.data;
			
			
            return new PlayFabResult<GetUserDataResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Retrieves the title-specific custom data for the user which can only be read by the client
		/// </summary>
        public static async Task<PlayFabResult<GetUserDataResult>> GetUserReadOnlyDataAsync(GetUserDataRequest request)
        {
            if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Client/GetUserReadOnlyData", request, "X-Authorization", AuthKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<GetUserDataResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<GetUserDataResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			GetUserDataResult result = resultData.data;
			
			
            return new PlayFabResult<GetUserDataResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Creates and updates the title-specific custom data for the user which is readable and writable by the client
		/// </summary>
        public static async Task<PlayFabResult<UpdateUserDataResult>> UpdateUserDataAsync(UpdateUserDataRequest request)
        {
            if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Client/UpdateUserData", request, "X-Authorization", AuthKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<UpdateUserDataResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<UpdateUserDataResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			UpdateUserDataResult result = resultData.data;
			
			
            return new PlayFabResult<UpdateUserDataResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Retrieves the specified version of the title's catalog of virtual goods, including all defined properties
		/// </summary>
        public static async Task<PlayFabResult<GetCatalogItemsResult>> GetCatalogItemsAsync(GetCatalogItemsRequest request)
        {
            if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Client/GetCatalogItems", request, "X-Authorization", AuthKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<GetCatalogItemsResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<GetCatalogItemsResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			GetCatalogItemsResult result = resultData.data;
			
			
            return new PlayFabResult<GetCatalogItemsResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Retrieves the key-value store of custom title settings
		/// </summary>
        public static async Task<PlayFabResult<GetTitleDataResult>> GetTitleDataAsync(GetTitleDataRequest request)
        {
            if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Client/GetTitleData", request, "X-Authorization", AuthKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<GetTitleDataResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<GetTitleDataResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			GetTitleDataResult result = resultData.data;
			
			
            return new PlayFabResult<GetTitleDataResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Retrieves the title news feed, as configured in the developer portal
		/// </summary>
        public static async Task<PlayFabResult<GetTitleNewsResult>> GetTitleNewsAsync(GetTitleNewsRequest request)
        {
            if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Client/GetTitleNews", request, "X-Authorization", AuthKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<GetTitleNewsResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<GetTitleNewsResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			GetTitleNewsResult result = resultData.data;
			
			
            return new PlayFabResult<GetTitleNewsResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Confirms with the payment provider that the purchase was approved (if applicable) and adjusts inventory and virtual currency balances as appropriate
		/// </summary>
        public static async Task<PlayFabResult<ConfirmPurchaseResult>> ConfirmPurchaseAsync(ConfirmPurchaseRequest request)
        {
            if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Client/ConfirmPurchase", request, "X-Authorization", AuthKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<ConfirmPurchaseResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<ConfirmPurchaseResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			ConfirmPurchaseResult result = resultData.data;
			
			
            return new PlayFabResult<ConfirmPurchaseResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Retrieves the user's current inventory of virtual goods
		/// </summary>
        public static async Task<PlayFabResult<GetUserInventoryResult>> GetUserInventoryAsync(GetUserInventoryRequest request)
        {
            if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Client/GetUserInventory", request, "X-Authorization", AuthKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<GetUserInventoryResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<GetUserInventoryResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			GetUserInventoryResult result = resultData.data;
			
			
            return new PlayFabResult<GetUserInventoryResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Selects a payment option for purchase order created via StartPurchase
		/// </summary>
        public static async Task<PlayFabResult<PayForPurchaseResult>> PayForPurchaseAsync(PayForPurchaseRequest request)
        {
            if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Client/PayForPurchase", request, "X-Authorization", AuthKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<PayForPurchaseResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<PayForPurchaseResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			PayForPurchaseResult result = resultData.data;
			
			
            return new PlayFabResult<PayForPurchaseResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Buys a single item with virtual currency. You must specify both the virtual currency to use to purchase, as well as what the client believes the price to be. This lets the server fail the purchase if the price has changed.
		/// </summary>
        public static async Task<PlayFabResult<PurchaseItemResult>> PurchaseItemAsync(PurchaseItemRequest request)
        {
            if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Client/PurchaseItem", request, "X-Authorization", AuthKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<PurchaseItemResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<PurchaseItemResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			PurchaseItemResult result = resultData.data;
			
			
            return new PlayFabResult<PurchaseItemResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Adds the virtual goods associated with the coupon to the user's inventory
		/// </summary>
        public static async Task<PlayFabResult<RedeemCouponResult>> RedeemCouponAsync(RedeemCouponRequest request)
        {
            if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Client/RedeemCoupon", request, "X-Authorization", AuthKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<RedeemCouponResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<RedeemCouponResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			RedeemCouponResult result = resultData.data;
			
			
            return new PlayFabResult<RedeemCouponResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Creates an order for a list of items from the title catalog
		/// </summary>
        public static async Task<PlayFabResult<StartPurchaseResult>> StartPurchaseAsync(StartPurchaseRequest request)
        {
            if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Client/StartPurchase", request, "X-Authorization", AuthKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<StartPurchaseResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<StartPurchaseResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			StartPurchaseResult result = resultData.data;
			
			
            return new PlayFabResult<StartPurchaseResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Unlocks a container item in the user's inventory and consumes a key item of the type indicated by the container item
		/// </summary>
        public static async Task<PlayFabResult<UnlockContainerItemResult>> UnlockContainerItemAsync(UnlockContainerItemRequest request)
        {
            if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Client/UnlockContainerItem", request, "X-Authorization", AuthKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<UnlockContainerItemResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<UnlockContainerItemResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			UnlockContainerItemResult result = resultData.data;
			
			
            return new PlayFabResult<UnlockContainerItemResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Adds the PlayFab user, based upon a match against a supplied unique identifier, to the friend list of the local user
		/// </summary>
        public static async Task<PlayFabResult<AddFriendResult>> AddFriendAsync(AddFriendRequest request)
        {
            if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Client/AddFriend", request, "X-Authorization", AuthKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<AddFriendResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<AddFriendResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			AddFriendResult result = resultData.data;
			
			
            return new PlayFabResult<AddFriendResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Retrieves the current friend list for the local user, constrained to users who have PlayFab accounts
		/// </summary>
        public static async Task<PlayFabResult<GetFriendsListResult>> GetFriendsListAsync(GetFriendsListRequest request)
        {
            if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Client/GetFriendsList", request, "X-Authorization", AuthKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<GetFriendsListResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<GetFriendsListResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			GetFriendsListResult result = resultData.data;
			
			
            return new PlayFabResult<GetFriendsListResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Removes a specified user from the friend list of the local user
		/// </summary>
        public static async Task<PlayFabResult<RemoveFriendResult>> RemoveFriendAsync(RemoveFriendRequest request)
        {
            if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Client/RemoveFriend", request, "X-Authorization", AuthKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<RemoveFriendResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<RemoveFriendResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			RemoveFriendResult result = resultData.data;
			
			
            return new PlayFabResult<RemoveFriendResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Updates the tag list for a specified user in the friend list of the local user
		/// </summary>
        public static async Task<PlayFabResult<SetFriendTagsResult>> SetFriendTagsAsync(SetFriendTagsRequest request)
        {
            if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Client/SetFriendTags", request, "X-Authorization", AuthKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<SetFriendTagsResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<SetFriendTagsResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			SetFriendTagsResult result = resultData.data;
			
			
            return new PlayFabResult<SetFriendTagsResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Registers the iOS device to receive push notifications
		/// </summary>
        public static async Task<PlayFabResult<RegisterForIOSPushNotificationResult>> RegisterForIOSPushNotificationAsync(RegisterForIOSPushNotificationRequest request)
        {
            if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Client/RegisterForIOSPushNotification", request, "X-Authorization", AuthKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<RegisterForIOSPushNotificationResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<RegisterForIOSPushNotificationResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			RegisterForIOSPushNotificationResult result = resultData.data;
			
			
            return new PlayFabResult<RegisterForIOSPushNotificationResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Validates with the iTunes store that the receipt for an iOS in-app purchase is valid and that it matches the purchased catalog item
		/// </summary>
        public static async Task<PlayFabResult<ValidateIOSReceiptResult>> ValidateIOSReceiptAsync(ValidateIOSReceiptRequest request)
        {
            if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Client/ValidateIOSReceipt", request, "X-Authorization", AuthKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<ValidateIOSReceiptResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<ValidateIOSReceiptResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			ValidateIOSReceiptResult result = resultData.data;
			
			
            return new PlayFabResult<ValidateIOSReceiptResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Get details about all current running game servers matching the given parameters.
		/// </summary>
        public static async Task<PlayFabResult<CurrentGamesResult>> GetCurrentGamesAsync(CurrentGamesRequest request)
        {
            if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Client/GetCurrentGames", request, "X-Authorization", AuthKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<CurrentGamesResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<CurrentGamesResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			CurrentGamesResult result = resultData.data;
			
			
            return new PlayFabResult<CurrentGamesResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		///  Get details about the regions hosting game servers matching the given parameters.
		/// </summary>
        public static async Task<PlayFabResult<GameServerRegionsResult>> GetGameServerRegionsAsync(GameServerRegionsRequest request)
        {
            if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Client/GetGameServerRegions", request, "X-Authorization", AuthKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<GameServerRegionsResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<GameServerRegionsResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			GameServerRegionsResult result = resultData.data;
			
			
            return new PlayFabResult<GameServerRegionsResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Get statistics about game server mode playlists.
		/// </summary>
        public static async Task<PlayFabResult<RegionPlaylistsResult>> GetRegionPlaylistsAsync(RegionPlaylistsRequest request)
        {
            if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Client/GetRegionPlaylists", request, "X-Authorization", AuthKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<RegionPlaylistsResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<RegionPlaylistsResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			RegionPlaylistsResult result = resultData.data;
			
			
            return new PlayFabResult<RegionPlaylistsResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Assign the current player to an existing or new game server matching the given parameters and return the connection information.
		/// </summary>
        public static async Task<PlayFabResult<MatchmakeResult>> MatchmakeAsync(MatchmakeRequest request)
        {
            if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Client/Matchmake", request, "X-Authorization", AuthKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<MatchmakeResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<MatchmakeResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			MatchmakeResult result = resultData.data;
			
			
            return new PlayFabResult<MatchmakeResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Start a new game server with a given configuration, add the current player and return the connection information.
		/// </summary>
        public static async Task<PlayFabResult<StartGameResult>> StartGameAsync(StartGameRequest request)
        {
            if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Client/StartGame", request, "X-Authorization", AuthKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<StartGameResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<StartGameResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			StartGameResult result = resultData.data;
			
			
            return new PlayFabResult<StartGameResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Registers the Android device to receive push notifications
		/// </summary>
        public static async Task<PlayFabResult<AndroidDevicePushNotificationRegistrationResult>> AndroidDevicePushNotificationRegistrationAsync(AndroidDevicePushNotificationRegistrationRequest request)
        {
            if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Client/AndroidDevicePushNotificationRegistration", request, "X-Authorization", AuthKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<AndroidDevicePushNotificationRegistrationResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<AndroidDevicePushNotificationRegistrationResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			AndroidDevicePushNotificationRegistrationResult result = resultData.data;
			
			
            return new PlayFabResult<AndroidDevicePushNotificationRegistrationResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Validates with the GooglePlay store that the receipt for an in-app purchase is valid and that it matches the purchased catalog item
		/// </summary>
        public static async Task<PlayFabResult<ValidateGooglePlayPurchaseResult>> ValidateGooglePlayPurchaseAsync(ValidateGooglePlayPurchaseRequest request)
        {
            if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Client/ValidateGooglePlayPurchase", request, "X-Authorization", AuthKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<ValidateGooglePlayPurchaseResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<ValidateGooglePlayPurchaseResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			ValidateGooglePlayPurchaseResult result = resultData.data;
			
			
            return new PlayFabResult<ValidateGooglePlayPurchaseResult>
                {
                    Result = result
                };
        }

        
		private static string AuthKey = null;
		
    }
}
