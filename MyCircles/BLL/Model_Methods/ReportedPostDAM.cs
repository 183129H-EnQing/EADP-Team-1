using MyCircles.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCircles.BLL
{
    public partial class ReportedPost
    {
        public static List<ReportedPost> getAllReportedPosts()
        {
            return ReportedPostDAO.GetAllReportedPosts();
        }
    }
}