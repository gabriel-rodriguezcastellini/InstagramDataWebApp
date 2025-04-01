using System.Text.Json.Serialization;

namespace InstagramDataWebApp.Models
{
    public class BlockedProfile
    {
        public required string Title { get; set; }

        [JsonPropertyName("string_list_data")]
        public required List<ProfileLink> StringListData { get; set; }
    }
}
