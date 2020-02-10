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
                                    <label class="eventId"><%#DataBinder.Eval(Container.DataItem, "eventId") %> </label>
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
                                    <button ID="notifyBtn" class="notifyBtn btn" type="Button" eventId=<%#DataBinder.Eval(Container.DataItem, "eventId") %> >Notify</button>
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
    <script>
        $(".notifyBtn").click(function () {
          //  alert($(this).attr("eventId"));
                var eventId = $(this).attr("eventId")
                ajaxHelper(`${signupeventdetailsUri}/${Number(eventId)}`, 'GET', null).done(function (data) {
                   // addNotificationToasts(data);
                    console.log(data);
                    for (i = 0; i < data.length; i++) {
                        console.log(data[i].userId)
                            addNotification({                 
                            Action: "Event has Stopped",
                            Source: "From Organizer",
                            UserId: data[i].userId,
                            Type: "negative",
                        });
                       

                      }
            });
        });

    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SignedInDeferredScriptsPlaceholder" runat="server">
</asp:Content>
