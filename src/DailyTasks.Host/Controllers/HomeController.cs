using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgrotoolsMaps.Host.Controllers
{
    [AllowAnonymous]
    public class HomeController : ControllerBase
    {
        public ActionResult Index() => new RedirectResult("~/swagger");
    }
}