using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using MyCircles.DAL;

namespace MyCircles.BLL
{
    public partial class User
    {
        UserDAO userAdapter = new UserDAO();

        public void AddUserToDb()
        {
            userAdapter.AddUser(this);
        }

        public void UpdateUserLocation()
        {
            userAdapter.UpdateUserLocation(this.Id, this.Latitude, this.Longitude);
        }
    }
}
