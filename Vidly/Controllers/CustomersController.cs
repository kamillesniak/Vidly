using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        public List<Customer> customers;
        private MyDbContext _context;
        public CustomersController()
        {
            _context = new MyDbContext();
            customers = _context.Customers.Include(x=> x.MembershipType).ToList();
        }
        // GET: Customer
        public ActionResult Index()
        {
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = customers.SingleOrDefault(x => x.Id == id);
            if (customer == null)
                HttpNotFound();
            return View(customer);
        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

    }
}