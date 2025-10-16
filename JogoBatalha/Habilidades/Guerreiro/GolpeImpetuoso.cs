using System;
using System.Collections.Generic;

namespace JogoBatalha.Habilidades.Guerreiro
{
    public class GolpeImpetuoso : Habilidade
    {
        public GolpeImpetuoso()
            : base("Golpe Impetuoso", "Um ataque poderoso com 50% de chance de errar. Se acertar, causa dano massivo e atordoa o alvo por 1 turno.", TipoDeAlvo.Inimigo)
        {
        }

        public override void Executar(Personagem usuario, Personagem alvo, List<Personagem> todosOsInimigos)
        {
            Console.WriteLine($"{usuario.Nome} prepara um {Nome} contra {alvo.Nome}!");

            Random random = new Random();
            if (random.Next(1, 101) <= 50) 
            {
                int dano = usuario.ForcaDeAtaque * 3;
                Console.WriteLine($"O golpe conecta com força total, causando {dano} de dano!");
                alvo.ReceberDano(dano, usuario.Tipo);
                alvo.AplicarEfeito(EfeitoDeStatus.Atordoado, 1);
            }
            else
            {
                Console.WriteLine("O ataque foi selvagem, mas errou o alvo!");
            }
        }
    }
}