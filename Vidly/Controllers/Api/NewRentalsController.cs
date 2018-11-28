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
            var customer = _context.Customers.SingleOrDefault(c => c.Id == newRental.CustomerId);
            if(customer==null)
                return NotFound();


            var movies = _context.Movies;
            var rentals = new List<Rental>();
            foreach( var movieId in newRental.MoviesId)
            {
                
                var movie = movies.SingleOrDefault(m => m.Id == movieId);
                if (movie == null)
                    return NotFound();
                if(movie.NumberInStock<1)
                {
                    //komuniakt
                }

                rentals.Add(new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Today,
                    DateReturned = DateTime.Today
                });
                
            }
            rentals.ForEach(x => _context.Rentals.Add(x));
            _context.SaveChanges();
            return Ok(rentals);

        }
    }
}
