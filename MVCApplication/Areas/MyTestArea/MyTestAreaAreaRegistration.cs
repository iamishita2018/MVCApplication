using System.Web.Mvc;

namespace MVCApplication.Areas.MyTestArea
{
    public class MyTestAreaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "MyTestArea";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "MyTestArea_default",
                "MyTestArea/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new[] { "MVCApplication.Areas.MyTestArea.Controllers" }
            );
        }
    }
}