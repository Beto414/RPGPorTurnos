using System;
using System.Linq;
namespace JogoBatalha.Personagens.Inimigos.Floresta
{
    public class DruidaCorrompido : Inimigo
    {
        public DruidaCorrompido() : base("Druida Corrompido", 90, 15, 8) { }

        public override void Atacar(Personagem alvo)
        {
            Console.WriteLine($"{this.Nome} usa magia da natureza corrompida!");
            base.Atacar(alvo);
        }
    }
}