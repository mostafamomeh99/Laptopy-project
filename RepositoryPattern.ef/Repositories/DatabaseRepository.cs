using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Repositorypattern.core.Const;
using Repositorypattern.core.IDatabaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace RepositoryPattern.ef.Repositories
{
    public class DatabaseRepository<T> : IDatabaseRepository<T> where T : class
    {
        protected readonly ApplicationDbContext context;

        public DatabaseRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public T Findme(Expression<Func<T, bool>> match, string[] includes = null)
        {
            if (includes == null)
            {
                return context.Set<T>().FirstOrDefault(match);
            }
            IQueryable<T> query = context.Set<T>();
            foreach (var item in includes)
            {
                query = query.Include(item);
            }
            return query.FirstOrDefault(match);
        }

        public IQueryable<T> FindAll(Expression<Func<T, bool>> match, string[] includes = null)
        {
            if (includes == null)
            {
                return context.Set<T>().Where(match);
            }
            else
            {
                IQueryable<T> query = context.Set<T>();
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
                return query.Where(match);
            }

        }


        public IQueryable<T> MatchOrder(Expression<Func<T, bool>> match = null, string[] includes = null, int? take = null, int? skip = null,
            Expression<Func<T, object>> orderby = null, string orderbydirection = Orderby.Ascending
            )
        {
            IQueryable<T> query = context.Set<T>();

            if (match != null)
            { query = query.Where(match); }


            if (skip != null)
            {
                query = query.Skip(skip ?? 0);
            }
            if (take != null)
            {
                query = query.Take(take ?? 0);
            }


            if (orderby != null)
            {
                if (orderbydirection == Orderby.Ascending)
                { query = query.OrderBy(orderby); }
                else
                {
                    query = query.OrderByDescending(orderby);
                }

            }


            if (includes == null)
            {
                return query;
            }
            else
            {
                foreach (var item in includes)
                    query = query.Include(item);
                return query;
            }



        }


        public void AddRange(IEnumerable<T> entities)
        {
            var query = context.Set<T>();
            foreach (var entity in entities)
            {
                query.Add(entity);
            }
            //context.SaveChanges();
        }


        public IQueryable<T> GetAll()
        {
            var query = context.Set<T>();

            return query;
        }

        public IQueryable<T> GetAllWith(string[] includes)
        {
            IQueryable<T> query = context.Set<T>();
            foreach (string entity in includes)
            {
                query = query.Include(entity);
            }
            return query;
        }

        public void Addone(T entitiy)
        {
            var query = context.Set<T>();
            query.Add(entitiy);
            //context.SaveChanges();
        }

        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
        }




        public void UpdateRange(List<T> entities)
        {

            context.Set<T>().UpdateRange(entities);


        } 

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);

        }
        public void DeleteRange(IEnumerable<T> entity)
        {
            context.Set<T>().RemoveRange(entity);

        }
        public void Attach(T entity)
        {
            context.Set<T>().Attach(entity);
        }

        public int Count()
        {
            return context.Set<T>().Count();
        }

        public int Count(Expression<Func<T, bool>> match)
        {
            return context.Set<T>().Where(match).Count();
        }









      







    }

}
