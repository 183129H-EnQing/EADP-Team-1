using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyCircles.BLL;

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
    }
}