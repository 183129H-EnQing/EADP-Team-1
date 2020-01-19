using MyCircles.BLL;
using MyCircles.DAL;
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
        public BLL.User currentUser;
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
            RedirectValidator.isUser(isAddingUserCircles: true);
            currentUser = (BLL.User)Session["currentUser"];

            using (var db = new MyCirclesEntityModel())
            {
                UserCircle existingUserCircle = db.UserCircles.Where(uc => uc.UserId == currentUser.Id).FirstOrDefault();
                if (existingUserCircle != null) Response.Redirect("/Profile/User.aspx?username=" + currentUser.Username);
            }

            if (!Page.IsPostBack)
            {
                rptAddCircles.DataSource = inputCirclesList;
                rptAddCircles.DataBind();
            }
        }

        protected void btAddCircle_Click(object sender, EventArgs e)
        {
            signedOutErrorContainer.Visible = false;
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
                signedOutErrorContainer.Visible = true;
                lbErrorMsg.Text = GeneralHelpers.GetFirstValidationError(Page.Validators);
            }
            else
            {
                inputCirclesList.Add(circleName);
            }

            tbCircleInput.Text = "";
            tbCircleInput.Focus();
            rptAddCircles.DataSource = inputCirclesList;
            rptAddCircles.DataBind();
        }

        protected void btSubmit_Click(object sender, EventArgs e)
        {
            signedOutErrorContainer.Visible = false;
            Page.Validate();

            if (!inputCirclesList.Any())
            {
                GeneralHelpers.AddValidationError(Page, "addUserCirclesGroup", "No circles have been added");
            }

            if (!Page.IsValid)
            {
                signedOutErrorContainer.Visible = true;
                lbErrorMsg.Text = GeneralHelpers.GetFirstValidationError(Page.Validators, "addUserCirclesGroup");
            }
            else
            {
                foreach (string circleName in inputCirclesList)
                {
                    UserCircleDAO.AddUserCircle(currentUser.Id, circleName);
                }

                Response.Redirect("/Profile/User.aspx?username=" + currentUser.Username);
            }
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
            Button btn = e.Item.FindControl("btRemove") as Button;

            if (btn != null)
            {
                btn.ID += e.Item.ItemIndex;
                btn.Text = "hi";

                ((ScriptManager)this.circleInputGroupBlock.FindControl("AddCircleScriptManager")).RegisterAsyncPostBackControl(btSubmit);
                ((ScriptManager)this.circleInputGroupBlock.FindControl("AddCircleScriptManager")).RegisterAsyncPostBackControl(btn);
            }
        }

        protected void btClear_Click(object sender, EventArgs e)
        {
            inputCirclesList.Clear();
            rptAddCircles.DataSource = inputCirclesList;
            rptAddCircles.DataBind();
        }
    }
}