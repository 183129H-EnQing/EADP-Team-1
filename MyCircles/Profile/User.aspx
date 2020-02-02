<%@ Page Title="User - MyCircles" Language="C#" MasterPageFile="~/SignedIn.master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="MyCircles.Profile.User" %>
<%@ Register assembly="Reimers.Google.Map" namespace="Reimers.Google.Map" TagPrefix="Reimers" %>

<asp:Content ID="ProfileHead" ContentPlaceHolderID="SignedInHeadPlaceholder" runat="server">
</asp:Content>

<asp:Content ID="ProfileContent" ContentPlaceHolderID="SignedInContentPlaceholder" runat="server">
    <form runat="server">
        <asp:ScriptManager ID="UserScriptManager" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
        <div class="rounded container-lg content-container bg-white p-0 shadow-sm mb-6">
            <div class="user-container">
                <a href="/Profile/Ex1UpdatePanel.aspx" runat="server">
                    <asp:Image ID="HeaderImage" runat="server" Width="100%" Height="300px" BorderWidth="0" CssClass="rounded" BackColor="#0cb0ca" />
                </a>
                <div class="mainprofilepic-container">
                    <asp:Image ID="ProfilePicImage" runat="server" CssClass="profilepic rounded-circle img-fluid" />
                </div>
                <div class="maindesc-container">
                    <asp:Label ID="lbName" cssClass="m-0 h1" runat="server"></asp:Label><span id="followBadge" class="badge badge-secondary" runat="server" visible="false">Follows you</span><br />
                    <asp:Label ID="lbUsername" class="m-0 text-muted" runat="server">@</asp:Label><br />
                    <span id="lbBio" class="bio-span d-block font-italic py-3" runat="server"></span>
                    <i class="fa fa-map-marker" aria-hidden="true"></i> &nbsp;
                    <span id="lbCity" runat="server" ClientIdMode="Static"></span>
                </div>
            </div>
            <div style="height:200px">
                <input id="btEditProfile" name="btEditProfile" class="btn btn-outline-primary float-right m-5 px-4" value="Edit Profile" type="button" runat="server" />
                <asp:UpdatePanel ID="FollowUpdatePanel" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:CheckBox ID="cbMakeEventHost" runat="server" Visible="false" CssClass="float-right" OnCheckedChanged="cbMakeEventHost_CheckedChanged" Text="Event Host" AutoPostBack="true"/>
                        <asp:Button ID="btFollow" runat="server" Text="Follow" CssClass="btn btn-outline-primary float-right m-5 px-4" OnClick="btFollow_Click" UseSubmitBehavior="false" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btFollow" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="cbMakeEventHost" EventName="CheckedChanged"/>
                    </Triggers>
                </asp:UpdatePanel>
            </div>

            <ul class="nav nav-pills mb-3 nav-justified px-6 border-bottom" id="pills-tab" role="tablist">
                <li class="nav-item">
                    <a class="nav-link" id="pills-posts-tab" data-toggle="pill" href="#pills-posts" role="tab" aria-controls="pills-posts" aria-selected="false">Posts</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" id="pills-circles-tab" data-toggle="pill" href="#pills-circles" role="tab" aria-controls="pills-circles" aria-selected="false" data-url="?action=circles">Circles</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" id="pills-people-tab" data-toggle="pill" href="#pills-people" role="tab" aria-controls="pills-people" aria-selected="false" data-url="?action=people">People</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link active" id="pills-map-tab" data-toggle="pill" href="#pills-map" role="tab" aria-controls="pills-map" aria-selected="true" data-url="?action=map">Map</a>
                </li>
            </ul>
            <div class="tab-content" id="pills-tabContent">
                <div class="tab-pane fade" id="pills-posts" role="tabpanel" aria-labelledby="pills-posts-tab">
                    <div id="userPostsContainer" class="container py-5 px-7" runat="server">
                        <h4 id="postWarning" class="text-center" runat="server">You have not made any posts yet</h4>
                    </div>
                </div>
                <div class="tab-pane fade" id="pills-circles" role="tabpanel" aria-labelledby="pills-circles-tab">
                    <div id="userCirclesContainer" class="container py-5 px-7" runat="server">
                    </div>
                </div>
                <div class="tab-pane fade" id="pills-people" role="tabpanel" aria-labelledby="pills-people-tab">
                    <div id="followingUserListContainer" class="container py-5 px-7" runat="server">
                        <asp:Repeater ID="rptUserFollowing" runat="server" ItemType="MyCircles.DAL.FollowingUsers">
                            <ItemTemplate>
                                <div class="row followinguser-container rounded-lg bg-light-color py-4 px-6 m-3">
                                    <div class="col-md-3 profilepic-container">
                                        <a href="User.aspx?username=<%#DataBinder.Eval(Container.DataItem, "User.Username")%>" class="text-decoration-none">
                                        <asp:Image runat='server' CssClass='profilepic rounded-circle' Height='150px' Width='150px' ImageUrl=<%#DataBinder.Eval(Container.DataItem, "User.ProfileImage")%> />
                                    </div>
                                    <div class="col-md-6 desc-container">
                                        <span class='m-0 h1'><%#DataBinder.Eval(Container.DataItem, "User.Name")%></span><span class='badge badge-secondary' visible='false'>Follows you</span><br />
                                        <span class='m-0 text-muted'>@<%#DataBinder.Eval(Container.DataItem, "User.Username")%></span></a><span class='bio-span d-block font-italic py-2'><%#DataBinder.Eval(Container.DataItem, "User.Bio")%></span><i class='fa fa-map-marker' aria-hidden='true'></i>&nbsp;
                                        <span><%#DataBinder.Eval(Container.DataItem, "User.City")%></span>
                                    </div>
                                    <div class='col-md-3 button-container'>
                                        <asp:Button runat='server' Text='Following' CssClass='btn btn-primary float-right m-3 px-4' UserId=<%#DataBinder.Eval(Container.DataItem, "User.Id")%> UseSubmitBehavior="false" />
                                        <asp:Button runat='server' Text='Message' CssClass='btn btn-outline-primary float-right m-3 px-4' UserId=<%#DataBinder.Eval(Container.DataItem, "User.Id")%> OnClick="btMessage_Click"  UseSubmitBehavior="false" />
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <h4 id="followWarning" class="text-center" runat="server">You have not followed any person yet</h4>
                    </div>
                </div>
                <div class="tab-pane fade show active" id="pills-map" role="tabpanel" aria-labelledby="pills-mao-tab">
                    <div id="mapContainer" class="container py-5 px-7" runat="server">
                        <div id="mapsContainer" class="container" runat="server">
                            <reimers:map id="GMap" width="100%" height="400px" runat="server" Zoom="18" />
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
                                <h5 class="text-primary modal-title">Add Circles</h5>
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
                                                            <asp:Button ID="btRemove" runat="server" CssClass="text-danger bg-transparent border-0" Text="&times;" CausesValidation="False" CommandName="Remove" />
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
    </script>
</asp:Content>

