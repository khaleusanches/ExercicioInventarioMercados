namespace ExercicioInventarioMercados.Models
{
    public class RespostaModel<T>
    {
        public T? Dados { get; set; }
        public bool Status { get; set; } = true;
        public string Mensagem { get; set; }
    }
}
