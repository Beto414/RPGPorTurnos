using System;
using System.Collections.Generic;

namespace JogoBatalha.Habilidades.Guerreiro
{
    public class GritoDeGuerra : Habilidade
    {
        public GritoDeGuerra()
            : base("Grito de Guerra", "Aumenta o ataque em 15% e a defesa em 20% por 3 turnos.", TipoDeAlvo.Aliado)
        {
        }

        public override void Executar(Personagem usuario, Personagem alvo, List<Personagem> todosOsInimigos)
        {
            Console.WriteLine($"{usuario.Nome} solta um {Nome} inspirador!");

            usuario.AplicarEfeito(EfeitoDeStatus.BuffAtaque, 3);
            usuario.AplicarEfeito(EfeitoDeStatus.BuffDefesa, 3);
        }
    }
}