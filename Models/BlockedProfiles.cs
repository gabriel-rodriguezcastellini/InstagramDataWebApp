using System.Text.Json.Serialization;

namespace InstagramDataWebApp.Models
{
    public class BlockedProfiles
    {
        [JsonPropertyName("relationships_blocked_users")]
        public required List<BlockedProfile> RelationshipsBlockedUsers { get; set; }
    }
}
