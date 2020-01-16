<%@ Page Title="" Language="C#" MasterPageFile="~/SignedIn.master" AutoEventWireup="true" CodeBehind="ViewEventDetails.aspx.cs" Inherits="MyCircles.ViewEventDetails1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SignedInHeadPlaceholder" runat="server">
    <style>
        @media (min-width: 1200px) {
    .container{
        max-width: 970px;
    }
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SignedInContentPlaceholder" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-12 mt-3">
                <div class="card card-body">
                    <div class="row">
                        <div class="col-12">
                             <!--insert event Title to the span-->
                            <span>IT Talk</span>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-12">
                            <i class="fas fa-filter"></i>
                            <!--insert event location to the span-->
                            <span>Nanyang Poly</span> 
                        </div>
                    </div>
                  
                    <div class="row">
                        <div class="col-12">
                            <span>Description</span>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-12">
                            <p>The Talk is about IT. The JAV Power.</p>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-12">
                            <div class="card card-body" style="padding-bottom: 0px;padding-top: 14px;">

                                    <span>Event schedule</span>

                                     <table class="table table-bordered">
                                        <thead>
                                          <tr>
                                            <th>Start</th>
                                            <th>End</th>
                                            <th>Event</th>
                                          </tr>
                                        </thead>
                                        <tbody>
                                          
                                          <tr>
                                            <td>John</td>
                                            <td>Doe</td>
                                            <td>john@example.com</td>
                                          </tr>
                                          <tr>
                                            <td>Mary</td>
                                            <td>Moe</td>
                                            <td>mary@example.com</td>
                                          </tr>
                                          <tr>
                                            <td>July</td>
                                            <td>Dooley</td>
                                            <td>july@example.com</td>
                                          </tr>
                                        </tbody>
                                      </table>

                            </div>
                        </div>
                    </div>
                    
                    <div class="row">
                        <div class="col-12">
                            <div class="card card-body mt-3">
                                <div class="row">
                                    <div class="col-sm-6 col-md-12 col-lg-4">
							            <p class="font-italic">Timings</p>
							            <p class="text-info"> 09.00AM - 06.00PM </p>
						            </div>

                                    <div class="col-sm-6 col-md-12 col-lg-4">
							            <p class="font-italic">Entry Fees</p>
							            <p class="text-info">Free</p>
						            </div>

						            <div class="col-sm-6 col-md-12 col-lg-4">
							            <p class="font-italic">Category Type</p>
							            <p class="text-info">Seminars</p>
						            </div>

						            <div class="col-sm-6 col-md-12 col-lg-4">
							            <p class="font-italic">Date </p>
							            <p class="text-info">15 Jan - 17 Jan 2020</p>
						            </div>

                                    <div class="col-sm-6 col-md-12 col-lg-4">
                                        <p class="font-italic">Avaliable Slots </p>
							            <p class="text-info">40</p>
                                    </div>

                                    <div class="col-sm-6 col-md-12 col-lg-4">
                                        <p class="font-italic">Organizer</p>
							            <p class="text-info">Nanyang Polytechnic</p>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-6" style="padding-right: 0px;">
                                        <a class="btn btn-danger" style="width:100%;">Contact Organizer</a>
                                    </div>
                                    <div class="col-6" style="padding-left:0px;">
                                        <a class="btn btn-success" style="width:100%;">Register</a>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SignedInDeferredScriptsPlaceholder" runat="server">
</asp:Content>
