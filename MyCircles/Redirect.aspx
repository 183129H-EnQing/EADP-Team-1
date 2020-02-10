<%@ Page Title="Redirecting... - MyCircles" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="Redirect.aspx.cs" Inherits="MyCircles.Redirect" %>

<asp:Content ID="RedirectHead" ContentPlaceHolderID="BaseHeadPlaceholder" runat="server">
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBlz2KBmeCFI5fsKZd0S0asMYbPIHOLpy0" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="RedirectContent" ContentPlaceHolderID="BaseContentPlaceholder" runat="server">
    <form runat="server" name="geolocationForm" id="geolocationForm" onsubmit="geolocationForm_Submit" class="h-100">
        <div class="container h-100">
	        <div class="row h-100 justify-content-center align-items-center">
                <figure class="redirect-logo">
                    <img src="/Content/images/MyCirclesIconStatic.png" alt="MyCircles Logo" id="redirectLogo">
                </figure>
                <div class="redirect-geolocation-fail" style="display: none;">
                    <span class="h4">Please enable location to have an optimal experience</span>
                </div>
            </div>
        </div>

        <div class="d-none">
            <div class="row form-group">
                <asp:TextBox ID="tbLat" runat="server" CssClass="form-control-lg m-1" type="hidden" placeholder="Latitude" ClientIDMode="Static"></asp:TextBox>
            </div>

            <div class="row form-group">
                <asp:TextBox ID="tbLong" runat="server" CssClass="form-control-lg m-1" type="hidden" placeholder="Longitude" ClientIDMode="Static"></asp:TextBox>
            </div>

            <div class="row form-group">
                <asp:TextBox ID="tbCity" runat="server" CssClass="form-control-lg m-1" type="hidden" placeholder="City" ClientIDMode="Static"></asp:TextBox>
            </div>

            <asp:Button ID="btSubmit" runat="server" CssClass="btn invisible" type="hidden" ClientIDMode="Static" OnClick="geolocationForm_Submit" />
        </div>
    </form>
</asp:Content>

<%-- TODO: Loading could be a pulse of the user's profile image --%>

<asp:Content ID="LocationScripts" ContentPlaceHolderID="DeferredScriptsPlaceholder" runat="server">
    <%-- below are common locations to simulate geolocation and check the city names --%>

    <%--Nanyang Poly = latlng = new google.maps.LatLng(1.380096, 103.848895);
    Sengkang = latlng = new google.maps.LatLng(1.393593, chr);
    Waterway Point (Punggol) = latlng = new google.maps.LatLng(1.407009, 103.902213); --%>

    <script>
        const latitudeInput = document.querySelector("#tbLat");
        const longitudeInput = document.querySelector("#tbLong");
        const cityInput = document.querySelector("#tbCity");
        const submitButton = document.querySelector("#btSubmit");
        const geolocationForm = document.querySelector("#geolocationForm");

        function success(position) {
            latitudeInput.setAttribute("value", position.coords.latitude);
            longitudeInput.setAttribute("value", position.coords.longitude);
            getCurrentCity(position.coords.latitude, position.coords.longitude)
                .then(currentCity => { cityInput.setAttribute("value", currentCity); })
                .catch(e => { cityInput.setAttribute("value", e); })
                .finally(f => { submitButton.click(); });
        }

        function error() {
            alert("We could not determine your location.")
            $("#redirect-logo").css("display", "none");
            $("#redirect-geolocation-fail").css("display", "block");
        }

        if (!navigator.geolocation) {
            error();
        } else {
            navigator.geolocation.getCurrentPosition(success, error);
        }
    </script>
</asp:Content>