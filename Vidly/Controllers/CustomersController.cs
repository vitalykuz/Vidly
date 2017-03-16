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
            //LAST UPDATE. We don;t need to use customer anymore becase we render them from api on a client

            // the query is only executed when we iterate through each customer (it does it in View)
            // var customers = _context.Customers; return View(customers)
            // we can add .ToList() and the query is executed.
            //     var customers = _context.Customers.ToList();

            //if we leave as it above, we wont be able to use MemebershipTypes of the customer (for example in index.cshtml). In order to fix it we use Include
            //var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            //return View(customers);
            return View();
        }

        // GET: Customers/NewCustomer
        public ActionResult NewCustomer()
        {
            /* when I use @Html.ValidationSummary() in Customer Form, the ID error appears
             * because we must provide an id. In order to make this error gone, we need to inialise 
             a new Customer and add it to the viewModel. When the customer is created 
             the id is added automatically (it actually initialises all default values, not just id)
            */
            var customer = new Customer();

            var membershipTypes = _context.MembershipTypes.ToList();

            var newCustomerViewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", newCustomerViewModel);
        }

        // this is called when a new customer is created (save button pressed in newCustomer.chtml) or if we update an existing customer
        [HttpPost]
        // we need to add it in order Anti Forgery Token in Customer Form works
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)   // Create(NewCustomerViewModel newCustomerViewModel) -> VS smart enough to understand Customer (all info I need is in customer
        {
            // adding a validation. Checks Annotations in Customer and then checks the Model state: ModelState.IsValid
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }

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