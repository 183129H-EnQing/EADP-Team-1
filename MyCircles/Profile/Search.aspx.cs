using MyCircles.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyCircles.Profile
{
    //TODO: Change autocomplete no content found text according to which section is clicked
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (BLL.Post post in PostDAO.GetPosts())
            {
                postDataList.InnerHtml += "<option value='" + post.Content + "'>" + post.Content + "</option>";
            }

            foreach (BLL.Circle circle in CircleDAO.GetAllCircles())
            {
                circleDataList.InnerHtml += "<option value='" + circle.Id + "'>" + circle.Id + "</option>";
            }

            foreach (BLL.User user in UserDAO.GetAllUsers())
            {
                userDataList.InnerHtml += "<option value='" + user.Username + "'>" + user.Username + "</option>";
            }
        }
    }
}