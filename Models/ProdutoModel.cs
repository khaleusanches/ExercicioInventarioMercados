﻿namespace ExercicioInventarioMercados.Models
{
    public class ProdutoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public double Preco { get; set; }
        public FornecedorModel Fornecedor { get; set; }
    }
}
