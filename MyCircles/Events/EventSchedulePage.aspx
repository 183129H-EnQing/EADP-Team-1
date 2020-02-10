<%@ Page Title="" Language="C#" MasterPageFile="~/SignedIn.master" AutoEventWireup="true" CodeBehind="EventSchedulePage.aspx.cs" Inherits="MyCircles.Events.EventSchedulePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SignedInHeadPlaceholder" runat="server">
   <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/tempusdominus-bootstrap-4/5.0.0-alpha14/js/tempusdominus-bootstrap-4.min.js"></script>
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/tempusdominus-bootstrap-4/5.0.0-alpha14/css/tempusdominus-bootstrap-4.min.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SignedInContentPlaceholder" runat="server">
    <div class="container">
        <form runat="server">
            <div class="col-12">

                    <h4 class="text-primary mt-3">Event Schedule  </h4>
                    <div class="card card-body">
                        <div class="row">
                            <div class="col-6">
                                <label>Start Time</label>
                               <asp:DropDownList ID="startTimeDLL" runat="server" class="form-control">
                                                <asp:ListItem Value="0000" />
                                                <asp:ListItem Value="0030" />
                                                <asp:ListItem Value="0100" />
                                                <asp:ListItem Value="0130" />
                                                <asp:ListItem Value="0200" />
                                                <asp:ListItem Value="0230" />
                                                <asp:ListItem Value="0300" />
                                                <asp:ListItem Value="0330" />
                                                <asp:ListItem Value="0400" />
                                                <asp:ListItem Value="0430" />
                                                <asp:ListItem Value="0500" />
                                                <asp:ListItem Value="0530" />
                                                <asp:ListItem Value="0600" />
                                                <asp:ListItem Value="0630" />
                                                <asp:ListItem Value="0700" />  
                                                <asp:ListItem Value="0730" />
                                                <asp:ListItem Value="0800" />
                                                <asp:ListItem Value="0830" />
                                                <asp:ListItem Value="0900" />
                                                <asp:ListItem Value="0930" />
                                                <asp:ListItem Value="1000" />
                                                <asp:ListItem Value="1030" />
                                                <asp:ListItem Value="1100" />
                                                <asp:ListItem Value="1130" />
                                                <asp:ListItem Value="1200" />
                                                <asp:ListItem Value="1230" />
                                                <asp:ListItem Value="1300" />
                                                <asp:ListItem Value="1300" />
                                                <asp:ListItem Value="1400" />
                                                <asp:ListItem Value="1430" />
                                                <asp:ListItem Value="1500" />
                                                <asp:ListItem Value="1530" />
                                                <asp:ListItem Value="1600" />
                                                <asp:ListItem Value="1630" />
                                                <asp:ListItem Value="1700" />
                                                <asp:ListItem Value="1730" />
                                                <asp:ListItem Value="1800" />
                                                <asp:ListItem Value="1830" />
                                                <asp:ListItem Value="1900" />
                                                <asp:ListItem Value="1930" />
                                                <asp:ListItem Value="2000" />
                                                <asp:ListItem Value="2030" />
                                                <asp:ListItem Value="2100" />   
                                                <asp:ListItem Value="2130" /> 
                                                <asp:ListItem Value="2200" /> 
                                                <asp:ListItem Value="2230" /> 
                                                <asp:ListItem Value="2300" /> 
                                                <asp:ListItem Value="2330" />
                                            </asp:DropDownList>
                            </div>
                            <div class="col-6">
                                <label>End Time</label>
                                <asp:DropDownList ID="endTimeDLL" runat="server" class="form-control">
                                                <asp:ListItem Value="0000" />
                                                <asp:ListItem Value="0030" />
                                                <asp:ListItem Value="0100" />
                                                <asp:ListItem Value="0130" />
                                                <asp:ListItem Value="0200" />
                                                <asp:ListItem Value="0230" />
                                                <asp:ListItem Value="0300" />
                                                <asp:ListItem Value="0330" />
                                                <asp:ListItem Value="0400" />
                                                <asp:ListItem Value="0430" />
                                                <asp:ListItem Value="0500" />
                                                <asp:ListItem Value="0530" />
                                                <asp:ListItem Value="0600" />
                                                <asp:ListItem Value="0630" />
                                                <asp:ListItem Value="0700" />  
                                                <asp:ListItem Value="0730" />
                                                <asp:ListItem Value="0800" />
                                                <asp:ListItem Value="0830" />
                                                <asp:ListItem Value="0900" />
                                                <asp:ListItem Value="0930" />
                                                <asp:ListItem Value="1000" />
                                                <asp:ListItem Value="1030" />
                                                <asp:ListItem Value="1100" />
                                                <asp:ListItem Value="1130" />
                                                <asp:ListItem Value="1200" />
                                                <asp:ListItem Value="1230" />
                                                <asp:ListItem Value="1300" />
                                                <asp:ListItem Value="1300" />
                                                <asp:ListItem Value="1400" />
                                                <asp:ListItem Value="1430" />
                                                <asp:ListItem Value="1500" />
                                                <asp:ListItem Value="1530" />
                                                <asp:ListItem Value="1600" />
                                                <asp:ListItem Value="1630" />
                                                <asp:ListItem Value="1700" />
                                                <asp:ListItem Value="1730" />
                                                <asp:ListItem Value="1800" />
                                                <asp:ListItem Value="1830" />
                                                <asp:ListItem Value="1900" />
                                                <asp:ListItem Value="1930" />
                                                <asp:ListItem Value="2000" />
                                                <asp:ListItem Value="2030" />
                                                <asp:ListItem Value="2100" />   
                                                <asp:ListItem Value="2130" /> 
                                                <asp:ListItem Value="2200" /> 
                                                <asp:ListItem Value="2230" /> 
                                                <asp:ListItem Value="2300" /> 
                                                <asp:ListItem Value="2330" />
                                            </asp:DropDownList>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-6 mt-2">
                                <label>Event Name</label>
                                <asp:TextBox type="text" class="form-control" ID="eventNameEventSchedule" runat="server" placeholder="Enter Your Event Name Here"></asp:TextBox>
                            </div>
                            <div class="col-6 mt-2">
                                <label>Event Description</label>
                                <asp:TextBox type="text" class="form-control" ID="eventDescriptionTBEventSchedule" runat="server" placeholder="Enter Your Event Description Here"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-6 mt-2">
                                <label>startDate</label>
                                 <div class="input-group date" id="datetimepickerStartDate" data-target-input="nearest">
                                        <asp:TextBox ID="startDateTB" type="text" class="form-control datetimepicker-input" data-target="#datetimepickerStartDate" runat="server"></asp:TextBox>
                                        <div class="input-group-append" data-target="#datetimepickerStartDate" data-toggle="datetimepicker">
                                        <div class="input-group-text"><i class="fa fa-calendar"></i></div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-6 mt-2">
                                <label>endDate</label>
                                 <div class="input-group date" id="datetimepickerEndDate" data-target-input="nearest">                                             
                                            <asp:TextBox ID="endDateTB" type="text" class="form-control datetimepicker-input" data-target="#datetimepickerEndDate" runat="server"></asp:TextBox>
                                        <div class="input-group-append" data-target="#datetimepickerEndDate" data-toggle="datetimepicker">
                                            <div class="input-group-text"><i class="fa fa-calendar"></i></div>
                                        </div>
                                    </div>
                            </div>
                        </div>
                        <div class="form-group">
                                   <asp:Button ID="submitButt" CssClass="form-check-label btn btn-success btn-block mt-4" runat="server" Text="Add" OnClick="submitButt_Click" />
                    </div>

            
            </div>
            </form>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SignedInDeferredScriptsPlaceholder" runat="server">
<script>
       $(function () {
                $('#datetimepickerStartDate').datetimepicker({
                    format: 'L',
                    minDate:new Date()
                });

                  $('#datetimepickerEndDate').datetimepicker({
                      format: 'L',
                      minDate:new Date()
                });
        });
</script>
</asp:Content>
