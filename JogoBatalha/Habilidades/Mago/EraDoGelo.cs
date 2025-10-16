using JogoBatalha.Personagens.Herois;
using System;
using System.Collections.Generic;

namespace JogoBatalha.Habilidades.Mago
{
    public class EraDoGelo : Habilidade
    {
        public EraDoGelo()
            : base("Era do Gelo", "Causa dano alto em todos os inimigos, com 25% de chance de Congelar cada um por 1 turno.", TipoDeAlvo.Inimigo, 50)
        {
        }

        public override void Executar(Personagem usuario, Personagem alvo, List<Personagem> todosOsInimigos)
        {
            if (usuario is HabilidadesMago mago && mago.PontosDeMana >= CustoDeMana)
            {
                mago.ConsumirMana(CustoDeMana);
                Console.WriteLine($"{usuario.Nome} desencadeia a {Nome}!");

                int dano = (int)(usuario.ForcaDeAtaque * 1.8); 
                Random random = new Random();

                foreach (var inimigo in todosOsInimigos)
                {
                    if (inimigo.EstaVivo())
                    {
                        Console.WriteLine($"{inimigo.Nome} é atingido pela onda de gelo!");
                        inimigo.ReceberDano(dano, usuario.Tipo);

                        // Chance de congelar
                        if (random.Next(1, 101) <= 25)
                        {
                            inimigo.AplicarEfeito(EfeitoDeStatus.Congelado, 1);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine($"{usuario.Nome} não tem mana suficiente!");
            }
        }
    }
}