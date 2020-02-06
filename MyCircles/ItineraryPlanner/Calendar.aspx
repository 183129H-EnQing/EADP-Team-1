<%@ Page MasterPageFile="Header.master" AutoEventWireup="true" CodeBehind="Calendar.aspx.cs" Inherits="MyCircles.ItineraryPlanner.Calendar" Title="Calendar" %>

<asp:Content ContentPlaceHolderID="BodyContentPlaceHolder" runat="server">
    <!doctype html>
    <html>
    <head>
        <meta charset="utf-8">
        <meta name="description" content="Vanilla javascript plugin for building nice responsive timetables">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <link rel="stylesheet" href="/Content/timetable.js-master/dist/styles/timetablejs.css">
        <link rel="stylesheet" href="/Content/timetable.js-master/dist/styles/demo.css">
    </head>

    <body>
        <div class="row mt-5 sticky-top bg-warning mb-5">
            <div class="col-md-1"></div>
            <div class="col-md-1"></div>
            <div class="col-md-8">
                <div class="row d-flex justify-content-center">
                    <%-- need insert title of Plan if possible--%>
                    <h2>
                        <asp:Label ID="lbPlannerName" runat="server" Text="January Outing"></asp:Label></h2>
                </div>
            </div>
            <div class="col-md-1">
                <a href="RequestFund.aspx" class="text-decoration-none">Request Fund<i class="fas fa-headset"></i></a>
            </div>
            <div class="col-md-1"></div>
        </div>
        <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-10">
            <asp:Label ID="lbDate" runat="server" ></asp:Label> <br />
            <asp:Label ID="lbLocation" runat="server" ></asp:Label>
                <div class="row d-flex justify-content-center">
                    <%--<div class="hero-unit">
                        <h1>Timetable.js demo</h1>
                        <p>Vanilla javascript plugin for building nice responsive timetables. More info on <a href="https://github.com/Grible/timetable.js" target="_blank">Github</a>.</p>
                    </div>--%>

                    <div class="timetable"></div>

                    <script src="/Content/timetable.js-master/dist/scripts/timetable.js"></script>
                    <script>
                        var timetable = new Timetable();

                        timetable.setScope(8, 20);
                        //timetable.addLocations(['17 Jan', '18 Jan', '19 Jan', '20 Jan']);
                        //var myday = @hello;
                        //alert("FIRE" + myday);
                        //timetable.addLocations([myday]);
                        var hi = document.getElementById('<%=lbLocation.ClientID%>').innerText;
                        //[ "Singapore Zoo ,05 Feb,1000,1600", "Buddha Tooth Relic Temple and Museum ,05 Feb,1630,1700", "" ]
                        console.log("hi: "+ hi)
                        var places = hi.split("|")  //split into individial places with details
                        //[ "Singapore Zoo ", "05 Feb", "1000", "1600" ]
                        console.log(places);


                        var fulldate;
                        for (var i = 0; i < places.length; i++) {
                            if (places.length > 1) {
                                console.log("places>1");
                                console.log(places[i])
                                var dates = places[i].split(",");
                                console.log("datesssss");
                                console.log(dates);


                                if (fulldate == dates[1]) {
                                    console.log("if");
                                    console.log(dates[1]);

                                    fulldate = dates[1];
                                    console.log("ifff -- fulldate");
                                    console.log(fulldate);
                                }
                                else {
                                    

                                    fulldate = dates[1];
                                    console.log("else");
                                    console.log(dates[1]);

                                    timetable.addLocations([dates[1]]);
                                }

                                var date = fulldate.substring(0, 2);

                                var startT1Hour = dates[2].substring(0, 2);
                                var startT2Min = dates[2].substring(2);

                                var endT1Hour = dates[3].substring(0, 2);
                                var endT2Min = dates[3].substring(2);

                                console.log(dates[0], fulldate, new Date(2020, 2, date, startT1Hour, startT2Min), new Date(2020, 2, date, endT1Hour, endT2Min))

                                timetable.addEvent(dates[0], fulldate, new Date(2020, 2, date, startT1Hour, startT2Min), new Date(2020, 2, date, endT1Hour, endT2Min), { url: '#' });
                                console.log("//////////////////");
                            }

                            var renderer = new Timetable.Renderer(timetable);
                            renderer.draw('.timetable');
                        }
                        
                        //timetable.addEvent('Buddha Tooth Relic Temple', '05 Feb', new Date(2020, 2, 5, 14, 00), new Date(2020, 2, 5, 15, 00), { url: '#' });

                        //var renderer = new Timetable.Renderer(timetable);
                        //renderer.draw('.timetable');
                    </script>
                </div>
            </div>
            <div class="col-md-1"></div>
        </div>

        <%--<script>
            var timetable = new Timetable();

            timetable.setScope(9, 3)

            timetable.addLocations(['Rotterdam', 'Madrid', 'Los Angeles', 'London', 'New York', 'Jakarta', 'Tokyo']);

            timetable.addEvent('Sightseeing', 'Rotterdam', new Date(2015, 7, 17, 9, 00), new Date(2015, 7, 17, 11, 30), { url: '#' });
            timetable.addEvent('Zumba', 'Madrid', new Date(2015, 7, 17, 12), new Date(2015, 7, 17, 13), { url: '#' });
            timetable.addEvent('Zumbu', 'Madrid', new Date(2015, 7, 17, 13, 30), new Date(2015, 7, 17, 15), { url: '#' });
            timetable.addEvent('Lasergaming', 'London', new Date(2015, 7, 17, 17, 45), new Date(2015, 7, 17, 19, 30), { class: 'vip-only', data: { maxPlayers: 14, gameType: 'Capture the flag' } });
            timetable.addEvent('All-you-can-eat grill', 'New York', new Date(2015, 7, 17, 21), new Date(2015, 7, 18, 1, 30), { url: '#' });
            timetable.addEvent('Hackathon', 'Tokyo', new Date(2015, 7, 17, 11, 30), new Date(2015, 7, 17, 20)); // options attribute is not used for this event
            timetable.addEvent('Tokyo Hackathon Livestream', 'Los Angeles', new Date(2015, 7, 17, 12, 30), new Date(2015, 7, 17, 16, 15)); // options attribute is not used for this event
            timetable.addEvent('Lunch', 'Jakarta', new Date(2015, 7, 17, 9, 30), new Date(2015, 7, 17, 11, 45), {
                onClick: function (event) {
                    window.alert('You clicked on the ' + event.name + ' event in ' + event.location + '. This is an example of a click handler');
                }
            });
            timetable.addEvent('Cocktails', 'Rotterdam', new Date(2015, 7, 18, 00, 00), new Date(2015, 7, 18, 02, 00), { class: 'vip-only' });

                    var renderer = new Timetable.Renderer(timetable);
            renderer.draw('.timetable');
        </script>--%>
    </body>
    </html>
</asp:Content>
