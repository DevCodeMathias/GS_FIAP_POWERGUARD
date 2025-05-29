using PowerGuard.Controller;
using PowerGuard.Model;

namespace PowerGuard.View
{
    public class MenuView
    {
        private readonly FalhaController _controller;

        public MenuView(FalhaController controller)
        {
            _controller = controller;
        }

        public void MostrarMenu()
        {
            bool sair = false;
            while (!sair)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1 - Registrar falha de energia");
                Console.WriteLine("2 - Listar falhas");
                Console.WriteLine("3 - Alterar falha");
                Console.WriteLine("4 - Gerar relatório");
                Console.WriteLine("5 - Sair");
                Console.WriteLine("6 - Excluir falha");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "1": RegistrarFalha(); break;
                    case "2": ListarFalhas(); break;
                    case "3": AlterarFalha(); break;
                    case "4": GerarRelatorio(); break;
                    case "5": sair = true; break;
                    case "6": ExcluirFalha(); break;
                    default: Console.WriteLine("Opção inválida."); break;
                }
            }
        }

        private void RegistrarFalha()
        {
            Console.WriteLine("\n--- Registrar Falha ---");

            string LerCampoObrigatorio(string nomeCampo)
            {
                string valor;
                do
                {
                    Console.Write($"{nomeCampo}: ");
                    valor = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(valor))
                        Console.WriteLine($"{nomeCampo} não pode ser vazio.");
                } while (string.IsNullOrWhiteSpace(valor));
                return valor;
            }

            string local = LerCampoObrigatorio("Local");

            Console.Write("Início (yyyy-MM-dd HH:mm): ");
            while (!DateTime.TryParse(Console.ReadLine(), out DateTime inicio))
                Console.Write("Data inválida. Digite novamente (yyyy-MM-dd HH:mm): ");

            string previsao = LerCampoObrigatorio("Previsão");
            string impacto = LerCampoObrigatorio("Impacto");

            var falha = new FalhaEnergia
            {
                Local = local,
                Previsao = previsao,
                Impacto = impacto,
                Resolvido = false
            };

            _controller.RegistrarFalha(falha);
            Console.WriteLine("Falha registrada com sucesso!");
        }

        private void ListarFalhas()
        {
            Console.WriteLine("\n--- Falhas Registradas ---");
            var falhas = _controller.ObterFalhas();
            if (falhas.Count == 0)
            {
                Console.WriteLine("Nenhuma falha registrada.");
                return;
            }

            foreach (var f in falhas)
            {
                Console.WriteLine($"ID: {f.Id} | Tipo: {f.Tipo} | Local: {f.Local} | Início: {f.Inicio} | Previsão: {f.Previsao} | Resolvido: {(f.Resolvido ? "Sim" : "Não")}");
                if (f is FalhaEnergia fe)
                    Console.WriteLine($"Impacto: {fe.Impacto}");
                Console.WriteLine("------------------------------");
            }
        }

        private void AlterarFalha()
        {
            ListarFalhas();
            Console.Write("\nID da falha a alterar: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            var falha = _controller.ObterFalhaPorId(id);
            if (falha == null)
            {
                Console.WriteLine("Falha não encontrada.");
                return;
            }

            Console.WriteLine("1 - Local\n2 - Início\n3 - Previsão\n4 - Impacto\n5 - Marcar como resolvida");
            Console.Write("Opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.Write("Novo local: ");
                    falha.Local = Console.ReadLine();
                    break;
                case "2":
                    DateTime novoInicio;
                    Console.Write("Novo início (yyyy-MM-dd HH:mm): ");
                    while (!DateTime.TryParse(Console.ReadLine(), out novoInicio))
                        Console.Write("Data inválida: ");
                    falha.Inicio = novoInicio;
                    break;
                case "3":
                    Console.Write("Nova previsão: ");
                    falha.Previsao = Console.ReadLine();
                    break;
                case "4":
                    if (falha is FalhaEnergia fe)
                    {
                        Console.Write("Novo impacto: ");
                        fe.Impacto = Console.ReadLine();
                    }
                    break;
                case "5":
                    falha.Resolvido = true;
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    return;
            }

            _controller.AtualizarFalha(falha);
            Console.WriteLine("Falha atualizada com sucesso!");
        }

        private void GerarRelatorio()
        {
            var falhas = _controller.ObterFalhas();
            int total = falhas.Count;
            int resolvidas = falhas.Count(f => f.Resolvido);
            int abertas = total - resolvidas;

            Console.WriteLine($"\nTotal: {total}\nResolvidas: {resolvidas}\nAbertas: {abertas}");
        }

        private void ExcluirFalha()
        {
            ListarFalhas();

            Console.Write("\nID da falha a excluir: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            var falha = _controller.ObterFalhaPorId(id);
            if (falha == null)
            {
                Console.WriteLine("Falha não encontrada.");
                return;
            }

            Console.Write("Tem certeza que deseja excluir essa falha? (s/n): ");
            string confirma = Console.ReadLine()?.ToLower();

            if (confirma == "s" || confirma == "sim")
            {
                try
                {
                    _controller.ExcluirFalha(id);
                    Console.WriteLine("Falha excluída com sucesso!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao excluir falha: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Exclusão cancelada.");
            }
        }
    }
}
