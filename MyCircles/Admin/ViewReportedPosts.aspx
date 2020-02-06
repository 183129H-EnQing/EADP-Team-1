<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeBehind="ViewReportedPosts.aspx.cs" Inherits="MyCircles.Admin.ViewReportedPosts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <h2 class="text-center">
        View Reported Posts
    </h2>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ViewReportedPostsScriptManager" runat="server" EnablePartialRendering="true"></asp:ScriptManager>

        <asp:UpdatePanel ID="ViewReportedPostsUpdatePanel" runat="server">
            <ContentTemplate>
                <div class="row">
                    <div class="col table-responsive">
                        <asp:GridView ID="gvReportedPosts" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" CssClass="table admin-table" OnRowCommand="gvReportedPosts_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="reporterUsername" HeaderText="Reporter's Username" />
                                <asp:BoundField DataField="reason" HeaderText="Reason" />
                                <asp:BoundField DataField="dateCreated" HeaderText="Date Reported" DataFormatString="{0:dd\/MMM\/yyyy}" />
                                <asp:ButtonField CommandName="ViewPost" Text="View Post" ButtonType="Button" ControlStyle-CssClass="btn btn-success text-white" />
                                <asp:ButtonField CommandName="DeletePost" Text="Delete" ButtonType="Button" ControlStyle-CssClass="btn btn-danger" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>

                <div class="modal" id="viewPostModal" tabindex="-1" role="dialog" aria-hidden="true" data-backdrop="static">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title">View Post</h5>
                                <button type="button" class="close" aria-label="Close" onclick="closeViewPostModal()">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>

                            <div class="modal-body">
                                <div class="font-weight-bold">
                                    Created by <asp:Label ID="lblModalPostCreatorName" runat="server" Text="CreatorName"></asp:Label>
                                </div>
                                <div class="text-center">
                                    <asp:Image ID="imgModalPost" runat="server" AlternateText="PostImage" CssClass="mb-2" />
                                </div>
                                <div>
                                    <asp:Label ID="lblModalContent" runat="server" Text="Content"></asp:Label>
                                </div>
                            </div>

                            <div class="modal-footer">
                                <button type="button" class="btn btn-success text-white" onclick="closeViewPostModal()">Close</button>
                                <asp:Button ID="ModalDeleteBtn" CssClass="btn btn-danger" runat="server" Text="Delete Post" OnClick="ModalDeleteBtn_Click" CausesValidation="false" UseSubmitBehavior="False" ValidateRequestMode="Disabled"/>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="gvReportedPosts" EventName="SelectedIndexChanged"/>
                <asp:AsyncPostBackTrigger ControlID="ModalDeleteBtn" EventName="Click"/>
            </Triggers>
        </asp:UpdatePanel>
    </form>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="JSPlaceHolder" runat="server">
    <script>
        function openViewPostModal() {
            $("#viewPostModal").modal('show');
        }

        function closeViewPostModal() {
            $('#viewPostModal').modal('hide')
        }
    </script>
</asp:Content>