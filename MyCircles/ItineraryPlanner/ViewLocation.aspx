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
                    <asp:CheckBox ID="chkShowPlanItems" runat="server" Text=" &nbsp Show items in my plan" AutoPostBack="true" />
                </div>
                <br />
                <div class="row">
                    <h4>Activity Type</h4>
                </div>
                <div class="row">
                    <asp:CheckBox ID="chbBeaches" runat="server" Text=" &nbsp Beaches" AutoPostBack="true" OnCheckedChanged="chbBeaches_CheckedChanged"/>
                </div>
                <div class="row">
                    <asp:CheckBox ID="chbOutdoors" runat="server" Text=" &nbsp Outdoors" AutoPostBack="true" OnCheckedChanged="chbOutdoors_CheckedChanged" />
                </div>
                <div class="row">
                    <asp:CheckBox ID="chbMuseums" runat="server" Text=" &nbsp Museums" AutoPostBack="true" OnCheckedChanged="chbMuseums_CheckedChanged" />
                </div>
                <div class="row">
                    <asp:CheckBox ID="chbHistoric" runat="server" Text=" &nbsp Historic Sites" AutoPostBack="true" OnCheckedChanged="chbHistoric_CheckedChanged" />
                </div>
                <div class="row">
                    <asp:CheckBox ID="chbShopping" runat="server" Text=" &nbsp Shopping" AutoPostBack="true" OnCheckedChanged="chbShopping_CheckedChanged" />
                </div>
                <div class="row">
                    <asp:CheckBox ID="chbWildlife" runat="server" Text=" &nbsp Wildlife Area" AutoPostBack="true" OnCheckedChanged="chbWildlife_CheckedChanged1"/>
                </div>
            </div>
            <div class="col-md-8">
                <asp:Repeater ID="rpLocation" runat="server" ItemType="MyCircles.BLL.Location">
                    <ItemTemplate>
                        <div class="row border border-primary mb-3">
                             <div class="row pt-3 pl-3">
                                <div class="col-md-1 mr-5 col-sm-1">
                                    <h6>Opening Hours </h6> <br />
                                    <h6><%#DataBinder.Eval(Container.DataItem, "locaOpenHour") %></h6> <br />
                                    <h6><%#DataBinder.Eval(Container.DataItem, "locaCloseHour") %></h6>
                                </div>
                                <div class="col-md-4 col-sm-12">
                                    <asp:Image runat='server' Height='160px' Width='250px' ImageUrl=<%#DataBinder.Eval(Container.DataItem, "locaPic") %> />
                                </div>
                                <div class="col-md-5 col-sm-12 nopadding">
                                    <div class="row">
                                        <div class="col-md-8">
                                            <h4 style="height: 28px; overflow: hidden; text-overflow: ellipsis;"><%#DataBinder.Eval(Container.DataItem, "locaName") %></h4>
                                        </div>
                                        <div class="col-md-4">
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
