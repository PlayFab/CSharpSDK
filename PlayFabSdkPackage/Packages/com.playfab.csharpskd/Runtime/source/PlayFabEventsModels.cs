using PlayFab.Internal;
using System;
using System.Collections.Generic;

namespace PlayFab.EventsModels
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
        /// Entity type. See https://docs.microsoft.com/gaming/playfab/features/data/entities/available-built-in-entity-types
        /// </summary>
        public string Type { get; set; }

    }

    public class EventContents
    {
        /// <summary>
        /// The optional custom tags associated with the event (e.g. build number, external trace identifiers, etc.). Before an
        /// event is written, this collection and the base request custom tags will be merged, but not overriden. This enables the
        /// caller to specify static tags and per event tags.
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// Entity associated with the event. If null, the event will apply to the calling entity.
        /// </summary>
        public EntityKey Entity ;

        /// <summary>
        /// The namespace in which the event is defined. Allowed namespaces can vary by API.
        /// </summary>
        public string EventNamespace ;

        /// <summary>
        /// The name of this event.
        /// </summary>
        public string Name ;

        /// <summary>
        /// The original unique identifier associated with this event before it was posted to PlayFab. The value might differ from
        /// the EventId value, which is assigned when the event is received by the server.
        /// </summary>
        public string OriginalId ;

        /// <summary>
        /// The time (in UTC) associated with this event when it occurred. If specified, this value is stored in the
        /// OriginalTimestamp property of the PlayStream event.
        /// </summary>
        public DateTime? OriginalTimestamp ;

        /// <summary>
        /// Arbitrary data associated with the event. Only one of Payload or PayloadJSON is allowed.
        /// </summary>
        public object Payload ;

        /// <summary>
        /// Arbitrary data associated with the event, represented as a JSON serialized string. Only one of Payload or PayloadJSON is
        /// allowed.
        /// </summary>
        public string PayloadJSON ;

    }

    public class WriteEventsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

        /// <summary>
        /// Collection of events to write to PlayStream.
        /// </summary>
        public List<EventContents> Events ;

    }

    public class WriteEventsResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The unique identifiers assigned by the server to the events, in the same order as the events in the request. Only
        /// returned if FlushToPlayStream option is true.
        /// </summary>
        public List<string> AssignedEventIds ;

    }
}
