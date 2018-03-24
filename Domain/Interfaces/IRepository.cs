using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Método que retorna todos os elementos do tipo
        /// </summary>
        /// <returns>IEnumberable dos elementos</returns>
        IEnumerable<TEntity> ObterTodos();
        TEntity ObterPorId(int id);
        void Adicionar(TEntity obj);
        void Atualizar(TEntity obj);
        void Remover(int id);
        /// <summary>
        /// Realizar uma busca, dada uma entidade e uma condicao booleana predicada
        /// </summary>
        /// <param name="predicate">Condicao booleana</param>
        /// <returns></returns>
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);

    }
}
