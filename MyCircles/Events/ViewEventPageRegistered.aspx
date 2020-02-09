<%@ Page Title="" Language="C#" MasterPageFile="~/SignedIn.master" AutoEventWireup="true" CodeBehind="ViewEventPageRegistered.aspx.cs" Inherits="MyCircles.Events.ViewEventPageRegistered" %>
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
                                <th>Slots Booked</th>
                                <th>Selected Event to participate</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rpViewEventPageRegistered" runat="server" ItemType="MyCircles.BLL.EventSchedule">
                                <ItemTemplate>
                                  
                                    <tr>
                                        <td><%#DataBinder.Eval(Container.DataItem, "startTime") %> - <%#DataBinder.Eval(Container.DataItem, "endTime") %></td>
                                        <td>
                                            <asp:Label ID="eventDescription" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "eventDescription") %>'> </asp:Label>
                                        </td>
                                        <td><asp:CheckBox ID="optInCB" runat="server" /></td>

                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SignedInDeferredScriptsPlaceholder" runat="server">
</asp:Content>
