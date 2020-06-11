using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApplication.Filters
{
    public class MyResultFilter : FilterAttribute, IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            //throw new NotImplementedException();
            StreamWriter sw = new StreamWriter("C:\\temp\\ResultExecuted.txt", true);
            sw.WriteLine("Controller Name = "
                + filterContext.RouteData.Values["controller"].ToString()
                + " Result Name = "
                + filterContext.RouteData.Values["action"].ToString()
                + " ResultExecuted at : "
                + DateTime.Now.ToString()) ;
            sw.Close();
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            //throw new NotImplementedException();
            StreamWriter sw = new StreamWriter("C:\\temp\\ResultExecuting.txt", true);
            sw.WriteLine("Controller Name = "
                + filterContext.RouteData.Values["controller"].ToString()
                + " Result Name = "
                + filterContext.RouteData.Values["action"].ToString()
                + " ResultExecuted at : "
                + DateTime.Now.ToString());
            sw.Close();
        }
    }
}