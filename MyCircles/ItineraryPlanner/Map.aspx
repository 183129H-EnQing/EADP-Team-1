<%@ Page MasterPageFile="Header.master" AutoEventWireup="true" CodeBehind="Map.aspx.cs" Inherits="MyCircles.ItineraryPlanner.Map" Title="My Map"%>

<asp:Content ContentPlaceHolderId="BodyContentPlaceHolder" runat="server">
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBlz2KBmeCFI5fsKZd0S0asMYbPIHOLpy0" type="text/javascript"></script>

    <style>
        /* Always set the map height explicitly to define the size of the div
        * element that contains the map. */
        #map {
            height: 100%;
        }
        /* Optional: Makes the sample page fill the window. */
        html, body {
            height: 100%;
            margin: 0;
            padding: 0;
        }
    </style>

    <form id="form1" runat="server">
        <h1>hello world</h1>
        <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-1"></div>
            <div class="col-md-8 border border-secondary">
                <div id="map"></div>
            </div>
            <div class="col-md-1"></div>
            <div class="col-md-1"></div>
        </div>
    </form>

    <script>
        var map;
        var service;
        var infowindow;

        function initMap() {
            var sydney = new google.maps.LatLng(-33.867, 151.195);

            infowindow = new google.maps.InfoWindow();

            map = new google.maps.Map(
                document.getElementById('map'), { center: sydney, zoom: 15 });

            var request = {
                query: 'Museum of Contemporary Art Australia',
                fields: ['name', 'geometry'],
            };

            service = new google.maps.places.PlacesService(map);

            service.findPlaceFromQuery(request, function (results, status) {
                if (status === google.maps.places.PlacesServiceStatus.OK) {
                    for (var i = 0; i < results.length; i++) {
                        createMarker(results[i]);
                    }

                    map.setCenter(results[0].geometry.location);
                }
            });
        }

        function createMarker(place) {
            var marker = new google.maps.Marker({
                map: map,
                position: place.geometry.location
            });

            google.maps.event.addListener(marker, 'click', function () {
                infowindow.setContent(place.name);
                infowindow.open(map, this);
            });
        }
</script>
</asp:Content>