﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace And.Eticaret.UI.WEB.Areas.Admin
{
    public class AdminControllerBase: Controller
    {
        protected override void Initialize(RequestContext requestContext)
        {
            var IsLogin = false;
            if (requestContext.HttpContext.Session["AdminLoginUser"] == null)
            {
                //Admin girişi yapılmamış
                requestContext.HttpContext.Response.Redirect("/Admin/AdminLogin");
            }
            else
            {
                //Sorun yok Admin içerde
                //Sayfayı çalıştır
                base.Initialize(requestContext);
            }
            
        }
    }
}