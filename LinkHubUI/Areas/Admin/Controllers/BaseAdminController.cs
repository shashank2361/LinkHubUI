using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Admin
{
    public class BaseAdminController : Controller
    {

        protected AdminBs objBs;

        public BaseAdminController()
        {
            objBs = new AdminBs();

        }
     
        // GET: Admin/BaseController
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}