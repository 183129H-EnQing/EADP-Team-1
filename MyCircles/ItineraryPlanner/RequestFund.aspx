<%@ Page MasterPageFile="Header.master" AutoEventWireup="true" CodeBehind="RequestFund.aspx.cs" Inherits="MyCircles.ItineraryPlanner.RequestFund" Title="Request Funds" %>

<asp:Content ContentPlaceHolderId="BodyContentPlaceHolder" runat="server">
    <form id="form1" runat="server">
        <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-1"></div>
            <div class="col-md-8 border border-secondary">
                <h2>Request Funds</h2> <br />
                <div class="row mb-2">
                    <div class="col-md-3">
                        <h5>Select Trip</h5>
                    </div>
                    <div class="col-md-9">
                        <input />
                    </div>
                </div>
                <div class="row mb-2">
                    <div class="col-md-3">
                        <h5>Date</h5>
                    </div>
                    <div class="col-md-9">
                        <input />
                    </div>
                </div>
                <div class="row mb-2">
                    <div class="col-md-3">
                        <h5>Activity</h5>
                    </div>
                    <div class="col-md-9">
                        <input />
                    </div>
                </div>
                <div class="row mb-2">
                    <div class="col-md-3">
                        <h5>Amount</h5>
                    </div>
                    <div class="col-md-9">
                        <input />
                    </div>
                </div>
                <div class="row mb-2">
                    <div class="col-md-3">
                        <h5>Expense Breakdown</h5>
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
