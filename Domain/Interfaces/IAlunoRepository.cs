using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IAlunoRepository: IRepository<Aluno>, IMatricula<Aluno>
    {
        //Aqui, assinaturas de métodos exclusivos a Aluno
    }
}
