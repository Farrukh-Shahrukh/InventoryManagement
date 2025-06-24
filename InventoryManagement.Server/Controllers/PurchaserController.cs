using investmentsManagement.Server.Data.Models.ViewModels;
using investmentsManagement.Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace investmentsManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaserController : ControllerBase
    {
        private readonly IPurchaserService _purchaserService;

        public PurchaserController(IPurchaserService purchaserService)
        {
            _purchaserService = purchaserService;
        }

        // GET: api/Purchaser
        [HttpGet]
        public ActionResult<List<PurchaserDTO>> GetAll()
        {
            var purchasers = _purchaserService.GetAllPurchaser();
            return Ok(purchasers);
        }

        // GET: api/Purchaser/5
        [HttpGet("{id}")]
        public ActionResult<PurchaserDTO> GetById(int id)
        {
            var purchaser = _purchaserService.GetPurchaserById(id);
            if (purchaser == null)
                return NotFound();

            return Ok(purchaser);
        }

        // POST: api/Purchaser
        [HttpPost]
        public ActionResult<PurchaserDTO> Create([FromBody] PurchaserDTO dto)
        {
            var created = _purchaserService.CreatePurchaser(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT: api/Purchaser/5
        [HttpPut("{id}")]
        public ActionResult<PurchaserDTO> Update(int id, [FromBody] PurchaserDTO dto)
        {
            try
            {
                var updated = _purchaserService.UpdatePurchaser(id, dto);
                return Ok(updated);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/Purchaser/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _purchaserService.DeletePurchaser(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
