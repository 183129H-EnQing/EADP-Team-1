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
using System.Web.Services;
using System.Device.Location;

namespace MyCircles.Profile
{
    //TODO: Messages with dragging points onto the map
    //TODO: Show whether or not user is online
    //TODO: Create example data (user, circle, user circle w/ points)
    //TODO: Gain points for referring users to app
    //TODO: Show all the mutual circles
    //TODO: Add points and show points source
    //TODO: Fix the autocomplete bug
    //TODO: Add edit user profile
    //TODO: Add support for Web API
    //TODO: Clean up the interface (show graph for circles maybe???)
    //TODO: Show following, followers, and strangers who dm'd you in user page
    public partial class User : System.Web.UI.Page
    {
        public BLL.User currentUser, requestedUser;
        public List<List<CircleFollowerDetails>> circleFollowerDetailList = new List<List<CircleFollowerDetails>>();
        public List<UserCircle> requestedUserCircleList
        {
            get
            {
                List<UserCircle> requestedUserCircleList = (List<UserCircle>)this.ViewState["requestedUserCircleList"];
                if (requestedUserCircleList == null)
                {
                    this.ViewState["requestedUserCircleList"] = new List<UserCircle>();
                }
                return (List<UserCircle>)(this.ViewState["requestedUserCircleList"]);
            }
            set
            {
                ViewState["requestedUserCircleList"] = value;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Request.QueryString["addingCircles"]))
            {
                RedirectValidator.isUser(isAddingUserCircles: false);
            }
            else
            {
                addCirclesCloseButton.Visible = false;
                RedirectValidator.isUser(isAddingUserCircles: true);
            }

            currentUser = (BLL.User)Session["currentUser"];
            requestedUser = GetUserByIdentifier(Request.QueryString["username"]);
            if (requestedUser == null) requestedUser = currentUser;

            if (!Page.IsPostBack)
            {
                requestedUserCircleList = UserCircleDAO.GetAllUserCircles(requestedUser.Id);
                foreach (UserCircle userCircle in requestedUserCircleList)
                {
                    var userDetailsForCircle = UserCircleDAO.GetCircleFollowerDetails(userCircle.CircleId);
                    circleFollowerDetailList.Add(userDetailsForCircle);
                }

                rptUpdateCircles.DataSource = requestedUserCircleList;
                rptUpdateCircles.DataBind();

                rptUserCircles.DataSource = requestedUserCircleList;
                rptUserCircles.DataBind();

                rptCircleFollowerLinks.DataSource = requestedUserCircleList;
                rptCircleFollowerLinks.DataBind();

                rptUserFollowing.DataSource = FollowDAO.GetAllFollowingUsers(requestedUser.Id);
                rptUserFollowing.DataBind();

                bindExisitingCircles();
                updateCirclesModal();
                initializeNearbyUserMap();
            }

            GMap.OverlayClick += new EventHandler<OverlayEventArgs>(MarkerClick);

            if (currentUser.Id != requestedUser.Id && BLL.Admin.RetrieveAdmin(currentUser) != null)
            {
                cbMakeEventHost.Visible = true;
                cbMakeEventHost.Checked = requestedUser.IsEventHolder;
            }

            Title = requestedUser.Username + " - MyCircles";            
            ProfilePicImage.ImageUrl = requestedUser.ProfileImage;
            lbName.Text = requestedUser.Name;
            lbUsername.Text = "@" + requestedUser.Username;
            lbBio.InnerText = requestedUser.Bio;
            lbCity.InnerText = requestedUser.City;

            if (requestedUser.Id == currentUser.Id)
            {
                btFollow.Visible = false;
            }
            else
            {
                var sCoord = new GeoCoordinate(Double.Parse(currentUser.Latitude.ToString()), Double.Parse(currentUser.Longitude.ToString()));
                var eCoord = new GeoCoordinate(Double.Parse(requestedUser.Latitude.ToString()), Double.Parse(requestedUser.Longitude.ToString()));

                lbDistance.InnerText = (sCoord.GetDistanceTo(eCoord) / 1000).ToString("0.0") + " km away";
                btEditProfile.Visible = false;
                followWarning.InnerText = requestedUser.Name + " has not followed anyone yet";
                postWarning.InnerText = requestedUser.Name + " has not created any posts yet";

                updateFollowButton();

                if (FollowDAO.SearchFollow(requestedUser.Id, currentUser.Id) != null) followBadge.Visible = true;

            }

            if (BLL.Admin.RetrieveAdmin(currentUser) != null)
            {
                cbMakeEventHost.Visible = true;
                cbMakeEventHost.Checked = requestedUser.IsEventHolder;
            }

            if (String.IsNullOrEmpty(requestedUser.Bio)) 
            {
                lbBio.Visible = false;
            } 
            else
            {
                lbBio.Visible = true;
            }

