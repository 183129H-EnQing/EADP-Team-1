using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCircles.BLL
{
    public class CommentDTO
    {
        public int CommentId { get; set; }
        public UserDTO CommentUser { get; set; }
        public string CommentContent { get; set; }
        public DateTime? CommentDate { get; set; }
        public int PostId { get; set; }
    }
}