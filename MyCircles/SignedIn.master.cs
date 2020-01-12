using MyCircles.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyCircles
{
    public partial class SignedIn : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RedirectValidator.isUser();

            var currentUser = (User)Session["currentUser"];
            byte[] imagem = (byte[])(currentUser.ProfileImage);
            string PROFILE_PIC = Convert.ToBase64String(imagem);

            ProfilePicNavImage.ImageUrl = String.Format("data:image/jpg;base64,{0}", PROFILE_PIC);
        }
    }
}