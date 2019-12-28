using System;
using System.Collections.Generic;
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

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btRegister_Click(object sender, EventArgs e)
        {
            newUser.Name = tbName.Text;
            newUser.EmailAddress = tbEmailAddress.Text;
            newUser.Username = tbUsername.Text;
            newUser.Password = tbPassword.Text;

            newUser.AddUser(newUser);
            Response.Redirect("Login.aspx");
        }

        protected void btBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}