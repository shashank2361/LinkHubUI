using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.Web.WebPages.OAuth;
using DotNetOpenAuth.AspNet;

namespace LinkHubUI.Areas.Security.Controllers
{
    [AllowAnonymous]
    public class LoginController : BaseSecurityController
    {
        // GET: Security/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(tbl_User user)
        {
            try
            {    
                if (Membership.ValidateUser(user.UserEmail, user.Password))
                {
                    FormsAuthentication.SetAuthCookie(user.UserEmail, false);
                    return RedirectToAction("Index", "Home", new { area = "Common" });
                }
                else
                {
                    TempData["Msg"] = "Login Falied";
                    return RedirectToAction("Index");
                }
                
                
            }
            catch (Exception E1)
            {

                TempData["Msg"] = "Login Falied" + E1.Message;
                return RedirectToAction("Index");
            }

        }



        public ActionResult ExternalLogin(string provider)

        {
            
            OAuthWebSecurity.RequestAuthentication(provider, Url.Action("ExternalLoginCallback")  );
            return RedirectToAction("Index", "Home", new { area = "Common" });
        }
   
        public ActionResult ExternalLoginCallback(string returnUrl)
        {
           // var result = OAuthWebSecurity.VerifyAuthentication(returnUrl);


            AuthenticationResult result = OAuthWebSecurity.VerifyAuthentication(Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl }));

            if (result.IsSuccessful == false)
            {
                TempData["Msg"] = "Login Failed  ";
                return RedirectToAction("Index");
            }
            else
            {




                if (User.Identity.IsAuthenticated)
                {
                    // If the current user is logged in add the new account
                    OAuthWebSecurity.CreateOrUpdateAccount(
                        result.Provider,
                        result.ProviderUserId,
                        User.Identity.Name);
                    return RedirectToRoute(returnUrl);
                }
                else
                {

                    objBs.CreateUserIfDoesNotExist(result.UserName);
                    FormsAuthentication.SetAuthCookie(result.UserName, false);
                    return RedirectToAction("Index", "Home", new { area = "Common" });
                }
             }
        }




        public ActionResult SignOut()
        {

            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home", new { area = "Common" });
        }


    }
}