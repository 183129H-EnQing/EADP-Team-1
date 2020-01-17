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
    }
}