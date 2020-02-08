<%@ Page Title="Chat - MyCircles" Language="C#" MasterPageFile="~/SignedIn.master" AutoEventWireup="true" CodeBehind="Chat.aspx.cs" Inherits="MyCircles.Profile.Chat" %>

<asp:Content ID="ChatHead" ContentPlaceHolderID="SignedInHeadPlaceholder" runat="server">
</asp:Content>

<asp:Content ID="ChatContent" ContentPlaceHolderID="SignedInContentPlaceholder" runat="server">
    <style>
        #map {
            height: 400px;
            border-radius: 0.27rem;
        }

        .show-location-map {
            height: 300px;
            width: 400px;
            border-radius: .4em;
        }

        html, body {
            height: 100%;
            margin: 0;
            padding: 0;
        }
    </style>

    <form runat="server">
        <div class="position-relative p-0 rounded container-lg content-container bg-white shadow-sm mb-4 border">
            <div class="row">
                <div class="col-md-4 pr-0 chatroom-user-list">
                    <asp:Repeater ID="rptUserChatRooms" runat="server" ItemType="MyCircles.DAL.UserChatRoom">
                        <ItemTemplate>
                            <a href="/Profile/Chat.aspx?chatroom=<%#DataBinder.Eval(Container.DataItem, "ChatRoom.Id")%>" class="text-decoration-none">
                                <div class='card border-light-color shadow-sm <%# ((int)DataBinder.Eval(Container.DataItem, "RequestedUser.Id") == recieverUser.Id) ? "selected thick-border" : "border" %>'>
                                    <div class="card-body">
                                        <div class="row">
                                            <div class="col-md-3 profilepic-container">
                                                <asp:Image runat='server' CssClass="small-profilepic rounded-circle" ImageUrl='<%#DataBinder.Eval(Container.DataItem, "RequestedUser.ProfileImage")%>' />
                                            </div>
                                            <div class="col-md-9 desc-container">
                                                <span class='m-0 h5'><%#DataBinder.Eval(Container.DataItem, "RequestedUser.Name")%></span><br />
                                                <span class='m-0 text-muted'>@<%#DataBinder.Eval(Container.DataItem, "RequestedUser.Username")%></span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </a>
                        </ItemTemplate>
                    </asp:Repeater>
                    <div class="border-bottom">
                    </div>
                </div>
                <div class="col-md-8 pl-0 border-left">
                    <header class="position-sticky chat-header border-bottom bg-light rounded-top">
                        <div class="p-4">
                            <a href="/Profile/User.aspx?username=<%= recieverUser.Username %>" class="text-decoration-none">
                                <div class="row justify-content-between">
                                    <div class="col-1 profilepic-container">
                                        <asp:Image ID="requestedUserProfilePicture" runat='server' CssClass="small-profilepic rounded-circle" />
                                    </div>
                                    <div class="col-5 desc-container pl-0">
                                        <span class='m-0 h5'><%= recieverUser.Name %></span><span class='IsLoggedIn-<%= recieverUser.IsLoggedIn %>'>   •   <%= (recieverUser.IsLoggedIn) ? "Online" : "Offline" %></span><br />
                                        <span class='m-0 text-muted'>@<%= recieverUser.Username %></span>
                                    </div>
                                    <div class="col-5 desc-container text-right">
                                        <asp:Button ID="btSubmit" runat="server" CssClass="btn btn-primary" Text="Follow" CausesValidation="False" />
                                    </div>
                                </div>
                            </a>
                        </div>
                    </header>
                    <article class="chat-content">
                        <div class="col-md-12 chat-history p-4" style="margin-bottom: 20px;">
                            <div id="chat-log" class="blog-entry">
                            </div>
                        </div>
                    </article>
                    <footer class="position-sticky chat-footer border-top bg-light rounded-bottom">
                        <div class="row p-4">
                            <div id="select-location-map" class="col-md-12 my-3" style="height: 100%; width: 100%; display: none;">
                                <div id="map"></div>
                                <input name="latitude" id="latitude" type="hidden" class="">
                                <input name="longitude" id="longitude" type="hidden" class="">
                            </div>
                            <div class="col-10">
                                <div class="input-group mb-3">
                                    <input id="tbMessage" class="form-control" placeholder="Type a message" name="tbMessage" />
                                    <div class="input-group-append">
                                        <button id="show-map" class="btn btn-secondary" type="button">Attach Location</button>
                                    </div>
                                </div>
                            </div>
                            <div class="col-2">
                                <button id="btSendMessage" class="btn btn-primary btn-tall w-100"><i class="fas fa-paper-plane"></i></button>
                            </div>
                        </div>
                    </footer>
                </div>
            </div>
        </div>
    </form>

        <script>
            var chatRoomAttributes = { chatRoomId: '<%= chatRoomId %>', recieverId: '<%= recieverUser.Id %>', senderId: '<%= currentUser.Id %>' };
            let userLatitude = <%= currentUser.Latitude %>, userLongitude = <%= currentUser.Longitude %>;
            let userLocation = { lat: userLatitude, lng: userLongitude };

            function initMap() {
                let map = new google.maps.Map(document.getElementById('map'), { zoom: 18 });

                let marker = new google.maps.Marker(
                    {
                        map: map,
                        draggable: true,
                        animation: google.maps.Animation.DROP,
                        position: userLocation,
                    }
                );

                let bounds = fitToMarker(marker);
                map.fitBounds(bounds);

                google.maps.event.addListener(marker, 'dragend', function () {
                    geocodePosition(marker.getPosition());
                });

                function geocodePosition(pos) {
                    geocoder = new google.maps.Geocoder();
                    geocoder.geocode(
                        {
                            latLng: pos
                        },
                        function (results, status) {
                            if (status == google.maps.GeocoderStatus.OK) {
                                $("#latitude").val(pos.lat());
                                $("#longitude").val(pos.lng());
                            }
                            else {
                                $("#mapErrorMsg").val('Cannot determine address at this location.' + status);
                            }
                        }
                    );
                }
            }

            function initShowLocationMap(mapId, lat, lng) {
                let selectedLocation = { lat: lat, lng: lng };

                let userIcon = {
                    url: "/Content/images/generic-user-marker.png",
                    scaledSize: new google.maps.Size(27, 45),
                };

                let directionsService = new google.maps.DirectionsService();
                let directionsDisplay = new google.maps.DirectionsRenderer({ suppressMarkers: true });
                let request = {
                    origin: userLocation,
                    destination: selectedLocation,
                    travelMode: google.maps.TravelMode.WALKING
                };

                let map = new google.maps.Map(document.getElementById(mapId), { zoom: 18 });

                let userMarker = new google.maps.Marker({
                    position: userLocation,
                    map: map,
                    icon: userIcon,
                });

                let destinationMarker = new google.maps.Marker(
                    {
                        map: map,
                        position: selectedLocation,
                    }
                );

                directionsService.route(request, function (response, status) {
                    if (status == google.maps.DirectionsStatus.OK) {
                        directionsDisplay.setDirections(response);
                        directionsDisplay.setMap(map);
                    } else {
                        alert("Directions request from your location to failed: " + status);
                    }
                });

                let bounds = new google.maps.LatLngBounds();
                bounds.extend(destinationMarker.position);
                bounds.extend(userMarker.position);

                map.fitBounds(bounds);
            }

            function fitToMarker(marker) {
                let bounds = new google.maps.LatLngBounds();

                let latlng = marker.getPosition();
                bounds.extend(latlng);

                if (bounds.getNorthEast().equals(bounds.getSouthWest())) {
                    let extendPoint1 = new google.maps.LatLng(bounds.getNorthEast().lat() + 0.001, bounds.getNorthEast().lng() + 0.001);
                    let extendPoint2 = new google.maps.LatLng(bounds.getNorthEast().lat() - 0.001, bounds.getNorthEast().lng() - 0.001);
                    bounds.extend(extendPoint1);
                    bounds.extend(extendPoint2);
                }

                return bounds;
            }

            function parseJsonDate(jsonDateString) {
                return new Date(jsonDateString.match(/\d+/)[0] * 1);
            };

            function appendMessage(message, currentUserId) {
                let messageDiv;

                if (message.SenderId == currentUserId) {
                    messageDiv =
                        '<div class="row justify-content-end">' +
                        '<div class="col-auto">' +
                        '<div class="speech-bubble-receiver my-2">' +
                        `<span><b>${message.Content}</b></span>`
                } else {
                    messageDiv =
                        '<div class="row justify-content-start">' +
                        '<div class="col-auto">' +
                        '<div class="speech-bubble-sender my-2">' +
                        `<span><b>${message.Content}</b></span>`
                }

                if (message.Latitude && message.Longitude) {
                    messageDiv +=
                        '<div class="show-location-div my-3" style="height:100%; width:100%;">' +
                        `<div id="show-location-map-${message.Id}" class="show-location-map"></div></div>`
                };

                messageDiv +=
                    `<br><span class="text-muted">${moment(parseJsonDate(message.CreatedAt)).format('h:mm a')}</span>` +
                    `</div></div></div>`

                $('#chat-log').append(messageDiv);

                if (message.Latitude && message.Longitude) {
                    initShowLocationMap(`show-location-map-${message.Id}`, message.Latitude, message.Longitude)
                };
            };

            function checkForNewMessages() {
                $.ajax({
                    url: '/Profile/Chat.aspx/GetNewMessages',
                    data: JSON.stringify(chatRoomAttributes),
                    dataType: 'json',
                    contentType: 'application/json',
                    type: "POST",
                    success: function (data) {
                        var newMessages = data.d.result;
                        for (i = 0; i < newMessages.length; i++) {
                            appendMessage(newMessages[i], chatRoomAttributes["currentUserId"]);
                            $('.chat-content').animate({ scrollTop: ($('.chat-content')[0].scrollHeight) });
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
                        var allMessages = data.d.result;
                        for (i = 0; i < allMessages.length; i++) {
                            appendMessage(allMessages[i], chatRoomAttributes["senderId"])
                        }
                        $('.chat-content').animate({ scrollTop: ($('.chat-content')[0].scrollHeight) });
                    },
                    error: function (data, err) {
                        console.log(err);
                    }
                });
            });

            $("form").submit(function (e) {
                e.preventDefault();

                if ($("#tbMessage").val()) {
                    chatRoomAttributes["messageContent"] = $("#tbMessage").val();
                    chatRoomAttributes["latitude"] = $("#latitude").val();
                    chatRoomAttributes["longitude"] = $("#longitude").val();

                    $.ajax({
                        url: '/Profile/Chat.aspx/AddNewMessage',
                        data: JSON.stringify(chatRoomAttributes),
                        dataType: 'json',
                        contentType: 'application/json',
                        type: "POST",
                        success: function (data) {
                            var newMessage = data.d.result;
                            appendMessage(newMessage, chatRoomAttributes["senderId"]);
                            $('.chat-content').animate({ scrollTop: ($('.chat-content')[0].scrollHeight) });
                            $("#tbMessage").val("");

                            addNotification({
                                Action: "Message",
                                Source: "<%= currentUser.Name %>",
                                UserId: <%= recieverUser.Id %>,
                                AdditionalMessage: chatRoomAttributes["messageContent"],
                                CallToAction: "View Message",
                                CallToActionLink: `/Profile/Chat.aspx?chatroom=${chatRoomAttributes.chatRoomId}`,
                            });
                        },
                        error: function (data, err) {
                            console.log(err);
                        }
                    });
                }
            });

            $("#show-map").click(function () {
                $("#select-location-map").slideToggle("slow", function () {
                    if ($("#select-location-map").not(":visible")) {
                        $("#latitude").val("");
                        $("#longitude").val("");
                    }
                });
            });

            setTimeout(checkForNewMessages, 1000);
    </script>

    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBlz2KBmeCFI5fsKZd0S0asMYbPIHOLpy0&callback=initMap" defer></script>
</asp:Content>

<asp:Content ID="ChatDeferredScripts" ContentPlaceHolderID="SignedInDeferredScriptsPlaceholder" runat="server">
</asp:Content>
