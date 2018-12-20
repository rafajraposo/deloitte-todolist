using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ToDoList.Service;
using ToDoList.Web.Models;

namespace ToDoList.Web.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly IUnitOfWork _uow;

        public AuthController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        private IAuthenticationManager AuthenticationManager
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }

        [Route("login")]
        public ActionResult Login()
        {
            var vm = new AuthLoginViewModel();
            return View(vm);
        }

        [HttpPost]
        [Route("login")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(AuthLoginViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var user = await _uow.Users.GetByUsernameAndPassword(vm.Username, vm.Password);

            if (user == null)
            {
                ModelState.AddModelError("Username", "Login failed");
                return View(vm);
            }

            var Identity = new ClaimsIdentity(
                new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                },
                DefaultAuthenticationTypes.ApplicationCookie
            );

            AuthenticationManager.SignIn(new AuthenticationProperties() { }, Identity);

            return RedirectToAction("Index", "ToDo");
        }

        [Route("logout")]
        public ActionResult Logout()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            return RedirectToAction("Login");
        }
    }
}
