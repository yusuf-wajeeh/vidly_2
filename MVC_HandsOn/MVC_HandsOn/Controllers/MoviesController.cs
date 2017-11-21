using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_HandsOn.Models;
using MVC_HandsOn.ViewModel;

namespace MVC_HandsOn.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movies

        public ActionResult Index()
        {

            var mov = _context.Movies.Include("Genre");
            return View(mov);
        }

        public ActionResult NewMovie()
        {

            NewMovieViewModel movieViewModel = new NewMovieViewModel();
            movieViewModel.Genres = _context.Genre.ToList();
            return View(movieViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NewMovieViewModel vm)
        {
            if(!ModelState.IsValid)
            {
                NewMovieViewModel movieViewModel = new NewMovieViewModel();
                movieViewModel.Movie = vm.Movie;
                movieViewModel.Genres = _context.Genre.ToList();
                return View(movieViewModel);
            }
            if (vm.Movie.id == 0)
            {
                _context.Movies.Add(vm.Movie);
            }
            else
            {
                var movindb = _context.Movies.Single(x => x.id == vm.Movie.id);
                movindb.name = vm.Movie.name;
                movindb.releaseDate = vm.Movie.releaseDate;
                movindb.numInStock = vm.Movie.numInStock;
                movindb.genreid = vm.Movie.genreid;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");

            
            
        }
        public ActionResult Edit(int id)
        {
            NewMovieViewModel nvm = new NewMovieViewModel();
            var movie = _context.Movies.SingleOrDefault(x => x.id == id);
            nvm.Movie = movie;
            nvm.Genres = _context.Genre;
            return View(nvm);
        }


        public ActionResult Random()
        {
            var movie = new Movie() { name = "Shrek" };
            var customers = new List<customer>()
            {
                new customer {name="adi" },
                new customer {name="modi" }
            };
            RandomMovieViewModel ran = new RandomMovieViewModel();
            ran.movie = movie;
            ran.customer = customers;
            return View(ran);
        }

        [Route("movies/releasedyear/{year:range(2012,2017)}/{month:regex(\\d{2})}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content("year&month" + year + "&" + month);
        }
    }
}