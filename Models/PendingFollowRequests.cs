using System.Text.Json.Serialization;

namespace InstagramDataWebApp.Models
{
    public class PendingFollowRequests
    {
        [JsonPropertyName("relationships_follow_requests_sent")]
        public required List<InstagramRelationship> RelationshipsFollowRequestsSent { get; set; }
    }
}
