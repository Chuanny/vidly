using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.DTO;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        
        // GET /api/customers
        public IEnumerable<MovieDTO> GetMovies()
        {
            return _context.Movies.ToList().Select(Mapper.Map<Movie, MovieDTO>);
        }

        // GET /api/movies/1
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(i => i.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDTO>(movie));
        }

        // POST /api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDTO MovieDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDTO, Movie>(MovieDTO);

            _context.Movies.Add(movie);
            _context.SaveChanges();

            MovieDTO.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), MovieDTO);
        }

        // PUT /api/movies/1
        [HttpPut]
        public void UpdateMovies(int id, MovieDTO MovieDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieInDb = _context.Movies.SingleOrDefault((i => i.Id == id));

            if(movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(MovieDTO, movieInDb);
            _context.SaveChanges();
        }

        // DELETE /api/movies/1
        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault((i => i.Id == id));

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
        }
    }
}
