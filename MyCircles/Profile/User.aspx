<%@ Page Title="User - MyCircles" Language="C#" MasterPageFile="~/SignedIn.master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="MyCircles.Profile.User" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SignedInHeadPlaceholder" runat="server">
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBlz2KBmeCFI5fsKZd0S0asMYbPIHOLpy0" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="SettingsContent" ContentPlaceHolderID="SignedInContentPlaceholder" runat="server">
    <form runat="server">
        <div class="container-lg content-container bg-white p-0">
            <div class="user-container">
                <a href="/Profile/Ex1UpdatePanel.aspx" runat="server">
                    <asp:Image ID="HeaderImage" runat="server" Width="100%" Height="200px" BorderWidth="0" />
                </a>
                <div class="profilepic-container">
                    <asp:Image ID="ProfilePicImage" runat="server" CssClass="profilepic rounded-circle" />
                </div>
                <div class="desc-container">
                    <h1 id="lbName" class="m-0" runat="server"></h1>
                    <h5 id="lbUsername" class="m-0" runat="server">@</h5>
                    <span id="lbBio" class="bio-span d-block" runat="server"></span>
                    <i class="fa fa-map-marker" aria-hidden="true"></i> &nbsp;
                    <span id="lbCity" runat="server" ClientIdMode="Static"></span>
                </div>
            </div>
        </div>
    </form>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="SignedInDeferredScriptsPlaceholder" runat="server">
    <script>
        const lbCity = document.querySelector("#lbCity");
        getCurrentCity(<%= latitude %>, <%= longitude %>).then(currentCity => { lbCity.textContent = currentCity });
    </script>
</asp:Content>
