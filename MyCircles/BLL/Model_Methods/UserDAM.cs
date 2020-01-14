using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using static MyCircles.DAL.UserDAO;

namespace MyCircles.BLL
{
    public partial class User
    {
        public void AddUserToDb()
        {
            AddUser(this);
        }

        public void UpdateUserLocation()
        {
            DAL.UserDAO.UpdateUserLocation(this.Id, this.Latitude, this.Longitude);
        }
    }
}
