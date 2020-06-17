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
        [Authorize]
        public ActionResult LoginDetails(LoginPage lp)
        {
            LoginPage log = new LoginPage();
            EmployeeContext ec = new EmployeeContext();
            var res = ec.LoginPages.SingleOrDefault(x => x.UserName == lp.UserName 
            && x.Password == lp.Password);
            if (res == null)//invalid credentials
            {
                ModelState.AddModelError("", "Invalid Username or password");
                return View();
            }
            else
            {
                return RedirectToAction("GetEmployeeDetailsTable", "Employee");
            }
                
        }

    }
}