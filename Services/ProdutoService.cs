﻿using ExercicioInventarioMercados.Data;
using ExercicioInventarioMercados.Dto;
using ExercicioInventarioMercados.Models;
using Microsoft.EntityFrameworkCore;

namespace ExercicioInventarioMercados.Services
{
    public class ProdutoService : IProdutoInterface
    {
        private readonly AppDbContext _context;
        public ProdutoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<RespostaModel<ProdutoModel>> atualizarPrecoProduto(ProdutoPrecoAtualizarDto produto_preco_atualizar_dto)
        {
            RespostaModel<ProdutoModel> resposta = new RespostaModel<ProdutoModel>();
            try
            {
                var produto = await _context.Produtos.FindAsync(produto_preco_atualizar_dto.Id);
                if(produto == null)
                {
                    resposta.Mensagem = "Produto não encontrado";
                    return resposta;
                }
                produto.Preco = produto_preco_atualizar_dto.Preco;
                await _context.SaveChangesAsync();
                resposta.Dados = produto;
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

        public async Task<RespostaModel<ProdutoModel>> atualizarProduto(ProdutoAtualizarDto produto_atualizar_dto)
        {
            RespostaModel<ProdutoModel> resposta = new RespostaModel<ProdutoModel>();
            try
            {
                var produto = await _context.Produtos.FindAsync(produto_atualizar_dto.Id);
                if(produto == null)
                {
                    resposta.Mensagem = "Produto não encontrado";
                    return resposta;
                }
                produto.Nome = produto_atualizar_dto.Nome;
                produto.Quantidade = produto_atualizar_dto.Quantidade;
                produto.Preco = produto_atualizar_dto.Preco;
                produto.Categoria = await _context.Categorias.FindAsync(produto_atualizar_dto.Id_categoria);
                produto.Fornecedor = await _context.Fornecedores.FindAsync(produto_atualizar_dto.Id_fornecedor);
                await _context.SaveChangesAsync();
                resposta.Dados = produto;
                resposta.Mensagem = "Sucesso";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = "Error";
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<RespostaModel<ProdutoModel>> atualizarQuantidadeProduto(ProdutoQuantidadeAtualizarDto produto_quantidade_atualizar_dto)
        {
            RespostaModel<ProdutoModel> resposta = new RespostaModel<ProdutoModel>();
            try
            {
                var produto = await _context.Produtos.FindAsync(produto_quantidade_atualizar_dto.Id);
                if (produto == null)
                {
                    resposta.Mensagem = "Produto não encontrado";
                    return resposta;
                }
                produto.Preco = produto_quantidade_atualizar_dto.Quantidade;
                await _context.SaveChangesAsync();
                resposta.Dados = produto;
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

        public async Task<RespostaModel<ProdutoModel>> buscarProdutoPorId(int id)
        {
            RespostaModel<ProdutoModel> resposta = new RespostaModel<ProdutoModel>();
            try 
            {
                var produto = await _context.Produtos.FindAsync(id);
                if(produto == null)
                {
                    resposta.Mensagem = "Produto não encontrado";
                    return resposta;
                }
                resposta.Dados = produto;
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

        public async Task<RespostaModel<ProdutoModel>> criarProduto(ProdutoCriarDto produto_criar_dto)
        {
            RespostaModel<ProdutoModel> resposta = new RespostaModel<ProdutoModel>();
            try
            {
                var fornecedor = await _context.Fornecedores.FindAsync(produto_criar_dto.Id_fornecedor);
                var categoria = await _context.Categorias.FindAsync(produto_criar_dto.Id_categoria);
                if (fornecedor == null || categoria == null) 
                {
                    resposta.Mensagem = "Categoria ou fornecedor não encontrados.";
                    return resposta;
                }
                ProdutoModel new_produto = new ProdutoModel()
                {
                    Nome = produto_criar_dto.Nome,
                    Quantidade = produto_criar_dto.Quantidade,
                    Preco = produto_criar_dto.Preco,
                    Fornecedor = fornecedor,
                    Categoria = categoria
                };
                await _context.Produtos.AddAsync(new_produto);
                await _context.SaveChangesAsync();
                resposta.Dados = new_produto;
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

        public async Task<RespostaModel<List<ProdutoModel>>> deletarProduto(int id)
        {
            RespostaModel<List<ProdutoModel>> resposta = new RespostaModel<List<ProdutoModel>>();
            try
            {
                var produto = await _context.Produtos.FindAsync(id);
                if(produto == null)
                {
                    resposta.Mensagem = "Produto não encontrado";
                }
                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();
                var produtos = await _context.Produtos.ToListAsync();
                resposta.Dados = produtos;
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

        public async Task<RespostaModel<List<ProdutoModel>>> listarProdutos()
        {
            RespostaModel<List<ProdutoModel>> resposta = new RespostaModel<List<ProdutoModel>>();
            try
            {
                var produtos = await _context.Produtos.Include(produto => produto.Fornecedor).Include(produto => produto.Categoria).ToListAsync();
                resposta.Dados = produtos;
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
