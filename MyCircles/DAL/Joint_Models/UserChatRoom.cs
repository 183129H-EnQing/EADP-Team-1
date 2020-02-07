using MyCircles.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCircles.DAL
{
    public class UserChatRoom
    {
        public User RequestedUser { get; set; }
        public User CurrentUser { get; set; }
        public ChatRoom ChatRoom { get; set; }

        public UserChatRoom(User requestedUser, User currentUser, ChatRoom chatRoom)
        {
            this.RequestedUser = requestedUser;
            this.CurrentUser = currentUser;
            this.ChatRoom = chatRoom;
        }
    }
}