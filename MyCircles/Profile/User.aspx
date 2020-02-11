<%@ Page Title="User - MyCircles" Language="C#" MasterPageFile="~/SignedIn.master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="MyCircles.Profile.User" %>
<%@ Register assembly="Reimers.Google.Map" namespace="Reimers.Google.Map" TagPrefix="Reimers" %>

<asp:Content ID="ProfileHead" ContentPlaceHolderID="SignedInHeadPlaceholder" runat="server">
</asp:Content>

<asp:Content ID="ProfileContent" ContentPlaceHolderID="SignedInContentPlaceholder" runat="server">
    <form runat="server">
        <asp:ScriptManager ID="UserScriptManager" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
        <div class="rounded container-lg content-container bg-white p-0 shadow-sm mb-6">
            <div class="user-container">
                <reimers:map id="GMap" width="100%" height="300px" runat="server" Zoom="18" />
                <div class="mainprofilepic-container">
                    <asp:Image ID="ProfilePicImage" runat="server" CssClass="profilepic rounded-circle img-fluid" />
                </div>
                <div class="maindesc-container">
                    <asp:Label ID="lbName" cssClass="m-0 h1" runat="server"></asp:Label><br />
                    <asp:Label ID="lbUsername" class="m-0 text-muted" runat="server">@</asp:Label><br />
                    <span id="lbBio" class="bio-span d-block font-italic py-3" runat="server"></span>
                    <i class="fa fa-map-marker" aria-hidden="true"></i> &nbsp;
                    <span id="lbCity" runat="server" ClientIdMode="Static"></span> • <span id="lbDistance" runat="server" ClientIdMode="Static"></span>
                </div>
            </div>
            <div style="height:200px">
                <input id="btEditProfile" name="btEditProfile" onclick="location.href ='/Profile/EditProfile.aspx'" class="btn btn-outline-primary float-right m-5 px-4"  value="Edit Profile" type="button" runat="server" />
                <%--<asp:Button ID="btFollow" runat="server" Text="Follow" CssClass="btn btn-outline-primary float-right m-5 px-4" OnClick="btFollow_Click" UseSubmitBehavior="false" />--%>
                <button id="btFollowProfile" class="btn btn-outline-primary m-5 px-4 btn-follow float-right" type="button" followingId=<%= requestedUser.Id %> followerId=<%= currentUser.Id %>>Follow</button>
                <asp:Button ID="btMessage" runat="server" Text="Message" CssClass="btn btn-outline-secondary float-right my-5 px-4" OnClick="btMessage_Click" UseSubmitBehavior="false" />
            </div>

            <ul class="nav nav-pills mb-3 nav-justified px-6 border-bottom" id="pills-tab" role="tablist">
                <li class="nav-item">
                    <a class="nav-link active" id="pills-circles-tab" data-toggle="pill" href="#pills-circles" role="tab" aria-controls="pills-circles" aria-selected="true" data-url="?action=circles">Circles</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" id="pills-posts-tab" data-toggle="pill" href="#pills-posts" role="tab" aria-controls="pills-posts" aria-selected="false">Posts</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" id="pills-people-tab" data-toggle="pill" href="#pills-people" role="tab" aria-controls="pills-people" aria-selected="false" data-url="?action=people">People</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" id="pills-events-tab" data-toggle="pill" href="#pills-events" role="tab" aria-controls="pills-events" aria-selected="false" data-url="?action=people">Event</a>
                </li>
            </ul>
            <div class="tab-content" id="pills-tabContent">
                <div class="tab-pane fade" id="pills-posts" role="tabpanel" aria-labelledby="pills-posts-tab">
                    <div id="userPostsContainer" class="container py-5 px-7">
                        <h4 id="no-post-message" class="text-center">You have not made any posts yet</h4>
                    </div>
                </div>
                <div class="tab-pane fade show active" id="pills-circles" role="tabpanel" aria-labelledby="pills-circles-tab">
                    <div id="userCirclesContainer" class="row container py-5 px-7" runat="server">
                        <div class="col-md-3 border-right">
                            <div class="nav flex-column nav-pills" id="v-pills-tab" role="tablist" aria-orientation="vertical">
                                <asp:Repeater ID="rptUserCircles" runat="server" ItemType="MyCircles.BLL.UserCircle">
                                    <ItemTemplate>
                                        <a class="nav-link" id=v-pills-<%#DataBinder.Eval(Container.DataItem, "CircleId")%>-tab data-toggle="pill" href=#v-pills-<%#DataBinder.Eval(Container.DataItem, "CircleId")%> role="tab" aria-controls=v-pills-<%#DataBinder.Eval(Container.DataItem, "CircleId")%>><%#DataBinder.Eval(Container.DataItem, "CircleId")%></a>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <button type="button" class="btn btn-outline-info mt-3" data-toggle="modal" data-target="#editprofile-modal">
                                <i class="fas fa-edit"></i>&nbsp; Edit Circles
                            </button>
                        </div>
                        <div class="col-md-9">
                            <div class="tab-content" id="v-pills-tabContent">
                                <asp:Repeater ID="rptCircleFollowerLinks" runat="server" ItemType="MyCircles.BLL.UserCircle" OnItemDataBound="rptCircleFollowerLinks_ItemDataBound">
                                    <HeaderTemplate>
                                        <div class="tab-pane fade show active" id=v-pills-header role="tabpanel" aria-labelledby=v-pills-header-tab>
                                            <h4>
                                                Leaderboards
                                            </h4>

                                            <span>
                                                Engage with your circles by creating or sharing posts or even taking part in events to earn points. Compete with other users to earn the highest points!
                                            </span>
                                        </div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div class="tab-pane fade show" id=v-pills-<%#DataBinder.Eval(Container.DataItem, "CircleId")%> role="tabpanel" aria-labelledby=v-pills-<%#DataBinder.Eval(Container.DataItem, "CircleId")%>-tab>
                                            <asp:Repeater ID="rptCircleFollowerDetails" runat="server" ItemType="MyCircles.DAL.CircleFollowerDetails">
                                                <HeaderTemplate>
                                                    <table class="table">
                                                        <thead>
                                                            <tr>
                                                                <th scope="col">Position</th>
                                                                <th scope="col">User</th>
                                                                <th scope="col">Points</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr>
                                                        <th scope="row"><%# Container.ItemIndex + 1 %></th>
                                                        <td>
                                                            <a href="User.aspx?username=<%#DataBinder.Eval(Container.DataItem, "User.Username")%>" class="text-decoration-none">
                                                                <asp:Image runat='server' CssClass='rounded-circle' Height='25px' Width='25px' ImageUrl=<%#DataBinder.Eval(Container.DataItem, "User.ProfileImage")%> />
                                                                <%#DataBinder.Eval(Container.DataItem, "User.Username")%>
                                                            </a>
                                                        </td>
                                                        <td><%#DataBinder.Eval(Container.DataItem, "UserCircle.Points")%></td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                        </tbody>
                                                    </table>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="tab-pane fade" id="pills-people" role="tabpanel" aria-labelledby="pills-people-tab">
                    <div id="followingUserListContainer" class="container py-5 px-7" runat="server">
                        <div class="card-columns" style="column-count: 2;">
                        <asp:Repeater ID="rptUserFollowing" runat="server" ItemType="MyCircles.DAL.FollowingUsers" OnItemCommand="rptUserFollowing_ItemCommand">
                            <ItemTemplate>
                                <div class="card border-light-color thick-border shadow-sm">
                                    <div class="card-body">
                                        <div class="row">
                                            <div class="col-md-3 profilepic-container">
                                                <a href="User.aspx?username=<%#DataBinder.Eval(Container.DataItem, "User.Username")%>" class="text-decoration-none">
                                                <asp:Image runat='server' CssClass='profilepic rounded-circle' Height='100px' Width='100px' ImageUrl='<%#DataBinder.Eval(Container.DataItem, "User.ProfileImage")%>' />
                                            </div>
                                            <div class="col-md-9 desc-container">
                                                <span class='m-0 h3'><%#DataBinder.Eval(Container.DataItem, "User.Name")%></span><br />
                                                <span class='m-0 text-muted'>@<%#DataBinder.Eval(Container.DataItem, "User.Username")%></span></a><span class='d-block font-italic py-1 display-<%# DataBinder.Eval(Container.DataItem, "User.Bio") != null %>'><%# DataBinder.Eval(Container.DataItem, "User.Bio") %></span><br /><i class='fa fa-map-marker' aria-hidden='true'></i>&nbsp;
                                                <span><%#DataBinder.Eval(Container.DataItem, "User.City")%></span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="card-footer">
                                        <div class="row">
                                            <div class="col-md-6">
                                                <button class="btn btn-primary px-4 w-100 btn-follow" type="button" followingId=<%#DataBinder.Eval(Container.DataItem, "User.Id")%> followerId=<%# currentUser.Id %>>Follow</button>
                                            </div>
                                            <div class="col-md-6">
                                                <asp:Button runat="server" cssClass="btn btn-outline-secondary px-4 w-100" Text="Message" CommandName="Message" CommandArgument=<%#DataBinder.Eval(Container.DataItem, "User.Id")%> />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        </div>
                        <h4 id="followWarning" class="text-center" runat="server">You have not followed any person yet</h4>
                    </div>
                </div>

                <div class="tab-pane fade p-6" id="pills-events" role="tabpanel" aria-labelledby="pills-events-tab">
                    <div class="row">
                        <div class="col-12">
                            <table class="table table-bordered">
                                <thead>
                                    <tr>
                                        <th>eventID</th>
                                        <th>Date</th>
                                        <th>Time</th>
                         <%--               <th>Edit</th>
                                        <th>Delete</th>--%>
                                        <th>Notify</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rpViewEventPageCreated" runat="server" ItemType="MyCircles.BLL.Event">
                                        <ItemTemplate>
                                            <tr>
                                                <%-- <td><%#DataBinder.Eval(Container.DataItem, "eventId") %> </td>--%>
                                                <td>
                                                    <label class="eventId"><%#DataBinder.Eval(Container.DataItem, "eventId") %> </label>
                                                </td>
                                                <td>
                                                    <%#DataBinder.Eval(Container.DataItem, "eventStartDate") %> - <%#DataBinder.Eval(Container.DataItem, "eventEndDate") %>
                                                </td>
                                                <td>
                                                    <%#DataBinder.Eval(Container.DataItem, "eventStartTime") %> - <%#DataBinder.Eval(Container.DataItem, "eventEndTime") %>
                                                </td>
                                  <%--              <td>
                                                    <asp:Button ID="Button1" runat="server" Text="Edit" class="btn" type="Button" UseSubmitBehavior="False" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="Button2" runat="server" Text="Delete" class="btn" type="Button" UseSubmitBehavior="False" />
                                                </td>--%>
                                                <td>
                                                    <button id="notifyBtn" class="notifyBtn btn" type="Button" eventid='<%#DataBinder.Eval(Container.DataItem, "eventId") %>'>Notify</button>
                                                </td>

                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>

            </div>
        </div>

        <div class="modal fade shadow-none" id="editprofile-modal" tabindex="-1" role="dialog" aria-labelledby="editProfileModel" aria-hidden="true" data-backdrop="static">
            <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
                <div class="modal-content">
                    <asp:UpdatePanel ID="UpdateCircleUpdatePanel" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <div class="modal-header">
                                <h5 class="text-primary modal-title">Edit Circles</h5>
                                <button id="addCirclesCloseButton" runat="server" type="button" class="close" data-dismiss="modal" aria-label="Close" visible="true">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                <div class="container-fluid">
                                    <div class="row">
                                        <div runat="server" class="col-md-6 col-sm-12 border-right pl-0">
                                            <div id="addCirclesIntroBlurb" runat="server" visible="false">
                                                <span class="text-secondary">Follow some circles so that we can provide you with content that's relevant to your interests and compete with other people in your circle using our innovative points system.</span><br />
                                                <br />
                                                <span class="h6">Just enter any of your interests to join a circle!</span>
                                            </div>
                                            <div>
                                                <asp:Repeater ID="rptUpdateCircles" runat="server" ItemType="MyCircles.BLL.UserCircle" OnItemCommand="rptUpdateCircles_ItemCommand">
                                                    <ItemTemplate>
                                                        <div class="mb-2 d-inline-flex">
                                                            <div class="border border-primary p-2 rounded d-inline mr-1">
                                                                <span class="text-primary"><%#DataBinder.Eval(Container.DataItem, "CircleId")%>&nbsp;&nbsp;|&nbsp;&nbsp;<%#DataBinder.Eval(Container.DataItem, "Points")%> points</span>&nbsp;
                                                                <asp:Button ID="btRemove" runat="server" CssClass="text-danger bg-transparent border-0" Text="&times;" CausesValidation="False" CommandName="Remove" CommandArgument=<%#DataBinder.Eval(Container.DataItem, "Id")%> />
                                                            </div>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </div>
                                        </div>
                                        <div class="col-md-6 col-sm-12 border-left pr-0">
                                            <div id="circleInputForm" runat="server">
                                                <div id="circleInputGroupBlock" class="mb-5" runat="server">
                                                    <div id="circleInputGroup" class="mb-3 input-group" runat="server" inputgroup="tbCircleInput">
                                                        <asp:TextBox ID="tbCircleInput" runat="server" CssClass="input-height-lg rounded form-control interestfollow-input flexdatalist" placeholder="Interest name" EnableViewState="false" ValidationGroup="addCircleGroup" data-min-length="1" list="existingCircles" name="circleInput" ClientIDMode="Static"></asp:TextBox>
                                                    </div>
                                                    <div id="signedOutErrorContainer" class="signedOutErrorContainer col-md-12 my-4 p-0" runat="server" visible="false">
                                                        <div class="signedOutErrorBlock">
                                                            <i class="fas fa-exclamation-triangle"></i>&nbsp;
                                                            <asp:Label ID="lbErrorMsg" runat="server">
                                                                <asp:ValidationSummary ID="vsAddCircles" runat="server" ShowSummary="false" DisplayMode="List" ValidationGroup="addCircleGroup" />
                                                            </asp:Label>
                                                        </div>
                                                    </div>
                                                    <asp:Button ID="btAddCircle" runat="server" CssClass="btn btn-outline-primary float-right" Text="+ Add" OnClick="btAddCircle_Click" CausesValidation="true" AutoPostback="true" ValidationGroup="addCircleGroup" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="btClear" runat="server" CssClass="btn btn-outline-danger" Text="Clear" OnClick="btClear_Click" CausesValidation="true" AutoPostback="true" ValidationGroup="addUserCirclesGroup" />
                                <asp:Button ID="btSubmit" runat="server" CssClass="btn btn-primary" Text="Save changes" OnClick="btSubmit_Click" CausesValidation="true" AutoPostback="true" ValidationGroup="addUserCirclesGroup" />
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btAddCircle" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="rptUpdateCircles" EventName="ItemCommand" />
                            <asp:AsyncPostBackTrigger ControlID="btClear" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="btSubmit" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>

        <datalist id="existingCircles" runat="server" ClientIDMode="Static">
        </datalist>
    </form>
