using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewsExercise.Models;

namespace NewsExercise.Controllers
{
    public class UserController : Controller
    {
        private UserOperate userOp = new UserOperate();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login()
        {
            string name = Request.Form["userName"];
            string pwd = Request.Form["pwd"];
            var res=userOp.Login(name,pwd);
            if (res !=null)
            {
                Session["UserName"] = res.UserName;
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "User");
        }
        public ActionResult LogOff()
        {
            Session["UserName"] = null;
            return RedirectToAction("Index", "Home");
        }

    }
}
