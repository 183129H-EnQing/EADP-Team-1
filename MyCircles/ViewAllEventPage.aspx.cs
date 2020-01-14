using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyCircles
{
    public partial class ViewEventDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void hello()
        {
            Response.Redirect("ViewEventDetails.aspx");
        }
    }
}