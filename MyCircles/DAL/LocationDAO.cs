using MyCircles.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCircles.DAL
{
    public class LocationDAO
    {
        public List<Location> GetAllLocation()
        {
            List<Location> allLocaList = new List<Location>();
            using (MyCirclesEntityModel db = new MyCirclesEntityModel())
            {
                allLocaList = db.Locations.ToList();
                return allLocaList;
            }
        }

        public List<Location> ByTagLocation(int locationTag)
        {
            List<Location> locaListByTag = new List<Location>();
            using (MyCirclesEntityModel db = new MyCirclesEntityModel())
            {
                locaListByTag = db.Locations.Where(i => i.landmarkType == locationTag).ToList();
                return locaListByTag;
            }
        }

        public List<Location> ByALocation(int locId)
        {
            List<Location> alocList = new List<Location>();
            using (MyCirclesEntityModel db = new MyCirclesEntityModel())
            {
                alocList = db.Locations.Where(i => i.locaId == locId).ToList();
                return alocList;
            }
        }
    }
}