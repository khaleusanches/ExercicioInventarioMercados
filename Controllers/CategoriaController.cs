using ExercicioInventarioMercados.Dto;
using ExercicioInventarioMercados.Models;
using ExercicioInventarioMercados.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExercicioInventarioMercados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaInterface _interface_categoria;
        public CategoriaController(ICategoriaInterface interface_categoria)
        {
            _interface_categoria = interface_categoria;
        }

        [HttpGet("Listar")]
        public async Task<ActionResult<RespostaModel<List<CategoriaModel>>>> listarCategorias()
        {
            var categorias = await _interface_categoria.listarCategorias();
            return Ok(categorias);
        }

        [HttpGet("BuscarCategoriaPorId/{id}")]
        public async Task<ActionResult<RespostaModel<CategoriaModel>>> buscarCategoriaPorId(int id)
        {
            var categoria = await _interface_categoria.buscarCategoriaPorId(id);
            return categoria;
        }

        [HttpPost("Criar")]
        public async Task<ActionResult<RespostaModel<CategoriaModel>>> criarCategoria(CriarCategoriaDto criar_categoria_dto)
        {
            var categoria = await _interface_categoria.criarCategoria(criar_categoria_dto);
            return Ok(categoria);
        }

        [HttpPut("AtualizarPorId")]
        public async Task<ActionResult<RespostaModel<List<CategoriaModel>>>> atualizarCategoria(CategoriaModel atualizacao_categoria)
        {
            var categorias = await _interface_categoria.atualizarCategoria(atualizacao_categoria);
            return Ok(categorias);
        }

        [HttpGet("DeletarPorId/{id}")]
        public async Task<ActionResult<RespostaModel<List<CategoriaModel>>>> deletarCategoria(int id)
        {
            var categoria = await _interface_categoria.deletarCategoria(id);
            return categoria;
        }
    }
}
