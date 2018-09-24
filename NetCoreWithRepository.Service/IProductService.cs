using NetCoreWithRepository.Data.Entities;
using NetCoreWithRepository.Data.Model.Request;
using NetCoreWithRepository.Data.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NetCoreWithRepository.Service
{
    public interface IProductService
    {
        Task<BaseResponseModel<List<Product>>> List(Expression<Func<Product, bool>> filter, int take);
        Task<BaseResponseModel<Product>> Get(Expression<Func<Product, bool>> filter);
        Task<BaseResponseModel<Product>> Get(object Id);
        Task<BaseResponseModel<bool>> Create(ProductRequestModel model);
        Task<BaseResponseModel<bool>> Update(ProductRequestModel model);
        Task<BaseResponseModel<bool>> Delete(int Id);
    }
}
