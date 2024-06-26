using Microsoft.EntityFrameworkCore.Storage;
using Portfolio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Core.Abstractions.IRepository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<int> InsertAsync(T model);
        Task<int> InsertRangeAsync(List<T> models);
        Task<int> RemoveAsync(T model);
        Task<int> RemoveAsync(Guid id);
        Task<int> RemoveRangeAsync(List<T> models);
        Task<int> RemoveRangeAsync(List<Guid> ids);
        Task<int> UpdateAsync(T model);
        Task<IEnumerable<T>> SearchAsync(Expression<Func<T,bool>> expression);
        Task<IEnumerable<T>> FetchAll();
        Task<T?> FindOneAsync(Expression<Func<T,bool>> expression);
        Task<T?> FindOneAsync(Guid id);
        IDbContextTransaction StartTransaction();
    }
}
