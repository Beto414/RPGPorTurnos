using System;

namespace JogoBatalha.Personagens.Inimigos.Pantano
{
    public class CobraVenenosa : Inimigo
    {
        public CobraVenenosa()
            : base("Cobra Venenosa", 60, 15, 4) 
        {
        }

        public override void Atacar(Personagem alvo)
        {
            Console.WriteLine($"{this.Nome} dá uma Picada Peçonhenta!");
            base.Atacar(alvo);

            Random random = new Random();
            if (random.Next(1, 101) <= 80)
            {
                alvo.AplicarEfeito(EfeitoDeStatus.Queimando, 3); 
            }
        }
    }
}