using investmentsManagement.Server.Data.Models.ViewModels;
using investmentsManagement.Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace investmentsManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaserDocumentsController : ControllerBase
    {
        private readonly IPurchaserDocumentsService _service;

        public PurchaserDocumentsController(IPurchaserDocumentsService service)
        {
            _service = service;
        }

        // GET: api/PurchaserDocuments
        [HttpGet]
        public ActionResult<List<PurchaserDocumentsDTO>> GetAll()
        {
            var docs = _service.GetAllPurchaserDocuments();
            return Ok(docs);
        }

        // GET: api/PurchaserDocuments/5
        [HttpGet("{id}")]
        public ActionResult<PurchaserDocumentsDTO> GetById(int id)
        {
            var doc = _service.GetPurchaserDocumentsById(id);
            if (doc == null)
                return NotFound();

            return Ok(doc);
        }

        // POST: api/PurchaserDocuments
        [HttpPost]
        public ActionResult<PurchaserDocumentsDTO> Create([FromBody] PurchaserDocumentsDTO dto)
        {
            var created = _service.CreatePurchaserDocuments(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT: api/PurchaserDocuments/5
        [HttpPut("{id}")]
        public ActionResult<PurchaserDocumentsDTO> Update(int id, [FromBody] PurchaserDocumentsDTO dto)
        {
            try
            {
                var updated = _service.UpdatePurchaserDocuments(id, dto);
                return Ok(updated);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/PurchaserDocuments/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.DeletePurchaserDocuments(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
