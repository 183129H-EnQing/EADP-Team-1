using MyCircles.BLL;
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
        public List<UserPost> UserPosts;

        

        protected void Page_Load(object sender, EventArgs e)
        {
            RedirectValidator.isUser();
            currentUser = (BLL.User)Session["currentUser"];

            var circlesname = UserCircleDAO.GetAllUserCircles(currentUser.Id);

            if (!IsPostBack)
            {
                DropDownList1.DataSource = circlesname;
                DropDownList1.DataTextField = "CircleId";
                DropDownList1.DataValueField = "CircleId";
                DropDownList1.DataBind();

                DropDownList2.DataSource = circlesname;
                DropDownList2.DataTextField = "CircleId";
                DropDownList2.DataValueField = "CircleId";
                DropDownList2.DataBind();


                
            }
            var notfollow = UserDAO.GetNewUser(currentUser.Id);
            Repeater1.DataSource = notfollow;
            Repeater1.DataBind();

            this.Title = "Home";
            //CircleDAO.AddCircle("gym");
            refreshGv();
            
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
                newPost.CircleId = DropDownList1.SelectedValue;
                newPost.Image = GeneralHelpers.UploadFile(FileUpload1);
                PostDAO.AddPost(newPost);

                rptUserPosts.DataSource = PostDAO.GetPostsByCircle("gym");
                rptUserPosts.DataBind();

                UserCircleDAO.ChangeUserCirclePoints(
                    userId: currentUser.Id,
                    circleName: newPost.CircleId,
                    points: 30,
                    source: "creating a new post",
                    addNotification: true
                );
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

                refreshGv();
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
            var deltee = e.Item.ItemIndex;
            
            var dletepost = userpost.User.Id;
            Button delte = (e.Item.FindControl("Delete") as Button);
            HyperLink report = (e.Item.FindControl("mreport") as HyperLink);

            if (currentUser.Id == dletepost )
            {
          
                delte.Visible = true;
         
            }
            else
            {
                delte.Visible = false;
               
            }
            
          

            //if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            //{
            //    var post = e.Item.DataItem as DAL.Post;
            //    repeater.DataSource = CommentDAO.GetCommentByPost(post.Id);
            //    repeater.DataBind();
            //}

        }
   
        protected void rptUserPosts_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Repeater repeater = (e.Item.FindControl("rptComment") as Repeater);
            if (e.CommandName == "Comment")
                {
                    TextBox comment = (e.Item.FindControl("hello") as TextBox);
                    var comt = comment.Text;
                    var newComment = new BLL.Comment();
                    newComment.UserId = currentUser.Id;
                    newComment.PostId = Convert.ToInt32(e.CommandArgument);
                    newComment.comment_date = DateTime.Now;
                    newComment.comment_text = comment.Text;
                    CommentDAO.AddComment(newComment);
                    comment.Text = String.Empty;

                    repeater.DataSource = CommentDAO.GetCommentByPost(Convert.ToInt32(e.CommandArgument));
                    repeater.DataBind();
            }
                if (e.CommandName == "Report")
                {

                    RadioButtonList report = (e.Item.FindControl("RadioButtonList1") as RadioButtonList);
                    var userpostindex = e.Item.ItemIndex;
                    var rpt = report.SelectedValue;
                    List<UserPost> userposts = new List<UserPost>();
                    UserPost selecteduserpost = ((List<UserPost>)rptUserPosts.DataSource)[userpostindex];
                    var newReport = new BLL.ReportedPost();
                    newReport.postId = selecteduserpost.Post.Id;
                    newReport.reason = rpt;
                    newReport.dateCreated = DateTime.Now;
                    newReport.reporterUserId = currentUser.Id;
                    ReportedPostDAO.AddReport(newReport);
                     
                }

                if (e.CommandName == "Delete")
                {
                    var deleteId = Convert.ToInt32(e.CommandArgument);
                    var userpostindex = e.Item.ItemIndex;
                    UserPost selecteduserpost = ((List<UserPost>)rptUserPosts.DataSource)[userpostindex];



                    if (currentUser.Id == selecteduserpost.User.Id)
                    {

                        CommentDAO.DeleteCommentByPostId(selecteduserpost.Post.Id);
                        ReportedPostDAO.DeleteReportedPostByPostId(selecteduserpost.Post.Id);
                        PostDAO.DeletePost(deleteId);
                        refreshGv();

                        UserCircleDAO.ChangeUserCirclePoints(
                            userId: currentUser.Id,
                            circleName: selecteduserpost.Post.CircleId,
                            points: -30,
                            source: "removing a post",
                            addNotification: true
                        );
                }


                }

            }


        



        public void refreshGv()
        {
            List<UserPost> userposts = new List<UserPost>();
            List<BLL.UserCircle> userCircles = UserCircleDAO.GetAllUserCircles(currentUser.Id);

            foreach (BLL.UserCircle circle in userCircles)
            {
                List<UserPost> posts = PostDAO.GetPostsByCircle(circle.CircleId);
                foreach (UserPost post in posts)
                {
                    userposts.Add(post);
                }
            }
            
            rptUserPosts.DataSource = userposts;
            rptUserPosts.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Profile/User.aspx");
        }

        protected void rptComment_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

          if(e.CommandName == "Remove")
            {
                var commentId = Convert.ToInt32(e.CommandArgument);
                var userpostindex = e.Item.ItemIndex;
                BLL.Comment selecteduserpost = CommentDAO.GetCommentById(commentId);
                if (currentUser.Id == selecteduserpost.UserId)
                {                   
                    CommentDAO.DeleteComment(commentId);
                    refreshGv();
                }

            }

        }

        protected void rptComment_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Button delte = (e.Item.FindControl("remove") as Button);
            var data = e.Item.DataItem;

            DAL.UserComment usercomment = data as DAL.UserComment;
            delte.Visible = usercomment.User.Id == currentUser.Id;
        }
    }
}
