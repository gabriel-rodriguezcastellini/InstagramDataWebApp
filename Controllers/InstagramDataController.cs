using InstagramDataWebApp.Models;
using InstagramDataWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace InstagramDataWebApp.Controllers
{
    public class InstagramDataController(InstagramDataService dataService) : Controller
    {
        public IActionResult Followers(string searchTerm)
        {
            List<Models.InstagramRelationship> followers = dataService.Followers;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                followers = [.. followers
                    .Where(f => f.StringListData?.FirstOrDefault()?.Value?
                        .IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0)];
            }

            ViewBag.SearchTerm = searchTerm;
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

        public IActionResult FollowingNotFollowingMe()
        {
            List<InstagramRelationship> followingList = dataService.Following.RelationshipsFollowing ?? [];
            List<InstagramRelationship> followerList = dataService.Followers ?? [];

            List<InstagramRelationship> notFollowingMe = [.. followingList
                .Where(f => !followerList.Any(r =>
                    string.Equals(r.StringListData?.FirstOrDefault()?.Value, f.StringListData?.FirstOrDefault()?.Value, StringComparison.OrdinalIgnoreCase)
                ))];
            return View(notFollowingMe);
        }

        public IActionResult FollowersNotFollowedByMe()
        {
            List<InstagramRelationship> followingList = dataService.Following.RelationshipsFollowing ?? [];
            List<InstagramRelationship> followerList = dataService.Followers ?? [];

            List<InstagramRelationship> notFollowedByMe = [.. followerList
                .Where(r => !followingList.Any(f =>
                    string.Equals(f.StringListData?.FirstOrDefault()?.Value, r.StringListData?.FirstOrDefault()?.Value, StringComparison.OrdinalIgnoreCase)
                ))];
            return View(notFollowedByMe);
        }
    }
}
