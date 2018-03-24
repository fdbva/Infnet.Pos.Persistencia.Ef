using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Infra;
using Infra.Repository;
using Infra.UoW;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Teste3();
        }

        private static void Teste3()
        {
            UnitOfWork uow = new UnitOfWork();
            Aluno aluno = uow.AlunoRepository.ObterPorId(1);
            aluno.Nome = "Madeinusa Letsgo";
            uow.AlunoRepository.Atualizar(aluno);
            /*Turma turma = uow.TurmaRepository.ObterPorId(1);
            turma.Alunos.Add(aluno);*/
            uow.Commit();
            System.Console.WriteLine(uow.AlunoRepository.ObterPorId(1).Nome);
            System.Console.ReadKey();
        }

        private static void Teste2()
        {
            UnitOfWork uow = new UnitOfWork();
            Aluno aluno = new Aluno();
            aluno.Nome = "Aluno Novo";
            Usuario usuario = new Usuario();
            usuario.Email = "alunonovo@ies.edu.br";
            usuario.Senha = "12345";

            aluno.Usuario = usuario;
            aluno.Turma = uow.TurmaRepository.ObterPorId(1);

            uow.AlunoRepository.Adicionar(aluno);
            uow.Commit();

            System.Console.WriteLine("Commit realizado");
            System.Console.ReadKey();
        }

        private static void Teste1()
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
