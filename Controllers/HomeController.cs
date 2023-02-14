using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission6Assignment.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6Assignment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieContext _context { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieContext x)
        {
            _logger = logger;
            _context = x;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPodcasts()
        {
            return View("MyPodcasts");
        }

        [HttpGet]
        public IActionResult EnterMovie()
        {
            return View("EnterMovie");
        }

        [HttpPost]
        public IActionResult EnterMovie(ApplicationResponse ar)
        {
            _context.Add(ar);
            _context.SaveChanges();
            return View("Confirmation", ar);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
