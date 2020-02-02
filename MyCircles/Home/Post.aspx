<%@ Page Language="C#"  MasterPageFile="~/SignedIn.Master" AutoEventWireup="true" CodeBehind="Post.aspx.cs" Inherits="MyCircles.Home.Post" %>

<asp:Content ID="SignedOutBase" ContentPlaceHolderID="SignedInContentPlaceholder" runat="server">

    <form id="form1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col">   <div class="card" style="width: 18rem;">
                    <div class="card-header">
                        <h3 class="text-dark">Upcoming Events</h3>
                        None.
                    </div>
                    <ul class="list-group list-group-flush">

                    </ul>
                </div>
            </div>
        </div>
        <div class="row d-flex">
            <div class="col d-flex justify-content-center">
                <div class="mt-3 border border-secondary panel-group" style =" border-radius:16px 16px; margin-left:430px;" >
                    <%--<form>--%>
                        <div class="form-group mb-2 mt-3">
                            <asp:TextBox ID="activity"  class="form-control" runat="server" placeholder="Post Your activity.." Width="800" required></asp:TextBox>
                        </div>
                        <div class="form-group justify-content-between d-flex">
                            <input id="fileupld" runat="server" type="file" class="btn" />
                            <asp:button id="btnUpload" type="file" text="Upload Image" class="btn"  runat="server"  accept="image/png,image/jpeg,image/jpg,image/gif" OnClick="UploadFile"></asp:button>
                            <asp:Button ID="btnPost" runat="server" Text="Post" class="btn btn-primary" style="border-radius:12px" OnClick="btnPost_Click"></asp:button>
                        </div>
                    <%--</form>--%>
                </div>
            </div>
            <div class="col-3 pl-0">
                <div class="card" style="width: 18rem;">
                    <div class="card-header">
                        <h3 class="text-info">Circles</h3>
                    </div>
                    <ul class="list-group list-group-flush">
                        <li class="list-group-item">#Guitar<asp:Button ID="Btncircle" runat="server" Text="Add"  usesubmitbehavior="false" class="btn btn-primary" data-toggle="popover" data-content="you have added this circle" style="border-radius:10px" OnClick="Btncircle_Click" ></asp:button></li>
                        <li class="list-group-item">#Starwars&nbsp<asp:Button ID="Btnc" runat="server" Text="Add" class="btn btn-primary" data-toggle="popover" data-content="you have added this circle" style="border-radius:10px"></asp:button></li>
                        <li class="list-group-item">#VisualStudio&nbsp<asp:Button ID="Button3" runat="server" Text="Add" class="btn btn-primary" style="border-radius:10px"></asp:button></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="row mt-3">
            <div class="col-3"></div>
            <div class="col-6">
                <div class="row">
                    <div class="col">
                        <asp:Repeater ID="rptUserPosts" runat="server" ItemType="MyCircles.DAL.UserPost">
                            <ItemTemplate>
                                <div class="card"  id="mypost"   runat="server">
                                    <div class=" card-header d-flex bd-highlight bg-muted mb-2  ">
			                            <div class="mr-auto p-1 bd-highlight">
                                            <h5><asp:Label runat="server"><%#DataBinder.Eval(Container.DataItem, "User.Username")%></asp:Label></h5>
			                            </div>
                                        <div>
                                            <h5>3.45</h5>
                                        </div>
                                        <div>
                                            <h5><%#DataBinder.Eval(Container.DataItem, "User.City")%></h5>
                                        </div>
                                        <div>
                                            <asp:ImageButton src="../Content/images/3dot.jpg" runat="server" OnClick="ImageButton2_Click" data-toggle="modal" width="20px" Height="15px"
					                        data-target="#reportModal" />
                                        </div>
                                        <div class="modal fade" id="reportModal">
						                    <div class="modal-dialog modal-dialog-centered">
							                    <div class="modal-content">
								                    <!-- Modal Header -->
								                    <div class="modal-header">
									                    <h4 class="modal-title">Report Image Or Title</h4>
									                    <button type="button" class="close" data-dismiss="modal">&times;</button>
								                    </div>
								                    <!-- Modal body -->
								                    <div class="modal-body">
									                    <label class="form-check">Innappropriate
										                    <input class="form-check-input" type="radio" name="report" id="Innappropriate"
											                    value="Innappropriate" checked>
										                    <span class="checkmark"></span>
									                    </label>
									                    <label class="form-check">Unfollow
										                    <input class="form-check-input" type="radio" name="report" id="Unfollow"
											                    value="Unfollow">
										                    <span class="checkmark"></span>
									                    </label>
									                    <label class="form-check"> Copy Link
										                    <input class="form-check-input" type="radio" name="report" id="Copy Link"
											                    value="Copy Link">
										                    <span class="checkmark"></span>
									                    </label>
								                    </div>
								                    <!-- Modal footer -->
								                    <div class="modal-footer">
									                    <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
									                    <button type="submit" id="butAddReport" class="btn btn-primary">Submit</button>
								                    </div>
							                    </div>
						                    </div>
				                        </div>
                                    </div>
                                    <div class="card-body">
			                            <div class="responsive">
				                            <div class="gallery text-center">
					                            <a target="_blank" href="../Content/images/81017379.jpg">
						                            <img src="<%#DataBinder.Eval(Container.DataItem, "Post.Image") %>" alt="Image unavailable"
							                            style="max-height: 300px; width: auto; border-radius:8px;">
					                            </a>
				                            </div>
                                            <span class="h5">
                                            <asp:Label runat="server" Text=""><%#DataBinder.Eval(Container.DataItem, "Post.Content")%></asp:Label></span>
			                            </div>
                                    </div>
                                    <div class="card-footer">
                                        <div class="d-flex justify-content-between">
				                            <strong>Comments:</strong>
				                            <div class="text-right">
					                            <a class="btn btn-primary text-light"> Create Comment</a>
			                                </div>
		                                </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
                <div class="row">
                    <div class="col"></div>
                </div>
            </div>
            <div class="col-3 pl-0">
                <div class="card" style="width: 18rem;">
                    <div class="card-header">
                        <h3 class="text-info">Connect To More</h3>
                    </div>
                    <ul class="list-group list-group-flush">
                        <li class="list-group-item">Jamal <br /> 1.2km <asp:Button ID="Btn55" runat="server" Text="Follow"  class="btn btn-primary" data-toggle="popover" data-content=" Following" style="border-radius:12px" ></asp:button></li>
                        <li class="list-group-item">Suresh <br /> 500m <asp:Button ID="Btn4" runat="server" Text="Follow" class="btn btn-primary" style="border-radius:12px"></asp:button></li>
                        <li class="list-group-item">Sarah <br /> 250m  <asp:Button ID="Btn44" runat="server" Text="Follow" class="btn btn-primary" style="border-radius:12px"></asp:button></li>
                        <li class="list-group-item"><asp:Button ID="btn6" runat="server" Text="More..." class="btn btn-secondary" style="border-radius:12px" OnClick="btn6_Click"></asp:button></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    </form>
</asp:Content>
