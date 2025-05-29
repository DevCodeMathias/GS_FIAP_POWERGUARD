using PowerGuard.Controller;

namespace PowerGuard.View
{
    public class LoginView
    {
        private readonly LoginController _controller;

        public LoginView(LoginController controller)
        {
            _controller = controller;
        }

        public bool SolicitarLogin()
        {
            int tentativas = 0;
            const int maxTentativas = 3;

            while (tentativas < maxTentativas)
            {
                try
                {
                    Console.WriteLine("\n--- Login ---");
                    Console.Write("Usuário: ");
                    string usuario = Console.ReadLine();
                    Console.Write("Senha: ");
                    string senha = Console.ReadLine();

                    bool sucesso = _controller.ValidarLogin(usuario, senha);

                    if (sucesso)
                    {
                        Console.WriteLine("Login realizado com sucesso!");
                        return true;
                    }
                    else
                    {
                        tentativas++;
                        Console.WriteLine($"Usuário ou senha inválidos. Tentativas restantes: {maxTentativas - tentativas}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocorreu um erro durante o login: {ex.Message}");
                    tentativas++;
                }
            }

            Console.WriteLine("Número máximo de tentativas excedido. Acesso bloqueado.");
            return false;
        }
    }
}
