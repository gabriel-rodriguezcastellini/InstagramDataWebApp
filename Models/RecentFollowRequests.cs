using System.Text.Json.Serialization;

namespace InstagramDataWebApp.Models
{
    public class RecentFollowRequests
    {
        [JsonPropertyName("relationships_permanent_follow_requests")]
        public required List<InstagramRelationship> RelationshipsPermanentFollowRequests { get; set; }
    }
}
