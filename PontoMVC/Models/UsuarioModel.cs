using PontoMVC.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PontoMVC.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public EPerfil Perfil { get; set; }
        [Display(Name = "E-mail")]

        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualização { get; set; }
    }
}
