using AutoMapper;
using CSShopping.ProductAPI.Data.ViewModel;
using CSShopping.ProductAPI.Model;
using CSShopping.ProductAPI.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace CSShopping.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private SQLServerContext _context;
        private IMapper _mapper;
        public ProductRepository(SQLServerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductViewModel> Create(ProductViewModel product)
        {
            await _context.Products.AddAsync(_mapper.Map<Product>(product));
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                Product product = await _context.FindAsync<Product>(id) ?? new Product();

                if (product == null) return false;

                _context.Products.Remove(product);
                 await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<ProductViewModel>> FindAll()
        {
            return _mapper.Map<IEnumerable<ProductViewModel>>(await _context.Products.ToListAsync());
        }

        public async Task<ProductViewModel> FindById(long id)
        {
            return _mapper.Map<ProductViewModel>(await _context.FindAsync<Product>(id)) ?? new ProductViewModel();
        }

        public async Task<ProductViewModel> Update(ProductViewModel product)
        {
            _context.Products.Update(_mapper.Map<Product>(product));
            await _context.SaveChangesAsync();

            return product;
        }
    }
}
