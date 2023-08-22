using PontoMVC.Helper;

namespace PontoMVC.Repositorio
{
    public class UsuarioLoginRepositorio : IUsuarioLoginRepositorio
    {
        private readonly IEmailService _emailService;

        public UsuarioLoginRepositorio(IEmailService emailService)
        {
            _emailService = emailService;
        }
        public async Task<bool> CriarSenha(string email)
        {
            return await _emailService.SendEmailAsync(email, "Recuperação de Senha", "senhanova");
        }

        public Task<bool> Recuperar(string email)
        {
            throw new NotImplementedException();
        }
    }
}
