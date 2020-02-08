using MyCircles.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCircles.DAL
{
    public static class UserCircleDAO
    {
        public static UserCircle GetUserCircleByCircleAndUserId(int userId, string circleName)
        {
            using (var db = new MyCirclesEntityModel())
            {
                return db.UserCircles
                    .Where(uc => uc.UserId == userId && uc.CircleId == circleName).FirstOrDefault();
            }
        }

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

        public static UserCircle AddUserCircle(UserCircle newUserCircle)
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

                return newUserCircle;
            }
        }

        public static void ChangeUserCirclePoints(int userId, string circleName, int points, string source, bool addNotification)
        {
            using (var db = new MyCirclesEntityModel())
            {
                UserCircle userCircle = GetUserCircleByCircleAndUserId(userId, circleName);

                if (userCircle != null)
                {
                    userCircle.Points += points;
                    db.SaveChanges();

                    if (addNotification)
                    {
                        Notification notification = new Notification();
                        notification.Type = (points > 0) ? "positive" : "negative";
                        notification.Action = (points > 0) ? "Gained" : "Lost";
                        notification.Action += $" {points} points in {circleName}";
                        notification.Source = source;
                        notification.UserId = userId;
                        NotificationDAO.AddNotification(notification);
                    }
                }
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

        public static List<CircleFollowerDetails> GetCircleFollowerDetails(string circleId)
        {
            using (var db = new MyCirclesEntityModel())
            {
                db.Configuration.LazyLoadingEnabled = false;

                var circleFollowerDetails =
                    db.UserCircles
                        .Where(uc => uc.CircleId == circleId)
                        .OrderByDescending(uc => uc.Points)
                        .ToList()
                        .Join(
                            db.Users,
                            uc => uc.UserId,
                            user => user.Id,
                            (uc, user) => new CircleFollowerDetails(user, uc)
                        )
                        .ToList();

                return circleFollowerDetails;
            }
        }
    }
}