            if (rptUserFollowing.Items.Count > 0) 
            {
                followWarning.Visible = false;
            }
            else
            {
                followWarning.Visible = true;
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

        protected void btAddCircle_Click(object sender, EventArgs e)
        {
            signedOutErrorContainer.Visible = false;
            var circleName = ((tbCircleInput.Text).Trim()).Replace(" ", "").ToLower();

            if (String.IsNullOrEmpty(tbCircleInput.Text))
            {
                GeneralHelpers.AddValidationError(Page, "addCircleGroup", "Required fields are not filled up");
            }

            if (requestedUserCircleList.Where(uc => uc.CircleId == circleName).Count() > 0)
            {
                GeneralHelpers.AddValidationError(Page, "addCircleGroup", "There are duplicate circles present");
            }

            if (!Page.IsValid)
            {
                signedOutErrorContainer.Visible = true;
                lbErrorMsg.Text = GeneralHelpers.GetFirstValidationError(Page.Validators);
            }
            else
            {
                UserCircle newUserCircle = new UserCircle();
                newUserCircle.CircleId = circleName;
                newUserCircle.UserId = currentUser.Id;
                requestedUserCircleList.Add(newUserCircle);
            }


            tbCircleInput.Text = "";
            tbCircleInput.Focus();
            rptUpdateCircles.DataSource = requestedUserCircleList;
            rptUpdateCircles.DataBind();
            updateCirclesModal();
        }

        protected void btClear_Click(object sender, EventArgs e)
        {
            requestedUserCircleList.Clear();
            rptUpdateCircles.DataSource = requestedUserCircleList;
            rptUpdateCircles.DataBind();
            updateCirclesModal();
        }

        protected void btRemove_Click(int circleIndex)
        {
            requestedUserCircleList.RemoveAt(circleIndex);
            rptUpdateCircles.DataSource = requestedUserCircleList;
            rptUpdateCircles.DataBind();
            updateCirclesModal();
        }

        protected void rptUpdateCircles_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                btRemove_Click(e.Item.ItemIndex);
            }
        }

        protected void btSubmit_Click(object sender, EventArgs e)
        {
            signedOutErrorContainer.Visible = false;
            Page.Validate();

            if (!requestedUserCircleList.Any())
            {
                GeneralHelpers.AddValidationError(Page, "addUserCirclesGroup", "No circles have been added");
            }

            if (!Page.IsValid)
            {
                signedOutErrorContainer.Visible = true;
                lbErrorMsg.Text = GeneralHelpers.GetFirstValidationError(Page.Validators, "addUserCirclesGroup");
            }
            else
            {
                UserCircleDAO.RemoveUserCircles(requestedUser.Id);

                foreach (UserCircle userCircle in requestedUserCircleList)
                {
                    UserCircleDAO.AddUserCircle(userCircle);
                }

                Response.Redirect("/Redirect.aspx");
            }
        }

        protected void rptCircleFollowerLinks_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var currentIndex = e.Item.ItemIndex;
            Repeater rptCircleFollowerDetails = e.Item.FindControl("rptCircleFollowerDetails") as Repeater;

            if (currentIndex >= 0)
            {
                rptCircleFollowerDetails.DataSource = circleFollowerDetailList[currentIndex];
                rptCircleFollowerDetails.DataBind();
            }
        }

        protected void rptUserFollowing_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Unfollow")
            {
                FollowDAO.ToggleFollow(currentUser.Id, Int32.Parse(e.CommandArgument.ToString()));
                Response.Redirect(Request.RawUrl);
            }
            else if (e.CommandName == "Message")
            {
                var chatroom = ChatRoomDAO.GetChatRoom(currentUser.Id, Int32.Parse(e.CommandArgument.ToString()));
                Response.Redirect("/Profile/Chat.aspx?chatroom=" + chatroom.Id);
            }
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
                requestedUser.UpdateIsEventHost(cbSender.Checked);
            }
        }

        private void bindExisitingCircles()
        {
            foreach (BLL.Circle circle in CircleDAO.GetAllCircles())
            {
                existingCircles.InnerHtml += "<option value='" + circle.Id + "'>" + circle.Id + "</option>";
            }
        }

        protected void initializeNearbyUserMap() 
        {
            GMap.ApiKey = ConfigurationManager.AppSettings["MapKey"];
            List<BLL.User> allUsers = GetAllUsers();

            foreach (BLL.User user in allUsers)
            {
                if (user.Latitude != null || user.Longitude != null)
                {
                    LatLng pos = new LatLng();
                    pos.Latitude = (user.Latitude.HasValue) ? user.Latitude.Value : 0;
                    pos.Longitude = (user.Longitude.HasValue) ? user.Longitude.Value : 0;

                    Marker userMarker = new Marker(pos);
                    Marker overlayMarker = new Marker(pos);
                    userMarker.ZIndex = user.Id;
                    overlayMarker.ZIndex = user.Id;

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
                        GMap.Center = pos;
                    }


                    if (user.Id == currentUser.Id)
                    {
                        overlayIcon.ImageUri = new Uri(string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, "/Content/images/UserOutlineDefault.png"));
                        userMarker.ZIndex = 98;
                        overlayMarker.ZIndex = 99;
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
                    }

                    userMarker.Options.Name = user.Username;
                    overlayMarker.Options.Name = user.Username;

                    GMap.Overlays.Add(userMarker);
                    GMap.Overlays.Add(overlayMarker);
                }
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

        protected void updateCirclesModal()
        {
            if (rptUpdateCircles.Items.Count.Equals(0))
            {
                addCirclesIntroBlurb.Visible = true;
            }
            else
            {
                addCirclesIntroBlurb.Visible = false;
            }
        }

        void MarkerClick(object sender, OverlayEventArgs e)
        {
            e.MapCommand = "window.location.replace('/Profile/User.aspx?username=" + e.Overlay.Options.Name + "')";
        }

        //[WebMethod]
        //public static object GetData()
        //{

        //    return new { result = ... };
        //}
    }
}