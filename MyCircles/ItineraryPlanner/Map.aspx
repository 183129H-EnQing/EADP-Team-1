<%@ Page MasterPageFile="Header.master" AutoEventWireup="true" CodeBehind="Map.aspx.cs" Inherits="MyCircles.ItineraryPlanner.Map" Title="My Map" %>

<asp:Content ContentPlaceHolderID="BodyContentPlaceHolder" runat="server">


    <form id="form1" runat="server">
        <style>
            #map {
                height: 400px;
                width: 700px
            }
        </style>

        <h1>hello map</h1>
        <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-1"></div>
            <div class="col-md-8 border border-secondary">
                <div id="map"></div>
                <script>
                    var map;
                    function initMap() {
                        map = new google.maps.Map(document.getElementById('map'), {
                            center: { lat: -34.397, lng: 150.644 },
                            zoom: 8
                        })
                    }
                </script>
                <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDrvz8Ax4K4wqNN7Bf0cQE6xJ6Alf-GVec&callback=initMap" async defer></script>
            </div>
            <div class="col-md-1"></div>
            <div class="col-md-1"></div>
        </div>
    </form>
</asp:Content>
