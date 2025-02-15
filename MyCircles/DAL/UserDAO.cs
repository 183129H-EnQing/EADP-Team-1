﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using MyCircles.BLL;

namespace MyCircles.DAL
{
    public static class UserDAO
    {
        public static void AddUser(User newUser)
        {
            using (var db = new MyCirclesEntityModel())
            {
                if (String.IsNullOrEmpty(newUser.Password))
                {
                    throw new ArgumentException("Required fields are not filled up");
                }
                else
                {
                    if (db.Users.Any(u => u.Username == newUser.Username))
                    {
                        throw new ArgumentException("That username is not available");
                    }

                    if (db.Users.Any(u => u.EmailAddress == newUser.EmailAddress))
                    {
                        throw new ArgumentException("There's an account registered with that email");
                    }

                    newUser.Password = Crypto.HashPassword(newUser.Password);
                    newUser.ProfileImage = "/Content/images/DefaultProfileIcon.png";

                    db.Users.Add(newUser);
                    db.SaveChanges();
                }
            }
        }

        public static void AddGoogleUser(User newUser)
        {
            using (var db = new MyCirclesEntityModel())
            {
                db.Users.Add(newUser);
                db.SaveChanges();
            }
        }

        public static void EditUser(User editedUser)
        {
            using (var db = new MyCirclesEntityModel())
            {
                User currentUser = db.Users.Where(u => u.Id == editedUser.Id).FirstOrDefault();

                currentUser.Id = editedUser.Id;
                currentUser.Username = editedUser.Username;
                currentUser.Bio = editedUser.Bio;
                currentUser.ProfileImage = editedUser.ProfileImage;
               
                db.SaveChanges();
            }

        }

        public static User GetUserByIdentifier(string identifier)
        {
            User user = new User();

            using (MyCirclesEntityModel db = new MyCirclesEntityModel())
            {
                user = db.Users
                        .Where(u => u.EmailAddress == identifier || u.Username == identifier)
                        .FirstOrDefault();
            }

            return user;
        }

        public static User GetUserById(int userId)
        {
            User user = null;

            using (MyCirclesEntityModel db = new MyCirclesEntityModel())
            {
                user = db.Users
                        .Where(u => u.Id == userId)
                        .FirstOrDefault();
            }

            return user;
        }

        public static User VerifyCredentials(string identfier, string password)
        {
            User testUser = new User();
            User user = new User();

            testUser.EmailAddress = identfier;
            testUser.Username = identfier;
            testUser.Password = password;

            using (MyCirclesEntityModel db = new MyCirclesEntityModel())
            {
                user = db.Users
                        .Where(u => u.EmailAddress == testUser.EmailAddress || u.Username == testUser.Username)
                        .FirstOrDefault();

                if (user != null)
                {
                    if (user.IsDeleted)
                    {
                        throw new ArgumentException("Your account is disabled");
                    }
                    else if (!user.IsGoogleUser)
                    {
                        if (!Crypto.VerifyHashedPassword(user.Password, testUser.Password))
                        {
                            user = null;
                            throw new ArgumentException("That password is not correct");
                        } 
                    }
                    else
                    {
                        throw new ArgumentException("Please sign in using your existing Google account");
                    }
                }
                else
                {
                    throw new ArgumentException("That account does not exist");
                }
            }

            return user;
        }

        public static void UpdateUserLocation(int id, double? latitude, double? longitude, string city)
        {
            using (MyCirclesEntityModel db = new MyCirclesEntityModel())
            {
                var userQuery = db.Users
                        .Where(u => u.Id == id)
                        .FirstOrDefault();

                userQuery.Latitude = latitude;
                userQuery.Longitude = longitude;
                userQuery.City = city;

                db.SaveChanges();
            }
        }

        public static void ToggleLoginStatus(int id, bool isLoggedIn)
        {
            using (MyCirclesEntityModel db = new MyCirclesEntityModel())
            {
                User user = db.Users
                    .Where(u => u.Id == id)
                    .FirstOrDefault();

                user.IsLoggedIn = isLoggedIn;

                db.SaveChanges();
            }
        }

        public static List<User> GetAllUsers()
        {
            using (MyCirclesEntityModel db = new MyCirclesEntityModel())
            {
                return db.Users.ToList();
            }
        }

        public static List<User>GetNewUser(int id)
        {
            using (MyCirclesEntityModel db = new MyCirclesEntityModel())
            {
                var followuser = FollowDAO.GetAllFollowingUsers(id);
                var getUser = db.Users.Where(u => u.Id != id).ToList();
                var notFollowuser = new List<User>();

                for (int i = 0; followuser.Count > i; i++ )
                {
                    for (int j=0; getUser.Count > j; j++)
                    {
                        if (followuser[i].User.Id != getUser[j].Id)
                        { 
                            notFollowuser.Add(getUser[j]);
                        }
                    }
                }

                return notFollowuser;
                     
            }
        }

        public static void UpdateIsEventHost(int id, bool isEventHost)
        {
            using (MyCirclesEntityModel db = new MyCirclesEntityModel())
            {
                User user = db.Users
                        .Where(u => u.Id == id)
                        .FirstOrDefault();

                user.IsEventHolder = isEventHost;

                db.SaveChanges();
            }
        }

        public static void UpdateIsDisabled(int id, bool isDisabled)
        {
            using (MyCirclesEntityModel db = new MyCirclesEntityModel())
            {
                User user = db.Users
                        .Where(u => u.Id == id)
                        .FirstOrDefault();

                user.IsDeleted = isDisabled;
                db.SaveChanges();
            }
        }
    }
}