using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Infra.Repository;

namespace Infra.UoW
{
    public class UnitOfWork
    {
        public DataContext Db = new DataContext();
        private IAlunoRepository alunoRepository;

        private ITurmaRepository turmaRepository;
        //private IProfessorRepository professorRepository;
        //etc

        public IAlunoRepository AlunoRepository
        {
            get
            {
                if (this.alunoRepository == null)
                {
                    this.alunoRepository = new AlunoRepository(Db);
                }

                return alunoRepository;
            }
        }

        public ITurmaRepository TurmaRepository
        {
            get
            {
                if (this.turmaRepository == null)
                {
                    this.turmaRepository = new TurmaRepository(Db);
                }

                return turmaRepository;
            }
        }

        //Outras propriedades de repositorio...

        public void Commit()
        {
            Db.SaveChanges();
        }


    }
}
