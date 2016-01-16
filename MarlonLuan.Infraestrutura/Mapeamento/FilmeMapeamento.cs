using MarlonLuan.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarlonLuan.Infraestrutura.Mapeamento
{
    public class FilmeMapeamento : EntityTypeConfiguration<Filme>
    {
        public FilmeMapeamento()
        {
            ToTable("Filme");

            HasKey(x => x.Id);

            Property(x => x.Titulo).HasMaxLength(160).IsRequired();
            Property(x => x.Preco).IsRequired();
            Property(x => x.DataAquisicao).IsRequired();

            HasRequired(x => x.Categoria);
        }
    }
}
