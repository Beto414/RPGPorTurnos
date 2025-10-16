using JogoBatalha.Personagens.Inimigos.Gelo;
using System;

namespace JogoBatalha.Jogo.Biomas
{
    public class BiomaGelo : Bioma
    {
        public BiomaGelo()
            : base("Floresta Congelada", "Uma floresta coberta de neve e gelo eterno.")
        {
            InimigosPossiveis.Add(() => new LoboDasNeves());
            InimigosPossiveis.Add(() => new GiganteDeGelo());
            InimigosPossiveis.Add(() => new ElementalDeGelo());
            InimigosPossiveis.Add(() => new UrsoPolarFeroz());
            InimigosPossiveis.Add(() => new FeiticeiraDoInverno());
        }
    }
}