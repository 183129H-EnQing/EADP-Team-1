using MyCircles.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCircles.DAL
{
    public static class CircleDAO
    {
        public static void AddCircle(string circleName)
        {
            using (var db = new MyCirclesEntityModel())
            {
                Circle newCircle = new Circle();
                Circle existingCircle = db.Circles.Where(ec => ec.Name == circleName).FirstOrDefault();

                if (existingCircle == null)
                {
                    db.Circles.Add(newCircle);
                    db.SaveChanges();
                }
            }
        }
    }
}