using CSShopping.ProductAPI.Data.ViewModel;
using CSShopping.ProductAPI.Model;

namespace CSShopping.ProductAPI.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductViewModel>> FindAll();
        Task<ProductViewModel> FindById(long id);
        Task<ProductViewModel> Create(ProductViewModel product);
        Task<ProductViewModel> Update(ProductViewModel product);
        Task<bool> Delete(long id);
    }
}
