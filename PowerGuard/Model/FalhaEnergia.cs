namespace PowerGuard.Model
{
    public class FalhaEnergia : Falha
    {
        public string Impacto { get; set; }
        public override string Tipo => "Falha de Energia";
    }
}
