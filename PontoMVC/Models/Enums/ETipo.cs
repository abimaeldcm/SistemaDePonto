using System;
using System.ComponentModel.DataAnnotations;

namespace PontoMVC.Models.Enums
{
    public enum ETipo : int
    {
        Entrada = 1,
        [Display(Name = "Pausa")]
        Pausa = 2,
        [Display(Name = "Retorno")]
        Retorno = 3,
        Saida = 4,
    }
}
