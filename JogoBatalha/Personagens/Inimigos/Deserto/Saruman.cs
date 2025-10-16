using System;

namespace JogoBatalha.Personagens.Inimigos.Deserto
{
    public class Saruman : Inimigo
    {
        public Saruman()
            : base("Feiticeiro das Areias Saruman", 200, 35, 10)
        {
        }

        public override void Atacar(Personagem alvo)
        {
            Console.WriteLine($"{this.Nome} conjura magia antiga!");
            Random random = new Random();
            int escolha = random.Next(3);

            if (escolha == 0)
            {
                Console.WriteLine($"Ele lança uma Maldição Drenante em {alvo.Nome}!");
                int dano = this.ForcaDeAtaque;
                alvo.ReceberDano(dano, this.Tipo);
                int cura = dano / 2;
                this.PontosDeVida += cura;
                Console.WriteLine($"{this.Nome} se cura em {cura} HP!");
            }
            else
            {
                Console.WriteLine("Ele dispara uma Rajada de Energia Negra!");
                base.Atacar(alvo);
            }
        }
    }
}