using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyCircles.BLL;

namespace MyCircles.DAL
{
    public static class SignUpEventDetailDAO
    {
        public static void AddEventSignUp(BLL.SignUpEventDetail userSignUpDetails)
        {
            using (MyCirclesEntityModel db = new MyCirclesEntityModel())
            {
                db.SignUpEventDetails.Add(userSignUpDetails);

                db.SaveChanges();
            }
        }

        public static List<SignUpEventDetail> GetSignUpEventDetails(int eventId)
        {
            List<SignUpEventDetail> SignUpEventDetailsList = new List<SignUpEventDetail>();
            using (MyCirclesEntityModel db = new MyCirclesEntityModel())
            {
                SignUpEventDetailsList = db.SignUpEventDetails.Where(event1 => event1.eventId == eventId).ToList();
                return SignUpEventDetailsList;
            }
        }

        public static List<SignUpEventDetail> getUserSignUpEventDetails(int userId)
        {
            List<SignUpEventDetail> SignUpEventDetailsList = new List<SignUpEventDetail>();
            using (MyCirclesEntityModel db = new MyCirclesEntityModel())
            {

                SignUpEventDetailsList = db.SignUpEventDetails.Where(i => i.userId == userId).ToList()
                    .Join(
                    db.EventSchedules,
                    signUpDetails => signUpDetails.userId,
                    es => es.usersOptIn.Contains(userId.ToString()),
                    (signUpDetails, es) => new SignUpAndEventScheduleDetails(signUpDetails, es)
                    ).ToList();

                    
                return SignUpEventDetailsList;
            }
        }

          //using (var db = new MyCirclesEntityModel())
          //  {
          //      db.Configuration.LazyLoadingEnabled = false;

          //      var circleFollowerDetails =
          //          db.UserCircles
          //              .Where(uc => uc.CircleId == circleId)
          //              .OrderByDescending(uc => uc.Points)
          //              .ToList()
          //              .Join(
          //                  db.Users,
          //                  uc => uc.UserId,
          //                  user => user.Id,
          //                  (uc, user) => new CircleFollowerDetails(user, uc)
          //              )
          //              .ToList();

          //      return circleFollowerDetails;
          //  }
    }
}