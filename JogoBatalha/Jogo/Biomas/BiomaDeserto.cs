using JogoBatalha.Personagens.Inimigos.Deserto;
using System;

namespace JogoBatalha.Jogo.Biomas
{
    public class BiomaDeserto : Bioma
    {
        public BiomaDeserto()
            : base("Deserto de Fogo", "Dunas escaldantes guardadas por monstros de areia e lava.")
        {
            InimigosPossiveis.Add(() => new EscorpiaoDeLava());
            InimigosPossiveis.Add(() => new SalamandraDeFogo());
            InimigosPossiveis.Add(() => new DjinnDasAreias());
            InimigosPossiveis.Add(() => new BandidoDoDeserto());
            InimigosPossiveis.Add(() => new VermeDaAreia());
        }
    }
}