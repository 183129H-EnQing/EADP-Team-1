﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyCircles.BLL;
using MyCircles.DAL.Joint_Models;

namespace MyCircles.DAL
{
    public class ReportedPostDAO
    {
        public static ReportedPost GetReportedPostById(int reportedPostId)
        {
            using (MyCirclesEntityModel db = new MyCirclesEntityModel())
            {
                return db.ReportedPosts.Where(p => p.Id == reportedPostId).FirstOrDefault();
            }
        }

        public static void AddReport(ReportedPost newReport)
        {
            using (var db = new MyCirclesEntityModel())
            {
                db.ReportedPosts.Add(newReport);
                db.SaveChanges();
            }
        }

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

        public static List<UserReportedPost> GetAllUserReportedPostsSortByPostId()
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
                    .OrderBy(reportedPost => reportedPost.postId)
                    .ToList();

                return followingUsers;
            }
        }

        public static void DeleteReportedPostByPostId(int postId)
        {
            using (var db = new MyCirclesEntityModel())
            {
                List<ReportedPost> posts = db.ReportedPosts.Where(p => p.postId == postId).ToList();

                foreach (ReportedPost post in posts)
                {
                    post.postId = null;
                }

                db.SaveChanges();
            }
        }

        public static List<ReportedPostCount> GetReportedPostCountByDate()
        {
            using (var db = new MyCirclesEntityModel())
            {
                List<ReportedPostCount> counts = db.ReportedPosts
                    .ToList()
                    .GroupBy(
                        post => post.dateCreated
                    )
                    .Select(reportStat => new ReportedPostCount(reportStat.Key, reportStat.Count()))
                    .ToList();

                //var query = from post in db.ReportedPosts
                //            group post by post.dateCreated into reportStat
                //            select new ReportedPostCount(reportStat.Key, reportStat.Count());

                return counts;
            }
        }
    }
}