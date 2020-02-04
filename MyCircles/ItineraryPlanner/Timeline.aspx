<%@ Page MasterPageFile="Header.master" AutoEventWireup="true" CodeBehind="Timeline.aspx.cs" Inherits="MyCircles.ItineraryPlanner.Timeline" Title="Timeline" %>

<asp:Content ContentPlaceHolderID="BodyContentPlaceHolder" runat="server">
    <link href="http://maxcdn.bootstrapcdn.com/font-awesome/4.1.0/css/font-awesome.min.css" rel="stylesheet">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script>
        $(document).ready(function () {
            // Add smooth scrolling to all links
            $("a").on('click', function (event) {

                // Make sure this.hash has a value before overriding default behavior
                if (this.hash !== "") {
                    // Prevent default anchor click behavior
                    event.preventDefault();

                    // Store hash
                    var hash = this.hash;

                    // Using jQuery's animate() method to add smooth page scroll
                    // The optional number (800) specifies the number of milliseconds it takes to scroll to the specified area
                    $('html, body').animate({
                        scrollTop: $(hash).offset().top
                    }, 800, function () {

                        // Add hash (#) to URL when done scrolling (default click behavior)
                        window.location.hash = hash;
                    });
                } // End if
            });
        });
    </script>
    <form id="form1" runat="server">
        <div class="row d-flex justify-content-center mt-5">
            <%-- need insert title of Plan if possible--%>
            <h2>
                <asp:Label ID="lbPlannerName" runat="server" Text="January Outing"></asp:Label></h2>
        </div>
        <%--  <asp:Repeater ID="rpDates" runat="server" ItemType="MyCircles.BLL.DayByDay">
            <ItemTemplate>--%>
        <div class="row mt-3">
            <div class="col-md-1"></div>
            <div class="col-md-1">
                <h2>
                    <asp:Label ID="lbMonth" runat="server" Text="Label"></asp:Label></h2>
                <%--<input id="noOfDate" runat="server" ClientIdMode="Static"/>--%>
                <ul class="nav flex-column">
                    <li class="nav-item">
                        <a id="aStartDate" class="nav-link active" href="#" runat="server"></a>
                    </li>

                    <li class="nav-item">
                        <a id="aEndDate" class="nav-link" href="#" runat="server"></a>
                    </li>
                </ul>
                <asp:Repeater ID="rpDates" runat="server" ItemType="MyCircles.BLL.DayByDay">
                    <ItemTemplate>
                        <h5 class="mb-3"><%#DataBinder.Eval(Container.DataItem, "date") %></h5>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="col-md-8 border border-primary">
                <asp:Repeater ID="rpLocation" runat="server" ItemType="MyCircles.BLL.Location">
                    <ItemTemplate>
                        <div class="row border border-primary mb-3">
                            <div id="btn" style="color: white; background-color: grey; border-radius: 25px;">30 Jan, Thu</div>
                            <div class="row pt-3 pl-3">
                                <div class="col-md-1 mr-5 col-sm-1">
                                    <h6>Opening Hours </h6>
                                    <br />
                                    <h6><%#DataBinder.Eval(Container.DataItem, "locaOpenHour") %></h6>
                                    <br />
                                    <h6><%#DataBinder.Eval(Container.DataItem, "locaCloseHour") %></h6>
                                </div>
                                <div class="col-md-4 col-sm-12">
                                    <asp:Image runat='server' Height='160px' Width='250px' ImageUrl='<%#DataBinder.Eval(Container.DataItem, "locaPic") %>' />
                                </div>
                                <div class="col-md-5 col-sm-12 nopadding">
                                    <div class="row">
                                        <div class="col-md-8">
                                            <h4 style="height: 28px; overflow: hidden; text-overflow: ellipsis;"><%#DataBinder.Eval(Container.DataItem, "locaName") %></h4>
                                        </div>
                                        <div class="col-md-4">
                                            <h6><%#DataBinder.Eval(Container.DataItem, "locaRating") %> stars</h6>
                                        </div>
                                    </div>
                                    <div class="row" style="height: 150px;">
                                        <p style="height: 120px; overflow: auto; text-overflow: ellipsis;"><%#DataBinder.Eval(Container.DataItem, "locaDesc") %></p>
                                    </div>
                                </div>
                                <div class="col-md-1 col-sm-12 d-flex flex-row-reverse">
                                    <h6><%#DataBinder.Eval(Container.DataItem, "landmarkType") %></h6>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="col-md-1">
                <a href="RequestFund.aspx" class="text-decoration-none">Request Fund<i class="fas fa-headset"></i></a>
            </div>
            <div class="col-md-1"></div>
        </div>
        <%--            </ItemTemplate>
        </asp:Repeater>--%>
    </form>
    <%--<script>
        var dayStr1 = '<%= dayStr1 %>';
        var singleDate = dayStr1.split(",");
        singleDate.reverse();
        console.log(dayStr1);
        console.log(singleDate);

        for (var i = 0; i < singleDate.length; i++) {
            var d1 = document.getElementById("BaseContentPlaceholder_SignedInContentPlaceholder_BodyContentPlaceHolder_aStartDate");
            d1.insertAdjacentHTML('afterend', '<a id="amDate" class="nav-link" href="#" runat="server">' + singleDate[i] + '</a>');
        }

    </script>--%>
</asp:Content>
