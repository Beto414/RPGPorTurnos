namespace JogoBatalha.Personagens.Inimigos.Ruinas
{
    public class EsqueletoReanimado : Inimigo
    {
        private bool _jaReergueu = false;
        public EsqueletoReanimado() : base("Esqueleto Reanimado", 70, 16, 6) { }

        public new void ReceberDano(int danoBruto, TipoDePersonagem tipoAtacante)
        {
            base.ReceberDano(danoBruto, tipoAtacante);
            if (!this.EstaVivo() && !_jaReergueu)
            {
                _jaReergueu = true;
                this.PontosDeVida = 1;
                Console.WriteLine($"Os ossos do {this.Nome} se juntam e ele se reergue com 1 HP!");
            }
        }
    }
}