using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NetCoreWithRepository.Data.Context;
using NetCoreWithRepository.Data.Entities;
using NetCoreWithRepository.Data.Model.Request;
using NetCoreWithRepository.Data.Model.Response;
using NetCoreWithRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NetCoreWithRepository.Service.Implementation
{
    public class ProductService:IProductService
    {
        private readonly BaseRepository<Product> repository = null;
        public ProductService(DbContextOptions<DataContext> options) : base()
        {
            this.repository = new Repository<Product>(options);
        }

        public Task<BaseResponseModel<bool>> Create(ProductRequestModel model)
        {
            var config = new MapperConfiguration(cfg => {

                cfg.CreateMap<ProductRequestModel, Product>();

            });

            IMapper iMapper = config.CreateMapper();

            var Product = iMapper.Map<ProductRequestModel, Product>(model);

            var result = repository.Create(Product);
            return result;
        }

        public Task<BaseResponseModel<bool>> Update(ProductRequestModel model)
        {
            var config = new MapperConfiguration(cfg => {

                cfg.CreateMap<ProductRequestModel, Product>();

            });

            IMapper iMapper = config.CreateMapper();

            var Product = iMapper.Map<ProductRequestModel, Product>(model);

            var result = repository.Update(Product);
            return result;
        }

        public Task<BaseResponseModel<bool>> Delete(int Id)
        {
            var result = repository.Delete(Id);
            return result;
        }

        public Task<BaseResponseModel<Product>> Get(Expression<Func<Product, bool>> filter)
        {
            var result = repository.Get(filter);
            return result;
        }

        public Task<BaseResponseModel<Product>> Get(object Id)
        {
            var result = repository.Get(Id);
            return result;
        }

        public Task<BaseResponseModel<List<Product>>> List(Expression<Func<Product, bool>> filter, int take)
        {
            var result = repository.List(filter, take);
            return result;
        }
    }
}
