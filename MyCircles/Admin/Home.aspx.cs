using MyCircles.BLL;
using System;

namespace MyCircles.Admin
{
    public partial class Home : System.Web.UI.Page
    {
        public int numOfReportedPosts;

        protected void Page_Load(object sender, EventArgs e)
        {
            numOfReportedPosts = ReportedPost.getAllReportedPosts().Count;
            System.Diagnostics.Debug.WriteLine("num reported posts: " + numOfReportedPosts);
        }
    }
}