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
    }
}
