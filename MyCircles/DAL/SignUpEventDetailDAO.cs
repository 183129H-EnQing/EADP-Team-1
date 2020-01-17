using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyCircles.BLL;

namespace MyCircles.DAL
{
    public class SignUpEventDetailDAO
    {
        public static void AddEventSignUp(BLL.SignUpEventDetail userSignUpDetails)
        {
            using (MyCirclesEntityModel db = new MyCirclesEntityModel())
            {
                db.SignUpEventDetails.Add(userSignUpDetails);
                db.SaveChanges();
            }
        }
    }
}