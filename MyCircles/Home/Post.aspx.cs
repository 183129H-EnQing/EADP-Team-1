using MyCircles.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyCircles.Home
{

    public partial class Post : System.Web.UI.Page
    {
        public BLL.User currentUser;

        
       


        protected void Page_Load(object sender, EventArgs e)
        {
            RedirectValidator.isUser();
            currentUser = (BLL.User)Session["currentUser"];

            this.Title = "Home";
            CircleDAO.AddCircle("gym");
            rptUserPosts.DataSource = PostDAO.GetPostsByCircle("gym");
            rptUserPosts.DataBind();
        }

        protected void ImageMap1_Click(object sender, ImageMapEventArgs e)
        {

        }

        protected void btn6_Click(object sender, EventArgs e)
        {
            Response.Redirect("PeopleNearby.aspx");
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {


            try

            {

                var newPost = new BLL.Post();
                newPost.Content = activity.Text;
                newPost.DateTime = DateTime.Now;
                newPost.UserId = currentUser.Id;
                newPost.CircleId = "gym";
                newPost.Image = GeneralHelpers.UploadFile(FileUpload1);
                PostDAO.AddPost(newPost);

                rptUserPosts.DataSource = PostDAO.GetPostsByCircle("gym");
                rptUserPosts.DataBind();

            }
            catch (DbEntityValidationException ex)
            {
                var err = ex.EntityValidationErrors.FirstOrDefault().ValidationErrors.FirstOrDefault().ErrorMessage;
            }
        }
        protected void Comment_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (RepeaterItem item in rptUserPosts.Items)

                {


                    TextBox comment = (TextBox)item.FindControl("hello");
                    var newPost = new BLL.Post();
                    newPost.Comment = comment.Text;
                    newPost.UserId = currentUser.Id;
                    newPost.CircleId = "gym";
                    PostDAO.AddPost(newPost);

                    rptUserPosts.DataSource = PostDAO.GetPostsByCircle("gym");
                    rptUserPosts.DataBind();

                }
            }
            catch (DbEntityValidationException ex)
            {
                var err = ex.EntityValidationErrors.FirstOrDefault().ValidationErrors.FirstOrDefault().ErrorMessage;
            }

        }


        protected string UploadThisFile(FileUpload upload)
        {
            if (upload.HasFile)
            {
                string filename = currentUser.Id + '-' + DateTime.Now.ToString("yyyyMMdd_hhmmss") + '-' + upload.FileName;
                string filepath = Server.MapPath(Path.Combine("/Content/images/shared/" + filename));
                upload.SaveAs(filepath);

                return "/Content/images/shared/" + filename;
            }

            return null;
        }


        protected void Btncircle_Click(object sender, EventArgs e)
        {
          
            

        }

        

        protected void rptUserPosts_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Repeater repeater = (e.Item.FindControl("rptComment") as Repeater);

            var data = e.Item.DataItem;
            DAL.UserPost userpost = data as DAL.UserPost;
            repeater.DataSource = CommentDAO.GetCommentByPost(userpost.Post.Id);
            repeater.DataBind();


            //if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            //{
            //    var post = e.Item.DataItem as DAL.Post;
            //    repeater.DataSource = CommentDAO.GetCommentByPost(post.Id);
            //    repeater.DataBind();
            //}

        }

        protected void rptUserPosts_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if(e.CommandName == "Comment")
            {
                TextBox comment = (e.Item.FindControl("hello") as TextBox);
                var comt = comment.Text;
                var newComment = new BLL.Comment();
                newComment.UserId = currentUser.Id;
                newComment.PostId = Convert.ToInt32(e.CommandArgument);
                newComment.comment_date = DateTime.Now;
                newComment.comment_text = comment.Text;
                CommentDAO.AddComment(newComment);





            }
        }

        protected void report_Click(object sender, EventArgs e)
        {
            var newReport = new BLL.ReportedPost();
            newReport.dateCreated = DateTime.Now;

            

        }
    }
}
