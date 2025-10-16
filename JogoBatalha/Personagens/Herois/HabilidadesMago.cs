using System;
using JogoBatalha.Habilidades;
using JogoBatalha.Habilidades.Mago;

namespace JogoBatalha.Personagens.Herois
{
    public class HabilidadesMago : Personagem
    {
        public int PontosDeMana { get; private set; }
        public int PontosDeManaMax { get; private set; }

        public HabilidadesMago(string nome)
            : base(nome, 80, 25, 5, TipoDePersonagem.Mago) 
        {
            PontosDeManaMax = 100;
            PontosDeMana = PontosDeManaMax;

            Habilidades.Add(new BolaDeFogo());
            Habilidades.Add(new TempestadeDeRaios());
            Habilidades.Add(new EraDoGelo());
            Habilidades.Add(new Abencoar());
        }

        public override void Atacar(Personagem alvo)
        {
            Console.WriteLine($"{this.Nome} ataca com seu cajado, absorvendo energia mística!");

            int danoBase = (int)(this.ForcaDeAtaque * 0.8);

            if (this.Efeitos.ContainsKey(EfeitoDeStatus.BuffAtaque))
            {
                Console.WriteLine("O cajado brilha com poder elemental!");
                danoBase *= 2;
                this.Efeitos.Remove(EfeitoDeStatus.BuffAtaque);
            }

            alvo.ReceberDano(danoBase, this.Tipo);

            int manaRecuperada = (int)(this.PontosDeManaMax * 0.35);
            this.PontosDeMana += manaRecuperada;
            if (this.PontosDeMana > this.PontosDeManaMax)
            {
                this.PontosDeMana = this.PontosDeManaMax;
            }
            Console.WriteLine($"{this.Nome} recupera {manaRecuperada} de mana. Mana atual: {this.PontosDeMana}");
        }


        public void ConsumirMana(int custo)
        {
            PontosDeMana -= custo;
            if (PontosDeMana < 0) PontosDeMana = 0;
        }

        public void RecuperarMana(int quantidade)
        {
            this.PontosDeMana += quantidade;
            if (this.PontosDeMana > this.PontosDeManaMax)
            {
                this.PontosDeMana = this.PontosDeManaMax;
            }
            Console.WriteLine($"{this.Nome} recuperou {quantidade} de Mana.");
        }
    }
}