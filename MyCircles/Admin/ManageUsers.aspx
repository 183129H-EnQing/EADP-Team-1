<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="MyCircles.Admin.ManageUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <h2 class="text-center">Manage Users</h2>

    <form runat="server">
        <asp:ScriptManager ID="ManageUsersScriptManager" runat="server" EnablePartialRendering="true"></asp:ScriptManager>

        <asp:UpdatePanel ID="ManageUsersUpdatePanel" runat="server">
            <ContentTemplate>
                <div class="row">
                    <div class="col d-flex justify-content-end">
                        <div class="form-inline">
                            <asp:DropDownList ID="ddlQueryType" runat="server" CssClass="custom-select mr-3">
                                <asp:ListItem Selected="True" Value="0">All</asp:ListItem>
                                <asp:ListItem Value="1">Username</asp:ListItem>
                                <asp:ListItem Value="2">Display Name</asp:ListItem>
                                <asp:ListItem Value="3">Email Address</asp:ListItem>
                            </asp:DropDownList>
                            <asp:TextBox ID="tbSearchInput" runat="server" CssClass="form-control mr-3"></asp:TextBox>
                            <asp:Button ID="btnSearchSubmit" runat="server" Text="Search" CausesValidation="false" CssClass="btn btn-primary" OnClick="btnSearchSubmit_Click" UseSubmitBehavior="False" AutoPostBack="true" />
                        </div>
                    </div>
                </div>

                <div class="row mt-3">
                    <div class="col table-responsive">
                        <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" CssClass="table admin-table" OnRowCommand="gvUsers_RowCommand" OnRowDataBound="gvUsers_RowDataBound" AllowPaging="True" OnPageIndexChanging="gvUsers_PageIndexChanging">
                            <Columns>
                                <asp:BoundField DataField="Username" HeaderText="Username" />
                                <asp:BoundField DataField="Name" HeaderText="Display Name" />
                                <asp:BoundField DataField="EmailAddress" HeaderText="Email Address" />
                                
                                <asp:ButtonField CommandName="UserProfile" Text="View Profile" ButtonType="Button" ControlStyle-CssClass="btn btn-success text-white">
                                
                                <ControlStyle CssClass="btn btn-primary" />
                                </asp:ButtonField>
                                
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button runat="server" CommandName="ChgUserStatus" ID="btnChgUserStatus" Text="Disable User" CssClass="btn btn-danger" UseSubmitBehavior="false"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle CssClass="admin-table-pager" HorizontalAlign="Center" />
                        </asp:GridView>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnSearchSubmit" EventName="Click"/>
            </Triggers>
        </asp:UpdatePanel>
    </form>
</asp:Content>
