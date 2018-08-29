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
        public string Id;

        /// <summary>
        /// Entity type. See https://api.playfab.com/docs/tutorials/entities/entitytypes
        /// </summary>
        public string Type;

    }

    public class GetEntityTokenRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;

    }

    public class GetEntityTokenResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The entity id and type.
        /// </summary>
        public EntityKey Entity;

        /// <summary>
        /// The token used to set X-EntityToken for all entity based API calls.
        /// </summary>
        public string EntityToken;

        /// <summary>
        /// The time the token will expire, if it is an expiring token, in UTC.
        /// </summary>
        public DateTime? TokenExpiration;

    }
}
