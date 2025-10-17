using System;

namespace JogoBatalha.Personagens.Inimigos.Floresta
{
    public class ElementalDeFogo : Inimigo
    {
        public ElementalDeFogo()
            : base("Elemental de Fogo", 180, 28, 12)
        {
        }

        public override void Atacar(Personagem alvo)
        {
            Console.WriteLine($"{this.Nome} lança uma Erupção de Chamas!");
            base.Atacar(alvo);
            alvo.AplicarEfeito(EfeitoDeStatus.Queimando, 2);
        }
    }
}