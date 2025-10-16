using System;

namespace JogoBatalha.Personagens.Inimigos.Deserto
{
    public class BandidoDoDeserto : Inimigo
    {
        public BandidoDoDeserto()
            : base("Bandido do Deserto", 75, 17, 6) 
        {
        }

        public new void ReceberDano(int danoBruto, TipoDePersonagem tipoAtacante)
        {
            Random random = new Random();
            if (random.Next(1, 101) <= 30) 
            {
                Console.WriteLine($"{this.Nome} se esquiva agilmente do ataque!");
            }
            else
            {
                base.ReceberDano(danoBruto, tipoAtacante);
            }
        }

        public override void Atacar(Personagem alvo)
        {
            Console.WriteLine($"{this.Nome} avança com um Ataque Rápido!");
            base.Atacar(alvo);

            Random random = new Random();
            if (random.Next(1, 101) <= 25)
            {
                Console.WriteLine($"{this.Nome} ataca novamente!");
                base.Atacar(alvo);
            }
        }
    }
}