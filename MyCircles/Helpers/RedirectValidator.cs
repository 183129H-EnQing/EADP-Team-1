using MyCircles.BLL;
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
                using (var db = new MyCirclesEntityModel())
                {
                    UserCircle existingUserCircle = db.UserCircles.Where(uc => uc.UserId == currentUser.Id).FirstOrDefault();
                    if (existingUserCircle == null && !isAddingUserCircles) HttpContext.Current.Response.Redirect("/Profile/FollowCircles.aspx");
                }
            } 
        }
    }
}