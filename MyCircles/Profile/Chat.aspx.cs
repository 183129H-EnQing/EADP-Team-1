using MyCircles.BLL;
using MyCircles.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyCircles.Profile
{
    public partial class Chat : System.Web.UI.Page
    {
        static int chatRoomId;
        static List<Message> messages;
        BLL.User currentUser;
        BLL.User recieverUser;

        //TODO: Do validation for the chatroom
        protected void Page_Load(object sender, EventArgs e)
        {
            RedirectValidator.isUser();

            try
            {
                chatRoomId = Convert.ToInt32(Request.QueryString["chatroom"]);
                currentUser = (BLL.User)Session["currentUser"];
                recieverUser = UserDAO.GetUserById(ChatRoomDAO.GetRecieverId(currentUser.Id, chatRoomId));
                BindMessages();
            }
            catch (Exception ex)
            {
                Response.Redirect("/Home/Post.aspx");
            }
        }

        protected void UpdateMessagesTimer_Tick(object sender, EventArgs e)
        {
            BindMessages();
        }

        protected void btSendMessage_Click(object sender, EventArgs e)
        {
            MessageDAO.AddMessage(chatRoomId, tbMessage.Text, recieverUser.Id, currentUser.Id);
            BindMessages();
        }

        protected void BindMessages()
        {
            messages = MessageDAO.GetChatRoomMessages(chatRoomId);
            rptMessages.DataSource = messages;
            rptMessages.DataBind();
        }

        [WebMethod]
        public static object GetNewMessages()
        {
            var newMessages = MessageDAO.GetNewChatRoomMessages(chatRoomId);
            return new { result = newMessages };
        }
    }
}