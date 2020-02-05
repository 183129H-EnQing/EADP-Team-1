<%@ Page MasterPageFile="~/ItineraryPlanner/Header.Master" AutoEventWireup="true" CodeBehind="LocationDetail.aspx.cs" Inherits="MyCircles.ItineraryPlanner.LocationDetail" %>

<asp:Content ContentPlaceHolderID="BodyContentPlaceHolder" runat="server">
    <form id="form1" runat="server">
        <div class="row sticky-top">
            <h4>Sands SkyPark Observation Deck</h4>
        </div>
        <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-1"></div>
            <div class="col-md-8">
                <div class="row">
                    <div class="col-md-8">
                        <div class="row">
                            <%--<img src="" />--%>
                            img
                        </div>
                        <div class="row">
                            description
                        </div>
                        <div class="row">
                            <h5>On the web:</h5>
                        </div>
                        <div class="row">
                            <h5>website:</h5>
                        </div>
                    </div>
                    <div class="col-md-5">
                        <div class="row">
                            <h5>Recommended Duration</h5>
                        </div>
                        <div class="row">
                            <h5>Operating Hours</h5>
                        </div>
                        <div class="row">
                            <h5>Address</h5>
                        </div>
                        <div class="row">
                            <h5>Contact</h5>
                        </div>
                        <div class="row">
                            <h5>map</h5>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-1"></div>
            <div class="col-md-1"></div>
        </div>
    </form>
</asp:Content>
