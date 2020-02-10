<%@ Page MasterPageFile="Header.master" AutoEventWireup="true" CodeBehind="Map.aspx.cs" Inherits="MyCircles.ItineraryPlanner.Map" Title="My Map" %>

<asp:Content ContentPlaceHolderID="BodyContentPlaceHolder" runat="server">
    <form id="form1" runat="server">
        <%--<h1>hello map</h1>--%>
        <div class="row mt-5 sticky-top bg-warning mb-5">
            <div class="col-md-2"></div>
            <div class="col-md-8">
                <div class="row d-flex justify-content-center">
                    <%-- need insert title of Plan if possible--%>
                    <h2><asp:Label ID="lbPlannerName" runat="server" Text="January Outing"></asp:Label></h2>
                </div>
            </div>
            <div class="col-md-2"></div>
        </div>
        <div class="row mt-3">
            <div class="col-md-1"></div>
            <div class="col-md-1">
                <asp:Repeater ID="rpDates" runat="server" ItemType="MyCircles.BLL.DayByDay">
                    <ItemTemplate>
                        <h5><a href="#<%#DataBinder.Eval(Container.DataItem, "dayByDayId") %>" style="text-decoration: none;" onclick="changetext()"><%#DataBinder.Eval(Container.DataItem, "date") %></a></h5>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="col-md-8">
                <div id="map" style="width:100%; height: 400px;"></div>
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
        <%--<script>

            let userLatitude = 1.4043, userLongitude = 103.793;
            let userLocation = { lat: userLatitude, lng: userLongitude };

            let locationLatitude = 1.281509, locationLongitude = 103.844149;
            let locationLocation = { lat: locationLatitude, lng: locationLongitude };

            function initMap() {
                let map = new google.maps.Map(document.getElementById('map'), { zoom: 18 });

                let marker = new google.maps.Marker(
                    {
                        map: map,
                        //draggable: true,
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
        <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBlz2KBmeCFI5fsKZd0S0asMYbPIHOLpy0&callback=initMap" defer></script>--%>
    </form>
</asp:Content>
