using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCircles
{
    public static class RedirectValidator
    {
        public static void isSignedOut()
        {
            if (HttpContext.Current.Session["currentUser"] != null) HttpContext.Current.Response.Redirect("/Redirect.aspx");
        }

        public static void isUser()
        {
            if (HttpContext.Current.Session["currentUser"] == null) HttpContext.Current.Response.Redirect("/Auth/Login.aspx");
        }
    }
}