<%@ Page Title="Chat - MyCircles" Language="C#" MasterPageFile="~/SignedIn.master" AutoEventWireup="true" CodeBehind="Chat.aspx.cs" Inherits="MyCircles.Profile.Chat" %>

<asp:Content ID="ChatHead" ContentPlaceHolderID="SignedInHeadPlaceholder" runat="server">
</asp:Content>

<asp:Content ID="ChatContent" ContentPlaceHolderID="SignedInContentPlaceholder" runat="server">
    <form runat="server">
        <asp:ScriptManager ID="MessagesScriptManager" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
        <div class="rounded container-lg content-container bg-white p-4 shadow-sm">
            <div class="col-md-12 friend details p-3">
                <div class="blog-entry">
                    <h1 class="font_color"><b>Chat History</b></h1>
                    <hr>
                </div>
                <div class="padding: 20px;"><h6 class="text-center" style="font-weight: 800;"><</h6></div>
<%--                <asp:UpdatePanel ID="UpdateCircleUpdatePanel" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                    <ContentTemplate>--%>
                        <div class="col-md-12 chat-history" style="margin-bottom: 20px">
                            <div class="blog-entry">
                                <asp:Repeater ID="rptMessages" runat="server" ItemType="MyCircles.BLL.Message">
                                    <ItemTemplate>
                                        <div class="row justify-content-end">
                                            <div class="col-auto">
                                                <p class="speech-bubble-receiver">
                                                    <b><%#DataBinder.Eval(Container.DataItem, "Content")%></b>
                                                    <br>
                                                    <%#DataBinder.Eval(Container.DataItem, "CreatedAt")%>
                                                </p>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-10">
                                <asp:TextBox ID="tbMessage" runat="server" CssClass="form-control" placeholder="Type a message" EnableViewState="false" name="messageInput" ClientIDMode="Static" required="true"></asp:TextBox>
                            </div>
                            <div class="col-2">
                                <asp:Button ID="btSendMessage" runat="server" CssClass="btn btn-primary btn-tall w-100" Text="Send" OnClick="btSendMessage_Click" AutoPostback="true" />
                            </div>
                        </div>
<%--                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="UpdateMessagesTimer" EventName="Tick" />
                    </Triggers>
                </asp:UpdatePanel>
                <asp:Timer ID="UpdateMessagesTimer" runat="server" Interval="1000" OnTick="UpdateMessagesTimer_Tick"></asp:Timer> --%>
            </div>
        </div>
    </form>
</asp:Content>

<asp:Content ID="ChatDeferredScripts" ContentPlaceHolderID="SignedInDeferredScriptsPlaceholder" runat="server">
    <script>
        function checkForNewMessages() {
            $.ajax({
                url: '/Profile/Chat.aspx/GetNewMessages',
                data: '',
                dataType: 'json',
                contentType: 'application/json',
                type: "POST",
                success: function (data) {
                    console.log(data);
                },
                complete: function (data) {
                    setTimeout(checkForNewMessages, 1000);
                },
                error: function (data, err) {
                    //alert("Your messages could not be retrieved");
                    console.log(err);
                }
            });
        }

        setTimeout(checkForNewMessages, 1000);
    </script>
</asp:Content>
