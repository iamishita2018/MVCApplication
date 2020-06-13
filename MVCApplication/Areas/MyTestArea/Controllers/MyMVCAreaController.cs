using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApplication.Areas.MyTestArea.Controllers
{
    public class MyMVCAreaController : Controller
    {
        // GET: MyTestArea/MyMVCArea
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DisplayData()
        {
            return View();
        }

        public PartialViewResult DisplayPartialViewData()
        {
            return PartialView("Views/MyPartialViewTest.cshtml");
        }
    }

}