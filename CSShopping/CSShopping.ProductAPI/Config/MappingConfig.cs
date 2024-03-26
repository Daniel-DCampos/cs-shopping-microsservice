using AutoMapper;
using CSShopping.ProductAPI.Data.ViewModel;
using CSShopping.ProductAPI.Model;

namespace CSShopping.ProductAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration MapperConfiguration()
        {
            var mappingConfig = new MapperConfiguration(config => {
                config.CreateMap<ProductViewModel, Product>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
