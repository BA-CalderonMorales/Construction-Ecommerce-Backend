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
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // <baseurl>/api/categories
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = _context.Categories;
            return Ok(categories);
        }

        // <baseurl>/api/categories/category
        [HttpPost("category")]
        public IActionResult AddACategory([FromBody] Category category)
        {
            if (category == null)
            {
                return BadRequest(category + " Your category is missing some information. Please fill out everything before submitting again.");
            }
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Ok(category);
        }

        // <baseurl>/api/categories/1
        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var categories = _context.Categories;
            if (categories == null)
            {
                return NotFound();
            }

            // Retrieve ApplicationUser by id
            var entity = _context.Categories.FirstOrDefault(cat => cat.CategoryId == id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        // <baseurl>/api/categories/1
        [HttpPut("{id}")]
        public async Task<IActionResult> EditCategoryInfo(int id, [FromBody] Category incomingInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Retrieve ApplicationUser by id
            var entity = _context.Categories.FirstOrDefault(pro => pro.CategoryId == id);

            if (entity == null)
            {
                return NotFound();
            }

            // Set Changes (exclude entity's key)
            if (incomingInfo.CategoryName == null)
            {
                entity.CategoryName = entity.CategoryName;
            }
            else
            {
                entity.CategoryName = incomingInfo.CategoryName;
            }

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

        // <baseurl>/api/categories/1
        [HttpDelete("{id}")]
        public IActionResult DeleteSpecificCategory(int id)
        {
            // Retrieve ApplicationUser by id
            var entity = _context.Categories.FirstOrDefault(category => category.CategoryId == id);
            if (entity == null)
            {
                return NotFound();
            }
            _context.Remove(entity);
            _context.SaveChanges();
            return StatusCode(201, entity + " Removal from database successful.");
        }
    }
}
