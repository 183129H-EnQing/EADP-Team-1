using MyCircles.BLL;
using Reimers.Google.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace MyCircles.ItineraryPlanner
{
    public partial class LocationDetail : System.Web.UI.Page
    {
        int locId;
        Location alocation = new Location();
        List<Location> alocList = new List<Location>();
        protected void Page_Load(object sender, EventArgs e)
        {
            locId = Convert.ToInt32(Request.QueryString["locId"]);

            alocList = alocation.RetrieveALocation(locId);

            GetALocation();
            MapLocation();
        }

        private void GetALocation()
        {
            rpLocation.DataSource = alocList;
            rpLocation.DataBind();
        }

        private void MapLocation()
        {
            GMap.ApiKey = ConfigurationManager.AppSettings["MapKey"];

            foreach (Location i in alocList)
            {
                if (i.locaLatitude != null || i.locaLongitude != null)
                {
                    LatLng pos = new LatLng();
                    pos.Latitude = i.locaLatitude.HasValue ? i.locaLatitude.Value : 0;
                    pos.Longitude = i.locaLongitude.HasValue ? i.locaLongitude.Value : 0;

                    Marker locaMarker = new Marker(pos);
                    Marker overlayMarker = new Marker(pos);
                    locaMarker.ZIndex = locId;
                    overlayMarker.ZIndex = locId;

                    Icon locaIcon = new Icon();
                    locaIcon.ScaledSize = new Size(24, 24);
                    locaIcon.Anchor = new Point(12, 28);
                    locaMarker.Icon = locaIcon;

                    Icon overlayIcon = new Icon();
                    overlayIcon.ScaledSize = new Size(32, 32);
                    overlayMarker.Icon = overlayIcon;

                    if (Uri.IsWellFormedUriString(i.locaPic, UriKind.Absolute))
                    {
                        locaIcon.ImageUri = new Uri(i.locaPic);
                    }
                    else
                    {
                        locaIcon.ImageUri = new Uri(string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, i.locaPic));
                    }

                    if (i.locaId == locId)
                    {
                        GMap.Center = pos;
                    }


                    if (i.locaId == locId)
                    {
                        overlayIcon.ImageUri = new Uri(string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, "/Content/images/UserOutlineDefault.png"));
                        locaMarker.ZIndex = 98;
                        overlayMarker.ZIndex = 99;
                    }

                    locaMarker.Options.Name = i.locaName;
                    overlayMarker.Options.Name = i.locaName;

                    GMap.Overlays.Add(locaMarker);
                    GMap.Overlays.Add(overlayMarker);
                }
            }
        }
    }
}