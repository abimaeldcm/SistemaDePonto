namespace PontoMVC.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public ICollection<PontoModel>? Ponto { get; set; }
    }
}
