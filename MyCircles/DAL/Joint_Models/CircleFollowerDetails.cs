using MyCircles.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCircles.DAL
{
    public class CircleFollowerDetails
    {
        public User User { get; set; }
        public UserCircle UserCircle { get; set; }

        public CircleFollowerDetails(User user, UserCircle userCircle)
        {
            this.User = user;
            this.UserCircle = userCircle;
        }
    }
}