using InventoryManagement.Server.Data.Models.ViewModels;
using InventoryManagement.Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenceTypeController : ControllerBase
    {


        private readonly IExpenceTypeService _ExpenceTypeervice;
        public ExpenceTypeController(IExpenceTypeService ExpenceTypeervice)
        {
            _ExpenceTypeervice = ExpenceTypeervice;
        }
        [HttpGet(Name = "GetAllExpenceType")]
        public IActionResult Get()
        {
            return Ok(_ExpenceTypeervice.GetAllExpenceTypes());
        }
        [HttpPost]
        public IActionResult Create([FromBody] ExpenceTypesDTO ExpenceTypeDto)
        {
            if (ExpenceTypeDto == null)
            {
                return BadRequest("ExpenceType data is null.");
            }

            var createdExpenceType = _ExpenceTypeervice.CreateExpenceTypes(ExpenceTypeDto);
            return CreatedAtRoute("GetExpenceTypeById", new { id = createdExpenceType.Id }, createdExpenceType);
        }

        [HttpGet("{id}", Name = "GetExpenceTypeById")]
        public IActionResult Get(int id)
        {
            var ExpenceType = _ExpenceTypeervice.GetExpenceTypesById(id);
            if (ExpenceType == null)
            {
                return NotFound();
            }

            return Ok(ExpenceType);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ExpenceTypesDTO ExpenceTypeDto)
        {
            if (ExpenceTypeDto == null || id != ExpenceTypeDto.Id)
            {
                return BadRequest("ExpenceType data is invalid.");
            }

            var updatedExpenceType = _ExpenceTypeervice.UpdateExpenceTypes(id, ExpenceTypeDto);
            if (updatedExpenceType == null)
            {
                return NotFound();
            }

            return Ok(updatedExpenceType);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var ExpenceType = _ExpenceTypeervice.GetExpenceTypesById(id);
            if (ExpenceType == null)
            {
                return NotFound();
            }

            _ExpenceTypeervice.DeleteExpenceTypes(id);
            return NoContent();
        }
    }
}
