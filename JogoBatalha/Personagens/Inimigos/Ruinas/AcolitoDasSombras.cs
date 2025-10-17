using System;
namespace JogoBatalha.Personagens.Inimigos.Ruinas
{
    public class AcolitoDasSombras : Inimigo
    {
        public AcolitoDasSombras() : base("Acólito das Sombras", 85, 12, 7) { }

        public override void Atacar(Personagem alvo)
        {
            Console.WriteLine($"{this.Nome} lança uma maldição em {alvo.Nome}!");
            Random random = new Random();
            if (random.Next(2) == 0)
            {
                alvo.AplicarEfeito(EfeitoDeStatus.BuffAtaque, -3); 
                Console.WriteLine("O ataque do herói foi reduzido!");
            }
            else
            {
                alvo.AplicarEfeito(EfeitoDeStatus.BuffDefesa, -3); 
                Console.WriteLine("A defesa do herói foi reduzida!");
            }
        }
    }
}