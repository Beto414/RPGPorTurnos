using System;

namespace JogoBatalha.Personagens.Inimigos.Pantano
{
    public class TrollDoPantano : Inimigo
    {
        public TrollDoPantano()
            : base("Troll do Pântano", 140, 25, 12) 
        {
        }

        public new void ProcessarEfeitosDeTurno()
        {
            base.ProcessarEfeitosDeTurno();

            if (this.EstaVivo())
            {
                int cura = (int)(this.PontosDeVidaMax * 0.05);
                this.PontosDeVida += cura;
                if (this.PontosDeVida > this.PontosDeVidaMax)
                {
                    this.PontosDeVida = this.PontosDeVidaMax;
                }
                Console.WriteLine($"{this.Nome} se regenera, curando {cura} HP!");
            }
        }

        public override void Atacar(Personagem alvo)
        {
            Console.WriteLine($"{this.Nome} ataca com sua clava pesada!");
            base.Atacar(alvo);
        }
    }
}