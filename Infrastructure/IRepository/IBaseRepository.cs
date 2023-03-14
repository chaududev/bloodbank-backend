using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IRepository
{
    public interface IBaseRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        (IEnumerable<T> data, int total) Get(Expression<Func<T, object>>[]? includeProperties, Expression<Func<T, bool>>? filter, Expression<Func<T, object>>? orderBy, int? pageSize, int? page);
        T GetById(Expression<Func<T, object>>[]? includeProperties, int id);
    }
}
