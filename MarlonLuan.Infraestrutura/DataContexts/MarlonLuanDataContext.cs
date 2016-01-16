using MarlonLuan.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarlonLuan.Infraestrutura.DataContexts
{
    public class MarlonLuanDataContext : DbContext
    {
        public MarlonLuanDataContext()
            : base("MarlonLuanConnectionString")
        {
            Database.SetInitializer<MarlonLuanDataContext>(new MarlonLuanDataContextInitializer());
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        public class MarlonLuanDataContextInitializer : DropCreateDatabaseAlways<MarlonLuanDataContext>
        {
            protected override void Seed(MarlonLuanDataContext context)
            {
                context.Categorias.Add(new Categoria { Id = 1, Titulo = "Acao" });
                context.Categorias.Add(new Categoria { Id = 2, Titulo = "Comedia" });
                context.Categorias.Add(new Categoria { Id = 3, Titulo = "Terror" });
                context.SaveChanges();

                context.Filmes.Add(new Filme { Id = 1, CategoriaId = 1, Disponivel = true, Titulo = "Busca Implacavel 1", Preco = 99 });
                context.Filmes.Add(new Filme { Id = 2, CategoriaId = 1, Disponivel = true, Titulo = "Busca Implacavel 2", Preco = 199 });
                context.Filmes.Add(new Filme { Id = 3, CategoriaId = 1, Disponivel = true, Titulo = "Busca Implacavel 3", Preco = 59 });

                context.Filmes.Add(new Filme { Id = 4, CategoriaId = 2, Disponivel = true, Titulo = "Debi e Loide", Preco = 59 });
                context.Filmes.Add(new Filme { Id = 5, CategoriaId = 2, Disponivel = true, Titulo = "Se Beber, Nao Case", Preco = 79 });
                context.Filmes.Add(new Filme { Id = 6, CategoriaId = 2, Disponivel = true, Titulo = "Todo Mundo em Panico", Preco = 99 });

                context.Filmes.Add(new Filme { Id = 7, CategoriaId = 3, Disponivel = true, Titulo = "Annabelle", Preco = 9.89M });
                context.SaveChanges();

                base.Seed(context);
            }
        }
    }
}