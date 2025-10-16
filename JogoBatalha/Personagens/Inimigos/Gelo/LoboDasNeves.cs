using System;

namespace JogoBatalha.Personagens.Inimigos.Gelo
{
    public class LoboDasNeves : Inimigo
    {
        public LoboDasNeves()
            : base("Lobo das Neves", 70, 20, 5) 
        {
        }

        public override void Atacar(Personagem alvo)
        {
            Console.WriteLine($"{this.Nome} avança com uma mordida congelante!");
            base.Atacar(alvo); 

            Random random = new Random();
            if (random.Next(1, 101) <= 20) 
            {
                alvo.AplicarEfeito(EfeitoDeStatus.Congelado, 1);
            }
        }
    }
}
