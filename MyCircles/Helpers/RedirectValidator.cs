using MyCircles.BLL;
using MyCircles.DAL;
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

        public static void isUser(bool isAddingUserCircles = false)
        {
            User currentUser = (User)HttpContext.Current.Session["currentUser"];

            if (currentUser == null) 
            {
                HttpContext.Current.Response.Redirect("/Auth/Login.aspx");
            }
            else
            {
                List<UserCircle> existingUserCircle = UserCircleDAO.GetAllUserCircles(currentUser.Id);
                if (existingUserCircle.Count.Equals(0) && !isAddingUserCircles) HttpContext.Current.Response.Redirect("/Profile/User.aspx?username=" + currentUser.Username.Trim() + "&addingCircles=true");
                else if (!existingUserCircle.Count.Equals(0) && isAddingUserCircles) HttpContext.Current.Response.Redirect("/Profile/User.aspx?username=" + currentUser.Username.Trim());
            }
        }
    }
}