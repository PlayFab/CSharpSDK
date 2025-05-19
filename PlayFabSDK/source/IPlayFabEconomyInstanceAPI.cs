using PlayFab.EconomyModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayFab
{
    public interface IPlayFabEconomyInstanceAPI
    {
        bool IsEntityLoggedIn();
        void ForgetAllCredentials();
        Task<PlayFabResult<AddInventoryItemsResponse>> AddInventoryItemsAsync(AddInventoryItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<CreateDraftItemResponse>> CreateDraftItemAsync(CreateDraftItemRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<CreateUploadUrlsResponse>> CreateUploadUrlsAsync(CreateUploadUrlsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<DeleteEntityItemReviewsResponse>> DeleteEntityItemReviewsAsync(DeleteEntityItemReviewsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<DeleteInventoryCollectionResponse>> DeleteInventoryCollectionAsync(DeleteInventoryCollectionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<DeleteInventoryItemsResponse>> DeleteInventoryItemsAsync(DeleteInventoryItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<DeleteItemResponse>> DeleteItemAsync(DeleteItemRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<ExecuteInventoryOperationsResponse>> ExecuteInventoryOperationsAsync(ExecuteInventoryOperationsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<ExecuteTransferOperationsResponse>> ExecuteTransferOperationsAsync(ExecuteTransferOperationsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<GetCatalogConfigResponse>> GetCatalogConfigAsync(GetCatalogConfigRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<GetDraftItemResponse>> GetDraftItemAsync(GetDraftItemRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<GetDraftItemsResponse>> GetDraftItemsAsync(GetDraftItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<GetEntityDraftItemsResponse>> GetEntityDraftItemsAsync(GetEntityDraftItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<GetEntityItemReviewResponse>> GetEntityItemReviewAsync(GetEntityItemReviewRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<GetInventoryCollectionIdsResponse>> GetInventoryCollectionIdsAsync(GetInventoryCollectionIdsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<GetInventoryItemsResponse>> GetInventoryItemsAsync(GetInventoryItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<GetInventoryOperationStatusResponse>> GetInventoryOperationStatusAsync(GetInventoryOperationStatusRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<GetItemResponse>> GetItemAsync(GetItemRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<GetItemContainersResponse>> GetItemContainersAsync(GetItemContainersRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<GetItemModerationStateResponse>> GetItemModerationStateAsync(GetItemModerationStateRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<GetItemPublishStatusResponse>> GetItemPublishStatusAsync(GetItemPublishStatusRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<GetItemReviewsResponse>> GetItemReviewsAsync(GetItemReviewsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<GetItemReviewSummaryResponse>> GetItemReviewSummaryAsync(GetItemReviewSummaryRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<GetItemsResponse>> GetItemsAsync(GetItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<GetMicrosoftStoreAccessTokensResponse>> GetMicrosoftStoreAccessTokensAsync(GetMicrosoftStoreAccessTokensRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<GetTransactionHistoryResponse>> GetTransactionHistoryAsync(GetTransactionHistoryRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<PublishDraftItemResponse>> PublishDraftItemAsync(PublishDraftItemRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<PurchaseInventoryItemsResponse>> PurchaseInventoryItemsAsync(PurchaseInventoryItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<RedeemAppleAppStoreInventoryItemsResponse>> RedeemAppleAppStoreInventoryItemsAsync(RedeemAppleAppStoreInventoryItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<RedeemGooglePlayInventoryItemsResponse>> RedeemGooglePlayInventoryItemsAsync(RedeemGooglePlayInventoryItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<RedeemMicrosoftStoreInventoryItemsResponse>> RedeemMicrosoftStoreInventoryItemsAsync(RedeemMicrosoftStoreInventoryItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<RedeemNintendoEShopInventoryItemsResponse>> RedeemNintendoEShopInventoryItemsAsync(RedeemNintendoEShopInventoryItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<RedeemPlayStationStoreInventoryItemsResponse>> RedeemPlayStationStoreInventoryItemsAsync(RedeemPlayStationStoreInventoryItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<RedeemSteamInventoryItemsResponse>> RedeemSteamInventoryItemsAsync(RedeemSteamInventoryItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<ReportItemResponse>> ReportItemAsync(ReportItemRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<ReportItemReviewResponse>> ReportItemReviewAsync(ReportItemReviewRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<ReviewItemResponse>> ReviewItemAsync(ReviewItemRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<SearchItemsResponse>> SearchItemsAsync(SearchItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<SetItemModerationStateResponse>> SetItemModerationStateAsync(SetItemModerationStateRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<SubmitItemReviewVoteResponse>> SubmitItemReviewVoteAsync(SubmitItemReviewVoteRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<SubtractInventoryItemsResponse>> SubtractInventoryItemsAsync(SubtractInventoryItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<TakedownItemReviewsResponse>> TakedownItemReviewsAsync(TakedownItemReviewsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<TransferInventoryItemsResponse>> TransferInventoryItemsAsync(TransferInventoryItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<UpdateCatalogConfigResponse>> UpdateCatalogConfigAsync(UpdateCatalogConfigRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<UpdateDraftItemResponse>> UpdateDraftItemAsync(UpdateDraftItemRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<UpdateInventoryItemsResponse>> UpdateInventoryItemsAsync(UpdateInventoryItemsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
    }
}
