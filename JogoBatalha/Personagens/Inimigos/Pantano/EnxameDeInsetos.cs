using System;

namespace JogoBatalha.Personagens.Inimigos.Pantano
{
    public class EnxameDeInsetos : Inimigo
    {
        public EnxameDeInsetos()
            : base("Enxame de Insetos", 50, 8, 2) 
        {
        }

        public override void Atacar(Personagem alvo)
        {
            Console.WriteLine($"{this.Nome} avança sobre os heróis!");

            alvo.ReceberDano(this.ForcaDeAtaque, this.Tipo);

            Console.WriteLine($"{alvo.Nome} é atormentado pelos insetos!");
        }
    }
}