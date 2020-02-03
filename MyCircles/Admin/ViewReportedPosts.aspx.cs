using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyCircles.DAL.Joint_Models;
using MyCircles.BLL;

namespace MyCircles.Admin
{
    public partial class ViewReportedPosts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            gvReportedPosts.DataSource = BLL.ReportedPost.GetAllUserReportedPosts();
            gvReportedPosts.DataBind();
        }

        protected void gvReportedPosts_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = gvReportedPosts.SelectedIndex;
            UserReportedPost reportedPost = BLL.ReportedPost.GetAllUserReportedPosts()[id];
            Post post = Post.GetPostById(reportedPost.postId);

            System.Diagnostics.Debug.WriteLine("hi, i am selecting a post, " + post.Id);

            ModalPostImage.ImageUrl = post.Image;
            ModalPostText.Text = post.Content;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openViewPostModal();", true);
        }

        protected void ModalDeleteBtn_Click(object sender, EventArgs e)
        {
            // delete reportedpost data
            // delete post data
        }
    }
}