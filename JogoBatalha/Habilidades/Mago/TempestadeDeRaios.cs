using JogoBatalha.Personagens.Herois;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JogoBatalha.Habilidades.Mago
{
    public class TempestadeDeRaios : Habilidade
    {
        public TempestadeDeRaios()
            : base("Tempestade de Raios", "Causa dano médio em um alvo, com 40% de chance de atingir um segundo inimigo e 15% de chance de Atordoar o alvo principal.", TipoDeAlvo.Inimigo, 35)
        {
        }

        public override void Executar(Personagem usuario, Personagem alvo, List<Personagem> todosOsInimigos)
        {
            if (usuario is HabilidadesMago mago && mago.PontosDeMana >= CustoDeMana)
            {
                mago.ConsumirMana(CustoDeMana);
                Console.WriteLine($"{usuario.Nome} invoca uma {Nome}!");

                int dano = (int)(usuario.ForcaDeAtaque * 1.5); 
                alvo.ReceberDano(dano, usuario.Tipo);

                Random random = new Random();
                if (random.Next(1, 101) <= 15)
                {
                    alvo.AplicarEfeito(EfeitoDeStatus.Atordoado, 1);
                }

                if (random.Next(1, 101) <= 40)
                {
                    var outrosAlvos = todosOsInimigos.Where(i => i != alvo && i.EstaVivo()).ToList();
                    if (outrosAlvos.Any())
                    {
                        var segundoAlvo = outrosAlvos[random.Next(outrosAlvos.Count)];
                        Console.WriteLine($"O raio encadeia e atinge {segundoAlvo.Nome}!");
                        segundoAlvo.ReceberDano((int)(dano * 0.7), usuario.Tipo); 
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
