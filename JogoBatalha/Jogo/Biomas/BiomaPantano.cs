using JogoBatalha.Personagens.Inimigos.Pantano;
using System;

namespace JogoBatalha.Jogo.Biomas
{
    public class BiomaPantano : Bioma
    {
        public BiomaPantano()
            : base("Pântano Sombrio", "Um brejo fétido e cheio de criaturas perigosas.")
        {
            InimigosPossiveis.Add(() => new CrocodiloMutante());
            InimigosPossiveis.Add(() => new CobraVenenosa());
            InimigosPossiveis.Add(() => new LimoAcido());
            InimigosPossiveis.Add(() => new EnxameDeInsetos());
            InimigosPossiveis.Add(() => new TrollDoPantano());
        }
    }
}