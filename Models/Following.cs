using System.Text.Json.Serialization;

namespace InstagramDataWebApp.Models
{
    public class Following
    {
        [JsonPropertyName("relationships_following")]
        public required List<InstagramRelationship> RelationshipsFollowing { get; set; }
    }
}
