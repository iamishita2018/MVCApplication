using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace MVCApplication.Filters
{
    public class MyActionFilter : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            StreamWriter sw = new StreamWriter("C:\\temp\\ActionExecuted.txt",true);
            sw.WriteLine("Controller Name = "+filterContext.ActionDescriptor.ControllerDescriptor.ControllerName+
                " Action Name = "+filterContext.ActionDescriptor.ActionName+
                " ActionExecuted at : " + DateTime.Now.ToString());
            sw.Close();
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            StreamWriter sw = new StreamWriter("C:\\temp\\ActionExecuting.txt", true);
            sw.WriteLine("Controller Name = " + filterContext.ActionDescriptor.ControllerDescriptor.ControllerName
                + " Action Name = " + filterContext.ActionDescriptor.ActionName +
                " ActionExecuting at : " + DateTime.Now.ToString());
            sw.Close();
        }
    }
}