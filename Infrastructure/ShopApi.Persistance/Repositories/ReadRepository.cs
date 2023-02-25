using Microsoft.EntityFrameworkCore;
using ShopApi.Application.Repositories;
using ShopApi.Domain.Entities.Common;
using ShopApi.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Persistance.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;

        public ReadRepository(AppDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null, params string[] includeProperties)
        {
            var query = Table.AsQueryable();
            if (includeProperties != null)
                query = includeProperties.Aggregate(query, (current, include) => current.Include(include));

            return filter == null ? query : query.Where(filter);
        }


        public async Task<T> GetAsync(Expression<Func<T, bool>> filter, params string[] includeProperties)
        {
            var query = Table.AsQueryable();
            if (includeProperties != null)
                query = includeProperties.Aggregate(query, (current, include) => current.Include(include));
            return await query.FirstOrDefaultAsync(filter);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return filter == null? query : query.Where(filter);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(filter);
        }

        public async Task<T> GetByIdAsync(Guid id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if(!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
