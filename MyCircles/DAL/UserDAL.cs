namespace MyCircles.BLL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class UserDAL
    {
        public List<User> GetUserById(int userId)
        {
            using (MyCirclesModel myCirclesDataContext = new MyCirclesModel())
            {
                return (from user in myCirclesDataContext.Users
                        where user.Id == userId
                        select user)
                        .ToList();
            }
        }

        public void addNewUser(User newUser)
        {
            using (MyCirclesModel myCirclesDataContext = new MyCirclesModel())
            {
                //myCirclesDataContext.Users.InsertOnSubmit(newUser);
                //// executes the commands to implement the changes to the database
                //objDataContext.SubmitChanges();
            }
        }
    }
}