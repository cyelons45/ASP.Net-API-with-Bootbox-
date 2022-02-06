using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Sibly.Dtos;
using Sibly.Models;





namespace Sibly.Controllers.API
{

    public class MovieController : ApiController
    {
        public ApplicationDbContext _context;
        public MovieController()
        {
            _context = new ApplicationDbContext();
        }


         protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET api/<controller>
         public IHttpActionResult GetMovies()
        {
           
            return Ok(_context.Movies.Include(m => m.Genre).ToList().Select(Mapper.Map<Movie, MoviesDto>));
       
        }

        // GET api/<controller>/5
         public IHttpActionResult GetMovie(int id)
        {
            //Get /API/CUSTOMERS
            var movie = _context.Movies.SingleOrDefault(c => c.MovieId == id);
            if (movie == null)
                return NotFound();
            return Ok(Mapper.Map<Movie, MoviesDto>(movie));
        }

        // POST api/<controller>
        [HttpPost]
         public IHttpActionResult CreateMovie(MoviesDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var movie = Mapper.Map<MoviesDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            movieDto.MovieId = movie.MovieId;
            return Created(new Uri(Request.RequestUri + "/" + movie.MovieId), movieDto);
        }

        // PUT api/<controller>/5
          [HttpPut]
        public IHttpActionResult Put(int id, MoviesDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var movieInDb = _context.Movies.SingleOrDefault(c => c.MovieId == id);
            if (movieInDb == null)
            {
                return NotFound();
            }
            Mapper.Map(movieDto, movieInDb);

            _context.SaveChanges();
            movieDto.MovieId = id;
            return Ok(movieDto);
        }




        // DELETE api/<controller>/5
        [HttpDelete]
        public void Delete(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.MovieId == id);
            if (movie == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }
    }
}