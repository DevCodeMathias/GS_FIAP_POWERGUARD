namespace PowerGuard.Model
{
    public abstract class Falha
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public DateTime Inicio { get; set; }
        public string Previsao { get; set; }
        public bool Resolvido { get; set; }

        public virtual string Tipo => "Falha";
    }
}
