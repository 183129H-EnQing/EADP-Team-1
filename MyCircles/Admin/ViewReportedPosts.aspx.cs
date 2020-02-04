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
            refreshGridView();
        }

        protected void ModalDeleteBtn_Click(object sender, EventArgs e)
        {
            int idx = gvReportedPosts.SelectedIndex;
            deleteOp(idx);
        }

        protected void gvReportedPosts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idx = int.Parse(e.CommandArgument.ToString());
            switch (e.CommandName)
            {
                case "ViewPost":
                    System.Diagnostics.Debug.WriteLine("gvReportedPosts_RowCommand, ViewPost:" + e.CommandArgument);
                    UserReportedPost userReportedPost = ReportedPost.GetAllUserReportedPosts()[idx];
                    Post post = Post.GetPostById(userReportedPost.postId);
                    User postCreator = BLL.User.GetUserById(post.UserId);

                    System.Diagnostics.Debug.WriteLine("gv SelectedIndexChanged," + post.Id);

                    lblModalPostCreatorName.Text = postCreator.Username;
                    imgModalPost.ImageUrl = post.Image;
                    lblModalContent.Text = post.Content;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openViewPostModal();", true);
                    break;
                case "DeletePost":
                    System.Diagnostics.Debug.WriteLine("gvReportedPosts_RowCommand, DeletePost:" + e.CommandArgument);
                    deleteOp(idx);
                    break;
            }
        }

        public void deleteOp(int index)
        {
            System.Diagnostics.Debug.WriteLine("deleteOp, index:" + index);
            UserReportedPost userReportedPost = ReportedPost.GetAllUserReportedPosts()[index];
            Post post = Post.GetPostById(userReportedPost.postId);

            System.Diagnostics.Debug.WriteLine("deleteOp, postId:" + post.Id);

            // delete reportedpost data
            ReportedPost rp = ReportedPost.GetReportedPostById(userReportedPost.id);
            System.Diagnostics.Debug.WriteLine("deleteOp, reportedPost:" + rp.reason);
            ReportedPost.DeleteReportedPost(userReportedPost.id);

            // delete post data
            //Post.DeletePost(post.Id);

            // TODO - Investigate why cannot use remove, but removeRange can work for inside the DAO

            refreshGridView();
        }

        public void refreshGridView()
        {
            gvReportedPosts.DataSource = ReportedPost.GetAllUserReportedPosts();
            gvReportedPosts.DataBind();
        }
    }
}