using MyCircles.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCircles.BLL
{
    public partial class Admin
    {
        public void Add()
        {
            AdminDAO.AddAdmin(this);
        }

        public static Admin RetrieveAdmin(User user)
        {
            return AdminDAO.GetAdmin(user);
        }
    }
}