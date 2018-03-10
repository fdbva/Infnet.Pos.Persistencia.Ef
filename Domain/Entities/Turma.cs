using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Turma
    {
        public Turma()
        {
            Alunos = new List<Aluno>();
        }
        public int TurmaId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public virtual Professor Professor { get; set; }
        public virtual Curso Curso { get; set; }
        public virtual ICollection<Aluno> Alunos { get; set; }

        public override string ToString()
        {
            return
                $"Turma {Curso} - Inicio: {DataInicio:d} - " +
                $"Término: {DataTermino:d} - Professor: {Professor}";
        }
    }
}