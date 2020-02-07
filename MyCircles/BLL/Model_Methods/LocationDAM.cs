using MyCircles.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCircles.BLL
{
    public partial class Location
    {
        public List<Location> RetrieveAllLocation()
        {
            LocationDAO dao = new LocationDAO();
            return dao.GetAllLocation();
        }

        public List<Location> RetrieveByTag(int locationTag)
        {
            LocationDAO dao = new LocationDAO();
            return dao.ByTagLocation(locationTag);
        }

        public List<Location> RetrieveALocation(int locId)
        {
            LocationDAO dao = new LocationDAO();
            return dao.ByALocation(locId);
        }
    }
}