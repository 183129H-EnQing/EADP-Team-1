using Reimers.Google.Map;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyCircles.Home
{
    public partial class PeopleNearby : System.Web.UI.Page
    {
        public BLL.User currentUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            RedirectValidator.isUser();
            currentUser = (BLL.User)Session["currentUser"];

            var nearby = new BLL.User();
            



            GMap.ApiKey = ConfigurationManager.AppSettings["MapKey"];

            if (currentUser.Latitude != null || currentUser.Longitude != null)
            {
                LatLng currentPos = new LatLng();
                double currentLat = (this.currentUser.Latitude.HasValue) ? this.currentUser.Latitude.Value : 0;
                double currentLng = (this.currentUser.Longitude.HasValue) ? this.currentUser.Longitude.Value : 0;

                currentPos.Latitude = currentLat;
                currentPos.Longitude = currentLng;
                if (!Page.IsPostBack) GMap.Center = currentPos;
                var marker = new Marker(currentPos);

                GMap.Overlays.Add(marker);
            }
        }
    }
}