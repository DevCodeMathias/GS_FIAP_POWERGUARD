namespace PowerGuard.Service
{
    public class LoginService
    {
        private readonly string usuario = "admin";
        private readonly string senha = "123";

        public bool ValidarLogin(string user, string pass)
        {
            return user == usuario && pass == senha;
        }
    }
}
