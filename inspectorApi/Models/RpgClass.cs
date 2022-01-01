using System.Text.Json.Serialization;

namespace inspectorApi.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RpgClass
    {
        Knight,
        Mage,
        Claric
    }
}