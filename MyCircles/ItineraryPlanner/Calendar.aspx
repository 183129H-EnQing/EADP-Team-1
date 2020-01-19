<%@ Page MasterPageFile="Header.master" AutoEventWireup="true" CodeBehind="Calendar.aspx.cs" Inherits="MyCircles.ItineraryPlanner.Calendar" %>

<asp:Content ContentPlaceHolderID="BodyContentPlaceHolder" runat="server">
    <link rel="stylesheet" href="/Content/timetable.js-master/dist/styles/timetablejs.css">
    <script src="/Content/timetable.js-master/dist/scripts/timetable.min.js"></script>
    <form id="form1" runat="server">
        <h1>hello calendar</h1>
        <div class="timetable"></div>
    </form>
    <script>
        var timetable = new Timetable();
        timetable.setScope(9, 17); // optional, only whole hours between 0 and 23

        timetable.addLocations(['Silent Disco', 'Nile', 'Len Room', 'Maas Room']);
        timetable.addEvent('Frankadelic', 'Nile', new Date(2015, 7, 17, 10, 45), new Date(2015, 7, 17, 12, 30));

        var renderer = new Timetable.Renderer(timetable);
        renderer.draw('.timetable'); // any css selector
    </script>
</asp:Content>
