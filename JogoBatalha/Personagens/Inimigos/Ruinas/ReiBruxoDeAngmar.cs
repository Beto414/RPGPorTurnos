using System;

namespace JogoBatalha.Personagens.Inimigos.Ruinas
{
    public class ReiBruxoDeAngmar : Inimigo
    {
        public ReiBruxoDeAngmar()
            : base("Rei Bruxo de Angmar", 350, 38, 20)
        {
        }

        public override void Atacar(Personagem alvo)
        {
            Console.WriteLine($"{this.Nome} ataca com sua lâmina Morgul!");
            base.Atacar(alvo);

            Random random = new Random();
            if (random.Next(1, 101) <= 30)
            {
                Console.WriteLine("O grito do Nazgûl ecoa, paralisando o herói de medo!");
                alvo.AplicarEfeito(EfeitoDeStatus.Atordoado, 1);
            }
        }
    }
}