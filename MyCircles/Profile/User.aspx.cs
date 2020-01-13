using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace MyCircles.Profile
{
    public partial class User : System.Web.UI.Page
    {
        public BLL.User currentUser;
        public double? latitude, longitude;

        protected void Page_Load(object sender, EventArgs e)
        {
            RedirectValidator.isUser();

            currentUser = (BLL.User)Session["currentUser"];
            latitude = currentUser.Latitude;
            longitude = currentUser.Longitude;
            Title = currentUser.Username + " - MyCircles";

            byte[] imagem = currentUser.ProfileImage;
            string PROFILE_PIC = Convert.ToBase64String(imagem);

            ProfilePicImage.ImageUrl = String.Format("data:image/jpg;base64,{0}", PROFILE_PIC);
            lbName.InnerText = currentUser.Name;
            lbUsername.InnerText = "@" + currentUser.Username;
            lbBio.InnerText = currentUser.Bio;

            if (String.IsNullOrEmpty(currentUser.Bio)) lbBio.Visible = false;
        }

        protected void btRefresh_Click(object sender, EventArgs e)
        {

        }
    }
}