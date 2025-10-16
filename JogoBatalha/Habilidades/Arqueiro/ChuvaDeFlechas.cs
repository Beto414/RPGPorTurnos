using System;
using System.Collections.Generic;

namespace JogoBatalha.Habilidades.Arqueiro
{
    public class ChuvaDeFlechas : Habilidade
    {
        public ChuvaDeFlechas()
            : base("Chuva de Flechas", "Atira de 1 a 8 flechas em cada inimigo, cada uma causando dano baixo.", TipoDeAlvo.Inimigo)
        {
        }

        public override void Executar(Personagem usuario, Personagem alvo, List<Personagem> todosOsInimigos)
        {
            Console.WriteLine($"{usuario.Nome} dispara uma {Nome} sobre o campo de batalha!");
            Random random = new Random();

            foreach (var inimigo in todosOsInimigos)
            {
                if (inimigo.EstaVivo())
                {
                    int numeroDeFlechas = random.Next(1, 9);
                    int danoPorFlecha = (int)(usuario.ForcaDeAtaque * 0.8);
                    int danoTotal = numeroDeFlechas * danoPorFlecha;

                    Console.WriteLine($"{inimigo.Nome} é atingido por {numeroDeFlechas} flechas!");
                    inimigo.ReceberDano(danoTotal, usuario.Tipo);
                }
            }
        }
    }
}