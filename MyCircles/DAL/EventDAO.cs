using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyCircles.BLL;

namespace MyCircles.DAL
{
    public class EventDAO
    {
        public static void AddEventSignUp(BLL.Event userSignUpDetails)
        {
            using (MyCirclesEntityModel db = new MyCirclesEntityModel())
            {
                db.Events.Add(userSignUpDetails);
                db.SaveChanges();
            }
        }
    }
}