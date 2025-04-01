namespace InstagramDataWebApp.Models
{
    public class DashboardViewModel
    {
        public int SyncedContactsCount { get; set; }
        public int BlockedCount { get; set; }
        public int FollowersCount { get; set; }
        public int FollowingCount { get; set; }
        public int PendingFollowRequestsCount { get; set; }
        public int RecentFollowRequestsCount { get; set; }
        public int RecentlyUnfollowedCount { get; set; }
    }
}
