using InventoryManagement.Server.Data.Models.ViewModels;
using InventoryManagement.Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpencesController : ControllerBase
    {


        private readonly IExpencesService _Expenceservice;
        public ExpencesController(IExpencesService Expenceservice)
        {
            _Expenceservice = Expenceservice;
        }
        [HttpGet(Name = "GetAllExpences")]
        public IActionResult Get()
        {
            return Ok(_Expenceservice.GetAllExpences());
        }
        [HttpPost]
        public IActionResult Create([FromBody] ExpencesDTO ExpencesDto)
        {
            if (ExpencesDto == null)
            {
                return BadRequest("Expences data is null.");
            }

            var createdExpences = _Expenceservice.CreateExpences(ExpencesDto);
            return CreatedAtRoute("GetExpencesById", new { id = createdExpences.Id }, createdExpences);
        }

        [HttpGet("{id}", Name = "GetExpencesById")]
        public IActionResult Get(int id)
        {
            var Expences = _Expenceservice.GetExpencesById(id);
            if (Expences == null)
            {
                return NotFound();
            }

            return Ok(Expences);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ExpencesDTO ExpencesDto)
        {
            if (ExpencesDto == null || id != ExpencesDto.Id)
            {
                return BadRequest("Expences data is invalid.");
            }

            var updatedExpences = _Expenceservice.UpdateExpences(id, ExpencesDto);
            if (updatedExpences == null)
            {
                return NotFound();
            }

            return Ok(updatedExpences);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Expences = _Expenceservice.GetExpencesById(id);
            if (Expences == null)
            {
                return NotFound();
            }

            _Expenceservice.DeleteExpences(id);
            return NoContent();
        }
    }
}
