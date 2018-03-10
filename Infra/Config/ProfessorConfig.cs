using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infra.Config
{
    public class ProfessorConfig : EntityTypeConfiguration<Professor>
    {
        public ProfessorConfig()
        {
            ToTable("Professor");
            HasKey(x => x.ProfessorId);
            Property(x => x.Nome).IsRequired();
        }
    }
}
