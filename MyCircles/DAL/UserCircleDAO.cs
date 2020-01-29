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

        public static void AddUserCircle(UserCircle newUserCircle)
        {
            using (var db = new MyCirclesEntityModel())
            {
                Circle existingCircle = db.Circles.Where(ec => ec.Id == newUserCircle.CircleId).FirstOrDefault();

                if (existingCircle == null)
                {
                    existingCircle = CircleDAO.AddCircle(newUserCircle.CircleId);
                }

                db.UserCircles.Add(newUserCircle);
                db.SaveChanges();
            }
        }

        public static List<UserCircle> GetAllUserCircles(int userId)
        {
            using (var db = new MyCirclesEntityModel())
            {
                List<UserCircle> existingUserCircles = db.UserCircles.Where(uc => uc.UserId == userId).ToList();
                return existingUserCircles;
            }
        }

        public static void RemoveUserCircles(int userId)
        {
            using (var db = new MyCirclesEntityModel())
            {
                db.UserCircles.RemoveRange(db.UserCircles.Where(uc => uc.UserId == userId));
                db.SaveChanges();
            }
        }
    }
}