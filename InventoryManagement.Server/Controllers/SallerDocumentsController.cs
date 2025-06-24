using investmentsManagement.Server.Data.Models.ViewModels;
using investmentsManagement.Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace investmentsManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SallerDocumentsController : ControllerBase
    {
        private readonly ISallerDocumentsService _sallerDocumentsService;

        public SallerDocumentsController(ISallerDocumentsService sallerDocumentsService)
        {
            _sallerDocumentsService = sallerDocumentsService;
        }

        // GET: api/SallerDocuments
        [HttpGet]
        public ActionResult<List<SallerDocumentsDTO>> GetAll()
        {
            var documents = _sallerDocumentsService.GetAllSallerDocuments();
            return Ok(documents);
        }

        // GET: api/SallerDocuments/5
        [HttpGet("{id}")]
        public ActionResult<SallerDocumentsDTO> GetById(int id)
        {
            var doc = _sallerDocumentsService.GetSallerDocumentsById(id);
            if (doc == null)
                return NotFound();

            return Ok(doc);
        }

        // POST: api/SallerDocuments
        [HttpPost]
        public ActionResult<SallerDocumentsDTO> Create([FromBody] SallerDocumentsDTO dto)
        {
            var created = _sallerDocumentsService.CreateSallerDocuments(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT: api/SallerDocuments/5
        [HttpPut("{id}")]
        public ActionResult<SallerDocumentsDTO> Update(int id, [FromBody] SallerDocumentsDTO dto)
        {
            try
            {
                var updated = _sallerDocumentsService.UpdateSallerDocuments(id, dto);
                return Ok(updated);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/SallerDocuments/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _sallerDocumentsService.DeleteSallerDocuments(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
