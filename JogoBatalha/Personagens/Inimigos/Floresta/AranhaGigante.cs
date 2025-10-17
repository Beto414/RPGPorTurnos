using System;
namespace JogoBatalha.Personagens.Inimigos.Floresta
{
    public class AranhaGigante : Inimigo
    {
        public AranhaGigante() : base("Aranha Gigante", 100, 18, 10) { }

        public override void Atacar(Personagem alvo)
        {
            Console.WriteLine($"{this.Nome} ataca com suas presas venenosas!");
            base.Atacar(alvo);
            Random random = new Random();
            if (random.Next(1, 101) <= 35) 
            {
                alvo.AplicarEfeito(EfeitoDeStatus.Queimando, 3);
            }
        }
    }
}