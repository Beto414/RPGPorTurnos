using JogoBatalha.Personagens.Herois;
using System;
using System.Collections.Generic;

namespace JogoBatalha.Habilidades.Mago
{
    public class Abencoar : Habilidade
    {
        public Abencoar()
            : base("Abençoar", "Abençoa um aliado, fazendo com que seu próximo ataque cause dano elemental adicional.", TipoDeAlvo.Aliado, 20)
        {
        }

        public override void Executar(Personagem usuario, Personagem alvo, List<Personagem> todosOsInimigos)
        {
            if (usuario is HabilidadesMago mago && mago.PontosDeMana >= CustoDeMana)
            {
                mago.ConsumirMana(CustoDeMana);
                Console.WriteLine($"{usuario.Nome} abençoa {alvo.Nome} com poder elemental!");
                alvo.AplicarEfeito(EfeitoDeStatus.BuffAtaque, 2); 
            }
            else
            {
                Console.WriteLine($"{usuario.Nome} não tem mana suficiente!");
            }
        }
    }
}