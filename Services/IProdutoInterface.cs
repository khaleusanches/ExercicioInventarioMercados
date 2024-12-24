using ExercicioInventarioMercados.Dto;
using ExercicioInventarioMercados.Models;

namespace ExercicioInventarioMercados.Services
{
    public interface IProdutoInterface
    {
        Task<RespostaModel<ProdutoModel>> criarProduto(ProdutoCriarDto produto_criar_dto);
        Task<RespostaModel<List<ProdutoModel>>> listarProdutos();
    }
}
