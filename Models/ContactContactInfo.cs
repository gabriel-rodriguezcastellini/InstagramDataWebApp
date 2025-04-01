using System.Text.Json.Serialization;

namespace InstagramDataWebApp.Models
{
    public class ContactContactInfo
    {
        public required string Title { get; set; }

        [JsonPropertyName("media_map_data")]
        public required Dictionary<string, object> MediaMapData { get; set; }
    }
}
