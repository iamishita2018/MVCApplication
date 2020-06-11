using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MVCApplication.Filters
{

    public class MyErrorFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            Exception ex = filterContext.Exception;
            string msg = ex.Message;
            filterContext.ExceptionHandled = true;
            filterContext.Result = new ViewResult
            {

                ViewName = "~/Views/Shared/CustomErrors.cshtml",
                ViewBag = { Message = msg }
            };
            //throw new NotImplementedException();
        }
    }
}