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
        private readonly ApplicationDbContext _context;

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

        // GET: Customers/NewCustomer
        public ActionResult NewCustomer()
        {
            var membershipTypes = _context.MembershipTypes.ToList();

            var newCustomerViewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", newCustomerViewModel);
        }

        // this is called when a new customer is created (save button pressed in newCustomer.chtml) or if we update an existing customer
        [HttpPost]
        public ActionResult Save(Customer customer)   // Create(NewCustomerViewModel newCustomerViewModel) -> VS smart enough to understand Customer (all info I need is in customer
        {
            //I now use this method to Update a customer or to create a new customer

            if (customer.Id == 0)
            {
                // we just adding a customer to context, not to the db!
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.Birthday = customer.Birthday;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;

                // this is the official Microsoft approach of updating the database
                //TryUpdateModel(customerInDb);
            }
            
            // now we are saving data to database
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        // GET: Customers/Details
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            var newCustomerViewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", newCustomerViewModel);
        }
    }
}