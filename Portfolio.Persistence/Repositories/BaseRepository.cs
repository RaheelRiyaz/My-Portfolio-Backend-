using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Portfolio.Core.Abstractions.IRepository;
using Portfolio.Domain.Models;
using Portfolio.Persistence.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Portfolio.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity, new()
    {
        protected readonly RaheelPortfolioDbContext dbContext;

        public DbSet<T> db_set { get; set; }
        public BaseRepository(RaheelPortfolioDbContext dbContext)
        {
            db_set = dbContext.Set<T>();
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<T>> FetchAll()
        {
            return await Task.FromResult(db_set);
        }

        public async Task<T?> FindOneAsync(Expression<Func<T, bool>> expression)
        {
            return await db_set.FirstOrDefaultAsync(expression);
        }

        public async Task<T?> FindOneAsync(Guid id)
        {
            return await db_set.FindAsync(id);
        }

        public async Task<int> InsertAsync(T model)
        {
            await dbContext.AddAsync(model);
            return await SaveChangesAsync();
        }

        public async Task<int> InsertRangeAsync(List<T> models)
        {
            await db_set.AddRangeAsync(models);
            return await SaveChangesAsync();
        }

        public async Task<int> RemoveAsync(T model)
        {
            db_set.Remove(model);
            return await SaveChangesAsync();
        }

        public async Task<int> RemoveAsync(Guid id)
        {
            db_set.Remove(new T { Id = id });
            return await SaveChangesAsync();
        }

        public async Task<int> RemoveRangeAsync(List<T> models)
        {
            db_set.RemoveRange(models);
            return await SaveChangesAsync();
        }

        public async Task<int> RemoveRangeAsync(List<Guid> ids)
        {
            List<T> models = new List<T>();

            foreach (var id in ids)
            {
                models.Add(new T { Id = id });
            }

            db_set.RemoveRange(models);
            return await SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> SearchAsync(Expression<Func<T, bool>> expression)
        {
            return await db_set.Where(expression).ToListAsync();
        }

        public async Task<int> UpdateAsync(T model)
        {
            db_set.Update(model);
            return await SaveChangesAsync();
        }


        private Task<int> SaveChangesAsync() => 
            dbContext.SaveChangesAsync();

        public IDbContextTransaction StartTransaction()
        {
            var transaction = dbContext.Database.BeginTransaction();
            return transaction;
        }
    }
}
