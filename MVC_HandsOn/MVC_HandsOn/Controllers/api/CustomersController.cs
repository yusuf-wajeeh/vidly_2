using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVC_HandsOn.Models;
namespace MVC_HandsOn.Controllers.api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<customer> GetCustomers()
        {
            return _context.customers.ToList();
        }

        public IHttpActionResult GetCustomer(int id)
        {
            var cust = _context.customers.SingleOrDefault(x => x.id == id);
            if (cust == null)
                return NotFound();
            else
            {
                return Ok(cust);
            }
        }

        [HttpPost]
        public IHttpActionResult CreateCustomer(customer cust)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            _context.customers.Add(cust);
            _context.SaveChanges();
            return Created(new Uri(Request.RequestUri+"/"+cust.id),cust);
        }

        [HttpPut]
        public void UpdateCustomer(int id, customer cust)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
           var custindb = _context.customers.SingleOrDefault(x => x.id == id);
            if (custindb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            custindb.name = cust.name;
            custindb.dob = cust.dob;
            custindb.IsSubscribedToNewsLetter = cust.IsSubscribedToNewsLetter;
            custindb.MemberShipTypeId = cust.MemberShipTypeId;
            _context.SaveChanges();


        }

        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var cust = _context.customers.SingleOrDefault(x => x.id == id);
            if (cust == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            else
            {
                _context.customers.Remove(cust);
                _context.SaveChanges();
            }
        }

    }
    }

