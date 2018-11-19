using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;
using AutoMapper;

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

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm",viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name; 
                customerInDb.IsSubsribedToNewsLetter = customer.IsSubsribedToNewsLetter; 
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                ;
                customerInDb.BirthDate = customer.BirthDate; 
            }
            _context.SaveChanges();
            return RedirectToAction("Index","Customers");
        }

        public ActionResult Details(int id)
        {
            var customer = customers.SingleOrDefault(x => x.Id == id);
            if (customer == null)
                HttpNotFound();
            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm",viewModel);
        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

    }
}