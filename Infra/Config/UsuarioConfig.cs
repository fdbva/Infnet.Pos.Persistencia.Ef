using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infra.Config
{
    public class UsuarioConfig : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfig()
        {
            ToTable("Usuario");
            HasKey(x => x.UsuarioId);

            Property(x => x.Email).IsRequired();
            Property(x => x.Senha).IsRequired().HasMaxLength(20);
        }
    }
}
