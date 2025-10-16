using System;
using System.Collections.Generic;

namespace JogoBatalha.Habilidades.Arqueiro
{
    public class FlechaExplosiva : Habilidade
    {
        public FlechaExplosiva()
            : base("Flecha Explosiva", "Causa dano massivo em um alvo e quebra sua armadura, fazendo-o receber 20% a mais de dano pelo resto da batalha.", TipoDeAlvo.Inimigo)
        {
        }

        public override void Executar(Personagem usuario, Personagem alvo, List<Personagem> todosOsInimigos)
        {
            Console.WriteLine($"{usuario.Nome} atira uma {Nome} em {alvo.Nome}!");

            int dano = (int)(usuario.ForcaDeAtaque * 2.2); 
            alvo.ReceberDano(dano, usuario.Tipo);

            alvo.AplicarEfeito(EfeitoDeStatus.ArmaduraQuebrada, 99);
        }
    }
}