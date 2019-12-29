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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btLogin_Click(object sender, EventArgs e)
        {
            User user = new User();
            UserDAO userDataAdapter = new UserDAO();
            string identifier = tbUsername.Text;
            string password = tbPassword.Text;

            user = userDataAdapter.VerifyCredentials(identifier, password);

            Response.Redirect("/");
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