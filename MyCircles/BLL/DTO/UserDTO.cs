using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCircles.BLL
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string City { get; set; }
        public string ProfileImage { get; set; }
        public bool IsLoggedIn { get; set; }
        public bool IsFollowedByUser { get; set; }
        public bool IsUser { get; set; } = true;
    }
}