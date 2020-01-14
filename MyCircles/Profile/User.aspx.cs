using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using MyCircles.BLL;
using static MyCircles.DAL.UserDAO;

namespace MyCircles.Profile
{
    //TODO: Edit profile with messages if mutuals/don't show location on map

    public partial class User : System.Web.UI.Page
    {
        public BLL.User currentUser, requestedUser;
        public double? latitude, longitude;

        protected void Page_Load(object sender, EventArgs e)
        {
            RedirectValidator.isUser();
            currentUser = (BLL.User)Session["currentUser"];

            string requestedUsername = Request.QueryString["username"];
            requestedUser = GetUserByIdentifier(requestedUsername);

            if (requestedUser == null) requestedUser = currentUser;

            latitude = (requestedUser.Latitude == null) ? -1 : requestedUser.Latitude;
            longitude = (requestedUser.Longitude == null) ? -1 : requestedUser.Longitude;
            Title = requestedUser.Username + " - MyCircles";

            byte[] imagem = requestedUser.ProfileImage;
            string PROFILE_PIC = Convert.ToBase64String(imagem);

            ProfilePicImage.ImageUrl = String.Format("data:image/jpg;base64,{0}", PROFILE_PIC);
            lbName.InnerText = requestedUser.Name;
            lbUsername.InnerText = "@" + requestedUser.Username;
            lbBio.InnerText = requestedUser.Bio;

            if (String.IsNullOrEmpty(requestedUser.Bio)) lbBio.Visible = false;
        }

        protected void btRefresh_Click(object sender, EventArgs e)
        {

        }
    }
}