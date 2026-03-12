using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsApiTask.Data;
using ProductsApiTask.Models;

namespace ProductsApiTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Products
        // GET: api/Products
        [HttpGet]
        public async Task<IActionResult> GetProducts(int pageNumber = 1, int pageSize = 50)
        {
            
            if (pageSize > 100)
                pageSize = 100;

            // Numri total i produkteve
            var totalCount = await _context.Products.CountAsync();

           
            var products = await _context.Products.Include(p => p.Category).Skip(pageNumber * pageSize).Take(pageSize).ToListAsync();

            // Kthe rezultatet 
            return Ok(new
            {
                totalCount,
                pageNumber,
                pageSize,
                data = products
            });

        }
        // GET: api/Products/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.ID == id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            // Verifikim qe kategoria ekziston
            var category = await _context.Categories.FindAsync(product.CategoryID);
            if (category == null)
            {
                return BadRequest("Kategoria nuk ekziston");
            }

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = product.ID }, product);
        }

        // PUT: api/Products/id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.ID)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Products/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ID == id);
        }
    }
}