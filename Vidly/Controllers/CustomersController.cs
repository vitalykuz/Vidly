using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        //we need to have db context for using the database.
        //By convention we create private property and initialise the property in default constructor
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // we need to properly dispose the _context object. Proper way:
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            // the query is only executed when we iterate through each customer (it does it in View)
            // var customers = _context.Customers; return View(customers)
            // we can add .ToList() and the query is executed.
            //     var customers = _context.Customers.ToList();

            //if we leave as it above, we wont be able to use MemebershipTypes of the customer (for example in index.cshtml). In order to fix it we use Include
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

        // GET: Customers/Details
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }
    }
}


// we dont need this method anymore. I just want to keep it commented as reference.
/*
 * private IEnumerable<Customer> GetCustomers()
    {
        return new List<Customer>
        {
            new Customer {Id = 1, Name = "Vitaly Kuzenkov"},
            new Customer {Id = 2, Name = "Ivan and Vova"},
            new Customer {Id = 3, Name = "Tanya"}
        };
    }
 */
