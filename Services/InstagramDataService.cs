using InstagramDataWebApp.Models;
using System.Text.Json;

namespace InstagramDataWebApp.Services
{
    public class InstagramDataService
    {
        public string DataFolderPath { get; }

        public SyncedContacts SyncedContacts { get; set; } = new SyncedContacts { ContactsContactInfo = [] };
        public BlockedProfiles BlockedProfiles { get; set; } = new BlockedProfiles { RelationshipsBlockedUsers = [] };
        public List<InstagramRelationship> Followers { get; set; } = [];
        public Following Following { get; set; } = new Following { RelationshipsFollowing = [] };
        public PendingFollowRequests PendingFollowRequests { get; set; } = new PendingFollowRequests { RelationshipsFollowRequestsSent = [] };
        public RecentFollowRequests RecentFollowRequests { get; set; } = new RecentFollowRequests { RelationshipsPermanentFollowRequests = [] };
        public RecentlyUnfollowedProfiles RecentlyUnfollowed { get; set; } = new RecentlyUnfollowedProfiles { RelationshipsUnfollowedUsers = [] };

        private readonly ILogger<InstagramDataService> _logger;

        public InstagramDataService(IWebHostEnvironment env, ILogger<InstagramDataService> logger)
        {
            _logger = logger;
            DataFolderPath = Path.Combine(env.ContentRootPath, "Data");
            LoadData();
        }

        private void LoadData()
        {
            JsonSerializerOptions options = new() { PropertyNameCaseInsensitive = true };
            try
            {
                string file = Path.Combine(DataFolderPath, "synced_contacts.json");
                if (File.Exists(file))
                {
                    string json = File.ReadAllText(file);
                    SyncedContacts? deserialized = JsonSerializer.Deserialize<SyncedContacts>(json, options);
                    if (deserialized != null)
                    {
                        SyncedContacts = deserialized;
                    }
                }
                else
                {
                    _logger.LogWarning("File not found: synced_contacts.json in {DataFolderPath}", DataFolderPath);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading synced_contacts.json");
            }

            try
            {
                string file = Path.Combine(DataFolderPath, "blocked_profiles.json");
                if (File.Exists(file))
                {
                    string json = File.ReadAllText(file);
                    BlockedProfiles? deserialized = JsonSerializer.Deserialize<BlockedProfiles>(json, options);
                    if (deserialized != null)
                    {
                        BlockedProfiles = deserialized;
                    }
                }
                else
                {
                    _logger.LogWarning("File not found: blocked_profiles.json in {DataFolderPath}", DataFolderPath);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading blocked_profiles.json");
            }

            try
            {
                string file = Path.Combine(DataFolderPath, "followers_1.json");
                if (File.Exists(file))
                {
                    string json = File.ReadAllText(file);
                    List<InstagramRelationship>? deserialized = JsonSerializer.Deserialize<List<InstagramRelationship>>(json, options);
                    if (deserialized != null)
                    {
                        Followers = deserialized;
                    }
                }
                else
                {
                    _logger.LogWarning("File not found: followers_1.json in {DataFolderPath}", DataFolderPath);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading followers_1.json");
            }

            try
            {
                string file = Path.Combine(DataFolderPath, "following.json");
                if (File.Exists(file))
                {
                    string json = File.ReadAllText(file);
                    Following? deserialized = JsonSerializer.Deserialize<Following>(json, options);
                    if (deserialized != null)
                    {
                        Following = deserialized;
                    }
                }
                else
                {
                    _logger.LogWarning("File not found: following.json in {DataFolderPath}", DataFolderPath);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading following.json");
            }

            try
            {
                string file = Path.Combine(DataFolderPath, "pending_follow_requests.json");
                if (File.Exists(file))
                {
                    string json = File.ReadAllText(file);
                    PendingFollowRequests? deserialized = JsonSerializer.Deserialize<PendingFollowRequests>(json, options);
                    if (deserialized != null)
                    {
                        PendingFollowRequests = deserialized;
                    }
                }
                else
                {
                    _logger.LogWarning("File not found: pending_follow_requests.json in {DataFolderPath}", DataFolderPath);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading pending_follow_requests.json");
            }

            try
            {
                string file = Path.Combine(DataFolderPath, "recent_follow_requests.json");
                if (File.Exists(file))
                {
                    string json = File.ReadAllText(file);
                    RecentFollowRequests? deserialized = JsonSerializer.Deserialize<RecentFollowRequests>(json, options);
                    if (deserialized != null)
                    {
                        RecentFollowRequests = deserialized;
                    }
                }
                else
                {
                    _logger.LogWarning("File not found: recent_follow_requests.json in {DataFolderPath}", DataFolderPath);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading recent_follow_requests.json");
            }

            try
            {
                string file = Path.Combine(DataFolderPath, "recently_unfollowed_profiles.json");
                if (File.Exists(file))
                {
                    string json = File.ReadAllText(file);
                    RecentlyUnfollowedProfiles? deserialized = JsonSerializer.Deserialize<RecentlyUnfollowedProfiles>(json, options);
                    if (deserialized != null)
                    {
                        RecentlyUnfollowed = deserialized;
                    }
                }
                else
                {
                    _logger.LogWarning("File not found: recently_unfollowed_profiles.json in {DataFolderPath}", DataFolderPath);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading recently_unfollowed_profiles.json");
            }
        }
    }
}
