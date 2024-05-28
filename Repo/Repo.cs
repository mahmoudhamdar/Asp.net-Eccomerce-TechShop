 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Repo.IRepo;
using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Http.HttpResults;
using WebApplication1.Areas.Admin.Models;

namespace WebApplication1.Repo
{
    public class Repo<T> : IRepo<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;



        public Repo(ApplicationDbContext db)
        {
            _db = db;
            dbSet = _db.Set<T>();
            _db.Products.Include(p => p.Category).Include(p => p.CategoryId);

        }
        public void Add(T entity)
        {

            dbSet.Add(entity);

        }

        public T Get(Expression<Func<T, bool>>? filter, string? includeProperties = null, bool tracked = false)
        {
            IQueryable<T> query;
            if (tracked)
            {
                 query = dbSet;
            }
            else
            {   query = dbSet.AsNoTracking();
            
            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties.Split(new[] { ',' },
                             StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            T? q = query.Where(filter).FirstOrDefault();

            return q;
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter=null,string? includeProperties=null)
        {
            IQueryable<T> query = dbSet;
            if (filter!=null)
            {
                query= query.Where(filter);
                
            }
             
            if (!string.IsNullOrEmpty(includeProperties))
            {
                  foreach (var includeProp in includeProperties.Split(new []{','},StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();
        }


        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }


}