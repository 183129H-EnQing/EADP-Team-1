using MyCircles.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCircles.DAL
{
    public static class MessageDAO
    {
        public static List<Message> GetChatRoomMessages(int chatRoomId)
        {
            using (var db = new MyCirclesEntityModel())
            {
                return db.Messages.Where(m => m.ChatRoomId == chatRoomId).OrderBy(m => m.CreatedAt).ToList();
            }
        }

        public static void AddMessage(int chatRoomId, string content, string lat = null, string lng = null)
        {
            using (var db = new MyCirclesEntityModel())
            {
                Message newMessage = new Message();
                newMessage.ChatRoomId = chatRoomId;
                newMessage.Content = content;
                newMessage.CreatedAt = DateTime.Now;

                if (!String.IsNullOrEmpty(lat) && !String.IsNullOrEmpty(lng))
                {
                    newMessage.HasGeolocation = true;
                    newMessage.Latitude = Double.Parse(lat);
                    newMessage.Longitude = Double.Parse(lng);
                }

                db.Messages.Add(newMessage);
                db.SaveChanges();
            }
        }
    }
}