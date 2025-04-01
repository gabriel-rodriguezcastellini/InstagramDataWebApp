namespace InstagramDataWebApp.Models
{
    public class InstagramUserLink
    {
        public required string Href { get; set; }
        public required string Value { get; set; }
        public long Timestamp { get; set; }
    }
}
