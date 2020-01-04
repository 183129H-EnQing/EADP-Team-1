<%@ Page Title="" Language="C#" MasterPageFile="~/SignedIn.Master" AutoEventWireup="true" CodeBehind="ViewAllEventPage.aspx.cs" Inherits="MyCircles.ViewEventDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SignedInHeadPlaceholder" runat="server">
    <style>
        .fliterText{
            font-size:14px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SignedInContentPlaceholder" runat="server">
    <form runat="server">
        <div class="container">
            <div class="row" id="fliterOptions">
                <!-- Fliter Options--  <!-- d-none d-md-block" for col-3 class-->
                <div class=" col-md-4 col-lg-3 d-none d-md-block">
                    <div class="card card-body mt-3">
                        <div class="left-filter-container">
                            <div class="form-inline">
                                <asp:Label runat="server" Text="MyInterestedCircle"></asp:Label>
                            </div>
                            <!--Will be empty if the user haven't add his interest circle,for now static data-->
                            <div class="form-inline">
                                <asp:Label runat="server" class="fliterText" Text="#Seminars"></asp:Label>
                            </div>
                            <div class="form-inline">
                                <asp:Label runat="server" class="fliterText" Text="#Sport"></asp:Label>
                            </div>
                        </div>

                        <div class="left-filter-container">
                            <div class="form-inline">
                                <asp:Label runat="server" Text="Location"></asp:Label>
                            </div>
                          
                            <div class="form-inline">
                                <asp:CheckBox ID="central" runat="server" />
                                <asp:Label runat="server" class="fliterText" Text="Central"></asp:Label>                  
                            </div>

                            <div class="form-inline">
                                <asp:CheckBox ID="South" runat="server" />
                                <asp:Label runat="server" class="fliterText" Text="South"></asp:Label>                  
                            </div>

                            <div class="form-inline">
                                <asp:CheckBox ID="West" runat="server" />
                                <asp:Label runat="server" class="fliterText" Text="West"></asp:Label>                  
                            </div>

                            <div class="form-inline">
                                <asp:CheckBox ID="East" runat="server" />
                                <asp:Label runat="server" class="fliterText" Text="East"></asp:Label>                  
                            </div>

                            <div class="form-inline">
                                <asp:CheckBox ID="North" runat="server" />
                                <asp:Label runat="server" class="fliterText" Text="North"></asp:Label>                  
                            </div>
                        </div>

                        <div class="left-filter-container">
                             <div class="form-inline">
                                <asp:Label runat="server" class="fliterText" Text="Event Type"></asp:Label>
                            </div>
                          
                            <div class="form-inline">
                                <asp:CheckBox ID="Entertainment" runat="server" />
                                <asp:Label runat="server" class="fliterText" Text="Entertainment"></asp:Label>                  
                            </div>

                            <div class="form-inline">
                                <asp:CheckBox ID="CheckBox2" runat="server" />
                                <asp:Label runat="server" class="fliterText" Text="Sport"></asp:Label>                  
                            </div>

                            <div class="form-inline">
                                <asp:CheckBox ID="CheckBox3" runat="server" />
                                <asp:Label runat="server" class="fliterText" Text="Seminars"></asp:Label>                  
                            </div>

                            <div class="form-inline">
                                <asp:CheckBox ID="CheckBox4" runat="server" />
                                <asp:Label runat="server" class="fliterText" Text="Community Services"></asp:Label>                  
                            </div>

                        </div>
                        
                    </div>
                </div>
   
                <div class="col-sm-12 col-md-8 col-lg-9">
                    <div class="card card-body mt-3">
                        <asp:Label runat="server" Text="Recommended Events"></asp:Label>
                        <div class="row">
                            <div class="col-sm-4">
                                <div class="card card-body">
                                    hello world
                                </div>
                            </div>
                        </div>
                    </div>
                <!-- recommend events -->
                </div>
            </div>
        </div>  
    </form>

</asp:Content>
