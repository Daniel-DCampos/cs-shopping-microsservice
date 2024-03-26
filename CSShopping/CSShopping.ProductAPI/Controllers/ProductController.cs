using CSShopping.ProductAPI.Data.ViewModel;
using CSShopping.ProductAPI.Repository;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CSShopping.ProductAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("[Action]/{id:long}")]
        public async Task<IActionResult> FindById(long id)
        {
            var product = await _productRepository.FindById(id);
            
            return product.Id == 0 || product is null ? NotFound() : Ok(product);
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> FindAll()
        {
            var product = await _productRepository.FindAll();

            return Ok(product);
        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> Create(ProductViewModel productViewModel)
        {
            try
            {
                var product = await _productRepository.Create(productViewModel);

                return Ok(product);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("[Action]")]
        public async Task<IActionResult> Update(ProductViewModel productViewModel)
        {
            try
            {
                var product = await _productRepository.Update(productViewModel);

                return Ok(product);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("[Action]/{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var product = await _productRepository.Delete(id);

                return product ? Ok() : NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



    }
}
