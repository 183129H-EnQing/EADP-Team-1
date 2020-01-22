<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="MyCircles.Admin.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <h2 class="text-center">
        Overview
    </h2>

    <div class="row">
        <div class="col d-flex justify-content-end">
            <div class="card border-black">
                <div class="card-body">
                    <div class="card-title">Reported Posts</div>
                    <div class="card-text text-center">
                        <span class="number-thingy"><b><%=numOfReportedPosts %></b></span>
                    </div>
                </div>
            </div>
        </div>
        
        <div class="col d-flex">
            <div class="card border-black">
                <div class="card-body">
                    <div class="card-title">Number of Event Hosts</div>
                    <div class="card-text text-center">
                        <span class="number-thingy"><b>26</b></span>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
