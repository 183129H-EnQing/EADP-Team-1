<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeBehind="ViewReportedPosts.aspx.cs" Inherits="MyCircles.Admin.ViewReportedPosts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <h2 class="text-center">
        View Reported Posts
        <form id="form1" runat="server">
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </form>
    </h2>
</asp:Content>
