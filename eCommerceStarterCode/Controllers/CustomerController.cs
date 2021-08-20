using eCommerceStarterCode.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace eCommerceStarterCode.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // <baseurl>/api/customers
        [HttpGet]
        public IActionResult GetAllOwners()
        {
            var customers = _context.Customers;
            return Ok(customers);
        }

        // <baseurl>/api/customers/1
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            // Retrieve ApplicationUser by id
            var entity = _context.Customers.FirstOrDefault(cus => cus.CustomerId == id);

            // If the Customer does not exist
            if (entity == null)
            {
                return NotFound();
            }

            // Delete and save all changes
            _context.Remove(entity);
            _context.SaveChanges();
            return StatusCode(201, entity + " Was successfully removed from the database.");
        }

    }
}