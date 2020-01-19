using MyCircles.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCircles.BLL {    // partial - means the extend the modal
    // EventDAM class name can be changed to the modal name,example event table
    public partial class Event
    {
        //public void Add()
        //{
        //    EventDAO.AddEvent(this);
        //}

        public static List<Event> GetEvent()
        {
            return EventDAO.GetAllEvent();
        }


    }
}