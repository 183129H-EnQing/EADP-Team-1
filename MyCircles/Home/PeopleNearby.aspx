<%@ Page Language="C#"  MasterPageFile="~/SignedIn.Master" AutoEventWireup="true" CodeBehind="PeopleNearby.aspx.cs" Inherits="MyCircles.Home.PeopleNearby" %>
<%@ Register assembly="Reimers.Google.Map" namespace="Reimers.Google.Map" TagPrefix="Reimers" %>

<asp:Content ID="SignedOutBase" ContentPlaceHolderID="SignedInContentPlaceholder" runat="server">


 <form id="form1" runat="server">
     
        <div>
       <table class="table table-hover">
        <thead>
        <tr>
        <th><h1 class="text-primary">Suggested</h1></th>
        
        </tr>
        </thead>
        
        <asp:Repeater ID="rptNearbyPost" runat="server" ItemType="MyCircles.BLL.User" OnItemDataBound="rptNearbyPost_ItemDataBound">
        <ItemTemplate>
        <tbody>
        <tr>
        <td><h3><%#DataBinder.Eval(Container.DataItem, "Username")%></h3>Follows U</td>
        <td> <asp:Button ID="btn1" runat="server" Text="Follow" class="btn btn-primary" style="border-radius:12px" data-toggle="popover" data-content=" Following"></asp:button> </td>
        </tr>
      <%--  <tr>
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
        </tr>--%>
        </tbody>
        </table>
                </ItemTemplate>
                        </asp:Repeater>
            <Reimers:Map ID="GMap" Width="100%" Height="400px" runat="server" />
        </div>

        
         
    </form>

 </asp:Content>


