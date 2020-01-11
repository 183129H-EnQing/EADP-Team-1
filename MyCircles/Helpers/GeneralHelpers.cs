using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
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

        public static string GetFirstValidationError(ValidatorCollection validators)
        {
            string errMsg = null;

            foreach (IValidator validator in validators)
            {
                if (!validator.IsValid) {
                    errMsg = validator.ErrorMessage;
                    break;
                }
            }

            return errMsg;
        }
    }
}