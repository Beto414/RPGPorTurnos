using JogoBatalha.Personagens;
using System.Collections.Generic;
using System.Linq;

namespace JogoBatalha.Jogo
{
    public class GrupoDeHerois
    {
        public List<Personagem> Herois { get; private set; }

        public int PocoesDeCura { get; private set; }

        public void ResetarPocoes()
        {
            PocoesDeCura = 3;
        }

        public bool UsarPocao()
        {
            if (PocoesDeCura > 0)
            {
                PocoesDeCura--;
                return true;
            }
            return false;
        }

        public GrupoDeHerois()
        {
            Herois = new List<Personagem>();
        }

        public void AdicionarHeroi(Personagem heroi)
        {
            Herois.Add(heroi);
        }

        public bool EstaoTodosMortos()
        {
            return Herois.All(h => !h.EstaVivo());
        }
    }
}