<%@ Page Title="" Language="C#" MasterPageFile="~/SignedIn.master" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="MyCircles.Profile.EditProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SignedInHeadPlaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SignedInContentPlaceholder" runat="server">
    <div class="container mt-3">
        <div class="card card-body">
            <h4 class="text-primary">Edit Profile</h4>
        <div class="card card-body">
            <form id="form1" runat="server">
                <div class="form-group">
                    <label id="NameLB">Name</label>
                    <asp:TextBox type="text" class="form-control" ID="nameTB" runat="server"></asp:TextBox>
                </div>

                <div class="row">
                    <div class="col-12">
                        <label>Main Event Image</label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-12">
                        <asp:FileUpload ID="imageUpload" runat="server" />
                    </div>
                </div>

                <div class="form-group">
                    <label id="bioLB" class="mt-3">Bio</label>
                    <asp:TextBox type="text" class="form-control" ID="bioTB" runat="server"></asp:TextBox>
                </div>

                <asp:Button ID="submitButt" OnClick="submitButt_Click" CssClass="form-check-label btn btn-success btn-block mt-4" runat="server" Text="Submit" />
            </form>
        </div>
                    </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SignedInDeferredScriptsPlaceholder" runat="server">
</asp:Content>
