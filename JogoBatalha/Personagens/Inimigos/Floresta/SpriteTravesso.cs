using System;
namespace JogoBatalha.Personagens.Inimigos.Floresta
{
    public class SpriteTravesso : Inimigo
    {
        public SpriteTravesso() : base("Sprite Travesso", 50, 10, 5) { }

        public override void Atacar(Personagem alvo)
        {
            Console.WriteLine($"{this.Nome} joga um pó de sono em {alvo.Nome}!");
            Random random = new Random();
            if (random.Next(1, 101) <= 40) 
            {
                alvo.AplicarEfeito(EfeitoDeStatus.Atordoado, 1); 
            }
            else
            {
                Console.WriteLine("Mas o herói resiste ao feitiço!");
            }
        }
    }
}