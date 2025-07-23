#if !DISABLE_PLAYFABENTITY_API

using PlayFab.EconomyModels;
using PlayFab.Internal;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayFab
{
    /// <summary>
    /// API methods for managing the catalog. Inventory manages in-game assets for any given entity. API methods for managing
    /// the versioned catalogs.
    /// </summary>
    public interface IPlayFabEconomyInstanceAPI
    {
        /// <summary>
        /// Add inventory items. Up to 10,000 stacks of items can be added to a single inventory collection. Stack size is uncapped.
        /// </summary>
        Task<PlayFabResult<AddInventoryItemsResponse>> AddInventoryItemsAsync(
            AddInventoryItemsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Creates a new item in the working catalog using provided metadata. Note: SAS tokens provided are valid for 1 hour.
        /// </summary>
        Task<PlayFabResult<CreateDraftItemResponse>> CreateDraftItemAsync(
            CreateDraftItemRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Creates one or more upload URLs which can be used by the client to upload raw file data. Content URls and uploaded
        /// content will be garbage collected after 24 hours if not attached to a draft or published item. Detailed pricing info
        /// around uploading content can be found here:
        /// https://learn.microsoft.com/en-us/gaming/playfab/features/pricing/meters/catalog-meters
        /// </summary>
        Task<PlayFabResult<CreateUploadUrlsResponse>> CreateUploadUrlsAsync(
            CreateUploadUrlsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes all reviews, helpfulness votes, and ratings submitted by the entity specified.
        /// </summary>
        Task<PlayFabResult<DeleteEntityItemReviewsResponse>> DeleteEntityItemReviewsAsync(
            DeleteEntityItemReviewsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Delete an Inventory Collection. More information about Inventory Collections can be found here:
        /// https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/inventory/collections
        /// </summary>
        Task<PlayFabResult<DeleteInventoryCollectionResponse>> DeleteInventoryCollectionAsync(
            DeleteInventoryCollectionRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Delete inventory items
        /// </summary>
        Task<PlayFabResult<DeleteInventoryItemsResponse>> DeleteInventoryItemsAsync(
            DeleteInventoryItemsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Removes an item from working catalog and all published versions from the public catalog.
        /// </summary>
        Task<PlayFabResult<DeleteItemResponse>> DeleteItemAsync(
            DeleteItemRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Execute a list of Inventory Operations. A maximum list of 50 operations can be performed by a single request. There is
        /// also a limit to 300 items that can be modified/added in a single request. For example, adding a bundle with 50 items
        /// counts as 50 items modified. All operations must be done within a single inventory collection. This API has a reduced
        /// RPS compared to an individual inventory operation with Player Entities limited to 60 requests in 90 seconds.
        /// </summary>
        Task<PlayFabResult<ExecuteInventoryOperationsResponse>> ExecuteInventoryOperationsAsync(
            ExecuteInventoryOperationsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Transfer a list of inventory items. A maximum list of 50 operations can be performed by a single request. When the
        /// response code is 202, one or more operations did not complete within the timeframe of the request. You can identify the
        /// pending operations by looking for OperationStatus = 'InProgress'. You can check on the operation status at anytime
        /// within 1 day of the request by passing the TransactionToken to the GetInventoryOperationStatus API.
        /// </summary>
        Task<PlayFabResult<ExecuteTransferOperationsResponse>> ExecuteTransferOperationsAsync(
            ExecuteTransferOperationsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the configuration for the catalog. Only Title Entities can call this API. There is a limit of 100 requests in 10
        /// seconds for this API. More information about the Catalog Config can be found here:
        /// https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/settings
        /// </summary>
        Task<PlayFabResult<GetCatalogConfigResponse>> GetCatalogConfigAsync(
            GetCatalogConfigRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves an item from the working catalog. This item represents the current working state of the item. GetDraftItem
        /// does not work off a cache of the Catalog and should be used when trying to get recent item updates. However, please note
        /// that item references data is cached and may take a few moments for changes to propagate. Note: SAS tokens provided are
        /// valid for 1 hour.
        /// </summary>
        Task<PlayFabResult<GetDraftItemResponse>> GetDraftItemAsync(
            GetDraftItemRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves a paginated list of the items from the draft catalog. Up to 50 IDs can be retrieved in a single request.
        /// GetDraftItems does not work off a cache of the Catalog and should be used when trying to get recent item updates. Note:
        /// SAS tokens provided are valid for 1 hour.
        /// </summary>
        Task<PlayFabResult<GetDraftItemsResponse>> GetDraftItemsAsync(
            GetDraftItemsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves a paginated list of the items from the draft catalog created by the Entity. Up to 50 items can be returned at
        /// once. You can use continuation tokens to paginate through results that return greater than the limit.
        /// GetEntityDraftItems does not work off a cache of the Catalog and should be used when trying to get recent item updates.
        /// </summary>
        Task<PlayFabResult<GetEntityDraftItemsResponse>> GetEntityDraftItemsAsync(
            GetEntityDraftItemsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the submitted review for the specified item by the authenticated entity. Individual ratings and reviews data update
        /// in near real time with delays within a few seconds.
        /// </summary>
        Task<PlayFabResult<GetEntityItemReviewResponse>> GetEntityItemReviewAsync(
            GetEntityItemReviewRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Get Inventory Collection Ids. Up to 50 Ids can be returned at once (or 250 with response compression enabled). You can
        /// use continuation tokens to paginate through results that return greater than the limit. It can take a few seconds for
        /// new collection Ids to show up.
        /// </summary>
        Task<PlayFabResult<GetInventoryCollectionIdsResponse>> GetInventoryCollectionIdsAsync(
            GetInventoryCollectionIdsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Get current inventory items.
        /// </summary>
        Task<PlayFabResult<GetInventoryItemsResponse>> GetInventoryItemsAsync(
            GetInventoryItemsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Get the status of an inventory operation using an OperationToken. You can check on the operation status at anytime
        /// within 1 day of the request by passing the TransactionToken to the this API.
        /// </summary>
        Task<PlayFabResult<GetInventoryOperationStatusResponse>> GetInventoryOperationStatusAsync(
            GetInventoryOperationStatusRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves an item from the public catalog. GetItem does not work off a cache of the Catalog and should be used when
        /// trying to get recent item updates. However, please note that item references data is cached and may take a few moments
        /// for changes to propagate.
        /// </summary>
        Task<PlayFabResult<GetItemResponse>> GetItemAsync(
            GetItemRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Search for a given item and return a set of bundles and stores containing the item. Up to 50 items can be returned at
        /// once. You can use continuation tokens to paginate through results that return greater than the limit. This API is
        /// intended for tooling/automation scenarios and has a reduced RPS with Player Entities limited to 30 requests in 300
        /// seconds and Title Entities limited to 100 requests in 10 seconds.
        /// </summary>
        Task<PlayFabResult<GetItemContainersResponse>> GetItemContainersAsync(
            GetItemContainersRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the moderation state for an item, including the concern category and string reason. More information about
        /// moderation states can be found here: https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/ugc/moderation
        /// </summary>
        Task<PlayFabResult<GetItemModerationStateResponse>> GetItemModerationStateAsync(
            GetItemModerationStateRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the status of a publish of an item.
        /// </summary>
        Task<PlayFabResult<GetItemPublishStatusResponse>> GetItemPublishStatusAsync(
            GetItemPublishStatusRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Get a paginated set of reviews associated with the specified item. Individual ratings and reviews data update in near
        /// real time with delays within a few seconds.
        /// </summary>
        Task<PlayFabResult<GetItemReviewsResponse>> GetItemReviewsAsync(
            GetItemReviewsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Get a summary of all ratings and reviews associated with the specified item. Summary ratings data is cached with update
        /// data coming within 15 minutes.
        /// </summary>
        Task<PlayFabResult<GetItemReviewSummaryResponse>> GetItemReviewSummaryAsync(
            GetItemReviewSummaryRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Retrieves items from the public catalog. Up to 50 items can be returned at once. GetItems does not work off a cache of
        /// the Catalog and should be used when trying to get recent item updates. However, please note that item references data is
        /// cached and may take a few moments for changes to propagate.
        /// </summary>
        Task<PlayFabResult<GetItemsResponse>> GetItemsAsync(
            GetItemsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the access tokens.
        /// </summary>
        Task<PlayFabResult<GetMicrosoftStoreAccessTokensResponse>> GetMicrosoftStoreAccessTokensAsync(
            GetMicrosoftStoreAccessTokensRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Get transaction history for a player. Up to 250 Events can be returned at once. You can use continuation tokens to
        /// paginate through results that return greater than the limit. Getting transaction history has a lower RPS limit than
        /// getting a Player's inventory with Player Entities having a limit of 30 requests in 300 seconds.
        /// </summary>
        Task<PlayFabResult<GetTransactionHistoryResponse>> GetTransactionHistoryAsync(
            GetTransactionHistoryRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Initiates a publish of an item from the working catalog to the public catalog. You can use the GetItemPublishStatus API
        /// to track the state of the item publish.
        /// </summary>
        Task<PlayFabResult<PublishDraftItemResponse>> PublishDraftItemAsync(
            PublishDraftItemRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Purchase an item or bundle. Up to 10,000 stacks of items can be added to a single inventory collection. Stack size is
        /// uncapped.
        /// </summary>
        Task<PlayFabResult<PurchaseInventoryItemsResponse>> PurchaseInventoryItemsAsync(
            PurchaseInventoryItemsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Redeem items.
        /// </summary>
        Task<PlayFabResult<RedeemAppleAppStoreInventoryItemsResponse>> RedeemAppleAppStoreInventoryItemsAsync(
            RedeemAppleAppStoreInventoryItemsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Redeem items.
        /// </summary>
        Task<PlayFabResult<RedeemGooglePlayInventoryItemsResponse>> RedeemGooglePlayInventoryItemsAsync(
            RedeemGooglePlayInventoryItemsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Redeem items.
        /// </summary>
        Task<PlayFabResult<RedeemMicrosoftStoreInventoryItemsResponse>> RedeemMicrosoftStoreInventoryItemsAsync(
            RedeemMicrosoftStoreInventoryItemsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Redeem items.
        /// </summary>
        Task<PlayFabResult<RedeemNintendoEShopInventoryItemsResponse>> RedeemNintendoEShopInventoryItemsAsync(
            RedeemNintendoEShopInventoryItemsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Redeem items.
        /// </summary>
        Task<PlayFabResult<RedeemPlayStationStoreInventoryItemsResponse>> RedeemPlayStationStoreInventoryItemsAsync(
            RedeemPlayStationStoreInventoryItemsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Redeem items.
        /// </summary>
        Task<PlayFabResult<RedeemSteamInventoryItemsResponse>> RedeemSteamInventoryItemsAsync(
            RedeemSteamInventoryItemsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Submit a report for an item, indicating in what way the item is inappropriate.
        /// </summary>
        Task<PlayFabResult<ReportItemResponse>> ReportItemAsync(
            ReportItemRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Submit a report for a review
        /// </summary>
        Task<PlayFabResult<ReportItemReviewResponse>> ReportItemReviewAsync(
            ReportItemReviewRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Creates or updates a review for the specified item. More information around the caching surrounding item ratings and
        /// reviews can be found here:
        /// https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/catalog/ratings#ratings-design-and-caching
        /// </summary>
        Task<PlayFabResult<ReviewItemResponse>> ReviewItemAsync(
            ReviewItemRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Executes a search against the public catalog using the provided search parameters and returns a set of paginated
        /// results. SearchItems uses a cache of the catalog with item updates taking up to a few minutes to propagate. You should
        /// use the GetItem API for when trying to immediately get recent item updates. More information about the Search API can be
        /// found here: https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/catalog/search
        /// </summary>
        Task<PlayFabResult<SearchItemsResponse>> SearchItemsAsync(
            SearchItemsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Sets the moderation state for an item, including the concern category and string reason. More information about
        /// moderation states can be found here: https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/ugc/moderation
        /// </summary>
        Task<PlayFabResult<SetItemModerationStateResponse>> SetItemModerationStateAsync(
            SetItemModerationStateRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Submit a vote for a review, indicating whether the review was helpful or unhelpful.
        /// </summary>
        Task<PlayFabResult<SubmitItemReviewVoteResponse>> SubmitItemReviewVoteAsync(
            SubmitItemReviewVoteRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Subtract inventory items.
        /// </summary>
        Task<PlayFabResult<SubtractInventoryItemsResponse>> SubtractInventoryItemsAsync(
            SubtractInventoryItemsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Submit a request to takedown one or more reviews.
        /// </summary>
        Task<PlayFabResult<TakedownItemReviewsResponse>> TakedownItemReviewsAsync(
            TakedownItemReviewsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Transfer inventory items. When transferring across collections, a 202 response indicates that the transfer did not
        /// complete within the timeframe of the request. You can identify the pending operations by looking for OperationStatus =
        /// 'InProgress'. You can check on the operation status at anytime within 1 day of the request by passing the
        /// TransactionToken to the GetInventoryOperationStatus API. More information about item transfer scenarios can be found
        /// here:
        /// https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/inventory/?tabs=inventory-game-manager#transfer-inventory-items
        /// </summary>
        Task<PlayFabResult<TransferInventoryItemsResponse>> TransferInventoryItemsAsync(
            TransferInventoryItemsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates the configuration for the catalog. Only Title Entities can call this API. There is a limit of 10 requests in 10
        /// seconds for this API. More information about the Catalog Config can be found here:
        /// https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/settings
        /// </summary>
        Task<PlayFabResult<UpdateCatalogConfigResponse>> UpdateCatalogConfigAsync(
            UpdateCatalogConfigRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Update the metadata for an item in the working catalog. Note: SAS tokens provided are valid for 1 hour.
        /// </summary>
        Task<PlayFabResult<UpdateDraftItemResponse>> UpdateDraftItemAsync(
            UpdateDraftItemRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Update inventory items
        /// </summary>
        Task<PlayFabResult<UpdateInventoryItemsResponse>> UpdateInventoryItemsAsync(
            UpdateInventoryItemsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);
    }
}
#endif
