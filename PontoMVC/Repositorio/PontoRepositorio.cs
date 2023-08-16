using Microsoft.EntityFrameworkCore;
using PontoMVC.Data;
using PontoMVC.Helper;
using PontoMVC.Models;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace PontoMVC.Repositorio
{
    public class PontoRepositorio : IPontoRepositorio
    {
        private readonly BancoContext _bancoContext;
        private readonly ISessao _sessao;

        public PontoRepositorio(BancoContext bancoContext, ISessao sessao)
        {
            _bancoContext = bancoContext;
            _sessao = sessao;
        }

        public PontoModel BaterPonto(PontoModel bater)
        {
            _bancoContext.Pontos.Add(bater);
            _bancoContext.SaveChanges();

            return bater;
        }
        public UsuarioModel Usuario()
        {
            UsuarioModel usuario = _sessao.BuscarSessaoDoUsuario();
            return _bancoContext.Usuarios.FirstOrDefault(x => x == usuario);
        }

        public IEnumerable<PontoModel> Marcacoes()
        {            
            UsuarioModel usuario = _sessao.BuscarSessaoDoUsuario();
            return _bancoContext.Pontos.Where(x => x.Usuario.Id == usuario.Id );
        }
    }
}
