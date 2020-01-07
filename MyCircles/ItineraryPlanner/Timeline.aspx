<%@ Page MasterPageFile="Header.master" AutoEventWireup="true" CodeBehind="Timeline.aspx.cs" Inherits="MyCircles.ItineraryPlanner.Timeline" Title="Timeline" %>

<asp:Content ContentPlaceHolderId="BodyContentPlaceHolder" runat="server">
    <script>
        var middleDates = document.getElementById("<%=noOfDate%>").value;
        var dateArray = middleDates.split(",");
    </script>

    <form id="form1" runat="server">
        <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-1">
                <asp:Label ID="lbMonth" runat="server" Text="Label"></asp:Label> <br />
                <h2>11</h2>  <br />
                <input id="noOfDate" runat="server"/>
                <ul class="nav flex-column">
                    <li class="nav-item">
                        <a id="aStartDate" class="nav-link active" href="#" runat="server"></a>
                    </li>
                    {{#foreach dateArray}}
                        <li class="nav-item">
                            <a class="nav-link" href="#" runat="server">{{ . }}</a>
                        </li>
                    {{/foreach}}
                    <li class="nav-item">
                        <a id="aEndDate" class="nav-link" href="#" runat="server"></a>
                    </li>
                </ul>
            </div>
            <div class="col-md-8 border border-primary">
                <div class="row pt-3">
                    <div class="col-md-2 mr-1">
                        <h4>10.00am</h4> <br />
                        <h4>12.00pm</h4>
                    </div>
                    <div class="col-md-3 mr-1">
                        image
                    </div>
                    <div class="col-md-5">
                        Appreciate the majesty of exotic and endangered animals at Singapore Zoo, home to the world's largest collection of orangutans housed
                    </div>
                </div>
            </div>
            <div class="col-md-1"></div>
            <div class="col-md-1"></div>
        </div>
    </form>
</asp:Content>
