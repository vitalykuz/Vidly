using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }


        // GET: Movies
        // public ActionResult Index(int? pageIndex, string sortBy) // string is nullabale by default in C#, that's why we dont add "?" as we did in int
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            return View(movies);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel    
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
            //return Content("Testing Content result");
            //return HttpNotFound();
            //return  new EmptyResult();
            //return RedirectToAction("Index", "Home");
        }

        // GET: Movies/Edit
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            var genres = _context.Genres.ToList();

            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieFormViewModel(movie)
            {               
                Genres = genres
            };

            return View("New", viewModel);
        }

        //GET: Movies/Details
        public ActionResult Details(int id)
        {    
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id); 
            
            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }

        // GET: Movies/ByReleaseYear
        [Route("movies/released/{year:regex(\\d{1})}/{month:int:range(1,12)}")]
        public ActionResult ByReleaseYear(int year, int month)
        {
            return Content(year + "/" + month);
        }

        // GET: Movies/New
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();

            var movieFormViewModel = new MovieFormViewModel
            {
                Genres = genres
            };

            return View("New", movieFormViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("New", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.AddedToDbDate = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;               
            }

                _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
    }
}