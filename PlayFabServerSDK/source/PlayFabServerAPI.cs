using System;
using System.IO;
using System.Threading.Tasks;

using Newtonsoft.Json;

using PlayFab.Internal;
using PlayFab.ServerModels;


namespace PlayFab
{

	
	/// <summary>
	/// Provides functionality to allow external (developer-controlled) servers to interact with user inventories and data in a trusted manner, and to handle matchmaking and client connection orchestration
	/// </summary>
    public class PlayFabServerAPI
    {
		
		
		/// <summary>
		/// Validated a client's session ticket, and if successful, returns details for that user
		/// </summary>
        public static async Task<PlayFabResult<AuthenticateSessionTicketResult>> AuthenticateSessionTicketAsync(AuthenticateSessionTicketRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/AuthenticateSessionTicket", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<AuthenticateSessionTicketResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<AuthenticateSessionTicketResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			AuthenticateSessionTicketResult result = resultData.data;
			
			
            return new PlayFabResult<AuthenticateSessionTicketResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Retrieves the unique PlayFab identifiers for the given set of Facebook identifiers.
		/// </summary>
        public static async Task<PlayFabResult<GetPlayFabIDsFromFacebookIDsResult>> GetPlayFabIDsFromFacebookIDsAsync(GetPlayFabIDsFromFacebookIDsRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/GetPlayFabIDsFromFacebookIDs", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<GetPlayFabIDsFromFacebookIDsResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<GetPlayFabIDsFromFacebookIDsResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			GetPlayFabIDsFromFacebookIDsResult result = resultData.data;
			
			
            return new PlayFabResult<GetPlayFabIDsFromFacebookIDsResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Retrieves the relevant details for a specified user
		/// </summary>
        public static async Task<PlayFabResult<GetUserAccountInfoResult>> GetUserAccountInfoAsync(GetUserAccountInfoRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/GetUserAccountInfo", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<GetUserAccountInfoResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<GetUserAccountInfoResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			GetUserAccountInfoResult result = resultData.data;
			
			
            return new PlayFabResult<GetUserAccountInfoResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Sends an iOS/Android Push Notification to a specific user, if that user's device has been configured for Push Notifications in PlayFab. If a user has linked both Android and iOS devices, both will be notified.
		/// </summary>
        public static async Task<PlayFabResult<SendPushNotificationResult>> SendPushNotificationAsync(SendPushNotificationRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/SendPushNotification", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<SendPushNotificationResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<SendPushNotificationResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			SendPushNotificationResult result = resultData.data;
			
			
            return new PlayFabResult<SendPushNotificationResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Deletes the users for the provided game. Deletes custom data, all account linkages, and statistics.
		/// </summary>
        public static async Task<PlayFabResult<DeleteUsersResult>> DeleteUsersAsync(DeleteUsersRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/DeleteUsers", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<DeleteUsersResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<DeleteUsersResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			DeleteUsersResult result = resultData.data;
			
			
            return new PlayFabResult<DeleteUsersResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Retrieves a list of ranked users for the given statistic, starting from the indicated point in the leaderboard
		/// </summary>
        public static async Task<PlayFabResult<GetLeaderboardResult>> GetLeaderboardAsync(GetLeaderboardRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/GetLeaderboard", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<GetLeaderboardResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<GetLeaderboardResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			GetLeaderboardResult result = resultData.data;
			
			
            return new PlayFabResult<GetLeaderboardResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Retrieves a list of ranked users for the given statistic, centered on the currently signed-in user
		/// </summary>
        public static async Task<PlayFabResult<GetLeaderboardAroundUserResult>> GetLeaderboardAroundUserAsync(GetLeaderboardAroundUserRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/GetLeaderboardAroundUser", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<GetLeaderboardAroundUserResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<GetLeaderboardAroundUserResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			GetLeaderboardAroundUserResult result = resultData.data;
			
			
            return new PlayFabResult<GetLeaderboardAroundUserResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Retrieves the title-specific custom data for the user which is readable and writable by the client
		/// </summary>
        public static async Task<PlayFabResult<GetUserDataResult>> GetUserDataAsync(GetUserDataRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/GetUserData", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
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
		/// Retrieves the title-specific custom data for the user which cannot be accessed by the client
		/// </summary>
        public static async Task<PlayFabResult<GetUserDataResult>> GetUserInternalDataAsync(GetUserDataRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/GetUserInternalData", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
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
		/// Retrieves the publisher-specific custom data for the user which is readable and writable by the client
		/// </summary>
        public static async Task<PlayFabResult<GetUserDataResult>> GetUserPublisherDataAsync(GetUserDataRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/GetUserPublisherData", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
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
		/// Retrieves the publisher-specific custom data for the user which cannot be accessed by the client
		/// </summary>
        public static async Task<PlayFabResult<GetUserDataResult>> GetUserPublisherInternalDataAsync(GetUserDataRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/GetUserPublisherInternalData", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
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
		/// Retrieves the publisher-specific custom data for the user which can only be read by the client
		/// </summary>
        public static async Task<PlayFabResult<GetUserDataResult>> GetUserPublisherReadOnlyDataAsync(GetUserDataRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/GetUserPublisherReadOnlyData", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
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
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/GetUserReadOnlyData", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
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
		/// Retrieves the details of all title-specific statistics for the user
		/// </summary>
        public static async Task<PlayFabResult<GetUserStatisticsResult>> GetUserStatisticsAsync(GetUserStatisticsRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/GetUserStatistics", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<GetUserStatisticsResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<GetUserStatisticsResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			GetUserStatisticsResult result = resultData.data;
			
			
            return new PlayFabResult<GetUserStatisticsResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Updates the title-specific custom data for the user which is readable and writable by the client
		/// </summary>
        public static async Task<PlayFabResult<UpdateUserDataResult>> UpdateUserDataAsync(UpdateUserDataRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/UpdateUserData", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
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
		/// Updates the title-specific custom data for the user which cannot be accessed by the client
		/// </summary>
        public static async Task<PlayFabResult<UpdateUserDataResult>> UpdateUserInternalDataAsync(UpdateUserInternalDataRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/UpdateUserInternalData", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
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
		/// Updates the publisher-specific custom data for the user which is readable and writable by the client
		/// </summary>
        public static async Task<PlayFabResult<UpdateUserDataResult>> UpdateUserPublisherDataAsync(UpdateUserDataRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/UpdateUserPublisherData", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
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
		/// Updates the publisher-specific custom data for the user which cannot be accessed by the client
		/// </summary>
        public static async Task<PlayFabResult<UpdateUserDataResult>> UpdateUserPublisherInternalDataAsync(UpdateUserInternalDataRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/UpdateUserPublisherInternalData", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
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
		/// Updates the publisher-specific custom data for the user which can only be read by the client
		/// </summary>
        public static async Task<PlayFabResult<UpdateUserDataResult>> UpdateUserPublisherReadOnlyDataAsync(UpdateUserDataRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/UpdateUserPublisherReadOnlyData", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
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
		/// Updates the title-specific custom data for the user which can only be read by the client
		/// </summary>
        public static async Task<PlayFabResult<UpdateUserDataResult>> UpdateUserReadOnlyDataAsync(UpdateUserDataRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/UpdateUserReadOnlyData", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
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
		/// Updates the values of the specified title-specific statistics for the user
		/// </summary>
        public static async Task<PlayFabResult<UpdateUserStatisticsResult>> UpdateUserStatisticsAsync(UpdateUserStatisticsRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/UpdateUserStatistics", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<UpdateUserStatisticsResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<UpdateUserStatisticsResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			UpdateUserStatisticsResult result = resultData.data;
			
			
            return new PlayFabResult<UpdateUserStatisticsResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Retrieves the specified version of the title's catalog of virtual goods, including all defined properties
		/// </summary>
        public static async Task<PlayFabResult<GetCatalogItemsResult>> GetCatalogItemsAsync(GetCatalogItemsRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/GetCatalogItems", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
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
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/GetTitleData", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
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
		/// Retrieves the key-value store of custom internal title settings
		/// </summary>
        public static async Task<PlayFabResult<GetTitleDataResult>> GetTitleInternalDataAsync(GetTitleDataRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/GetTitleInternalData", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
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
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/GetTitleNews", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
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
		/// Updates the key-value store of custom title settings
		/// </summary>
        public static async Task<PlayFabResult<SetTitleDataResult>> SetTitleDataAsync(SetTitleDataRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/SetTitleData", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<SetTitleDataResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<SetTitleDataResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			SetTitleDataResult result = resultData.data;
			
			
            return new PlayFabResult<SetTitleDataResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Updates the key-value store of custom title settings
		/// </summary>
        public static async Task<PlayFabResult<SetTitleDataResult>> SetTitleInternalDataAsync(SetTitleDataRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/SetTitleInternalData", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<SetTitleDataResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<SetTitleDataResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			SetTitleDataResult result = resultData.data;
			
			
            return new PlayFabResult<SetTitleDataResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Increments  the character's balance of the specified virtual currency by the stated amount
		/// </summary>
        public static async Task<PlayFabResult<ModifyCharacterVirtualCurrencyResult>> AddCharacterVirtualCurrencyAsync(AddCharacterVirtualCurrencyRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/AddCharacterVirtualCurrency", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<ModifyCharacterVirtualCurrencyResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<ModifyCharacterVirtualCurrencyResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			ModifyCharacterVirtualCurrencyResult result = resultData.data;
			
			
            return new PlayFabResult<ModifyCharacterVirtualCurrencyResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Increments  the user's balance of the specified virtual currency by the stated amount
		/// </summary>
        public static async Task<PlayFabResult<ModifyUserVirtualCurrencyResult>> AddUserVirtualCurrencyAsync(AddUserVirtualCurrencyRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/AddUserVirtualCurrency", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<ModifyUserVirtualCurrencyResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<ModifyUserVirtualCurrencyResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			ModifyUserVirtualCurrencyResult result = resultData.data;
			
			
            return new PlayFabResult<ModifyUserVirtualCurrencyResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Retrieves the specified character's current inventory of virtual goods
		/// </summary>
        public static async Task<PlayFabResult<GetCharacterInventoryResult>> GetCharacterInventoryAsync(GetCharacterInventoryRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/GetCharacterInventory", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<GetCharacterInventoryResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<GetCharacterInventoryResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			GetCharacterInventoryResult result = resultData.data;
			
			
            return new PlayFabResult<GetCharacterInventoryResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Retrieves the specified user's current inventory of virtual goods
		/// </summary>
        public static async Task<PlayFabResult<GetUserInventoryResult>> GetUserInventoryAsync(GetUserInventoryRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/GetUserInventory", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
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
		/// Adds the specified items to the specified character's inventory
		/// </summary>
        public static async Task<PlayFabResult<GrantItemsToCharacterResult>> GrantItemsToCharacterAsync(GrantItemsToCharacterRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/GrantItemsToCharacter", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<GrantItemsToCharacterResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<GrantItemsToCharacterResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			GrantItemsToCharacterResult result = resultData.data;
			
			
            return new PlayFabResult<GrantItemsToCharacterResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Adds the specified items to the specified user's inventory
		/// </summary>
        public static async Task<PlayFabResult<GrantItemsToUserResult>> GrantItemsToUserAsync(GrantItemsToUserRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/GrantItemsToUser", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<GrantItemsToUserResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<GrantItemsToUserResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			GrantItemsToUserResult result = resultData.data;
			
			
            return new PlayFabResult<GrantItemsToUserResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Adds the specified items to the specified user inventories
		/// </summary>
        public static async Task<PlayFabResult<GrantItemsToUsersResult>> GrantItemsToUsersAsync(GrantItemsToUsersRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/GrantItemsToUsers", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<GrantItemsToUsersResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<GrantItemsToUsersResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			GrantItemsToUsersResult result = resultData.data;
			
			
            return new PlayFabResult<GrantItemsToUsersResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Modifies the number of remaining uses of a player's inventory item
		/// </summary>
        public static async Task<PlayFabResult<ModifyItemUsesResult>> ModifyItemUsesAsync(ModifyItemUsesRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/ModifyItemUses", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<ModifyItemUsesResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<ModifyItemUsesResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			ModifyItemUsesResult result = resultData.data;
			
			
            return new PlayFabResult<ModifyItemUsesResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Moves an item from a character's inventory into another of the users's character's inventory.
		/// </summary>
        public static async Task<PlayFabResult<MoveItemToCharacterFromCharacterResult>> MoveItemToCharacterFromCharacterAsync(MoveItemToCharacterFromCharacterRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/MoveItemToCharacterFromCharacter", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<MoveItemToCharacterFromCharacterResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<MoveItemToCharacterFromCharacterResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			MoveItemToCharacterFromCharacterResult result = resultData.data;
			
			
            return new PlayFabResult<MoveItemToCharacterFromCharacterResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Moves an item from a user's inventory into their character's inventory.
		/// </summary>
        public static async Task<PlayFabResult<MoveItemToCharacterFromUserResult>> MoveItemToCharacterFromUserAsync(MoveItemToCharacterFromUserRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/MoveItemToCharacterFromUser", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<MoveItemToCharacterFromUserResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<MoveItemToCharacterFromUserResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			MoveItemToCharacterFromUserResult result = resultData.data;
			
			
            return new PlayFabResult<MoveItemToCharacterFromUserResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Moves an item from a character's inventory into the owning user's inventory.
		/// </summary>
        public static async Task<PlayFabResult<MoveItemToUserFromCharacterResult>> MoveItemToUserFromCharacterAsync(MoveItemToUserFromCharacterRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/MoveItemToUserFromCharacter", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<MoveItemToUserFromCharacterResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<MoveItemToUserFromCharacterResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			MoveItemToUserFromCharacterResult result = resultData.data;
			
			
            return new PlayFabResult<MoveItemToUserFromCharacterResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Adds the virtual goods associated with the coupon to the user's inventory. Coupons can be generated  via the Promotions->Coupons tab in the PlayFab Game Manager. See this post for more information on coupons:  https://playfab.com/blog/2015/06/18/using-stores-and-coupons-game-manager
		/// </summary>
        public static async Task<PlayFabResult<RedeemCouponResult>> RedeemCouponAsync(RedeemCouponRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/RedeemCoupon", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
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
		/// Submit a report about a player (due to bad bahavior, etc.) on behalf of another player, so that customer service representatives for the title can take action concerning potentially poxic players.
		/// </summary>
        public static async Task<PlayFabResult<ReportPlayerServerResult>> ReportPlayerAsync(ReportPlayerServerRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/ReportPlayer", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<ReportPlayerServerResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<ReportPlayerServerResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			ReportPlayerServerResult result = resultData.data;
			
			
            return new PlayFabResult<ReportPlayerServerResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Decrements the character's balance of the specified virtual currency by the stated amount
		/// </summary>
        public static async Task<PlayFabResult<ModifyCharacterVirtualCurrencyResult>> SubtractCharacterVirtualCurrencyAsync(SubtractCharacterVirtualCurrencyRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/SubtractCharacterVirtualCurrency", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<ModifyCharacterVirtualCurrencyResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<ModifyCharacterVirtualCurrencyResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			ModifyCharacterVirtualCurrencyResult result = resultData.data;
			
			
            return new PlayFabResult<ModifyCharacterVirtualCurrencyResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Decrements the user's balance of the specified virtual currency by the stated amount
		/// </summary>
        public static async Task<PlayFabResult<ModifyUserVirtualCurrencyResult>> SubtractUserVirtualCurrencyAsync(SubtractUserVirtualCurrencyRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/SubtractUserVirtualCurrency", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<ModifyUserVirtualCurrencyResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<ModifyUserVirtualCurrencyResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			ModifyUserVirtualCurrencyResult result = resultData.data;
			
			
            return new PlayFabResult<ModifyUserVirtualCurrencyResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Updates the key-value pair data tagged to the specified item, which is read-only from the client.
		/// </summary>
        public static async Task<PlayFabResult<UpdateUserInventoryItemDataResult>> UpdateUserInventoryItemCustomDataAsync(UpdateUserInventoryItemDataRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/UpdateUserInventoryItemCustomData", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<UpdateUserInventoryItemDataResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<UpdateUserInventoryItemDataResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			UpdateUserInventoryItemDataResult result = resultData.data;
			
			
            return new PlayFabResult<UpdateUserInventoryItemDataResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Informs the PlayFab match-making service that the user specified has left the Game Server Instance
		/// </summary>
        public static async Task<PlayFabResult<NotifyMatchmakerPlayerLeftResult>> NotifyMatchmakerPlayerLeftAsync(NotifyMatchmakerPlayerLeftRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/NotifyMatchmakerPlayerLeft", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<NotifyMatchmakerPlayerLeftResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<NotifyMatchmakerPlayerLeftResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			NotifyMatchmakerPlayerLeftResult result = resultData.data;
			
			
            return new PlayFabResult<NotifyMatchmakerPlayerLeftResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Validates a Game Server session ticket and returns details about the user
		/// </summary>
        public static async Task<PlayFabResult<RedeemMatchmakerTicketResult>> RedeemMatchmakerTicketAsync(RedeemMatchmakerTicketRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/RedeemMatchmakerTicket", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<RedeemMatchmakerTicketResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<RedeemMatchmakerTicketResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			RedeemMatchmakerTicketResult result = resultData.data;
			
			
            return new PlayFabResult<RedeemMatchmakerTicketResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Awards the specified users the specified Steam achievements
		/// </summary>
        public static async Task<PlayFabResult<AwardSteamAchievementResult>> AwardSteamAchievementAsync(AwardSteamAchievementRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/AwardSteamAchievement", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<AwardSteamAchievementResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<AwardSteamAchievementResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			AwardSteamAchievementResult result = resultData.data;
			
			
            return new PlayFabResult<AwardSteamAchievementResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Logs a custom analytics event
		/// </summary>
        public static async Task<PlayFabResult<LogEventResult>> LogEventAsync(LogEventRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/LogEvent", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<LogEventResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<LogEventResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			LogEventResult result = resultData.data;
			
			
            return new PlayFabResult<LogEventResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Adds users to the set of those able to update both the shared data, as well as the set of users in the group. Only users in the group (and the server) can add new members.
		/// </summary>
        public static async Task<PlayFabResult<AddSharedGroupMembersResult>> AddSharedGroupMembersAsync(AddSharedGroupMembersRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/AddSharedGroupMembers", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<AddSharedGroupMembersResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<AddSharedGroupMembersResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			AddSharedGroupMembersResult result = resultData.data;
			
			
            return new PlayFabResult<AddSharedGroupMembersResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Requests the creation of a shared group object, containing key/value pairs which may be updated by all members of the group. When created by a server, the group will initially have no members.
		/// </summary>
        public static async Task<PlayFabResult<CreateSharedGroupResult>> CreateSharedGroupAsync(CreateSharedGroupRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/CreateSharedGroup", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<CreateSharedGroupResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<CreateSharedGroupResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			CreateSharedGroupResult result = resultData.data;
			
			
            return new PlayFabResult<CreateSharedGroupResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Deletes a shared group, freeing up the shared group ID to be reused for a new group
		/// </summary>
        public static async Task<PlayFabResult<EmptyResult>> DeleteSharedGroupAsync(DeleteSharedGroupRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/DeleteSharedGroup", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<EmptyResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<EmptyResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			EmptyResult result = resultData.data;
			
			
            return new PlayFabResult<EmptyResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Retrieves the key-value store of custom publisher settings
		/// </summary>
        public static async Task<PlayFabResult<GetPublisherDataResult>> GetPublisherDataAsync(GetPublisherDataRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/GetPublisherData", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<GetPublisherDataResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<GetPublisherDataResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			GetPublisherDataResult result = resultData.data;
			
			
            return new PlayFabResult<GetPublisherDataResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Retrieves data stored in a shared group object, as well as the list of members in the group. The server can access all public and private group data.
		/// </summary>
        public static async Task<PlayFabResult<GetSharedGroupDataResult>> GetSharedGroupDataAsync(GetSharedGroupDataRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/GetSharedGroupData", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<GetSharedGroupDataResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<GetSharedGroupDataResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			GetSharedGroupDataResult result = resultData.data;
			
			
            return new PlayFabResult<GetSharedGroupDataResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Removes users from the set of those able to update the shared data and the set of users in the group. Only users in the group can remove members. If as a result of the call, zero users remain with access, the group and its associated data will be deleted.
		/// </summary>
        public static async Task<PlayFabResult<RemoveSharedGroupMembersResult>> RemoveSharedGroupMembersAsync(RemoveSharedGroupMembersRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/RemoveSharedGroupMembers", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<RemoveSharedGroupMembersResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<RemoveSharedGroupMembersResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			RemoveSharedGroupMembersResult result = resultData.data;
			
			
            return new PlayFabResult<RemoveSharedGroupMembersResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Updates the key-value store of custom publisher settings
		/// </summary>
        public static async Task<PlayFabResult<SetPublisherDataResult>> SetPublisherDataAsync(SetPublisherDataRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/SetPublisherData", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<SetPublisherDataResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<SetPublisherDataResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			SetPublisherDataResult result = resultData.data;
			
			
            return new PlayFabResult<SetPublisherDataResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Adds, updates, and removes data keys for a shared group object. If the permission is set to Public, all fields updated or added in this call will be readable by users not in the group. By default, data permissions are set to Private. Regardless of the permission setting, only members of the group (and the server) can update the data.
		/// </summary>
        public static async Task<PlayFabResult<UpdateSharedGroupDataResult>> UpdateSharedGroupDataAsync(UpdateSharedGroupDataRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/UpdateSharedGroupData", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<UpdateSharedGroupDataResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<UpdateSharedGroupDataResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			UpdateSharedGroupDataResult result = resultData.data;
			
			
            return new PlayFabResult<UpdateSharedGroupDataResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// This API retrieves a pre-signed URL for accessing a content file for the title. A subsequent  HTTP GET to the returned URL will attempt to download the content. A HEAD query to the returned URL will attempt to  retrieve the metadata of the content. Note that a successful result does not guarantee the existence of this content -  if it has not been uploaded, the query to retrieve the data will fail. See this post for more information:  https://support.playfab.com/support/discussions/topics/1000059929
		/// </summary>
        public static async Task<PlayFabResult<GetContentDownloadUrlResult>> GetContentDownloadUrlAsync(GetContentDownloadUrlRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/GetContentDownloadUrl", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<GetContentDownloadUrlResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<GetContentDownloadUrlResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			GetContentDownloadUrlResult result = resultData.data;
			
			
            return new PlayFabResult<GetContentDownloadUrlResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Deletes the specific character ID from the specified user.
		/// </summary>
        public static async Task<PlayFabResult<DeleteCharacterFromUserResult>> DeleteCharacterFromUserAsync(DeleteCharacterFromUserRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/DeleteCharacterFromUser", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<DeleteCharacterFromUserResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<DeleteCharacterFromUserResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			DeleteCharacterFromUserResult result = resultData.data;
			
			
            return new PlayFabResult<DeleteCharacterFromUserResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Lists all of the characters that belong to a specific user.
		/// </summary>
        public static async Task<PlayFabResult<ListUsersCharactersResult>> GetAllUsersCharactersAsync(ListUsersCharactersRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/GetAllUsersCharacters", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<ListUsersCharactersResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<ListUsersCharactersResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			ListUsersCharactersResult result = resultData.data;
			
			
            return new PlayFabResult<ListUsersCharactersResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Retrieves a list of ranked characters for the given statistic, starting from the indicated point in the leaderboard
		/// </summary>
        public static async Task<PlayFabResult<GetCharacterLeaderboardResult>> GetCharacterLeaderboardAsync(GetCharacterLeaderboardRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/GetCharacterLeaderboard", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<GetCharacterLeaderboardResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<GetCharacterLeaderboardResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			GetCharacterLeaderboardResult result = resultData.data;
			
			
            return new PlayFabResult<GetCharacterLeaderboardResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Retrieves the details of all title-specific statistics for the specific character
		/// </summary>
        public static async Task<PlayFabResult<GetCharacterStatisticsResult>> GetCharacterStatisticsAsync(GetCharacterStatisticsRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/GetCharacterStatistics", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<GetCharacterStatisticsResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<GetCharacterStatisticsResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			GetCharacterStatisticsResult result = resultData.data;
			
			
            return new PlayFabResult<GetCharacterStatisticsResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Retrieves a list of ranked characters for the given statistic, centered on the requested user
		/// </summary>
        public static async Task<PlayFabResult<GetLeaderboardAroundCharacterResult>> GetLeaderboardAroundCharacterAsync(GetLeaderboardAroundCharacterRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/GetLeaderboardAroundCharacter", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<GetLeaderboardAroundCharacterResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<GetLeaderboardAroundCharacterResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			GetLeaderboardAroundCharacterResult result = resultData.data;
			
			
            return new PlayFabResult<GetLeaderboardAroundCharacterResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Retrieves a list of all of the user's characters for the given statistic.
		/// </summary>
        public static async Task<PlayFabResult<GetLeaderboardForUsersCharactersResult>> GetLeaderboardForUserCharactersAsync(GetLeaderboardForUsersCharactersRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/GetLeaderboardForUserCharacters", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<GetLeaderboardForUsersCharactersResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<GetLeaderboardForUsersCharactersResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			GetLeaderboardForUsersCharactersResult result = resultData.data;
			
			
            return new PlayFabResult<GetLeaderboardForUsersCharactersResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Grants the specified character type to the user.
		/// </summary>
        public static async Task<PlayFabResult<GrantCharacterToUserResult>> GrantCharacterToUserAsync(GrantCharacterToUserRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/GrantCharacterToUser", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<GrantCharacterToUserResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<GrantCharacterToUserResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			GrantCharacterToUserResult result = resultData.data;
			
			
            return new PlayFabResult<GrantCharacterToUserResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Updates the values of the specified title-specific statistics for the specific character
		/// </summary>
        public static async Task<PlayFabResult<UpdateCharacterStatisticsResult>> UpdateCharacterStatisticsAsync(UpdateCharacterStatisticsRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/UpdateCharacterStatistics", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<UpdateCharacterStatisticsResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<UpdateCharacterStatisticsResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			UpdateCharacterStatisticsResult result = resultData.data;
			
			
            return new PlayFabResult<UpdateCharacterStatisticsResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Retrieves the title-specific custom data for the user which is readable and writable by the client
		/// </summary>
        public static async Task<PlayFabResult<GetCharacterDataResult>> GetCharacterDataAsync(GetCharacterDataRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/GetCharacterData", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<GetCharacterDataResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<GetCharacterDataResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			GetCharacterDataResult result = resultData.data;
			
			
            return new PlayFabResult<GetCharacterDataResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Retrieves the title-specific custom data for the user's character which cannot be accessed by the client
		/// </summary>
        public static async Task<PlayFabResult<GetCharacterDataResult>> GetCharacterInternalDataAsync(GetCharacterDataRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/GetCharacterInternalData", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<GetCharacterDataResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<GetCharacterDataResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			GetCharacterDataResult result = resultData.data;
			
			
            return new PlayFabResult<GetCharacterDataResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Retrieves the title-specific custom data for the user's character which can only be read by the client
		/// </summary>
        public static async Task<PlayFabResult<GetCharacterDataResult>> GetCharacterReadOnlyDataAsync(GetCharacterDataRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/GetCharacterReadOnlyData", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<GetCharacterDataResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<GetCharacterDataResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			GetCharacterDataResult result = resultData.data;
			
			
            return new PlayFabResult<GetCharacterDataResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Updates the title-specific custom data for the user's chjaracter which is readable and writable by the client
		/// </summary>
        public static async Task<PlayFabResult<UpdateCharacterDataResult>> UpdateCharacterDataAsync(UpdateCharacterDataRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/UpdateCharacterData", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<UpdateCharacterDataResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<UpdateCharacterDataResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			UpdateCharacterDataResult result = resultData.data;
			
			
            return new PlayFabResult<UpdateCharacterDataResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Updates the title-specific custom data for the user's character which cannot  be accessed by the client
		/// </summary>
        public static async Task<PlayFabResult<UpdateCharacterDataResult>> UpdateCharacterInternalDataAsync(UpdateCharacterDataRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/UpdateCharacterInternalData", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<UpdateCharacterDataResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<UpdateCharacterDataResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			UpdateCharacterDataResult result = resultData.data;
			
			
            return new PlayFabResult<UpdateCharacterDataResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Updates the title-specific custom data for the user's character which can only be read by the client
		/// </summary>
        public static async Task<PlayFabResult<UpdateCharacterDataResult>> UpdateCharacterReadOnlyDataAsync(UpdateCharacterDataRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Server/UpdateCharacterReadOnlyData", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<UpdateCharacterDataResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<UpdateCharacterDataResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			UpdateCharacterDataResult result = resultData.data;
			
			
            return new PlayFabResult<UpdateCharacterDataResult>
                {
                    Result = result
                };
        }

        
    }
}
