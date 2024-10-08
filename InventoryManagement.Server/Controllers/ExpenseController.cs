using InventoryManagement.Server.Data.Models.ViewModels;
using InventoryManagement.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _ExpenseService;
        public ExpenseController(IExpenseService ExpenseService)
        {
            _ExpenseService = ExpenseService;
        }
        [HttpGet(Name = "GetAllExpenses")]
        public IActionResult Get()
        {
            return Ok(_ExpenseService.GetAllExpense());
        }
        [HttpPost]
        public IActionResult Create([FromBody] ExpencesDTO expenseDto)
        {
            if (expenseDto == null)
            {
                return BadRequest("Expense data is null.");
            }

            var createdExpense = _ExpenseService.CreateExpense(expenseDto);
            return CreatedAtRoute("GetExpenseById", new { id = createdExpense.Id }, createdExpense);
        }

        [HttpGet("{id}", Name = "GetExpenseById")]
        public IActionResult Get(int id)
        {
            var expense = _ExpenseService.GetExpenseById(id);
            if (expense == null)
            {
                return NotFound();
            }

            return Ok(expense);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ExpencesDTO ExpenseDto)
        {
            if (ExpenseDto == null || id != ExpenseDto.Id)
            {
                return BadRequest("Expense data is invalid.");
            }

            var updatedExpense = _ExpenseService.UpdateExpense(id, ExpenseDto);
            if (updatedExpense == null)
            {
                return NotFound();
            }

            return Ok(updatedExpense);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var expense = _ExpenseService.GetExpenseById(id);
            if (expense == null)
            {
                return NotFound();
            }

            _ExpenseService.DeleteExpense(id);
            return NoContent();
        }
    }
}
