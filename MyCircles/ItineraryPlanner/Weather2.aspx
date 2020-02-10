<%@ Page MasterPageFile="~/SignedIn.master" AutoEventWireup="true" CodeBehind="Weather2.aspx.cs" Inherits="MyCircles.ItineraryPlanner.Weather2" Title="2 Hour - Weather"%>

<asp:Content ContentPlaceHolderID="SignedInContentPlaceholder" runat="server">
    <form id="form1" runat="server">
        <div class="container">
            <div class="row mt-4">
                <div class="col-md-2"></div>
                <div class="col-md-8 d-flex justify-content-center">
                    <h2>2 Hour Weather Report</h2>
                    <i class="fas fa-wind"></i>
                </div>
                <div class="col-md-2">
                    <a href="Weather1.aspx">24-hour Forecast</a>
                </div>
                </div>
            </div>
            <div class="row mt-4 mb-4">
                <div class="col-md-1"></div>
                <div class="col-md-6 mr-3 d-flex justify-content-center">
                    <iframe width="100%;" height="400" src="https://data.gov.sg/dataset/weather-forecast/resource/571ef5fb-ed31-48b2-85c9-61677de42ca9/view/4c127d9a-cba6-445a-8fc1-978b565f9bf7" frameBorder="0"> </iframe> 
                </div>
                <div class="col-md-4" style="height: 400px; overflow: auto;">
                    <div id="demo"></div>
                </div>
            <div class="row mt-3">
                <div class="col-md-1"></div>
                <div class="col-md-10" >
                    
                </div>
                <div class="col-md-1"></div>
            </div>
        </div>
        <script>
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
                        txt += "<tr bgcolor='orange' style='color: white;'><td colspan='2'> Date: " + items[i]["valid_period"]["start"].substring(5, 10) + " | Time: " + items[i]["valid_period"]["start"].substring(11, 16) + " - " + items[i]["valid_period"]["end"].substring(11, 16) + "</td></tr>";

                        for (var j = 0; j < items[i]["forecasts"].length; j++) {
                            txt += "<tbody><tr><td>" + items[i]["forecasts"][j]["area"] + "</td><td>" + items[i]["forecasts"][j]["forecast"] + "</td></tr></tbody>";
                        }

                    }
                    txt += "</table>"
                    document.getElementById("demo").innerHTML = txt;
                }
            };
            xhr.send();
            
            $(function(){
                $("tbody").each(function(elem,index){
                    var arr = $.makeArray($("tr",this).detach());
                    arr.reverse();
                    $(this).append(arr);
                });
            });
        </script>
    </form>
</asp:Content>