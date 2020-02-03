using MyCircles.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCircles.BLL
{
    public partial class Post
    {
        public static void AddPost(Post newPost)
        {
            PostDAO.AddPost(newPost);
        }

        public static List<UserPost> GetPostsByCircle(string circleName)
        {
            return PostDAO.GetPostsByCircle(circleName);
        }

        public static Post GetPostById(int postId)
        {
            return PostDAO.GetPostById(postId);
        }
    }
}