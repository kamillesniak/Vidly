using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private MyDbContext _context;
        private List<Movie> movies;
        public MoviesController()
        {
            _context = new MyDbContext();
            movies = _context.Movies.ToList();

        }
        // GET: Movies
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovie))
                return View("List");

            return View("ReadOnlyList");
        }
        [Authorize(Roles = RoleName.CanManageMovie)]
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieGenreViewModel
            {
                Genres = genres
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieGenreViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
            };
                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();
            var viewModel = new MovieGenreViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Details(int id)
        {
            var movie = movies.SingleOrDefault(x => x.Id == id);
            if (movie == null)
                HttpNotFound();
            return View(movie);
        }

        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}