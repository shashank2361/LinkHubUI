using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Admin.Controllers
{
    [Authorize(Roles ="A")]
    public class CategoryController : BaseAdminController
    {

        // GET: Admin/Category
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tbl_Category category)
        {
  
            try
            {
                if (!ModelState.IsValid)
                {
                    objBs.categoryBs.Insert(category);

                    TempData["Msg"] = "Category Created Successfully";
                    return View("Index");
                }
                else
                {
                    return View ("Index");

                }

            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Category Create Failed : " + e1.Message;
                return View("Index");
            }



        }
    }
}