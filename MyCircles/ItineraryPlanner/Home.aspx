<%@ Page MasterPageFile="~/SignedIn.master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="MyCircles.ItineraryPlanner.Home" Title="Itinerary Planner" %>

<asp:Content ContentPlaceHolderId="SignedInContentPlaceholder" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.4.0/js/bootstrap-datepicker.min.js"></script>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/css/bootstrap.min.css" rel="stylesheet"/>

    

    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <link rel="stylesheet" href="/resources/demos/style.css">
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>

    <script>
        $( function runDate() {
            var dateFormat = "mm/dd/yy",
                from = $( "#<%= tbStartDate.ClientID %>" )
                .datepicker({
                    defaultDate: "+1w",
                    changeMonth: true,
                    numberOfMonths: 2,
                    minDate: 0
                })
                .on( "change", function() {
                    to.datepicker( "option", "minDate", getDate( this ) );
                }),
                to = $( "#<%= tbEndDate.ClientID %>" ).datepicker({
                    defaultDate: "+1w",
                    changeMonth: true,
                    numberOfMonths: 2,
                    minDate: 0
                })
                .on( "change", function() {
                from.datepicker( "option", "maxDate", getDate( this ) );
                });
 
            function getDate( element ) {
                var date;
                try {
                    date = $.datepicker.parseDate( dateFormat, element.value );
                }
                catch (error) {
                    date = null;
                }
 
                return date;
            }
        });

        function show() {

        }
    </script>

    <form id="formIPHome" runat="server">
        <div class="row justify-content mt-5">
            <div class="col-md-2"></div>
            <div class="col-md-3">
                <div class="row mb-3">
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                    <asp:Label ID="Label1" runat="server" Text="The next way to <br> plan your next trip" Font-Bold="True" Font-Size="30pt"></asp:Label>
                </div>
                <div class="row mb-3">
                    <asp:Label ID="Label4" runat="server" Text="OR"></asp:Label>
                </div>
                <div class="row mb-3">
                    <asp:Button ID="btnImportActivity" class="btn btn-lg" BackColor="Orange" runat="server" Text="Import Activity" ForeColor="White"  />
                    <a href="ViewLocation.aspx" class="btn btn-lg" >Explore Locations</a>
                </div>
                <br /><br /><br />
                <div class="row mb-3">
                    <asp:Button ID="btnViewPlan" class="btn btn-lg" BackColor="Orange" runat="server" Text="View Exisiting Plans" ForeColor="White" disabled/>
                </div>
            </div>
            <div class="col-md-2"></div>
            <div id="accordion" class="col-md-4 border border-secondary panel-group">
                <div class="ml-5 mr-5">
                    <div class="row d-flex justify-content-center">
                        <h1>Itinerary Planner</h1>
                    </div>
                    <div class="row mb-3">
                         <asp:TextBox ID="tbDestination" class="form-control" runat="server" placeholder="Enter destination (Region, Landmarks)" required></asp:TextBox>
                    </div>
                    <div class="row mb-5">
                        <div class="col-md-4">
                             <asp:TextBox ID="tbStartDate" class="form-control" runat="server" onkeyup="runDate" placeholder="Start" required></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                             <asp:TextBox ID="tbEndDate" class="form-control" runat="server" onKeyPress="javascript:runDate" placeholder="End" required></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                             <asp:TextBox ID="tbNoPeople" class="form-control" runat="server" type="number" min="2" max="100" placeholder="No. of Youths" required></asp:TextBox>

                        </div>
                    </div>
                    <div class="row mb-4 panel panel-primary">
                        <div class="panel-heading w-100">
                            <div class="panel-title">
                                <a href="#panelBody" class="text-decoration-none" data-toggle="collapse" data-parent="#accordion">
                                    <span class="glyphicon glyphicon-menu-down"></span>&nbsp ACTIVITY PREFERENCES (OPTIONAL)
                                </a>
                            </div>
                        </div>
                    </div>
                    <div id="panelBody" class="row mb-4 panel-collapse collapse">
                        <div class="col-md-12">
                            <div class="row mb-3 border border-primary">
                                <div class="col-md-4 border border-primary">
                                    <asp:CheckBox ID="CheckBox1" runat="server" Text="&nbsp culture" />
                                </div>
                                <div class="col-md-4 border border-primary">
                                    <asp:CheckBox ID="CheckBox2" runat="server" Text="&nbsp outdoors" />
                                </div>
                                <div class="col-md-4 border border-primary">
                                    <asp:CheckBox ID="CheckBox3" runat="server" Text="&nbsp relaxing" />
                                </div>
                            </div>
                            <div class="row mb-1 border border-primary">
                                <div class="col-md-4 border border-primary">
                                    <asp:CheckBox ID="CheckBox4" runat="server" Text="&nbsp museums" />
                                </div>
                                <div class="col-md-4 border border-primary">
                                    <asp:CheckBox ID="CheckBox5" runat="server" Text="&nbsp shoppping" />
                                </div>
                                <div class="col-md-4 border border-primary">
                                    <asp:CheckBox ID="CheckBox6" runat="server" Text="&nbsp wildlife" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row mb-4 d-flex justify-content-center">
                        <asp:Button ID="btnSubmitPlan" class="btn btn-lg" BackColor="Orange" runat="server" Text="See your plan" ForeColor="White" OnClick="btnSubmitPlan_Click" Font-Size="X-Large"/>
                    </div>
                </div>
            </div>
            <div class="col-md-1"></div>
        </div>
        <div class="row justify-content mt-4">
            <div class="col-md-2"></div>
            <div class="col-md-8">
                    <div class="row mb-3">
                        <asp:Repeater ID="rpItinerary" runat="server" ItemType="MyCircles.BLL.Itinerary">
                            <ItemTemplate>
                                 <div class="card mr-4" style="width: 18rem;">
                                    <img class="card-img-top" src="..." alt="Card image cap">
                                    <div class="card-body">
                                        <h5 class="card-title"><b>August Holiday Shopping</b></h5>
                                        <h6 class="card-subtitle mb-2 text-muted">Created by you</h6>
                                        <p class="card-text"><%#DataBinder.Eval(Container.DataItem, "startDate") %> - <%#DataBinder.Eval(Container.DataItem, "endDate") %></p>
                                        <p class="card-text"><%#DataBinder.Eval(Container.DataItem, "groupSize") %>Youth</p>
                                        <a href="#" class="btn btn-primary">Click to view</a>
                                    </div>
                                </div>  
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
            <div class="col-md-2"></div>
        </div>
    </form>
</asp:Content>