namespace JogoBatalha.Personagens.Inimigos
{
    public class Inimigo : Personagem
    {
        public Inimigo(string nome, int vida, int ataque, int defesa)
            : base(nome, vida, ataque, defesa, TipoDePersonagem.Inimigo)
        {
        }

    }
}