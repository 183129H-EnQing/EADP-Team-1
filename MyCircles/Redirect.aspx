<%@ Page Title="Redirecting... - MyCircles" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="Redirect.aspx.cs" Inherits="MyCircles.Redirect" %>

<asp:Content ID="RedirectContent" ContentPlaceHolderID="BaseContentPlaceholder" runat="server">
    <form runat="server" name="geolocationForm" id="geolocationForm" onsubmit="geolocationForm_Submit">
        <div class="container h-100">
	        <div class="row h-100 justify-content-center align-items-center text-center">
		        Loading...
	        </div>
        </div>

	    <div class="row form-group">
		    <asp:TextBox ID="tbLat" runat="server" CssClass="form-control-lg m-1" type="hidden" placeholder="Latitude" ClientIDMode="Static"></asp:TextBox>
	    </div>

	    <div class="row form-group">
		    <asp:TextBox ID="tbLong" runat="server" CssClass="form-control-lg m-1" type="hidden" placeholder="Longitude" ClientIDMode="Static"></asp:TextBox>
	    </div>

        <asp:Button ID="btSubmit" runat="server" CssClass="btn" type="hidden" ClientIDMode="Static" OnClick="geolocationForm_Submit" />
    </form>
</asp:Content>

<asp:Content ID="LocationScripts" ContentPlaceHolderID="DeferredScriptsPlaceholder" runat="server">
    <%-- below are common locations to simulate geolocation and check the city names --%>

    <%--Nanyang Poly = latlng = new google.maps.LatLng(1.380096, 103.848895);
    Sengkang = latlng = new google.maps.LatLng(1.393593, chr);
    Waterway Point (Punggol) = latlng = new google.maps.LatLng(1.407009, 103.902213); --%>

    <script>
        const latitudeInput = document.querySelector("#tbLat");
        const longitudeInput = document.querySelector("#tbLong");
        const submitButton = document.querySelector("#btSubmit");
        const geolocationForm = document.querySelector("#geolocationForm");

        function success(position) {
            latitudeInput.setAttribute("value", position.coords.latitude);
            longitudeInput.setAttribute("value", position.coords.longitude);
            submitButton.click();
        }

        function error() {
            alert("We could not determine your location.")
            submitButton.click();
        }

        if (!navigator.geolocation) {
            error();
        } else {
            navigator.geolocation.getCurrentPosition(success, error);
        }
    </script>
</asp:Content>