<%@ Page MasterPageFile="SignedOut.master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MyCircles.Register" Title="Register - MyCircles" %>

<asp:Content ContentPlaceHolderId="SignedOutContentPlaceholder" runat="server">
    <form id="formRegister" class="my-5" runat="server">
        <h5 class="p-2 text-left">Register for a new account</h5>
        <div class="row signedOutInputContainer text-center p-2">
            <div class="col-md-6 pr-md-1">
                <asp:TextBox ID="tbName" runat="server" CssClass="form-control-lg m-1" type="text" placeholder="Display Name"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Name is required" ControlToValidate="tbName" Display="None" ValidationGroup="registerErrGroup" />
            </div>
            <div class="col-md-6 pl-md-1">
                <asp:TextBox ID="tbUsername" runat="server" CssClass="form-control-lg m-1" type="text" placeholder="Username"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ErrorMessage="Username is required" ControlToValidate="tbUsername" Display="None" ValidationGroup="registerErrGroup" />
            </div>
            <div class="col-md-12">
                <asp:TextBox ID="tbEmailAddress" runat="server" CssClass="form-control-lg m-1" type="email" placeholder="Email Address"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEmailAddress" runat="server" ErrorMessage="Email Address is required" ControlToValidate="tbEmailAddress" Display="None" ValidationGroup="registerErrGroup" />
                <asp:RegularExpressionValidator ID="revEmailAddress" runat="server" ErrorMessage="Enter a valid email format" ControlToValidate="tbEmailAddress" Display="None" ValidationGroup="registerErrGroup" ValidationExpression="^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$" />
            </div>
            <div class="col-md-12">
                <asp:TextBox ID="tbPassword" runat="server" CssClass="form-control-lg m-1" type="password" placeholder="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Password is required" ControlToValidate="tbPassword" Display="None" ValidationGroup="registerErrGroup" />
            </div>
            <div class="col-md-12">
                <asp:ScriptManager ID="RegisterScriptManager" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
                <asp:UpdatePanel ID="RegisterUpdatePanel" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="row">
                            <div id="signedOutErrorContainer" class="signedOutErrorContainer col-md-12 my-3" runat="server" visible="false">
                                <div class="signedOutErrorBlock">
                                    <i class="fas fa-exclamation-triangle"></i> &nbsp;
                                    <asp:Label ID="lbErrorMsg" runat="server" />
                                </div>
                            </div>
                            <div class="col-md-12 float-left my-5">
                                <asp:Button ID="btRegister" runat="server" Text="Register" CssClass="btn btn-primary btn-util-block float-right ml-2" UseSubmitBehavior="false" OnClick="btRegister_Click"  OnClientClick="disableAsyncButton(this);" />
                                <input id="btBack" name="btBack" class="btn btn-link float-right mr-2" value="Go Back" type="button" runat="server" onserverclick="btBack_Click" />
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btRegister" EventName="Click" />        
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </form>
</asp:Content>