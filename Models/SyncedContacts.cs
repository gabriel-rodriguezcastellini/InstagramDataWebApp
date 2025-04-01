using System.Text.Json.Serialization;

namespace InstagramDataWebApp.Models
{
    public class SyncedContacts
    {
        [JsonPropertyName("contacts_contact_info")]
        public required List<ContactContactInfo> ContactsContactInfo { get; set; }
    }
}
