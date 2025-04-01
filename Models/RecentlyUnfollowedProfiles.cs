using System.Text.Json.Serialization;

namespace InstagramDataWebApp.Models
{
    public class RecentlyUnfollowedProfiles
    {
        [JsonPropertyName("relationships_unfollowed_users")]
        public required List<InstagramRelationship> RelationshipsUnfollowedUsers { get; set; }
    }
}
