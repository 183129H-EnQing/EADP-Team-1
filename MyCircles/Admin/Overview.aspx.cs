using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyCircles.BLL;

namespace MyCircles.Admin
{
    public partial class Overview : System.Web.UI.Page
    {
        public int numOfReportedPosts;
        public int numOfEvents;
        public int numOfUsers;
        public int numOfCircles;

        protected void Page_Load(object sender, EventArgs e)
        {
            List<ReportedPost> reportedPosts = new List<ReportedPost>();
            foreach (ReportedPost post in ReportedPost.GetAllReportedPosts())
            {
                if (post.postId > -1)
                    reportedPosts.Add(post);
            }
            numOfReportedPosts = reportedPosts.Count;
            
            numOfEvents = Event.GetAllEvent().Count;

            numOfUsers = BLL.User.GetAllUsers().Count;

            numOfCircles = DAL.CircleDAO.GetAllCircles().Count;
        }
    }
}