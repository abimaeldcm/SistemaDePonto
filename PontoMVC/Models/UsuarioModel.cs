using PontoMVC.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PontoMVC.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Selecione um perfil")]
        public EPerfil Perfil { get; set; }

        [Required(ErrorMessage = "Digite um e-mail")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualização { get; set; }
    }
}
