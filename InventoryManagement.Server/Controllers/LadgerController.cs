using investmentsManagement.Server.Data.Models.ViewModels;
using investmentsManagement.Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace investmentsManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LadgerController : ControllerBase
    {
        private readonly ILadgerService _Ladgerervice;
        public LadgerController(ILadgerService Ladgerervice)
        {
            _Ladgerervice = Ladgerervice;
        }
        [HttpGet(Name = "GetAllLadger")]
        public IActionResult Get()
        {
            return Ok(_Ladgerervice.GetAllLadger());
        }
        [HttpPost]
        public IActionResult Create([FromBody] LadgerDTO LadgerDto)
        {
            if (LadgerDto == null)
            {
                return BadRequest("Ladger data is null.");
            }

            var createdLadger = _Ladgerervice.CreateLadger(LadgerDto);
            return CreatedAtRoute("GetLadgerById", new { id = createdLadger.Id }, createdLadger);
        }

        [HttpGet("{id}", Name = "GetLadgerById")]
        public IActionResult Get(int id)
        {
            var Ladger = _Ladgerervice.GetLadgerById(id);
            if (Ladger == null)
            {
                return NotFound();
            }

            return Ok(Ladger);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] LadgerDTO LadgerDto)
        {
            if (LadgerDto == null || id != LadgerDto.Id)
            {
                return BadRequest("Ladger data is invalid.");
            }

            var updatedLadger = _Ladgerervice.UpdateLadger(id, LadgerDto);
            if (updatedLadger == null)
            {
                return NotFound();
            }

            return Ok(updatedLadger);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Ladger = _Ladgerervice.GetLadgerById(id);
            if (Ladger == null)
            {
                return NotFound();
            }

            _Ladgerervice.DeleteLadger(id);
            return NoContent();
        }
    }
}
