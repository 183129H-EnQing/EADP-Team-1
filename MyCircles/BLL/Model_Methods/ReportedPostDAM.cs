using MyCircles.DAL;
using MyCircles.DAL.Joint_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCircles.BLL
{
    public partial class ReportedPost
    {
        public static ReportedPost GetReportedPostById(int reportedPostId)
        {
            return ReportedPostDAO.GetReportedPostById(reportedPostId);
        }

        public static List<ReportedPost> GetAllReportedPosts()
        {
            return ReportedPostDAO.GetAllReportedPosts();
        }

        public static List<UserReportedPost> GetAllUserReportedPosts()
        {
            return ReportedPostDAO.GetAllUserReportedPosts();
        }

        public static List<UserReportedPost> GetAllUserReportedPostsSortByPostId()
        {
            return ReportedPostDAO.GetAllUserReportedPostsSortByPostId();
        }

        public static void DeleteReportedPostByPostId(int postId)
        {
            ReportedPostDAO.DeleteReportedPostByPostId(postId);
        }

        public static List<ReportedPostCount> GetReportedPostCountByDate()
        {
            return ReportedPostDAO.GetReportedPostCountByDate();
        }
    }
}