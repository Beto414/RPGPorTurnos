using JogoBatalha.Habilidades.Guerreiro;
using System;

namespace JogoBatalha.Personagens.Herois
{
    public enum PosturaGuerreiro { Equilibrada, Ofensiva, Defensiva }

    public class Guerreiro : Personagem
    {
        public PosturaGuerreiro PosturaAtual { get; private set; }

        public Guerreiro(string nome)
            : base(nome, 120, 15, 10, TipoDePersonagem.Guerreiro)
        {
            PosturaAtual = PosturaGuerreiro.Equilibrada;
            this.Habilidades.Add(new GolpeImpetuoso());
            this.Habilidades.Add(new Multiataque());
            this.Habilidades.Add(new GritoDeGuerra());
            this.Habilidades.Add(new TrocaDePostura()); 
        }

        public void MudarPostura(PosturaGuerreiro novaPostura)
        {
            PosturaAtual = novaPostura;
            Console.WriteLine($"{this.Nome} entra na Postura {novaPostura}!");
        }

        public override void Atacar(Personagem alvo)
        {
            float multiplicador = 1.0f;
            if (PosturaAtual == PosturaGuerreiro.Ofensiva) multiplicador = 1.25f;
            if (PosturaAtual == PosturaGuerreiro.Defensiva) multiplicador = 0.75f;

            int danoFinal = (int)(this.ForcaDeAtaque * multiplicador);

            Console.WriteLine($"{this.Nome} (Postura {PosturaAtual}) ataca {alvo.Nome}!");
            alvo.ReceberDano(danoFinal, this.Tipo);
        }

        public new void ReceberDano(int danoBruto, TipoDePersonagem tipoAtacante)
        {
            float multiplicadorDefesa = 1.0f;
            if (PosturaAtual == PosturaGuerreiro.Defensiva)
            {
                multiplicadorDefesa = 0.60f; 
                Console.WriteLine($"{this.Nome} absorve o golpe com sua postura defensiva!");
            }

            base.ReceberDano((int)(danoBruto * multiplicadorDefesa), tipoAtacante);
        }
    }
}