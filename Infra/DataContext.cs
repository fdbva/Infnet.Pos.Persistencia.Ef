using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infra.Config;

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
        //Pessoa não entra aqui, pois não será tabela, é apenas uma abstração para Professor

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //remove convenção que cria tabelas com nome no plural.
            //Utilizaria regras de pluralização do inglês.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //Removem convenções de on delete para relacionamentos 1:n e M:N
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Estabelece como uma nova convenção que serão chaves primárias
            //as propriedades que atendem à condição: nome da entidade + Id
            modelBuilder.Properties()
                .Where(x => x.Name == $"{x.ReflectedType}Id")
                .Configure(x => x.IsKey());
            //Estabelecem que todas as propriedades strings mapeadas no BD serão do tipo varchar sempre.
            modelBuilder.Properties<string>()
                .Configure(x=>x.HasColumnType("varchar"));
            modelBuilder.Properties<string>()
                .Configure(x => x.HasMaxLength(100));

            modelBuilder.Configurations.Add(new AlunoConfig());
            modelBuilder.Configurations.Add(new CursoConfig());
            modelBuilder.Configurations.Add(new ProfessorConfig());
            modelBuilder.Configurations.Add(new TurmaConfig());
            modelBuilder.Configurations.Add(new UsuarioConfig());
        }
    }
}
