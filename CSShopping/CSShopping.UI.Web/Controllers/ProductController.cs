using CSShopping.UI.Web.Models;
using CSShopping.UI.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CSShopping.UI.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> Index()
        {
            var product = await _productService.FindAllProducts();
            return View(product);
        }

        public async Task<IActionResult> ProductCreate() => View();

        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.CreateProduct(product);

                if (response != null)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(product);
        }

        public async Task<IActionResult> ProductUpdate(int id)
        {

            var product = await _productService.FindProductById(id);

            if (product is null) return NotFound();

            return View(product);
        }


        [HttpPost]
        public async Task<IActionResult> ProductUpdate(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.UpdateProduct(product);

                if (response != null)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(product);
        }

        public async Task<IActionResult> ProductDelete(int id)
        {
            var product = await _productService.FindProductById(id);

            if (product is null) return NotFound();

            var response = await _productService.DeleteProductById(id);

            if(response)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }
       
    }
}
