using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.Owin.Security.DataHandler.Serializer;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movies
        public ActionResult Random()
        {
            
            var movie = new Movie() {Name = "Shrek!"};

            var customers = _context.Customers.ToList();

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customer = customers
            };
          //  ViewResult.ViewData.Model
            
            return View(viewModel);

        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleasedYear(int year, int month)
        {
            return Content("year: "+year + " Month: " + month);
        }

        public ActionResult Index()
        {

            var movies = _context.Movie.Include(x => x.Genre).ToList();
            var moviesList = new MoviesList()
            {
                Movies = movies
            };

            return View(moviesList);
        }

        [Route("Movies/{id:regex(\\d{1})}")]
        public ActionResult Details(int id)
        {
            

            var customer = _context.Movie.Include(x => x.Genre).SingleOrDefault(x => x.Id == id);
            if (customer == null)
                return new HttpNotFoundResult();
            return View(customer);


        }

        public ActionResult New()
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel()
            {
                Genres = genres
            };
            //return View("MovieForm",viewModel);
            return View("New", viewModel);
        }
        [HttpPost]
        public ActionResult New(Movie movie)
        {
            
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel()
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };
                return View("New", viewModel);
            }
            if (movie.Id == 0)
            {
                _context.Movie.Add(movie);
            }
            else
            {
                var movieFromDb = _context.Movie.Single(x => x.Id == movie.Id);
                movieFromDb.Name = movie.Name;
                movieFromDb.ReleaseDate = movie.ReleaseDate;
                movieFromDb.GenreId = movie.GenreId;
                movieFromDb.NumberInStock = movie.NumberInStock;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("New", "Movies");
            }

            if (movie.Id==0)
            {
                _context.Movie.Add(movie);
            }
            else
            {
                var movieFromDb = _context.Movie.Single(x => x.Id == movie.Id);
                movieFromDb.Name = movie.Name;
                movieFromDb.ReleaseDate = movie.ReleaseDate;
                movieFromDb.GenreId = movie.GenreId;
                movieFromDb.NumberInStock = movie.NumberInStock;
            }
            
            _context.SaveChanges();

            return RedirectToAction("Index","Movies");
        }

        public ActionResult Edit(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var movie = _context.Movie.SingleOrDefault(x => x.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel()
            {
                Movie = movie,
                Genres = genres
            };
            return View("Edit", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<Movie, Movie>());

                var movieFromDb = _context.Movie.Single(x => x.Id == movie.Id);
                Mapper.Map(movie, movieFromDb);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            if (movie == null)
            {
                return HttpNotFound();
            }

            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel()
            {
                Movie = movie,
                Genres = genres
            };
            return View("Edit", viewModel);
        }

        public virtual ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = _context.Movie.Include(b=>b.Genre).FirstOrDefault(x=>x.Id==id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
          
            var movieFromDb = _context.Movie.SingleOrDefault(x => x.Id == id);
            if (movieFromDb == null)
            {
                return HttpNotFound();
            }
            _context.Movie.Remove(movieFromDb);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}