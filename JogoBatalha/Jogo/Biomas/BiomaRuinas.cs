using JogoBatalha.Personagens.Inimigos.Ruinas;
namespace JogoBatalha.Jogo.Biomas
{
    public class BiomaRuinas : Bioma
    {
        public BiomaRuinas()
            : base("Ruínas Sombrias", "Os restos de uma cidade amaldiçoada, onde os mortos não descansam.")
        {
            InimigosPossiveis.Add(() => new EsqueletoReanimado());
            InimigosPossiveis.Add(() => new EspectroDrenante());
            InimigosPossiveis.Add(() => new GargulaDePedra());
            InimigosPossiveis.Add(() => new AcolitoDasSombras());
            InimigosPossiveis.Add(() => new CavaleiroCaido());
        }
    }
}