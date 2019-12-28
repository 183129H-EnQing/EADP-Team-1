using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using MyCircles.BLL;

namespace MyCircles.DAL
{
    public class UserDAL
    {
        public void AddUser(User newUser)
        {
            using (var db = new MyCirclesEntityModel())
            {
                if (db.Users.Any(u => u.Username == newUser.Username))
                {
                    throw new ArgumentException("That username is not available");
                }

                if (db.Users.Any(u => u.EmailAddress == newUser.EmailAddress))
                {
                    throw new ArgumentException("There's an account registered with that email");
                }

                newUser.Password = Crypto.HashPassword(newUser.Password);
                db.Users.Add(newUser);
                db.SaveChanges();
            }
        }
    }
}