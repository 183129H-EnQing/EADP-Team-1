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

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btRegister_Click(object sender, EventArgs e)
        {
            try { 
                newUser.Name = tbName.Text;
                newUser.EmailAddress = tbEmailAddress.Text;
                newUser.Username = tbUsername.Text;
                newUser.Password = tbPassword.Text;

                newUser.AddUser(newUser);
                Response.Redirect("Login.aspx");
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

        protected void btBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}