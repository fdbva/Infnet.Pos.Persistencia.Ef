using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Professor : Pessoa
    {
        public Professor()
        {
            Cursos = new List<Curso>();
            Turmas = new List<Turma>();
        }
        public int ProfessorId { get; set; }
        public virtual ICollection<Curso> Cursos { get; set; }
        public virtual ICollection<Turma> Turmas { get; set; }

        public override string ToString()
        {
            return Nome;
        }
    }
}
