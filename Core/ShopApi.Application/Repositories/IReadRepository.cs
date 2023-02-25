using ShopApi.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null, params string[] includeProperties);
        IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null, bool tracking = true);
        Task<T> GetAsync(Expression<Func<T, bool>> filter, params string[] includeProperties);
        Task<T> GetAsync(Expression<Func<T, bool>> filter,bool tracking = true);
        Task<T> GetByIdAsync(Guid id, bool tracking = true);

    }
}
