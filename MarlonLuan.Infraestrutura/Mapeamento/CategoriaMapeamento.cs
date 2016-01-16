using MarlonLuan.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarlonLuan.Infraestrutura.Mapeamento
{
    public class CategoriaMapeamento : EntityTypeConfiguration<Categoria>
    {
        public CategoriaMapeamento()
        {
            ToTable("Categoria");

            HasKey(x => x.Id);

            Property(x => x.Titulo).HasMaxLength(60).IsRequired();
        }
    }
}
