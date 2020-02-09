using MyCircles.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCircles.BLL
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public int UserId { get; set; }
        public string CircleId { get; set; }
        public DateTime? DateTime { get; set; }
        public UserDTO User { get; set; }

        //private List<UserComment> _Comments;
        //public List<UserComment> Comments
        //{
        //    get { return _Comments; }
        //    set { _Comments = CommentDAO.GetCommentByPost(this.Id); }
        //}

        //private User _User;
        //public User User
        //{
        //    get { return _User; }
        //    set { _User = UserDAO.GetUserById(this.UserId); }
        //}

        //public PostDTO()
        //{
        //    Id = Id;
        //    User = UserDAO.GetUserById(UserId);
        //    Comments = CommentDAO.GetCommentByPost(Id);
        //}
    }
}