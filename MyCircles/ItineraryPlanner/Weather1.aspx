<%@ Page MasterPageFile="/SignedIn.master" AutoEventWireup="true" CodeBehind="Weather1.aspx.cs" Inherits="MyCircles.ItineraryPlanner.Weather1" %>

<asp:Content ContentPlaceHolderID="SignedInContentPlaceholder" runat="server">
    <form id="form1" runat="server">
        <div class="container">
            <div class="row mt-4">
                <div class="col-md-2"></div>
                <div class="col-md-8 d-flex justify-content-center">
                    <h2>Weather Report</h2>
                </div>
                <div class="col-md-2">
                    <a href="Weather2.aspx" onclick="changeView()">2-hour Region Forecast</a>
                </div>
            </div>
            <div class="row mt-3">
                <div class="col-md-1"></div>
                <div class="col-md-10 d-flex justify-content-center">
                    <div id="cardone" class="col-md-4 p-5 mr-3" style="background-color:#bed73b; height: 300px;">
                        <div class="row"><h5>24-hour weather</h5></div>
                        <div class="row"><h5>forecast</h5></div>
                        <div class="row"><p id="forecast" style="font-size: 25px;">Windy</p></div>
                        <div class="row"><p id="temperature" style="font-size:40px;">23 - 31 C</p></div>
                        <div class="row">
                            <p id="wind" class="pr-3">N 15 - 30 km/h</p>
                            <%--<p>60 - 95%</p>--%>
                        </div>
                    </div>
                    <div id="cardtwo" class="col-md-6 p-5 mr-3" style="background-color:#bed73b; height: 300px;">
                        <div class="row"><h5>3-hour Outlook</h5></div>
                        <div class="row mt-2">
                            <div class="col-md-6">
                                <div class="row"><h6>Central</h6></div>
                                <div class="row">
                                    <p id="central" style="font-size: 18px;">Windy</p>
                                </div>
                                <div class="row"><h6>East</h6></div>
                                <div class="row">
                                    <p id="east" style="font-size: 18px;">Windy</p>
                                </div>
                                <div class="row"><h6>North</h6></div>
                                <div class="row">
                                    <p id="north" style="font-size: 18px;">Windy</p>
                                </div>
                            </div>
                           <div class="col-md-6">
                               <div class="row"><h6>South</h6></div>
                               <div class="row">
                                    <p id="south" style="font-size: 18px;">Windy</p>
                               </div>
                               <div class="row"><h6>West</h6></div>
                               <div class="row">
                                    <p id="west" style="font-size: 18px;">Windy</p>
                               </div>
                           </div>
                        </div>
                    </div>
                    <div class="col-md-2"></div>
                </div>
                <div class="col-md-1"></div>
            </div>
        </div>
        <script>
            var xhr = new XMLHttpRequest();
            var url = "https://api.data.gov.sg/v1/environment/24-hour-weather-forecast?date" + "2020-02-10";
            xhr.open("GET", url, true);
            xhr.setRequestHeader("Content-Type", "application/json");
            xhr.onreadystatechange = function () {
                if (xhr.readyState === 4 && xhr.status === 200) {
                    var json = JSON.parse(xhr.responseText);
                    //console.log(json);

                    //var items0 = json["items"]["0"];
                    //console.log(items0);

                    var items0g = json["items"]["0"]["general"];
                    //console.log(items0g);

                    document.getElementById("forecast").innerHTML = items0g["forecast"];
                    document.getElementById("temperature").innerHTML = items0g["temperature"]["low"] + " - " + items0g["temperature"]["high"] + "°C";
                    document.getElementById("wind").innerHTML = items0g["wind"]["direction"] + " " + items0g["wind"]["speed"]["low"] + " - " + items0g["wind"]["speed"]["high"] + " km/h";


                    var items0p = json["items"]["0"]["periods"];
                    //console.log(items0p);

                    document.getElementById("central").innerHTML = items0p["0"]["regions"]["central"];
                    document.getElementById("east").innerHTML = items0p["0"]["regions"]["east"];
                    document.getElementById("north").innerHTML = items0p["0"]["regions"]["north"];
                    document.getElementById("south").innerHTML = items0p["0"]["regions"]["south"];
                    document.getElementById("west").innerHTML = items0p["0"]["regions"]["west"];

                    //var items0v = json["items"]["0"]["valid_period"];
                    //console.log(items0v);
                }
            };
            xhr.send();
        </script>
    </form>
</asp:Content>

