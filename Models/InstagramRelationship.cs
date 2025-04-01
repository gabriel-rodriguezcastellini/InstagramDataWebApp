using System.Text.Json.Serialization;

namespace InstagramDataWebApp.Models
{
    public class InstagramRelationship
    {
        public required string Title { get; set; }

        [JsonPropertyName("media_list_data")]
        public required List<object> MediaListData { get; set; }

        [JsonPropertyName("string_list_data")]
        public required List<InstagramUserLink> StringListData { get; set; }
    }
}
