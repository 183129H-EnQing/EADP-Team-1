using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyCircles.BLL;

namespace MyCircles.DAL
{
    public static class PostDAO
    {
        public static void   AddPost(Post newPost)
        {
            using (var db = new MyCirclesEntityModel())
            {
                db.Posts.Add(newPost);
                db.SaveChanges();
            }

            }
          
           
            

        
       
    }
}