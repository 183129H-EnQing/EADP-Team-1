<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeBehind="Overview.aspx.cs" Inherits="MyCircles.Admin.Overview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
<div class="m-4">
    <h2 class="text-center">
        Overview
    </h2>

    <div class="row">
        <div class="col col-lg-6 offset-lg-3">
            <div class="row row-cols-1 row-cols-sm-2 text-center">
                <div class="col mb-3">
                    <div class="card border-black h-100">
                        <div class="card-body font-weight-bold">
                            Posts Reported
                        </div>
                        <div class="card-footer number-thingy">
                            <%=numOfReportedPosts %>
                        </div>
                    </div>
                </div>

                <div class="col mb-3">
                    <div class="card border-black h-100">
                        <div class="card-body font-weight-bold">
                            Events Created
                        </div>
                            
                        <div class="card-footer number-thingy">
                            <%=numOfEvents %>
                        </div>
                    </div>
                </div>

                <div class="col mb-lg-0 mb-sm-0 mb-3">
                    <div class="card border-black h-100">
                        <div class="card-body font-weight-bold">
                            Users registered
                        </div>
                            
                        <div class="card-footer number-thingy">
                            <%=numOfUsers %>
                        </div>
                    </div>
                </div>

                <div class="col">
                    <div class="card border-black h-100">
                        <div class="card-body font-weight-bold">
                            Circles Created
                        </div>
                            
                        <div class="card-footer number-thingy">
                            <%=numOfCircles %>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
</div>
</asp:Content>
