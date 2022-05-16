using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntitiyFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {  //Idisposebile pattern implemation of c# hızlıca belleği temizler.
            using (TContext context = new TContext()) //buraya yazılan nesneler using bitince bellekten atar garbage collectore gelir ve bellekten atılır
            {
                var addedEntity = context.Entry(entity);      //var karşısına ne atanırsa o veri tipi olan bir değişlken
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }
        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext()) //buraya yazılan nesneler using bitince bellekten atar garbage collectore gelir ve bellekten atılır
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }
        public TEntity Get()
        {
            throw new NotImplementedException();
        }
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();

            }
        }
        public void Update(TEntity entity)
        {
            using (TContext context = new TContext()) //buraya yazılan nesneler using bitince bellekten atar garbage collectore gelir ve bellekten atılır
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
