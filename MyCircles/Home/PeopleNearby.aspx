<%@ Page Language="C#"  MasterPageFile="~/SignedIn.Master" AutoEventWireup="true" CodeBehind="PeopleNearby.aspx.cs" Inherits="MyCircles.Home.PeopleNearby" %>
<%@ Register assembly="Reimers.Google.Map" namespace="Reimers.Google.Map" TagPrefix="Reimers" %>

<asp:Content ID="SignedOutBase" ContentPlaceHolderID="SignedInContentPlaceholder" runat="server">

<style>
body {
width: 100%;
margin: 5px;
}

.table-condensed tr th {
border: 0px solid #6e7bd9;
color: white;
background-color: #6e7bd9;
}

.table-condensed, .table-condensed tr td {
border: 0px solid #000;
}

tr:nth-child(even) {
background: #f8f7ff
}

tr:nth-child(odd) {
background: #fff;
}
</style>

 <form id="form1" runat="server">
     
        <div>
        <h1 class="text-primary">Suggested</h1> 
       <asp:GridView ID="GridViewFollow"  AutoGenerateColumns ="False" CssClass="table table-condensed table-hover" runat="server">
           <Columns>
               <asp:ImageField DataImageUrlField="ProfileImage" ControlStyle-Width="40" ControlStyle-Height = "40"></asp:ImageField>         
               <asp:BoundField DataField="Username" HeaderText="Circle User's" />                            
               <asp:ButtonField CommandName="Follow" Text="Follow" ButtonType="Button" ControlStyle-CssClass="btn btn-info text-white" />
              
           </Columns>
       </asp:GridView>
                       
       <%-- <asp:Repeater ID="rptNearbyPost" runat="server" ItemType="MyCircles.BLL.User" OnItemDataBound="rptNearbyPost_ItemDataBound">
        <ItemTemplate>--%>
        <%--<tr>
            <td>
                <h3><%#DataBinder.Eval(Container.DataItem, "Username")%></h3>
                Follows U</td>
        <td> <asp:Button ID="btn1" runat="server" Text="Follow" class="btn btn-primary" style="border-radius:12px" data-toggle="popover" data-content=" Following"></asp:button> </td>
        </tr>--%>
       <%-- <tr>
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
                </ItemTemplate>
                        </asp:Repeater>--%>
            <Reimers:Map ID="GMap" Width="100%" Height="400px" runat="server" />
        </div>                
    </form>

 </asp:Content>


