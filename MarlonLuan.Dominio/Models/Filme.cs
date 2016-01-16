using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarlonLuan.Dominio.Models
{
    public class Filme
    {
        public Filme()
        {
            this.DataAquisicao = DateTime.Now;
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataAquisicao { get; set; }
        public bool Disponivel { get; set; }
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}