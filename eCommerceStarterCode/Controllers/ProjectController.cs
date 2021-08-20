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
    [Route("api/projects")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ProjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        // <baseurl>/api/projects
        [HttpGet]
        public IActionResult GetAllProjects()
        {
            var projects = _context.Projects;
            return Ok(projects);
        }

        // <baseurl>/api/projects/project
        [HttpPost("project")]
        public IActionResult AddAProject([FromBody]Project project)
        {
            if (project == null)
            {
                return BadRequest(project + " Your project is missing some information. Please fill out everything before submitting again.");
            }
            _context.Projects.Add(project);
            _context.SaveChanges();
            return Ok(project);
        }

        // <baseurl>/api/projects/1
        [HttpGet("{id}")]
        public IActionResult GetProjectById(int id)
        {
            var projects = _context.Projects;
            if (projects == null)
            {
                return NotFound();
            }

            foreach (var project in projects)
            {
                if (project.ProjectId == id)
                {
                    return Ok(project);
                }
            }
            return NotFound();
        }

        // <baseurl>/api/projects/1
        [HttpPut("{id}")]
        public async Task<IActionResult> EditProjectInfo(int id, [FromBody] Project incomingInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Retrieve ApplicationUser by id
            var entity = _context.Projects.FirstOrDefault(pro => pro.ProjectId == id);

            if (entity == null)
            {
                return NotFound();
            }

            // Set Changes (exclude entity's key)
            if (incomingInfo.NameOfProject == null)
            {
                entity.NameOfProject = entity.NameOfProject;
            }
            else
            {
                entity.NameOfProject = incomingInfo.NameOfProject;
            }

            if (incomingInfo.DetailsOfProject == null)
            {
                entity.DetailsOfProject = entity.DetailsOfProject;
            }
            else
            {
                entity.DetailsOfProject = incomingInfo.DetailsOfProject;
            }
            if (incomingInfo.ImageOfProject == null)
            {
                entity.ImageOfProject = entity.ImageOfProject;
            }
            else
            {
                entity.ImageOfProject = incomingInfo.ImageOfProject;
            }
            if (incomingInfo.LocationOfProject == null)
            {
                entity.LocationOfProject = entity.LocationOfProject;
            }
            else
            {
                entity.LocationOfProject = incomingInfo.LocationOfProject;
            }
            if (incomingInfo.DurationOfProject == null)
            {
                entity.DurationOfProject = entity.DurationOfProject;
            }
            else
            {
                entity.DurationOfProject = incomingInfo.DurationOfProject;
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

        // <baseurl>/api/projects/1
        [HttpDelete("{id}")]
        public IActionResult DeleteSpecificProject(int id)
        { 
            // Retrieve ApplicationUser by id
            var entity = _context.Projects.FirstOrDefault(project => project.ProjectId == id);
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
