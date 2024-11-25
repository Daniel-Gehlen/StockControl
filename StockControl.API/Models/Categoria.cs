using System.Collections.Generic;

namespace StockControl.API.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public List<Produto> Produtos { get; set; } = new();
    }
}