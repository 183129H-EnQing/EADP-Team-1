<%@ Page Title="" Language="C#" MasterPageFile="~/SignedIn.master" AutoEventWireup="true" CodeBehind="SignUpFreeEventPage.aspx.cs" Inherits="MyCircles.SignUpFreeEventPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SignedInHeadPlaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SignedInContentPlaceholder" runat="server">
    <div class="container mt-3">
         <div class="card card-body">
             	<h4 class="text-primary">Registeration</h4>
                <div class="card card-body">
                    <form runat="server">
                      <div class="form-group">
                          <label for="inputName">Name</label>
                          <input type="text" class="form-control" name="name" required>
                      </div>
                      <div class="form-group">
                          <label for="inputDate">Date</label>
                          <input type="text" class="form-control" name="date" required>
                         <!-- <asp:TextBox ID="TextBox1" runat="server" type="text"  class="form-control"></asp:TextBox> -->
                      </div>
                      <div class="form-group">
                          <label for="inputContactNumber">ContactNumber</label>
                          <input type="number" class="form-control" name="number" required>
                      </div>
                      <div class="form-group">
                          <label for="inputNumberOfBookingSlots">Number of Booking slots</label>
                          <select class="form-control" name="NumberOfBookingSlots" required>
                            <option>1</option>
                            <option>2</option>
                            <option>3</option>
                            <option>4</option>
                            <option>5</option>
                          </select>
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
                                          
                                          <tr>
                                            <td>09:00 - 13:00</td>
                                            <td>Introduction to information technology and different sectors in IT</td>
                                            <td> 
                                                  <label class="checkbox-inline">
                                                    <input type="checkbox" value="">
                                                  </label>
                                            </td>
                                          </tr>
                                          <tr>
                                            <td>13:00 - 14:00</td>
                                            <td>Break</td>
                                            <td></td>
                                          </tr>
                                          <tr>
                                            <td>14:00 - 18:00
                                               
                                            </td>
                                            <td>Career In Information Technology</td>
                                            <td>
                                                  <label class="checkbox-inline">
                                                    <input type="checkbox" value="">
                                                  </label>
                                            </td>
                                          </tr>
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
