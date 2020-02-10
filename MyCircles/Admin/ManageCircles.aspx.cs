using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyCircles.Admin
{
    public partial class ManageCircles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            refreshGv();
        }

        protected void gvCircles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteCircle")
            {
                int idx = int.Parse(e.CommandArgument.ToString());
                System.Diagnostics.Debug.WriteLine("Delete! " + idx);

                BLL.Circle circle = DAL.CircleDAO.GetAllCircles()[idx];

                foreach (DAL.UserPost post in DAL.PostDAO.GetPostsByCircle(circle.Id))
                {
                    // Delete Report's reference
                    BLL.ReportedPost.DeleteReportedPostByPostId(post.Post.Id);

                    // Delete Post first
                    DAL.PostDAO.DeletePost(post.Post.Id);
                }

                // Delete UserCircles next
                DAL.UserCircleDAO.RemoveUserCircleByCircleId(circle.Id);

                // Delete Circles in the end
                DAL.CircleDAO.RemoveUserCircleByCircleId(circle.Id);

                refreshGv();
            }
        }

        public void refreshGv()
        {
            List<BLL.Circle> circles = DAL.CircleDAO.GetAllCircles();

            gvCircles.DataSource = circles;
            gvCircles.DataBind();
        }
    }
}