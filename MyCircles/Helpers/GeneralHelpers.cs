using MyCircles.BLL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyCircles
{
    public static class GeneralHelpers
    {
        public static byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        public static System.Drawing.Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
            return returnImage;
        }

        public static void AddValidationError(Page page, string validationGroup, string errMsg)
        {
            CustomValidator err = new CustomValidator();
            err.ValidationGroup = validationGroup;
            err.ErrorMessage = errMsg;
            err.IsValid = false;
            page.Validators.Add(err);
        }

        public static string GetFirstValidationError(ValidatorCollection validators, string validatorGroup = null)
        {
            string errMsg = null;

            foreach (BaseValidator validator in validators)
            {
                if (String.IsNullOrEmpty(validatorGroup))
                {
                    if (!validator.IsValid)
                    {
                        errMsg = validator.ErrorMessage;
                        break;
                    }
                }
                else
                {
                    if (!validator.IsValid && validator.ValidationGroup == validatorGroup)
                    {
                        errMsg = validator.ErrorMessage;
                        break;
                    }
                }
            }

            return errMsg;
        }

        public static string UploadFile(FileUpload upload)
        {
            if (upload.HasFile)
            {
                User currentUser = (User) HttpContext.Current.Session["currentUser"];
                string filename = currentUser.Id + '-' + DateTime.Now.ToString("yyyyMMdd_hhmmss") + '-' + upload.FileName;
                string filepath = HttpContext.Current.Server.MapPath(Path.Combine("/Content/images/shared/" + filename));
                upload.SaveAs(filepath);

                return "/Content/images/shared/" + filename;
            }

            return null;
        }

        public static IEnumerable<T> FindControls<T>(this Control control, bool recurse) where T : Control
        {
            List<T> found = new List<T>();
            Action<Control> search = null;
            search = ctrl =>
            {
                foreach (Control child in ctrl.Controls)
                {
                    if (typeof(T).IsAssignableFrom(child.GetType()))
                    {
                        found.Add((T)child);
                    }
                    if (recurse)
                    {
                        search(child);
                    }
                }
            };
            search(control);
            return found;
        }

        public static IEnumerable<Control> FindControlByAttribute(this Control control, string key, string value)
        {
            var current = control as System.Web.UI.HtmlControls.HtmlControl;
            if (current != null)
            {
                var k = current.Attributes[key];
                if (k != null && k == value)
                    yield return current;
            }
            if (control.HasControls())
            {
                foreach (Control c in control.Controls)
                {
                    foreach (Control item in c.FindControlByAttribute(key, value))
                    {
                        yield return item;
                    }
                }
            }
        }

        public static IEnumerable<Control> GetTextBoxValueByAttribute(this Control control, string key, string value)
        {
            var current = control as System.Web.UI.HtmlControls.HtmlControl;
            if (current != null)
            {
                var k = current.Attributes[key];
                if (k != null && k == value)
                    yield return current;
            }
            if (control.HasControls())
            {
                foreach (Control c in control.Controls)
                {
                    foreach (Control item in c.FindControlByAttribute(key, value))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}