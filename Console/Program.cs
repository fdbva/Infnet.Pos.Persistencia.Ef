using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infra;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new DataContext();

            var cursos = db.Cursos
                .Include(x => x.Professores)
                .ToList();

            var curso = cursos.FirstOrDefault(x => x.CursoId == 1);
            var professor = curso.Professores.FirstOrDefault(x => x.ProfessorId == 1);

            var turma = new Turma
            {
                DataInicio = DateTime.Now,
                DataTermino = DateTime.Now.AddDays(15),
                Curso = curso,
                Professor = professor,
                Alunos = new List<Aluno>
                {
                    new Aluno
                    {
                        Nome = "Joãozinho",
                        Usuario = new Usuario
                        {
                            Email = "joaozinho@ies.edu.br",
                            Senha = "12345"
                        }
                    }
                }
            };
            db.Turmas.Add(turma);
            db.SaveChanges();
        }
    }
}
