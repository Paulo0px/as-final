using System.Collections.Generic;
using GerenciamentoPedidosFornecedores.Models;

namespace GerenciamentoPedidosFornecedores.Repositories
{
    public interface IFornecedorRepository
    {
        IEnumerable<Fornecedor> GetAll();
        Fornecedor GetById(int id);
        void Add(Fornecedor fornecedor);
        void Update(Fornecedor fornecedor);
        void Delete(int id);
    }
}
