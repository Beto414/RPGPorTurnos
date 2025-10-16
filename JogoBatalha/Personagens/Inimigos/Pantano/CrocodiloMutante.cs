using System;

namespace JogoBatalha.Personagens.Inimigos.Pantano
{
    public class CrocodiloMutante : Inimigo
    {
        public CrocodiloMutante()
            : base("Crocodilo Mutante", 100, 15, 12) 
        {
        }

        public override void Atacar(Personagem alvo)
        {
            Console.WriteLine($"{this.Nome} usa sua mandíbula esmagadora!");
            int dano = this.ForcaDeAtaque * 2; 
            alvo.ReceberDano(dano, this.Tipo);
        }
    }
}