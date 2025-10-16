using System;

namespace JogoBatalha.Personagens.Inimigos.Gelo
{
    public class ElementalDeGelo : Inimigo
    {
        public ElementalDeGelo()
            : base("Elemental de Gelo", 90, 22, 8) 
        {
        }

        public new void AplicarEfeito(EfeitoDeStatus efeito, int duracao)
        {
            if (efeito == EfeitoDeStatus.Congelado)
            {
                Console.WriteLine($"{this.Nome} é imune a congelamento!");
            }
            else
            {
                base.AplicarEfeito(efeito, duracao);
            }
        }

        public override void Atacar(Personagem alvo)
        {
            Console.WriteLine($"{this.Nome} dispara uma Lança de Gelo afiada!");

            int dano = this.ForcaDeAtaque; 

            int danoPerfurante = 5;
            alvo.ReceberDano(dano + danoPerfurante, this.Tipo);
        }
    }
}