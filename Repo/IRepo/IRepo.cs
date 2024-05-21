using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Linq.Expressions;
namespace WebApplication1.Repo.IRepo
{
    public interface IRepo<T> where T : class
    {
        IEnumerable<T> GetAll(string? includeProperties=null);
        T Get(Expression<Func<T, bool>> filter,string? includeProperties=null);

        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}