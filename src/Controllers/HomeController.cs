using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using src.Services;

namespace AspNet1Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMagicService _magicService = null;
        private readonly ILogger<HomeController> _logger = null;

        public HomeController(IMagicService magicService, ILogger<HomeController> logger)
        {
            _magicService = magicService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogDebug("IM ALIVE!");
            return View();
        }
        public IActionResult Values() 
        {
            return Ok($"Secret returned from service: {_magicService.GetSecret()}");
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
