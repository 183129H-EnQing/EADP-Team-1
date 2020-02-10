<%@ Page Title="" Language="C#" MasterPageFile="~/SignedIn.master" AutoEventWireup="true" CodeBehind="ViewEventPageRegistered.aspx.cs" Inherits="MyCircles.Events.ViewEventPageRegistered" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SignedInHeadPlaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SignedInContentPlaceholder" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <form runat="server">
                        <table class="table table-bordered">
                            <thead>
                                <tr>
                                    <th>eventID</th>
                                    <th>Date</th>
                                    <th>Time</th>
                                    <th>Slots Booked</th>
                                    <th>Selected Event to participate</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rpViewEventPageRegistered" runat="server" ItemType="MyCircles.BLL.SignUpEventDetail">
                                    <ItemTemplate>

                                        <tr>
                                            <td><%#DataBinder.Eval(Container.DataItem, "eventId") %></td>
                                             <td><%#DataBinder.Eval(Container.DataItem, "date") %></td>
                                            <td></td>
                                            <td><%#DataBinder.Eval(Container.DataItem, "numberOfBookingSlot") %></td>
                                            <% foreach (var x in startTimeList) {%>
                                            <td><%=x %></td>
                                            <%} %>

                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </form>
                </div>
            </div>
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SignedInDeferredScriptsPlaceholder" runat="server">
</asp:Content>
