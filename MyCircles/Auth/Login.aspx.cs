using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyCircles.BLL;
using MyCircles.DAL;

namespace MyCircles
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RedirectValidator.isSignedOut();
        }

        // TODO: Use email verification and forgot password
        // TODO: Points system to make your circle bigger

        protected void btLogin_Click(object sender, EventArgs e)
        {
            try
            {
                signedOutErrorContainer.Visible = false;
                User user = new User();
                UserDAO userDataAdapter = new UserDAO();
                string identifier = tbUsername.Text;
                string password = tbPassword.Text;

                user = userDataAdapter.VerifyCredentials(identifier, password);

                Session["currentUser"] = user;
                Response.Redirect("/Redirect.aspx");
            }
            catch (DbEntityValidationException ex)
            {
                signedOutErrorContainer.Visible = true;
                lbErrorMsg.Text = ex.EntityValidationErrors.FirstOrDefault().ValidationErrors.FirstOrDefault().ErrorMessage;
            }
            catch (Exception ex)
            {
                signedOutErrorContainer.Visible = true;
                lbErrorMsg.Text = ex.Message;
            }
        }

        protected void btGoogleSignIn_Click(object sender, EventArgs e)
        {
                
        }

        protected void btRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}