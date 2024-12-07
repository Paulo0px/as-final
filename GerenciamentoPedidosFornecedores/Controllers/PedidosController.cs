using Microsoft.AspNetCore.Mvc;
using GerenciamentoPedidosFornecedores.Models;
using GerenciamentoPedidosFornecedores.Repositories;

namespace GerenciamentoPedidosFornecedores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidosController(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        [HttpGet]   
        public IEnumerable<Pedido> Get()
        {
            return _pedidoRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Pedido> Get(int id)
        {
            var pedido = _pedidoRepository.GetById(id);
            if (pedido == null)
            {
                return NotFound();
            }
            return pedido;
        }

        [HttpPost]
        public ActionResult<Pedido> Post([FromBody] Pedido pedido)
        {
            _pedidoRepository.Add(pedido);
            return CreatedAtAction(nameof(Get), new { id = pedido.Id }, pedido);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Pedido pedido)
        {
            if (id != pedido.Id)
            {
                return BadRequest();
            }
            _pedidoRepository.Update(pedido);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _pedidoRepository.Delete(id);
            return NoContent();
        }
    }
}
