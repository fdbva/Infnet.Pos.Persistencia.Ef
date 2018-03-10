using System.Collections.Generic;

namespace Domain.Entities
{
    public class Curso
    {
        public Curso()
        {
            Professores = new List<Professor>();
        }

        public int CursoId { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<Professor> Professores { get; set; }

        public override string ToString()
        {
            return Descricao;
        }
    }
}