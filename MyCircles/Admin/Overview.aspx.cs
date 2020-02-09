using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            numOfReportedPosts = BLL.ReportedPost.GetAllReportedPosts().Count;
            
            numOfEvents = BLL.Event.GetAllEvent().Count;

            numOfUsers = BLL.User.GetAllUsers().Count;

            numOfCircles = DAL.CircleDAO.GetAllCircles().Count;
        }
    }
}