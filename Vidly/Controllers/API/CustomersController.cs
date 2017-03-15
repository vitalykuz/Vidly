using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class CustomersController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
        }

        // GET /api/customers/1
        public CustomerDto GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            // this is a convention. 
            // If the given resource is not found we throw the standart Not Found Httpresponce
            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return Mapper.Map<Customer, CustomerDto>(customer);
        }

        /*  POST /api/customers
         by convention we return a new resource (in ths case a new customer)
         If we name a method like CreateCustomer, it's not by convention so we must add [HttpPost] above the method. This method is better.
         But if we name the method as PostCustomer then the asp.net does know that it's a post method (dont need to specify [HttpPost]). official Microsoft approach.
         */
        [HttpPost]
        public CustomerDto CreateCustomer(CustomerDto customerDto) // this customer comes form a request body
        {
            // this is a convention.  we throw the standart Bad Request HttpResponce
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return customerDto;
        }

        // PUT /api/customers/1
        // two returns options available: return a resource(in this case a customer) or void
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto) // this customer comes form a request body
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(customerDto, customerInDb);
            //Mapper.Map<CustomerDto, Customer>(customerDto, customerInDb);

            //customerInDb.Name = customerDto.Name;
            //customerInDb.Birthday = customerDto.Birthday;
            //customerInDb.IsSubscribedToNewsletter = customerDto.IsSubscribedToNewsletter;
            //customerInDb.MembershipTypeId = customerDto.MembershipTypeId;

            _context.SaveChanges();
        }

        // DELETE /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDb);

            _context.SaveChanges();
        }

    }
}
