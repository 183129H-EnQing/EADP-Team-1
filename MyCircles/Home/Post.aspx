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
            <div class="card mb-3">
                <div class="card-header d-flex justify-content-between bg-secondary">
			<div>
			       <h3>Username</h3>
			</div>
                    <div>
                         <h3>Time</h3>
                    </div>
                    <div>
                         <h3>Location</h3>
                        
                        <asp:ImageMap src="../Content/images/JustMeetIcon.png" ID="ImageMap1"  runat="server" OnClick="ImageMap1_Click"></asp:ImageMap>
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
