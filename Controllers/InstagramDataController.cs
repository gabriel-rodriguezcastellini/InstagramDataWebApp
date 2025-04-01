using InstagramDataWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace InstagramDataWebApp.Controllers
{
    public class InstagramDataController(InstagramDataService dataService) : Controller
    {
        public IActionResult Followers()
        {
            List<Models.InstagramRelationship> followers = dataService.Followers;
            return View(followers);
        }

        public IActionResult Following()
        {
            List<Models.InstagramRelationship>? following = dataService.Following?.RelationshipsFollowing;
            return View(following);
        }

        public IActionResult Blocked()
        {
            List<Models.BlockedProfile>? blocked = dataService.BlockedProfiles?.RelationshipsBlockedUsers;
            return View(blocked);
        }

        public IActionResult PendingFollowRequests()
        {
            List<Models.InstagramRelationship>? pending = dataService.PendingFollowRequests?.RelationshipsFollowRequestsSent;
            return View(pending);
        }

        public IActionResult RecentFollowRequests()
        {
            List<Models.InstagramRelationship>? recent = dataService.RecentFollowRequests?.RelationshipsPermanentFollowRequests;
            return View(recent);
        }

        public IActionResult RecentlyUnfollowed()
        {
            List<Models.InstagramRelationship>? unfollowed = dataService.RecentlyUnfollowed?.RelationshipsUnfollowedUsers;
            return View(unfollowed);
        }
    }
}
