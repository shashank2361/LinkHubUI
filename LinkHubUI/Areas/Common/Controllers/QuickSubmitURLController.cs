using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Common.Controllers
{
    [AllowAnonymous]
    public class QuickSubmitURLController : BaseCommonController
    {
        //
        // GET: /Common/QuickSubmitURL/
        public ActionResult Index()
        {
            ViewBag.CategoryId = new SelectList(objBs.categoryBs.GetALL().ToList(), "CategoryId", "CategoryName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(QuickSubmitURLModel myQuickUrl)
        {
            try
            {
                tbl_User U = myQuickUrl.User;
                ModelState.Remove("User.Password");
                ModelState.Remove("User.ConfirmPassword");
                ModelState.Remove("MyUrl.UrlDesc");
                
                if (ModelState.IsValid)
                {
                    objBs.InsertQuickUrl(myQuickUrl);
                    TempData["Msg"] = "Created Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.CategoryId = new SelectList(objBs.categoryBs.GetALL().ToList(), "CategoryId", "CategoryName");
                    return View("Index");
                }
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Create Failed : " + e1.Message;
                return RedirectToAction("Index");
            }
           
        }
	}
}