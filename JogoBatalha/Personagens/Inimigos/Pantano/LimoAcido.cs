using System;

namespace JogoBatalha.Personagens.Inimigos.Pantano
{
    public class LimoAcido : Inimigo
    {
        public LimoAcido()
            : base("Limo Ácido", 80, 10, 10) 
        {
        }

        public override void Atacar(Personagem alvo)
        {
            Console.WriteLine($"{this.Nome} dispara uma Gosma Corrosiva!");
            base.Atacar(alvo);

            alvo.AplicarEfeito(EfeitoDeStatus.ArmaduraQuebrada, 99);
        }
    }
}