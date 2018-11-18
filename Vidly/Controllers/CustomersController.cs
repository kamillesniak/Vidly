using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        public RandomMovieViewModel customers;
        public CustomersController()
        {
             customers = new RandomMovieViewModel
            {
                Customers = new List<Models.Customer>
                {
                    new Models.Customer{ Name="Janusz z budowy", Id=0},
                    new Models.Customer{ Name="Popek monster",Id=1}
                }
            };
        }
        // GET: Customer
        public ActionResult Index()
        {  
            return View(customers);
        }
        public ActionResult Details(int id)
        {
            var customer = customers.Customers.FirstOrDefault(x => x.Id == id);
            if (customer == null)
                HttpNotFound();
            return View(customer);
        }
    }
}