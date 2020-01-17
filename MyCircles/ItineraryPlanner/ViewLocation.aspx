<%@ Page MasterPageFile="Header.master" AutoEventWireup="true" CodeBehind="ViewLocation.aspx.cs" Inherits="MyCircles.ItineraryPlanner.ViewLocation" Title="Locations"%>

<asp:Content ContentPlaceHolderId="BodyContentPlaceHolder" runat="server">
    <form id="form1" runat="server">
        <div class="row d-flex justify-content-center mt-4">
            <h2><asp:Label ID="lbPlannerName" runat="server" Text="Explore Locations"></asp:Label></h2>
        </div>
        <div class="row mt-3">
            <div class="col-md-1"></div>
            <div class="col-md-2 position-sticky">
                <div class="row">
                    <label><input type="checkbox" id="cbPlanItem" value="other" class="mr-2" >Show items in my plan</label>
                </div>
                <br />
                <div class="row">
                    <h4>Activity Type</h4>
                </div>
                <div class="row">
                    <asp:CheckBox ID="chbBeaches" runat="server" Text="Beaches" AutoPostBack="true" OnCheckedChanged="chbBeaches_CheckedChanged"/>
                    <label><input type="checkbox" id="cbBeaches" value="1" class="mr-2" runat="server" AutoPostBack="true" OnCheckedChanged="landMarkBeaches()">Beaches</label>
                </div>
                <div class="row">
                    <label><input type="checkbox" id="cbOutdoors" class="mr-2" runat="server">Outdoors</label>
                </div>
                <div class="row">
                    <label><input type="checkbox" id="cbMuseums" class="mr-2" runat="server">Museums</label>
                </div>
                <div class="row">
                    <label><input type="checkbox" id="cbHistoricSites" class="mr-2" runat="server">Historic Sites</label>
                </div>
                <div class="row">
                    <label><input type="checkbox" id="cbShopping" class="mr-2" runat="server">Shopping</label>
                </div>
                <div class="row">
                    <label><input type="checkbox" id="cbWildlifeArea" class="mr-2" >Wildlife Area</label>
                </div>
            </div>
            <div class="col-md-8">
                <asp:Repeater ID="rpLocation" runat="server" ItemType="MyCircles.BLL.Location">
                    <ItemTemplate>
                        <div class="row border border-primary">
                             <div class="row pt-3 pl-3">
                                <div class="col-md-1 mr-5 col-sm-12">
                                    <h6>Opening Hours </h6>
                                    <h4><%#DataBinder.Eval(Container.DataItem, "locaOpenHour") %></h4> <br />
                                    <h4><%#DataBinder.Eval(Container.DataItem, "locaCloseHour") %></h4>
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
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="col-md-1"></div>
        </div>
    </form>
</asp:Content>
