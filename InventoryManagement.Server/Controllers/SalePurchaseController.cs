using investmentsManagement.Server.Data.Models.ViewModels;
using investmentsManagement.Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace investmentsManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalePurchaseController : ControllerBase
    {
        private readonly ISalePurchaseService _salePurchaseService;

        public SalePurchaseController(ISalePurchaseService salePurchaseService)
        {
            _salePurchaseService = salePurchaseService;
        }

        // GET: api/SalePurchase
        [HttpGet]
        public ActionResult<List<SalePurchaseDTO>> GetAll()
        {
            var result = _salePurchaseService.GetAllSalePurchase();
            return Ok(result);
        }

        // GET: api/SalePurchase/5
        [HttpGet("{id}")]
        public ActionResult<SalePurchaseDTO> GetById(int id)
        {
            var result = _salePurchaseService.GetSalePurchaseById(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // POST: api/SalePurchase
        [HttpPost]
        public ActionResult<SalePurchaseDTO> Create([FromBody] SalePurchaseDTO dto)
        {
            var created = _salePurchaseService.CreateSalePurchase(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT: api/SalePurchase/5
        [HttpPut("{id}")]
        public ActionResult<SalePurchaseDTO> Update(int id, [FromBody] SalePurchaseDTO dto)
        {
            try
            {
                var updated = _salePurchaseService.UpdateSalePurchase(id, dto);
                return Ok(updated);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/SalePurchase/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _salePurchaseService.DeleteSalePurchase(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
