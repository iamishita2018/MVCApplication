using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCApplication.ContextClass;
using MVCApplication.Models;

namespace MVCApplication.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult LoginDetails()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginDetails(LoginPage lp)
        {
            LoginPage log = new LoginPage();
            EmployeeContext ec = new EmployeeContext();
            if (ModelState.IsValid)
            {
                var res = ec.LoginPages.SingleOrDefault(x => x.UserName == lp.UserName
                && x.Password == lp.Password);
                if (res != null)
                {
                    Session["UserName"] = res.UserName;
                    return RedirectToAction("GetEmployeeDetailsTable", "Employee");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid User Name or Password");
                    return View(lp);
                }
            }
            else
            {
                return View();
            }

        }

        public string UnAuthorized()
        {
            return "You are not authorized to view this page";
        }

    }
}