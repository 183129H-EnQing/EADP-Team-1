using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using Reimers.Google.Map;
using MyCircles.BLL;
using static MyCircles.DAL.UserDAO;
using MyCircles.DAL;
using System.Configuration;

namespace MyCircles.Profile
{
    //TODO: Edit profile with messages if mutuals/don't show location on map
    //TODO: Show whether or not user is online

    public partial class User : System.Web.UI.Page
    {
        public BLL.User currentUser, requestedUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            RedirectValidator.isUser();
            currentUser = (BLL.User)Session["currentUser"];

            requestedUser = GetUserByIdentifier(Request.QueryString["username"]);
            if (requestedUser == null) requestedUser = currentUser;

            rptUserFollowing.DataSource = FollowDAO.GetAllFollowingUsers(requestedUser.Id);
            rptUserFollowing.DataBind();

            Title = requestedUser.Username + " - MyCircles";            
            ProfilePicImage.ImageUrl = requestedUser.ProfileImage;
            lbName.Text = requestedUser.Name;
            lbUsername.Text = "@" + requestedUser.Username;
            lbBio.InnerText = requestedUser.Bio;
            lbCity.InnerText = requestedUser.City;
            GMap.ApiKey = ConfigurationManager.AppSettings["MapKey"];
            List<BLL.User> allUsers = GetAllUsers();

            if (String.IsNullOrEmpty(requestedUser.Bio)) lbBio.Visible = false;
            if (rptUserFollowing.Items.Count > 0) followWarning.Visible = false;

            if (requestedUser.Id == currentUser.Id)
            {
                btFollow.Visible = false;
            }
            else
            {
                if (BLL.Admin.RetrieveAdmin(currentUser) != null)
                {
                    cbMakeEventHost.Visible = true;
                    if (!Page.IsPostBack) cbMakeEventHost.Checked = requestedUser.IsEventHolder;
                }

                btEditProfile.Visible = false;
                followWarning.InnerText = requestedUser.Name + " has not followed anyone yet";
                postWarning.InnerText = requestedUser.Name + " has not created any posts yet";
                circleWarning.InnerText = requestedUser.Name + " has not followed any circles yet";
                
                updateFollowButton();

                if (FollowDAO.SearchFollow(requestedUser.Id, currentUser.Id) != null) followBadge.Visible = true;
            }

            foreach (BLL.User user in allUsers)
            {
                if (user.Latitude != null || user.Longitude != null)
                {
                    LatLng pos = new LatLng();
                    pos.Latitude = (user.Latitude.HasValue) ? user.Latitude.Value : 0;
                    pos.Longitude = (user.Longitude.HasValue) ? user.Longitude.Value : 0;

                    Marker userMarker = new Marker(pos);
                    Marker overlayMarker = new Marker(pos);
                    userMarker.ZIndex = -1;
                    overlayMarker.ZIndex = 1;

                    Icon userIcon = new Icon();
                    userIcon.ScaledSize = new Size(24, 24);
                    userIcon.Anchor = new Point(12, 28);
                    userMarker.Icon = userIcon;

                    Icon overlayIcon = new Icon();
                    overlayIcon.ScaledSize = new Size(32, 32);
                    overlayMarker.Icon = overlayIcon;

                    if (Uri.IsWellFormedUriString(user.ProfileImage, UriKind.Absolute))
                    {
                        userIcon.ImageUri = new Uri(user.ProfileImage);
                    }
                    else
                    {
                        userIcon.ImageUri = new Uri(string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, user.ProfileImage));
                    }

                    if (user.Id == requestedUser.Id)
                    {
                        overlayIcon.ImageUri = new Uri(string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, "/Content/images/UserOutlineDefault.png"));
                        GMap.Center = pos;
                    }
                    else
                    {
                        if (user.IsLoggedIn)
                        {
                            overlayIcon.ImageUri = new Uri(string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, "/Content/images/UserOutlineOnline.png"));
                        }
                        else
                        {
                            overlayIcon.ImageUri = new Uri(string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, "/Content/images/UserOutlineOffline.png"));
                        }

                        userMarker.Clickable = true;
                    }

                    userMarker.Options.Name = user.Username;
                    overlayMarker.Options.Name = user.Username;

                    GMap.Overlays.Add(userMarker);
                    GMap.Overlays.Add(overlayMarker);
                    GMap.OverlayClick += new EventHandler<OverlayEventArgs>(MarkerClick);
                }
            }
        }

        protected void btFollow_Click(object sender, EventArgs e)
        {
            int requestedUserId = requestedUser.Id;
            Button button = (Button)sender;

            if (button.Attributes["UserId"] != null) requestedUserId = int.Parse(button.Attributes["UserId"]);

            FollowDAO.ToggleFollow(currentUser.Id, requestedUserId);
            updateFollowButton();
        }

        protected void btMessage_Click(object sender, EventArgs e)
        {
            Response.Redirect("User.aspx?username=" + currentUser.Username);
        }

        protected void cbMakeEventHost_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox)
            {
                CheckBox cbSender = (CheckBox) sender;
                System.Diagnostics.Debug.WriteLine("Updating user's event host: " + cbSender.Checked);
                requestedUser.UpdateIsEventHost(cbSender.Checked);
            }
        }

        protected void updateFollowButton()
        {
            Follow existingFollow = FollowDAO.SearchFollow(currentUser.Id, requestedUser.Id);

            if (existingFollow == null)
            {
                btFollow.Text = "Follow";
                btFollow.CssClass = "btn btn-outline-primary float-right m-5 px-4";
            }
            else
            {
                btFollow.Text = "Following";
                btFollow.CssClass = "btn btn-primary float-right m-5 px-4";
            }
        }

        void MarkerClick(object sender, OverlayEventArgs e)
        {
            e.MapCommand = "window.location.replace('/Profile/User.aspx?username=" + e.Overlay.Options.Name + "');";
            //Server.Transfer("Profile/User.aspx?username=" + e.Overlay.Options.Name);
        }
    }
}