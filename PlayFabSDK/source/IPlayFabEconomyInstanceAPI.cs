using PlayFab.EconomyModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayFab
{
    /// <summary>
    /// Interface for PlayFab Economy Instance API, providing methods for managing inventory, catalog items, transactions, and reviews.
    /// </summary>
    public interface IPlayFabEconomyInstanceAPI
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
        /// Adds inventory items to an entity.
        /// </summary>
        Task<PlayFabResult<AddInventoryItemsResponse>> AddInventoryItemsAsync(AddInventoryItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Creates a draft item in the catalog.
        /// </summary>
        Task<PlayFabResult<CreateDraftItemResponse>> CreateDraftItemAsync(CreateDraftItemRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Creates upload URLs for item content.
        /// </summary>
        Task<PlayFabResult<CreateUploadUrlsResponse>> CreateUploadUrlsAsync(CreateUploadUrlsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes all reviews for a specific item by an entity.
        /// </summary>
        Task<PlayFabResult<DeleteEntityItemReviewsResponse>> DeleteEntityItemReviewsAsync(DeleteEntityItemReviewsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes an inventory collection for an entity.
        /// </summary>
        Task<PlayFabResult<DeleteInventoryCollectionResponse>> DeleteInventoryCollectionAsync(DeleteInventoryCollectionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes inventory items from an entity.
        /// </summary>
        Task<PlayFabResult<DeleteInventoryItemsResponse>> DeleteInventoryItemsAsync(DeleteInventoryItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes an item from the catalog.
        /// </summary>
        Task<PlayFabResult<DeleteItemResponse>> DeleteItemAsync(DeleteItemRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Executes a list of inventory operations for an entity.
        /// </summary>
        Task<PlayFabResult<ExecuteInventoryOperationsResponse>> ExecuteInventoryOperationsAsync(ExecuteInventoryOperationsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Executes transfer operations for inventory items between entities.
        /// </summary>
        Task<PlayFabResult<ExecuteTransferOperationsResponse>> ExecuteTransferOperationsAsync(ExecuteTransferOperationsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the catalog configuration.
        /// </summary>
        Task<PlayFabResult<GetCatalogConfigResponse>> GetCatalogConfigAsync(GetCatalogConfigRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets a draft item from the catalog.
        /// </summary>
        Task<PlayFabResult<GetDraftItemResponse>> GetDraftItemAsync(GetDraftItemRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets a list of draft items from the catalog.
        /// </summary>
        Task<PlayFabResult<GetDraftItemsResponse>> GetDraftItemsAsync(GetDraftItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets draft items for a specific entity.
        /// </summary>
        Task<PlayFabResult<GetEntityDraftItemsResponse>> GetEntityDraftItemsAsync(GetEntityDraftItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets a review for an item by an entity.
        /// </summary>
        Task<PlayFabResult<GetEntityItemReviewResponse>> GetEntityItemReviewAsync(GetEntityItemReviewRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets inventory collection IDs for an entity.
        /// </summary>
        Task<PlayFabResult<GetInventoryCollectionIdsResponse>> GetInventoryCollectionIdsAsync(GetInventoryCollectionIdsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets inventory items for an entity.
        /// </summary>
        Task<PlayFabResult<GetInventoryItemsResponse>> GetInventoryItemsAsync(GetInventoryItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the status of an inventory operation.
        /// </summary>
        Task<PlayFabResult<GetInventoryOperationStatusResponse>> GetInventoryOperationStatusAsync(GetInventoryOperationStatusRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets an item from the catalog.
        /// </summary>
        Task<PlayFabResult<GetItemResponse>> GetItemAsync(GetItemRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets containers and stores containing a specific item.
        /// </summary>
        Task<PlayFabResult<GetItemContainersResponse>> GetItemContainersAsync(GetItemContainersRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the moderation state of an item.
        /// </summary>
        Task<PlayFabResult<GetItemModerationStateResponse>> GetItemModerationStateAsync(GetItemModerationStateRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the publish status of an item.
        /// </summary>
        Task<PlayFabResult<GetItemPublishStatusResponse>> GetItemPublishStatusAsync(GetItemPublishStatusRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets reviews for a specific item.
        /// </summary>
        Task<PlayFabResult<GetItemReviewsResponse>> GetItemReviewsAsync(GetItemReviewsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets the review summary for a specific item.
        /// </summary>
        Task<PlayFabResult<GetItemReviewSummaryResponse>> GetItemReviewSummaryAsync(GetItemReviewSummaryRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets multiple items from the catalog.
        /// </summary>
        Task<PlayFabResult<GetItemsResponse>> GetItemsAsync(GetItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets Microsoft Store access tokens for authentication.
        /// </summary>
        Task<PlayFabResult<GetMicrosoftStoreAccessTokensResponse>> GetMicrosoftStoreAccessTokensAsync(GetMicrosoftStoreAccessTokensRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets transaction history for an entity and collection.
        /// </summary>
        Task<PlayFabResult<GetTransactionHistoryResponse>> GetTransactionHistoryAsync(GetTransactionHistoryRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Publishes a draft item to the public catalog.
        /// </summary>
        Task<PlayFabResult<PublishDraftItemResponse>> PublishDraftItemAsync(PublishDraftItemRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Purchases inventory items for an entity.
        /// </summary>
        Task<PlayFabResult<PurchaseInventoryItemsResponse>> PurchaseInventoryItemsAsync(PurchaseInventoryItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Redeems inventory items from the Apple App Store.
        /// </summary>
        Task<PlayFabResult<RedeemAppleAppStoreInventoryItemsResponse>> RedeemAppleAppStoreInventoryItemsAsync(RedeemAppleAppStoreInventoryItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Redeems inventory items from the Google Play Store.
        /// </summary>
        Task<PlayFabResult<RedeemGooglePlayInventoryItemsResponse>> RedeemGooglePlayInventoryItemsAsync(RedeemGooglePlayInventoryItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Redeems inventory items from the Microsoft Store.
        /// </summary>
        Task<PlayFabResult<RedeemMicrosoftStoreInventoryItemsResponse>> RedeemMicrosoftStoreInventoryItemsAsync(RedeemMicrosoftStoreInventoryItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Redeems inventory items from the Nintendo EShop.
        /// </summary>
        Task<PlayFabResult<RedeemNintendoEShopInventoryItemsResponse>> RedeemNintendoEShopInventoryItemsAsync(RedeemNintendoEShopInventoryItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Redeems inventory items from the PlayStation Store.
        /// </summary>
        Task<PlayFabResult<RedeemPlayStationStoreInventoryItemsResponse>> RedeemPlayStationStoreInventoryItemsAsync(RedeemPlayStationStoreInventoryItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Redeems inventory items from Steam.
        /// </summary>
        Task<PlayFabResult<RedeemSteamInventoryItemsResponse>> RedeemSteamInventoryItemsAsync(RedeemSteamInventoryItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Reports an item for inappropriate content.
        /// </summary>
        Task<PlayFabResult<ReportItemResponse>> ReportItemAsync(ReportItemRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Reports an item review for inappropriate content.
        /// </summary>
        Task<PlayFabResult<ReportItemReviewResponse>> ReportItemReviewAsync(ReportItemReviewRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Submits a review for an item.
        /// </summary>
        Task<PlayFabResult<ReviewItemResponse>> ReviewItemAsync(ReviewItemRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Searches for items in the catalog.
        /// </summary>
        Task<PlayFabResult<SearchItemsResponse>> SearchItemsAsync(SearchItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Sets the moderation state for an item.
        /// </summary>
        Task<PlayFabResult<SetItemModerationStateResponse>> SetItemModerationStateAsync(SetItemModerationStateRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Submits a vote for an item review.
        /// </summary>
        Task<PlayFabResult<SubmitItemReviewVoteResponse>> SubmitItemReviewVoteAsync(SubmitItemReviewVoteRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Subtracts inventory items from an entity.
        /// </summary>
        Task<PlayFabResult<SubtractInventoryItemsResponse>> SubtractInventoryItemsAsync(SubtractInventoryItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Takes down one or more item reviews, removing them from public view.
        /// </summary>
        Task<PlayFabResult<TakedownItemReviewsResponse>> TakedownItemReviewsAsync(TakedownItemReviewsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Transfers inventory items between entities.
        /// </summary>
        Task<PlayFabResult<TransferInventoryItemsResponse>> TransferInventoryItemsAsync(TransferInventoryItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates the catalog configuration.
        /// </summary>
        Task<PlayFabResult<UpdateCatalogConfigResponse>> UpdateCatalogConfigAsync(UpdateCatalogConfigRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates a draft item in the catalog.
        /// </summary>
        Task<PlayFabResult<UpdateDraftItemResponse>> UpdateDraftItemAsync(UpdateDraftItemRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates inventory items for an entity.
        /// </summary>
        Task<PlayFabResult<UpdateInventoryItemsResponse>> UpdateInventoryItemsAsync(UpdateInventoryItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
    }
}
