<%@ Page Title="Chat - MyCircles" Language="C#" MasterPageFile="~/SignedIn.master" AutoEventWireup="true" CodeBehind="Chat.aspx.cs" Inherits="MyCircles.Profile.Chat" %>

<asp:Content ID="ChatHead" ContentPlaceHolderID="SignedInHeadPlaceholder" runat="server">
</asp:Content>

<asp:Content ID="ChatContent" ContentPlaceHolderID="SignedInContentPlaceholder" runat="server">
    <div class="rounded container-lg content-container bg-white p-4 shadow-sm">
    <div class="col-md-12 friend details p-3">
            <div class="blog-entry">
                <h1 class="font_color"><b>Chat History</b></h1>
                <hr>
            </div>

            <div class="padding: 20px;"><h6 class="text-center" style="font-weight: 800;">05-01-2020</h6></div>
            <div class="col-md-12 chat-history" style="margin-bottom: 20px">
                <div class="blog-entry">
                    <div class="row justify-content-end">
                        <div class="col-auto">
                            <p class="speech-bubble-receiver"><b>hello</b> <br>
                                02:33 PM <br>
                            </p>

                        </div>
                    </div>
                    <div class="row justify-content-start">
                        <div class="col-auto">
                            <p class="speech-bubble-sender"><b>hey</b> <br>
                                02:34 PM</p>

                        </div>
                    </div>
                    <div class="row justify-content-start">
                        <div class="col-auto">
                            <p class="speech-bubble-sender"><b>sup</b> <br>
                                02:34 PM</p>

                        </div>
                    </div>
                    <div class="row justify-content-end">
                        <div class="col-auto">
                            <p class="speech-bubble-receiver"><b>nothing much</b> <br>
                                02:34 PM <br>
                            </p>

                        </div>
                    </div>
                </div>
            </div>

            <form method="post" style="width: 100%; margin-top: 30px;">

                <div class="row">
                    <div class="col-10">
                        <input type="text" class="form-control" name="message" id="message" placeholder="Type a message" required="">
                    </div>
                    <div class="col-2">
                        <button type="submit" id="sendMessage" name="sendMessage" class="btn btn-primary btn-tall" style="width: 100%;"><i class="fas fa-reply"></i></button>
                        <input type="hidden" name="receive" id="receive" value="10"><br>
                        <input type="hidden" name="refId" id="refId" value="4"><br>
                    </div>
                </div>
            </form>
        </div>
    </div>
</asp:Content>
