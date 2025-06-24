using investmentsManagement.Server.Data.Models.ViewModels;
using investmentsManagement.Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace investmentsManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalePurchaseAttachmentController : ControllerBase
    {
        private readonly ISalePurchaseAttachmentService _service;

        public SalePurchaseAttachmentController(ISalePurchaseAttachmentService service)
        {
            _service = service;
        }

        // GET: api/SalePurchaseAttachment
        [HttpGet]
        public ActionResult<List<SalePurchaseAttachmentDTO>> GetAll()
        {
            var attachments = _service.GetAllSalePurchaseAttachment();
            return Ok(attachments);
        }

        // GET: api/SalePurchaseAttachment/5
        [HttpGet("{id}")]
        public ActionResult<SalePurchaseAttachmentDTO> GetById(int id)
        {
            var attachment = _service.GetSalePurchaseAttachmentById(id);
            if (attachment == null)
                return NotFound();

            return Ok(attachment);
        }

        // POST: api/SalePurchaseAttachment
        [HttpPost]
        public ActionResult<SalePurchaseAttachmentDTO> Create([FromBody] SalePurchaseAttachmentDTO dto)
        {
            var created = _service.CreateSalePurchaseAttachment(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT: api/SalePurchaseAttachment/5
        [HttpPut("{id}")]
        public ActionResult<SalePurchaseAttachmentDTO> Update(int id, [FromBody] SalePurchaseAttachmentDTO dto)
        {
            try
            {
                var updated = _service.UpdateSalePurchaseAttachment(id, dto);
                return Ok(updated);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/SalePurchaseAttachment/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.DeleteSalePurchaseAttachment(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
