using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyCircles.Home
{
    public partial class Post : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RedirectValidator.isUser();
        }

        protected void ImageMap1_Click(object sender, ImageMapEventArgs e)
        {
            
        }
    }
}