using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;

namespace Infra.Repository
{
    public class TurmaRepository: Repository<Turma>, ITurmaRepository
    {
        public TurmaRepository(DataContext context) : base(context)
        {
        }
    }
}
