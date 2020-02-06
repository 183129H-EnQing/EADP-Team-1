<%@ Page MasterPageFile="Header.master" AutoEventWireup="true" CodeBehind="Timeline.aspx.cs" Inherits="MyCircles.ItineraryPlanner.Timeline" Title="Timeline" %>

<asp:Content ContentPlaceHolderID="BodyContentPlaceHolder" runat="server">
<%--    <link href="http://maxcdn.bootstrapcdn.com/font-awesome/4.1.0/css/font-awesome.min.css" rel="stylesheet">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>--%>
    <style>
        /*#hoverdiv {
            visibility: hidden;
        }*/
        /*i:hover + #hoverdiv {
            display: block;
        }

        #hoverdiv:focus {
            display: block;
        }*/
    </style>
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
    <%--<script>
    $(function runDate() {
            var dateFormat = "dd M",
                from = $( "#<%= tbeventDate.ClientID %>")
                    .datepicker({
                        defaultDate: "+1w",
                        changeMonth: true,
                        numberOfMonths: 0,
                        minDate: 0,
                        dateFormat: "dd M",
                        maxDate: "+3m"
                    })
                    .on("change", function () {
                        to.datepicker("option", "minDate", getDate(this));
                    })
                    });

            function getDate(element) {
                var date;
                try {
                    date = $.datepicker.parseDate(dateFormat, element.value);
                }
                catch (error) {
                    date = null;
                }

                return date;
            }
        });
    </script>--%>
    <form id="form1" runat="server">
        <div class="row mt-5 sticky-top bg-warning mb-5">
            <div class="col-md-1"></div>
            <div class="col-md-1 sticky-top">
                <asp:Repeater ID="rpDates" runat="server" ItemType="MyCircles.BLL.DayByDay">
                    <itemtemplate>
                        <h5><a href="#header<%#DataBinder.Eval(Container.DataItem, "dayByDayId") %>" style="text-decoration:none;"><%#DataBinder.Eval(Container.DataItem, "date") %></a></h5>
                    </itemtemplate>
                </asp:Repeater>
            </div>
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

        <%--<div class="row">
            <asp:Repeater ID="rpModal" runat="server" ItemType="MyCircles.BLL.DayByDay">
                <itemtemplate>
                    <div class="col-md-2"></div>
                    <div class="col-md-8">
                        <div class="row border border-secondary p-3"> <!--asp repeater above -->
                            <div class="col-md-1"></div>
                            <div class="col-md-10">
                                <div class="row mt-3">
                                    <div class="col-md-3">img</div>
                                    <div class="col-md-9">
                                        <div class="row"><h5><%#DataBinder.Eval(Container.DataItem, "locaName") %></h5></div>
                                        <div class="row"><%#DataBinder.Eval(Container.DataItem, "locaRating") %></div>
                                        <div class="row" style="height: 75px; overflow: auto;"><%#DataBinder.Eval(Container.DataItem, "locaDesc") %></div>
                                    </div>
                                </div>
                                <div class="row"><hr /></div>
                                <div class="row">
                                    <div class="col-md-6"><h6>Date:</h6></div>
                                    <div class="col-md-3"><h6>Start Time:</h6></div>
                                    <div class="col-md-3"><h6>End Time:</h6></div>
                                </div>
                                <div class="row mb-3">
                                    <div class="col-md-6">
                                        <asp:TextBox ID="tbdate" runat="server" Style="width: 75%" Text="<%#DataBinder.Eval(Container.DataItem, "date") %>"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:DropDownList ID="ddlstartTime" runat="server" Style="width: 100%" Text="<%#DataBinder.Eval(Container.DataItem, "startTime") %>"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:DropDownList ID="ddlendTime" runat="server" Style="width: 100%" Text="<%#DataBinder.Eval(Container.DataItem, "endTime") %>"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row mb-2">
                                    <div class="col-md-12">
                                         <asp:TextBox ID="tbnote" TextMode="MultiLine" runat="server" Style="width: 100%" placeholder="Add Notes"></asp:TextBox>
                                    </div>
                                </div>
                                 <div class="row mb-3">
                                     <div class="col-md-3"></div>
                                     <div class="col-md-6 d-flex justify-content-center">
                                         <asp:Button ID="Button1" runat="server" Text="Save"/>
                                     </div>
                                     <div class="col-md-3  d-flex justify-content-center">
                                         <a href="#" class="text-decoration: none;">Delete Event</a>
                                     </div>
                                </div>
                            </div>
                            <div class="col-md-1"></div>
                        </div>
                    </div>
                    <div class="col-md-2"></div>
                </itemtemplate>
            </asp:Repeater>
        </div>--%>









        <div id="eventModal" class="modal" tabindex="-1" role="dialog">
            <div class="modal-dialog modal-lg" role="document">
                <%--<asp:Repeater ID="rpModal" runat="server" ItemType="MyCircles.DAL.Joint_Models.DayLocation" OnDataBinding="rpModal_DataBinding">       
                    <Itemtemplate>--%>
                        <div class="modal-content pl-3 pr-3"> 
                            <div class="modal-header">
                                <h5 class="modal-title">Modal title</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                 <div class="row mb-2">
                                    <%--<div class="col-md-4"><%#DataBinder.Eval(Container.DataItem, "locaName") %></div>--%>
                                    <div class="col-md-8" style="height: 100px; overflow: auto;">Enjoy panoramic views of the city from high up above at Singapore Flyer. The Ferris wheel reaches 165 m (541 ft) at its pinnacle and takes half an hour to complete a spin. You can celebrate special occasions on board with a range of packages, including a signature cocktail flight or a couple's dinner with full butler service. Buy your tickets online to avoid waiting in line on the day of your visit.</div>
                                </div>
                                <div class="row mb-2">
                                    <div class="col-md-6">Date</div>
                                    <div class="col-md-3">Start Time</div>
                                    <div class="col-md-3">End Time</div>
                                </div>
                                <div class="row mb-2">
                                    <div class="col-md-6">
                                        <asp:TextBox ID="tbeventDate" runat="server"></asp:TextBox> 
                                        <%--onkeyup="runDate"--%>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:DropDownList ID="ddlstartTime" runat="server" onmouseover="javascript:this.size=5" onmouseout="javascript:this.size=1">
                                            <asp:ListItem Text="0800" />
                                            <asp:ListItem Text="0830" />
                                            <asp:ListItem Text="0900" />
                                            <asp:ListItem Text="0930" />
                                            <asp:ListItem Text="1000" />
                                            <asp:ListItem Text="1030" />
                                            <asp:ListItem Text="1100" />
                                            <asp:ListItem Text="1130" />
                                            <asp:ListItem Text="1200" />
                                            <asp:ListItem Text="1230" />
                                            <asp:ListItem Text="1300" />
                                            <asp:ListItem Text="1300" />
                                            <asp:ListItem Text="1400" />
                                            <asp:ListItem Text="1430" />
                                            <asp:ListItem Text="1500" />
                                            <asp:ListItem Text="1530" />
                                            <asp:ListItem Text="1600" />
                                            <asp:ListItem Text="1630" />
                                            <asp:ListItem Text="1700" />
                                            <asp:ListItem Text="1730" />
                                            <asp:ListItem Text="1800" />
                                            <asp:ListItem Text="1830" />
                                            <asp:ListItem Text="1900" />
                                            <asp:ListItem Text="1930" />
                                            <asp:ListItem Text="2000" />
                                            <asp:ListItem Text="2030" />
                                            <asp:ListItem Text="2100" />
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:DropDownList ID="ddlendTime" runat="server" onmouseover="javascript:this.size=5" onmouseout="javascript:this.size=1">
                                            <asp:ListItem Text="0800" />
                                            <asp:ListItem Text="0830" />
                                            <asp:ListItem Text="0900" />
                                            <asp:ListItem Text="0930" />
                                            <asp:ListItem Text="1000" />
                                            <asp:ListItem Text="1030" />
                                            <asp:ListItem Text="1100" />
                                            <asp:ListItem Text="1130" />
                                            <asp:ListItem Text="1200" />
                                            <asp:ListItem Text="1230" />
                                            <asp:ListItem Text="1300" />
                                            <asp:ListItem Text="1300" />
                                            <asp:ListItem Text="1400" />
                                            <asp:ListItem Text="1430" />
                                            <asp:ListItem Text="1500" />
                                            <asp:ListItem Text="1530" />
                                            <asp:ListItem Text="1600" />
                                            <asp:ListItem Text="1630" />
                                            <asp:ListItem Text="1700" />
                                            <asp:ListItem Text="1730" />
                                            <asp:ListItem Text="1800" />
                                            <asp:ListItem Text="1830" />
                                            <asp:ListItem Text="1900" />
                                            <asp:ListItem Text="1930" />
                                            <asp:ListItem Text="2000" />
                                            <asp:ListItem Text="2030" />
                                            <asp:ListItem Text="2100" />
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                         <asp:TextBox ID="tbnote" TextMode="MultiLine" runat="server" Style="width: 100%" placeholder="Add Notes"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-primary">Save changes</button>
                                <button type="button" class="btn btn-secondary" data-dismiss="modal" onclick="closeViewPostModal()">Close</button>
                            </div>
                        </div>
                    <%--</Itemtemplate>
                </asp:Repeater>--%>
            </div>
        </div>

        <asp:Repeater ID="rpParentDates" runat="server" ItemType="MyCircles.BLL.DayByDay">
            <itemtemplate>
                <div class="row">
                    <div class="col-md-1"></div>
                    <div class="col-md-1">
                        <%--<input id="noOfDate" runat="server" ClientIdMode="Static"/>--%>
                        <%-- %>ul class="nav flex-column">
                            <li class="nav-item">
                                <a id="aStartDate" class="nav-link active" href="#" runat="server"></a>
                            </li>

                            <li class="nav-item">
                                <a id="aEndDate" class="nav-link" href="#" runat="server"></a>
                            </li>
                        </--%>
                    </div>
                    <div class="col-md-8">
                        <div class="col-md-2">
                            <div id="header<%#DataBinder.Eval(Container.DataItem, "dayByDayId") %>" style="color: white; background-color: grey; border-radius: 10px;">&nbsp &nbsp <%#DataBinder.Eval(Container.DataItem, "date") %></div>
                            <br />
                        </div>
                        <asp:Repeater ID="rpChildDayLocation" runat="server" ItemType="MyCircles.DAL.Joint_Models.DayLocation" OnDataBinding="rpChildDayLocation_DataBinding">
                            <ItemTemplate>
                                <div class="row border border-primary mb-5">
                                    <div class="row pt-3 pl-3">
                                        <div class="col-md-1 mr-5 col-sm-1">
                                            <br />
                                            <h6><%#DataBinder.Eval(Container.DataItem, "startTime") %></h6>
                                            <br />
                                            <h6><%#DataBinder.Eval(Container.DataItem, "endTime") %></h6>
                                        </div>
                                        <div class="col-md-4 col-sm-12">
                                            <asp:Image runat='server' Height='160px' Width='250px' ImageUrl='<%#DataBinder.Eval(Container.DataItem, "locaPic") %>' />
                                        </div>
                                        <div class="col-md-5 col-sm-12 nopadding">
                                            <div class="row">
                                                <div class="col-md-8">
                                                    <h4 style="height: 28px;overflow: hidden;text-overflow: ellipsis;"><%#DataBinder.Eval(Container.DataItem, "locaName") %></h4>
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
                                            <%--<i class='fa fa-ellipsis-v'></i>--%>
                                            <div class="dropdown show">
                                                <a class="btn btn-secondary dropdown-toggle" href="#" role="button" id="dropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                    <i class='fa fa-ellipsis-v'></i>
                                                </a>
                                                <div class="dropdown-menu" aria-labelledby="dropdownMenuLink">
                                                    <a class="dropdown-item" href="#" onclick="openViewPostModal()">Edit Time</a>
                                                    <a class="dropdown-item" href="#">Delete Event</a>
                                                    <a class="dropdown-item" href="#">Add Notes</a>
                                                </div>
                                            </div>
                                            <script>
                                                function openViewPostModal() {
                                                    $("#eventModal").modal('show');
                                                }

                                                function closeViewPostModal() {
                                                    $('#eventModal').modal('hide')
                                                }
                                            </script>
                                            <%--<h6><%#DataBinder.Eval(Container.DataItem, "landmarkType") %></h6>--%>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <div class="col-md-1"></div>
                    <div class="col-md-1"></div>
                </div>
            </itemtemplate>
        </asp:Repeater>
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
