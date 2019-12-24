using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCircles.BLL
{
    public class User
    {
        public string Username { get; set; }
        public string EmailAddr { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public decimal xGeoPos { get; set; }
        public decimal yGeoPos { get; set; }
        public string ProfileImage { get; set; }
        public string HeaderImage { get; set; }
        public bool isLoggedIn { get; set; }
        public bool IsPrivileged { get; set; }

        public User(string Username, string EmailAddr, string Name)
        {
            this.Username = Username;
            this.EmailAddr = EmailAddr;
            this.Name = Name;
            this.Bio = "";
            this.xGeoPos = 0;
            this.yGeoPos = 0;
            this.ProfileImage = "";
            this.HeaderImage = "";
            this.isLoggedIn = true;
            this.IsPrivileged = false;
        }
    }
}