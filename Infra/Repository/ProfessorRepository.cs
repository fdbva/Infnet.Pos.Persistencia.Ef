using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;

namespace Infra.Repository
{
    public class ProfessorRepository: Repository<Professor>, IProfessorRepository
    {
        public ProfessorRepository(DataContext context) : base(context)
        {
            //Detalhes especificos para Professor
        }

        public Professor ObterPorMatricula(string matricula)
        {
            throw new NotImplementedException();
        }
    }
}
