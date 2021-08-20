using eCommerceStarterCode.Data;
using eCommerceStarterCode.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace eCommerceStarterCode.Controllers
{
    [Route("api/owners")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public OwnerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // <baseurl>/api/owners
        [HttpGet]
        public IActionResult GetAllOwners()
        {
            var owners = _context.Owners;
            return Ok(owners);
        }

        // <baseurl>/api/owners/1
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            // Retrieve ApplicationUser by id
            var entity = _context.Owners.FirstOrDefault(own => own.OwnerId == id);

            // If the owner does not exist
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