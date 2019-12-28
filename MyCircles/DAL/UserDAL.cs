using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyCircles.BLL;

namespace MyCircles.DAL
{
    public class UserDAL
    {
        public void AddUser(User newUser)
        {
            using (var db = new MyCirclesEntityModel())
            {
                if (db.Users.Any(u => u.Username != newUser.Username))
                {
                    db.Users.Add(newUser);
                    db.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("Username already exists, choose another username.");
                }
            }
        }
    }
}