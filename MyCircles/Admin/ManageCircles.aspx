<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeBehind="ManageCircles.aspx.cs" Inherits="MyCircles.Admin.ManageCircles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
<div class="m-4">
    <h2 class="text-center">
        Manage Circles
    </h2>

    <form id="form1" runat="server">
        <asp:ScriptManager ID="ManageCircleScriptManager" runat="server" EnablePartialRendering="true"></asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="gvCircles" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true" CssClass="table admin-table" OnRowCommand="gvCircles_RowCommand">

                    <Columns>
                        <asp:BoundField HeaderText="Circle Name" DataField="Id" />
                        <asp:ButtonField CommandName="DeleteCircle" Text="Delete" ButtonType="Button" ControlStyle-CssClass="btn btn-danger" />
                    </Columns>

                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="JSPlaceHolder" runat="server">
</asp:Content>
