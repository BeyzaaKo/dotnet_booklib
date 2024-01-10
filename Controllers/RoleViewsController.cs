using ASP.NETCoreIdentityCustom.Core;
using ASP.NETCoreIdentityCustom.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCoreIdentityCustom.Controllers
{
    public class RoleViewsController : Controller
    {
        [Authorize]
        public IActionResult Books()
        {
            return View();
        }

        [Authorize]
        public IActionResult Discover()
        {
            return View();
        }

        [Authorize]
        public IActionResult Profile()
        {
            return View();
        }
    }

}