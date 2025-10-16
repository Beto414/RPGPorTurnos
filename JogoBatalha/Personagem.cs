using JogoBatalha.Habilidades;
using JogoBatalha.Personagens.Herois;
using System;
using System.Collections.Generic;

namespace JogoBatalha
{
    public enum TipoDePersonagem { Guerreiro, Mago, Arqueiro, Inimigo }
    public enum EfeitoDeStatus { Nenhum, Queimando, Congelado, Atordoado, ArmaduraQuebrada, BuffAtaque, BuffDefesa, CriticoGarantido }

    public abstract class Personagem
    {
        public string Nome { get; protected set; }
        public int PontosDeVidaMax { get; protected set; }
        public int PontosDeVida { get; protected set; }
        public int ForcaDeAtaque { get; protected set; }
        public int Defesa { get; protected set; }
        public TipoDePersonagem Tipo { get; protected set; }
        public bool EstaDefendendo { get; protected set; }
        public List<Habilidade> Habilidades { get; protected set; }
        public Dictionary<EfeitoDeStatus, int> Efeitos { get; private set; } 

        public Personagem(string nome, int vida, int ataque, int defesa, TipoDePersonagem tipo)
        {
            Nome = nome;
            PontosDeVidaMax = vida;
            PontosDeVida = vida;
            ForcaDeAtaque = ataque;
            Defesa = defesa;
            Tipo = tipo;
            Habilidades = new List<Habilidade>();
            Efeitos = new Dictionary<EfeitoDeStatus, int>();
        }

        public virtual void Atacar(Personagem alvo)
        {
            Console.WriteLine($"{this.Nome} ataca {alvo.Nome}!");
            alvo.ReceberDano(this.ForcaDeAtaque, this.Tipo); 
        }


        public void UsarHabilidade(int indiceHabilidade, Personagem alvo, List<Personagem> todosOsInimigos)
        {
            if (indiceHabilidade >= 0 && indiceHabilidade < Habilidades.Count)
            {
                Habilidades[indiceHabilidade].Executar(this, alvo, todosOsInimigos);
            }
            else
            {
                Console.WriteLine("Habilidade inválida!");
            }
        }

        public void Defender()
        {
            Console.WriteLine($"{this.Nome} está se defendendo!");
            EstaDefendendo = true;
        }

        public void ReceberDano(int danoBruto, TipoDePersonagem tipoAtacante)
        {
            float multiplicador = 1.0f;
            if ((this.Tipo == TipoDePersonagem.Guerreiro && tipoAtacante == TipoDePersonagem.Mago) ||
                (this.Tipo == TipoDePersonagem.Mago && tipoAtacante == TipoDePersonagem.Arqueiro) ||
                (this.Tipo == TipoDePersonagem.Arqueiro && tipoAtacante == TipoDePersonagem.Guerreiro))
            {
                multiplicador = 1.5f; 
                Console.WriteLine("É super efetivo!");
            }

            int danoModificado = (int)(danoBruto * multiplicador);

            int defesaAtual = this.Defesa;
            if (EstaDefendendo) defesaAtual *= 2;
            if (Efeitos.ContainsKey(EfeitoDeStatus.ArmaduraQuebrada)) defesaAtual = (int)(defesaAtual * 0.8);

            int danoFinal = danoModificado - defesaAtual;
            if (danoFinal < 1) danoFinal = 1; 

            this.PontosDeVida -= danoFinal;
            if (this.PontosDeVida < 0) this.PontosDeVida = 0;

            Console.WriteLine($"{this.Nome} recebe {danoFinal} de dano e agora tem {this.PontosDeVida} HP.");
        }

        public void AplicarEfeito(EfeitoDeStatus efeito, int duracao)
        {
            if (Efeitos.ContainsKey(efeito))
            {
                Efeitos[efeito] = duracao; 
            }
            else
            {
                Efeitos.Add(efeito, duracao);
            }
            Console.WriteLine($"{this.Nome} foi afetado por {efeito}!");
        }

        public virtual void ProcessarEfeitosDeTurno()
        {
            if (Efeitos.ContainsKey(EfeitoDeStatus.Queimando))
            {
                int danoQueimadura = (int)(this.PontosDeVidaMax * 0.15);
                this.PontosDeVida -= danoQueimadura;
                Console.WriteLine($"{this.Nome} está queimando e perde {danoQueimadura} HP.");
            }

            var chaves = new List<EfeitoDeStatus>(Efeitos.Keys);
            foreach (var efeito in chaves)
            {
                Efeitos[efeito]--;
                if (Efeitos[efeito] <= 0)
                {
                    Efeitos.Remove(efeito);
                    Console.WriteLine($"O efeito {efeito} em {this.Nome} acabou.");
                }
            }
        }

        public void PrepararProximoTurno()
        {
            EstaDefendendo = false;
        }

        public bool EstaVivo()
        {
            return PontosDeVida > 0;
        }

        public void Curar(int quantidade)
        {
            this.PontosDeVida += quantidade;
            if (this.PontosDeVida > this.PontosDeVidaMax)
            {
                this.PontosDeVida = this.PontosDeVidaMax;
            }
            Console.WriteLine($"{this.Nome} recupera {quantidade} HP!");
        }
        public void RecuperarVidaEMana(double porcentagem)
        {
            if (!this.EstaVivo()) return; 

            int cura = (int)(this.PontosDeVidaMax * porcentagem);
            this.PontosDeVida += cura;
            if (this.PontosDeVida > this.PontosDeVidaMax)
            {
                this.PontosDeVida = this.PontosDeVidaMax;
            }
            Console.WriteLine($"{this.Nome} recuperou {cura} HP.");

            if (this is HabilidadesMago mago)
            {
                int manaRecuperada = (int)(mago.PontosDeManaMax * porcentagem);
                mago.RecuperarMana(manaRecuperada);
            }
        }
    }
}