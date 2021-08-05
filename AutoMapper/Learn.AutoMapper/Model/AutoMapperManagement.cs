using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Learn.AutoMapper.Model
{
    public class AutoMapperManagement
    {

        IMapper _mapper;



        public object MappingClass<T, TViewModel>(object obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<T, TViewModel>();
            });

            IMapper _mapper = config.CreateMapper();
            var viewModel = _mapper.Map<TViewModel>(obj);
            return viewModel;
        }

        public ProductViewModel MappingClassProduct(Product p)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductViewModel>()
                .ForMember(p => p.Id, m => m.MapFrom(a => a.Id.ToString()))
                .ForMember(p => p.Description, m => m.MapFrom(a => a.NameProduct));
            });

            IMapper _mapper = config.CreateMapper();
            var viewModel = _mapper.Map<ProductViewModel>(p);
            return viewModel;
        }

    }
}
