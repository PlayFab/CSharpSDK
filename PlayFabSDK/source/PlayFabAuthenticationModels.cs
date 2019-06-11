using PlayFab.Internal;
using System;
using System.Collections.Generic;

namespace PlayFab.AuthenticationModels
{
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
        /// Entity type. See https://api.playfab.com/docs/tutorials/entities/entitytypes
        /// </summary>
        public string Type { get; set; }

    }

    public class EntityLineage
    {
        /// <summary>
        /// The Character Id of the associated entity.
        /// </summary>
        public string CharacterId ;

        /// <summary>
        /// The Group Id of the associated entity.
        /// </summary>
        public string GroupId ;

        /// <summary>
        /// The Master Player Account Id of the associated entity.
        /// </summary>
        public string MasterPlayerAccountId ;

        /// <summary>
        /// The Namespace Id of the associated entity.
        /// </summary>
        public string NamespaceId ;

        /// <summary>
        /// The Title Id of the associated entity.
        /// </summary>
        public string TitleId ;

        /// <summary>
        /// The Title Player Account Id of the associated entity.
        /// </summary>
        public string TitlePlayerAccountId ;

    }

    /// <summary>
    /// This API must be called with X-SecretKey, X-Authentication or X-EntityToken headers. An optional EntityKey may be
    /// included to attempt to set the resulting EntityToken to a specific entity, however the entity must be a relation of the
    /// caller, such as the master_player_account of a character. If sending X-EntityToken the account will be marked as freshly
    /// logged in and will issue a new token. If using X-Authentication or X-EntityToken the header must still be valid and
    /// cannot be expired or revoked.
    /// </summary>
    public class GetEntityTokenRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity ;

    }

    public class GetEntityTokenResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The entity id and type.
        /// </summary>
        public EntityKey Entity ;

        /// <summary>
        /// The token used to set X-EntityToken for all entity based API calls.
        /// </summary>
        public string EntityToken ;

        /// <summary>
        /// The time the token will expire, if it is an expiring token, in UTC.
        /// </summary>
        public DateTime? TokenExpiration ;

    }

    /// <summary>
    /// Given an entity token, validates that it hasn't exipired or been revoked and will return details of the owner.
    /// </summary>
    public class ValidateEntityTokenRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Client EntityToken
        /// </summary>
        public string EntityToken ;

    }

    public class ValidateEntityTokenResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The entity id and type.
        /// </summary>
        public EntityKey Entity ;

        /// <summary>
        /// The lineage of this profile.
        /// </summary>
        public EntityLineage Lineage ;

    }
}
