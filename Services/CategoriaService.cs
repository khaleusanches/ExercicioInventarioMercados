using ExercicioInventarioMercados.Data;
using ExercicioInventarioMercados.Dto;
using ExercicioInventarioMercados.Models;
using Microsoft.EntityFrameworkCore;

namespace ExercicioInventarioMercados.Services
{
    public class CategoriaService : ICategoriaInterface
    {

        private readonly AppDbContext _context;

        public CategoriaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<RespostaModel<List<CategoriaModel>>> listarCategorias()
        {
            RespostaModel<List<CategoriaModel>> resposta = new RespostaModel<List<CategoriaModel>>();
            try
            {
                var categorias = await _context.Categorias.ToListAsync();
                resposta.Dados = categorias;
                resposta.Mensagem = "Sucesso";
                resposta.Status = false;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<RespostaModel<CategoriaModel>> buscarCategoriaPorId(int id)
        {
            RespostaModel<CategoriaModel> resposta = new RespostaModel<CategoriaModel>();
            try
            {
                var categoria = await _context.Categorias.FindAsync(id);
                if (categoria == null)
                {
                    resposta.Mensagem = "Categoria não encontrada";
                    return resposta;
                }
                resposta.Dados = categoria;
                resposta.Mensagem = "Sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<RespostaModel<CategoriaModel>> criarCategoria(CriarCategoriaDto new_categoria_dto)
        {
            RespostaModel<CategoriaModel> resposta = new RespostaModel<CategoriaModel>();
            try
            {
                var new_categoria = new CategoriaModel() { Nome = new_categoria_dto.Nome };
                await _context.Categorias.AddAsync(new_categoria);
                await _context.SaveChangesAsync();
                resposta.Dados = new_categoria;
                resposta.Mensagem = "Sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<RespostaModel<CategoriaModel>> atualizarCategoria(CategoriaModel atualizacao_categoria)
        {
            RespostaModel<CategoriaModel> resposta = new RespostaModel<CategoriaModel>();
            try
            {
                var categoria = await _context.Categorias.FindAsync(atualizacao_categoria.Id);
                if (categoria == null)
                {
                    resposta.Mensagem = "Categoria não encontrada";
                    return resposta;
                }
                categoria.Nome = atualizacao_categoria.Nome;
                await _context.SaveChangesAsync();
                resposta.Dados = categoria;
                resposta.Mensagem = "Sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<RespostaModel<List<CategoriaModel>>> deletarCategoria(int id)
        {
            RespostaModel<List<CategoriaModel>> resposta = new RespostaModel<List<CategoriaModel>>();
            try
            {
                var categoria = await _context.Categorias.FindAsync(id);
                if (categoria == null)
                {
                    resposta.Mensagem = "Categoria não encontrada";
                    return resposta;
                }
                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();
                var categorias = await _context.Categorias.ToListAsync();
                resposta.Dados = categorias;
                resposta.Mensagem = "Sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
