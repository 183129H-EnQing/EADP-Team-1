using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using MyCircles.BLL;

namespace MyCircles.DAL
{
    public class AdminDAO
    {
        public static void AddAdmin(BLL.Admin admin)
        {
            using (MyCirclesEntityModel db = new MyCirclesEntityModel())
            {
                db.Admins.Add(admin);
                db.SaveChanges();
            }
        }

        public static BLL.Admin GetAdmin(User user)
        {
            BLL.Admin admin = null;
            using (MyCirclesEntityModel db = new MyCirclesEntityModel())
            {
                admin = db.Admins.Where(ad => ad.UserId == user.Id).FirstOrDefault();
            }
            return admin;
        }
    }
}