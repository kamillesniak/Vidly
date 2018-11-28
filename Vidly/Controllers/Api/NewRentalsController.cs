using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Vidly.Dto;
using Vidly.Models;
using System.Data.Entity;
namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {

        private MyDbContext _context;
        public NewRentalsController()
        {
            _context = new MyDbContext();
        }

        public IHttpActionResult GetRental()
        {
            var rentals = _context.Rentals
             .ToList()
             .Select(Mapper.Map<Rental, NewRentalDto>);

            return Ok(rentals);
        }


        //Post create rental
        [HttpPost]
        public IHttpActionResult NewRental(NewRentalDto newRental)
        {
            if (newRental.MoviesId.Count == 0)
                return BadRequest("No Movie Ids have been given.");

            var customer = _context.Customers.SingleOrDefault(c => c.Id == newRental.CustomerId);

            if (customer == null)
                return BadRequest("CustomerId is not valid.");

            var movies = _context.Movies.Where(m=> newRental.MoviesId.Contains(m.Id));

            var rentals = new List<Rental>();

            if (movies.Count() != newRental.MoviesId.Count)
                return BadRequest("One or more movie Ids are invalid");

            foreach( var movie in movies)
            {
                if(movie.NumberAvailable<1)
                    return BadRequest($"Movie is not avaliable {movie.Id}");


                rentals.Add(new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                });

                movie.NumberAvailable--;
                
            }
            rentals.ForEach(x => _context.Rentals.Add(x));
            _context.SaveChanges();
            return Ok(rentals);

        }
    }
}
