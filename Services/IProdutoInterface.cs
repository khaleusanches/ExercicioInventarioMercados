using ExercicioInventarioMercados.Dto;
using ExercicioInventarioMercados.Models;

namespace ExercicioInventarioMercados.Services
{
    public interface IProdutoInterface
    {
        Task<RespostaModel<ProdutoModel>> criarProduto(ProdutoCriarDto produto_criar_dto);
        Task<RespostaModel<List<ProdutoModel>>> listarProdutos();
        Task<RespostaModel<ProdutoModel>> buscarProdutoPorId(int id);
        Task<RespostaModel<ProdutoModel>> atualizarProduto(ProdutoAtualizarDto produto_atualizar_dto);
        Task<RespostaModel<ProdutoModel>> atualizarPrecoProduto(ProdutoPrecoAtualizarDto produto_preco_atualizar_dto);
        Task<RespostaModel<ProdutoModel>> atualizarQuantidadeProduto(ProdutoQuantidadeAtualizarDto produto_quantidade_atualizar_dto);
        Task<RespostaModel<List<ProdutoModel>>> deletarProduto(int id);
    }
}
