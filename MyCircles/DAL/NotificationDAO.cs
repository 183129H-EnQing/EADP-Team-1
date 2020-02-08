using MyCircles.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCircles.DAL
{
    public static class NotificationDAO
    {
        public static void AddNotification(Notification notification)
        {
            using (var db = new MyCirclesEntityModel())
            {
                notification.CreatedAt = DateTime.Now;
                db.Notifications.Add(notification);
                db.SaveChanges();
            }
        }
    }
}