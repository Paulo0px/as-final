using Microsoft.AspNetCore.Mvc;
using GerenciamentoPedidosFornecedores.Models;
using GerenciamentoPedidosFornecedores.Repositories;

namespace GerenciamentoPedidosFornecedores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedoresController : ControllerBase
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedoresController(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        [HttpGet]
        public IEnumerable<Fornecedor> Get()
        {
            return _fornecedorRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Fornecedor> Get(int id)
        {
            var fornecedor = _fornecedorRepository.GetById(id);
            if (fornecedor == null)
            {
                return NotFound();
            }
            return fornecedor;
        }

        [HttpPost]
        public ActionResult<Fornecedor> Post([FromBody] Fornecedor fornecedor)
        {
            _fornecedorRepository.Add(fornecedor);
            return CreatedAtAction(nameof(Get), new { id = fornecedor.Id }, fornecedor);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Fornecedor fornecedor)
        {
            if (id != fornecedor.Id)
            {
                return BadRequest();
            }
            _fornecedorRepository.Update(fornecedor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _fornecedorRepository.Delete(id);
            return NoContent();
        }
    }
}
