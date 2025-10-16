using System;

namespace JogoBatalha.Personagens.Inimigos.Gelo
{
    public class GiganteDeGelo : Inimigo
    {
        public GiganteDeGelo()
            : base("Gigante de Gelo", 150, 12, 15) 
        {
        }

        public override void Atacar(Personagem alvo)
        {
            Console.WriteLine($"{this.Nome} ergue seu porrete colossal para uma Pancada Esmagadora!");

            int dano = (int)(this.ForcaDeAtaque * 1.5);
            alvo.ReceberDano(dano, this.Tipo);

            Random random = new Random();
            if (random.Next(1, 101) <= 25)
            {
                alvo.AplicarEfeito(EfeitoDeStatus.Atordoado, 1);
            }
        }
    }
}