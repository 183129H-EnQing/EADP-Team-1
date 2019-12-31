<%@ Page MasterPageFile="SignedOut.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MyCircles.Login" Title="Login - MyCircles" %>

<asp:Content ContentPlaceHolderId="SignedOutContentPlaceholder" runat="server">
    <form id="formRegister" class="my-5" runat="server">
        <h5 class="p-2 text-left">Sign into your account</h5>
        <div class="row signedOutInputContainer text-center p-2">
            <div class="col-md-12">
                <asp:TextBox ID="tbUsername" runat="server" CssClass="form-control-lg m-1" type="text" placeholder="Username" required></asp:TextBox>
            </div>
            <div class="col-md-12">
                <asp:TextBox ID="tbPassword" runat="server" CssClass="form-control-lg m-1" type="password" placeholder="Password" required></asp:TextBox>
            </div>
            <div id="signedOutErrorContainer" class="col-md-12 my-3" runat="server" visible="false">
                <div class="signedOutErrorBlock">
                    <i class="fas fa-exclamation-triangle"></i> &nbsp;
                    <asp:Label ID="lbErrorMsg" runat="server"></asp:Label>
                </div>
            </div>
            <div class="col-md-12 float-left my-5">
                <asp:Button ID="btLogin" runat="server" Text="Login" CssClass="btn btn-primary btn-util-block float-left mr-2" OnClick="btLogin_Click" />
                <input id="btGoogleSignIn" name="btGoogleSignIn" class="btn btn-outline-dark btn-google float-left ml-2" value="Sign in with Google" type="button" runat="server" onserverclick="btGoogleSignIn_Click" /> <br /> <br />
                <input id="btRegister" name="btRegister" class="btn btn-link float-left" value="Register for a new account" type="button" runat="server" onserverclick="btRegister_Click" />
            </div>
        </div>
    </form>
</asp:Content>