using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infra
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DataContext")
        {
            /* Lazy Loading: carregamento automático de propriedades relacionadas ao objeto
             * Por exemplo, carregar uma Turma ao obter dados de um Aluno
             * Pode resultar em queda de performance, portanto desabilitaremos
             * Caso se deseje inserir o objeto relacionado (Turma)
             * ao objeto buscando (Aluno), use .Include()
             */
            Configuration.LazyLoadingEnabled = false; //Podemos usar o método .Include()

            /* O Ef por padrão cria um proxy sempre que uma entidade é instanciada
             * para realizar mudanças e carregar automaticamente as propriedades virtuais.
             * Como não vamos usar o LazyLoading, vamos desabilitar o proxy,
             * pois ele não faria muito sentido.
             */
            Configuration.ProxyCreationEnabled = false;
        }

        /* Entidades que serão convertidas em tabelas de banco de dados pelo ORM */
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Turma> Turmas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
