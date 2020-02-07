using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCircles.BLL
{
    public class NotificationDTO
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Action { get; set; }
        public string Source { get; set; }
        public string AdditionalMessage { get; set; }
        public string CallToAction { get; set; }
        public string CallToActionLink { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }
    }
}