using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyCircles.Profile
{
    public partial class FollowCircles : System.Web.UI.Page
    {
        public List<string> inputCirclesList
        {
            get
            {
                if (this.ViewState["inputCirclesList"] == null)
                {
                    this.ViewState["inputCirclesList"] = new List<string>();
                }
                return (List<string>)(this.ViewState["inputCirclesList"]);
            }
            set
            {
                ViewState["inputCirclesList"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                rptAddCircles.DataSource = inputCirclesList;
                rptAddCircles.DataBind();
            }
        }

        protected void btAddCircle_Click(object sender, EventArgs e)
        {
            addCirclesErrorContainer.Visible = false;
            var circleName = ((tbCircleInput.Text).Trim()).ToLower();

            if (String.IsNullOrEmpty(tbCircleInput.Text))
            {
                GeneralHelpers.AddValidationError(Page, "addCircleGroup", "Required fields are not filled up");
            }

            if (inputCirclesList.Contains(circleName))
            {
                GeneralHelpers.AddValidationError(Page, "addCircleGroup", "There are duplicate circles present");
            }

            if (!Page.IsValid)
            {
                addCirclesErrorContainer.Visible = true;
                lbErrorMsg.Text = GeneralHelpers.GetFirstValidationError(Page.Validators);
            }
            else
            {
                inputCirclesList.Add(circleName);
            }

            tbCircleInput.Focus();
            rptAddCircles.DataSource = inputCirclesList;
            rptAddCircles.DataBind();
        }

        protected void btSubmit_Click(object sender, EventArgs e)
        {

        }

        protected void btRemove_Click(object sender, EventArgs e)
        {
            int circleIndex = int.Parse((sender as Button).Attributes["circleIndex"]);
            inputCirclesList.RemoveAt(circleIndex);
            rptAddCircles.DataSource = inputCirclesList;
            rptAddCircles.DataBind();
        }

        protected void rptAddCircles_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
            ScriptManager scriptMan = ScriptManager.GetCurrent(this);
            Button btn = e.Item.FindControl("btRemove") as Button;

            if (btn != null)
            {
                btn.Click += btRemove_Click;
                scriptMan.RegisterAsyncPostBackControl(btn);
            }
        }
    }
}