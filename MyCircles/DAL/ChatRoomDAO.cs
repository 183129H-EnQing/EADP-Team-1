using MyCircles.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCircles.DAL
{
    public static class ChatRoomDAO
    {
        public static ChatRoom GetChatRoom(int user1Id, int user2Id)
        {
            ChatRoom existingChatRoom = null;

            using (var db = new MyCirclesEntityModel())
            {
                if (user1Id != user2Id)
                {
                    existingChatRoom = db.ChatRooms.Where(cr =>
                            (cr.User1Id == user1Id && cr.User2Id == user2Id) ||
                            (cr.User1Id == user2Id && cr.User2Id == user1Id))
                        .FirstOrDefault();

                    if (existingChatRoom == null)
                    {
                        existingChatRoom = new ChatRoom();
                        existingChatRoom.User1Id = user1Id;
                        existingChatRoom.User2Id = user2Id;
                        existingChatRoom.CreatedAt = DateTime.Now;
                        db.ChatRooms.Add(existingChatRoom);
                    }

                    db.SaveChanges();
                }
            }

            return existingChatRoom;
        }

        public static ChatRoom GetChatRoomById(int chatRoomId)
        {
            using (var db = new MyCirclesEntityModel())
            {
                return db.ChatRooms.Where(cr => cr.Id == chatRoomId).FirstOrDefault();
            }
        }

        public static int GetRecieverId(int senderId, int chatRoomId)
        {
            using (var db = new MyCirclesEntityModel())
            {
                ChatRoom chatRoom = GetChatRoomById(chatRoomId);

                if (chatRoom.User1Id != senderId)
                {
                    return chatRoom.User1Id;
                }
                else
                {
                    return chatRoom.User2Id;
                }


            }
        }
    }
}