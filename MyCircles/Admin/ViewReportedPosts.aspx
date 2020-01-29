<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeBehind="ViewReportedPosts.aspx.cs" Inherits="MyCircles.Admin.ViewReportedPosts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <h2 class="text-center">
        View Reported Posts
        <form id="form1" runat="server">
            <asp:GridView ID="gvReportedPosts" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="reporterUsername" HeaderText="Reporter User" />
                    <asp:BoundField DataField="reason" HeaderText="Reason" />
                </Columns>
            </asp:GridView>
        </form>
    </h2>
</asp:Content>
