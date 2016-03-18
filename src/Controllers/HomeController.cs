using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNet.Authorization;
using src.Models;

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
            _logger.LogDebug("IM ALIVE!");
            return View();
        }
        public IActionResult Values() 
        {
            _logger.LogDebug("Values!");
            return Ok(new[] {"a", "b", "c"});
        } 

        public IActionResult ODataTest(ODataModel model)
        {
            return Ok(model);
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
