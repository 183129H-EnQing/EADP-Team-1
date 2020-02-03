<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeBehind="ViewReportedPosts.aspx.cs" Inherits="MyCircles.Admin.ViewReportedPosts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <h2 class="text-center">
        View Reported Posts
    </h2>
    <form id="form1" runat="server">
        
        <asp:ScriptManager ID="UserScriptManager" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="gvReportedPosts" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" CssClass="admin-table" OnSelectedIndexChanged="gvReportedPosts_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="reporterUsername" HeaderText="Reporter User" />
                        <asp:BoundField DataField="reason" HeaderText="Reason" />
                        <asp:CommandField CausesValidation="False" SelectText="View Post" ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>

                <div class="modal fade" id="viewPostModal" tabindex="-1" role="dialog" aria-hidden="true">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title">View Post</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>

                            <div class="modal-body">
                                <asp:Image ID="ModalPostImage" runat="server" />
                                <asp:Label ID="ModalPostText" runat="server" Text="Testing"></asp:Label>
                            </div>

                            <div class="modal-footer">
                                <button type="button" class="btn btn-success" data-dismiss="modal">Close</button>
                                <asp:Button ID="ModalDeleteBtn" CssClass="btn btn-danger" runat="server" Text="Delete Post" CausesValidation="False" OnClientClick="return false" OnClick="ModalDeleteBtn_Click"/>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="gvReportedPosts" EventName="SelectedIndexChanged"/>
            </Triggers>
        </asp:UpdatePanel>
    </form>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="JSPlaceHolder" runat="server">
    <script>
        function openViewPostModal() {
            $("#viewPostModal").modal('show');
        }
    </script>
</asp:Content>