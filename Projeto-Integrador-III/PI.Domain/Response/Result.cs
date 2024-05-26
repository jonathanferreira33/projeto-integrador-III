namespace PI.Domain.Response
{
    public class Result<T> where T : class
    {
        public Result<T> Resultado { get; set; }
        public string Mensagen { get; set; }
        public bool Sucesso { get; set; }
    }
}
