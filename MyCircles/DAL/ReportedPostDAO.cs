using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyCircles.BLL;
using MyCircles.DAL.Joint_Models;

namespace MyCircles.DAL
{
    public class ReportedPostDAO
    {
        public static List<ReportedPost> GetAllReportedPosts()
        {
            List<ReportedPost> reportedPosts = new List<ReportedPost>();
            using (MyCirclesEntityModel db = new MyCirclesEntityModel())
            {
                reportedPosts = db.ReportedPosts.ToList();
            }
            return reportedPosts;
        }

        public static List<UserReportedPost> GetAllUserReportedPosts()
        {
            using (var db = new MyCirclesEntityModel())
            {
                db.Configuration.LazyLoadingEnabled = false;

                var followingUsers = db.ReportedPosts
                    .ToList()
                    .Join(
                        db.Users,
                        reportedPosts => reportedPosts.reporterUserId,
                        user => user.Id,
                        (reportedPosts, user) => new UserReportedPost(reportedPosts, user)
                    )
                    .ToList();

                return followingUsers;
            }
        }
    }
}