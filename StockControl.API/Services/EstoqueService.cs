using Microsoft.EntityFrameworkCore;
using StockControl.API.Data;
using StockControl.API.Models;
using System;
using System.Threading.Tasks;

namespace StockControl.API.Services
{
    public class EstoqueService
    {
        private readonly StockControlContext _context;

        public EstoqueService(StockControlContext context)
        {
            _context = context;
        }

        public async Task<bool> AtualizarEstoque(int produtoId, int quantidade, string tipo)
        {
            var estoque = await _context.Estoques.FirstOrDefaultAsync(e => e.ProdutoId == produtoId);

            if (estoque == null) return false;

            if (tipo == "Entrada")
            {
                estoque.QuantidadeAtual += quantidade;
            }
            else if (tipo == "Saída")
            {
                estoque.QuantidadeAtual -= quantidade;
            }

            estoque.UltimaAtualizacao = DateTime.Now;

            var movimentacao = new Movimentacao
            {
                ProdutoId = produtoId,
                Tipo = tipo,
                Quantidade = quantidade,
                Data = DateTime.Now
            };

            _context.Movimentacoes.Add(movimentacao);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}