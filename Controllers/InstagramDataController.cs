using InstagramDataWebApp.Models;
using InstagramDataWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using X.PagedList.Extensions;

namespace InstagramDataWebApp.Controllers
{
    public class InstagramDataController(InstagramDataService dataService) : Controller
    {
        public IActionResult Followers(string searchTerm, int? page)
        {
            List<InstagramRelationship> followers = dataService.Followers ?? [];

            if (!string.IsNullOrEmpty(searchTerm))
            {
                followers = [.. followers
                    .Where(f => f.StringListData?.FirstOrDefault()?.Value?
                        .IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0)];
            }

            int pageNumber = page ?? 1;
            int pageSize = 10;

            X.PagedList.IPagedList<InstagramRelationship> pagedFollowers = followers.ToPagedList(pageNumber, pageSize);

            ViewBag.SearchTerm = searchTerm;

            return View(pagedFollowers);
        }

        public IActionResult Following()
        {
            List<InstagramRelationship>? following = dataService.Following?.RelationshipsFollowing;
            return View(following);
        }

        public IActionResult Blocked()
        {
            List<BlockedProfile>? blocked = dataService.BlockedProfiles?.RelationshipsBlockedUsers;
            return View(blocked);
        }

        public IActionResult PendingFollowRequests()
        {
            List<InstagramRelationship>? pending = dataService.PendingFollowRequests?.RelationshipsFollowRequestsSent;
            return View(pending);
        }

        public IActionResult RecentFollowRequests()
        {
            List<InstagramRelationship>? recent = dataService.RecentFollowRequests?.RelationshipsPermanentFollowRequests;
            return View(recent);
        }

        public IActionResult RecentlyUnfollowed()
        {
            List<InstagramRelationship>? unfollowed = dataService.RecentlyUnfollowed?.RelationshipsUnfollowedUsers;
            return View(unfollowed);
        }

        public IActionResult FollowingNotFollowingMe(string sortField = "username", string sortOrder = "asc")
        {
            List<InstagramRelationship> followingList = dataService.Following.RelationshipsFollowing ?? [];
            List<InstagramRelationship> followerList = dataService.Followers ?? [];

            List<InstagramRelationship> notFollowingMe = [.. followingList
                .Where(f => !followerList.Any(r =>
                    string.Equals(r.StringListData?.FirstOrDefault()?.Value, f.StringListData?.FirstOrDefault()?.Value, StringComparison.OrdinalIgnoreCase)
                ))];

            notFollowingMe = sortField.ToLower() switch
            {
                "date" => sortOrder.Equals("desc", StringComparison.CurrentCultureIgnoreCase) ?
                    [.. notFollowingMe.OrderByDescending(x => x.StringListData?.FirstOrDefault()?.Timestamp)] :
                    [.. notFollowingMe.OrderBy(x => x.StringListData?.FirstOrDefault()?.Timestamp)],
                _ =>
                    sortOrder.Equals("desc", StringComparison.CurrentCultureIgnoreCase) ?
                    [.. notFollowingMe.OrderByDescending(x => x.StringListData?.FirstOrDefault()?.Value)] :
                    [.. notFollowingMe.OrderBy(x => x.StringListData?.FirstOrDefault()?.Value)]
            };

            ViewBag.SortField = sortField;
            ViewBag.SortOrder = sortOrder;

            return View(notFollowingMe);
        }

        public IActionResult FollowersNotFollowedByMe(string sortField = "username", string sortOrder = "asc")
        {
            List<InstagramRelationship> followingList = dataService.Following.RelationshipsFollowing ?? [];
            List<InstagramRelationship> followerList = dataService.Followers ?? [];

            List<InstagramRelationship> notFollowedByMe = [.. followerList
                .Where(r => !followingList.Any(f =>
                    string.Equals(f.StringListData?.FirstOrDefault()?.Value, r.StringListData?.FirstOrDefault()?.Value, StringComparison.OrdinalIgnoreCase)
                ))];

            notFollowedByMe = sortField.ToLower() switch
            {
                "date" => sortOrder.Equals("desc", StringComparison.CurrentCultureIgnoreCase) ?
                    [.. notFollowedByMe.OrderByDescending(x => x.StringListData?.FirstOrDefault()?.Timestamp)] :
                    [.. notFollowedByMe.OrderBy(x => x.StringListData?.FirstOrDefault()?.Timestamp)],
                _ =>
                    sortOrder.Equals("desc", StringComparison.CurrentCultureIgnoreCase) ?
                    [.. notFollowedByMe.OrderByDescending(x => x.StringListData?.FirstOrDefault()?.Value)] :
                    [.. notFollowedByMe.OrderBy(x => x.StringListData?.FirstOrDefault()?.Value)]
            };

            ViewBag.SortField = sortField;
            ViewBag.SortOrder = sortOrder;

            return View(notFollowedByMe);
        }
    }
}
