using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;

namespace AspNet1Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger = null;
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Values() 
        {
            var result = new
            {
                Values = new[] { "a", "b", "c" },
                User = this.User.FindFirst("name")?.Value ?? "(no name)"
            };

            return Ok(result);
        } 
        
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
