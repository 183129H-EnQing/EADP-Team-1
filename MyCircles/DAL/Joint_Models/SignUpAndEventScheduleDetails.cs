using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyCircles.BLL;

namespace MyCircles.DAL
{
    public class SignUpAndEventScheduleDetails
    {
        public SignUpEventDetail SignUpEventDetail { get; set; }
        public EventSchedule EventSchedule { get; set; }

        public SignUpAndEventScheduleDetails(SignUpEventDetail signUpEventDetail, EventSchedule eventSchedule)
        {
            this.SignUpEventDetail = signUpEventDetail;
            this.EventSchedule = eventSchedule;
        }
    }
}