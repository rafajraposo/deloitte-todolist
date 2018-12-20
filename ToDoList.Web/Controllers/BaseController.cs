using System.Security.Claims;
using System.Web.Mvc;
using ToDoList.Web.Models;

namespace ToDoList.Web.Controllers
{
    public class BaseController : Controller
    {
        public UserData CurrentUser => new UserData(User as ClaimsPrincipal);
    }
}