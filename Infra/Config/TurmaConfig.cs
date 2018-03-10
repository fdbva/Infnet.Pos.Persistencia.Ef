using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infra.Config
{
    public class TurmaConfig : EntityTypeConfiguration<Turma>
    {
        public TurmaConfig()
        {
            ToTable("Turma");
            HasKey(x => x.TurmaId);

            /* Na entidade Turma, o Curso é obrigatório*/
            HasRequired(x => x.Curso)
                .WithMany(x => x.Turmas) //Curso pode ter várias turmas
                .Map(x => x.MapKey("CursoId"));  //A chave estrangeira em turma é CursoId

            HasRequired(x => x.Professor)
                .WithMany(x => x.Turmas)
                .Map(x => x.MapKey("ProfessorId"));
        }
    }
}
