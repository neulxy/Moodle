using BusinessEntities;
using BusinessLayer;
using Moodle.Security;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Moodle.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DoLogin(User u)
        {
            UserBusinessLayer userBL = new UserBusinessLayer();
            if (userBL.IsValidUser(u))
            {
                FormsAuthentication.SetAuthCookie(u.UserName, false);
                Session["UserName"] = u.UserName;
                Session["UserId"] = u.Id;
                Session["Roles"] = userBL.GetRoles(u.UserName);
                //MoodlePrincipal moodlePrincipal = new MoodlePrincipal(u.UserName, u.Password);
                //moodlePrincipal.RoleList = new ArrayList(userBL.GetRoles(u.UserName).Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries));
                //HttpContext.User = moodlePrincipal;
                return RedirectToAction("Index", "Student");
            }
            else
            {
                ModelState.AddModelError("CredentialError", "Invalid Username or Password");
                return View("Login");
            }
        }

    }
}