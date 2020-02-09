using MyCircles.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyCircles.ItineraryPlanner
{
    public partial class ViewLocation : System.Web.UI.Page
    {
        MyCirclesEntityModel db = new MyCirclesEntityModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            loadAllLocations();
        }

        private void loadAllLocations()
        {
            Location location = new Location();
            List<Location> locationList = new List<Location>();

            locationList = location.RetrieveAllLocation();

            rpLocation.DataSource = locationList;
            rpLocation.DataBind();
        }

        private void selectItemTag()
        {
            Location locationTag = new Location();
            List<Location> locationTagList = new List<Location>();

            if (chbBeaches.Checked)
            {
                List<Location> beachList = locationTag.RetrieveByTag(1);
                foreach (Location beachLoc in beachList)
                {
                    locationTagList.Add(beachLoc);
                }
            }
            if (chbOutdoors.Checked)
            {
                List<Location> outdoorList = locationTag.RetrieveByTag(2);
                foreach (Location outdoorLoc in outdoorList)
                {
                    locationTagList.Add(outdoorLoc);
                }
            }
            if (chbMuseums.Checked)
            {
                List<Location> museumList = locationTag.RetrieveByTag(3);
                foreach (Location museumLoc in museumList)
                {
                    locationTagList.Add(museumLoc);
                }
            }
            if (chbHistoric.Checked)
            {
                List<Location> historicList = locationTag.RetrieveByTag(4);
                foreach (Location historicLoc in historicList)
                {
                    locationTagList.Add(historicLoc);
                }
            }
            if (chbShopping.Checked)
            {
                List<Location> shoppingList = locationTag.RetrieveByTag(5);
                foreach (Location shoppingLoc in shoppingList)
                {
                    locationTagList.Add(shoppingLoc);
                }
            }
            if (chbWildlife.Checked)
            {
                List<Location> wildlifeList = locationTag.RetrieveByTag(6);
                foreach (Location wildLoc in wildlifeList)
                {
                    locationTagList.Add(wildLoc);
                }
            }

            rpLocation.DataSource = locationTagList;
            rpLocation.DataBind();

            if (chbBeaches.Checked == false && chbOutdoors.Checked == false && chbMuseums.Checked == false && chbHistoric.Checked == false && chbShopping.Checked == false && chbWildlife.Checked == false)
            {
                loadAllLocations();
            }
        }

        protected void chbBeaches_CheckedChanged(object sender, EventArgs e)
        {
            selectItemTag();
        }

        protected void chbOutdoors_CheckedChanged(object sender, EventArgs e)
        {
            selectItemTag();
        }

        protected void chbMuseums_CheckedChanged(object sender, EventArgs e)
        {
            selectItemTag();
        }

        protected void chbHistoric_CheckedChanged(object sender, EventArgs e)
        {
            selectItemTag();
        }

        protected void chbShopping_CheckedChanged(object sender, EventArgs e)
        {
            selectItemTag();
        }

        protected void chbWildlife_CheckedChanged1(object sender, EventArgs e)
        {
            selectItemTag();
        }

        protected void chkShowPlanItems_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}