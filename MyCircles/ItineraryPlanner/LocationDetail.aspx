<%@ Page MasterPageFile="Header.Master" AutoEventWireup="true" CodeBehind="LocationDetail.aspx.cs" Inherits="MyCircles.ItineraryPlanner.LocationDetail" Title="Locaction Details"%>
<%@ Register assembly="Reimers.Google.Map" namespace="Reimers.Google.Map" TagPrefix="Reimers" %>

<asp:Content ContentPlaceHolderID="BodyContentPlaceHolder" runat="server">
    <form id="form1" runat="server">
        <div class="container-fluid mt-5 mb-5">
            <asp:Repeater ID="rpLocation" runat="server" ItemType="MyCircles.BLL.Location">
                <ItemTemplate>
                    <div class="row mt-3 mb-4">
                        <div class="col-md-2"></div>
                        <div class="col-md-5">
                            <div class="row d-flex justify-content-between">
                                <h5><%#DataBinder.Eval(Container.DataItem, "locaName") %></h5>
                                <h6><%#DataBinder.Eval(Container.DataItem, "locaRating") %></h6>
                            </div>
                            <div class="row mb-4">
                                <img src="<%#DataBinder.Eval(Container.DataItem, "locaPic") %>" alt="<%#DataBinder.Eval(Container.DataItem, "locaName") %>"/>
                            </div>
                            <div class="row">
                                <p><%#DataBinder.Eval(Container.DataItem, "locaDesc") %></p>
                            </div>
                            <div class="row"><h6>On the web</h6></div>
                            <div class="row"><a href="<%#DataBinder.Eval(Container.DataItem, "locaWeb") %>" target="_blank"><%#DataBinder.Eval(Container.DataItem, "locaWeb") %></a></div>
                        </div>
                        <div class="col-md-1"></div>
                        <div class="col-md-2">
                            <div class="row"><h6>Recommended Duration</h6></div> 
                            <div class="row"><%#DataBinder.Eval(Container.DataItem, "locaRecom") %></div> <br />
                            <div class="row"><h6>Hours</h6></div>
                            <div class="row">
                                <p>Mon - Sun: &nbsp</p>
                                <p><%#DataBinder.Eval(Container.DataItem, "locaOpenHour") %></p> 
                                <p> - </p>
                                <p><%#DataBinder.Eval(Container.DataItem, "locaCloseHour") %></p>
                            </div>
                            <div class="row"><h6>Contact</h6></div>
                            <div class="row"><%#DataBinder.Eval(Container.DataItem, "locaAddress") %>,</div>
                            <div class="row"><%#DataBinder.Eval(Container.DataItem, "locaPostalCode") %></div> <br />
                            <div class="row"><h6><%#DataBinder.Eval(Container.DataItem, "locaContact") %></h6></div>
                        </div>
                        <div class="col-md-1"></div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <div class="row">
                <reimers:map id="GMap" width="100%" height="300px" runat="server" Zoom="18" />
            </div>
        </div>
    </form>
</asp:Content>
