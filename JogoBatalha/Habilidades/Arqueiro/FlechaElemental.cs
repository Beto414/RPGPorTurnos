using System;
using System.Collections.Generic;

namespace JogoBatalha.Habilidades.Arqueiro
{
    public class FlechaElemental : Habilidade
    {
        public FlechaElemental()
            : base("Flecha Elemental", "Atira uma flecha imbuída com um elemento aleatório (Fogo, Gelo ou Raio).", TipoDeAlvo.Inimigo)
        {
        }

        public override void Executar(Personagem usuario, Personagem alvo, List<Personagem> todosOsInimigos)
        {
            Random random = new Random();
            int elemento = random.Next(3); 
            int dano = (int)(usuario.ForcaDeAtaque * 1.8); 

            if (elemento == 0) 
            {
                Console.WriteLine($"{usuario.Nome} atira uma Flecha de Fogo em {alvo.Nome}!");
                alvo.ReceberDano(dano, usuario.Tipo);
                if (random.Next(1, 101) <= 50) alvo.AplicarEfeito(EfeitoDeStatus.Queimando, 2);
            }
            else if (elemento == 1) 
            {
                Console.WriteLine($"{usuario.Nome} atira uma Flecha de Gelo em {alvo.Nome}!");
                alvo.ReceberDano(dano, usuario.Tipo);
                if (random.Next(1, 101) <= 50) alvo.AplicarEfeito(EfeitoDeStatus.Congelado, 1);
            }
            else 
            {
                Console.WriteLine($"{usuario.Nome} atira uma Flecha de Raio em {alvo.Nome}!");
                alvo.ReceberDano(dano, usuario.Tipo);
                if (random.Next(1, 101) <= 25) alvo.AplicarEfeito(EfeitoDeStatus.Atordoado, 1);
            }
        }
    }
}