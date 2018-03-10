using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Aluno : Pessoa
    {
        public Aluno()
        {
            Usuario = new Usuario();
        }
        public int AlunoId { get; set; }
        public virtual Turma Turma { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
