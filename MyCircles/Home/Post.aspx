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
    </style>



<form id="form1" runat="server">
    <div class="container">
        <div class="row mt-3">
            <div class="col-md-4 col-lg-3 d-none d-lg-block">
                 <div class="card">
                    <div class="card-header">
                        <h3 class="text-info">Circles</h3>
                    </div>
                    <ul class="list-group list-group-flush">
                        <li class="list-group-item d-flex justify-content-between align-items-center">
                            <div>#Guitar</div>
                            <div>
                                <asp:Button ID="Btncircle" runat="server" Text="Add"  usesubmitbehavior="false" class="btn btn-primary" data-toggle="popover" data-content="you have added this circle" style="border-radius:10px" OnClick="Btncircle_Click" ></asp:button>
                            </div>
                        </li>
                        <li class="list-group-item d-flex justify-content-between align-items-center">
                            <div>#Starwars</div>
                            <div>
                                <asp:Button ID="Btnc" runat="server" Text="Add" class="btn btn-primary" data-toggle="popover" data-content="you have added this circle" style="border-radius:10px"></asp:button>
                            </div>
                        </li>
                        <li class="list-group-item d-flex justify-content-between align-items-center">
                            <div>#VisualStudio</div>
                            <div>
                                <asp:Button ID="Button3" runat="server" Text="Add" class="btn btn-primary" style="border-radius:10px"></asp:button>
                            </div>
                        </li>
                    </ul>
                <%-- <div class="col">   <div class="card" style="width: 18rem;">
                            <div class="card-header">
                                <h3 class="text-dark">Upcoming Events</h3>
                                None.
                            </div>
                            <ul class="list-group list-group-flush">

                            </ul>
                        </div>
                    </div>--%>
                </div>
            </div>
            <div class="col-sm-12 col-md-12 col-lg-7">
                <div class="row">
                    <div class="col">
                        <div class="border border-secondary px-3" style =" border-radius:16px 16px;" >
                            <div class="form-group mb-2 mt-3">
                                <asp:TextBox ID="activity"  class="form-control" runat="server" placeholder="Post Your activity.." Width="400" ></asp:TextBox>
                            </div>
                            <div class="form-group justify-content-between d-flex">
                                <div>
                                    <asp:FileUpload ID="FileUpload1"  runat="server" />                         
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
                                                    </h5>                                                
                                                </div>                                             
                                                <div> 
                                                     <a id="mod" href="#"  onclick="openViewPostModal(<%#DataBinder.Eval(Container.DataItem, "Post.Id")%>)"></a>
                                                </div>
                                            </div>                                          
                                            <div class="text-center">
                                            <img src="<%#DataBinder.Eval(Container.DataItem, "Post.Image") %>" style="max-height: 300px; width: auto; border-radius:8px;" 
                                                class="card-image">
                                                </div>                                                
                                            <div class="card-body">
                                                <div class="card-text">
                                                    <span class="h5">
                                                        <asp:Label runat="server" Text=""><%#DataBinder.Eval(Container.DataItem, "Post.Content")%></asp:Label>
                                                    </span>
                                                </div>
                                                <div class="d-flex justify-content-end">
                                                    <p><%#DataBinder.Eval(Container.DataItem, "Post.DateTime","{0:t}")%>, <%#DataBinder.Eval(Container.DataItem, "User.City")%></p>
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
                                            <asp:Repeater ID="rptComment" runat="server" EnableViewState="false"  ItemType="MyCircles.DAL.UserComment">
                                                <ItemTemplate>
                                                    <div class="m-3">
                                                        <div class="media mb-3">
                                                            <img src="" class="rounded-circle mr-2" style="width: 50px;">
                                                            <div class="media-body">
                                                                <h4><%#DataBinder.Eval(Container.DataItem, "User.Username")%><small> <i>Posted on<%#DataBinder.Eval(Container.DataItem, "Comment.comment_date","{0:t}")%> </i></small></h4>
                                                                <p class="mb-0"><%#DataBinder.Eval(Container.DataItem, "Comment.comment_text")%></p>                                                            
                                                                  <asp:Button ID ="remove"  runat ="server" class="btn btn-warning  p-1 pl-2 pr-2"  style="font-size: 12px;" CommandName ="Remove" CommandArgument=<%#DataBinder.Eval(Container.DataItem, "Comment.Id")%> Text="remove" />                                                             
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
            <div class="col-lg-2 col-12">
                <div class="card">
                    <div class="card-header">
                        <h3 class="text-info">Connect</h3></div>
                    <ul class="list-group list-group-flush">
                       <li class="list-group-item d-flex justify-content-between align-items-center">
                            <div>Jamal</div>
                            <div>
                                <asp:Button ID="Button1" runat="server" Text="Follow"  usesubmitbehavior="false" class="btn btn-primary" data-toggle="popover" data-content="you have added this circle" style="border-radius:10px" OnClick="Btncircle_Click" ></asp:button>
                            </div>
                        </li>
                        <li class="list-group-item d-flex justify-content-between align-items-center">
                            <div>Suresh</div>
                            <div>
                                <asp:Button ID="Button2" runat="server" Text="Follow" class="btn btn-primary" data-toggle="popover" data-content="you have added this circle" style="border-radius:10px"></asp:button>
                            </div>
                        </li>
                        <li class="list-group-item d-flex justify-content-between align-items-center">
                            <div>Vishnu</div>
                            <div>
                                <asp:Button ID="Button4" runat="server" Text="Follow" class="btn btn-primary" style="border-radius:10px"></asp:button>
                            </div>
                        </li >
                        <li class="list-group-item"><asp:Button ID="btn6" runat="server" Text="More..." class="btn btn-secondary" style="border-radius:12px"  usesubmitbehavior="false" OnClick="btn6_Click"></asp:button></li>
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

