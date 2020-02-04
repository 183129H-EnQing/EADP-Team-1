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
        public int numOfEventHosts;
        public int numOfEvents;

        protected void Page_Load(object sender, EventArgs e)
        {
            numOfReportedPosts = BLL.ReportedPost.GetAllReportedPosts().Count;
            System.Diagnostics.Debug.WriteLine("num reported posts: " + numOfReportedPosts);

            numOfEventHosts = 0;
            foreach (BLL.User user in BLL.User.GetAllUsers())
            {
                if (user.IsEventHolder == true)
                {
                    numOfEventHosts += 1;
                }
            }

            numOfEvents = BLL.Event.GetAllEvent().Count;
        }
    }
}