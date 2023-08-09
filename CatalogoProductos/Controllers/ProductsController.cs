using CatalogoProductos.Aplication.Dtos;
using CatalogoProductos.Aplication.Services;
using CatalogoProductos.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoProductos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts([FromQuery] ProductQueryParameters parameters)
        {
            var products = await _productService.GetAllAsync(parameters.Name, parameters.Description, parameters.Category, parameters.OrderBy, parameters.IsAscending);
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> PostProduct([FromBody] ProductDTO productDTO)
        {
            await _productService.CreateAsync(productDTO);
            return CreatedAtAction(nameof(GetProduct), new { id = productDTO.Id }, productDTO);
        }

        [HttpPut()]
        public async Task<IActionResult> PutProduct([FromBody] ProductDTO product)
        {
            try
            {
                await _productService.UpdateAsync(product);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                await _productService.DeleteAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }
    }
}
