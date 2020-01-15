using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using MyCircles.BLL;
using static MyCircles.DAL.UserDAO;
using MyCircles.DAL;

namespace MyCircles.Profile
{
    //TODO: Edit profile with messages if mutuals/don't show location on map

    public partial class User : System.Web.UI.Page
    {
        public BLL.User currentUser, requestedUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            RedirectValidator.isUser();
            currentUser = (BLL.User)Session["currentUser"];

            string requestedUsername = Request.QueryString["username"];
            requestedUser = GetUserByIdentifier(requestedUsername);

            if (requestedUser == null) requestedUser = currentUser;

            Title = requestedUser.Username + " - MyCircles";            
            ProfilePicImage.ImageUrl = requestedUser.ProfileImage;
            lbName.Text = requestedUser.Name;
            lbUsername.Text = "@" + requestedUser.Username;
            lbBio.InnerText = requestedUser.Bio;
            lbCity.InnerText = requestedUser.City;
            rptUserFollowing.DataSource = FollowDAO.GetAllFollowingUsers(requestedUser.Id);
            rptUserFollowing.DataBind();

            if (String.IsNullOrEmpty(requestedUser.Bio)) lbBio.Visible = false;

            if (requestedUser.Id == currentUser.Id)
            {
                btFollow.Visible = false;
            }
            else
            {
                btEditProfile.Visible = false;
                updateFollowButton();

                if (FollowDAO.SearchFollow(requestedUser.Id, currentUser.Id) != null) followBadge.Visible = true;
            }
        }

        protected void btFollow_Click(object sender, EventArgs e)
        {
            FollowDAO.ToggleFollow(currentUser.Id, requestedUser.Id);
            updateFollowButton();
        }

        protected void btRefresh_Click(object sender, EventArgs e)
        {

        }

        protected void updateFollowButton()
        {
            Follow existingFollow = FollowDAO.SearchFollow(currentUser.Id, requestedUser.Id);

            if (existingFollow == null)
            {
                btFollow.Text = "Follow";
                btFollow.CssClass = "btn btn-outline-primary float-right m-5 px-5";
            }
            else
            {
                btFollow.Text = "Following";
                btFollow.CssClass = "btn btn-primary float-right m-5 px-5";
            }
        }

        protected void generateFollowingUserList(List<FollowingUsers> followingUsers)
        {
            string html = "";

            foreach (var followingUser in followingUsers)
            {
                html += "<div class='row followinguser-container rounded-lg bg-light-color py-4 px-6 m-3'>";
                    html += "<div class='col-md-3 profilepic-container'>";
                        html += "<asp:Image runat='server' CssClass='profilepic rounded-circle' Height='150px' Width='150px' ImageUrl='.." + followingUser.User.ProfileImage + "' />";
                    html += "</div>";
                    html += "<div class='col-md-6 desc-container'>";
                        html += "<span class='m-0 h1'>" + followingUser.User.Name + "</span>";
                        html += "<span class='badge badge-secondary' visible='"+ true.ToString() +"'>Follows you</span><br />";
                        html += "<span class='m-0 text-muted'>@" + followingUser.User.Username + "</span>";
                        html += "<span class='bio-span d-block font-italic py-2'>" + followingUser.User.Bio + "</span>";
                        html += "<i class='fa fa-map-marker' aria-hidden='true'></i> &nbsp;";
                        html += "<span>" + followingUser.User.City + "</span>";
                    html += "</div>";
                    html += "<div class='col-md-3 button-container'>";
                        html += "<asp:Button ID='btFollow" + followingUser.User.Id + "' runat='server' Text='Following' CssClass='btn btn-primary float-right m-3 px-4' UserId='" + followingUser.User.Id + "' OnClick='btFollow_Click'></asp:Button>";
                        html += "<asp:Button ID='btMessage" + followingUser.User.Id + "' runat='server' Text='Message' CssClass='btn btn-outline-primary float-right m-3 px-4' UserId='" + followingUser.User.Id + "' OnClick='btFollow_Click'></asp:Button>";
                    html += "</div>";
                html += "</div>";
            }

            followingUserListContainer.InnerHtml = html;
        }
    }
}