using MVC_HandsOn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVC_HandsOn.Controllers.api
{
    public class MovieController : ApiController
    {
        private ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Movie> GetMovies()
        {
            return _context.Movies.ToList();
        }

        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(x => x.id == id);
            if (movie == null)
                return NotFound();
            else
            {
                return Ok(movie);
            }
        }

        [HttpPost]
        public IHttpActionResult CreateMovie(Movie mov)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            _context.Movies.Add(mov);
            _context.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + mov.id), mov);
        }

        [HttpPut]
        public void UpdateMovie(int id, Movie mov)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var movieindb = _context.Movies.SingleOrDefault(x => x.id == id);
            if (movieindb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            movieindb.name = mov.name;
            movieindb.releaseDate = mov.releaseDate;
            movieindb.numInStock = mov.numInStock;
            movieindb.genreid = mov.genreid;
            _context.SaveChanges();

        }

        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var mov = _context.Movies.SingleOrDefault(x => x.id == id);
            if (mov == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            else
            {
                _context.Movies.Remove(mov);
                _context.SaveChanges();
            }
        }

    }
}
