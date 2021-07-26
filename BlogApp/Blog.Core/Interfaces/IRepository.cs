using Blog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity:class
    {
        Task<TEntity> Get(string id);
        Task<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        Task<IEnumerable<TEntity>> GetAll();
    }
}
