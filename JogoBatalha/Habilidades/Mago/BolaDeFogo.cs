using JogoBatalha.Personagens.Herois;
using System;
using System.Collections.Generic;

namespace JogoBatalha.Habilidades.Mago
{
    public class BolaDeFogo : Habilidade
    {
        public BolaDeFogo()
            : base("Bola de Fogo", "Causa dano massivo em um inimigo e tem 30% de chance de causar Queimadura por 2 turnos.", TipoDeAlvo.Inimigo, 25)
        {
        }

        public override void Executar(Personagem usuario, Personagem alvo, List<Personagem> todosOsInimigos)
        {
            if (usuario is HabilidadesMago mago && mago.PontosDeMana >= CustoDeMana)
            {
                mago.ConsumirMana(CustoDeMana);
                Console.WriteLine($"{usuario.Nome} conjura uma {Nome}!");

                int dano = (int)(usuario.ForcaDeAtaque * 2.5); 
                alvo.ReceberDano(dano, usuario.Tipo);

                Random random = new Random();
                if (random.Next(1, 101) <= 30)
                {
                    alvo.AplicarEfeito(EfeitoDeStatus.Queimando, 2);
                }
            }
            else
            {
                Console.WriteLine($"{usuario.Nome} não tem mana suficiente!");
            }
        }
    }
}
