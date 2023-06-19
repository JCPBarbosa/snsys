using Microsoft.AspNetCore.Mvc;

namespace TesteSNSYS.MVC.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
