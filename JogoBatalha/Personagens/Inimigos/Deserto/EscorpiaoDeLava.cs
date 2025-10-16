using System;

namespace JogoBatalha.Personagens.Inimigos.Deserto
{
    public class EscorpiaoDeLava : Inimigo
    {
        public EscorpiaoDeLava()
            : base("Escorpião de Lava", 80, 18, 8)
        {
        }

        public override void Atacar(Personagem alvo)
        {
            Console.WriteLine($"{this.Nome} ataca com seu ferrão incandescente!");
            base.Atacar(alvo);

            Random random = new Random();
            if (random.Next(1, 101) <= 30) 
            {
                alvo.AplicarEfeito(EfeitoDeStatus.Queimando, 2);
            }
        }
    }
}
