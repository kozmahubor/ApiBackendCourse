using System.Text.Json.Serialization;

namespace Backend_course.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RpgClass
    {
        Fighter, Tank, Mage, Ranger, Support
    }
}