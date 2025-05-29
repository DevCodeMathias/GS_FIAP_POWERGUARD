using PowerGuard.Model;
using PowerGuard.Service;

namespace PowerGuard.Controller
{
    public class FalhaController
    {
        private readonly FalhaService _service;

        public FalhaController()
        {
            _service = new FalhaService();
        }

        public void RegistrarFalha(Falha falha)
        {
            _service.RegistrarFalha(falha);
        }

        public List<Falha> ObterFalhas()
        {
            return _service.ObterFalhas();
        }

        public Falha ObterFalhaPorId(int id)
        {
            return _service.ObterFalhaPorId(id);
        }

        public void AtualizarFalha(Falha falha)
        {
            _service.AtualizarFalha(falha);
        }

        public void ExcluirFalha(int id)
        {
            _service.ExcluirFalha(id);
        }
    }
}
