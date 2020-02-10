<%@ Page Language="C#"  MasterPageFile="~/SignedIn.Master" AutoEventWireup="true" CodeBehind="Post.aspx.cs" Inherits="MyCircles.Home.Post" %>

<asp:Content ID="SignedOutBase" ContentPlaceHolderID="SignedInContentPlaceholder" runat="server">
  
   
<style>
#mod {
    position: relative;
    background-color: grey;
    border-radius: 5px;
    font-size: 0;
    margin-left: 20px;
    padding: 5px;
}

#mod:before {
    position: absolute;
    left: -20px;
    top: 0;
    content: '';

    background-color: grey;
    border-radius: 5px;
    font-size: 0;
    padding: 5px;
}

#mod:after {
    position: absolute;
    left: 20px;
    top: 0;
    content: '';
    background-color: grey;
    border-radius: 5px;
    font-size: 0;    
    padding: 5px;
}

.form-check {
	display: block;
	position: relative;
	padding-left: 35px;
	margin-bottom: 12px;
	cursor: pointer;
	font-size: 22px;
	-webkit-user-select: none;
	-moz-user-select: none;
	-ms-user-select: none;
	user-select: none;
}

/* Hide the browser's default radio button */
.form-check input {
	position: absolute;
	opacity: 0;
	cursor: pointer;
	height: 0;
	width: 0;
}

/* Create a custom radio button */
.checkmark {
	position: absolute;
	top: 0;
	left: 0;
	height: 25px;
	width: 25px;
	background-color: #eee;
	border-radius: 50%;
}

/* On mouse-over, add a grey background color */
.form-check:hover input~.checkmark {
	background-color: #ccc;
}

/* When the radio button is checked, add a blue background */
.form-check input:checked~.checkmark {
	background-color: #2196F3;
}

/* Create the indicator (the dot/circle - hidden when not checked) */
.checkmark:after {
	content: "";
	position: absolute;
	display: none;
}

/* Show the indicator (dot/circle) when checked */
.form-check input:checked~.checkmark:after {
	display: block;
}

/* Style the indicator (dot/circle) */
.form-check .checkmark:after {
	top: 9px;
	left: 9px;
	width: 8px;
	height: 8px;
	border-radius: 50%;
	background: white;
}

.custom-select {
  position: relative;
  font-family: Arial;
}

.custom-select select {
  display: none; /*hide original SELECT element: */
}

.select-selected {
  background-color: DodgerBlue;
}

/* Style the arrow inside the select element: */
.select-selected:after {
  position: absolute;
  content: "";
  top: 14px;
  right: 10px;
  width: 0;
  height: 0;
  border: 6px solid transparent;
  border-color: #fff transparent transparent transparent;
}

/* Point the arrow upwards when the select box is open (active): */
.select-selected.select-arrow-active:after {
  border-color: transparent transparent #fff transparent;
  top: 7px;
}

/* style the items (options), including the selected item: */
.select-items div,.select-selected {
  color: #ffffff;
  padding: 8px 16px;
  border: 1px solid transparent;
  border-color: transparent transparent rgba(0, 0, 0, 0.1) transparent;
  cursor: pointer;
}

/* Style items (options): */
.select-items {
  position: absolute;
  background-color: DodgerBlue;
  top: 100%;
  left: 0;
  right: 0;
  z-index: 99;
}

/* Hide the items when the select box is closed: */
.select-hide {
  display: none;
}

.select-items div:hover, .same-as-selected {
  background-color: rgba(0, 0, 0, 0.1);
}

 
    </style>



