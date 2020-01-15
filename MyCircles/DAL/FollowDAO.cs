using MyCircles.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows.Documents;

namespace MyCircles.DAL
{
    public static class FollowDAO
    {
        public static Follow ToggleFollow(int followerId, int followingId)
        {
            Follow newFollow = null;
            Mutual newMutual = null;

            using (var db = new MyCirclesEntityModel())
            {
                Follow existingFollow = db.Follows.Where(ef => ef.FollowerId == followerId && ef.FollowingId == followingId).FirstOrDefault();

                if (existingFollow == null)
                {
                    newFollow = new Follow();
                    newFollow.FollowerId = followerId;
                    newFollow.FollowingId = followingId;
                    newFollow.CreatedAt = DateTime.Now;
                    newFollow.IsDeleted = false;
                    db.Follows.Add(newFollow);

                    Follow existingReverseFollow = db.Follows.Where(ef => ef.FollowerId == followingId && ef.FollowingId == followerId).FirstOrDefault();

                    if (existingReverseFollow != null)
                    {
                        newMutual = MutualDAO.ToggleMutual(followerId, followingId);
                    }
                }
                else
                {
                    db.Follows.Remove(existingFollow);
                    MutualDAO.ToggleMutual(followerId, followingId);
                }

                db.SaveChanges();
            }

            return newFollow;
        }

        public static Follow SearchFollow(int followerId, int followingId)
        {
            Follow existingFollow = null;

            using (var db = new MyCirclesEntityModel())
            {
                existingFollow = db.Follows.Where(ef => ef.FollowerId == followerId && ef.FollowingId == followingId).FirstOrDefault();
            }

            return existingFollow;
        }

        public static List<FollowingUsers> GetAllFollowing(int followerId)
        {
            using (var db = new MyCirclesEntityModel())
            {
                db.Configuration.LazyLoadingEnabled = false;

                var followingUsers = db.Follows
                    .Where(following => following.FollowerId == followerId)
                    .ToList()
                    .Join(
                        db.Users,
                        follow => follow.FollowingId,
                        user => user.Id,
                        (follow, user) => new FollowingUsers(user, follow)
                        //{
                        //    uId = user.Id,
                        //    uName = user.Name,
                        //    uUsername = user.Username,
                        //    uEmailAddress = user.EmailAddress,
                        //    uHeaderImage = user.HeaderImage,
                        //    uProfileImage = user.ProfileImage,
                        //    uLatitude = user.Latitude,
                        //    user.Longitude
                        //    uBio = user.Bio,
                        //    uCity = user.City,
                        //    Follow = follow
                        //}
                    )
                    .ToList();

                return followingUsers;
            }
        }
    }
}