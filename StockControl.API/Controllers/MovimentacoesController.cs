using Microsoft.AspNetCore.Mvc;
using StockControl.API.Data;
using StockControl.API.Models;
using System.Threading.Tasks;

namespace StockControl.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovimentacoesController : ControllerBase
    {
        private readonly StockControlContext _context;

        public MovimentacoesController(StockControlContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> RegistrarMovimentacao(Movimentacao movimentacao)
        {
            _context.Movimentacoes.Add(movimentacao);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}