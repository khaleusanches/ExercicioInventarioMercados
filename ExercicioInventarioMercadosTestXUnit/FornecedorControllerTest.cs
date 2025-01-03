using ExercicioInventarioMercados.Controllers;
using ExercicioInventarioMercados.Models;
using ExercicioInventarioMercados.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioInventarioMercadosTestXUnit
{
    public class FornecedorControllerTest
    {
        private readonly Mock<IFornecedorInterface> _fornecedorInterface;
        private readonly FornecedorController _controller;

        public FornecedorControllerTest()
        {
            _fornecedorInterface = new Mock<IFornecedorInterface>();
            _controller = new FornecedorController(_fornecedorInterface.Object);
        }

        [Fact]
        public async void listarFornecedores_Ok()
        {
            //Arrange
            var fornecedores = new List<FornecedorModel>() {
                new FornecedorModel() {
                    Id = 1, Nome = "Italac", Cnpj = "11212"
                } 
            };
            var respostaEsperada = new RespostaModel<List<FornecedorModel>>() { Dados = fornecedores, Mensagem = "Sucesso", Status = true }; 
            _fornecedorInterface.Setup(service => service.listarFornecedores()).ReturnsAsync(respostaEsperada); //Define que o listarFornecedores() vai retornar a respostaEsperada
            
            //Act
            var resposta = await _controller.listarFornecedores();

            //Assert
            var resposta_result = Assert.IsType<OkObjectResult>(resposta.Result); //Ve o resultado do controller
            var actual_result = Assert.IsType<RespostaModel<List<FornecedorModel>>>(resposta_result.Value); //Puxa os dados do resultado e ve o tipo
            Assert.Equal(respostaEsperada, actual_result);
            Assert.Equal(respostaEsperada.Status, actual_result.Status);
        }
        [Fact]
        public async void listarFornecedores_Status()
        {
            //Arrange
            var fornecedores = new List<FornecedorModel>() { new FornecedorModel() { Id = 1, Cnpj = "1212", Nome = "Italac" } };
            var respostaEsperada = new RespostaModel<List<FornecedorModel>>() {  Dados = fornecedores, Mensagem = "Error", Status = false };
            _fornecedorInterface.Setup(service => service.listarFornecedores()).ReturnsAsync(respostaEsperada);
            //Act
            var resposta = await _controller.listarFornecedores();

            //Assert
            var resposta_result = Assert.IsType<BadRequestObjectResult>(resposta.Result);
            var actual_resposta = Assert.IsType<RespostaModel<List<FornecedorModel>>>(resposta_result.Value);
            Assert.Equal(respostaEsperada, actual_resposta);
        }
    }
}
