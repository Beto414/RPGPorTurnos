using JogoBatalha.Personagens.Inimigos.Floresta;
namespace JogoBatalha.Jogo.Biomas
{
    public class BiomaFloresta : Bioma
    {
        public BiomaFloresta()
            : base("Floresta Encantada", "Uma floresta antiga, banhada em luz e sombras misteriosas.")
        {
            InimigosPossiveis.Add(() => new LoboSombrio());
            InimigosPossiveis.Add(() => new SpriteTravesso());
            InimigosPossiveis.Add(() => new AranhaGigante());
            InimigosPossiveis.Add(() => new EntProtetor());
            InimigosPossiveis.Add(() => new DruidaCorrompido());
        }
    }
}