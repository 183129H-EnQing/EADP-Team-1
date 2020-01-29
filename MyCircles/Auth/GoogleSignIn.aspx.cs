using MyCircles.BLL;
using MyCircles.DAL;
using Nemiro.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyCircles.Auth
{
    public partial class GoogleSignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var result = OAuthWeb.VerifyAuthorization();

            if (result.IsSuccessfully)
            {
                Session["AccessToken"] = result.AccessTokenValue;
                var existingUser = UserDAO.GetUserByIdentifier(result.UserInfo.Email);

                if (existingUser == null) 
                {
                    User newUser = new User();
                    newUser.EmailAddress = result.UserInfo.Email;
                    newUser.Username = ((newUser.EmailAddress).Split('@'))[0];
                    newUser.ProfileImage = result.UserInfo.Userpic;
                    newUser.Name = result.UserInfo.FirstName;
                    newUser.IsGoogleUser = true;
                    UserDAO.AddGoogleUser(newUser);

                    newUser.ToggleLoginStatus(true);
                    Session["currentUser"] = newUser;
                }
                else
                {
                    existingUser.ToggleLoginStatus(true);
                    Session["currentUser"] = existingUser;
                }

                Response.Redirect("/Redirect.aspx");
            }
            else
            {
                Response.Write("Error: " + result.ErrorInfo.Message);
            }
        }
    }
}