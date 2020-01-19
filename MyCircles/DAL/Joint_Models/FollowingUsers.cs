using MyCircles.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCircles.DAL
{
    public class FollowingUsers
    {
        public User User { get; set; }
        public Follow Follow { get; set; }

        public FollowingUsers(User user, Follow follow)
        {
            this.User = user;
            this.Follow = follow;
        }
    }
}