using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class AuthController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
