using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infra.Config
{
    public class AlunoConfig : EntityTypeConfiguration<Aluno>
    {
        public AlunoConfig()
        {
            ToTable("Aluno");
            HasKey(x => x.AlunoId);

            // 1:N com Turma -> O aluno deve ter 1 turma e uma turma pode ter N alunos
            HasRequired(x => x.Turma)
                .WithMany(x => x.Alunos)
                .Map(x => x.MapKey("TurmaId"));

            // 1:1 com Usuario -> 1 aluno deve ter exatamente 1 usuário
            HasRequired(x => x.Usuario)
                .WithRequiredPrincipal();
        }
    }
}
