using PlayFab.Internal;
using System;
using System.Collections.Generic;

namespace PlayFab.EconomyModels
{
    public class CatalogAlternateId
    {
        /// <summary>
        /// Type of the alternate ID.
        /// </summary>
        public string Type ;

        /// <summary>
        /// Value of the alternate ID.
        /// </summary>
        public string Value ;

    }

    public class CatalogConfig
    {
        /// <summary>
        /// A list of player entity keys that will have admin permissions.
        /// </summary>
        public List<EntityKey> AdminEntities ;

        /// <summary>
        /// A list of display properties to index.
        /// </summary>
        public List<DisplayPropertyIndexInfo> DisplayPropertyIndexInfos ;

        /// <summary>
        /// The set of configuration that only applies to Files.
        /// </summary>
        public FileConfig File ;

        /// <summary>
        /// The set of configuration that only applies to Images.
        /// </summary>
        public ImageConfig Image ;

        /// <summary>
        /// Flag defining whether catalog is enabled.
        /// </summary>
        public bool IsCatalogEnabled ;

        /// <summary>
        /// A list of Platforms that can be applied to catalog items.
        /// </summary>
        public List<string> Platforms ;

        /// <summary>
        /// A set of player entity keys that are allowed to review content.
        /// </summary>
        public List<EntityKey> ReviewerEntities ;

        /// <summary>
        /// The set of configuration that only applies to user generated contents.
        /// </summary>
        public UserGeneratedContentSpecificConfig UserGeneratedContent ;

    }

    public class CatalogItem
    {
        /// <summary>
        /// The alternate IDs associated with this item.
        /// </summary>
        public List<CatalogAlternateId> AlternateIds ;

        /// <summary>
        /// The set of contents associated with this item.
        /// </summary>
        public List<Content> Contents ;

        /// <summary>
        /// The client-defined type of the item.
        /// </summary>
        public string ContentType ;

        /// <summary>
        /// The date and time when this item was created.
        /// </summary>
        public DateTime? CreationDate ;

        /// <summary>
        /// The ID of the creator of this catalog item.
        /// </summary>
        public EntityKey CreatorEntity ;

        /// <summary>
        /// A dictionary of localized descriptions. Key is language code and localized string is the value. The neutral locale is
        /// required.
        /// </summary>
        public Dictionary<string,string> Description ;

        /// <summary>
        /// Game specific properties for display purposes. This is an arbitrary JSON blob.
        /// </summary>
        public object DisplayProperties ;

        /// <summary>
        /// The user provided version of the item for display purposes.
        /// </summary>
        public string DisplayVersion ;

        /// <summary>
        /// The date of when the item will cease to be available. If not provided then the product will be available indefinitely.
        /// </summary>
        public DateTime? EndDate ;

        /// <summary>
        /// The current ETag value that can be used for optimistic concurrency in the If-None-Match header.
        /// </summary>
        public string ETag ;

        /// <summary>
        /// The unique ID of the item.
        /// </summary>
        public string Id ;

        /// <summary>
        /// The images associated with this item. Images can be thumbnails or screenshots.
        /// </summary>
        public List<Image> Images ;

        /// <summary>
        /// Indicates if the item is hidden.
        /// </summary>
        public bool? IsHidden ;

        /// <summary>
        /// A dictionary of localized keywords. Key is language code and localized list of keywords is the value.
        /// </summary>
        public Dictionary<string,KeywordSet> Keywords ;

        /// <summary>
        /// The date and time this item was last updated.
        /// </summary>
        public DateTime? LastModifiedDate ;

        /// <summary>
        /// The moderation state for this item.
        /// </summary>
        public ModerationState Moderation ;

        /// <summary>
        /// Rating summary for this item.
        /// </summary>
        public Rating Rating ;

        /// <summary>
        /// The date of when the item will be available. If not provided then the product will appear immediately.
        /// </summary>
        public DateTime? StartDate ;

