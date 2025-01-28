using ASPCoreWebAPI_CRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPCoreWebAPI_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        private readonly efdemoContext context;

        public ProductAPIController(efdemoContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Product>> GetProducts()
        {
            var data = await context.Products.ToListAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var data = await context.Products.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult<Product>>PostProduct(Product product)
        {
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            context.Entry(product).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            
            var product =  await context.Products.FindAsync(id);
            if(product == null)
            {
                return NotFound();
            }
            context.Products.Remove(product);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
