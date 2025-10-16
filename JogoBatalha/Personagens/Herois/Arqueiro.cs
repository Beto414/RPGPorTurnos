using System;
using JogoBatalha.Habilidades;
using JogoBatalha.Habilidades.Arqueiro;

namespace JogoBatalha.Personagens.Herois
{
    public class Arqueiro : Personagem
    {
        public Arqueiro(string nome)
            : base(nome, 100, 18, 7, TipoDePersonagem.Arqueiro)
        {
            this.Habilidades.Add(new OlhosDeFalcao());
            this.Habilidades.Add(new ChuvaDeFlechas());
            this.Habilidades.Add(new FlechaExplosiva());
            this.Habilidades.Add(new FlechaElemental()); 
        }
        public override void Atacar(Personagem alvo)
        {
            Console.WriteLine($"{Nome} atira uma flecha em {alvo.Nome}!");
            int dano = ForcaDeAtaque;

            if (Efeitos.ContainsKey(EfeitoDeStatus.CriticoGarantido))
            {
                dano *= 2;
                Console.WriteLine("É um acerto crítico!");
                Efeitos.Remove(EfeitoDeStatus.CriticoGarantido); 
            }

            alvo.ReceberDano(dano, Tipo);
        }
    }
}