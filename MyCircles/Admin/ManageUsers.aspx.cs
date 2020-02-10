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
                if (Session[keySessionList] == null) usersList = RetrieveNonAdminUsers();
                refreshGridView(usersList);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("page load no postback!");
                Session[keySessionList] = RetrieveNonAdminUsers();
                gvUsers.DataSource = RetrieveNonAdminUsers();
                gvUsers.DataBind();
            }
        }

        protected void btnSearchSubmit_Click(object sender, EventArgs e)
        {
            int queryTypeId = int.Parse(ddlQueryType.SelectedValue);
            System.Diagnostics.Debug.WriteLine("query type id:" + queryTypeId);

            string inputStr = tbSearchInput.Text.ToLower();
            List<User> users = RetrieveNonAdminUsers();

            System.Diagnostics.Debug.WriteLine("search submit with:" + inputStr);

            if (!inputStr.Equals("")) // Search is not empty
            {
                tbSearchInput.BorderColor = System.Drawing.Color.Empty;
                List<User> resultUserList = new List<User>();
                foreach (User user in users)
                {
                    bool shouldAddUser = false;
                    switch (queryTypeId)
                    {
                        case 0: // All
                            shouldAddUser = user.Username.ToLower().Contains(inputStr) || user.Name.ToLower().Contains(inputStr) || user.EmailAddress.ToLower().Contains(inputStr);
                            break;
                        case 1: // Username
                            shouldAddUser = user.Username.ToLower().Contains(inputStr);
                            break;
                        case 2: // Display Name
                            shouldAddUser = user.Name.ToLower().Contains(inputStr);
                            break;
                        case 3: // Email
                            shouldAddUser = user.EmailAddress.ToLower().Contains(inputStr);
                            break;
                    }

                    if (shouldAddUser)
                        resultUserList.Add(user);
                }

                System.Diagnostics.Debug.WriteLine("searching," + resultUserList.Count);
                refreshGridView(resultUserList);
            }
            else
            {
                tbSearchInput.BorderColor = System.Drawing.Color.Red;
            }
        }

        protected void btnChgUserStatus_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            List<User> usersList = (List<User>)Session[keySessionList];

            System.Diagnostics.Debug.WriteLine("btnChgUserStatus_Click cmdArg:" + btn.CommandArgument.ToString());
            int idx = int.Parse(btn.CommandArgument.ToString()) + (10 * gvUsers.PageIndex);

            System.Diagnostics.Debug.WriteLine("gvUsers_RowCommand index:" + idx);
            User user = usersList[idx];

            user.UpdateIsDisabled(!user.IsDeleted);
            System.Diagnostics.Debug.WriteLine("gvUsers_RowCommand ChgUserStatus, is Button:" + (sender is Button));
            refreshGridView(RetrieveNonAdminUsers());
        }

        protected void gvUsers_RowCreated(object sender, GridViewRowEventArgs e)
        {
            Control ctrl = e.Row.FindControl("btnChgUserStatus");

            if (ctrl != null)
            {
                System.Diagnostics.Debug.WriteLine("gvUsers_RowCreated, ctrl is fine!");
                ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl(ctrl as Button);
            }
        }

        protected void gvUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "UserProfile")
            {
                System.Diagnostics.Debug.WriteLine("gvUsers_RowCommand pageIndex:" + gvUsers.PageIndex);
                List<User> usersList = (List<User>)Session[keySessionList];

                System.Diagnostics.Debug.WriteLine("gvUsers_RowCommand cmdName:" + e.CommandName);
                System.Diagnostics.Debug.WriteLine("gvUsers_RowCommand cmdArg:" + e.CommandArgument.ToString());
                int idx = int.Parse(e.CommandArgument.ToString()) + (10 * gvUsers.PageIndex);

                System.Diagnostics.Debug.WriteLine("gvUsers_RowCommand index:" + idx);
                User user = usersList[idx];
                string profileLink = "/Profile/User.aspx?username=" + usersList[idx].Username;
                Response.Redirect(profileLink);
            }
        }

        protected void gvUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                System.Diagnostics.Debug.WriteLine("gvUsers_RowDataBound pageIndex:" + gvUsers.PageIndex);
                List<User> usersList = (List<User>)Session[keySessionList];
                int idx = e.Row.RowIndex + (10 * gvUsers.PageIndex);
                System.Diagnostics.Debug.WriteLine("gvUsers_RowDataBound index:" + idx);
                User user = usersList[idx];

                string displayChgUserStatus = "User";
                if (user.IsDeleted) // if disabled
                    displayChgUserStatus = "Re-enable " + displayChgUserStatus;
                else // if enabled
                    displayChgUserStatus = "Disable " + displayChgUserStatus;
                System.Diagnostics.Debug.WriteLine("gvUsers_RowDataBound IsDeleted:" + user.IsDeleted);

                //Control 
                try
                {
                    Button someCtrl = e.Row.FindControl("btnChgUserStatus") as Button;
                    someCtrl.Text = displayChgUserStatus;
                    System.Diagnostics.Debug.WriteLine("are you running? Text:" + displayChgUserStatus);
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
            System.Diagnostics.Debug.WriteLine("pagerindex:" + e.NewPageIndex);

            List<User> usersList = (List<User>)Session[keySessionList];
            refreshGridView(usersList);
        }

        private void refreshGridView(List<User> dataToBind)
        {
            System.Diagnostics.Debug.WriteLine("refreshing gv," + dataToBind.Count);
            Session[keySessionList] = dataToBind;
            gvUsers.DataSource = dataToBind;
            gvUsers.DataBind();
        }

        private List<User> RetrieveNonAdminUsers()
        {
            List<User> users = new List<User>();

            foreach (User user in BLL.User.GetAllUsers())
            {
                if (BLL.Admin.RetrieveAdmin(user) == null)
                {
                    users.Add(user);
                }
            }

            return users;
        }
    }
}