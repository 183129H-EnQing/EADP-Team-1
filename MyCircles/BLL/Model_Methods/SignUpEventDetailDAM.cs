using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyCircles.DAL;

namespace MyCircles.BLL
{
    public partial class SignUpEventDetail
    {
        public void Add()
        {
            SignUpEventDetailDAO.AddEventSignUp(this);
        }

        public List<SignUpEventDetail> GetSignUpEventDetails(int eventId)
        {
            return SignUpEventDetailDAO.GetSignUpEventDetails(eventId);
        }

        public List<SignUpEventDetail> getUserSignUpEventDetails(int userId)
        {
            return SignUpEventDetailDAO.getUserSignUpEventDetails(userId);
        }
    }
}