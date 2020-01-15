<%@ Page Language="C#"  MasterPageFile="~/SignedIn.Master" AutoEventWireup="true" CodeBehind="PeopleNearby.aspx.cs" Inherits="MyCircles.Home.PeopleNearby" %>

<asp:Content ID="SignedOutBase" ContentPlaceHolderID="SignedInContentPlaceholder" runat="server">

<script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" ></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" ></script>

<script>
$(function () {
  $('[data-toggle="popover"]').popover()
})
</script>

 <form id="form1" runat="server">
     
        <div>
            <table class="table table-hover">
        <thead>
        <tr>
        <th><h1 class="text-primary">Suggested</h1></th>
        
        </tr>
        </thead>
        <tbody>
        <tr>
        <td><h3>Ghp@14</h3>Follows U</td>
        <td> <asp:Button ID="btn1" runat="server" Text="Follow" class="btn btn-primary" style="border-radius:12px" data-toggle="popover" data-content=" Following"></asp:button> </td>
        </tr>
        <tr>
        <td><h3>Jasmine2001</h3>New to Circles</td>
        <td> <asp:Button ID="btn2" runat="server" Text="Follow" class="btn btn-primary" style="border-radius:12px" data-toggle="popover" data-content=" Following"></asp:button> </td>
        </tr>
        <tr>
        <td><h3>Ong@Yen</h3>Have a common interest</td>
        <td><asp:Button ID="btn3" runat="server" Text="Follow" class="btn btn-primary" style="border-radius:12px" data-toggle="popover" data-content=" Following"></asp:button></td>
        </tr>
        <tr>
        <td><h3>Adbul_M</h3>Follows U</td>
        <td> <asp:Button ID="btn4" runat="server" Text="Follow" class="btn btn-primary" style="border-radius:12px"></asp:button> </td>
        </tr>
         <tr>
        <td><h3>@Priya</h3>New To Circles</td>
        <td> <asp:Button ID="btn5" runat="server" Text="Follow" class="btn btn-primary" style="border-radius:12px"></asp:button> </td>
        </tr>
        </tbody>
        </table>
        </div>
         
    </form>

 </asp:Content>


