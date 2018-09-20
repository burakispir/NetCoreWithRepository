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
    public class CategoryService : ICategoryService
    {
        private readonly BaseRepository<Category> repository = null;
        public CategoryService(DbContextOptions<DataContext> options) : base()
        {
            this.repository = new Repository<Category>(options);
        }

        public Task<BaseResponseModel<bool>> Create(CategoryRequestModel model)
        {
            var config = new MapperConfiguration(cfg => {

                cfg.CreateMap<CategoryRequestModel, Category>();

            });

            IMapper iMapper = config.CreateMapper();

            var category = iMapper.Map<CategoryRequestModel, Category>(model);

            var result = repository.Create(category);
            return result;
        }

        public Task<BaseResponseModel<bool>> Update(CategoryRequestModel model)
        {
            var config = new MapperConfiguration(cfg => {

                cfg.CreateMap<CategoryRequestModel, Category>();

            });

            IMapper iMapper = config.CreateMapper();

            var category = iMapper.Map<CategoryRequestModel, Category>(model);

            var result = repository.Update(category);
            return result;
        }

        public Task<BaseResponseModel<bool>> Delete(int Id)
        {
            var result = repository.Delete(Id);
            return result;
        }

        public Task<BaseResponseModel<Category>> Get(Expression<Func<Category, bool>> filter)
        {
            var result = repository.Get(filter);
            return result;
        }

        public Task<BaseResponseModel<Category>> Get(object Id)
        {
            var result = repository.Get(Id);
            return result;
        }

        public Task<BaseResponseModel<List<Category>>> List(Expression<Func<Category, bool>> filter, int take)
        {
            var result = repository.List(filter, take);
            return result;
        }
    }
}
