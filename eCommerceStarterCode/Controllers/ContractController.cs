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
    [Route("api/contracts")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ContractController(ApplicationDbContext context)
        {
            _context = context;
        }

        // <baseurl>/api/contracts
        [HttpGet]
        public IActionResult GetAllContracts()
        {
            var contracts = _context.Contracts;
            return Ok(contracts);
        }

        // <baseurl>/api/contracts/contract
        [HttpPost("contract")]
        public IActionResult AddAContract([FromBody] Contract contract)
        {
            if (contract == null)
            {
                return BadRequest(contract + " Your contract is missing some information. Please fill out everything before submitting again.");
            }
            _context.Contracts.Add(contract);
            _context.SaveChanges();
            return Ok(contract);
        }

        // <baseurl>/api/contracts/1
        [HttpGet("{id}")]
        public IActionResult GetContractById(int id)
        {
            var contracts = _context.Contracts;
            if (contracts == null)
            {
                return NotFound();
            }

            foreach (var contract in contracts)
            {
                if (contract.ContractId == id)
                {
                    return Ok(contract);
                }
            }
            return NotFound();
        }

        // <baseurl>/api/contracts/1
        [HttpPut("{id}")]
        public async Task<IActionResult> EditContractInfo(int id, [FromBody] Contract incomingInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Retrieve ApplicationUser by id
            var entity = _context.Contracts.FirstOrDefault(pro => pro.ContractId == id);

            if (entity == null)
            {
                return NotFound();
            }

            // Set Changes (exclude entity's key)
            if (incomingInfo.Date == null)
            {
                entity.Date = entity.Date;
            }
            else
            {
                entity.Date = incomingInfo.Date;
            }

            if (incomingInfo.TypeOfWork == null)
            {
                entity.TypeOfWork = entity.TypeOfWork;
            }
            else
            {
                entity.TypeOfWork = incomingInfo.TypeOfWork;
            }
            if (incomingInfo.DescriptionOfProject == null)
            {
                entity.DescriptionOfProject = entity.DescriptionOfProject;
            }
            else
            {
                entity.DescriptionOfProject = incomingInfo.DescriptionOfProject;
            }
            if (incomingInfo.CustomerPriceProposal == null)
            {
                entity.CustomerPriceProposal = entity.CustomerPriceProposal;
            }
            else
            {
                entity.CustomerPriceProposal = incomingInfo.CustomerPriceProposal;
            }
            if (incomingInfo.Location == null)
            {
                entity.Location = entity.Location;
            }
            else
            {
                entity.Location = incomingInfo.Location;
            }
            if (incomingInfo.Image == null)
            {
                entity.Image = entity.Image;
            }
            else
            {
                entity.Image = incomingInfo.Image;
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

        // <baseurl>/api/contracts/1
        [HttpDelete("{id}")]
        public IActionResult DeleteSpecificContract(int id)
        {
            // Retrieve ApplicationUser by id
            var entity = _context.Contracts.FirstOrDefault(contract => contract.ContractId == id);
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
