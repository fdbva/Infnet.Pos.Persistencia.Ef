using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Infra.Repository
{
    public class Repository<TEntity>: IRepository<TEntity> where TEntity : class
    {
        protected readonly DataContext Ctx;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(DataContext context)
        {
            Ctx = context;
            DbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return DbSet.ToList();
        }

        public TEntity ObterPorId(int id)
        {
            return DbSet.Find(id);
        }

        public void Adicionar(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public void Atualizar(TEntity obj)
        {
            var entry = Ctx.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;
        }

        public void Remover(int id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }
    }
}
