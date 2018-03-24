using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IMatricula<TEntity> where TEntity: class
    {
        TEntity ObterPorMatricula(string matricula);
    }
}
