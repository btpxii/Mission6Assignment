using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        // private readonly ILogger<HomeController> _logger;
        // instance of MovieContext that can get and set details about movies
        private MovieContext movieContext { get; set; }

        // constructs homecontroller class, passes in logger and moviecontext variables
        public HomeController(MovieContext x)
        {
            movieContext = x;
        }

        // get request to root returns index file
        public IActionResult Index()
        {
            return View();
        }
        
        // get request to MyPodcasts returns MyPodcasts view
        public IActionResult MyPodcasts()
        {
            return View("MyPodcasts");
        }

        // get request to viewmovies returns all movies from db into viewmovies view, in order by year
        [HttpGet]
        public IActionResult ViewMovies()
        {
            var movies = movieContext.Movies
                .Include(x => x.Category)
                .OrderBy(x => x.Year)
                .ToList();
            return View(movies);
        }

        // get request to edit returns the entermovie view with the given data, passed by filtering with the edited movie's id
        [HttpGet]
        public IActionResult Edit (int id)
        {
            ViewBag.Categories = movieContext.Categories.ToList();

            var movie = movieContext.Movies.Single(x => x.MovieId == id);
            return View("EnterMovie", movie);
        }

        // post request to edit validates the model, updates and saves and brings back to view movies if valid, sends back to entermovie with movie's info if false (shows errors as well)
        [HttpPost]
        public IActionResult Edit (Movie movie)
        {
            if (ModelState.IsValid)
            {
                movieContext.Update(movie);
                movieContext.SaveChanges();

                return RedirectToAction("ViewMovies");
            }
            else
            {
                ViewBag.Categories = movieContext.Categories.ToList();
                return View("EnterMovie", movie);
            }

        }

        // get req to delete shows delete confirmation page with data from selected movie's details (filtered by id)
        [HttpGet]
        public IActionResult Delete (int id)
        {
            var movie = movieContext.Movies.Single(x => x.MovieId == id);
            return View(movie);
        }

        // post req to delete removes selected movie from db, saves, and redirects back to viewMovies view
        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            movieContext.Movies.Remove(movie);
            movieContext.SaveChanges();
            return RedirectToAction("ViewMovies");
        }

        // when a get request is received for entermovie, entermovie view is displayed
        [HttpGet]
        public IActionResult EnterMovie()
        {
            ViewBag.Categories = movieContext.Categories.ToList();
            return View(new Movie());
        }

        // when a post request is received to entermovie, posted data is added to the db, saved
        // then, user is redirected to confirmation page
        [HttpPost]
        public IActionResult EnterMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                movieContext.Add(movie);
                movieContext.SaveChanges();
                return View("Confirmation", movie);
            }
            else
            {
                ViewBag.Categories = movieContext.Categories.ToList();
                return View();
            }
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}


    }
}
