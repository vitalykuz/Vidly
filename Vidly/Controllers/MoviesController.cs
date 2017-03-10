﻿using System;
using System.Collections.Generic;
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
            return Content("Id = " + id);
        }

        // GET: Movies
        // public ActionResult Index(int? pageIndex, string sortBy) // string is nullabale by default in C#, that's why we dont add "?" as we did in int
        public ActionResult Index() 
        {

            var movies = GetMovies();

            return View(movies);
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "The big bang theory"},
                new Movie { Id = 2, Name = "Titanic"},
                new Movie { Id = 3, Name = "Star Wars"}
            };
        }

        //GET: Movies/Details
        public ActionResult Details(int id)
        {
            Console.WriteLine("I am in Details");
            var movie = GetMovies().SingleOrDefault(m => m.Id == id); 
            
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
    }
}