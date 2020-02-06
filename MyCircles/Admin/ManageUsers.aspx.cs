using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyCircles.BLL;

namespace MyCircles.Admin
{
    public partial class ManageUsers : System.Web.UI.Page
    {
        private string keySessionList = "ManageUsersList";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                System.Diagnostics.Debug.WriteLine("page load postback!");
                List<User> usersList = (List<User>)Session[keySessionList];
                if (Session[keySessionList] == null) usersList = BLL.User.GetAllUsers();
                refreshGridView(usersList);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("page load no postback!");
                Session[keySessionList] = null;
                gvUsers.DataSource = BLL.User.GetAllUsers();
                gvUsers.DataBind();
            }
        }

        protected void btnSearchSubmit_Click(object sender, EventArgs e)
        {
            string inputStr = tbSearchInput.Text;
            List<User> users = BLL.User.GetAllUsers();

            System.Diagnostics.Debug.WriteLine("search submit with:" + inputStr);

            if (!inputStr.Equals("")) // Search is not empty
            {
                tbSearchInput.BorderColor = System.Drawing.Color.Empty;
                List<User> resultUserList = new List<User>();
                foreach (User user in users)
                {
                    if (user.Username.Contains(inputStr))
                    {
                        resultUserList.Add(user);
                    }
                    else if (user.Name.Contains(inputStr))
                    {
                        resultUserList.Add(user);
                    }
                    else if (user.EmailAddress.Contains(inputStr))
                    {
                        resultUserList.Add(user);
                    }
                }

                System.Diagnostics.Debug.WriteLine("searching," + resultUserList.Count);
                refreshGridView(resultUserList);
            }
            else
            {
                tbSearchInput.BorderColor = System.Drawing.Color.Red;
            }
        }

        protected void gvUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ChgUserStatus" || e.CommandName == "UserProfile")
            {
                System.Diagnostics.Debug.WriteLine("gvUsers_RowCommand pageIndex:" + gvUsers.PageIndex);
                List<User> usersList = (List<User>)Session[keySessionList];
                if (usersList == null) usersList = BLL.User.GetAllUsers();

                int idx = int.Parse(e.CommandArgument.ToString()) + (10 * gvUsers.PageIndex);

                System.Diagnostics.Debug.WriteLine("gvUsers_RowCommand cmdName:" + e.CommandName);
                System.Diagnostics.Debug.WriteLine("gvUsers_RowCommand cmdArg:" + int.Parse(e.CommandArgument.ToString()));
                System.Diagnostics.Debug.WriteLine("gvUsers_RowCommand index:" + idx);
                User user = usersList[idx];
                switch (e.CommandName)
                {
                    case "ChgUserStatus":
                        user.UpdateIsDisabled(!user.IsDeleted);
                        refreshGridView(BLL.User.GetAllUsers());
                        break;
                    case "UserProfile":
                        string profileLink = "/Profile/User.aspx?username=" + usersList[idx].Username;
                        Response.Redirect(profileLink);
                        break;
                }
            }
        }

        protected void gvUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                System.Diagnostics.Debug.WriteLine("gvUsers_RowDataBound pageIndex:" + gvUsers.PageIndex);
                List<User> usersList = (List<User>)Session[keySessionList];
                if (usersList == null) usersList = BLL.User.GetAllUsers();
                int idx = e.Row.RowIndex + (10 * gvUsers.PageIndex);
                System.Diagnostics.Debug.WriteLine("gvUsers_RowCommand index:" + idx);
                User user = usersList[idx];

                string displayChgUserStatus = "User";
                if (user.IsDeleted) // if disabled
                    displayChgUserStatus = "Re-enable " + displayChgUserStatus;
                else // if enabled
                    displayChgUserStatus = "Disable " + displayChgUserStatus;

                //Control 
                try
                {
                    Button someCtrl = e.Row.FindControl("btnChgUserStatus") as Button;
                    someCtrl.Text = displayChgUserStatus;
                    System.Diagnostics.Debug.WriteLine("are you running?");
                    System.Diagnostics.Debug.WriteLine(someCtrl == null);
                } catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("failed to find control" + ex.Message);
                }
            }
        }

        protected void gvUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUsers.PageIndex = e.NewPageIndex;
            System.Diagnostics.Debug.WriteLine("pagerindex");

            List<User> usersList = (List<User>)Session[keySessionList];
            if (usersList == null) usersList = BLL.User.GetAllUsers();
            refreshGridView(usersList);
        }

        private void refreshGridView(List<User> dataToBind)
        {
            System.Diagnostics.Debug.WriteLine("refreshing gv," + dataToBind.Count);
            Session[keySessionList] = dataToBind;
            gvUsers.DataSource = dataToBind;
            gvUsers.DataBind();
        }
    }
}