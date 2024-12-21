using ExercicioInventarioMercados.Models;
using Microsoft.EntityFrameworkCore;

namespace ExercicioInventarioMercados.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        
        }
        public DbSet<FornecedorModel> Fornecedores { get; set; }
        public DbSet<CategoriaModel> Categorias { get; set; }
        public DbSet<ProdutoModel> Produtos { get; set; }
    }
}