        /// <summary>
        /// The list of tags that are associated with this item.
        /// </summary>
        public List<string> Tags ;

        /// <summary>
        /// A dictionary of localized titles. Key is language code and localized string is the value. The neutral locale is
        /// required.
        /// </summary>
        public Dictionary<string,string> Title ;

        /// <summary>
        /// The high-level type of the item.
        /// </summary>
        public string Type ;

    }

    public class CatalogItemReference
    {
        /// <summary>
        /// The amount of the catalog item.
        /// </summary>
        public int? Amount ;

        /// <summary>
        /// The unique ID of the catalog item.
        /// </summary>
        public string Id ;

        /// <summary>
        /// The price of the catalog item.
        /// </summary>
        public CatalogPrice Price ;

    }

    public class CatalogPrice
    {
        /// <summary>
        /// Prices of the catalog item.
        /// </summary>
        public List<CatalogPriceInstance> Prices ;

        /// <summary>
        /// Real prices of the catalog item.
        /// </summary>
        public List<CatalogPriceInstance> RealPrices ;

        /// <summary>
        /// A standardized sorting key to allow proper sorting between items with prices in different currencies.
        /// </summary>
        public int? Sort ;

    }

    public class CatalogPriceAmount
    {
        /// <summary>
        /// The amount of the catalog price.
        /// </summary>
        public int Amount ;

        /// <summary>
        /// The Item ID of the price.
        /// </summary>
        public string Id ;

    }

    public class CatalogPriceInstance
    {
        /// <summary>
        /// The amounts of the catalog item price.
        /// </summary>
        public List<CatalogPriceAmount> Amounts ;

    }

    public class CatalogSpecificConfig
    {
        /// <summary>
        /// The set of content types that will be used for validation.
        /// </summary>
        public List<string> ContentTypes ;

        /// <summary>
        /// The set of tags that will be used for validation.
        /// </summary>
        public List<string> Tags ;

    }

    public enum ConcernCategory
    {
        None,
        OffensiveContent,
        ChildExploitation,
        MalwareOrVirus,
        PrivacyConcerns,
        MisleadingApp,
        PoorPerformance,
        ReviewResponse,
        SpamAdvertising,
        Profanity
    }

    public class Content
    {
        /// <summary>
        /// The content unique ID.
        /// </summary>
        public string Id ;

        /// <summary>
        /// The maximum client version that this content is compatible with.
        /// </summary>
        public string MaxClientVersion ;

        /// <summary>
        /// The minimum client version that this content is compatible with.
        /// </summary>
        public string MinClientVersion ;

        /// <summary>
        /// The list of tags that are associated with this content.
        /// </summary>
        public List<string> Tags ;

        /// <summary>
        /// The client-defined type of the content.
        /// </summary>
        public string Type ;

        /// <summary>
        /// The Azure CDN URL for retrieval of the catalog item binary content.
        /// </summary>
        public string Url ;

    }

    public class ContentFeed
    {
    }

    /// <summary>
    /// The item will not be published to the public catalog until the PublishItem API is called for the item.
    /// </summary>
    public class CreateDraftItemRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// Metadata describing the new catalog item to be created.
        /// </summary>
        public CatalogItem Item ;

