using System;
using System.Collections.Generic;

namespace JogoBatalha.Personagens.Inimigos.Gelo
{
    public class FeiticeiraDoInverno : Inimigo
    {
        public FeiticeiraDoInverno()
            : base("Feiticeira do Inverno", 85, 20, 6)
        {
        }

        public override void Atacar(Personagem alvo)
        {
            Random random = new Random();
            int escolha = random.Next(1, 101);

            if (escolha <= 60) 
            {
                Console.WriteLine($"{this.Nome} lança um Raio Congelante em {alvo.Nome}!");
                alvo.ReceberDano(this.ForcaDeAtaque, this.Tipo);
            }
            else 
            {
                Console.WriteLine($"{this.Nome} conjura uma Nevasca sobre os heróis!");
                int danoArea = (int)(this.ForcaDeAtaque * 0.7);
                alvo.ReceberDano(danoArea, this.Tipo);

                if (random.Next(1, 101) <= 25) 
                {
                    alvo.AplicarEfeito(EfeitoDeStatus.Congelado, 1);
                }
            }
        }
    }
}