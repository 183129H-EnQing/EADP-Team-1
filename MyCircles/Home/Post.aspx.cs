using MyCircles.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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

        protected void btnPost_Click(object sender, EventArgs e)
        {
            try
            {
                var newPost = new BLL.Post();
                newPost.Content = activity.Text;
                newPost.UserId = currentUser.Id;
                newPost.CircleId = "gym";
                PostDAO.AddPost(newPost);

                rptUserPosts.DataSource = PostDAO.GetPostsByCircle("gym");
                rptUserPosts.DataBind();
            }
            catch (DbEntityValidationException ex)
            {
                var err = ex.EntityValidationErrors.FirstOrDefault().ValidationErrors.FirstOrDefault().ErrorMessage;
            }
        }

        protected void Btncircle_Click(object sender, EventArgs e)
        {
          
           
        }


    }
}