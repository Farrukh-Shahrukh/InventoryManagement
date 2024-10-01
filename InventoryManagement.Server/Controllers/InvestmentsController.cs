using InventoryManagement.Server.Data.Models.ViewModels;
using InventoryManagement.Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestmentsController : ControllerBase
    {

        private readonly IInvestmentsService _Investmentservice;
        public InvestmentsController(IInvestmentsService Investmentservice)
        {
            _Investmentservice = Investmentservice;
        }
        [HttpGet(Name = "GetAllInvestments")]
        public IActionResult Get()
        {
            return Ok(_Investmentservice.GetAllInvestments());
        }
        [HttpPost]
        public IActionResult Create([FromBody] InvestmentsDTO InvestmentsDto)
        {
            if (InvestmentsDto == null)
            {
                return BadRequest("Investments data is null.");
            }

            var createdInvestments = _Investmentservice.CreateInvestments(InvestmentsDto);
            return CreatedAtRoute("GetInvestmentsById", new { id = createdInvestments.Id }, createdInvestments);
        }

        [HttpGet("{id}", Name = "GetInvestmentsById")]
        public IActionResult Get(int id)
        {
            var Investments = _Investmentservice.GetInvestmentsById(id);
            if (Investments == null)
            {
                return NotFound();
            }

            return Ok(Investments);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] InvestmentsDTO InvestmentsDto)
        {
            if (InvestmentsDto == null || id != InvestmentsDto.Id)
            {
                return BadRequest("Investments data is invalid.");
            }

            var updatedInvestments = _Investmentservice.UpdateInvestments(id, InvestmentsDto);
            if (updatedInvestments == null)
            {
                return NotFound();
            }

            return Ok(updatedInvestments);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Investments = _Investmentservice.GetInvestmentsById(id);
            if (Investments == null)
            {
                return NotFound();
            }

            _Investmentservice.DeleteInvestments(id);
            return NoContent();
        }
    }
}
