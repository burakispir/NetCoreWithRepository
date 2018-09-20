using NetCoreWithRepository.Data.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NetCoreWithRepository.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<BaseResponseModel<List<T>>> List(Expression<Func<T, bool>> filter, int take);
        Task<BaseResponseModel<List<T>>> List();
        Task<BaseResponseModel<T>> Get(Expression<Func<T, bool>> filter);
        Task<BaseResponseModel<T>> Get(object Id);
        Task<BaseResponseModel<bool>> Create(T entity);
        Task<BaseResponseModel<bool>> Update(T entity);
        Task<BaseResponseModel<bool>> Delete(int Id);
    }
}
