using Microsoft.AspNetCore.Mvc;

namespace Identity.Web.Controllers
{
    public class MembersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
