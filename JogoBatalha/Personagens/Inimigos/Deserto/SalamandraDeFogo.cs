using System;

namespace JogoBatalha.Personagens.Inimigos.Deserto
{
    public class SalamandraDeFogo : Inimigo
    {
        public SalamandraDeFogo()
            : base("Salamandra de Fogo", 90, 16, 9)
        {
        }
        public new void AplicarEfeito(EfeitoDeStatus efeito, int duracao)
        {
            if (efeito == EfeitoDeStatus.Queimando)
            {
                Console.WriteLine($"{this.Nome} absorve o fogo e não sofre dano!");
            }
            else
            {
                base.AplicarEfeito(efeito, duracao);
            }
        }

        public override void Atacar(Personagem alvo)
        {
            Console.WriteLine($"{this.Nome} cospe uma Baforada de Fogo!");
            int danoArea = (int)(this.ForcaDeAtaque * 0.8);
            alvo.ReceberDano(danoArea, this.Tipo);

            Random random = new Random();
            if (random.Next(1, 101) <= 40)
            {
                alvo.AplicarEfeito(EfeitoDeStatus.Queimando, 2);
            }
        }
    }
}