using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyCircles.BLL;
using MyCircles.DAL;
using Nemiro.OAuth;

namespace MyCircles
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RedirectValidator.isSignedOut();
            this.Form.DefaultButton = this.btLogin.ID;
        }

        // TODO: Use email verification and forgot password
        // TODO: Points system to make your circle bigger

        protected void btLogin_Click(object sender, EventArgs e)
        {
            try
            {
                signedOutErrorContainer.Visible = false;
                string identifier = tbUsername.Text;
                string password = tbPassword.Text;
                Page.Validate();

                User user = new User();

                user = UserDAO.VerifyCredentials(identifier, password);

                Session["currentUser"] = user;
                Response.Redirect("/Redirect.aspx");
            }
            catch (DbEntityValidationException ex)
            {
                GeneralHelpers.AddValidationError(Page, "loginErrGroup", ex.EntityValidationErrors.FirstOrDefault().ValidationErrors.FirstOrDefault().ErrorMessage);
            }
            catch (Exception ex)
            {
                GeneralHelpers.AddValidationError(Page, "loginErrGroup", ex.Message);
            }
            finally
            {
                if (!Page.IsValid)
                {
                    signedOutErrorContainer.Visible = true;
                    lbErrorMsg.Text = GeneralHelpers.GetFirstValidationError(Page.Validators);
                }

                btLogin.Enabled = true;
                btLogin.Text = "Login";
            }
        }

        protected void btGoogleSignIn_Click(object sender, EventArgs e)
        {
            string returnUrl = new Uri(Request.Url, "GoogleSignIn.aspx").AbsoluteUri;
            OAuthWeb.RedirectToAuthorization("google", returnUrl);
        }

        protected void btRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}