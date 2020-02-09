using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyCircles.BLL;

namespace MyCircles.DAL
{
    public static class PostDAO
    {
        public static List<Post> GetPosts()
        {
            using (var db = new MyCirclesEntityModel())
            {
                return db.Posts.ToList();
            }
        }

        public static void AddPost(Post newPost)
        {
            using (var db = new MyCirclesEntityModel())
            {
                db.Posts.Add(newPost);
                db.SaveChanges();
            }
        }

        public static List<UserPost> GetPostsByCircle(string circleName)
        {
            using (var db = new MyCirclesEntityModel())
            {
                db.Configuration.LazyLoadingEnabled = false;

                var postList = db.Posts
                    .Where(p => p.CircleId == circleName)
                    .ToList()
                    .Join(
                        db.Users,
                        p => p.UserId,
                        u => u.Id,
                        (post, user) => new UserPost(user, post)
                    )
                    .ToList();

                return postList;
            }
        }

        public static void DeletePost(int postId)
        {
            using (var db = new MyCirclesEntityModel())
            {
                db.Posts.RemoveRange(db.Posts.Where(p => p.Id == postId));
                db.SaveChanges();
            }
        }

        public static Post GetPostById(int postId)
        {
            using (var db = new MyCirclesEntityModel())
            {
                var post = db.Posts.Where(p => p.Id == postId).FirstOrDefault();

                return post;
            }
        }
    }
}