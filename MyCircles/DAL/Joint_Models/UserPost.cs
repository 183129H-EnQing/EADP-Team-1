using MyCircles.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCircles.DAL
{
    public class UserPost
    {
        public User User { get; set; }
        public Post Post { get; set; }

        public UserPost(User user, Post post)
        {
            this.User = user;
            this.Post = post;
        }
    }
}