using System.Collections.Generic;

namespace JogoBatalha.Habilidades
{
    public enum TipoDeAlvo
    {
        Inimigo,
        Aliado
    }

    public abstract class Habilidade
    {
        public string Nome { get; protected set; }
        public string Descricao { get; protected set; }
        public int CustoDeMana { get; protected set; }
        public TipoDeAlvo Alvo { get; protected set; } 
        public Habilidade(string nome, string descricao, TipoDeAlvo tipoAlvo, int custoDeMana = 0)
        {
            Nome = nome;
            Descricao = descricao;
            CustoDeMana = custoDeMana;
            Alvo = tipoAlvo;
        }

        public abstract void Executar(Personagem usuario, Personagem alvo, List<Personagem> todosOsInimigos);
    }
}