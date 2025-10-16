using System;

namespace JogoBatalha.Personagens.Inimigos.Gelo
{
    public class UrsoPolarFeroz : Inimigo
    {
        private bool _emFuria = false;

        public UrsoPolarFeroz()
            : base("Urso Polar Feroz", 110, 18, 10)
        {
        }

        public new void ReceberDano(int danoBruto, TipoDePersonagem tipoAtacante)
        {
            base.ReceberDano(danoBruto, tipoAtacante);

            if (this.EstaVivo())
            {
                if (!_emFuria)
                {
                    Console.WriteLine($"{this.Nome} ruge, entrando em fúria!");
                    _emFuria = true;
                }

                int aumentoAtaque = 2;
                this.ForcaDeAtaque += aumentoAtaque;
                Console.WriteLine($"A fúria do {this.Nome} aumenta seu ataque para {this.ForcaDeAtaque}!");
            }
        }

        public override void Atacar(Personagem alvo)
        {
            Console.WriteLine($"{this.Nome} ataca com suas garras poderosas!");
            base.Atacar(alvo);
        }
    }
}