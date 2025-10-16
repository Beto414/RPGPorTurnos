using System;
using System.Collections.Generic;
using System.Linq;

namespace JogoBatalha.Personagens.Inimigos
{
    public class Sauron : Inimigo
    {
        private bool _emFuria = false;

        public Sauron()
            : base("Sauron, o Lorde Sombrio", 500, 40, 25) 
        {
        }
        public new void ReceberDano(int danoBruto, TipoDePersonagem tipoAtacante)
        {
            base.ReceberDano(danoBruto, tipoAtacante);

            if (!_emFuria && this.PontosDeVida <= (this.PontosDeVidaMax / 2))
            {
                _emFuria = true;
                this.ForcaDeAtaque = (int)(this.ForcaDeAtaque * 1.3); 
                Console.WriteLine("O olho de Sauron brilha intensamente! Ele entra em fúria!");
            }
        }

        public override void Atacar(Personagem alvo)
        {
            Random random = new Random();
            int escolhaAtaque = random.Next(1, 101);

            if (!_emFuria)
            {
                if (escolhaAtaque <= 40) 
                {
                    GolpeComMaca(alvo);
                }
                else if (escolhaAtaque <= 70) 
                {
                    PalavraDeComando(alvo);
                }
                else 
                {
                    OndaDePavor(alvo); 
                }
            }
            else 
            {
                if (escolhaAtaque <= 40)
                {
                    GolpeComMaca(alvo); 
                }
                else if (escolhaAtaque <= 70) 
                {
                    OndaDePavor(alvo);
                }
                else 
                {
                    UmAnelParaTodosGovernar(alvo);
                }
            }
        }

        private void GolpeComMaca(Personagem alvo)
        {
            Console.WriteLine($"{this.Nome} ataca {alvo.Nome} com sua maça negra!");
            base.Atacar(alvo);
        }

        private void PalavraDeComando(Personagem alvo)
        {
            Console.WriteLine($"{this.Nome} sussurra uma Palavra de Comando, paralisando {alvo.Nome}!");
            alvo.AplicarEfeito(EfeitoDeStatus.Atordoado, 1);
        }

        private void OndaDePavor(Personagem alvo)
        {
            Console.WriteLine($"{this.Nome} libera uma Onda de Pavor que atinge a todos!");
            int danoArea = (int)(this.ForcaDeAtaque * 0.7);
            alvo.ReceberDano(danoArea, this.Tipo);
            alvo.AplicarEfeito(EfeitoDeStatus.ArmaduraQuebrada, 2); 
        }

        private void UmAnelParaTodosGovernar(Personagem alvo)
        {
            Console.WriteLine($"{this.Nome} canaliza o poder do Um Anel!");
            int dano = this.ForcaDeAtaque * 2;
            alvo.ReceberDano(dano, this.Tipo);

            int cura = dano / 3;
            this.PontosDeVida += cura;
            if (this.PontosDeVida > this.PontosDeVidaMax) this.PontosDeVida = this.PontosDeVidaMax;
            Console.WriteLine($"{this.Nome} drena a força vital de {alvo.Nome}, curando-se em {cura} HP!");
        }
    }
}