<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeBehind="Overview.aspx.cs" Inherits="MyCircles.Admin.Overview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <h2 class="text-center">
        Overview
    </h2>

    <div class="row">
        <div class="col-8 offset-2">
            <div class="row">
                <div class="col">
                    <div class="card-deck">
                        <div class="card border-black">
                            <div class="card-body text-center">
                                <div class="card-text">Reported Posts</div>
                                <div class="card-text">
                                    <span class="number-thingy"><b><%=numOfReportedPosts %></b></span>
                                </div>
                            </div>
                        </div>
        
                        <div class="card border-black">
                            <div class="card-body text-center">
                                <div class="card-text">Event Hosts</div>
                                <div class="card-text">
                                    <span class="number-thingy"><b><%=numOfEventHosts %></b></span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row mt-4">
                <div class="col">
                    <div class="card-deck">
                        <div class="card border-black">
                            <div class="card-body text-center">
                                <div class="card-text">Events Created</div>
                                <div class="card-text">
                                    <span class="number-thingy"><b><%=numOfEvents %></b></span>
                                </div>
                            </div>
                        </div>
                        <div class="card border-black">
                            <div class="card-body text-center">
                                <div class="card-text">Users registered for events</div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
