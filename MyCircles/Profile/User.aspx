<%@ Page Title="User - MyCircles" Language="C#" MasterPageFile="~/SignedIn.master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="MyCircles.Profile.User" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SignedInHeadPlaceholder" runat="server">
</asp:Content>

<asp:Content ID="SettingsContent" ContentPlaceHolderID="SignedInContentPlaceholder" runat="server">
    <form runat="server">
        <div class="container-lg content-container bg-white p-0">
            <a class="nav-link" href="/Profile/Ex1UpdatePanel.aspx" runat="server">
                <asp:Image ID="HeaderImage" runat="server" Width="100%" Height="200px" BorderWidth="0" />
            </a>
        </div>
    </form>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="SignedInDeferredScriptsPlaceholder" runat="server">
</asp:Content>
