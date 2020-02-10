using MyCircles.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace MyCircles.Profile
{
    public partial class EditProfile : System.Web.UI.Page
    {
        public BLL.User currentUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            RedirectValidator.isUser();
            currentUser = (BLL.User)Session["currentUser"];

            nameTB.Text = currentUser.Username;

            bioTB.Text = currentUser.Bio;



        }

        protected void submitButt_Click(object sender, EventArgs e)
        {
            var newProfile = new BLL.User();
            newProfile.Username = nameTB.Text;
            newProfile.Bio = bioTB.Text;
            newProfile.ProfileImage = GeneralHelpers.UploadFile(imageUpload);

            UserDAO.EditUser(newProfile);

       
           

        }


        protected string UploadThisFile(FileUpload upload)
        {
            if (upload.HasFile)
            {
                string filename = currentUser.Id + '-' + DateTime.Now.ToString("yyyyMMdd_hhmmss") + '-' + upload.FileName;
                string filepath = Server.MapPath(Path.Combine("/Content/images/shared/" + filename));
                upload.SaveAs(filepath);

                return "/Content/images/shared/" + filename;
            }

            return null;
        }
    }
}