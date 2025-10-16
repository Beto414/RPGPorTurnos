using System;

namespace JogoBatalha.Personagens.Inimigos.Deserto
{
    public class DjinnDasAreias : Inimigo
    {
        public DjinnDasAreias()
            : base("Djinn das Areias", 100, 22, 7)
        {
        }

        public override void Atacar(Personagem alvo)
        {
            Random random = new Random();
            int escolha = random.Next(1, 101);

            if (escolha <= 50)
            {
                Console.WriteLine($"{this.Nome} invoca um Punho de Pedra contra {alvo.Nome}!");
                int dano = (int)(this.ForcaDeAtaque * 1.2);
                alvo.ReceberDano(dano, this.Tipo);
            }
            else 
            {
                Console.WriteLine($"{this.Nome} cria uma Tempestade de Areia ofuscante!");
         
                int danoArea = (int)(this.ForcaDeAtaque * 0.5);
                alvo.ReceberDano(danoArea, this.Tipo);
            }
        }
    }
}