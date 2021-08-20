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
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ApplicationUserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _context.Users;
            return Ok(users);
        }

        // <baseurl>/api/applicationuser/user
        [HttpGet("user"), Authorize]
        public IActionResult GetCurrentUser()
        {
            var userId = User.FindFirstValue("id");
            var user = _context.Users.Find(userId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // <baseurl>/api/applicationuser/4b3a5e96-6001-4e0e-a427-2abe127670ef
        [HttpGet("{id}")]
        public IActionResult GetSpecificUser(string id)
        {
            var users = _context.Users;
            if (users == null)
            {
                return NotFound();
            }

            foreach (var user in users)
            {
                if (user.Id.Contains(id))
                {
                    return Ok(user);
                }
            }
            return NotFound();
        }

        // <baseurl>/api/applicationuser/4b3a5e96-6001-4e0e-a427-2abe127670ef
        [HttpPut("{id}")]
        public async Task<IActionResult> EditUserInfo(string id, [FromBody] ApplicationUser incomingInfo)
        {
            ///
            /// When using this Put method, you need to enter all the values necessary. Do not leave anything null, 
            /// or you will cause the user to have null information in some of the table slots.
            ///
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Retrieve ApplicationUser by id
            var entity = _context.Users.Include(u => u.Customers).Include(u => u.Owners).FirstOrDefault(user => user.Id == id);

            if (entity == null)
            {
                return NotFound();
            }

            // Set Changes (exclude entity's key)
            entity.FirstName = incomingInfo.FirstName;
            entity.LastName = incomingInfo.LastName;
            entity.Email = incomingInfo.Email;
            entity.PhoneNumber = incomingInfo.PhoneNumber;
            entity.UserName = incomingInfo.UserName;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Add logging for exception
                return new ObjectResult(entity) { StatusCode = (int)HttpStatusCode.InternalServerError };
            }
            return Ok(entity);
        }

        // <baseurl>/api/applicationuser/4b3a5e96-6001-4e0e-a427-2abe127670ef
        [HttpDelete("{id}")]
        public IActionResult DeleteSpecificUser(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            // Retrieve ApplicationUser by id
            var entity = _context.Users.Include(u => u.Customers).Include(u => u.Owners).FirstOrDefault(user => user.Id == id);

            _context.Remove(entity);
            _context.SaveChanges();
            return StatusCode(201, entity + " Removal from database successful.");
        }
    }
}