</asp:Content>

<asp:Content ID="ProfileDeferredScripts" ContentPlaceHolderID="SignedInDeferredScriptsPlaceholder" runat="server">
    <script>
        url = new URL(window.location.href);

        if (url.searchParams.get('addingCircles')) {
            $('#editprofile-modal').modal('show');
        }

        $('.flexdatalist').flexdatalist({
            noResultsText: 'Create new circle called "{keyword}"',
        });

        $(document).ready(function () {
            ajaxHelper(`${postUri}/<%= requestedUser.Id %>`, 'GET', null).done(function (data) {
                if (data.length) {
                    if (data[0].IsPost) {
                        var postHtml = getPostDom(data);
                        $('#no-post-message').css("display", "none");
                        $('#userPostsContainer').append(postHtml);
                    } else {
                        $('#no-post-message').css("display", "block");
                    }
                } else {
                    $('#no-post-message').css("display", "block");
                }
            });
        });

            $(".notifyBtn").click(function () {
          //  alert($(this).attr("eventId"));
                var eventId = $(this).attr("eventId")
                ajaxHelper(`${signupeventdetailsUri}/${Number(eventId)}`, 'GET', null).done(function (data) {
                   // addNotificationToasts(data);
                    console.log(data);
                    for (i = 0; i < data.length; i++) {
                        console.log(data[i].userId)
                            addNotification({                 
                            Action: "Event has Stopped",
                            Source: "From Organizer",
                            UserId: data[i].userId,
                            Type: "negative",
                        });
                       

                      }
            });
        });
    </script>
</asp:Content>

