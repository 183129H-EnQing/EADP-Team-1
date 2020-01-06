<%@ Page Language="C#"  MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="HomePost.aspx.cs" Inherits="MyCircles.HomePost.HomePost" %>

<asp:Content ID="SignedOutBase" ContentPlaceHolderID="BaseContentPlaceholder" runat="server">
    
  <form id="form1" runat="server">
        <div>
            <div class="card-body">
            <div class="row  mt-5">
            <h2>Upcoming Events</h2>
             
                </div>
                </div>
            <div class="container">
            <div class="row d-flex justify-content-center">
            <div id="accordion" class="col-md-5 border border-secondary panel-group" style =" border-radius:16px 16px">
            <div class="form-group">
                 <div class="row mb-2 mt-3">
                         <asp:TextBox ID="activity"  class="form-control" runat="server" placeholder="Post Your activity.." required></asp:TextBox>
                    </div>
                <div class="form-group">
                <div class="row sm-1">
                <asp:button id="btnUpload" type="submit" text="Upload Image" class="btn" runat="server" ></asp:button> 
                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                <asp:Button ID="Post" runat="server" Text="Post" class="btn btn-primary" style="border-radius:12px"></asp:button> 
                </div>
            </div>
            </div> 
            </div>
            </div>
            </div>
      <
        </div>
    </form>
</asp:Content>
