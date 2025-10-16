using System;

namespace JogoBatalha.Personagens.Inimigos.Deserto
{
    public class VermeDaAreia : Inimigo
    {
        private bool _estaEnterrado = false;

        public VermeDaAreia()
            : base("Verme da Areia", 200, 35, 18) 
        {
        }

        public new void ReceberDano(int danoBruto, TipoDePersonagem tipoAtacante)
        {
            if (_estaEnterrado)
            {
                Console.WriteLine($"{this.Nome} está enterrado e não pode ser atingido!");
            }
            else
            {
                base.ReceberDano(danoBruto, tipoAtacante);
            }
        }

        public override void Atacar(Personagem alvo)
        {
            if (!_estaEnterrado)
            {
                Console.WriteLine($"{this.Nome} mergulha na areia!");
                _estaEnterrado = true;
            }
            else
            {
                Console.WriteLine($"{this.Nome} emerge da areia para Engolir!");
                int danoMassivo = this.ForcaDeAtaque * 2;
                alvo.ReceberDano(danoMassivo, this.Tipo);
                _estaEnterrado = false; 
            }
        }
    }
}