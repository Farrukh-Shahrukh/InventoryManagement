using investmentsManagement.Server.Data.Models.ViewModels;
using investmentsManagement.Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace investmentsManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SallerController : ControllerBase
    {
        private readonly ISallerService _sallerService;

        public SallerController(ISallerService sallerService)
        {
            _sallerService = sallerService;
        }

        // GET: api/Saller
        [HttpGet]
        public ActionResult<List<SallerDTO>> GetAll()
        {
            var sallers = _sallerService.GetAllSaller();
            return Ok(sallers);
        }

        // GET: api/Saller/5
        [HttpGet("{id}")]
        public ActionResult<SallerDTO> GetById(int id)
        {
            var saller = _sallerService.GetSallerById(id);
            if (saller == null)
                return NotFound();

            return Ok(saller);
        }

        // POST: api/Saller
        [HttpPost]
        [Consumes("multipart/form-data")]
        public ActionResult<SallerDTO> Create([FromForm] SallerDTO dto)
        {
            var created = _sallerService.CreateSaller(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT: api/Saller/5
        [HttpPut("{id}")]
        public ActionResult<SallerDTO> Update(int id, [FromBody] SallerDTO dto)
        {
            try
            {
                var updated = _sallerService.UpdateSaller(id, dto);
                return Ok(updated);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/Saller/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _sallerService.DeleteSaller(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
