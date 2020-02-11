<%@ Page Title="" Language="C#" MasterPageFile="~/SignedIn.master" AutoEventWireup="true" CodeBehind="ViewEventDetails.aspx.cs" Inherits="MyCircles.Events.ViewEventDetails" %>
<%@ Import Namespace="MyCircles.BLL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SignedInHeadPlaceholder" runat="server">
    <style>
        @media (min-width: 1200px) {
    .container{
        max-width: 970px;
    }
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SignedInContentPlaceholder" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-12 mt-3">
                <div class="card card-body">
                    <div class="row">
                        <div class="col-12">
                             <!--insert event Title to the span-->
                           <!-- <span></span> -->
                            <%=singleEventDetails.eventName %>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-12">
                            <i class="fas fa-filter"></i>
                            <!--insert event location to the span-->
                            <span> <%=singleEventDetails.eventLocation %></span> 
                        </div>
                    </div>
                  
                    <div class="row">
                        <div class="col-12">
                            <span>Description</span>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-12">
                            <p><%=singleEventDetails.eventDescription %></p>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-12">
                            <div class="card card-body" style="padding-bottom: 0px;padding-top: 14px;">

                                    <span>Event schedule</span>

                                     <table class="table table-bordered">
                                        <thead>
                                          <tr>
                                            <th>Start</th>
                                            <th>End</th>
                                            <th>Event</th>
                                          </tr>
                                        </thead>
                                        <tbody>
                                     <asp:Repeater ID="rpEventSchedule" runat="server" ItemType="MyCircles.BLL.EventSchedule">
                                         <ItemTemplate>                                                                     
                                          <tr>
                                            <td><%#DataBinder.Eval(Container.DataItem, "startTime") %></td>
                                            <td><%#DataBinder.Eval(Container.DataItem, "endTime") %></td>
                                            <td><%#DataBinder.Eval(Container.DataItem, "eventDescription") %></td>
                                          </tr>
                                         </ItemTemplate>
                                       </asp:Repeater>
                                        </tbody>
                                      </table>

                            </div>
                        </div>
                    </div>
                    
                    <div class="row">
                        <div class="col-12">
                            <div class="card card-body mt-3">
                                <div class="row">
                                    <div class="col-sm-6 col-md-12 col-lg-4">
							            <p class="font-italic">Timings</p>
							            <p class="text-info"><%=singleEventDetails.eventStartTime %> - <%=singleEventDetails.eventEndTime %></p>
						            </div>

                                    <div class="col-sm-6 col-md-12 col-lg-4">
							            <p class="font-italic">Entry Fees</p>
							            <p class="text-info"><%=singleEventDetails.eventEntryFeesStatus %></p>
						            </div>

						            <div class="col-sm-6 col-md-12 col-lg-4">
							            <p class="font-italic">Category Type</p>
							            <p class="text-info"><%=singleEventDetails.eventCategory %></p>
						            </div>

						            <div class="col-sm-6 col-md-12 col-lg-4">
							            <p class="font-italic">Date </p>
							            <p class="text-info"><%=singleEventDetails.eventStartDate %> - <%=singleEventDetails.eventEndDate %></p>
						            </div>

                                    <div class="col-sm-6 col-md-12 col-lg-4">
                                        <p class="font-italic">Avaliable Slots </p>
                                        <%if (totalAvaliableSlots == 0) { %>
                                            <p class="text-info"><%=avaliableSlotsText %></p>
                                        <%} %>     
                                        
                                        <%else { %>
                                             <p class="text-info"><%=totalAvaliableSlots %></p>
                                        <%} %>
                                    </div>

                                    <div class="col-sm-6 col-md-12 col-lg-4">
                                        <p class="font-italic">Organizer</p>
							            <p class="text-info"><%=singleEventDetails.eventHolderName %></p>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-6" style="padding-right: 0px;">
                                        <a class="btn btn-danger" style="width:100%;">Contact Organizer</a>
                                    </div>
                                    <div class="col-6" style="padding-left:0px;">
                                        <!--data-toggle="modal" data-target=".bd-example-modal-lg"-->
                                         <a href="/Events/SignUpFreeEventPage.aspx?eventID=<%=singleEventDetails.eventId %>" class="btn btn-primary"  style="width:100%;">Register</a>

                                        <!--sign up page modal-->
                                        <!--
                                        <div class="modal fade bd-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
                                          <div class="modal-dialog modal-lg">
                                            <div class="modal-content">
                                              <div class="modal-header">
                                                  <h4 class="modal-title" id="FreeSignUpEventTitle">Event</h4>
                                                  <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                      <span aria-hidden="true">×</span>
                                                  </button>
                                              </div>
                                              <div class="modal-body">
                                                  <div class="container-fluid">
                                                        <div class="row">
                                                            <div class="col-12">
                                                                <p>Ticket Title</p>
                                                                <p>Ticket Price Information</p>
                                                                <p>Sales end in a day</p>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-12">
                                                            <div class="form-group">
                                                                <label for="ticketQuantity">Select Amount of Ticket</label>
                                                                <select class="form-control" id="ticketQuantity">
                                                                        <option>1</option>
                                                                        <option>2</option>
                                                                        <option>3</option>
                                                                        <option>4</option>
                                                                </select>
                                                            </div>
                                                            </div>
                                                        </div>
                                                      </div>
                                                  </div>

                                            </div>
                                          </div>
                                        </div>
                                        -->
                                        <!--end of modal signup page-->
                                    </div>

                                </div>

                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SignedInDeferredScriptsPlaceholder" runat="server">
</asp:Content>
