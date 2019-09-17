using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ViewResult Index()
        {
            //var movies = _context.Movies.Include(m => m.Genre).ToList();
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");

            return View("ReadOnlyList");
        }

        
        public ActionResult Details(int id)
        {
            var movie = _context.Movies
                .Include(m => m.Genre)
                .SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int Id)
        {
            // retrieve the selected movie
            var movie = _context.Movies.SingleOrDefault(m => m.Id == Id);

            if (movie == null)
                return HttpNotFound();
            var viewModel = new MovieFormViewModel(movie)
            {
                
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }
            //check if the this is an existing movie or a new movie
            //if this is a new movie then add it to the database
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }

            //if this is an existing movie then update its new information
            else
            {
                var movieInDB = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDB.Name = movie.Name;
                movieInDB.GenreId = movie.GenreId;
                movieInDB.NumberInStock = movie.NumberInStock;
                movieInDB.ReleaseDate = movie.ReleaseDate;

            }
            // apply saveChanges to the database
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek" };

            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1" },
                new Customer {Name = "Customer 2" }

            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }
    }
}