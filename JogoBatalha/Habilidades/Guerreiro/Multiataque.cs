using System;
using System.Collections.Generic;
using System.Linq;

namespace JogoBatalha.Habilidades.Guerreiro
{
    public class Multiataque : Habilidade
    {
        public Multiataque()
            : base("Multiataque", "Custa 15% da vida máxima para desferir 3 ataques básicos em inimigos aleatórios.", TipoDeAlvo.Inimigo)
        {
        }

        public override void Executar(Personagem usuario, Personagem alvo, List<Personagem> todosOsInimigos)
        {
            int custoDeVida = (int)(usuario.PontosDeVidaMax * 0.15);

            if (usuario.PontosDeVida > custoDeVida)
            {
                usuario.ReceberDano(custoDeVida, TipoDePersonagem.Inimigo); 
                Console.WriteLine($"{usuario.Nome} usa {Nome}, sacrificando {custoDeVida} HP!");

                Random random = new Random();
                for (int i = 0; i < 3; i++)
                {
                    var inimigosVivos = todosOsInimigos.Where(p => p.EstaVivo()).ToList();
                    if (!inimigosVivos.Any())
                    {
                        Console.WriteLine("Não há mais inimigos para atacar!");
                        break;
                    }

                    var alvoAleatorio = inimigosVivos[random.Next(inimigosVivos.Count)];
                    Console.WriteLine($"Ataque {i + 1} mira em {alvoAleatorio.Nome}!");
                    usuario.Atacar(alvoAleatorio); 
                }
            }
            else
            {
                Console.WriteLine($"{usuario.Nome} não tem vida suficiente para usar o Multiataque!");
            }
        }
    }
}