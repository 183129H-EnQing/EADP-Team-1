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
        public List<UserCircle> inputCirclesList
        {
            get
            {
                List<UserCircle> inputCirclesList = (List<UserCircle>)this.ViewState["inputCirclesList"];
                if (inputCirclesList == null)
                {
                    this.ViewState["inputCirclesList"] = new List<UserCircle>();
                }
                return (List<UserCircle>)(this.ViewState["inputCirclesList"]);
            }
            set
            {
                ViewState["inputCirclesList"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            RedirectValidator.isUser();
            currentUser = (BLL.User)Session["currentUser"];
            requestedUser = GetUserByIdentifier(Request.QueryString["username"]);
            if (requestedUser == null) requestedUser = currentUser;

            if (!Page.IsPostBack)
            {
                inputCirclesList = UserCircleDAO.GetAllUserCircles(currentUser.Id);
                rptUpdateCircles.DataSource = inputCirclesList;
                rptUpdateCircles.DataBind();
            }

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

        protected void btAddCircle_Click(object sender, EventArgs e)
        {
            signedOutErrorContainer.Visible = false;
            var circleName = ((tbCircleInput.Text).Trim()).ToLower();

            if (String.IsNullOrEmpty(tbCircleInput.Text))
            {
                GeneralHelpers.AddValidationError(Page, "addCircleGroup", "Required fields are not filled up");
            }

            if (inputCirclesList.Where(uc => uc.CircleId == circleName).Count() > 0)
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
                inputCirclesList.Add(newUserCircle);
            }

            tbCircleInput.Text = "";
            tbCircleInput.Focus();
            rptUpdateCircles.DataSource = inputCirclesList;
            rptUpdateCircles.DataBind();
        }

        protected void btSubmit_Click(object sender, EventArgs e)
        {
            signedOutErrorContainer.Visible = false;
            Page.Validate();

            if (!inputCirclesList.Any())
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
                foreach (UserCircle userCircle in inputCirclesList)
                {
                    UserCircleDAO.AddUserCircle(userCircle);
                }

                Response.Redirect("/Redirect.aspx");
            }
        }

        protected void btClear_Click(object sender, EventArgs e)
        {
            inputCirclesList.Clear();
            rptUpdateCircles.DataSource = inputCirclesList;
            rptUpdateCircles.DataBind();
        }

        protected void btRemove_Click(int circleIndex)
        {
            inputCirclesList.RemoveAt(circleIndex);
            rptUpdateCircles.DataSource = inputCirclesList;
            rptUpdateCircles.DataBind();
        }

        protected void rptUpdateCircles_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                btRemove_Click(e.Item.ItemIndex);
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