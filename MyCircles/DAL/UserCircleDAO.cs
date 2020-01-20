using MyCircles.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCircles.DAL
{
    public static class UserCircleDAO
    {
        public static void AddUserCircle(int userId, string circleName)
        {
            using (var db = new MyCirclesEntityModel())
            {
                UserCircle newUserCircle = new UserCircle();
                Circle existingCircle = db.Circles.Where(ec => ec.Id == circleName).FirstOrDefault();

                if (existingCircle == null)
                {
                    existingCircle = CircleDAO.AddCircle(circleName);
                }

                newUserCircle.CircleId = existingCircle.Id;
                newUserCircle.UserId = userId;

                db.UserCircles.Add(newUserCircle);
                db.SaveChanges();
            }
        }
    }
}