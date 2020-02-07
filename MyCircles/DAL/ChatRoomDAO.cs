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

        public static List<UserChatRoom> GetUserChatRooms(int userId)
        {
            using (var db = new MyCirclesEntityModel())
            {
                db.Configuration.LazyLoadingEnabled = false;

                List<UserChatRoom> UserChatRoomList = new List<UserChatRoom>();

                var query =
                    from cr in db.ChatRooms
                    join u1 in db.Users on cr.User1Id equals u1.Id
                    join u2 in db.Users on cr.User2Id equals u2.Id
                    where cr.User1Id == userId || cr.User2Id == userId
                    select new
                    {
                        user1 = u1,
                        user2 = u2,
                        chatRoom = cr,
                    };

                foreach (var item in query.AsEnumerable())
                {
                    if (item.user1.Id == userId)
                    {
                        UserChatRoomList.Add(new UserChatRoom(item.user2, item.user1, item.chatRoom));
                    } else
                    {
                        UserChatRoomList.Add(new UserChatRoom(item.user1, item.user2, item.chatRoom));
                    }
                }

                if (UserChatRoomList.Count == 0) UserChatRoomList = null;

                return UserChatRoomList;
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