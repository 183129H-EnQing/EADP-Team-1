<%@ Page Title="" Language="C#" MasterPageFile="~/SignedIn.master" AutoEventWireup="true" CodeBehind="CreateEventPage.aspx.cs" Inherits="MyCircles.Events.CreateEventPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SignedInHeadPlaceholder" runat="server">
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/tempusdominus-bootstrap-4/5.0.0-alpha14/js/tempusdominus-bootstrap-4.min.js"></script>
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/tempusdominus-bootstrap-4/5.0.0-alpha14/css/tempusdominus-bootstrap-4.min.css" />
<%--<link href="https://cdn.quilljs.com/1.3.6/quill.snow.css" rel="stylesheet">
    <script src="https://cdn.quilljs.com/1.3.6/quill.js"></script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SignedInContentPlaceholder" runat="server">
    <div class="container-fluid mt-3">
        <div class="row">
           <%-- <div class="col-3">
                <div class="card card-body">
                    <a class="navbar-brand" href="/Home/Post.aspx" runat="server">
                        <img src="../Content/images/MyCirclesIconStatic.png" width="40" height="40" alt="">
                     </a>
                    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>

                    <div class="collapse navbar-collapse" id="navbarNav">
                        <ul class="navbar-nav mx-auto">
                            <li class="nav-item <% if (Request.Url.AbsoluteUri.Contains("Home")) { %> active  <% } %>">
                                <a class="nav-link" href="/Home/Post.aspx" runat="server">Home <% if (Request.Url.AbsoluteUri.Contains("Home")) { %> <span class="sr-only">(current)</span>  <% } %></a>
                            </li>
                            <li class="nav-item <% if (Request.Url.AbsoluteUri.Contains("Event")) { %> active  <% } %>">
                                <a class="nav-link" href="/Events/ViewAllEventPage.aspx" runat="server">Events <% if (Request.Url.AbsoluteUri.Contains("Event")) { %> <span class="sr-only">(current)</span>  <% } %></a>
                            </li>
                            <li class="nav-item <% if (Request.Url.AbsoluteUri.Contains("Planner")) { %> active  <% } %>">
                                <a class="nav-link" href="/ItineraryPlanner/Home.aspx" runat="server">Planner <% if (Request.Url.AbsoluteUri.Contains("Planner")) { %> <span class="sr-only">(current)</span>  <% } %></a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="/Profile/Search" runat="server">Search</a>
                            </li>
                        </ul>
                    </div>

                </div>
    
            </div>--%>

            <div class="col-12">
                <div class="card card-body" style="left: 0px; top: 0px">
                    <form runat="server">
                        <%-- basic info collaspe --%>
                    <div class="d-flex justify-content-between">
                        <h4 class="text-primary my-auto">Basic Info </h4>
                        <button class="btn btn-primary" type="button" data-toggle="collapse" data-target="#collaspeBasicInfo" aria-expanded="false" aria-controls="collapseExample">Show/Hide</button>
                    </div>
                  
                    <div class="collapse" id="collaspeBasicInfo">

                        <h5 style="font-size: 16px;">
                            Name your event and tell event-goers why they should come. Add details that highlight what makes it unique.
                        </h5>
                        <div class="card card-body">
                          
                                <div class="form-group">
                                    <label id="eventLB">Event Title</label>
                                    <asp:TextBox type="text" class="form-control" ID="eventTitleTB" runat="server"></asp:TextBox>
                                </div>

                                <div class="form-group">
                                    <label id="eventDescription">EventDescription</label>
                                    <asp:TextBox ID="eventDescriptionTB" runat="server" TextMode="MultiLine" CssClass="form-control" style="width:100%;"></asp:TextBox>
                                </div>

                                <div class="row">
                                    <div class="col-12">
                                        <div class="form-group">
                                                <label>Category</label>
                                            <asp:DropDownList ID="CategoryDropDownList" runat="server" class="form-control" ClientIDMode="Static">
                                                <asp:ListItem Value="Sports & Fitness" />
                                                <asp:ListItem Value="Performing & Visual Arts"/>
                                                <asp:ListItem Value="Science & Technology" />
                                                
                                            </asp:DropDownList>
                                        </div>
                                    </div>
         <%--                           <div class="col-6">
                                        <div class="form-group">
                                            <label>SubCategory</label>
                                            <asp:DropDownList ID="SubCategoryDropDownList" runat="server" class="form-control"  ClientIDMode="Static">

                                            </asp:DropDownList>
                                        </div>
                                    </div>--%>
                                </div>

                                <div class="form-group">
                                    <label for="inputOrganizer">Organizer</label>
                                    <asp:TextBox type="text" class="form-control" ID="organizerTB" runat="server"></asp:TextBox>
                                </div>
                                 
                        </div>

                    </div>

                        <%-- Location collaspe --%>
                    <div class="d-flex justify-content-between mt-3">
                        <h4 class="text-primary my-auto">Location </h4>
                        <button class="btn btn-primary" type="button" data-toggle="collapse" data-target="#collaspeLocation" aria-expanded="false" aria-controls="collapseExample">Show/Hide</button>
                    </div>

                    <div class="collapse" id="collaspeLocation">
                        <h5 style="font-size: 16px;">
                            Help people in the area discover your event and let attendees know where to show up.
                        </h5>
                        <div class="card card-body">
                              <div class="form-group">
                                    <label id="LocationLB">Location</label>
                                       <asp:DropDownList ID="LocationDLL" runat="server" class="form-control" ClientIDMode="Static" AutoPostBack="false" >
                                           <asp:ListItem Value="To Be Announced" />
                                           <asp:ListItem Value="Venue" />
                                       </asp:DropDownList>
                              </div>
                              <div class="form-group" ID="LocationTBContainer" ClientIDMode="Static" style="display:none;"> 
                                  <asp:TextBox type="text" class="form-control" ID="LocationTB" runat="server" placeholder="Enter Your Venue Here" ></asp:TextBox>
                              </div>     
                        </div>
                    </div>
        
                    <%-- Date And Time collaspe--%>       
                    <div class="d-flex justify-content-between mt-3">
                        <h4 class="text-primary my-auto">Date and Time </h4>
                        <button class="btn btn-primary" type="button" data-toggle="collapse" data-target="#collaspeDateAndTime" aria-expanded="false" aria-controls="collapseExample">Show/Hide</button>
                    </div>

                    <div class="collapse" id="collaspeDateAndTime">
                        <h5 style="font-size: 16px;">
                            Tell event-goers when your event starts and ends so they can make plans to attend.
                        </h5>
                        <div class="card card-body">
                              <div class="radio">
                                  <label><asp:RadioButton ID="singleEventRadioButton" runat="server" type="radio" Checked="true"/>Single Event - Happens once and can last multiple days</label>
                              </div>                         

                              <div class="row">
                                    <div class="col-6">
                                        <div class="form-group">
                                            <label>StartDate</label>
                                             <div class="input-group date" id="datetimepickerStartDate" data-target-input="nearest">
                                                 <asp:TextBox ID="startDateTB" type="text" class="form-control datetimepicker-input" data-target="#datetimepickerStartDate" runat="server"></asp:TextBox>
                                                 <div class="input-group-append" data-target="#datetimepickerStartDate" data-toggle="datetimepicker">
                                                    <div class="input-group-text"><i class="fa fa-calendar"></i></div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-6">
                                        <div class="form-group">
                                            <label>EndDate</label>
                                            <div class="input-group date" id="datetimepickerEndDate" data-target-input="nearest">                                             
                                                 <asp:TextBox ID="endDateTB" type="text" class="form-control datetimepicker-input" data-target="#datetimepickerEndDate" runat="server"></asp:TextBox>
                                                <div class="input-group-append" data-target="#datetimepickerEndDate" data-toggle="datetimepicker">
                                                    <div class="input-group-text"><i class="fa fa-calendar"></i></div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-6">
                                        <div class="form-group">
                                            <label id="startTimeLB">startTime</label>
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
                                         
                                    </div>

                                    <div class="col-6">
                                        <div class="form-group">
                                            <label id="endTimeLB">EndTime</label>
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
                                </div>

                            </div>

                    </div>

                         <%-- Event Details collaspe--%>       
                    <div class="d-flex justify-content-between mt-3">
                        <h4 class="text-primary my-auto">Details </h4>
                        <button class="btn btn-primary" type="button" data-toggle="collapse" data-target="#collaspeEventDetails" aria-expanded="false" aria-controls="collapseExample">Show/Hide</button>
                    </div>

                    <div class="collapse" id="collaspeEventDetails">
                        <h5 style="font-size: 16px;">
                            Help people in the area discover your event and let attendees know where to show up.
                        </h5>
                        <div class="card card-body">
                            <div class="row">
                                <div class="col-12">
                                     <label >Main Event Image</label>
                                </div>
                            </div>

                            <div class="row"> 
                                <div class="col-12">
                                    <asp:FileUpload ID="imageUpload" runat="server" />
                                </div>
                           
                            </div>

                              <div class="form-group">
                                    <label class="mt-2">EntryFee</label>
                                       <asp:DropDownList ID="entryFeeStatusDDL" runat="server" class="form-control" ClientIDMode="Static" AutoPostBack="false">
                                           <asp:ListItem Value="Free" /> 
                                           <asp:ListItem Value="Not Free" />
                                       </asp:DropDownList>
                              </div>
                              <div class="form-group" id="entryFeeTBConatiner" ClientIDMode="Static" style="display:none;"> 
                                  <asp:TextBox type="text" class="form-control" ID="entryFeeTB" runat="server" placeholder="Enter Your Entry Fee Price"></asp:TextBox>
                              </div>   
                            
                              <div class="form-group">
                                  <label>Maximum Time A Person Can Register</label>

                                  <asp:DropDownList ID="maxTimeAPersonCanRegisterDLL" runat="server" class="form-control" ClientIDMode="Static" AutoPostBack="false">
                                    <asp:ListItem Value="No Limit" /> 
                                    <asp:ListItem Value="Got Limit" />
                                  </asp:DropDownList>
                              </div>

                            <div class="form-group" id="maxTimeAPersonCanRegisterTBConatiner" ClientIDMode="Static" style="display:none;">
                               <asp:TextBox type="text" class="form-control" ID="maxTimeAPersonCanRegisterTB" runat="server" placeholder="Enter The Limit A Person Can Book"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label>Maxmium Slot Avaliable</label>
                                <asp:DropDownList ID="maxSlotAvaliableDDL" runat="server" class="form-control" ClientIDMode="Static" AutoPostBack="false">
                                    <asp:ListItem Value="No Limit" /> 
                                    <asp:ListItem Value="Got Limit" />
                                 </asp:DropDownList>
                            </div>

                            <div class="form-group" id="maxSlotTBConatiner" ClientIDMode="Static" style="display:none;">
                                <asp:TextBox type="text" class="form-control" ID="maxSlotTB" runat="server" placeholder="Enter The Maxmium Available Slots"></asp:TextBox>                            
                            </div>
                           
                        </div>
                    </div>

                        <div id="signedOutErrorContainer" class="signedOutErrorContainer col-md-12 my-4 p-0" runat="server" visible="false">
                            <div class="signedOutErrorBlock">
                                <i class="fas fa-exclamation-triangle"></i>&nbsp;
                            <asp:Label ID="lbErrorMsg" runat="server">
                                <asp:ValidationSummary ID="vsAddCircles" runat="server" ShowSummary="false" DisplayMode="List" ValidationGroup="addEvent" />
                            </asp:Label>
                            </div>
                        </div>

                        <asp:Button ID="submitButt" CssClass="form-check-label btn btn-success btn-block mt-4" runat="server" Text="Submit" OnClick="submitButt_Click" />
                    </form>
                </div>
            </div>
        </div>
    </div>

    <div></div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SignedInDeferredScriptsPlaceholder" runat="server">
    <script type="text/javascript">
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


        window.onload = function () {
            hideOrShowExtraTB();
        }


        function addEventScheduleData()
        {
            console.log("value:", document.getElementById("endDateTBEventSchedule").value);

            $.ajax({
                url: "/",
                type: "POST",
                data: {
                    "someData": document.getElementById("endDateTBEventSchedule").value
                },
                "success": (data) => {
                    console.log("success");
                    console.log(data);
                }
            })
        }<%--          var quill = new Quill('#editor', {
            theme: 'snow'
        });
        var editor_content = quill.container.innerHTML;
        var x = <%=quillData %> 
            x = editor_content
        console.log(editor_content);--%>
        function hideOrShowExtraTB() {
            var locationDDLValue = document.getElementById("LocationDLL").value;
            var entryFeeStatusDDLValue = document.getElementById("entryFeeStatusDDL").value;
            var maxTimeAPersonCanRegisterDLLValue = document.getElementById("maxTimeAPersonCanRegisterDLL").value;
            var maxSlotAvaliableDDLValue = document.getElementById("maxSlotAvaliableDDL").value;

            //console.log(maxSlotAvaliableDDLValue)

            if (locationDDLValue == "Venue") {
                document.getElementById("LocationTBContainer").style.display = "block";
            }
            else {
                document.getElementById("LocationTBContainer").style.display = "none";
            }

            if (entryFeeStatusDDLValue == "Not Free") {
                document.getElementById("entryFeeTBConatiner").style.display = "block";
            }
            else {
                document.getElementById("entryFeeTBConatiner").style.display = "none";
            }

            if (maxTimeAPersonCanRegisterDLLValue == "Got Limit") {
                document.getElementById("maxTimeAPersonCanRegisterTBConatiner").style.display = "block";
            }
            else {
                document.getElementById("maxTimeAPersonCanRegisterTBConatiner").style.display = "none";
            }

            if (maxSlotAvaliableDDLValue == "Got Limit") {
                document.getElementById("maxSlotTBConatiner").style.display = "block";
            }
            else {
                document.getElementById("maxSlotTBConatiner").style.display = "none";
            }
            
        }
       
        </script>
</asp:Content>
