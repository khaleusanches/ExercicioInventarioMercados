using ExercicioInventarioMercados.Controllers;
using ExercicioInventarioMercados.Models;
using ExercicioInventarioMercados.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Moq;
using Xunit.Abstractions;

namespace ExercicioInventarioMercadosTestXUnit
{
    public class CategoriaControllerTest
    {
        private readonly CategoriaController _controller;
        private readonly Mock<ICategoriaInterface> _categoriaMock;
        private readonly ITestOutputHelper _output;
        public CategoriaControllerTest(ITestOutputHelper output)
        {
            _categoriaMock = new Mock<ICategoriaInterface>();
            _controller = new CategoriaController(_categoriaMock.Object);
            _output = output;
        }

        [Fact(DisplayName = "Resultado Ok")]
        public async void listarProdutosTest_OK()
        {
            //Arrange
            var categorias = new List<CategoriaModel> { new CategoriaModel() { Id = 2, Nome = "Carnes" } };
            var resultExpected = new RespostaModel<List<CategoriaModel>> { Dados = categorias, Mensagem = "Sucesso", Status = true };
            _categoriaMock.Setup(service => service.listarCategorias()).ReturnsAsync(resultExpected);

            //Act
            var result = await _controller.listarCategorias();

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var actualValue = Assert.IsType<RespostaModel<List<CategoriaModel>>>(okResult.Value);
            Assert.Equal(resultExpected.Status, actualValue.Status);
            Assert.Equal(resultExpected.Mensagem, actualValue.Mensagem);
            Assert.Equal(Newtonsoft.Json.JsonConvert.SerializeObject(resultExpected.Dados),
                         Newtonsoft.Json.JsonConvert.SerializeObject(actualValue.Dados));
            _categoriaMock.Verify(service => service.listarCategorias(), Times.Once());
        }
        [Fact(DisplayName = "Status = false")]
        public async void listarProdutosTest_StatusFalse()
        {
            //Arrange
            var categorias = new List<CategoriaModel> { new CategoriaModel() { Id = 2, Nome = "Carnes" } };
            var resultExpected = new RespostaModel<List<CategoriaModel>> { Dados = categorias, Mensagem = "Error", Status = false };
            _categoriaMock.Setup(service => service.listarCategorias()).ReturnsAsync(resultExpected);

            //Act
            var result = await _controller.listarCategorias();

            //Assert
            var okResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var actualValue = Assert.IsType<RespostaModel<List<CategoriaModel>>>(okResult.Value);
            Assert.Equal(resultExpected.Status, actualValue.Status);
            Assert.Equal(resultExpected.Mensagem, actualValue.Mensagem);
            Assert.Equal(Newtonsoft.Json.JsonConvert.SerializeObject(resultExpected.Dados),
                         Newtonsoft.Json.JsonConvert.SerializeObject(actualValue.Dados));
            _categoriaMock.Verify(service => service.listarCategorias(), Times.Once());
        }
    }
}