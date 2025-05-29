using PowerGuard.Model;

namespace PowerGuard.Service
{
    public class FalhaService
    {
        private List<Falha> falhas = new List<Falha>();
        private int proximoId = 1;

        public void RegistrarFalha(Falha falha)
        {
            try
            {
                falha.Id = proximoId++;
                falhas.Add(falha);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao registrar falha: {ex.Message}");
            }
        }

        public List<Falha> ObterFalhas()
        {
            try
            {
                return falhas;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter falhas: {ex.Message}");
                return new List<Falha>();
            }
        }

        public Falha ObterFalhaPorId(int id)
        {
            try
            {
                return falhas.FirstOrDefault(f => f.Id == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter falha por ID: {ex.Message}");
                return null;
            }
        }

        public void AtualizarFalha(Falha falha)
        {
            try
            {
                var index = falhas.FindIndex(f => f.Id == falha.Id);
                if (index != -1)
                    falhas[index] = falha;
                else
                    Console.WriteLine("Falha não encontrada para atualizar.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar falha: {ex.Message}");
            }
        }

        public void ExcluirFalha(int id)
        {
            var falha = falhas.FirstOrDefault(f => f.Id == id);
            if (falha == null)
                throw new Exception("Falha não encontrada.");

            falhas.Remove(falha);
        }
    }

}
