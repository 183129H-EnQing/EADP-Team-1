<%@ Page MasterPageFile="Header.Master" AutoEventWireup="true" CodeBehind="Weather.aspx.cs" Inherits="MyCircles.ItineraryPlanner.Weather" Title="Weather" %>

<asp:Content ContentPlaceHolderID="BodyContentPlaceHolder" runat="server">
    <style>
        #demo {
            display: none;
        }
    </style>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row mt-4">
                <div class="col-md-2"></div>
                <div class="col-md-8 d-flex justify-content-center">
                    <h2>Weather Report</h2>
                </div>
                <div class="col-md-1"></div>
                <div class="col-md-1">
                    <button onclick="changeView()">Change View</button>
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
            <div class="row mt-5">
                <div class="col-md-1"></div>
                <div class="col-md-10" style="height: 300px; overflow: auto;">
                    <div id="demo"></div>
                </div>
                <div class="col-md-1"></div>
            </div>
        </div>
        <script>
            window.onload = threehour();

            function changeView() {
                var cardone = document.getElementById("cardone");
                var cardtwo = document.getElementById("cardtwo");
                var demo = document.getElementById("demo");

                if (demo.style.display == "none") {
                    cardone.style.display = "none";
                    cardtwo.style.display = "none";
                    demo.style.display = "block";
                    twohour();
                }
                else {
                    cardone.style.display = "block";
                    cardtwo.style.display = "block";
                    demo.style.display = "none";
                    threehour();
                }
            }

            function threehour(){
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
            }

            function twohour(){
                var xhr = new XMLHttpRequest();
                var url = "https://api.data.gov.sg/v1/environment/2-hour-weather-forecast?date=" + "2020-02-10";
                //var url = "https://api.data.gov.sg/v1/environment/4-day-weather-forecast?date=" + "2020-02-10";
                xhr.open("GET", url, true);
                xhr.setRequestHeader("Content-Type", "application/json");
                xhr.onreadystatechange = function () {
                    if (xhr.readyState === 4 && xhr.status === 200) {
                        var json = JSON.parse(xhr.responseText);
                        //console.log(json);

                        console.log(json["items"])

                        var items = json["items"];
                        //console.log(items["0"]["timestamp"])
                        var txt = "<table border='1' cellpadding='10' style='width:100%; font-size: 20px;'>";
                        for (var i = 0; i < items.length; i++) {
                            txt += "<tr><td colspan='2'> Date: " + items[i]["valid_period"]["start"].substring(5, 10) + " | Time: " + items[i]["valid_period"]["start"].substring(11, 16) + " - " + items[i]["valid_period"]["end"].substring(11, 16) + "</td></tr>";

                            for (var j = 0; j < items[i]["forecasts"].length; j++) {
                                txt += "<tr><td>" + items[i]["forecasts"][j]["area"] + "</td><td>" + items[i]["forecasts"][j]["forecast"] + "</td></tr>";
                            }

                        }
                        txt += "</table>"
                        document.getElementById("demo").innerHTML = txt;
                    }
                };
                xhr.send();
            }
        </script>
    </form>
</asp:Content>
