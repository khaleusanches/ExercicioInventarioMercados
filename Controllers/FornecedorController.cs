using ExercicioInventarioMercados.Dto;
using ExercicioInventarioMercados.Models;
using ExercicioInventarioMercados.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExercicioInventarioMercados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorInterface interface_fornecedor;
        public FornecedorController(IFornecedorInterface fornecedor)
        {
            interface_fornecedor = fornecedor;
        }
        [HttpPost]
        public async Task<ActionResult<RespostaModel<List<FornecedorModel>>>> criarFornecedor(CriarFornecedorDto criar_fornecedor_dto)
        {
            var fornecedores = await interface_fornecedor.criarFornecedor(criar_fornecedor_dto);
            return Ok(fornecedores);
        }
        [HttpGet("Listar")]
        public async Task<ActionResult<RespostaModel<List<FornecedorModel>>>> listarFornecedores()
        {
            var fornecedores = await interface_fornecedor.listarFornecedores();
            return Ok(fornecedores);
        }
        [HttpGet("BuscarPorID/{id_fornecedor}")]
        public async Task<ActionResult<RespostaModel<FornecedorModel>>> buscarFornecedorById(int id_fornecedor)
        {
            var fornecedor = await interface_fornecedor.buscarFornecedorById(id_fornecedor);
            return Ok(fornecedor);
        }
        [HttpPut("AtualizarFornecedorPorId")]
        public async Task<ActionResult<RespostaModel<List<FornecedorModel>>>> atualizarFornecedor(FornecedorEditarDto fornecedor_editar_dto)
        {
            var fornecedor = await interface_fornecedor.atualizarFornecedor(fornecedor_editar_dto);
            return Ok(fornecedor);
        }
    }
}
