<%@ Page MasterPageFile="~/SignedIn.master"AutoEventWireup="true" CodeBehind="TaxiAvail.aspx.cs" Inherits="MyCircles.ItineraryPlanner.TaxiAvail" Title="Taxi Availability" %>

<asp:Content ContentPlaceHolderID="SignedInContentPlaceholder" runat="server">
    <form id="form1" runat="server">
        <div class="row mt-4">
            <div class="col-md-4"></div>
            <div class="col-md-4 d-flex justify-content-center">
                <h2>Taxis Available - &nbsp</h2><h2 id="avail">4324</h2>
            </div>
            <div class="col-md-4">
                <p id="yourlocation"></p>
            </div>
        </div>
        <div class="row mt-3">
            <div class="col-md-1"></div>
            <div class="col-md-6 mr-3">
                <iframe width="100%;" height="400" src="https://data.gov.sg/dataset/taxi-availability/resource/9d217820-1350-4032-a7a3-3cd83e222eb7/view/5ad2510e-6b51-4ffe-9504-6661061a708c" frameBorder="0"> </iframe> 
            </div>
            <script>
                //window.setInterval(function () {
                    
                //},5000);
                var date = new Date();
                var currentdate = new Date(Date.UTC(date.getFullYear(), date.getMonth(), date.getDate(), date.getHours(), date.getMinutes(), date.getSeconds())); //this is UTC date set using Date.UTC
                jsonconvert = currentdate.toJSON(); //returns the UTC Date
                var jcon = jsonconvert.split(":").join("%3A");
                jcon = jcon.substring(0, 23)
                //console.log(jcon);

                var xhr = new XMLHttpRequest();
                var url = "https://api.data.gov.sg/v1/transport/taxi-availability?date_time=" + jcon;
                xhr.open("GET", url, true);
                xhr.setRequestHeader("Content-Type", "application/json");
                xhr.onreadystatechange = function () {
                    if (xhr.readyState === 4 && xhr.status === 200) {
                        var json = JSON.parse(xhr.responseText);
                        //console.log(json);

                        var userlong = 103.8489;
                        var userlat = 1.3800;

                        document.getElementById("yourlocation").innerHTML = "Your location: <br /> 180 Ang Mo Kio Avenue 8, Singapore 569830 <br />" + "Lng: " + userlong + " Lat: " + userlat;
                        var lon = userlong + 0.02;
                        var lonn = userlong - 0.02;

                        var lat = userlat + 0.02;
                        var latt = userlat - 0.02;

                        var geometry = json["features"]["0"]["geometry"]["coordinates"];
                        //console.log(geometry);

                        var txt = "<table border='1' cellpadding='10' style='width:100%; font-size: 20px;'>";
                        for (var i = 0; i < geometry.length; i++) {
                            txt += "<tr>";
                            for (var j = 0; j < geometry[i].length; j++) {
                                txt += "<td>" + geometry[i][j] + "</td>";
                            }
                            txt += "</tr>";
                        }
                        txt += "</table>"
                        document.getElementById("demo").innerHTML = txt;

                        var properties = json["features"]["0"]["properties"]
                        console.log(properties);

                        var taxiCount = json["features"]["0"]["properties"]["taxi_count"];
                        document.getElementById("avail").innerHTML = taxiCount;
                    }
                }
                xhr.send();
            </script>
            <div class="col-md-4" style="height: 400px; overflow: auto;">
                <div id="demo"></div>
            </div>
        </div>
    </form>
</asp:Content>
