<%@ Page Title="User - MyCircles" Language="C#" MasterPageFile="~/SignedIn.master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="MyCircles.Profile.User" %>
<%@ Register assembly="Reimers.Google.Map" namespace="Reimers.Google.Map" TagPrefix="Reimers" %>

<asp:Content ID="ProfileHead" ContentPlaceHolderID="SignedInHeadPlaceholder" runat="server">
</asp:Content>

<asp:Content ID="ProfileContent" ContentPlaceHolderID="SignedInContentPlaceholder" runat="server">
    <form runat="server">
        <div class="rounded container-lg content-container bg-white p-0 shadow-sm">
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
                <asp:ScriptManager ID="FollowScriptManager" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
                    <asp:UpdatePanel ID="FollowUpdatePanel" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
<%--                            <input id="btFollow" name="btFollow" class="btn btn-outline-primary float-right m-5" value="Follow" type="button" runat="server" />--%>
                            <asp:Button ID="btFollow" runat="server" Text="Follow" CssClass="btn btn-outline-primary float-right m-5 px-4" OnClick="btFollow_Click"  UseSubmitBehavior="false" />
                        </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btFollow" EventName="Click" />        
                    </Triggers>
                </asp:UpdatePanel>
            </div>
            <ul class="nav nav-pills mb-3 nav-justified px-6 border-bottom" id="pills-tab" role="tablist">
                <li class="nav-item">
                    <a class="nav-link active" id="pills-posts-tab" data-toggle="pill" href="#pills-posts" role="tab" aria-controls="pills-posts" aria-selected="true">Posts</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" id="pills-circles-tab" data-toggle="pill" href="#pills-circles" role="tab" aria-controls="pills-circles" aria-selected="false">Circles</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" id="pills-people-tab" data-toggle="pill" href="#pills-people" role="tab" aria-controls="pills-people" aria-selected="false">People</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" id="pills-map-tab" data-toggle="pill" href="#pills-map" role="tab" aria-controls="pills-map" aria-selected="false">Map</a>
                </li>
            </ul>
            <div class="tab-content" id="pills-tabContent">
                <div class="tab-pane fade show active" id="pills-posts" role="tabpanel" aria-labelledby="pills-posts-tab">
                    <div id="userPostsContainer" class="container py-5 px-7" runat="server">
                        <h4 id="postWarning" class="text-center" runat="server">You have not made any posts yet</h4>
                    </div>
                </div>
                <div class="tab-pane fade" id="pills-circles" role="tabpanel" aria-labelledby="pills-circles-tab">
                    <div id="userCirclesContainer" class="container py-5 px-7" runat="server">
                        <h4 id="circleWarning" class="text-center" runat="server">You have not joined any circles yet</h4>
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
                                        <span class='m-0 text-muted'>@<%#DataBinder.Eval(Container.DataItem, "User.Username")%></span>
                                        </a>
                                        <span class='bio-span d-block font-italic py-2'><%#DataBinder.Eval(Container.DataItem, "User.Bio")%></span>
                                        <i class='fa fa-map-marker' aria-hidden='true'></i> &nbsp;
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
            </div>
            <div class="tab-pane fade" id="pills-map" role="tabpanel" aria-labelledby="pills-map-tab">
                <div id="mapsContainer" class="container py-5 px-7" runat="server">
<%--                    <asp:UpdatePanel ID="MapUpdatePanel" runat="server">
                        <ContentTemplate>
                            <Reimers:Map ID="GMap" Width="500px" Height="400px" runat="server" />
                        </ContentTemplate>
                    </asp:UpdatePanel>--%>
                    <Reimers:Map ID="GMap" Width="100%" Height="400px" runat="server" />
                </div>
            </div>
        </div>

        <div class="modal fade shadow-none" id="editprofile-modal" tabindex="-1" role="dialog" aria-labelledby="editProfileModel" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered modal-lg shadow-none">
                <div class="modal-content shadow-none">
                    ...
                </div>
            </div>
        </div>
    </form>
</asp:Content>

<asp:Content ID="ProfileDeferredScripts" ContentPlaceHolderID="SignedInDeferredScriptsPlaceholder" runat="server">
</asp:Content>

