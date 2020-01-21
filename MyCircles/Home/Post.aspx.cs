using MyCircles.DAL;
using System;
using System.Collections.Generic;
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

            lblUsername.Text = currentUser.Name;
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
            var newPost = new BLL.Post();
            newPost.Content = LPost.Text;
            mypost.Visible = true;
            newPost.UserId = currentUser.Id;
            LPost.Text = activity.Text;
            PostDAO.AddPost(newPost);
        }

        protected void Btncircle_Click(object sender, EventArgs e)
        {
          
           
        }


    }
}