<%@ Page Title="Chat - MyCircles" Language="C#" MasterPageFile="~/SignedIn.master" AutoEventWireup="true" CodeBehind="Chat.aspx.cs" Inherits="MyCircles.Profile.Chat" %>

<asp:Content ID="ChatHead" ContentPlaceHolderID="SignedInHeadPlaceholder" runat="server">
</asp:Content>

<asp:Content ID="ChatContent" ContentPlaceHolderID="SignedInContentPlaceholder" runat="server">
    <form runat="server">
        <asp:ScriptManager ID="MessagesScriptManager" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
        <div class="rounded container-lg content-container bg-white p-4 shadow-sm">
            <header>
                <div class="blog-entry">
                    <h1 class="font_color"><b>Chat History</b></h1>
                    <hr>
                </div>
            </header>
            <article>
                <div class="col-md-12 chat-history" style="margin-bottom: 20px;">
                    <div id="chat-log" class="blog-entry overflow-auto">
    <%--                                <div class="row justify-content-end">
                            <div class="col-auto">
                                <div class="speech-bubble-receiver my-2">
                                    <b><%#DataBinder.Eval(Container.DataItem, "Content")%></b>
                                    <br>
                                    <span class="text-muted"><%#DataBinder.Eval(Container.DataItem, "CreatedAt")%></span>
                                </div>
                            </div>
                        </div>--%>
                    </div>
                </div>
            </article>
            <footer>
                <div class="row">
                    <div class="col-10">
                        <input id="tbMessage" class="form-control" placeholder="Type a message" name="tbMessage" required="true" />
                    </div>
                    <div class="col-2">
                        <button id="btSendMessage" class="btn btn-primary btn-tall w-100"><i class="fas fa-paper-plane"></i></button>
                    </div>
                </div>
            </footer>
        </div>
    </form>
</asp:Content>

<asp:Content ID="ChatDeferredScripts" ContentPlaceHolderID="SignedInDeferredScriptsPlaceholder" runat="server">
    <script>
        var chatRoomAttributes = { chatRoomId: '<%= chatRoomId %>', recieverId: '<%= recieverUser.Id %>', senderId: '<%= currentUser.Id %>' };

        function parseJsonDate(jsonDateString) {
            return new Date(jsonDateString.match(/\d+/)[0] * 1);
        };

        function appendMessage(message) {
            let messageDiv;

            if (message.SenderId == <%= currentUser.Id %>) {
                messageDiv =
                    '<div class="row justify-content-end">' +
                    '<div class="col-auto">' +
                    '<div class="speech-bubble-receiver my-2">' +
                    `<span><b>${message.Content}</b></span>` +
                    '<br>' +
                    `<span class="text-muted">${moment(parseJsonDate(message.CreatedAt)).format('h:mm a')}</span>` +
                    '</div>' +
                    '</div>' +
                    '</div>';
            } else {
                messageDiv =
                    '<div class="row justify-content-start">' +
                    '<div class="col-auto">' +
                    '<div class="speech-bubble-sender my-2">' +
                    `<span><b>${message.Content}</b></span>` +
                    '<br>' +
                    `<span class="text-muted">${moment(parseJsonDate(message.CreatedAt)).format('h:mm a')}</span>` +
                    '</div>' +
                    '</div>' +
                    '</div>';
            }

            $('#chat-log').append(messageDiv);
        };

        function checkForNewMessages() {
            console.log(JSON.stringify(chatRoomAttributes))
            $.ajax({
                url: '/Profile/Chat.aspx/GetNewMessages',
                data: JSON.stringify(chatRoomAttributes),
                dataType: 'json',
                contentType: 'application/json',
                type: "POST",
                success: function (data) {
                    var newMessages = data.d.result;
                    for (i = 0; i < newMessages.length; i++) {
                        appendMessage(newMessages[i])
                    }
                },
                complete: function (data) {
                    setTimeout(checkForNewMessages, 1000);
                },
                error: function (data, err) {
                    console.log(err);
                }
            });
        };

        $(document).ready(function () {
            $.ajax({
                url: '/Profile/Chat.aspx/GetAllMessages',
                data: JSON.stringify(chatRoomAttributes),
                dataType: 'json',
                contentType: 'application/json',
                type: "POST",
                success: function (data) {
                    console.log(data)
                    var allMessages = data.d.result;
                    for (i = 0; i < allMessages.length; i++) {
                        appendMessage(allMessages[i])
                    }
                },
                error: function (data, err) {
                    console.log(err);
                }
            });
        });

        $("form").submit(function (e) {
            e.preventDefault();
            chatRoomAttributes["messageContent"] = $("#tbMessage").val();

            $.ajax({
                url: '/Profile/Chat.aspx/AddNewMessage',
                data: JSON.stringify(chatRoomAttributes),
                dataType: 'json',
                contentType: 'application/json',
                type: "POST",
                success: function (data) {
                    var newMessage = data.d.result;
                    appendMessage(newMessage);
                },
                error: function (data, err) {
                    console.log(err);
                }
            });
        });

        setTimeout(checkForNewMessages, 1000);
    </script>
</asp:Content>
