using Microsoft.EntityFrameworkCore;
using PontoMVC.Data;
using PontoMVC.Models;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace PontoMVC.Repositorio
{
    public class PontoRepositorio : IPontoRepositorio
    {
        private readonly BancoContext _bancoContext;

        public PontoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public PontoModel BaterPonto(PontoModel bater)
        {
            _bancoContext.Pontos.Add(bater);
            _bancoContext.SaveChanges();

            return bater;
        }
        public UsuarioModel Usuario()
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Id == 1);
        }

        public IQueryable<PontoModel> Marcacoes()
        {            
            return _bancoContext.Pontos;
        }
    }
}
