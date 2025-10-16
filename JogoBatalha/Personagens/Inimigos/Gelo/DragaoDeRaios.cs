using System;
using System.Collections.Generic;

namespace JogoBatalha.Personagens.Inimigos.Gelo
{
    public class DragaoDeRaios : Inimigo
    {
        public DragaoDeRaios()
            : base("Dragão de Raios Wyrmvyr", 250, 30, 15) 
        {
        }

        public override void Atacar(Personagem alvo)
        {
            Console.WriteLine($"{this.Nome} canaliza o poder da tempestade!");
            Random random = new Random();
            int escolha = random.Next(3);

            if (escolha == 0)
            {
                Console.WriteLine("Ele dispara um Sopro Elétrico que atinge a todos!");
                alvo.ReceberDano((int)(this.ForcaDeAtaque * 0.8), this.Tipo);
            }
            else
            {
                Console.WriteLine($"Ele crava suas garras eletrificadas em {alvo.Nome}!");
                base.Atacar(alvo);
                if (random.Next(1, 101) <= 30)
                {
                    alvo.AplicarEfeito(EfeitoDeStatus.Atordoado, 1);
                }
            }
        }
    }
}