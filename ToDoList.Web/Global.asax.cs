using System.Security.Claims;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Routing;
using ToDoList.Web.App_Start;
using ToDoList.Web.AutoMapper;

namespace ToDoList.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.NameIdentifier;
            AutoMapperConfiguration.Configure();
        }
    }
}
