using ExercicioInventarioMercados.Models;

namespace ExercicioInventarioMercados.Dto
{
    public class ProdutoCriarDto
    {
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public double Preco { get; set; }
        public int Id_fornecedor { get; set; }
        public int Id_categoria { get; set; }
    }
}
