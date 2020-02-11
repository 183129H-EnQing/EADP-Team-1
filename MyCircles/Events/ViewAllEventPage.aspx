<%@ Page Title="" Language="C#" MasterPageFile="~/SignedIn.Master" AutoEventWireup="true" CodeBehind="ViewAllEventPage.aspx.cs" Inherits="MyCircles.Events.ViewAllEventPage" %>
<%@ Import Namespace ="MyCircles.BLL"%>
<asp:Content ID="Content1" ContentPlaceHolderID="SignedInHeadPlaceholder" runat="server">
    <style>
        .fliterText{
            font-size:14px;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SignedInContentPlaceholder" runat="server">
    <form runat="server">
        <div class="container">
            <div class="row" id="fliterOptions">
                <!-- Fliter Options--  <!-- d-none d-md-block" for col-3 class-->
               
                <!-- Hide if screen smaller than lg-->
                <div class=" col-md-4 col-lg-3 d-none d-lg-block">
                   <%-- <div class="card card-body mt-3">
                        <div class="left-filter-container">
                            <div class="form-inline">
                                <asp:Label runat="server" Text="MyInterestedCircle"></asp:Label>
                            </div>
                            <!--Will be empty if the user haven't add his interest circle,for now static data-->
                            <div class="form-inline">
                                <asp:Label runat="server" class="fliterText" Text="#Seminars"></asp:Label>
                            </div>
                            <div class="form-inline">
                                <asp:Label runat="server" class="fliterText" Text="#Sport"></asp:Label>
                            </div>
                        </div>

                        <div class="left-filter-container">
                            <div class="form-inline">
                                <asp:Label runat="server" Text="Location"></asp:Label>
                            </div>
                          
                            <div class="form-inline">
                                <asp:CheckBox ID="central" runat="server" />
                                <asp:Label runat="server" class="fliterText" Text="Central"></asp:Label>                  
                            </div>

                            <div class="form-inline">
                                <asp:CheckBox ID="South" runat="server" />
                                <asp:Label runat="server" class="fliterText" Text="South"></asp:Label>                  
                            </div>

                            <div class="form-inline">
                                <asp:CheckBox ID="West" runat="server" />
                                <asp:Label runat="server" class="fliterText" Text="West"></asp:Label>                  
                            </div>

                            <div class="form-inline">
                                <asp:CheckBox ID="East" runat="server" />
                                <asp:Label runat="server" class="fliterText" Text="East"></asp:Label>                  
                            </div>

                            <div class="form-inline">
                                <asp:CheckBox ID="North" runat="server" />
                                <asp:Label runat="server" class="fliterText" Text="North"></asp:Label>                  
                            </div>
                        </div>

                        <div class="left-filter-container">
                             <div class="form-inline">
                                <asp:Label runat="server" class="fliterText" Text="Event Type"></asp:Label>
                            </div>
                          
                            <div class="form-inline">
                                <asp:CheckBox ID="Entertainment" runat="server" />
                                <asp:Label runat="server" class="fliterText" Text="Entertainment"></asp:Label>                  
                            </div>

                            <div class="form-inline">
                                <asp:CheckBox ID="CheckBox2" runat="server" />
                                <asp:Label runat="server" class="fliterText" Text="Sport"></asp:Label>                  
                            </div>

                            <div class="form-inline">
                                <asp:CheckBox ID="CheckBox3" runat="server" />
                                <asp:Label runat="server" class="fliterText" Text="Seminars"></asp:Label>                  
                            </div>

                            <div class="form-inline">
                                <asp:CheckBox ID="CheckBox4" runat="server" />
                                <asp:Label runat="server" class="fliterText" Text="Community Services"></asp:Label>                  
                            </div>

                        </div>
                        
                    </div>--%>
                </div>
                <%-- For now col-lg-12 because fliter option not working . the original col-lg-9 --%>
                <div class="col-sm-12 col-md-12 col-lg-12">
                    <div class="card card-body mt-3">
                        <div class="row">
                            <!-- my auto basically center your text-->
                            <div class="col-6 my-auto">
                                 <asp:Label runat="server" Text="Recommended Events"></asp:Label>
                            </div>
                            <div class="col-6 d-lg-none text-right">
                                     <button type="button" class="btn btn-primary">
                                         <i class="fas fa-filter"></i>
                                         <span>Filter</span>
                                     </button>      
                            </div>
                        </div>
                       
                        <div class="row mt-3">
                     <%--    <% for (int i = 0; i < 5; i++) { %> 
                             <h1><%= hello %></h1>  
                            <% } %>  --%>
            <% foreach (var singleEvent in MyCircles.BLL.Event.GetAllEvent()) { %>
                                  <%--<p id="hello+<%=singleEvent.eventId %>")"><%=singleEvent.eventEndDate%> </p>
                --%>
                              <div class="col-lg-4 col-md-4 col-sm-12 mb-2">
                                <a href="/Events/ViewEventDetails.aspx?eventID=<%=singleEvent.eventId%>"> 
                                <div class="card card-body" id="Div1">
                                    <div class="row">
                                        <div class="col-sm-3 col-md-12 ">
                                            <!-- event image -->
                                               <img alt="Card image cap" class="card-img-top img-fluid" src="..<%=singleEvent.eventImage %>" style="width:100%;" />
                                        </div>
                                        <div class="col-sm-9 col-md-12 col-lg-12">
                                            <div class="row">
                                                <div class="col-12">
                                            <!-- event title -->
                                                    <span class="EventTitle"><%=singleEvent.eventName%></span>
                                                </div>
                                             </div>
                                             <div class="row">
                                                <div class="col-12">
                                                     <span class="eventDate">
                                                         <!-- singleEvent.eventEndDate == ""abit lousy-->
                                                         <%if (singleEvent.eventEndDate == null || singleEvent.eventEndDate == "" || (singleEvent.eventEndDate == singleEvent.eventStartDate)){ %>
                                                                 <%=singleEvent.eventStartDate%>
                                                         <%} %>
                                                         <%else { %>
                                                                 <%=singleEvent.eventStartDate%> - <%=singleEvent.eventEndDate%>
                                                         <%} %>
                                                     </span>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-12">
                                                     <span class="eventOrganiser"><%=singleEvent.eventHolderName %></span>
                                                </div>
                                            </div> 


                                         
                                        </div>
                                    </div>
                                   
                                </div>
                                        </a>
                            </div>
                            <%} %>
                                        
                        </div>

                    </div>
     
                </div>
            </div>
        </div>  
    </form>

    <script>
        const request = makeRequest("POST", "lol", (response) => {
            console.log(response);
        });

        request.send();
    </script>
</asp:Content>

