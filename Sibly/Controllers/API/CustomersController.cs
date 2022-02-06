//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Web.Http;
//using System.Net.Http;
//using System.Web.Mvc;
//using Sibly.Models;
//using Sibly.ViewModels;
using System.Data.Entity;
//using Sibly.Dtos;
//using AutoMapper;
using AutoMapper;
using Sibly.Dtos;
using Sibly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace Sibly.Controllers.API
{
    public class CustomersController : ApiController
    {
        public ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public IHttpActionResult  GetCustomers()
        {
            //Get /API/CUSTOMERS
            return Ok(_context.Customers.Include(c => c.MembershipType).ToList().Select(Mapper.Map<Customer, CustomerDto>));
          
        }


        //Get /API/CUSTOMER
  
        public IHttpActionResult GetCustomer(int id)
        {
            //Get /API/CUSTOMERS
            var customer = _context.Customers.SingleOrDefault(c => c.CustomerId==id);
            if (customer == null)
                return NotFound();
            return Ok(Mapper.Map<Customer,CustomerDto>(customer));
        }


        //POST /API/CUSTOMER
      [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
               return BadRequest(); 
            }
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.CustomerId = customer.CustomerId;
            return Created(new Uri(Request.RequestUri + "/" + customer.CustomerId), customerDto);
        }


        //PUT /API/CUSTOMER/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var customerInDb = _context.Customers.SingleOrDefault(c => c.CustomerId == id);
            if (customerInDb==null)
            {
                return NotFound();
            }
            Mapper.Map(customerDto, customerInDb);
          
            _context.SaveChanges();
            customerDto.CustomerId = id;
            return Ok(customerDto);
         

        }


        //DELETE /API/CUSTOMER
        [HttpDelete]
        public void CreateCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.CustomerId == id);
            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }




    }
}
