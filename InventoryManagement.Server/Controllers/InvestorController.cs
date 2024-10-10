﻿using investmentsManagement.Server.Data.Models.ViewModels;
using investmentsManagement.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace investmentsManagement.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InvestorController : ControllerBase
    {
        private readonly IInvestorService _Investorservice;
        public InvestorController(IInvestorService Investorservice)
        {
            _Investorservice = Investorservice;
        }
        [HttpGet(Name = "GetAllInvestors")]
        public IActionResult Get()
        {
            return Ok(_Investorservice.GetAllInvestors());
        }
        [HttpPost]
        public IActionResult Create([FromBody] InvestorsDTO InvestorsDto)
        {
            if (InvestorsDto == null)
            {
                return BadRequest("Investors data is null.");
            }

            var createdInvestors = _Investorservice.CreateInvestors(InvestorsDto);
            return CreatedAtRoute("GetInvestorsById", new { id = createdInvestors.Id }, createdInvestors);
        }

        [HttpGet("{id}", Name = "GetInvestorsById")]
        public IActionResult Get(int id)
        {
            var Investors = _Investorservice.GetInvestorsById(id);
            if (Investors == null)
            {
                return NotFound();
            }

            return Ok(Investors);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] InvestorsDTO InvestorsDto)
        {
            if (InvestorsDto == null || id != InvestorsDto.Id)
            {
                return BadRequest("Investors data is invalid.");
            }

            var updatedInvestors = _Investorservice.UpdateInvestors(id, InvestorsDto);
            if (updatedInvestors == null)
            {
                return NotFound();
            }

            return Ok(updatedInvestors);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Investors = _Investorservice.GetInvestorsById(id);
            if (Investors == null)
            {
                return NotFound();
            }

            _Investorservice.DeleteInvestors(id);
            return NoContent();
        }
    }
}
