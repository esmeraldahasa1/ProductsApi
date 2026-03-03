using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsApiTask.Data;
using ProductsApiTask.Models;

namespace ProductsApiTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAll()
        {
            return Ok(await _context.Categories.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<Category>> Create(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAll), new { id = category.ID }, category);
        }
    }
}