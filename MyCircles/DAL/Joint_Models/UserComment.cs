using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyCircles.BLL;

namespace MyCircles.DAL
{
    public class UserComment
    {
        public User User { get; set; }
        public Comment Comment { get; set; }

        public UserComment(User user, Comment comment)
        {
            this.User = user;
            this.Comment = comment;
        }
    }
}