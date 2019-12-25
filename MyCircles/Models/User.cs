using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace MyCircles.BLL
{
    public class User
    {
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public decimal xGeoPos { get; set; }
        public decimal yGeoPos { get; set; }
        public string ProfileImage { get; set; }
        public string HeaderImage { get; set; }
        public bool isLoggedIn { get; set; }
        public bool IsPrivileged { get; set; }
        public string Password
        {
            get { return Password; }
            set { Password = Crypto.HashPassword(value); }
        }

        public User(string username, string emailAddress, string name, string password)
        {
            this.Username = username;
            this.EmailAddress = emailAddress;
            this.Name = name;
            this.Password = password;
            this.Bio = null;
            this.xGeoPos = 0;
            this.yGeoPos = 0;
            this.ProfileImage = null;
            this.HeaderImage = null;
            this.isLoggedIn = false;
            this.IsPrivileged = false;
        }
    }
}