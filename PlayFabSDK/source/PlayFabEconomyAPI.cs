#if !DISABLE_PLAYFABENTITY_API && !DISABLE_PLAYFAB_STATIC_API

using PlayFab.EconomyModels;
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
    /// API methods for managing the catalog. Inventory manages in-game assets for any given entity. API methods for managing
    /// the versioned catalogs.
    /// </summary>
    public static class PlayFabEconomyAPI
    {
        /// <summary>
        /// Verify entity login.
        /// </summary>
        public static bool IsEntityLoggedIn()
        {
            return PlayFabSettings.staticPlayer.IsEntityLoggedIn();
        }

        /// <summary>
        /// Clear the Client SessionToken which allows this Client to call API calls requiring login.
        /// A new/fresh login will be required after calling this.
        /// </summary>
        public static void ForgetAllCredentials()
        {
            PlayFabSettings.staticPlayer.ForgetAllCredentials();
        }

        /// <summary>
        /// Add inventory items. Up to 10,000 stacks of items can be added to a single inventory collection. Stack size is uncapped.
        /// </summary>
        public static async Task<PlayFabResult<AddInventoryItemsResponse>> AddInventoryItemsAsync(AddInventoryItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Inventory/AddInventoryItems", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<AddInventoryItemsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<AddInventoryItemsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<AddInventoryItemsResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Creates a new item in the working catalog using provided metadata. Note: SAS tokens provided are valid for 1 hour.
        /// </summary>
        public static async Task<PlayFabResult<CreateDraftItemResponse>> CreateDraftItemAsync(CreateDraftItemRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Catalog/CreateDraftItem", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<CreateDraftItemResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<CreateDraftItemResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<CreateDraftItemResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Creates one or more upload URLs which can be used by the client to upload raw file data. Content URls and uploaded
        /// content will be garbage collected after 24 hours if not attached to a draft or published item. Detailed pricing info
        /// around uploading content can be found here:
        /// https://learn.microsoft.com/en-us/gaming/playfab/features/pricing/meters/catalog-meters
        /// </summary>
        public static async Task<PlayFabResult<CreateUploadUrlsResponse>> CreateUploadUrlsAsync(CreateUploadUrlsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Catalog/CreateUploadUrls", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<CreateUploadUrlsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<CreateUploadUrlsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<CreateUploadUrlsResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Deletes all reviews, helpfulness votes, and ratings submitted by the entity specified.
        /// </summary>
        public static async Task<PlayFabResult<DeleteEntityItemReviewsResponse>> DeleteEntityItemReviewsAsync(DeleteEntityItemReviewsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Catalog/DeleteEntityItemReviews", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<DeleteEntityItemReviewsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<DeleteEntityItemReviewsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<DeleteEntityItemReviewsResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Delete an Inventory Collection. More information about Inventory Collections can be found here:
        /// https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/inventory/collections
        /// </summary>
        public static async Task<PlayFabResult<DeleteInventoryCollectionResponse>> DeleteInventoryCollectionAsync(DeleteInventoryCollectionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Inventory/DeleteInventoryCollection", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<DeleteInventoryCollectionResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<DeleteInventoryCollectionResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<DeleteInventoryCollectionResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Delete inventory items
        /// </summary>
        public static async Task<PlayFabResult<DeleteInventoryItemsResponse>> DeleteInventoryItemsAsync(DeleteInventoryItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Inventory/DeleteInventoryItems", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<DeleteInventoryItemsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<DeleteInventoryItemsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<DeleteInventoryItemsResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Removes an item from working catalog and all published versions from the public catalog.
        /// </summary>
        public static async Task<PlayFabResult<DeleteItemResponse>> DeleteItemAsync(DeleteItemRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Catalog/DeleteItem", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<DeleteItemResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<DeleteItemResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<DeleteItemResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Execute a list of Inventory Operations. A maximum list of 50 operations can be performed by a single request. There is
        /// also a limit to 300 items that can be modified/added in a single request. For example, adding a bundle with 50 items
        /// counts as 50 items modified. All operations must be done within a single inventory collection. This API has a reduced
        /// RPS compared to an individual inventory operation with Player Entities limited to 60 requests in 90 seconds.
        /// </summary>
        public static async Task<PlayFabResult<ExecuteInventoryOperationsResponse>> ExecuteInventoryOperationsAsync(ExecuteInventoryOperationsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Inventory/ExecuteInventoryOperations", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ExecuteInventoryOperationsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ExecuteInventoryOperationsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ExecuteInventoryOperationsResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Transfer a list of inventory items. A maximum list of 50 operations can be performed by a single request. When the
        /// response code is 202, one or more operations did not complete within the timeframe of the request. You can identify the
        /// pending operations by looking for OperationStatus = 'InProgress'. You can check on the operation status at anytime
        /// within 1 day of the request by passing the TransactionToken to the GetInventoryOperationStatus API.
        /// </summary>
        public static async Task<PlayFabResult<ExecuteTransferOperationsResponse>> ExecuteTransferOperationsAsync(ExecuteTransferOperationsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Inventory/ExecuteTransferOperations", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ExecuteTransferOperationsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ExecuteTransferOperationsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ExecuteTransferOperationsResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Gets the configuration for the catalog. Only Title Entities can call this API. There is a limit of 100 requests in 10
        /// seconds for this API. More information about the Catalog Config can be found here:
        /// https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/settings
        /// </summary>
        public static async Task<PlayFabResult<GetCatalogConfigResponse>> GetCatalogConfigAsync(GetCatalogConfigRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Catalog/GetCatalogConfig", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetCatalogConfigResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetCatalogConfigResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetCatalogConfigResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves an item from the working catalog. This item represents the current working state of the item. GetDraftItem
        /// does not work off a cache of the Catalog and should be used when trying to get recent item updates. However, please note
        /// that item references data is cached and may take a few moments for changes to propagate. Note: SAS tokens provided are
        /// valid for 1 hour.
        /// </summary>
        public static async Task<PlayFabResult<GetDraftItemResponse>> GetDraftItemAsync(GetDraftItemRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Catalog/GetDraftItem", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetDraftItemResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetDraftItemResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetDraftItemResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves a paginated list of the items from the draft catalog. Up to 50 IDs can be retrieved in a single request.
        /// GetDraftItems does not work off a cache of the Catalog and should be used when trying to get recent item updates. Note:
        /// SAS tokens provided are valid for 1 hour.
        /// </summary>
        public static async Task<PlayFabResult<GetDraftItemsResponse>> GetDraftItemsAsync(GetDraftItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Catalog/GetDraftItems", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetDraftItemsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetDraftItemsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetDraftItemsResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves a paginated list of the items from the draft catalog created by the Entity. Up to 50 items can be returned at
        /// once. You can use continuation tokens to paginate through results that return greater than the limit.
        /// GetEntityDraftItems does not work off a cache of the Catalog and should be used when trying to get recent item updates.
        /// </summary>
        public static async Task<PlayFabResult<GetEntityDraftItemsResponse>> GetEntityDraftItemsAsync(GetEntityDraftItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Catalog/GetEntityDraftItems", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetEntityDraftItemsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetEntityDraftItemsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetEntityDraftItemsResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Gets the submitted review for the specified item by the authenticated entity. Individual ratings and reviews data update
        /// in near real time with delays within a few seconds.
        /// </summary>
        public static async Task<PlayFabResult<GetEntityItemReviewResponse>> GetEntityItemReviewAsync(GetEntityItemReviewRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Catalog/GetEntityItemReview", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetEntityItemReviewResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetEntityItemReviewResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetEntityItemReviewResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Get Inventory Collection Ids. Up to 50 Ids can be returned at once (or 250 with response compression enabled). You can
        /// use continuation tokens to paginate through results that return greater than the limit. It can take a few seconds for
        /// new collection Ids to show up.
        /// </summary>
        public static async Task<PlayFabResult<GetInventoryCollectionIdsResponse>> GetInventoryCollectionIdsAsync(GetInventoryCollectionIdsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Inventory/GetInventoryCollectionIds", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetInventoryCollectionIdsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetInventoryCollectionIdsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetInventoryCollectionIdsResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Get current inventory items.
        /// </summary>
        public static async Task<PlayFabResult<GetInventoryItemsResponse>> GetInventoryItemsAsync(GetInventoryItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Inventory/GetInventoryItems", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetInventoryItemsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetInventoryItemsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetInventoryItemsResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Get the status of an inventory operation using an OperationToken. You can check on the operation status at anytime
        /// within 1 day of the request by passing the TransactionToken to the this API.
        /// </summary>
        public static async Task<PlayFabResult<GetInventoryOperationStatusResponse>> GetInventoryOperationStatusAsync(GetInventoryOperationStatusRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Inventory/GetInventoryOperationStatus", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetInventoryOperationStatusResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetInventoryOperationStatusResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetInventoryOperationStatusResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves an item from the public catalog. GetItem does not work off a cache of the Catalog and should be used when
        /// trying to get recent item updates. However, please note that item references data is cached and may take a few moments
        /// for changes to propagate.
        /// </summary>
        public static async Task<PlayFabResult<GetItemResponse>> GetItemAsync(GetItemRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Catalog/GetItem", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetItemResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetItemResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetItemResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Search for a given item and return a set of bundles and stores containing the item. Up to 50 items can be returned at
        /// once. You can use continuation tokens to paginate through results that return greater than the limit. This API is
        /// intended for tooling/automation scenarios and has a reduced RPS with Player Entities limited to 30 requests in 300
        /// seconds and Title Entities limited to 100 requests in 10 seconds.
        /// </summary>
        public static async Task<PlayFabResult<GetItemContainersResponse>> GetItemContainersAsync(GetItemContainersRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Catalog/GetItemContainers", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetItemContainersResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetItemContainersResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetItemContainersResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Gets the moderation state for an item, including the concern category and string reason. More information about
        /// moderation states can be found here: https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/ugc/moderation
        /// </summary>
        public static async Task<PlayFabResult<GetItemModerationStateResponse>> GetItemModerationStateAsync(GetItemModerationStateRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Catalog/GetItemModerationState", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetItemModerationStateResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetItemModerationStateResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetItemModerationStateResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Gets the status of a publish of an item.
        /// </summary>
        public static async Task<PlayFabResult<GetItemPublishStatusResponse>> GetItemPublishStatusAsync(GetItemPublishStatusRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Catalog/GetItemPublishStatus", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetItemPublishStatusResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetItemPublishStatusResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetItemPublishStatusResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Get a paginated set of reviews associated with the specified item. Individual ratings and reviews data update in near
        /// real time with delays within a few seconds.
        /// </summary>
        public static async Task<PlayFabResult<GetItemReviewsResponse>> GetItemReviewsAsync(GetItemReviewsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Catalog/GetItemReviews", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetItemReviewsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetItemReviewsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetItemReviewsResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Get a summary of all ratings and reviews associated with the specified item. Summary ratings data is cached with update
        /// data coming within 15 minutes.
        /// </summary>
        public static async Task<PlayFabResult<GetItemReviewSummaryResponse>> GetItemReviewSummaryAsync(GetItemReviewSummaryRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Catalog/GetItemReviewSummary", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetItemReviewSummaryResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetItemReviewSummaryResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetItemReviewSummaryResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Retrieves items from the public catalog. Up to 50 items can be returned at once. GetItems does not work off a cache of
        /// the Catalog and should be used when trying to get recent item updates. However, please note that item references data is
        /// cached and may take a few moments for changes to propagate.
        /// </summary>
        public static async Task<PlayFabResult<GetItemsResponse>> GetItemsAsync(GetItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Catalog/GetItems", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetItemsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetItemsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetItemsResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Gets the access tokens.
        /// </summary>
        public static async Task<PlayFabResult<GetMicrosoftStoreAccessTokensResponse>> GetMicrosoftStoreAccessTokensAsync(GetMicrosoftStoreAccessTokensRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Inventory/GetMicrosoftStoreAccessTokens", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetMicrosoftStoreAccessTokensResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetMicrosoftStoreAccessTokensResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetMicrosoftStoreAccessTokensResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Get transaction history for a player. Up to 250 Events can be returned at once. You can use continuation tokens to
        /// paginate through results that return greater than the limit. Getting transaction history has a lower RPS limit than
        /// getting a Player's inventory with Player Entities having a limit of 30 requests in 300 seconds.
        /// </summary>
        public static async Task<PlayFabResult<GetTransactionHistoryResponse>> GetTransactionHistoryAsync(GetTransactionHistoryRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Inventory/GetTransactionHistory", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetTransactionHistoryResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetTransactionHistoryResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetTransactionHistoryResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Initiates a publish of an item from the working catalog to the public catalog. You can use the GetItemPublishStatus API
        /// to track the state of the item publish.
        /// </summary>
        public static async Task<PlayFabResult<PublishDraftItemResponse>> PublishDraftItemAsync(PublishDraftItemRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Catalog/PublishDraftItem", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<PublishDraftItemResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<PublishDraftItemResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<PublishDraftItemResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Purchase an item or bundle. Up to 10,000 stacks of items can be added to a single inventory collection. Stack size is
        /// uncapped.
        /// </summary>
        public static async Task<PlayFabResult<PurchaseInventoryItemsResponse>> PurchaseInventoryItemsAsync(PurchaseInventoryItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Inventory/PurchaseInventoryItems", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<PurchaseInventoryItemsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<PurchaseInventoryItemsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<PurchaseInventoryItemsResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Redeem items.
        /// </summary>
        public static async Task<PlayFabResult<RedeemAppleAppStoreInventoryItemsResponse>> RedeemAppleAppStoreInventoryItemsAsync(RedeemAppleAppStoreInventoryItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Inventory/RedeemAppleAppStoreInventoryItems", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<RedeemAppleAppStoreInventoryItemsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<RedeemAppleAppStoreInventoryItemsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<RedeemAppleAppStoreInventoryItemsResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Redeem items.
        /// </summary>
        public static async Task<PlayFabResult<RedeemGooglePlayInventoryItemsResponse>> RedeemGooglePlayInventoryItemsAsync(RedeemGooglePlayInventoryItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Inventory/RedeemGooglePlayInventoryItems", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<RedeemGooglePlayInventoryItemsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<RedeemGooglePlayInventoryItemsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<RedeemGooglePlayInventoryItemsResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Redeem items.
        /// </summary>
        public static async Task<PlayFabResult<RedeemMicrosoftStoreInventoryItemsResponse>> RedeemMicrosoftStoreInventoryItemsAsync(RedeemMicrosoftStoreInventoryItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Inventory/RedeemMicrosoftStoreInventoryItems", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<RedeemMicrosoftStoreInventoryItemsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<RedeemMicrosoftStoreInventoryItemsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<RedeemMicrosoftStoreInventoryItemsResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Redeem items.
        /// </summary>
        public static async Task<PlayFabResult<RedeemNintendoEShopInventoryItemsResponse>> RedeemNintendoEShopInventoryItemsAsync(RedeemNintendoEShopInventoryItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Inventory/RedeemNintendoEShopInventoryItems", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<RedeemNintendoEShopInventoryItemsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<RedeemNintendoEShopInventoryItemsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<RedeemNintendoEShopInventoryItemsResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Redeem items.
        /// </summary>
        public static async Task<PlayFabResult<RedeemPlayStationStoreInventoryItemsResponse>> RedeemPlayStationStoreInventoryItemsAsync(RedeemPlayStationStoreInventoryItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Inventory/RedeemPlayStationStoreInventoryItems", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<RedeemPlayStationStoreInventoryItemsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<RedeemPlayStationStoreInventoryItemsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<RedeemPlayStationStoreInventoryItemsResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Redeem items.
        /// </summary>
        public static async Task<PlayFabResult<RedeemSteamInventoryItemsResponse>> RedeemSteamInventoryItemsAsync(RedeemSteamInventoryItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Inventory/RedeemSteamInventoryItems", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<RedeemSteamInventoryItemsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<RedeemSteamInventoryItemsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<RedeemSteamInventoryItemsResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Submit a report for an item, indicating in what way the item is inappropriate.
        /// </summary>
        public static async Task<PlayFabResult<ReportItemResponse>> ReportItemAsync(ReportItemRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Catalog/ReportItem", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ReportItemResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ReportItemResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ReportItemResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Submit a report for a review
        /// </summary>
        public static async Task<PlayFabResult<ReportItemReviewResponse>> ReportItemReviewAsync(ReportItemReviewRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Catalog/ReportItemReview", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ReportItemReviewResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ReportItemReviewResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ReportItemReviewResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Creates or updates a review for the specified item. More information around the caching surrounding item ratings and
        /// reviews can be found here:
        /// https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/catalog/ratings#ratings-design-and-caching
        /// </summary>
        public static async Task<PlayFabResult<ReviewItemResponse>> ReviewItemAsync(ReviewItemRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Catalog/ReviewItem", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ReviewItemResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ReviewItemResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ReviewItemResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Executes a search against the public catalog using the provided search parameters and returns a set of paginated
        /// results. SearchItems uses a cache of the catalog with item updates taking up to a few minutes to propagate. You should
        /// use the GetItem API for when trying to immediately get recent item updates. More information about the Search API can be
        /// found here: https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/catalog/search
        /// </summary>
        public static async Task<PlayFabResult<SearchItemsResponse>> SearchItemsAsync(SearchItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Catalog/SearchItems", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<SearchItemsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<SearchItemsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<SearchItemsResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Sets the moderation state for an item, including the concern category and string reason. More information about
        /// moderation states can be found here: https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/ugc/moderation
        /// </summary>
        public static async Task<PlayFabResult<SetItemModerationStateResponse>> SetItemModerationStateAsync(SetItemModerationStateRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Catalog/SetItemModerationState", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<SetItemModerationStateResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<SetItemModerationStateResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<SetItemModerationStateResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Submit a vote for a review, indicating whether the review was helpful or unhelpful.
        /// </summary>
        public static async Task<PlayFabResult<SubmitItemReviewVoteResponse>> SubmitItemReviewVoteAsync(SubmitItemReviewVoteRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Catalog/SubmitItemReviewVote", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<SubmitItemReviewVoteResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<SubmitItemReviewVoteResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<SubmitItemReviewVoteResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Subtract inventory items.
        /// </summary>
        public static async Task<PlayFabResult<SubtractInventoryItemsResponse>> SubtractInventoryItemsAsync(SubtractInventoryItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Inventory/SubtractInventoryItems", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<SubtractInventoryItemsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<SubtractInventoryItemsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<SubtractInventoryItemsResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Submit a request to takedown one or more reviews.
        /// </summary>
        public static async Task<PlayFabResult<TakedownItemReviewsResponse>> TakedownItemReviewsAsync(TakedownItemReviewsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Catalog/TakedownItemReviews", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<TakedownItemReviewsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<TakedownItemReviewsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<TakedownItemReviewsResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Transfer inventory items. When transferring across collections, a 202 response indicates that the transfer did not
        /// complete within the timeframe of the request. You can identify the pending operations by looking for OperationStatus =
        /// 'InProgress'. You can check on the operation status at anytime within 1 day of the request by passing the
        /// TransactionToken to the GetInventoryOperationStatus API. More information about item transfer scenarios can be found
        /// here:
        /// https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/inventory/?tabs=inventory-game-manager#transfer-inventory-items
        /// </summary>
        public static async Task<PlayFabResult<TransferInventoryItemsResponse>> TransferInventoryItemsAsync(TransferInventoryItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Inventory/TransferInventoryItems", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<TransferInventoryItemsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<TransferInventoryItemsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<TransferInventoryItemsResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Updates the configuration for the catalog. Only Title Entities can call this API. There is a limit of 10 requests in 10
        /// seconds for this API. More information about the Catalog Config can be found here:
        /// https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/settings
        /// </summary>
        public static async Task<PlayFabResult<UpdateCatalogConfigResponse>> UpdateCatalogConfigAsync(UpdateCatalogConfigRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Catalog/UpdateCatalogConfig", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<UpdateCatalogConfigResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<UpdateCatalogConfigResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<UpdateCatalogConfigResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Update the metadata for an item in the working catalog. Note: SAS tokens provided are valid for 1 hour.
        /// </summary>
        public static async Task<PlayFabResult<UpdateDraftItemResponse>> UpdateDraftItemAsync(UpdateDraftItemRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Catalog/UpdateDraftItem", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<UpdateDraftItemResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<UpdateDraftItemResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<UpdateDraftItemResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Update inventory items
        /// </summary>
        public static async Task<PlayFabResult<UpdateInventoryItemsResponse>> UpdateInventoryItemsAsync(UpdateInventoryItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            await new PlayFabUtil.SynchronizationContextRemover();

            var requestContext = request?.AuthenticationContext ?? PlayFabSettings.staticPlayer;
            var requestSettings = PlayFabSettings.staticSettings;
            if (requestContext.EntityToken == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call Client Login or GetEntityToken before calling this method");


            var httpResult = await PlayFabHttp.DoPost("/Inventory/UpdateInventoryItems", request, "X-EntityToken", requestContext.EntityToken, extraHeaders);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<UpdateInventoryItemsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<UpdateInventoryItemsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<UpdateInventoryItemsResponse> { Result = result, CustomData = customData };
        }
}
}
#endif
