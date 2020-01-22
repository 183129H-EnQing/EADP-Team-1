using MyCircles;
using System;

namespace MyCircles.Admin
{
    public partial class Home : System.Web.UI.Page
    {
        public int numOfReportedPosts;
        public int numOfEventHosts;

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
        }
    }
}