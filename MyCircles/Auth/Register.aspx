<%@ Page MasterPageFile="SignedOut.master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MyCircles.Register" Title="Register - MyCircles" %>

<asp:Content ContentPlaceHolderId="SignedOutContentPlaceholder" runat="server">
    <form id="formRegister" class="my-5" runat="server">
        <h5 class="p-2 text-left">Register for a new account</h5>
        <div class="row signedOutInputContainer text-center p-2">
            <div class="col-md-6 pr-1">
                <asp:TextBox ID="tbName" runat="server" CssClass="form-control-lg m-1" type="text" placeholder="Display Name" required></asp:TextBox>
            </div>
            <div class="col-md-6 pl-1">
                <asp:TextBox ID="tbUsername" runat="server" CssClass="form-control-lg m-1" type="text" placeholder="Username" required></asp:TextBox>
            </div>
            <div class="col-md-12">
                <asp:TextBox ID="tbEmailAddress" runat="server" CssClass="form-control-lg m-1" type="email" placeholder="Email Address" required></asp:TextBox>
            </div>
            <div class="col-md-12">
                <asp:TextBox ID="tbPassword" runat="server" CssClass="form-control-lg m-1" type="password" placeholder="Password" required></asp:TextBox>
            </div>
            <asp:ScriptManager ID="LoginScriptManager" runat="server" EnablePartialRendering="true"></asp:ScriptManager>   
                <asp:UpdatePanel ID="LoginUpdatePanel" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div id="signedOutErrorContainer" class="col-md-12 my-3" runat="server" visible="false">
                            <div class="signedOutErrorBlock">
                                <i class="fas fa-exclamation-triangle"></i> &nbsp;
                                <asp:Label ID="lbErrorMsg" runat="server"></asp:Label>
                            </div>
                        </div>
                    </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btLogin" EventName="Click" />        
                </Triggers>
            </asp:UpdatePanel>
            <div class="col-md-12 float-right my-5">
                <asp:Button ID="btRegister" runat="server" Text="Register" CssClass="btn btn-primary btn-util-block float-right ml-2" OnClick="btRegister_Click" OnClientClick="" />
                <input id="btBack" name="btBack" class="btn btn-link float-right mr-2" value="Go Back" type="button" runat="server" onserverclick="btBack_Click" />
            </div>
        </div>
    </form>
</asp:Content>