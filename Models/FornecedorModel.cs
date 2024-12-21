using System.Text.Json.Serialization;

namespace ExercicioInventarioMercados.Models
{
    public class FornecedorModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        [JsonIgnore]
        public ICollection<ProdutoModel> Produtos { get; set; }
    }
}
