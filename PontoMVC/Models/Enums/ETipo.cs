using System.ComponentModel.DataAnnotations;

namespace PontoMVC.Models.Enums
{
    public enum ETipo : int
    {
        Entrada = 1,
        [Display(Name = "Almoço Ida")] 
        AlmocoIda = 2,
        [Display(Name = "Almoço Volta")]
        AlmocoVolta = 3,
        Saida = 4,
    }
}
