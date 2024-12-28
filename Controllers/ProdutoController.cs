using ExercicioInventarioMercados.Dto;
using ExercicioInventarioMercados.Models;
using ExercicioInventarioMercados.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExercicioInventarioMercados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoInterface _interface_produto;

        public ProdutoController(IProdutoInterface interface_produto)
        {
            _interface_produto = interface_produto;
        }
        [HttpGet("Listar")]
        public async Task<ActionResult<RespostaModel<List<ProdutoModel>>>> listarProdutos()
        {
            var produtos = await _interface_produto.listarProdutos();
            return Ok(produtos);
        }
        [HttpPost("Criar")]
        public async Task<ActionResult<RespostaModel<ProdutoModel>>> criarProduto(ProdutoCriarDto produto_criar_dto)
        {
            var new_produto = await _interface_produto.criarProduto(produto_criar_dto);
            return new_produto;
        }
        [HttpGet("BuscarPorId/{id}")]
        public async Task<ActionResult<RespostaModel<ProdutoModel>>> buscarProdutoPorID(int id)
        {
            var produto = await _interface_produto.buscarProdutoPorId(id);
            return Ok(produto);
        }
        [HttpPut("AtualizarProduto/{id}")]
        public async Task<ActionResult<RespostaModel<ProdutoModel>>> atualizarProduto(ProdutoAtualizarDto produto_atualizar_dto)
        {
            var produto = await _interface_produto.atualizarProduto(produto_atualizar_dto);
            return Ok(produto);
        }
        [HttpPut("AtualizarPreco")]
        public async Task<ActionResult<RespostaModel<ProdutoModel>>> atualizarPrecoProduto(ProdutoPrecoAtualizarDto produto_atualizar_dto)
        {
            var produto = await _interface_produto.atualizarPrecoProduto(produto_atualizar_dto);
            return Ok(produto);
        }
        [HttpPut("AtualizarQuantidade")]
        public async Task<ActionResult<RespostaModel<ProdutoModel>>> atualizarQuantiadeProduto(ProdutoQuantidadeAtualizarDto produto_atualizar_dto)
        {
            var produto = await _interface_produto.atualizarQuantidadeProduto(produto_atualizar_dto);
            return Ok(produto);
        }
        [HttpDelete("DeletarProdutoPorId/{id}")]
        public async Task<ActionResult<RespostaModel<List<ProdutoModel>>>> deletarProduto(int id)
        {
            var produto = await _interface_produto.deletarProduto(id);
            return Ok(produto);
        }
    }
}
