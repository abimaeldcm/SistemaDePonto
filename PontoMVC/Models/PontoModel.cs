using PontoMVC.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace PontoMVC.Models
{
    public class PontoModel
    {
        public int Id { get; set; }
        public DateTime Data { get; } = DateTime.Now;
        public TimeSpan Hora { get; set; } = DateTime.Now.TimeOfDay;
        [Display(Name = "Tipo de Marcação")]
        [Required(ErrorMessage = "Selecione uma opção")]
        public ETipo TipoBatida { get; set; }
        public UsuarioModel? Usuario { get; set; }
    }
}
