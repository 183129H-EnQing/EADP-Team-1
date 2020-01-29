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
        public List<UserCircle> inputCirclesList
        {
            get
            {
                List<UserCircle> inputCirclesList = (List<UserCircle>)this.ViewState["inputCirclesList"];
                if (inputCirclesList == null)
                {
                    this.ViewState["inputCirclesList"] = new List<UserCircle>();
                }
                return (List<UserCircle>)(this.ViewState["inputCirclesList"]);
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

            if (!Page.IsPostBack)
            {
                inputCirclesList = UserCircleDAO.GetAllUserCircles(currentUser.Id);
                rptAddCircles.DataSource = inputCirclesList;
                rptAddCircles.DataBind();
            }

            var testList = inputCirclesList;
        }

        protected void btAddCircle_Click(object sender, EventArgs e)
        {
            signedOutErrorContainer.Visible = false;
            var circleName = ((tbCircleInput.Text).Trim()).ToLower();

            if (String.IsNullOrEmpty(tbCircleInput.Text))
            {
                GeneralHelpers.AddValidationError(Page, "addCircleGroup", "Required fields are not filled up");
            }

            if (inputCirclesList.Where(uc => uc.CircleId == circleName).Count() > 0)
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
                UserCircle newUserCircle = new UserCircle();
                newUserCircle.CircleId = circleName;
                newUserCircle.UserId = currentUser.Id;
                inputCirclesList.Add(newUserCircle);
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
                foreach (UserCircle userCircle in inputCirclesList)
                {
                    UserCircleDAO.AddUserCircle(userCircle);
                }

                Response.Redirect("/Redirect.aspx");
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