<form id="form1" runat="server">
    <div class="container">
        <div class="row mt-3">
            <div class="col-md-4 col-lg-3 d-none d-lg-block">               
                 <div class="card">
                    <div class="card-header">
                        <h3 class="text-info">Your Circles</h3>
                    </div>
                    <ul class="list-group list-group-flush">
                        <li class="list-group-item d-flex justify-content-between align-items-center">                            
                            <div>
                                <asp:DropDownList ID="DropDownList2" CssClass="custom-select "   Width="200" runat="server">
                                </asp:DropDownList>
                            </div>
                        </li>                       
                        <li class="list-group-item d-flex justify-content-between align-items-center">
                            <div>Add Circles..</div>
                            <div>
                                <asp:Button ID="Button3" runat="server" Text="Add" OnClick="Button3_Click"  class="btn btn-primary" style="border-radius:10px"></asp:button>
                            </div>
                        </li>
                    </ul>             
                </div>
            </div>
            <div class="col-sm-12 col-md-12 col-lg-6">
                <div class="row">
                    <div class="col">
                        <div class="border border-secondary px-3" style =" border-radius:16px 16px;" >
                            <div class="form-group mb-2 mt-3">
                            <div class="form-group justify-content-between d-flex">
                                <div>
                                     <asp:TextBox ID="activity"  class="form-control" runat="server" placeholder="Post Your activity.." Width="400" ></asp:TextBox>
                                </div>
                                <div>
                                <asp:DropDownList ID="DropDownList1"  CssClass="btn btn-info dropdown-toggle" runat="server"  ></asp:DropDownList>
                                </div>                                                              
                            </div>
                               </div>
                            <div class="form-group justify-content-between d-flex">
                                <div>
                                    <asp:FileUpload ID="FileUpload1" CssClass="btn btn-default" runat="server" />                         
                                </div>
                                <div>
                                    <asp:Button ID="btnPost" runat="server" Text="Post" CssClass="btn btn-primary" style="border-radius:12px" OnClick="btnPost_Click"></asp:button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>           
                <div class="row mt-3">
                    <div class="col">
                        <asp:Repeater ID="rptUserPosts" runat="server" EnableViewState="false" ItemType="MyCircles.DAL.UserPost" OnItemDataBound="rptUserPosts_ItemDataBound" OnItemCommand="rptUserPosts_ItemCommand">
                            <ItemTemplate>
                                <div class="row">
                                    <div class="col">
                                        <div class="card" id="mypost" runat="server">
                                            <div class="card-header p-2 d-flex justify-content-between">
                                                <div class="mr-auto p-1">
                                                    <h5>
                                                        <asp:Label runat="server"><%#DataBinder.Eval(Container.DataItem, "User.Username")%></asp:Label>
                                                         <h6><span class="badge badge-secondary"><%#DataBinder.Eval(Container.DataItem, "Post.CircleId")%></span></h6>
                                                    </h5>                                                
                                                </div>                                             
                                                <div>                                                                                                                                                                                                                                                  
                                                <div class="dropdown show">                                                
                                                    <a class="btn btn-info dropdown-toggle" href="#" role="button" id="dropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                        <i class='fa fa-ellipsis-v'></i>
                                                    </a>
                                                    <div class="dropdown-menu" aria-labelledby="dropdownMenuLink<%#DataBinder.Eval(Container.DataItem, "Post.Id")%>">                                                
                                                        <asp:Button ID="Delete" runat="server" CssClass="dropdown-item" CommandName="Delete"  CommandArgument='<%#DataBinder.Eval(Container.DataItem, "Post.Id")%>'  Text="Delete" />
                                                        <a class="dropdown-item" ID="Report" href="#"  onclick="openViewPostModal(<%#DataBinder.Eval(Container.DataItem, "Post.Id")%>)">Report</a>
                                                    </div>
                                                </div> 
                                                     
                                                </div>
                                            </div>                                          
                                            <div class="text-center">
                                            <img src="<%#DataBinder.Eval(Container.DataItem, "Post.Image") %>" style="max-height: 300px; width: auto; border-radius:8px;" 
                                                class="card-image">
                                                </div>                                                
                                            <div class="card-body pt-0">
                                                <div class="card-text">
                                                    <span class="h5">
                                                        <asp:Label runat="server" Text="" ><%#DataBinder.Eval(Container.DataItem, "Post.Content")%></asp:Label>
                                                    </span>
                                                </div>
                                                <div class="d-flex justify-content-end">
                                                    <p><%#DataBinder.Eval(Container.DataItem, "Post.DateTime","{0:d/MM/yyyy}")%>, <%#DataBinder.Eval(Container.DataItem, "Post.DateTime","{0:t}")%>, <%#DataBinder.Eval(Container.DataItem, "User.City")%></p>
                                                </div>
                                            </div>
                                            <div class="card-footer">
                                                <div class="d-flex justify-content-between">
                                                    <div class="form-group col-md-6">
                                                        <asp:TextBox ID="hello" class="form-control" runat="server" placeholder="Comment here"></asp:TextBox>
                                                        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>&nbsp<asp:Label ID="Label1" runat="server" Text=""><%#DataBinder.Eval(Container.DataItem, "Post.Comment")%></asp:Label>
                                                    </div>
                                                    <div class="text-right">                                                    
                                                        <asp:Button ID="Comment" runat="server" class="btn btn-primary text-light" usesubmitbehavior="true"  CommandName="Comment" CommandArgument=<%#DataBinder.Eval(Container.DataItem, "Post.Id")%> Text="Comment" />
                                                    </div>
                                                </div>
                                            </div>
                                            <asp:Repeater ID="rptComment" runat="server" OnItemCommand="rptComment_ItemCommand" OnItemDataBound="rptComment_ItemDataBound"   EnableViewState="false"   ItemType="MyCircles.DAL.UserComment">
                                                <ItemTemplate>
                                                    <div class="m-3">
                                                        <div class="media mb-3">
                                                            <img src="<%#DataBinder.Eval(Container.DataItem, "User.ProfileImage")%>" class="rounded-circle mr-2" style="width: 50px;">
                                                            <div class="media-body">
                                                                <h4><%#DataBinder.Eval(Container.DataItem, "User.Username")%><small> <i>Posted <%#DataBinder.Eval(Container.DataItem, "Comment.comment_date","{0:t}")%></i></small></h4>
                                                                <p class="mb-0"><%#DataBinder.Eval(Container.DataItem, "Comment.comment_text")%></p>                                                            
                                                                  <asp:Button ID ="remove"  runat ="server" class="btn btn-warning  p-1 pl-2 pr-2"  style="font-size: 12px;" CommandName="Remove" CommandArgument=<%#DataBinder.Eval(Container.DataItem, "Comment.Id")%> Text="remove" />                                                             
                                                            </div>
                                                        </div>                                              
                                                    </div>

                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                        <div class="modal fade" id="modal<%#DataBinder.Eval(Container.DataItem, "Post.Id")%>" >
                                            <div class="modal-dialog modal-dialog-centered">
                                                <div class="modal-content">
                                                    <!-- Modal Header -->
                                                    <div class="modal-header">
                                                        <h4 class="modal-title">Report Image Or Title</h4>
                                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                    </div>
                                                    <!-- Modal body -->
                                                    <div class="modal-body">  
                                                        <asp:RadioButtonList ID="RadioButtonList1" runat="server">

                                                                <asp:ListItem Selected="True">Innappropriate</asp:ListItem>
                                                                <asp:ListItem>Spam and Misleading</asp:ListItem>
                                                                <asp:ListItem>Pirated</asp:ListItem>
                                                        </asp:RadioButtonList> 
                                                        <%--   
                                                        <label class="form-check">
                                                            Innappropriate Post
										                    <input class="form-check" type="radio" name="report" id="Innappropriate"
                                                                value="Innappropriate" checked="checked">
                                                                <span class="checkmark"></span>
                                                        </label>
                                                        <label class="form-check">Share
										                    <input class="form-check-input" type="radio" name="report" id="Share"
                                                                value="Unfollow">
                                                            <span class="checkmark"></span>
                                                        </label>
                                                        <label class="form-check">Copy Link
										                    <input class="form-check-input" type="radio" name="report" id="Copy Link"
                                                                value="Copy Link">
                                                            <span class="checkmark"></span>
                                                        </label>--%>
                                                    </div>
                                                    <!-- Modal footer -->
                                                    <div class="modal-footer">
                                                        <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>                      
                                                        <asp:Button ID="report" runat="server"  class="btn btn-primary" Text="Submit" CommandName="Report"  CommandArgument=<%#DataBinder.Eval(Container.DataItem, "Post.Id")%>/>
                                                    </div>    
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
            <div class="col-lg-3 col-12">
                <div class="card">
                    <div class="card-header">
                        <h3 class="text-info">Sugested</h3></div>
                    <ul class="list-group list-group-flush">
                        
                    <asp:Repeater ID="Repeater1" runat="server" ItemType="MyCircles.BLL.User">
                        <ItemTemplate>
        
                             <li class="list-group-item d-flex justify-content-between align-items-center">
                            <div><h6><%#DataBinder.Eval(Container.DataItem, "Username")%></h6> <p><small><%#DataBinder.Eval(Container.DataItem, "City")%></small></p></div>
                            <div>
                                <img src=<%#DataBinder.Eval(Container.DataItem, "ProfileImage")%> class="rounded-circle mr-2" style="width: 50px;">
                              
                            </div>
                        </li>                             
                        </ItemTemplate>
                    </asp:Repeater>                                                               
                        <li class="list-group-item"><asp:Button ID="btn6" runat="server" Text="Follow Them" class="btn btn-primary" style="border-radius:12px"  usesubmitbehavior="false" OnClick="btn6_Click"></asp:button></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</form>
<script>
    function openViewPostModal(id) {
        $("#modal" + id).modal('show');                                                  
    }

   
</script>

      
</asp:Content>

