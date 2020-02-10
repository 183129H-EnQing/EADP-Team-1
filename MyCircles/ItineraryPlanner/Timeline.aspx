<%@ Page MasterPageFile="Header.master" AutoEventWireup="true" CodeBehind="Timeline.aspx.cs" Inherits="MyCircles.ItineraryPlanner.Timeline" Title="Timeline"%>

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

        #foo {
            position: fixed;
            bottom: 25px;
            right: 70px;
            border-radius: 15%;
        }
        #ratingbar {
            position: fixed;
            bottom: 65px;
            right: 200px;
            /*display: none;*/
        }
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
        <div id="foo" class="btn btn-success" onclick="showRatingBar()">Rate Us</div>
        
        <script>
            function showRatingBar() {
                document.getElementById("ratingbar").style.display = "block";
            }
        </script>
        
        <div id="ratingbar" data-role="ratingbar" data-steps="3" style="font-size: 10px">
          <ul>
            <li><a href="#"><span class="glyphicon glyphicon-star"></span></a></li>
            <li><a href="#"><span class="glyphicon glyphicon-star"></span></a></li>
            <li><a href="#"><span class="glyphicon glyphicon-star"></span></a></li>
            <li><a href="#"><span class="glyphicon glyphicon-star"></span></a></li>
            <li><a href="#"><span class="glyphicon glyphicon-star"></span></a></li>
          </ul>
        </div>
        <script>
            $('[data-role="ratingbar"]')
                .ratingbar()
                .click(function () {

                    // Grab value
                    alert($(this).attr('data-value'));

                    return false;
                });
        </script>

        <div class="row mt-5 sticky-top bg-warning mb-5">
            <div class="col-md-1"></div>
            <div class="col-md-1 sticky-top">
                <asp:Repeater ID="rpDates" runat="server" ItemType="MyCircles.BLL.DayByDay">
                    <ItemTemplate>
                        <h5><a href="#header<%#DataBinder.Eval(Container.DataItem, "dayByDayId") %>" style="text-decoration: none;"><%#DataBinder.Eval(Container.DataItem, "date") %></a></h5>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="col-md-8">
                <div class="row d-flex justify-content-center">
                    <%-- need insert title of Plan if possible--%>
                    <h2>
                        <asp:Label ID="lbPlannerName" runat="server" Text="Feburary Outing"></asp:Label></h2>
                </div>
            </div>
            <div class="col-md-1">
                <div class="dropdown show">
                    <a class="btn btn-warning dropdown-toggle" href="#" role="button" id="dropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <i class='fa fa-ellipsis-v'></i>
                    </a>
                    <div class="dropdown-menu" aria-labelledby="dropdownMenuLink">
                        <a class="dropdown-item" href="RequestFund.aspx">Request Fund</a>
                        <a class="dropdown-item" href="#" onclick="openDeleteModal()" >Delete Planner</a>
                    </div>
                </div>
            </div>
            <div class="col-md-1"></div>
        </div>

        <script>
            function openDeleteModal() {
                $('#deleteModal').modal('show');
            }
        </script>
        <div id="deleteModal" class="modal" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Confirm Delete?</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <p>Are you sure you want to delete this plan?</p>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnDelete" runat="server" Text="Delete Planner" onclick="btnDelete_Click" CssClass="btn btn-primary"/>
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
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

        <asp:Repeater ID="rpParentDates" runat="server" ItemType="MyCircles.BLL.DayByDay">
            <ItemTemplate>
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
                                <div class="row border border-primary">
                                    <div class="row pt-3 pl-3">
                                        <div class="col-md-1 mr-5 col-sm-1">
                                            <br />
                                            <h6><%#DataBinder.Eval(Container.DataItem, "startTime", "{0:HH:mm}") %></h6>
                                            <br />
                                            <h6><%#DataBinder.Eval(Container.DataItem, "endTime", "{0:HH:mm}") %></h6>
                                        </div>
                                        <div class="col-md-4 col-sm-12">
                                            <asp:Image runat='server' Height='160px' Width='250px' ImageUrl='<%#DataBinder.Eval(Container.DataItem, "locaPic") %>' />
                                        </div>
                                        <div class="col-md-5 col-sm-12 nopadding">
                                            <div class="row">
                                                <div class="col-md-8">
                                                    <h4 style="height: 28px; overflow: hidden; text-overflow: ellipsis;"><a href="LocationDetail.aspx?locId=<%#DataBinder.Eval(Container.DataItem, "locationId") %>"><%#DataBinder.Eval(Container.DataItem, "locaName") %></a></h4>
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
                                                    <a class="dropdown-item" href="#"  onclick="openViewPostModal()">Add Notes</a>
                                                </div>
                                            </div>
                                            <script>
                                                function openViewPostModal() {
                                                    $('#eventModal<%#DataBinder.Eval(DirectCast(DirectCast(Container, Control).NamingContainer.NamingContainer, IDataItemContainer).DataItem, "dayByDayId") %>').modal('show');
                                                    $('tbeventDate<%#DataBinder.Eval(DirectCast(DirectCast(Container, Control).NamingContainer.NamingContainer, IDataItemContainer).DataItem, "dayByDayId") %>').val('<%#DataBinder.Eval(DirectCast(DirectCast(Container, Control).NamingContainer.NamingContainer, IDataItemContainer).DataItem, "date") %>');
                                                    $('ddlstartTime<%#DataBinder.Eval(DirectCast(DirectCast(Container, Control).NamingContainer.NamingContainer, IDataItemContainer).DataItem, "dayByDayId") %>').val('<%#DataBinder.Eval(Container.DataItem, "startTime") %>');
                                                    $('ddlendTime<%#DataBinder.Eval(DirectCast(DirectCast(Container, Control).NamingContainer.NamingContainer, IDataItemContainer).DataItem, "dayByDayId") %>').val('<%#DataBinder.Eval(Container.DataItem, "startTime") %>');

                                                }

                                                function closeViewPostModal() {
                                                    $('#eventModal<%#DataBinder.Eval(DirectCast(DirectCast(Container, Control).NamingContainer.NamingContainer, IDataItemContainer).DataItem, "dayByDayId") %>').modal('hide');
                                                }
                                            </script>
                                            <%--<h6><%#DataBinder.Eval(Container.DataItem, "landmarkType") %></h6>--%>
                                        </div>
                                    </div>
                                </div>
                                <div id="notesdiv<%#DataBinder.Eval(Container.DataItem, "dayId") %>" class="row pl-3 border border-primary border-top-0 mb-5" style="display: none;">
                                    <div class="col-md-1 mr-5"></div>
                                    <div class="col-md-1"><h6>Notes:</h6></div>
                                    <div class="col-md-7">
                                        <p id="notesData<%#DataBinder.Eval(Container.DataItem, "dayId") %>"><%#DataBinder.Eval(Container.DataItem, "notes") %></p>
                                    </div>
                                    <div class="col-md-1"></div>
                                </div>

                                <script>
                                    function showNotes() {
                                        var x = <%#DataBinder.Eval(Container.DataItem, "dayId") %>;
                                        var divs = document.getElementById("notesdiv" + x);
                                        var data = document.getElementById("notesData" + x);
                                        if (data.innerHTML != null) {
                                            divs.style.display = "block";
                                        }
                                    }
                                    window.onload = showNotes();
                                </script>


                                <div id='eventModal<%#DataBinder.Eval(DirectCast(DirectCast(Container, Control).NamingContainer.NamingContainer, IDataItemContainer).DataItem, "dayByDayId") %>' class="modal" tabindex="-1" role="dialog">
                                    <div class="modal-dialog modal-lg" role="document">
                                        <div class="modal-content pl-3 pr-3">
                                            <div class="modal-header">
                                                <h5 class="modal-title"><%#DataBinder.Eval(Container.DataItem, "locaName") %></h5>
                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                    <span aria-hidden="true">&times;</span>
                                                </button>
                                            </div>
                                            <div class="modal-body">
                                                <div class="row mb-2">
                                                    <div class="col-md-4">
                                                        <asp:Image runat='server' Height='140px' Width='230px' ImageUrl='<%#DataBinder.Eval(Container.DataItem, "locaPic") %>' />
                                                    </div>
                                                    <div class="col-md-8" style="height: 125px; overflow: auto;"><%#DataBinder.Eval(Container.DataItem, "locaDesc") %></div>
                                                </div>
                                                <div class="row mb-2">
                                                    <div class="col-md-6">Date</div>
                                                    <div class="col-md-3">Start Time</div>
                                                    <div class="col-md-3">End Time</div>
                                                </div>
                                                <div class="row mb-2">
                                                    <div class="col-md-6">
                                                        <p><%#DataBinder.Eval(DirectCast(DirectCast(Container, Control).NamingContainer.NamingContainer, IDataItemContainer).DataItem, "date") %></p>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <p><%#DataBinder.Eval(Container.DataItem, "startTime", "{0:HH:mm}") %></p>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <p><%#DataBinder.Eval(Container.DataItem, "endTime", "{0:HH:mm}") %></p>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <asp:TextBox ID="tbNotes" TextMode="MultiLine" runat="server" Style="width: 100%" placeholder="Add Notes"></asp:TextBox>
                                                        <%--<asp:Label ID="lbDay" runat="server"><%#DataBinder.Eval(Container.DataItem, "dayId") %></asp:Label>--%>
             
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="modal-footer">
                                                <asp:Button ID="btnSaveChanges" runat="server" CssClass="btn btn-primary" Text="Save changes" OnClick="btnSaveChanges_Click"/>
                                                <button type="button" class="btn btn-secondary" data-dismiss="modal" onclick="closeViewPostModal()">Close</button>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <div class="col-md-1"></div>
                    <div class="col-md-1"></div>
                </div>
            </ItemTemplate>
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
