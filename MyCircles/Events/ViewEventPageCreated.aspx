<%@ Page Title="" Language="C#" MasterPageFile="~/SignedIn.master" AutoEventWireup="true" CodeBehind="ViewEventPageCreated.aspx.cs" Inherits="MyCircles.Events.ViewEventPageCreated" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SignedInHeadPlaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SignedInContentPlaceholder" runat="server">
      <div class="container">
          <div class="row">
              <div class="col-12">
                  <table class="table table-bordered">
                <thead>
                    <tr>
                       <th>eventID</th>
                        <th>Date</th>
                        <th>Time</th>
                        <th>Edit</th>
                        <th>Delete</th>
                        <th>Notify</th>
                    </tr>
                </thead>
                      <form runat="server">
                <tbody>
                    <asp:Repeater ID="rpViewEventPageCreated" runat="server" ItemType="MyCircles.BLL.Event">
                        <ItemTemplate>                              
                            <tr>
                               <%-- <td><%#DataBinder.Eval(Container.DataItem, "eventId") %> </td>--%>
                                <td>
                                    <%#DataBinder.Eval(Container.DataItem, "eventId") %> 
                                </td>
                                <td>
                                    <%#DataBinder.Eval(Container.DataItem, "eventStartDate") %> - <%#DataBinder.Eval(Container.DataItem, "eventEndDate") %>
                                </td>
                                <td>
                                    <%#DataBinder.Eval(Container.DataItem, "eventStartTime") %> - <%#DataBinder.Eval(Container.DataItem, "eventEndTime") %>
                                </td>                               
                                 <td>
                                     <asp:Button ID="Button1" runat="server" Text="Edit" class="btn" type="Button" UseSubmitBehavior="False"/>
                                </td>    
                                <td>
                                     <asp:Button ID="Button2" runat="server" Text="Delete" class="btn" type="Button" UseSubmitBehavior="False"/>
                                </td>  
                                <td>
                                     <asp:Button ID="Button3" runat="server" Text="Notify" class="btn" type="Button" UseSubmitBehavior="False"/>
                                </td>  
                                
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
                      </form>
            </table>
              </div>
          </div>
      </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SignedInDeferredScriptsPlaceholder" runat="server">
</asp:Content>
