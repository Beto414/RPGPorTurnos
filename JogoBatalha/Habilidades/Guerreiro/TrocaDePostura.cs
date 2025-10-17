using JogoBatalha.Personagens.Herois;
using System;
using System.Collections.Generic;

namespace JogoBatalha.Habilidades.Guerreiro
{
    public class TrocaDePostura : Habilidade
    {
        public TrocaDePostura() : base("Troca de Postura", "Altera entre posturas Ofensiva, Defensiva e Equilibrada.", TipoDeAlvo.Aliado) { }

        public override void Executar(Personagem usuario, Personagem alvo, List<Personagem> todosOsInimigos)
        {
            if (usuario is Personagens.Herois.Guerreiro guerreiro)
            {
                Console.WriteLine("\nEscolha a nova postura:");
                Console.WriteLine("1. Equilibrada (Normal)");
                Console.WriteLine("2. Ofensiva (+25% de dano causado)");
                Console.WriteLine("3. Defensiva (-40% de dano recebido, -25% de dano causado)");

                int? escolha = UserInput.GetInt("Postura (1-3): ", 1, 3);

                if (escolha == null)
                {
                    Console.WriteLine("Ação cancelada.");
                    return;
                }

                guerreiro.MudarPostura((PosturaGuerreiro)(escolha.Value - 1));
            }
        }
    }
}