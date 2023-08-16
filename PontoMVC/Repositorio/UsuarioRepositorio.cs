using Microsoft.EntityFrameworkCore;
using PontoMVC.Data;
using PontoMVC.Models;
using PontoMVC.Models.Enums;

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
            if (usuario != null) 
            { 
                usuario.DataCadastro = DateTime.Now;
                usuario.DataAtualização = DateTime.Now;
                usuario.Senha = "123456"; 

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
        public async Task<UsuarioModel> BuscarPorEmail(string email)
        {
            UsuarioModel usuario = await _bancoContext.Usuarios.FirstOrDefaultAsync(e => e.Email == email);
            return usuario;

        }

        public async Task<bool> AlterarSenha(UsuarioModel usuario)
        {
            /*gerar a nova senha*/
            usuario.Senha = "novaSenha";
            _bancoContext.Usuarios.Update(usuario);
            await _bancoContext.SaveChangesAsync();

            return true;
        }

        public async Task<UsuarioModel> BuscarPorLoginSenha(LoginModel logar)
        {
            var usuarioDB = await _bancoContext.Usuarios.FirstOrDefaultAsync(x => x.Login == logar.Login && x.Senha == logar.Senha);
            return usuarioDB;
        }
    }
}
