using Domain.Entities;

namespace Infra.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Infra.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Infra.DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var professor1 = new Professor { Nome = "Gustavo Miranda" };
            var professor2 = new Professor { Nome = "Leonardo Nascimento" };
            var professor3 = new Professor { Nome = "Carlos Pivotto" };

            var curso1 = new Curso { Descricao = "Engenharia de Software com .NET" };
            curso1.Professores.Add(professor1);
            curso1.Professores.Add(professor2);

            var curso2 = new Curso { Descricao = "Engenharia de Software com Java" };
            curso2.Professores.Add(professor1);
            curso2.Professores.Add(professor3);

            context.Cursos.AddOrUpdate(curso1);
            context.Cursos.AddOrUpdate(curso2);
        }
    }
}
