using investmentsManagement.Server.Data.Models.ViewModels;
using investmentsManagement.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace investmentsManagement.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseTypeController : ControllerBase
    {


        private readonly IExpenceTypeService _ExpenseTypeService;
        public ExpenseTypeController(IExpenceTypeService ExpenseTypeService)
        {
            _ExpenseTypeService = ExpenseTypeService;
        }
        [HttpGet(Name = "GetAllExpenseType")]
        public IActionResult Get()
        {
            return Ok(_ExpenseTypeService.GetAllExpenceTypes());
        }
        [HttpPost]
        public IActionResult Create([FromBody] ExpenceTypesDTO ExpenceTypeDto)
        {
            if (ExpenceTypeDto == null)
            {
                return BadRequest("ExpenceType data is null.");
            }

            var createdExpenceType = _ExpenseTypeService.CreateExpenceTypes(ExpenceTypeDto);
            return CreatedAtRoute("GetExpenceTypeById", new { id = createdExpenceType.Id }, createdExpenceType);
        }

        [HttpGet("{id}", Name = "GetExpenceTypeById")]
        public IActionResult Get(int id)
        {
            var ExpenceType = _ExpenseTypeService.GetExpenceTypesById(id);
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

            var updatedExpenceType = _ExpenseTypeService.UpdateExpenceTypes(id, ExpenceTypeDto);
            if (updatedExpenceType == null)
            {
                return NotFound();
            }

            return Ok(updatedExpenceType);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var ExpenceType = _ExpenseTypeService.GetExpenceTypesById(id);
            if (ExpenceType == null)
            {
                return NotFound();
            }

            _ExpenseTypeService.DeleteExpenceTypes(id);
            return NoContent();
        }
    }
}
