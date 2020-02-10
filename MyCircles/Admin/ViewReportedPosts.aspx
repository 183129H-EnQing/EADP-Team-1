<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeBehind="ViewReportedPosts.aspx.cs" Inherits="MyCircles.Admin.ViewReportedPosts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
<div class="my-4">
    <h2 class="text-center">
        Reported Posts
    </h2>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ReportedPostsScriptManager" runat="server" EnablePartialRendering="true"></asp:ScriptManager>

        <asp:UpdatePanel ID="ViewReportedPostsUpdatePanel" runat="server">
            <ContentTemplate>
                <ul class="nav nav-pills mb-3 border-bottom px-4" role="tablist">
                    <li class="nav-item">
                        <a class="nav-link active" data-toggle="pill" href="#pillStats" role="tab" aria-controls="pill-stats" aria-selected="true">Stats</a>
                    </li>
                    <li class="nav-item">
                        <%--<a>Reported Posts</a>--%>
                        <a class="nav-link" data-toggle="pill" href="#pill-reportedposts" role="tab" aria-controls="pill-reportedposts" aria-selected="false">Reported Posts</a>
                    </li>
                </ul>
                <div class="tab-content mx-6">
                    <div class="tab-pane fade show active" id="pillStats" role="tabpanel" aria-labelledby="pill-stats-pane">
                        Stats
                    </div>
                    <div class="tab-pane fade" id="pill-reportedposts" role="tabpanel" aria-labelledby="pill-reportedposts-pane">
                        
                        <div class="row">
                            <div class="col table-responsive">
                                <asp:GridView ID="gvReportedPosts" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" CssClass="table admin-table" OnRowCommand="gvReportedPosts_RowCommand" OnDataBound="gvReportedPosts_DataBound">
                                    <Columns>
                                        <asp:BoundField DataField="reporterUsername" HeaderText="Reporter's Username" />
                                        <asp:BoundField DataField="reason" HeaderText="Reason" />
                                        <asp:BoundField DataField="dateCreated" HeaderText="Date Reported" DataFormatString="{0:dd\/MMM\/yyyy}" />
                                        <asp:ButtonField CommandName="ViewPost" Text="View Post" ButtonType="Button" ControlStyle-CssClass="btn btn-primary" />
                                        <asp:ButtonField CommandName="DeletePost" Text="Delete Report & Post" ButtonType="Button" ControlStyle-CssClass="btn btn-danger" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>

                    </div>
                </div>

                <div class="modal" id="viewPostModal" tabindex="-1" role="dialog" aria-hidden="true">
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
                                <button type="button" class="btn btn-primary" onclick="closeViewPostModal()">Close</button>
                                <asp:Button ID="btnModalDelete" CssClass="btn btn-danger" runat="server" Text="Delete Report & Post" OnClick="ModalDeleteBtn_Click" UseSubmitBehavior="false"/>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="gvReportedPosts" EventName="SelectedIndexChanged"/>
                <asp:AsyncPostBackTrigger ControlID="btnModalDelete" EventName="Click"/>
            </Triggers>
        </asp:UpdatePanel>
    </form>
</div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="JSPlaceHolder" runat="server">
    <script>
        function openViewPostModal() {
            $("#viewPostModal").modal('show');
        }

        function closeViewPostModal() {
            console.log("closing modal");
            $(".modal-backdrop").remove();
            $('#viewPostModal').modal('hide')
        }
    </script>
</asp:Content>