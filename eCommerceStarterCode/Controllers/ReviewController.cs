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
    [Route("api/reviews")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ReviewController(ApplicationDbContext context)
        {
            _context = context;
        }

        // <baseurl>/api/reviews
        [HttpGet]
        public IActionResult GetAllReviews()
        {
            var reviews = _context.Reviews;
            return Ok(reviews);
        }

        // <baseurl>/api/reviews/review
        [HttpPost("review")]
        public IActionResult AddAReview([FromBody] Review review)
        {
            if (review == null)
            {
                return BadRequest(review + " Your review is missing some information. Please fill out everything before submitting again.");
            }
            _context.Reviews.Add(review);
            _context.SaveChanges();
            return Ok(review);
        }

        // <baseurl>/api/reviews/1
        [HttpGet("{id}")]
        public IActionResult GetReviewById(int id)
        {
            var reviews = _context.Reviews;
            if (reviews == null)
            {
                return NotFound();
            }

            foreach (var review in reviews)
            {
                if (review.ReviewId == id)
                {
                    return Ok(review);
                }
            }
            return NotFound();
        }

        // <baseurl>/api/reviews/1
        [HttpPut("{id}")]
        public async Task<IActionResult> EditReviewInfo(int id, [FromBody] Review incomingInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Retrieve ApplicationUser by id
            var entity = _context.Reviews.FirstOrDefault(pro => pro.ReviewId == id);

            if (entity == null)
            {
                return NotFound();
            }

            // Set Changes (exclude entity's key)
            if (incomingInfo.ReviewContent == null)
            {
                entity.ReviewContent = entity.ReviewContent;
            }
            else
            {
                entity.ReviewContent = incomingInfo.ReviewContent;
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

        // <baseurl>/api/reviews/1
        [HttpDelete("{id}")]
        public IActionResult DeleteSpecificReview(int id)
        {
            // Retrieve ApplicationUser by id
            var entity = _context.Reviews.FirstOrDefault(review => review.ReviewId == id);
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