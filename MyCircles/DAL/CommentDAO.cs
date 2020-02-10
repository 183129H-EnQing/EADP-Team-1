using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyCircles.BLL;

namespace MyCircles.DAL
{
    public class CommentDAO
    {
        public static void AddComment(Comment newComment)
        {
            using (var db = new MyCirclesEntityModel())
            {
                db.Comments.Add(newComment);
                db.SaveChanges();
            }

            
        }

        public static List<UserComment> GetCommentByPost(int postid)
        {
            using (var db = new MyCirclesEntityModel())
            {
                db.Configuration.LazyLoadingEnabled = false;

                var commentList = 
                    db.Comments
                    .Where(p => p.PostId == postid)
                    .ToList()
                    .Join(
                        db.Users,
                        p => p.UserId,
                        u => u.Id,
                        (Comment, user) => new UserComment(user, Comment)
                    )
                    .ToList();

                return commentList;
            }
        }

        public static void DeleteComment(int Id)
        {
            using (var db = new MyCirclesEntityModel())
            {
                db.Comments.RemoveRange(db.Comments.Where(p => p.Id == Id));
                db.SaveChanges();
            }
        }

    }
}