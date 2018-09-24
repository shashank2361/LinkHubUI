﻿using Microsoft.Web.WebPages.OAuth;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LinkHubUI
{
    public class MvcApplication : System.Web.HttpApplication
    {

   
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            GlobalFilters.Filters.Add(new AuthorizeAttribute());
            OAuthConfig.RegisterProviders();
         }
    }
    public class OAuthConfig
    {
        public static void RegisterProviders()
        {
            OAuthWebSecurity.RegisterGoogleClient();



            OAuthWebSecurity.RegisterFacebookClient(
                appId: "2062881093756392",
                appSecret: "565ab39ae98b2d1107c3fd30c37b5488"
                //appId: ConfigurationManager.AppSettings["AppId"], 
                //appSecret: ConfigurationManager.AppSettings["AppSecret"]

                );

        }
    }

}