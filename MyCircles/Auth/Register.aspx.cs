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
    public partial class Register : System.Web.UI.Page
    {
        User newUser = new User();

        // TODO: Show error for required fields
        // TODO: Give each user their own colour theme

        protected void Page_Load(object sender, EventArgs e)
        {
            RedirectValidator.isSignedOut();
        }

        protected void btRegister_Click(object sender, EventArgs e)
        {
            try { 
                newUser.Name = tbName.Text;
                newUser.EmailAddress = tbEmailAddress.Text;
                newUser.Username = tbUsername.Text;
                newUser.Password = tbPassword.Text;
                Page.Validate();

                if (Page.IsValid)
                {
                    newUser.AddUserToDb();
                    Response.Redirect("Login.aspx");
                }
            }
            catch (DbEntityValidationException ex)
            {
                GeneralHelpers.AddValidationError(Page, "registerErrGroup", ex.EntityValidationErrors.FirstOrDefault().ValidationErrors.FirstOrDefault().ErrorMessage);
            }
            catch (Exception ex)
            {
                GeneralHelpers.AddValidationError(Page, "registerErrGroup", ex.Message);
            }
            finally
            {
                if (!Page.IsValid)
                {
                    signedOutErrorContainer.Visible = true;
                    lbErrorMsg.Text = GeneralHelpers.GetFirstValidationError(Page.Validators);
                }

                btRegister.Enabled = true;
                btRegister.Text = "Register";
            }
        }

        protected void btBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}