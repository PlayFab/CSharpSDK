using System;
using System.IO;
using System.Threading.Tasks;

using Newtonsoft.Json;

using PlayFab.Internal;
using PlayFab.AdminModels;


namespace PlayFab
{

	
	/// <summary>
	/// APIs for managing title configurations, uploaded Game Server code executables, and user data
	/// </summary>
    public class PlayFabAdminAPI
    {
		
		
		/// <summary>
		/// Retrieves the relevant details for a specified user, based upon a match against a supplied unique identifier
		/// </summary>
        public static async Task<PlayFabResult<LookupUserAccountInfoResult>> GetUserAccountInfoAsync(LookupUserAccountInfoRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Admin/GetUserAccountInfo", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<LookupUserAccountInfoResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<LookupUserAccountInfoResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			LookupUserAccountInfoResult result = resultData.data;
			
			
            return new PlayFabResult<LookupUserAccountInfoResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Forces an email to be sent to the registered email address for the specified account, with a link allowing the user to change the password
		/// </summary>
        public static async Task<PlayFabResult<SendAccountRecoveryEmailResult>> SendAccountRecoveryEmailAsync(SendAccountRecoveryEmailRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Admin/SendAccountRecoveryEmail", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
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
		/// Updates the title specific display name for a user
		/// </summary>
        public static async Task<PlayFabResult<UpdateUserTitleDisplayNameResult>> UpdateUserTitleDisplayNameAsync(UpdateUserTitleDisplayNameRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Admin/UpdateUserTitleDisplayName", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
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
		/// Retrieves the specified version of the title's catalog of virtual goods, including all defined properties
		/// </summary>
        public static async Task<PlayFabResult<GetCatalogItemsResult>> GetCatalogItemsAsync(GetCatalogItemsRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Admin/GetCatalogItems", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
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
		/// Retrieves the random drop table configuration for the title
		/// </summary>
        public static async Task<PlayFabResult<GetRandomResultTablesResult>> GetRandomResultTablesAsync(GetRandomResultTablesRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Admin/GetRandomResultTables", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<GetRandomResultTablesResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<GetRandomResultTablesResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			GetRandomResultTablesResult result = resultData.data;
			
			
            return new PlayFabResult<GetRandomResultTablesResult>
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

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Admin/GetTitleData", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
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
		/// Creates the catalog configuration of all virtual goods for the specified catalog version
		/// </summary>
        public static async Task<PlayFabResult<UpdateCatalogItemsResult>> SetCatalogItemsAsync(UpdateCatalogItemsRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Admin/SetCatalogItems", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<UpdateCatalogItemsResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<UpdateCatalogItemsResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			UpdateCatalogItemsResult result = resultData.data;
			
			
            return new PlayFabResult<UpdateCatalogItemsResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Creates and updates the key-value store of custom title settings
		/// </summary>
        public static async Task<PlayFabResult<SetTitleDataResult>> SetTitleDataAsync(SetTitleDataRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Admin/SetTitleData", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
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
		/// Updates the catalog configuration for virtual goods in the specified catalog version
		/// </summary>
        public static async Task<PlayFabResult<UpdateCatalogItemsResult>> UpdateCatalogItemsAsync(UpdateCatalogItemsRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Admin/UpdateCatalogItems", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<UpdateCatalogItemsResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<UpdateCatalogItemsResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			UpdateCatalogItemsResult result = resultData.data;
			
			
            return new PlayFabResult<UpdateCatalogItemsResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Updates the random drop table configuration for the title
		/// </summary>
        public static async Task<PlayFabResult<UpdateRandomResultTablesResult>> UpdateRandomResultTablesAsync(UpdateRandomResultTablesRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Admin/UpdateRandomResultTables", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<UpdateRandomResultTablesResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<UpdateRandomResultTablesResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			UpdateRandomResultTablesResult result = resultData.data;
			
			
            return new PlayFabResult<UpdateRandomResultTablesResult>
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

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Admin/GetUserInventory", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
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
		/// Revokes access to an item in a user's inventory
		/// </summary>
        public static async Task<PlayFabResult<RevokeInventoryResult>> RevokeInventoryItemAsync(RevokeInventoryItemRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Admin/RevokeInventoryItem", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<RevokeInventoryResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<RevokeInventoryResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			RevokeInventoryResult result = resultData.data;
			
			
            return new PlayFabResult<RevokeInventoryResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Retrieves the details for a specific completed session, including links to standard out and standard error logs
		/// </summary>
        public static async Task<PlayFabResult<GetMatchmakerGameInfoResult>> GetMatchmakerGameInfoAsync(GetMatchmakerGameInfoRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Admin/GetMatchmakerGameInfo", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<GetMatchmakerGameInfoResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<GetMatchmakerGameInfoResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			GetMatchmakerGameInfoResult result = resultData.data;
			
			
            return new PlayFabResult<GetMatchmakerGameInfoResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Retrieves the details of defined game modes for the specified game server executable
		/// </summary>
        public static async Task<PlayFabResult<GetMatchmakerGameModesResult>> GetMatchmakerGameModesAsync(GetMatchmakerGameModesRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Admin/GetMatchmakerGameModes", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<GetMatchmakerGameModesResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<GetMatchmakerGameModesResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			GetMatchmakerGameModesResult result = resultData.data;
			
			
            return new PlayFabResult<GetMatchmakerGameModesResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Updates the game server mode details for the specified game server executable
		/// </summary>
        public static async Task<PlayFabResult<ModifyMatchmakerGameModesResult>> ModifyMatchmakerGameModesAsync(ModifyMatchmakerGameModesRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Admin/ModifyMatchmakerGameModes", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<ModifyMatchmakerGameModesResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<ModifyMatchmakerGameModesResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			ModifyMatchmakerGameModesResult result = resultData.data;
			
			
            return new PlayFabResult<ModifyMatchmakerGameModesResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Adds the game server executable specified to the set of those a client is permitted to request in a call to StartGame
		/// </summary>
        public static async Task<PlayFabResult<AddServerBuildResult>> AddServerBuildAsync(AddServerBuildRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Admin/AddServerBuild", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<AddServerBuildResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<AddServerBuildResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			AddServerBuildResult result = resultData.data;
			
			
            return new PlayFabResult<AddServerBuildResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Retrieves the build details for the specified game server executable
		/// </summary>
        public static async Task<PlayFabResult<GetServerBuildInfoResult>> GetServerBuildInfoAsync(GetServerBuildInfoRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Admin/GetServerBuildInfo", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<GetServerBuildInfoResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<GetServerBuildInfoResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			GetServerBuildInfoResult result = resultData.data;
			
			
            return new PlayFabResult<GetServerBuildInfoResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Retrieves the build details for all game server executables which are currently defined for the title
		/// </summary>
        public static async Task<PlayFabResult<ListBuildsResult>> ListServerBuildsAsync(ListBuildsRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Admin/ListServerBuilds", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<ListBuildsResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<ListBuildsResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			ListBuildsResult result = resultData.data;
			
			
            return new PlayFabResult<ListBuildsResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Updates the build details for the specified game server executable
		/// </summary>
        public static async Task<PlayFabResult<ModifyServerBuildResult>> ModifyServerBuildAsync(ModifyServerBuildRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Admin/ModifyServerBuild", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<ModifyServerBuildResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<ModifyServerBuildResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			ModifyServerBuildResult result = resultData.data;
			
			
            return new PlayFabResult<ModifyServerBuildResult>
                {
                    Result = result
                };
        }
		
		/// <summary>
		/// Remove the game server executable specified from the set of those a client is permitted to request in a call to StartGame
		/// </summary>
        public static async Task<PlayFabResult<RemoveServerBuildResult>> RemoveServerBuildAsync(RemoveServerBuildRequest request)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            object httpResult = await PlayFabHTTP.DoPost(PlayFabSettings.GetURL() + "/Admin/RemoveServerBuild", request, "X-SecretKey", PlayFabSettings.DeveloperSecretKey);
            if(httpResult is PlayFabError)
            {
                PlayFabError error = (PlayFabError)httpResult;
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(error);
                return new PlayFabResult<RemoveServerBuildResult>
                {
                    Error = error,
                };
            }
            string resultRawJson = (string)httpResult;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);
            var resultData = serializer.Deserialize<PlayFabJsonSuccess<RemoveServerBuildResult>>(new JsonTextReader(new StringReader(resultRawJson)));
			
			RemoveServerBuildResult result = resultData.data;
			
			
            return new PlayFabResult<RemoveServerBuildResult>
                {
                    Result = result
                };
        }

        
    }
}
