using Microsoft.EntityFrameworkCore;
using GerenciamentoPedidosFornecedores.Models;

namespace GerenciamentoPedidosFornecedores.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
    }
}
