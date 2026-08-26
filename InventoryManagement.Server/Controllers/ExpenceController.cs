using InventoryManagement.Server.Data.Models.ViewModels;
using InventoryManagement.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenceController : ControllerBase
    {
        private readonly IExpenceService _expenceService;

        public ExpenceController(IExpenceService expenceService)
        {
            _expenceService = expenceService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var expences = _expenceService.GetAllExpences();
            return Ok(expences);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var expence = _expenceService.GetExpenceById(id);
            if (expence == null)
            {
                return NotFound();
            }
            return Ok(expence);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ExpencesDTO expenceDto)
        {
            if (expenceDto == null)
            {
                return BadRequest("Expence data is null.");
            }

            var createdExpence = _expenceService.CreateExpence(expenceDto);
            return CreatedAtAction(nameof(GetById), new { id = createdExpence.Id }, createdExpence);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ExpencesDTO expenceDto)
        {
            if (expenceDto == null)
            {
                return BadRequest("Expence data is null.");
            }

            var updatedExpence = _expenceService.UpdateExpence(id, expenceDto);
            if (updatedExpence == null)
            {
                return NotFound();
            }
            return Ok(updatedExpence);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _expenceService.DeleteExpence(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost("{id}/upload-picture")]
        public async Task<IActionResult> UploadPicture(int id, IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return BadRequest("No file uploaded.");
                }

                var picturePath = await _expenceService.UploadExpensePicture(id, file);
                return Ok(new { picturePath });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
