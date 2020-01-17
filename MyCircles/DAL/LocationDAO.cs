using MyCircles.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCircles.DAL
{
    public class LocationDAO
    {
        public List<Location>  GetAllLocation()
        {
            List<Location> allLocaList= new List<Location>();
            using (MyCirclesEntityModel db = new MyCirclesEntityModel())
            {
                allLocaList = db.Locations.ToList();
                return allLocaList;
            }
        }

        public List<Location> LocaListByTag()
        {
            List<Location> locaListByTag = new List<Location>();
            using (MyCirclesEntityModel db = new MyCirclesEntityModel())
            {
                //locaListByTag = db.Locations.Where();
                return locaListByTag;
            }
        }
    }
}