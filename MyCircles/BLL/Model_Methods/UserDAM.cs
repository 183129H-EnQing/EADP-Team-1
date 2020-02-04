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
            DAL.UserDAO.UpdateUserLocation(Id, Latitude, Longitude, City);
        }

        public void ToggleLoginStatus(bool isLoggedIn)
        {
            DAL.UserDAO.ToggleLoginStatus(Id, isLoggedIn);
        }

        public void UpdateIsEventHost(bool isEventHost)
        {
            DAL.UserDAO.UpdateIsEventHost(Id, isEventHost);
        }

        public void UpdateIsDisabled(bool isDisabled)
        {
            DAL.UserDAO.UpdateIsDisabled(Id, isDisabled);
        }

        public static List<User> GetAllUsers()
        {
            return DAL.UserDAO.GetAllUsers();
        }

        public static User GetUserById(int userId)
        {
            return DAL.UserDAO.GetUserById(userId);
        }
    }
}
