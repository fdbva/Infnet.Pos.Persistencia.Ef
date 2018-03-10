using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infra.Config
{
    public class CursoConfig : EntityTypeConfiguration<Curso>
    {
        public CursoConfig()
        {
            /* Nome padrão da tabela:
             *  - Com pluralização: Cursoes
             *  - Sem pluralização: Curso */
            ToTable("Curso");

            //Se quisermos sobrescrever o padrão de chave primária que já definimos na DataContext:
            HasKey(x => x.CursoId);
            //Em vez de 100, queremos Descricao (propriedade string) com 150 caracteres
            //E que seja NOT NULL
            Property(x => x.Descricao).HasMaxLength(150).IsRequired();

            //Mapeamento do relacionamento M:N entre curso e professor
            HasMany(x => x.Professores) //Um curso tem muitos professores
                .WithMany(x => x.Cursos) //E cada professor tem muitos cursos
                .Map(x =>
                {
                    //Chave esqueda: Curso
                    x.MapLeftKey("CursoId");
                    //Chave direita: Professor
                    x.MapRightKey("ProfessorId");
                    //Nome da tabela de relacionamento
                    x.ToTable("CursoProfessor");
                });
        }
    }
}
