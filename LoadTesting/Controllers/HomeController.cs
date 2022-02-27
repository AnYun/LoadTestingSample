using LoadTesting.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LoadTesting.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("404")]
        public IActionResult PageNotFound()
        {
            return NotFound();
        }

        [Route("500")]
        public IActionResult StatusInternalServerError()
        {
            return StatusCode(500);
        }

        [Route("SlowPage")]
        public IActionResult SlowPage()
        {
            Thread.Sleep(5000);
            return Content("Slow Page!");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}