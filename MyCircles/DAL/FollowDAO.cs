using MyCircles.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}