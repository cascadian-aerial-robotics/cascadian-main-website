using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cascadian.Abstractions
{
    public interface IRepository<TEntity, TId> where TEntity : class
    {
        Task<List<TEntity>> FetchAll();
        Task<IQueryable<TEntity>> Query { get; }
        Task Add(TEntity entity);

        Task Update(TEntity entity);

        Task Delete(TEntity entity);
        Task Save();
        Task<TEntity> Get(TId identifier);
    }
}
