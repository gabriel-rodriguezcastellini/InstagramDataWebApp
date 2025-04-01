using InstagramDataWebApp.Models;
using InstagramDataWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace InstagramDataWebApp.Controllers;

public class HomeController(InstagramDataService dataService) : Controller
{
    public IActionResult Index()
    {
        DashboardViewModel dashboard = new()
        {
            SyncedContactsCount = dataService.SyncedContacts?.ContactsContactInfo?.Count ?? 0,
            BlockedCount = dataService.BlockedProfiles?.RelationshipsBlockedUsers?.Count ?? 0,
            FollowersCount = dataService.Followers?.Count ?? 0,
            FollowingCount = dataService.Following?.RelationshipsFollowing.Count ?? 0,
            PendingFollowRequestsCount = dataService.PendingFollowRequests?.RelationshipsFollowRequestsSent.Count ?? 0,
            RecentFollowRequestsCount = dataService.RecentFollowRequests?.RelationshipsPermanentFollowRequests.Count ?? 0,
            RecentlyUnfollowedCount = dataService.RecentlyUnfollowed?.RelationshipsUnfollowedUsers.Count ?? 0
        };

        return View(dashboard);
    }
}
