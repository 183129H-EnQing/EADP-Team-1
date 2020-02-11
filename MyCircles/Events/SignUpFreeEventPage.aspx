<%@ Page Title="" Language="C#" MasterPageFile="~/SignedIn.master" AutoEventWireup="true" CodeBehind="SignUpFreeEventPage.aspx.cs" Inherits="MyCircles.Events.SignUpFreeEventPage" %>

<%@ Import Namespace="MyCircles.BLL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SignedInHeadPlaceholder" runat="server">
 <%--      <link rel="stylesheet" href="/Content/timetable.js-master/dist/styles/timetablejs.css">--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SignedInContentPlaceholder" runat="server">
    <div class="container mt-3">
        <div class="card card-body">
            <h4 class="text-primary">Registeration</h4>
            <div class="card card-body">
                <form runat="server">
                    <div class="form-group">
                        <label id="NameLB">Name</label>
                        <asp:TextBox type="text" class="form-control" ID="nameTB" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">

                        <label>Date</label>
                        <asp:DropDownList ID="dateDDL" runat="server" class="form-control">
                        </asp:DropDownList>

                    </div>
                    <div class="form-group">
                        <label for="inputContactNumber">ContactNumber</label>
                        <asp:TextBox type="text" class="form-control" ID="contactNumberTB" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="inputNumberOfBookingSlots">Number of Booking slots</label>

                         <% if(singleEventDetails.maxTimeAPersonCanRegister == "No Limit"){  %>
                                <asp:TextBox type="Number" ID="NumberOfBookingSlotsTB" runat="server" class="form-control" ClientIDMode="Static"  onchange="getBookingSlotsAmountTB(this)"></asp:TextBox>
                        <%} %>
                        <% else{ %>
                          <asp:DropDownList ID="NumberOfBookingSlotsDLL" class="form-control" runat="server" ClientIDMode="Static" onchange="getBookingSlotsAmountDDL(this)">

                          </asp:DropDownList>
                        <%}%>
                      
                    </div>
                    <div class="row">
                        <div class="col-12">
                            <label>Total Cost</label>

                        </div>
                    </div>

                    <div class="row">
                        <div class="col-12">
                              <label id="TotalCost"></label>
                        </div>
                    </div>

                                          

                    <table class="table table-bordered">
                        <thead>
                            <tr>
                                <th class="w-25">Time</th>
                                <th class="w-50">Description</th>
                                <th class="w-25">Opt in</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rpEventSchedule" runat="server" ItemType="MyCircles.BLL.EventSchedule">
                                <ItemTemplate>
                                  
                                    <tr>
                                        <td><%#DataBinder.Eval(Container.DataItem, "startTime") %> - <%#DataBinder.Eval(Container.DataItem, "endTime") %></td>
                                        <td>
                                            <asp:Label ID="eventDescription" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "eventDescription") %>'> </asp:Label>
                                        </td>
                                        <td><asp:CheckBox ID="optInCB" runat="server" /></td>
                                        <td style="display: none;">
                                              <asp:Label ID="secretEventSheduleId" runat="server" style="display: none;" Text='<%#DataBinder.Eval(Container.DataItem, "eventScheduleId") %>'> </asp:Label>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>

                      <div id="signedOutErrorContainer" class="signedOutErrorContainer col-md-12 my-4 p-0" runat="server" visible="false">
                            <div class="signedOutErrorBlock">
                                <i class="fas fa-exclamation-triangle"></i>&nbsp;
                            <asp:Label ID="lbErrorMsg" runat="server">
                                <asp:ValidationSummary ID="vsAddCircles" runat="server" ShowSummary="false" DisplayMode="List" ValidationGroup="registerEvent" />
                            </asp:Label>
                            </div>
                        </div>
                    <asp:Button ID="submitButt" runat="server" Text="Submit" ClientIDMode="Static" CssClass="form-check-label btn btn-success btn-block mt-2" OnClick="submitButt_Click" />
                </form>
                  
            </div>
        </div>
    </div>

<%--     <div class="timetable"></div>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SignedInDeferredScriptsPlaceholder" runat="server">
    <script>
        var retrieveTicketPrice = '<%=singleEventDetails.eventTicketCost %>';
        var ticketPrice = retrieveTicketPrice.slice(1);

        function getBookingSlotsAmountTB() {        
            var numberOfBookingSlotTB = document.getElementById("NumberOfBookingSlotsTB").value;
          

            console.log(ticketPrice);
            console.log(numberOfBookingSlotTB);
           document.getElementById("TotalCost").innerText = ticketPrice * numberOfBookingSlotTB;
        }
        function getBookingSlotsAmountDDL() {
            var numberOfBookingSlotDDL = document.getElementById("NumberOfBookingSlotsDLL").value;
              document.getElementById("TotalCost").innerText = ticketPrice * numberOfBookingSlotDDL;
        }
    </script>
<%--    <script src="/Content/timetable.js-master/dist/scripts/timetable.js"></script>
    <script>
        var x = '<%=testing %>';
        document.getElementById("NameLB").innerText = x;



        var timetable = new Timetable();

        timetable.setScope(8, 20)


        timetable.addLocations([x]);

        timetable.addEvent('Singapore Zoo', '17 Jan', new Date(2019, 1, 17, 9, 00), new Date(2019, 1, 17, 12, 30), { url: '#' });
        timetable.addEvent('Siloso Beach', '17 Jan', new Date(2019, 1, 17, 13, 15), new Date(2019, 1, 17, 17, 30), { url: '#' });

        var renderer = new Timetable.Renderer(timetable);
        renderer.draw('.timetable');

    </script>--%>


</asp:Content>
