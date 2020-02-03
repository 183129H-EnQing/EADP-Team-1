<%@ Page Title="" Language="C#" MasterPageFile="~/SignedIn.master" AutoEventWireup="true" CodeBehind="SignUpFreeEventPage.aspx.cs" Inherits="MyCircles.SignUpFreeEventPage" %>
<%@ Import Namespace ="MyCircles.BLL"%>
<asp:Content ID="Content1" ContentPlaceHolderID="SignedInHeadPlaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SignedInContentPlaceholder" runat="server">
    <div class="container mt-3">
         <div class="card card-body">
             	<h4 class="text-primary">Registeration</h4>
                <div class="card card-body">
                  <form runat="server">
                      <div class="form-group">
                          <label>Name</label>
                          <asp:TextBox type="text" class="form-control" ID="nameTB" runat="server"></asp:TextBox>
                      </div>
                      <div class="form-group">
                     
                           <label>Date</label>
                            <asp:DropDownList ID="dateDDL" runat="server" class="form-control">

                            </asp:DropDownList>
                        
                      </div>
                      <div class="form-group">
                          <label for="inputContactNumber">ContactNumber</label>
                           <asp:TextBox type="number" class="form-control" ID="contactNumberTB" runat="server"></asp:TextBox>
                      </div>
                      <div class="form-group">
                          <label for="inputNumberOfBookingSlots">Number of Booking slots</label>
                          <asp:DropDownList ID="NumberOfBookingSlotsDLL" class="form-control" runat="server" ClientIDMode="Static">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                        </asp:DropDownList>
                      </div>
                
                         <table class="table table-bordered">
                                        <thead>
                                          <tr>
                                            <th class="w-25">Time</th>
                                            <th class="w-50">Description</th>
                                            <th class="w-25">Opt in</th>
                                          </tr>
                                        </thead>
                                        <tbody>
                                           <asp:Repeater ID="rpEventSchedule" runat="server" ItemType="MyCircles.BLL.EventSchedule">
                                             <ItemTemplate>                 
                                                <%# Container.ItemIndex + 1 %>
                                              <tr>
                                                <td><%#DataBinder.Eval(Container.DataItem, "startTime") %> - <%#DataBinder.Eval(Container.DataItem, "endTime") %></td>
                                                <td><%#DataBinder.Eval(Container.DataItem, "eventDescription") %></td>
                                                  <!--add tb to the thing-->
                                                <td>
                                                    <asp:CheckBox ID="optInCB" runat="server" /></td>
                                              </tr>
                                             </ItemTemplate>
                                           </asp:Repeater>
                                        </tbody>
                                      </table>
                            <asp:Button ID="submitButt"  runat="server" Text="Submit" CssClass="form-check-label btn btn-success btn-block mt-2" OnClick="submitButt_Click"/>
                    </form>
                </div>
        </div>
    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SignedInDeferredScriptsPlaceholder" runat="server">

</asp:Content>
