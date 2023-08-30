using Microsoft.EntityFrameworkCore;
using PontoMVC.Data;
using PontoMVC.Models;
using PontoMVC.Models.Enums;
using BCrypt.Net;

namespace PontoMVC.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _bancoContext;

        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public async Task<bool> Criar(UsuarioModel usuario)
        {
            //não pode ter o mesmo login no banco
            if (usuario != null) 
            { 
                usuario.DataCadastro = DateTime.Now;
                usuario.DataAtualização = DateTime.Now;
                usuario.Senha = BCrypt.Net.BCrypt.HashPassword("123456");

                await _bancoContext.Usuarios.AddAsync(usuario);
                await _bancoContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public UsuarioModel UsuarioPorId(int id)
        {
            var a =  _bancoContext.Usuarios.FirstOrDefault(u => u.Id == id);
            return a;
        }
        public async Task<List<UsuarioModel>> TodosUsuarios()
        {
            return await _bancoContext.Usuarios.ToListAsync();
        }
        public async Task<UsuarioModel> AlterarUsario(UsuarioModel usuario)
        {
            UsuarioModel usDB =  UsuarioPorId(usuario.Id);

            usDB.DataAtualização = DateTime.Now;
            usDB.Nome = usuario.Nome;
            usDB.Email = usuario.Email;
            usDB.Login = usuario.Login;
            usDB.Perfil = usuario.Perfil;

            _bancoContext.Usuarios.Update(usDB);
            await _bancoContext.SaveChangesAsync();
            return usuario;
        }
        public async Task<bool> Apagar(int id)
        {
            var usuario = UsuarioPorId(id);
            var Pontos = _bancoContext.Pontos.Where(p => p.Usuario.Id == id);
            if (Pontos.Any()) 
            { 
                _bancoContext.Pontos.RemoveRange(Pontos);
            }
            
            _bancoContext.Remove(usuario);
             await _bancoContext.SaveChangesAsync();
            return true;
        }
        public  UsuarioModel BuscarPorEmail(string email)
        {
             return _bancoContext.Usuarios.FirstOrDefault(e => e.Email == email);
        }

        public async Task<bool> AlterarSenha(UsuarioModel usuario)
        {
            /*gerar a nova senha*/
            _bancoContext.Usuarios.Update(usuario);
            await _bancoContext.SaveChangesAsync();

            return true;
        }
        public List<PontoModel> MarcacoesId(int id)
        {
            var MarcaçõesDB = _bancoContext.Pontos.Where(x => x.Usuario.Id == id).ToList();

            return MarcaçõesDB;
        }

        public  UsuarioModel BuscarPorLoginSenha(LoginModel logar)
        {
            var usuarioDB =  _bancoContext.Usuarios.FirstOrDefault(x => x.Login == logar.Login);

            var igual = BCrypt.Net.BCrypt.Verify(logar.Senha, usuarioDB.Senha);

            if (igual)
            {
                return usuarioDB;
            }

            // Usuário não encontrado ou senha incorreta.
            return null;
        }
    }
}
