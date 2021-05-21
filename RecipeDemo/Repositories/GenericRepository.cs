using Microsoft.EntityFrameworkCore;
using RecipeDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RecipeDemo.Repositories
{
    public class GenericRepository<T> where T : class, new()
    {
        Context context = new Context();

        public List<T> TList()
        {
            return context.Set<T>().ToList();
        }

        public void TAdd(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }

        public void TDelete(T entity)
        {
            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }

        public void TUpdate(T entity)
        {
            context.Set<T>().Update(entity);
            context.SaveChanges();
        }

        public T TGet(int id)
        {
            return context.Set<T>().Find(id);
        }

        public List<T> TList(string entity)
        {
            return context.Set<T>().Include(entity).ToList();
        }

        public List<T> List(Expression<Func<T,bool>> filter)
        {
            return context.Set<T>().Where(filter).ToList();
        }

     
    }
}
