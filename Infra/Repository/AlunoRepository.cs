using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;

namespace Infra.Repository
{
    public class AlunoRepository : Repository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(DataContext context) : base(context)
        {
            //Demais operacoes para construir objeto do tipo AlunoRepository
        }

        public Aluno ObterPorMatricula(string matricula)
        {
            throw new NotImplementedException();
        }

        public new Aluno ObterPorId(int id)
        {
            return DbSet
                .Include(x => x.Usuario)
                .FirstOrDefault(x => x.AlunoId == id);
        }
    }
}
