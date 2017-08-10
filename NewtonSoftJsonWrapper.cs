using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

// To use NewtonSoftJson in your CSharp project:
// 1) Add the latest PlayFab and NewtonSoft nuget packages to your project
// 2) Add this file to your project
// 3) Put this line into your early program start, before making any PlayFab API calls:
//      PlayFab.Json.JsonWrapper.Instance = new PlayFab.Json.NewtonSoftJsonWrapper();
// Once complete, your program will no longer use SimpleJson, and won't conflict or mix JsonObject types

namespace PlayFab.Json
{
    public class NewtonSoftJsonWrapper : ISerializer
    {
        public static JsonSerializerSettings JsonSettings = new JsonSerializerSettings()
        {
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
            Converters = { new CustomIsoDateTimeConverter(), new StringEnumConverter() },
        };

        public object DeserializeObject(string json)
        {
            //UnityEngine.Debug.Log("Deserialized Using JSON.NET");
            return JsonConvert.DeserializeObject(json);
        }

        public T DeserializeObject<T>(string json)
        {
            //UnityEngine.Debug.Log("Deserialized Using JSON.NET");
            return JsonConvert.DeserializeObject<T>(json);
        }

        public T DeserializeObject<T>(string json, object jsonSerializerStrategy)
        {
            //UnityEngine.Debug.Log("Deserialized Using JSON.NET");
            return JsonConvert.DeserializeObject<T>(json, JsonSettings);
        }

        public string SerializeObject(object json)
        {
            //UnityEngine.Debug.Log("Serialized Using JSON.NET");
            return JsonConvert.SerializeObject(json);
        }

        public string SerializeObject(object json, object jsonSerializerStrategy)
        {
            //UnityEngine.Debug.Log("Serialized Using JSON.NET");
            return JsonConvert.SerializeObject(json, Newtonsoft.Json.Formatting.Indented, JsonSettings);
        }
    }

    /// <summary>
    /// Converts a <see cref="DateTime"/> to and from the ISO 8601 date format (e.g. 2008-04-12T12:53Z).
    /// </summary>
    public class CustomIsoDateTimeConverter : DateTimeConverterBase
    {
        private const string DefaultDateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK";

        private DateTimeStyles _dateTimeStyles = DateTimeStyles.RoundtripKind;
        private string _dateTimeFormat;
        private CultureInfo _culture;

        /// <summary>
        /// Gets or sets the date time styles used when converting a date to and from JSON.
        /// </summary>
        /// <value>The date time styles used when converting a date to and from JSON.</value>
        public DateTimeStyles DateTimeStyles
        {
            get { return _dateTimeStyles; }
            set { _dateTimeStyles = value; }
        }

        /// <summary>
        /// Gets or sets the date time format used when converting a date to and from JSON.
        /// </summary>
        /// <value>The date time format used when converting a date to and from JSON.</value>
        public string DateTimeFormat
        {
            get { return _dateTimeFormat ?? string.Empty; }
            set { _dateTimeFormat = string.IsNullOrEmpty(value) ? null : value; }
        }

        /// <summary>
        /// Gets or sets the culture used when converting a date to and from JSON.
        /// </summary>
        /// <value>The culture used when converting a date to and from JSON.</value>
        public CultureInfo Culture
        {
            get { return _culture ?? CultureInfo.CurrentCulture; }
            set { _culture = value; }
        }

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            string text;

            if (value is DateTime)
            {
                DateTime dateTime = (DateTime)value;

                if ((_dateTimeStyles & DateTimeStyles.AdjustToUniversal) == DateTimeStyles.AdjustToUniversal
                    || (_dateTimeStyles & DateTimeStyles.AssumeUniversal) == DateTimeStyles.AssumeUniversal)
                    dateTime = dateTime.ToUniversalTime();

                text = dateTime.ToString(_dateTimeFormat ?? DefaultDateTimeFormat, Culture);
            }
            else if (value is DateTimeOffset)
            {
                DateTimeOffset dateTimeOffset = (DateTimeOffset)value;
                if ((_dateTimeStyles & DateTimeStyles.AdjustToUniversal) == DateTimeStyles.AdjustToUniversal
                    || (_dateTimeStyles & DateTimeStyles.AssumeUniversal) == DateTimeStyles.AssumeUniversal)
                    dateTimeOffset = dateTimeOffset.ToUniversalTime();

                text = dateTimeOffset.ToString(_dateTimeFormat ?? DefaultDateTimeFormat, Culture);
            }
            else
            {
                throw new Exception(string.Format(CultureInfo.InvariantCulture, "Unexpected value when converting date. Expected DateTime or DateTimeOffset, got {0}.", value.GetType().Name));
            }

            writer.WriteValue(text);
        }

        public bool IsNullableType(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="JsonReader"/> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            bool nullable = IsNullableType(objectType);
            Type t = (nullable)
                ? Nullable.GetUnderlyingType(objectType)
                : objectType;

            if (reader.TokenType == JsonToken.Null)
            {
                if (!IsNullableType(objectType))
                    throw new Exception(string.Format(CultureInfo.InvariantCulture, "Cannot convert null value to {0}.", objectType.Name));
                return null;
            }

            if (reader.TokenType != JsonToken.String)
                throw new Exception(string.Format(CultureInfo.InvariantCulture, "Unexpected token parsing date. Expected String, got {0}.", reader.TokenType));

            string dateText = reader.Value.ToString();

            if (string.IsNullOrEmpty(dateText) && nullable)
                return null;

            if (t == typeof(DateTimeOffset))
            {
                if (!string.IsNullOrEmpty(_dateTimeFormat))
                    return DateTimeOffset.ParseExact(dateText, _dateTimeFormat, Culture, _dateTimeStyles);
                else
                    return DateTimeOffset.Parse(dateText, Culture, _dateTimeStyles);
            }

            foreach (var dateTimeFormat in PlayFabUtil.DefaultDateTimeFormats)
            {

                if (!string.IsNullOrEmpty(_dateTimeFormat))
                {
                    return DateTime.ParseExact(dateText, _dateTimeFormat, Culture, _dateTimeStyles);
                }
                else
                {
                    //.Parse(dateText, Culture, _dateTimeStyles);
                    DateTime parsedDateTime;
                    var parsed = DateTime.TryParseExact(dateText, dateTimeFormat, Culture, _dateTimeStyles, out parsedDateTime);
                    if (parsed)
                    {
                        return parsedDateTime;
                    }
                }
            }

            return null;
        }
    }
}
