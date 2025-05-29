using PowerGuard.Controller;
using PowerGuard.Service;
using PowerGuard.View;

class Program
{
    static void Main()
    {
        // Inicialização dos Services
        var loginService = new LoginService();
        var falhaService = new FalhaService();

    
        var loginController = new LoginController();
        var falhaController = new FalhaController();


        var loginView = new LoginView(loginController);
        var menuView = new MenuView(falhaController);

  
        bool loginSucesso = loginView.SolicitarLogin();

        if (loginSucesso)
        {
            menuView.MostrarMenu();
        }
        else
        {
            Console.WriteLine("Falha no login. Sistema encerrado.");
        }

        Console.WriteLine("Sistema encerrado.");
    }
}
