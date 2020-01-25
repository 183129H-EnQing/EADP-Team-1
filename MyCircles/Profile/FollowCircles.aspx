<%@ Page Title="" Language="C#" MasterPageFile="~/SignedIn.master" AutoEventWireup="true" CodeBehind="FollowCircles.aspx.cs" Inherits="MyCircles.Profile.FollowCircles" ClientIDMode="AutoID" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SignedInHeadPlaceholder" runat="server">
    <script type="text/javascript">
        $(".interestfollow-input").autocomplete({
            source: '@Url.Action("Search")'
        });
    </script>
</asp:Content>

<asp:Content ID="AddCirclesContent" ContentPlaceHolderID="SignedInContentPlaceholder" runat="server">
<form runat="server">
    <div class="rounded container-lg content-container bg-white shadow-sm p-5">
        <div class="row">
            <div class="col-md-6 col-sm-12 border-right">
                <span class="h1 text-primary">Follow Circles</span>
                <hr />
                <span class="lead">Before we continue, you need to follow some circles so that we can provide you with content that's relevant to your interests.</span> <br /><br /> <span class="h5">Just enter any of your interests to join a circle!</span>
            </div>
            <div class="col-md-6 col-sm-12 border-left">
                <div id="circleInputForm" runat="server">
                    <div id="circleInputGroupBlock" class="mb-5" runat="server">
                        <asp:ScriptManager ID="AddCircleScriptManager" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
                        <asp:UpdatePanel ID="AddCircleUpdatePanel" runat="server" UpdateMode="Always" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:Repeater ID="rptAddCircles" runat="server" EnableViewState="false">
                                    <ItemTemplate>
                                        <div id="circleInputGroup" class="mb-3 input-group" runat="server" InputGroup="tbCircleInput">
                                            <asp:TextBox runat="server" CssClass="input-height-lg form-control interestfollow-input tb" placeholder="Interest To Follow" Text=<%#Container.DataItem%> Enabled="false" EnableViewState="false" ValidationGroup="addCircleGroup"></asp:TextBox>
<%--                                            <span class="input-group-btn">
                                                <asp:Button ID=btRemove runat="server" CssClass="input-height-lg btn btn-danger rounded-left" Text="Remove" CausesValidation="False" ClientIDMode="Static" OnClick="btRemove_Click" AutoPostback="true" />
                                            </span>--%>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            <div id="circleInputGroup" class="mb-3 input-group" runat="server" InputGroup="tbCircleInput">
                                <asp:TextBox id="tbCircleInput" runat="server" CssClass="input-height-lg form-control interestfollow-input" placeholder="Interest To Follow" EnableViewState="false" ValidationGroup="addCircleGroup"></asp:TextBox>
                            </div>
                            <div id="signedOutErrorContainer" class="signedOutErrorContainer col-md-12 my-4 p-0" runat="server" visible="false">
                                <div class="signedOutErrorBlock">
                                    <i class="fas fa-exclamation-triangle"></i> &nbsp;
                                    <asp:Label ID="lbErrorMsg" runat="server">
                                        <asp:ValidationSummary ID="vsAddCircles" runat="server" ShowSummary="false" DisplayMode="List" ValidationGroup="addCircleGroup" />
                                    </asp:Label>
                                </div>
                            </div>
                            <asp:Button ID="btAddCircle" runat="server" CssClass="btn btn-outline-primary" Text="+ Add" OnClick="btAddCircle_Click" CausesValidation="true" AutoPostback="true" ClientIDMode="Static" ValidationGroup="addCircleGroup" />
                            <asp:Button ID="btClear" runat="server" CssClass="btn btn-outline-danger" Text="Clear" OnClick="btClear_Click" CausesValidation="true" AutoPostback="true" ClientIDMode="Static" ValidationGroup="addUserCirclesGroup" />
                            <asp:Button ID="btSubmit" Text="Continue" CssClass="btn btn-primary float-right px-4" runat="server" OnClick="btSubmit_Click" CausesValidation="false" AutoPostback="true" ClientIDMode="Static" />
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btAddCircle" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="btSubmit" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>

    <datalist id="existingCircles">
    </datalist>
</form>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="SignedInDeferredScriptsPlaceholder" runat="server">
</asp:Content>
