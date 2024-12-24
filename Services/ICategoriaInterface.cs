using ExercicioInventarioMercados.Dto;
using ExercicioInventarioMercados.Models;

namespace ExercicioInventarioMercados.Services
{
    public interface ICategoriaInterface 
    {
        Task<RespostaModel<List<CategoriaModel>>> listarCategorias();
        Task<RespostaModel<CategoriaModel>> buscarCategoriaPorId(int id);
        Task<RespostaModel<CategoriaModel>> criarCategoria(CriarCategoriaDto categoria);
        Task<RespostaModel<CategoriaModel>> atualizarCategoria(CategoriaModel categoria);
        Task<RespostaModel<List<CategoriaModel>>> deletarCategoria(int id);
    }
}
