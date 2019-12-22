<%@ Page MasterPageFile="SignedOut.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MyCircles.Login" Title="Login - MyCircles" %>

<asp:Content ContentPlaceHolderId="SignedOutContent" runat="server">
    <form id="formRegister" class="my-5" runat="server">
        <h5 class="p-2 text-left">Login into your account</h5>
        <div class="row signedOutInputContainer text-center p-2">
            <div class="col-md-12">
                <asp:TextBox ID="tbUsername" runat="server" CssClass="form-control-lg m-1" type="text" placeholder="Username"></asp:TextBox>
            </div>
            <div class="col-md-12">
                <asp:TextBox ID="tbPassword" runat="server" CssClass="form-control-lg m-1" type="password" placeholder="Password"></asp:TextBox>
            </div>
            <div class="col-md-12 float-right my-5">
                <asp:Button ID="btLogin" runat="server" Text="Login" CssClass="btn btn-primary btn-util-block float-right ml-2" />
                <asp:Button ID="btGoogleSignIn" runat="server" Text="Sign In With Google" CssClass="btn btn-outline-dark float-right mr-2 btn-google" /> <br />
                <asp:Button ID="btRegister" runat="server" Text="Register for a new account" CssClass="btn btn-link float-right" OnClick="btRegister_Click" />
            </div>
        </div>
    </form>
</asp:Content>