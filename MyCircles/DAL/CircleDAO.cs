using MyCircles.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCircles.DAL
{
    public static class CircleDAO
    {
        public static Circle AddCircle(string circleName)
        {
            Circle newCircle = null;

            using (var db = new MyCirclesEntityModel())
            {
                Circle existingCircle = db.Circles.Where(ec => ec.Id == circleName).FirstOrDefault();

                if (existingCircle == null)
                {
                    newCircle = new Circle();
                    newCircle.Id = circleName;
                    db.Circles.Add(newCircle);
                }

                db.SaveChanges();
            }

            return newCircle;
        }

        public static List<Circle> GetAllCircles()
        {
            using (var db = new MyCirclesEntityModel())
            {
                List<Circle> existingCircleList = db.Circles.ToList();
                return existingCircleList;
            }
        }
    }
}