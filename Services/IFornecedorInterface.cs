using ExercicioInventarioMercados.Dto;
using ExercicioInventarioMercados.Models;

namespace ExercicioInventarioMercados.Services
{
    public interface IFornecedorInterface
    {
        Task<RespostaModel<List<FornecedorModel>>> criarFornecedor(CriarFornecedorDto criar_fornecedor_dto);
        Task<RespostaModel<List<FornecedorModel>>> listarFornecedores();
        Task<RespostaModel<FornecedorModel>> buscarFornecedorById(int id);
        Task<RespostaModel<List<FornecedorModel>>> atualizarFornecedor(FornecedorEditarDto fornecedor_editar_dto);
        Task<RespostaModel<List<FornecedorModel>>> deletarFornecedor();
    }
}
