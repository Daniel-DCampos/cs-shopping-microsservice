using CSShopping.UI.Web.Models;
using CSShopping.UI.Web.Services.IServices;
using CSShopping.UI.Web.Utils;

namespace CSShopping.UI.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        public const string BasePath = "api/v1/product";

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ProductModel>> FindAllProducts()
        {
            var response = await _httpClient.GetAsync($"{BasePath}/FindAll");
            return await response.ReadContentAsync<IEnumerable<ProductModel>>();
        }

        public async Task<ProductModel> FindProductById(long id)
        {
            var response = await _httpClient.GetAsync($"{BasePath}/FindById/{id}");
            return await response.ReadContentAsync<ProductModel>();
        }

        public async Task<ProductModel> CreateProduct(ProductModel product)
        {
            var response = await _httpClient.PostAsJsonAsync(BasePath, product);

            if (!response.IsSuccessStatusCode)
                throw new Exception();

            return await response.ReadContentAsync<ProductModel>();
        }
        public async Task<ProductModel> UpdateProduct(ProductModel product)
        {
            var response = await _httpClient.PutAsJsonAsync(BasePath, product);

            if (!response.IsSuccessStatusCode)
                throw new Exception();

            return await response.ReadContentAsync<ProductModel>();
        }

        public async Task<bool> DeleteProductById(long id)
        {
            var response = await _httpClient.DeleteAsync($"{BasePath}/{id}");

            if (!response.IsSuccessStatusCode)
                throw new Exception();

            return response.IsSuccessStatusCode;
        }
    }
}
