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
            Location location = new Location();
            List<Location> locationList = new List<Location>();

            locationList = location.RetrieveAllLocation(); 

            rpLocation.DataSource = locationList;
            rpLocation.DataBind();
        }

        private void selectItemTag(int tagId)
        {
            Location locationTag = new Location();
            List<Location> locationTagList = new List<Location>();

            locationTagList = locationTag.RetrieveByTag(tagId);

            rpLocation.DataSource = locationTagList;
            rpLocation.DataBind();
        }

        private void selectItemTagS()
        {
            string tagId = "";

            if (chbBeaches.Checked == true)
            {
                tagId += "1";
            }
            if (chbOutdoors.Checked == true)
            {
                tagId += "2";
            }
            if (chbMuseums.Checked == true)
            {
                tagId += "3";
            }
            if (chbHistoric.Checked == true)
            {
                tagId += "4";
            }
            if (chbShopping.Checked == true)
            {
                tagId += "5";
            }
            if (chbWildlife.Checked == true)
            {
                tagId += "6";
            }
            Location locationTag = new Location();
            List<Location> locationTagList = new List<Location>();

            //locationTagList = locationTag.RetrieveByTag(tagId);

            rpLocation.DataSource = locationTagList;
            rpLocation.DataBind();
        }

        protected void chbBeaches_CheckedChanged(object sender, EventArgs e)
        {
            if (chbBeaches.Checked == true)
            {
                selectItemTag(1);
            }
        }

        protected void chbOutdoors_CheckedChanged(object sender, EventArgs e)
        {
            if (chbOutdoors.Checked == true)
            {
                selectItemTag(2);
            }
        }

        protected void chbMuseums_CheckedChanged(object sender, EventArgs e)
        {
            if (chbMuseums.Checked == true)
            {
                selectItemTag(3);
            }
        }

        protected void chbHistoric_CheckedChanged(object sender, EventArgs e)
        {
            if (chbHistoric.Checked == true)
            {
                selectItemTag(4);
            }
        }

        protected void chbShopping_CheckedChanged(object sender, EventArgs e)
        {
            if (chbShopping.Checked == true)
            {
                selectItemTag(5);
            }
        }

        protected void chbWildlife_CheckedChanged1(object sender, EventArgs e)
        {
            if (chbWildlife.Checked == true)
            {
                selectItemTag(6);
            }
        }
    }
}