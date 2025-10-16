using System;

namespace JogoBatalha.Personagens.Inimigos.Pantano
{
    public class CobraGigante : Inimigo
    {
        public CobraGigante()
            : base("Hidra do Pântano", 300, 25, 18)
        {
        }

        public override void Atacar(Personagem alvo)
        {
            Console.WriteLine($"{this.Nome} ataca com suas múltiplas cabeças!");
            base.Atacar(alvo); 

            Random random = new Random();
            if (random.Next(2) == 0)
            {
                Console.WriteLine("Uma segunda cabeça ataca!");
                base.Atacar(alvo);
            }

            if (random.Next(1, 101) <= 40)
            {
                alvo.AplicarEfeito(EfeitoDeStatus.Queimando, 3); 
            }
        }
    }
}