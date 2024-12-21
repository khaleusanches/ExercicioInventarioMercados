using ExercicioInventarioMercados.Data;
using ExercicioInventarioMercados.Dto;
using ExercicioInventarioMercados.Models;
using Microsoft.EntityFrameworkCore;

namespace ExercicioInventarioMercados.Services
{
    public class FornecedorService : IFornecedorInterface
    {
        private readonly AppDbContext _context;
        public FornecedorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<RespostaModel<List<FornecedorModel>>> criarFornecedor(CriarFornecedorDto criar_fornecedor_dto)
        {
            RespostaModel<List<FornecedorModel>> resposta = new RespostaModel<List<FornecedorModel>>();
            try
            {
                FornecedorModel new_fornecedor = new FornecedorModel()
                {
                    Nome = criar_fornecedor_dto.Nome,
                    Cnpj = criar_fornecedor_dto.Cnpj
                };
                await _context.Fornecedores.AddAsync(new_fornecedor);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Fornecedores.ToListAsync();
                resposta.Mensagem = "Sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<RespostaModel<FornecedorModel>> buscarFornecedorById(int id)
        {
            RespostaModel<FornecedorModel> resposta = new RespostaModel<FornecedorModel>();
            try
            {
                var fornecedor = await _context.Fornecedores.FindAsync(id);
                if(fornecedor == null)
                {
                    resposta.Mensagem = "Não encontrado";
                    return resposta;
                }
                resposta.Dados = fornecedor;
                resposta.Mensagem = "Sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = $"{ex.Message}";
                return resposta;
            }
        }

        public async Task<RespostaModel<List<FornecedorModel>>> listarFornecedores()
        {
            RespostaModel<List<FornecedorModel>> resposta = new RespostaModel<List<FornecedorModel>>();
            try
            {
                var fornecedores = await _context.Fornecedores.ToListAsync();
                resposta.Dados = fornecedores;
                resposta.Mensagem = "Sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = "Error";
                return resposta;
            }
        }

        public async Task<RespostaModel<List<FornecedorModel>>> atualizarFornecedor(FornecedorEditarDto fornecedor_editar_dto)
        {
            RespostaModel<List<FornecedorModel>> resposta = new RespostaModel<List<FornecedorModel>>();
            try
            {
                var fornecedor = await _context.Fornecedores.FindAsync(fornecedor_editar_dto.Id);
                if (fornecedor == null)
                {
                    resposta.Mensagem = "Não encontrado";
                    return resposta;
                }
                fornecedor.Nome = fornecedor_editar_dto.Nome;
                fornecedor.Cnpj = fornecedor_editar_dto.Cnpj;
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Fornecedores.ToListAsync();
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }
      
        public Task<RespostaModel<List<FornecedorModel>>> deletarFornecedor()
        {
            throw new NotImplementedException();
        }
    }
}
