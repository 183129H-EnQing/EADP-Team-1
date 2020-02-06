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
        private string keySessionRowIdx = "ViewReportedPostsRowIdx";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session[keySessionRowIdx] = -1;
            }

            refreshGridView();
        }

        protected void ModalDeleteBtn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("ModalDeleteBtn_Click," + Session[keySessionRowIdx]);
            int selectedRowIdx = (int) Session[keySessionRowIdx];
            if (selectedRowIdx > -1)
            {
                deleteOp(selectedRowIdx);
                System.Diagnostics.Debug.WriteLine("Delete Btn click!");
            }

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "closeViewPostModal();", true);
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
                    Session[keySessionRowIdx] = idx;

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
            // TODO deleting from modal, index is out of range
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

        private void refreshGridView()
        {
            gvReportedPosts.DataSource = ReportedPost.GetAllUserReportedPosts();
            gvReportedPosts.DataBind();
        }
    }
}