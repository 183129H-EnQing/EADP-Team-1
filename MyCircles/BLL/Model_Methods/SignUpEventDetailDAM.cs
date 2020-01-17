using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyCircles.DAL;

namespace MyCircles.BLL
{
    public partial class SignUpEventDetail
    {
        public void Add()
        {
            SignUpEventDetailDAO.AddEventSignUp(this);
        }
    }
}