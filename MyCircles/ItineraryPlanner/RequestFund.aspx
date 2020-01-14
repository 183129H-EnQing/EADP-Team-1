<%@ Page MasterPageFile="Header.master" AutoEventWireup="true" CodeBehind="RequestFund.aspx.cs" Inherits="MyCircles.ItineraryPlanner.RequestFund" Title="Request Funds" %>

<asp:Content ContentPlaceHolderId="BodyContentPlaceHolder" runat="server">
    <form id="form1" runat="server">
        <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-1"></div>
            <div class="col-md-8 border border-secondary">
                <h1>Request Funds</h1> <br />
                <div class="row">
                    <div class="col-md-3">
                        <h3>Select Trip</h3>
                    </div>
                    <div class="col-md-9">
                        <input />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <h3>Date</h3>
                    </div>
                    <div class="col-md-9">
                        <input />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <h3>Activity</h3>
                    </div>
                    <div class="col-md-9">
                        <input />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <h3>Amount</h3>
                    </div>
                    <div class="col-md-9">
                        <input />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <h3>Expense Breakdown</h3>
                    </div>
                    <div class="col-md-9">
                        <input />
                    </div>
                </div> 
                <br />
                <button class="btn btn-primary">Request</button>
            </div>
            <div class="col-md-1"></div>
            <div class="col-md-1"></div>
        </div>
    </form>
</asp:Content>
