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
        public void AddUser(User newUser)
        {
            UserDAO userAdapter = new UserDAO();
            userAdapter.AddUser(newUser);
        }
    }
}