        /// <summary>
        /// Whether the item should be published immediately.
        /// </summary>
        public bool Publish ;

    }

    public class CreateDraftItemResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Updated metadata describing the catalog item just created.
        /// </summary>
        public CatalogItem Item ;

    }

    /// <summary>
    /// Upload URLs point to Azure Blobs; clients must follow the Microsoft Azure Storage Blob Service REST API pattern for
    /// uploading content. The response contains upload URLs and IDs for each file. The IDs and URLs returned must be added to
    /// the item metadata and committed using the CreateDraftItem or UpdateDraftItem Item APIs.
    /// </summary>
    public class CreateUploadUrlsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// Description of the files to be uploaded by the client.
        /// </summary>
        public List<UploadInfo> Files ;

    }

    public class CreateUploadUrlsResponse : PlayFabResultCommon
    {
        /// <summary>
        /// List of URLs metadata for the files to be uploaded by the client.
        /// </summary>
        public List<UploadUrlMetadata> UploadUrls ;

    }

    public class DeepLinkFormat
    {
        /// <summary>
        /// The format of the deep link to return. The format should contain '{id}' to represent where the item ID should be placed.
        /// </summary>
        public string Format ;

        /// <summary>
        /// The target platform for the deep link.
        /// </summary>
        public string Platform ;

    }

    public class DeleteEntityItemReviewsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity ;

    }

    public class DeleteEntityItemReviewsResponse : PlayFabResultCommon
    {
    }

    public class DeleteItemRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// An alternate ID associated with this item.
        /// </summary>
        public CatalogAlternateId AlternateId ;

        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity ;

        /// <summary>
        /// The unique ID of the item.
        /// </summary>
        public string Id ;

    }

    public class DeleteItemResponse : PlayFabResultCommon
    {
    }

    public class DisplayPropertyIndexInfo
    {
        /// <summary>
        /// The property name in the 'DisplayProperties' property to be indexed.
        /// </summary>
        public string Name ;

        /// <summary>
        /// The type of the property to be indexed.
        /// </summary>
        public DisplayPropertyType? Type ;

    }

    public enum DisplayPropertyType
    {
        None,
        QueryDateTime,
        QueryDouble,
        QueryString,
        SearchString
    }

    /// <summary>
    /// Combined entity type and ID structure which uniquely identifies a single entity.
    /// </summary>
    public class EntityKey
    {
        /// <summary>
        /// Unique ID of the entity.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Entity type. See https://docs.microsoft.com/gaming/playfab/features/data/entities/available-built-in-entity-types
        /// </summary>
        public string Type { get; set; }

    }

    public class FileConfig
    {
        /// <summary>
        /// The set of content types that will be used for validation.
        /// </summary>
        public List<string> ContentTypes ;

        /// <summary>
        /// The set of tags that will be used for validation.
        /// </summary>
        public List<string> Tags ;

    }

    public class FilterOptions
    {
    }

    public class GetCatalogConfigRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

    }

    public class GetCatalogConfigResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The catalog configuration.
        /// </summary>
        public CatalogConfig Config ;

    }

    public class GetDraftItemRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// An alternate ID associated with this item.
        /// </summary>
        public CatalogAlternateId AlternateId ;

        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity ;

        /// <summary>
        /// The unique ID of the item.
        /// </summary>
        public string Id ;

    }

    public class GetDraftItemResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Full metadata of the catalog item requested.
        /// </summary>
        public CatalogItem Item ;

    }

    public class GetDraftItemsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// List of item alternate IDs.
        /// </summary>
        public List<CatalogAlternateId> AlternateIds ;

        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity ;

        /// <summary>
        /// List of Item Ids.
        /// </summary>
        public List<string> Ids ;

    }

    public class GetDraftItemsResponse : PlayFabResultCommon
    {
        /// <summary>
        /// An opaque token used to retrieve the next page of items, if any are available.
        /// </summary>
        public string ContinuationToken ;

        /// <summary>
        /// A set of items created by the entity.
        /// </summary>
        public List<CatalogItem> Items ;

    }

    public class GetEntityDraftItemsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// An opaque token used to retrieve the next page of items created by the caller, if any are available. Should be null on
        /// initial request.
        /// </summary>
        public string ContinuationToken ;

        /// <summary>
        /// Number of items to retrieve. Maximum page size is 10.
        /// </summary>
        public int Count ;

        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity ;

    }

    public class GetEntityDraftItemsResponse : PlayFabResultCommon
    {
        /// <summary>
        /// An opaque token used to retrieve the next page of items, if any are available.
        /// </summary>
        public string ContinuationToken ;

        /// <summary>
        /// A set of items created by the entity.
        /// </summary>
        public List<CatalogItem> Items ;

    }

    public class GetEntityItemReviewRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// An alternate ID associated with this item.
        /// </summary>
        public CatalogAlternateId AlternateId ;

        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity ;

        /// <summary>
        /// The unique ID of the item.
        /// </summary>
        public string Id ;

    }

    public class GetEntityItemReviewResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The review the entity submitted for the requested item.
        /// </summary>
        public Review Review ;

    }

    public class GetItemModerationStateRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// An alternate ID associated with this item.
        /// </summary>
        public CatalogAlternateId AlternateId ;

        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The unique ID of the item.
        /// </summary>
        public string Id ;

    }

    public class GetItemModerationStateResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The current moderation state for the requested item.
        /// </summary>
        public ModerationState State ;

    }

    public class GetItemPublishStatusRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// An alternate ID associated with this item.
        /// </summary>
        public CatalogAlternateId AlternateId ;

        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity ;

        /// <summary>
        /// The unique ID of the item.
        /// </summary>
        public string Id ;

    }

    public class GetItemPublishStatusResponse : PlayFabResultCommon
    {
        /// <summary>
        /// High level status of the published item.
        /// </summary>
        public PublishResult? Result ;

        /// <summary>
        /// Descriptive message about the current status of the publish.
        /// </summary>
        public string StatusMessage ;

    }

    public class GetItemRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// An alternate ID associated with this item.
        /// </summary>
        public CatalogAlternateId AlternateId ;

        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity ;

        /// <summary>
        /// The unique ID of the item.
        /// </summary>
        public string Id ;

    }

    /// <summary>
    /// Get item result.
    /// </summary>
    public class GetItemResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The item result.
        /// </summary>
        public CatalogItem Item ;

    }

    public class GetItemReviewsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// An alternate ID associated with this item.
        /// </summary>
        public CatalogAlternateId AlternateId ;

        /// <summary>
        /// An opaque token used to retrieve the next page of items, if any are available.
        /// </summary>
        public string ContinuationToken ;

        /// <summary>
        /// Number of items to retrieve. Maximum page size is 200. If not specified, defaults to 10.
        /// </summary>
        public int Count ;

        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The unique ID of the item.
        /// </summary>
        public string Id ;

        /// <summary>
        /// An OData orderBy used to order the results of the query.
        /// </summary>
        public string OrderBy ;

    }

    public class GetItemReviewsResponse : PlayFabResultCommon
    {
        /// <summary>
        /// An opaque token used to retrieve the next page of items, if any are available.
        /// </summary>
        public string ContinuationToken ;

        /// <summary>
        /// The paginated set of results.
        /// </summary>
        public List<Review> Reviews ;

    }

    public class GetItemReviewSummaryRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// An alternate ID associated with this item.
        /// </summary>
        public CatalogAlternateId AlternateId ;

        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The unique ID of the item.
        /// </summary>
        public string Id ;

    }

    public class GetItemReviewSummaryResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The least favorable review for this item.
        /// </summary>
        public Review LeastFavorableReview ;

        /// <summary>
        /// The most favorable review for this item.
        /// </summary>
        public Review MostFavorableReview ;

        /// <summary>
        /// The summary of ratings associated with this item.
        /// </summary>
        public Rating Rating ;

        /// <summary>
        /// The total number of reviews associated with this item.
        /// </summary>
        public int ReviewsCount ;

    }

    public class GetItemsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// List of item alternate IDs.
        /// </summary>
        public List<CatalogAlternateId> AlternateIds ;

        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity ;

        /// <summary>
        /// List of Item Ids.
        /// </summary>
        public List<string> Ids ;

    }

    public class GetItemsResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Metadata of set of items.
        /// </summary>
        public List<CatalogItem> Items ;

    }

    public enum HelpfulnessVote
    {
        None,
        UnHelpful,
        Helpful
    }

    public class Image
    {
        /// <summary>
        /// The image unique ID.
        /// </summary>
        public string Id ;

        /// <summary>
        /// The client-defined tag associated with this image.
        /// </summary>
        public string Tag ;

        /// <summary>
        /// The client-defined type of this image.
        /// </summary>
        public string Type ;

        /// <summary>
        /// The URL for retrieval of the image.
        /// </summary>
        public string Url ;

    }

    public class ImageConfig
    {
        /// <summary>
        /// The set of tags that will be used for validation.
        /// </summary>
        public List<string> Tags ;

    }

    public class KeywordSet
    {
        /// <summary>
        /// A list of localized keywords.
        /// </summary>
        public List<string> Values ;

    }

    public class ModerationState
    {
        /// <summary>
        /// The date and time this moderation state was last updated.
        /// </summary>
        public DateTime? LastModifiedDate ;

        /// <summary>
        /// The current stated reason for the associated item being moderated.
        /// </summary>
        public string Reason ;

        /// <summary>
        /// The current moderation status for the associated item.
        /// </summary>
        public ModerationStatus? Status ;

    }

    public enum ModerationStatus
    {
        Unknown,
        AwaitingModeration,
        Approved,
        Rejected
    }

    public class PayoutDetails
    {
        /// <summary>
        /// The Dev Center account ID of the payee.
        /// </summary>
        public string AccountSellerId ;

        /// <summary>
        /// The tax code for payout calculations.
        /// </summary>
        public string TaxCode ;

        /// <summary>
        /// The Universal account ID of the payee.
        /// </summary>
        public string Uaid ;

    }

    public class PriceOverride
    {
    }

    public class PricesOverride
    {
    }

    /// <summary>
    /// The call kicks off a workflow to publish the item to the public catalog. The Publish Status API should be used to
    /// monitor the publish job.
    /// </summary>
    public class PublishDraftItemRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// An alternate ID associated with this item.
        /// </summary>
        public CatalogAlternateId AlternateId ;

        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity ;

        /// <summary>
        /// ETag of the catalog item to published from the working catalog to the public catalog. Used for optimistic concurrency.
        /// If the provided ETag does not match the ETag in the current working catalog, the request will be rejected. If not
        /// provided, the current version of the document in the working catalog will be published.
        /// </summary>
        public string ETag ;

        /// <summary>
        /// The unique ID of the item.
        /// </summary>
        public string Id ;

    }

    public class PublishDraftItemResponse : PlayFabResultCommon
    {
    }

    public enum PublishResult
    {
        Unknown,
        Pending,
        Succeeded,
        Failed,
        Canceled
    }

    public class PurchaseOverride
    {
    }

    public class Rating
    {
        /// <summary>
        /// The average rating for this item.
        /// </summary>
        public float? Average ;

        /// <summary>
        /// The total count of 1 star ratings for this item.
        /// </summary>
        public int? Count1Star ;

        /// <summary>
        /// The total count of 2 star ratings for this item.
        /// </summary>
        public int? Count2Star ;

        /// <summary>
        /// The total count of 3 star ratings for this item.
        /// </summary>
        public int? Count3Star ;

        /// <summary>
        /// The total count of 4 star ratings for this item.
        /// </summary>
        public int? Count4Star ;

        /// <summary>
        /// The total count of 5 star ratings for this item.
        /// </summary>
        public int? Count5Star ;

        /// <summary>
        /// The total count of ratings for this item.
        /// </summary>
        public int? TotalCount ;

    }

    public class ReportItemRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// An alternate ID associated with this item.
        /// </summary>
        public CatalogAlternateId AlternateId ;

        /// <summary>
        /// Category of concern for this report.
        /// </summary>
        public ConcernCategory? ConcernCategory ;

        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity ;

        /// <summary>
        /// The unique ID of the item.
        /// </summary>
        public string Id ;

        /// <summary>
        /// The string reason for this report.
        /// </summary>
        public string Reason ;

    }

    public class ReportItemResponse : PlayFabResultCommon
    {
    }

    /// <summary>
    /// Submit a report for an inappropriate review, allowing the submitting user to specify their concern.
    /// </summary>
    public class ReportItemReviewRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// An alternate ID of the item associated with the review.
        /// </summary>
        public CatalogAlternateId AlternateId ;

        /// <summary>
        /// The reason this review is being reported.
        /// </summary>
        public ConcernCategory? ConcernCategory ;

        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity ;

        /// <summary>
        /// The string ID of the item associated with the review.
        /// </summary>
        public string ItemId ;

        /// <summary>
        /// The string reason for this report.
        /// </summary>
        public string Reason ;

        /// <summary>
        /// The ID of the review to submit a report for.
        /// </summary>
        public string ReviewId ;

    }

    public class ReportItemReviewResponse : PlayFabResultCommon
    {
    }

    public class Review
    {
        /// <summary>
        /// The number of negative helpfulness votes for this review.
        /// </summary>
        public int HelpfulNegative ;

        /// <summary>
        /// The number of positive helpfulness votes for this review.
        /// </summary>
        public int HelpfulPositive ;

        /// <summary>
        /// Indicates whether the review author has the item installed.
        /// </summary>
        public bool IsInstalled ;

        /// <summary>
        /// The ID of the item being reviewed.
        /// </summary>
        public string ItemId ;

        /// <summary>
        /// The version of the item being reviewed.
        /// </summary>
        public string ItemVersion ;

        /// <summary>
        /// The locale for which this review was submitted in.
        /// </summary>
        public string Locale ;

        /// <summary>
        /// Star rating associated with this review.
        /// </summary>
        public int Rating ;

        /// <summary>
        /// The ID of the author of the review.
        /// </summary>
        public EntityKey ReviewerEntity ;

        /// <summary>
        /// Deprecated. Use ReviewerEntity instead. This property will be removed in a future release.
        /// </summary>
        public string ReviewerId ;

        /// <summary>
        /// The ID of the review.
        /// </summary>
        public string ReviewId ;

        /// <summary>
        /// The full text of this review.
        /// </summary>
        public string ReviewText ;

        /// <summary>
        /// The date and time this review was last submitted.
        /// </summary>
        public DateTime Submitted ;

        /// <summary>
        /// The title of this review.
        /// </summary>
        public string Title ;

    }

    public class ReviewItemRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// An alternate ID associated with this item.
        /// </summary>
        public CatalogAlternateId AlternateId ;

        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity ;

        /// <summary>
        /// The unique ID of the item.
        /// </summary>
        public string Id ;

        /// <summary>
        /// The review to submit.
        /// </summary>
        public Review Review ;

    }

    public class ReviewItemResponse : PlayFabResultCommon
    {
    }

    public class ReviewTakedown
    {
        /// <summary>
        /// An alternate ID associated with this item.
        /// </summary>
        public CatalogAlternateId AlternateId ;

        /// <summary>
        /// The ID of the item associated with the review to take down.
        /// </summary>
        public string ItemId ;

        /// <summary>
        /// The ID of the review to take down.
        /// </summary>
        public string ReviewId ;

    }

    public class ScanResult : PlayFabResultCommon
    {
        /// <summary>
        /// The URL of the item which failed the scan.
        /// </summary>
        public string Url ;

    }

    public class SearchItemsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// An opaque token used to retrieve the next page of items, if any are available.
        /// </summary>
        public string ContinuationToken ;

        /// <summary>
        /// Number of items to retrieve. Maximum page size is 225. Default value is 10.
        /// </summary>
        public int Count ;

        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity ;

        /// <summary>
        /// An OData filter used to refine the search query.
        /// </summary>
        public string Filter ;

        /// <summary>
        /// An OData orderBy used to order the results of the search query.
        /// </summary>
        public string OrderBy ;

        /// <summary>
        /// The text to search for.
        /// </summary>
        public string Search ;

        /// <summary>
        /// An OData select query option used to augment the search results. If not defined, the default search result metadata will
        /// be returned.
        /// </summary>
        public string Select ;

    }

    public class SearchItemsResponse : PlayFabResultCommon
    {
        /// <summary>
        /// An opaque token used to retrieve the next page of items, if any are available.
        /// </summary>
        public string ContinuationToken ;

        /// <summary>
        /// The paginated set of results for the search query.
        /// </summary>
        public List<CatalogItem> Items ;

    }

    public class SetItemModerationStateRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// An alternate ID associated with this item.
        /// </summary>
        public CatalogAlternateId AlternateId ;

        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The unique ID of the item.
        /// </summary>
        public string Id ;

        /// <summary>
        /// The reason for the moderation state change for the associated item.
        /// </summary>
        public string Reason ;

        /// <summary>
        /// The status to set for the associated item.
        /// </summary>
        public ModerationStatus? Status ;

    }

    public class SetItemModerationStateResponse : PlayFabResultCommon
    {
    }

    public class StoreDetails
    {
    }

    public class StoreInfo
    {
        /// <summary>
        /// An alternate ID of the store.
        /// </summary>
        public CatalogAlternateId AlternateId ;

        /// <summary>
        /// The unique ID of the store.
        /// </summary>
        public string Id ;

    }

    public class SubmitItemReviewVoteRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// An alternate ID of the item associated with the review.
        /// </summary>
        public CatalogAlternateId AlternateId ;

        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity ;

        /// <summary>
        /// The string ID of the item associated with the review.
        /// </summary>
        public string ItemId ;

        /// <summary>
        /// The ID of the review to submit a helpfulness vote for.
        /// </summary>
        public string ReviewId ;

        /// <summary>
        /// The helpfulness vote of the review.
        /// </summary>
        public HelpfulnessVote? Vote ;

    }

    public class SubmitItemReviewVoteResponse : PlayFabResultCommon
    {
    }

    public class SubscriptionDetails
    {
        /// <summary>
        /// The length of time that the subscription will last in seconds.
        /// </summary>
        public double DurationInSeconds ;

    }

    /// <summary>
    /// Submit a request to takedown one or more reviews, removing them from public view. Authors will still be able to see
    /// their reviews after being taken down.
    /// </summary>
    public class TakedownItemReviewsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// The set of reviews to take down.
        /// </summary>
        public List<ReviewTakedown> Reviews ;

    }

    public class TakedownItemReviewsResponse : PlayFabResultCommon
    {
    }

    public class UpdateCatalogConfigRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The updated catalog configuration.
        /// </summary>
        public CatalogConfig Config ;

        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

    }

    public class UpdateCatalogConfigResponse : PlayFabResultCommon
    {
    }

    public class UpdateDraftItemRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// Updated metadata describing the catalog item to be updated.
        /// </summary>
        public CatalogItem Item ;

        /// <summary>
        /// Whether the item should be published immediately.
        /// </summary>
        public bool Publish ;

    }

    public class UpdateDraftItemResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Updated metadata describing the catalog item just updated.
        /// </summary>
        public CatalogItem Item ;

    }

    public class UploadInfo
    {
        /// <summary>
        /// Name of the file to be uploaded.
        /// </summary>
        public string FileName ;

    }

    public class UploadUrlMetadata
    {
        /// <summary>
        /// Name of the file for which this upload URL was requested.
        /// </summary>
        public string FileName ;

        /// <summary>
        /// Unique ID for the binary content to be uploaded to the target URL.
        /// </summary>
        public string Id ;

        /// <summary>
        /// URL for the binary content to be uploaded to.
        /// </summary>
        public string Url ;

    }

    public class UserGeneratedContentSpecificConfig
    {
        /// <summary>
        /// The set of content types that will be used for validation.
        /// </summary>
        public List<string> ContentTypes ;

        /// <summary>
        /// The set of tags that will be used for validation.
        /// </summary>
        public List<string> Tags ;

    }
}
