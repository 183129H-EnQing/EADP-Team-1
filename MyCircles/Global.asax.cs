using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using System.Web.UI;
using Nemiro.OAuth;

namespace MyCircles
{
    public class Global : HttpApplication
    {
        public System.Web.Script.Serialization.JavaScriptSerializer oSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        public BLL.User currentUser;

        void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            ScriptManager.ScriptResourceMapping.AddDefinition("jquery",
                new ScriptResourceDefinition
                {
                    Path = "~/scripts/jquery-3.4.1.min.js",
                    DebugPath = "~/scripts/jquery-3.4.1.js",
                    CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.4.1.min.js",
                    CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.4.1.js"
                }
            );

            OAuthManager.RegisterClient
            (
                "google",
                "53457353296-4bvakretn744evl3j4rtvalj27tvb5us.apps.googleusercontent.com",
                "zqzhoSebS9eZAJn7IhQiglDI",
                "https://www.googleapis.com/auth/userinfo.profile"
            );
        }
    }
}