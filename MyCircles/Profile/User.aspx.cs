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
    //TODO: Hover over user icon to show profile preview
    //TODO: Show whether or not user is online
    //TODO: Create example data (user, circle, user circle w/ points)
    //TODO: Gain points for referring users to app
    //TODO: Show all the mutual circles
    //TODO: Clean up the interface (show graph for circles maybe???)
    //TODO: Clean up presentation slides
    //TODO: Give buttons icons
    //TODO: Be able to to visit chat without being in a chat room
    //TODO: Make login and redirect prettier
    //TODO: Guan Hong's View Event Details

    public partial class User : System.Web.UI.Page
    {
        public BLL.User currentUser, requestedUser;
        public List<List<CircleFollowerDetails>> circleFollowerDetailList = new List<List<CircleFollowerDetails>>();

        public List<UserCircle> existingUserCircleList
        {
            get
            {
                List<UserCircle> existingUserCircleList = (List<UserCircle>)this.ViewState["existingUserCircleList"];
                if (existingUserCircleList == null)
                {
                    this.ViewState["existingUserCircleList"] = new List<UserCircle>();
                }
                return (List<UserCircle>)(this.ViewState["existingUserCircleList"]);
            }
            set
            {
                ViewState["existingUserCircleList"] = value;
            }
        }

        public List<UserCircle> removeUserCircleList
        {
            get
            {
                List<UserCircle> removeUserCircleList = (List<UserCircle>)this.ViewState["removeUserCircleList"];
                if (removeUserCircleList == null)
                {
                    this.ViewState["removeUserCircleList"] = new List<UserCircle>();
                }
                return (List<UserCircle>)(this.ViewState["removeUserCircleList"]);
            }
            set
            {
                ViewState["removeUserCircleList"] = value;
            }
        }

        public List<UserCircle> addUserCircleList
        {
            get
            {
                List<UserCircle> addUserCircleList = (List<UserCircle>)this.ViewState["addUserCircleList"];
                if (addUserCircleList == null)
                {
                    this.ViewState["addUserCircleList"] = new List<UserCircle>();
                }
                return (List<UserCircle>)(this.ViewState["addUserCircleList"]);
            }
            set
            {
                ViewState["addUserCircleList"] = value;
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
                existingUserCircleList = UserCircleDAO.GetAllUserCircles(requestedUser.Id);
                foreach (UserCircle userCircle in existingUserCircleList)
                {
                    var userDetailsForCircle = UserCircleDAO.GetCircleFollowerDetails(userCircle.CircleId);
                    circleFollowerDetailList.Add(userDetailsForCircle);
                }

                rptUpdateCircles.DataSource = existingUserCircleList;
                rptUpdateCircles.DataBind();

                rptUserCircles.DataSource = existingUserCircleList;
                rptUserCircles.DataBind();

                rptCircleFollowerLinks.DataSource = existingUserCircleList;
                rptCircleFollowerLinks.DataBind();

                rptUserFollowing.DataSource = FollowDAO.GetAllFollowingUsers(requestedUser.Id);
                rptUserFollowing.DataBind();

                bindExisitingCircles();
                updateCirclesModal();
                initializeNearbyUserMap();

                if (currentUser.Id != requestedUser.Id && BLL.Admin.RetrieveAdmin(currentUser) != null)
                {
                    cbMakeEventHost.Visible = true;
                    cbMakeEventHost.Checked = requestedUser.IsEventHolder;
                }
            }

            GMap.OverlayClick += new EventHandler<OverlayEventArgs>(MarkerClick);

            Title = requestedUser.Username + " - MyCircles";            
            ProfilePicImage.ImageUrl = requestedUser.ProfileImage;
            lbName.Text = requestedUser.Name;
            lbUsername.Text = "@" + requestedUser.Username;
            lbBio.InnerText = requestedUser.Bio;
            lbCity.InnerText = requestedUser.City;

            if (requestedUser.Id == currentUser.Id)
            {
                btMessage.Visible = false;
            }
            else
            {
                var sCoord = new GeoCoordinate(Double.Parse(currentUser.Latitude.ToString()), Double.Parse(currentUser.Longitude.ToString()));
                var eCoord = new GeoCoordinate(Double.Parse(requestedUser.Latitude.ToString()), Double.Parse(requestedUser.Longitude.ToString()));

                lbDistance.InnerText = (sCoord.GetDistanceTo(eCoord) / 1000).ToString("0.0") + " km away";
                btEditProfile.Visible = false;
                btMessage.Visible = true;
                followWarning.InnerText = requestedUser.Name + " has not followed anyone yet";
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

        protected void btAddCircle_Click(object sender, EventArgs e)
        {
            signedOutErrorContainer.Visible = false;
            var circleName = ((tbCircleInput.Text).Trim()).Replace(" ", "").ToLower();

            if (String.IsNullOrEmpty(tbCircleInput.Text))
            {
                GeneralHelpers.AddValidationError(Page, "addCircleGroup", "Required fields are not filled up");
            }

            if (addUserCircleList.Where(uc => uc.CircleId == circleName).Count() > 0 || existingUserCircleList.Where(uc => uc.CircleId == circleName).Count() > 0)
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
                addUserCircleList.Add(newUserCircle);
            }

            tbCircleInput.Text = "";
            tbCircleInput.Focus();
            rptUpdateCircles.DataSource = existingUserCircleList.Concat(addUserCircleList);
            rptUpdateCircles.DataBind();
            updateCirclesModal();
        }

        protected void btClear_Click(object sender, EventArgs e)
        {
            addUserCircleList.Clear();
            rptUpdateCircles.DataSource = existingUserCircleList.Concat(addUserCircleList);
            rptUpdateCircles.DataBind();
            updateCirclesModal();
        }

        protected void btRemove_Click(int userCircleId)
        {
            var existingUserCircle = existingUserCircleList.SingleOrDefault(x => x.Id == userCircleId);

            if (existingUserCircle != null)
            {
                existingUserCircleList.RemoveAll(x => x.Id == userCircleId);
                removeUserCircleList.Add(existingUserCircle);
            }
            else
            {
                addUserCircleList.RemoveAll(a => a.Id == userCircleId);
            }

            rptUpdateCircles.DataSource = existingUserCircleList.Concat(addUserCircleList);
            rptUpdateCircles.DataBind();
            updateCirclesModal();
        }

        protected void rptUpdateCircles_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                btRemove_Click(int.Parse(e.CommandArgument.ToString()));
            }
        }

        protected void btSubmit_Click(object sender, EventArgs e)
        {
            signedOutErrorContainer.Visible = false;
            Page.Validate();

            if (!existingUserCircleList.Concat(addUserCircleList).Any())
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
                foreach (UserCircle userCircle in removeUserCircleList)
                {
                    UserCircleDAO.ChangeUserCirclePoints(
                        userId: userCircle.UserId,
                        circleName: userCircle.CircleId,
                        points: -50,
                        source: "Removing the circle",
                        addNotification: true
                    );

                    UserCircleDAO.RemoveUserCircle(userCircle.Id);
                }

                foreach (UserCircle userCircle in addUserCircleList)
                {
                    UserCircle addedUserCircle = UserCircleDAO.AddUserCircle(userCircle);

                    UserCircleDAO.ChangeUserCirclePoints(
                        userId: addedUserCircle.UserId,
                        circleName: addedUserCircle.CircleId,
                        points: 50,
                        source: "Joining the circle",
                        addNotification: true
                    );
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
            if (e.CommandName == "Message")
            {
                var chatroom = ChatRoomDAO.GetChatRoom(currentUser.Id, Int32.Parse(e.CommandArgument.ToString()));
                if (chatroom != null)
                {
                    Response.Redirect("/Profile/Chat.aspx?chatroom=" + chatroom.Id); 
                }
            }
        }

        protected void btMessage_Click(object sender, EventArgs e)
        {
            var chatroom = ChatRoomDAO.GetChatRoom(currentUser.Id, requestedUser.Id);
            Response.Redirect("/Profile/Chat.aspx?chatroom=" + chatroom.Id);
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
    }
}