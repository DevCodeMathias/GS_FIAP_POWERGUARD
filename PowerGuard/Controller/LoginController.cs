using PowerGuard.Service;

namespace PowerGuard.Controller
{
    public class LoginController
    {
        private readonly LoginService _service = new LoginService();

        public bool ValidarLogin(string usuario, string senha)
        {
            return _service.ValidarLogin(usuario, senha);
        }
    }
}
