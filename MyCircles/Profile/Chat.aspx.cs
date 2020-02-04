using MyCircles.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyCircles.Profile
{
    public partial class Chat : System.Web.UI.Page
    {
        int chatRoomId;

        //TODO: Do validation for the chatroom
        protected void Page_Load(object sender, EventArgs e)
        {
            RedirectValidator.isUser();

            try
            {
                chatRoomId = Convert.ToInt32(Request.QueryString["chatroom"]);
                rptMessages.DataSource = MessageDAO.GetChatRoomMessages(chatRoomId);
                rptMessages.DataBind();
            }
            catch (Exception ex)
            {
                Response.Redirect("/Home/Post.aspx");
            }
        }

        protected void UpdateMessagesTimer_Tick(object sender, EventArgs e)
        {
            rptMessages.DataSource = MessageDAO.GetChatRoomMessages(chatRoomId);
            rptMessages.DataBind();
        }

        protected void btSendMessage_Click(object sender, EventArgs e)
        {
            MessageDAO.AddMessage(chatRoomId, tbMessage.Text);
        }
    }
}