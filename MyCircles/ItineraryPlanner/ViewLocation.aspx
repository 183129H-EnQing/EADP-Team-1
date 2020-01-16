<%@ Page MasterPageFile="Header.master" AutoEventWireup="true" CodeBehind="ViewLocation.aspx.cs" Inherits="MyCircles.ItineraryPlanner.ViewLocation" Title="Locations"%>

<asp:Content ContentPlaceHolderId="BodyContentPlaceHolder" runat="server">
    <form id="form1" runat="server">
        <div class="row d-flex justify-content-center mt-5">
            <h2><asp:Label ID="lbPlannerName" runat="server" Text="January Outing"></asp:Label></h2>
        </div>
        <div class="row mt-3">
            <div class="col-md-1"></div>
            <div class="col-md-1">
                <h2><asp:Label ID="lbMonth" runat="server" Text="Label"></asp:Label></h2> 
                <%--<input id="noOfDate" runat="server" ClientIdMode="Static"/>--%>
                <ul class="nav flex-column" >
                    <li class="nav-item">
                        <a id="aStartDate" class="nav-link active" href="#" runat="server"></a>
                    </li>
                   
                    <li class="nav-item">
                        <a id="aEndDate" class="nav-link" href="#" runat="server"></a>
                    </li>
                </ul>
            </div>
            <div class="col-md-8 border border-primary">
                <asp:Repeater ID="rpLocation" runat="server" ItemType="MyCircles.BLL.Location">
                    <ItemTemplate>
                        <div class="row pt-3">
                            <div class="col-md-1 mr-5 col-sm-12">
                                <h4>10.00am</h4> <br />
                                <h4>12.00pm</h4>
                            </div>
                            <div class="col-md-4 col-sm-12">
                                <asp:Image runat='server' Height='160px' Width='250px' ImageUrl=<%#DataBinder.Eval(Container.DataItem, "locaPic") %> />
                            </div>
                            <div class="col-md-5 col-sm-12">
                                <div class="row">
                                    <div class="col-md-7">
                                        <h4><%#DataBinder.Eval(Container.DataItem, "locaName") %></h4>
                                    </div>
                                    <div class="col-md-5">
                                        
                                         <h6><%#DataBinder.Eval(Container.DataItem, "locaRating") %> stars</h6>
                                    </div>
                                </div>
                                <div class="row" style="height:150px;">
                                    <p style="height: 120px; overflow: auto; text-overflow: ellipsis;"><%#DataBinder.Eval(Container.DataItem, "locaDesc") %></p>
                                </div>
                            </div>
                            <div class="col-md-1 col-sm-12 d-flex flex-row-reverse">
                                <h6><%#DataBinder.Eval(Container.DataItem, "landmarkType") %></h6>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="col-md-1"></div>
            <div class="col-md-1"></div>
        </div>
    </form>
    </form>
</asp:Content>
