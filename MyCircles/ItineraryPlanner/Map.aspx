<%@ Page MasterPageFile="Header.master" AutoEventWireup="true" CodeBehind="Map.aspx.cs" Inherits="MyCircles.ItineraryPlanner.Map" Title="My Map" %>

<asp:Content ContentPlaceHolderID="BodyContentPlaceHolder" runat="server">
    <form id="form1" runat="server">
        <%--<h1>hello map</h1>--%>
        <div class="row mt-5 sticky-top bg-warning mb-5">
            <div class="col-md-2"></div>
            <div class="col-md-8">
                <div class="row d-flex justify-content-center">
                    <%-- need insert title of Plan if possible--%>
                    <h2>
                        <asp:Label ID="lbPlannerName" runat="server" Text="January Outing"></asp:Label></h2>
                </div>
            </div>
            <div class="col-md-2"></div>
        </div>
        <div class="row mt-3">
            <div class="col-md-1"></div>
            <div class="col-md-1">
                <asp:Repeater ID="rpDates" runat="server" ItemType="MyCircles.ItineraryPlanner.Idk">
                    <ItemTemplate>
                        <h5><button type="button" class="btn btn-primary" style="text-decoration: none;" onclick='changetext(<%#DataBinder.Eval(Container.DataItem, "locations") %>)'><%#DataBinder.Eval(Container.DataItem, "date") %></button></h5>
                        
                    </ItemTemplate>
                </asp:Repeater>
            </div>

            <div class="col-md-8">
                <div id="map" style="width: 100%; height: 400px;"></div>
                <%--<script>
                    var map;
                    function initMap() {
                        map = new google.maps.Map(document.getElementById('map'), {
                            center: { lat: -34.397, lng: 150.644 },
                            zoom: 8
                        })
                    }
                </script>--%>
            </div>
            <div class="col-md-1"></div>
            <div class="col-md-1"></div>
        </div>
       <%-- <script>
            <asp:Repeater Id="rptLocationScript" runat="server" ItemType="MyCircles.DAL.DayLocation">
                let userLocation<%#DataBinder.Eval(Container.DataItem, "Id")%> = {lat: <%#DataBinder.Eval(Container.DataItem, "locaLatitude")%>, lng: <%#DataBinder.Eval(Container.DataItem, "locaLongitude")%>, date: <%#DataBinder.Eval(Container.DataItem, "date")%> };
                console.log(userLocation<%#DataBinder.Eval(Container.DataItem, "Id")%>)
            </asp:Repeater>

<%--            <% foreach (List<DayLocation> location in daysList) { %>
                let userLocation<%=location.Id%> = { lat: <%=location.locaLatitude%>, lng: <%=location.locaLongitude%>, date: <%=location.date%> };
                console.log(userLocation<%=location.Id%>)
            <% } %>
        </script>--%>
     <script>
         var locations = {
             "singapore-zoo": { lat: 1.4043, lng: 103.793 },
             "buddha-tooth-relic-temple": { lat: 1.281509, lng: 103.844189 }
         };

         function changetext(someJsonThingIdk) {
             console.log("someJsonThingIdk");
             console.log(someJsonThingIdk);
             console.log("converted to Json");
             console.log(parseFloat(someJsonThingIdk[0]["locaLatitude"]));
             console.log(parseFloat(someJsonThingIdk[0]["locaLongitude"]));
             //window.location.reload(false);

             let userLatitude = 1.4043, userLongitude = 103.793;
             userLatitude = parseFloat(someJsonThingIdk[0]["locaLatitude"]), userLongitude = parseFloat(someJsonThingIdk[0]["locaLongitude"]);
             let userLocation = { lat: userLatitude, lng: userLongitude };

             let locationLatitude = 1.281509, locationLongitude = 103.844149;
             locationLatitude = parseFloat(someJsonThingIdk[1]["locaLatitude"]), locationLongitude = parseFloat(someJsonThingIdk[1]["locaLongitude"]);
             let locationLocation = { lat: locationLatitude, lng: locationLongitude };

             initMap(userLocation, locationLocation);
             console.log(userLatitude);
         }


         //   let userLatitude = 1.4043, userLongitude = 103.793;
         //let userLocation = { lat: userLatitude, lng: userLongitude };

         //   let locationLatitude = 1.281509, locationLongitude = 103.844149;
         //   let locationLocation = { lat: locationLatitude, lng: locationLongitude };

            function initMap(userLoc, locationLoc) {
                let map = new google.maps.Map(document.getElementById('map'), { zoom: 18 });

                var userLocation = userLoc;
                var locationLocation = locationLoc;

                let marker = new google.maps.Marker(
                    {
                        map: map,
                        //draggable:    true,
                        animation: google.maps.Animation.DROP,
                        position: userLocation,
                    }
                );

                //let bounds = fitToMarker(marker);
                //map.fitBounds(bounds);

                //function
                let userIcon = {
                    url: "/Content/images/generic-user-marker.png",
                    scaledSize: new google.maps.Size(27, 45),
                };

                let directionsService = new google.maps.DirectionsService();
                let directionsDisplay = new google.maps.DirectionsRenderer({ suppressMarkers: true });
                let request = {
                    origin: userLocation,
                    destination: locationLocation,
                    travelMode: google.maps.TravelMode.DRIVING
                };

                let userMarker = new google.maps.Marker({
                    position: userLocation,
                    map: map,
                    icon: userIcon,
                });

                let destinationMarker = new google.maps.Marker(
                    {
                        map: map,
                        position: locationLocation,
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
        </script>
        <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBlz2KBmeCFI5fsKZd0S0asMYbPIHOLpy0" async defer></script>--%>
    </form>
</asp:Content>
