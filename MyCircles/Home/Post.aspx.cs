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

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btn6_Click(object sender, EventArgs e)
        {
            Response.Redirect("PeopleNearby.aspx");
        }

        protected void UploadThisFile(FileUpload upload)
        {
            if (upload.HasFile)
            {
                string theFileName = Path.Combine(Server.MapPath("~/Content/images"), upload.FileName);
                if (File.Exists(theFileName))
                {
                    File.Delete(theFileName);
                }
                upload.SaveAs(theFileName);
            }
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
          
                try
            {

                if (FileUpload1.HasFile)
                {
                    string strname = FileUpload1.FileName.ToString();
                    FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Content/images/") + strname);
                    Response.Redirect(Request.Url.AbsoluteUri);
                    var newPost = new BLL.Post();
                    newPost.Content = activity.Text;
                    newPost.DateTime = DateTime.Now;
                    newPost.Image = strname;
                    newPost.UserId = currentUser.Id;
                    newPost.CircleId = "gym";

                    PostDAO.AddPost(newPost);

                    rptUserPosts.DataSource = PostDAO.GetPostsByCircle("gym");
                    rptUserPosts.DataBind();
                }
                else
                {
                    var newPost = new BLL.Post();
                    newPost.Content = activity.Text;
                    newPost.DateTime = DateTime.Now;
                    newPost.Image = FileUpload1.ToString();
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
        protected void Btncircle_Click(object sender, EventArgs e)
        {
          
           
        }
        protected void UploadFile(object sender, EventArgs e)
        {
            string folderPath = Server.MapPath("~/Files/");

            //Check whether Directory (Folder) exists.
            if (!Directory.Exists(folderPath))
            {
                //If Directory (Folder) does not exists Create it.
                Directory.CreateDirectory(folderPath);
            }

            //Save the File to the Directory (Folder).
            //upldFile.SaveAs(folderPath + Path.GetFileName(upldFile.FileName));

            //Display the Picture in Image control.
           // Image1.ImageUrl = "~/Files/" + Path.GetFileName(upldFile.FileName);
        }

    }
}