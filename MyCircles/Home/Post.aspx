<%@ Page Language="C#"  MasterPageFile="~/SignedIn.Master" AutoEventWireup="true" CodeBehind="Post.aspx.cs" Inherits="MyCircles.Home.Post" %>

<asp:Content ID="SignedOutBase" ContentPlaceHolderID="SignedInContentPlaceholder" runat="server">
    
  <form id="form1" runat="server">
        <div>
            <div class="card-body">
            <div>
            <h2>Upcoming Events</h2>
             
                </div>
                </div>
            <div class="container">
            <div class="row d-flex justify-content-center">
            <div id="accordion" class="col-md-6 mt-3 border border-secondary panel-group" style =" border-radius:16px 16px">
            <div class="form-group">
                 <div class="row mb-2 mt-3">
                         <asp:TextBox ID="activity"  class="form-control" runat="server" placeholder="Post Your activity.." required></asp:TextBox>
                    </div>
                <div class="form-group">
                <div >
                <asp:button id="btnUpload" type="submit" text="Upload Image" class="btn" runat="server" ></asp:button> 
                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                <asp:Button ID="btnPost" runat="server" Text="Post" class="btn btn-primary" style="border-radius:12px"></asp:button> 
                </div>
            </div>
            </div> 
            </div>
            </div>
            </div>
            </div>
            <div class="row d-flex justify-content-center">
            <div class="card">
               <div class=" card-header d-flex bd-highlight bg-muted mb-3">
			<div class="mr-auto p-2 bd-highlight">
			       <h5><asp:Label ID="lblUsername" runat="server"  ></asp:Label></h5>
			</div>
                    <div>
                         <h3>Time</h3>
                    </div>
                    <div>
                         <h3>Location</h3>
                    </div>
                    <div>
                        <asp:ImageButton ID="ImageButton2" src="../Content/images/3dot.jpg" runat="server" OnClick="ImageButton2_Click" data-toggle="modal" width="20px" Height="15px"
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

                    
			<div>
				
			</div>
		</div>
            <div class ="form-group">
                  <div class="card-body">
			<h5 class="card-title" > Tittle </h5>
			<p class="card-text"> Content</p>
			
			
			<div class="responsive">
				<div class="gallery">
					<a target="_blank" href="">
						<img src="" alt="Image unavailable"
							style="max-height: 300px; width: auto; border-radius:8px;">
					</a>
				</div>
			</div>
		</div>
        </div>
                </div>
                </div>
    </form>
</asp:Content>
