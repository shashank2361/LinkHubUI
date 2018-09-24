using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Common.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        // GET: Common/Home
        
        public ActionResult Index()
        {
            return View();
        }
    }
}