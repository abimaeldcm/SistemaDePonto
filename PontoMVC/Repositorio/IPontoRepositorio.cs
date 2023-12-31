﻿using PontoMVC.Data;
using PontoMVC.Models;

namespace PontoMVC.Repositorio
{
    public interface IPontoRepositorio
    {
        PontoModel BaterPonto(PontoModel bater);
        UsuarioModel Usuario();
        IEnumerable<PontoModel> Marcacoes();
    }
}
