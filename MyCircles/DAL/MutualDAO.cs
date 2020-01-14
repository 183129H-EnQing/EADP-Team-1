using MyCircles.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCircles.DAL
{
    public static class MutualDAO
    {
        public static Mutual ToggleMutual(int user1Id, int user2Id)
        {
            Mutual newMutual = null;

            using (var db = new MyCirclesEntityModel())
            {
                Mutual existingMutual = db.Mutuals.Where(em => 
                                            (em.User1Id == user1Id && em.User2Id == user2Id) ||
                                            (em.User1Id == user2Id && em.User2Id == user1Id))
                                        .FirstOrDefault();

                if (existingMutual == null)
                {
                    newMutual = new Mutual();
                    newMutual.User1Id = user1Id;
                    newMutual.User2Id = user2Id;
                    db.Mutuals.Add(newMutual);
                }
                else
                {
                    db.Mutuals.Remove(existingMutual);
                }

                db.SaveChanges();
            }

            return newMutual;
        }

        public static Mutual SearchMutual(int user1Id, int user2Id)
        {
            Mutual newMutual = null;

            using (var db = new MyCirclesEntityModel())
            {
                Mutual existingMutual = db.Mutuals.Where(em =>
                                            (em.User1Id == user1Id && em.User2Id == user2Id) ||
                                            (em.User1Id == user2Id && em.User2Id == user1Id))
                                        .FirstOrDefault();
            }

            return newMutual;
        }
    }
}