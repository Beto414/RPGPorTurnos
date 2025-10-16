using JogoBatalha.Personagens;
using JogoBatalha.Personagens.Inimigos;
using System;
using System.Collections.Generic;

namespace JogoBatalha.Jogo
{
    public abstract class Bioma
    {
        public string Nome { get; protected set; }
        public string Descricao { get; protected set; }

        protected List<Func<Inimigo>> InimigosPossiveis;

        public Bioma(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
            InimigosPossiveis = new List<Func<Inimigo>>();
        }

        public List<Inimigo> GerarEncontro()
        {
            var encontro = new List<Inimigo>();
            Random random = new Random();

            int numeroDeInimigos = random.Next(1, 4);

            Console.WriteLine($"\nUm grupo de {numeroDeInimigos} inimigo(s) aparece!");

            for (int i = 0; i < numeroDeInimigos; i++)
            {
                int indiceInimigo = random.Next(InimigosPossiveis.Count);

                Inimigo novoInimigo = InimigosPossiveis[indiceInimigo]();
                encontro.Add(novoInimigo);
                Console.WriteLine($"- Um {novoInimigo.Nome} selvagem surgiu!");
            }

            return encontro;
        }
    }
}