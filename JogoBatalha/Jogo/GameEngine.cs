using JogoBatalha.Jogo.Biomas;
using JogoBatalha.Personagens;
using JogoBatalha.Personagens.Herois;
using JogoBatalha.Personagens.Inimigos;
using JogoBatalha.Personagens.Inimigos.Deserto;
using JogoBatalha.Personagens.Inimigos.Floresta;
using JogoBatalha.Personagens.Inimigos.Gelo;
using JogoBatalha.Personagens.Inimigos.Pantano;
using JogoBatalha.Personagens.Inimigos.Ruinas;
using System;
using System.Collections.Generic;

namespace JogoBatalha.Jogo
{
    public class GameEngine
    {
        private readonly Mapa _mapa;
        private readonly GrupoDeHerois _grupoDeHerois;
        private readonly ArenaDeBatalha _arena;

        public GameEngine()
        {
            _mapa = new Mapa();
            _grupoDeHerois = new GrupoDeHerois();
            _arena = new ArenaDeBatalha();
        }

        public void IniciarJogo()
        {
            Console.WriteLine("=== A JORNADA PARA DERROTAR SAURON COMEÇA! ===");

            _grupoDeHerois.AdicionarHeroi(new Guerreiro("Aragorn"));
            _grupoDeHerois.AdicionarHeroi(new HabilidadesMago("Gandalf"));
            _grupoDeHerois.AdicionarHeroi(new Arqueiro("Legolas"));

            _mapa.IniciarJornada();

            for (int i = 0; i < 3; i++)
            {
                var biomaAtual = _mapa.GetBiomaAtual();
                Console.Clear();
                Console.WriteLine($"\n--- ESTÁGIO {i + 1}: ENTRANDO EM {biomaAtual.Nome.ToUpper()} ---");

                _mapa.NarrarEntradaDoBioma();
                Console.ReadKey();

                for (int j = 0; j < 3; j++)
                {
                    Console.Clear();
                    Console.WriteLine($"-- BATALHA {j + 1} de 3 em {biomaAtual.Nome} --");
                    var inimigos = biomaAtual.GerarEncontro();

                    _grupoDeHerois.ResetarPocoes();

                    bool vitoria = _arena.IniciarBatalha(_grupoDeHerois, inimigos);

                    if (!vitoria)
                    {
                        Console.WriteLine("\n--- GAME OVER ---");
                        Console.WriteLine("Seus heróis foram derrotados.");
                        return;
                    }

                    _mapa.NarrarVitoria();
                    Console.WriteLine("\nOs heróis descansam brevemente, recuperando um pouco de suas forças.");
                    _grupoDeHerois.Herois.ForEach(h => h.RecuperarVidaEMana(0.25));

                    Console.WriteLine("Pressione qualquer tecla para continuar a jornada...");
                    Console.ReadKey();
                }

                Console.Clear();
                Console.WriteLine($"-- CHEFE DO BIOMA: {biomaAtual.Nome.ToUpper()} --");
                Inimigo chefeDoBioma = GetChefeDoBioma(biomaAtual);
                Console.WriteLine($"Um guardião poderoso surge: {chefeDoBioma.Nome}!");

                if (!ExecutarBatalha(new List<Inimigo> { chefeDoBioma })) return;

                _mapa.NarrarVitoria();
                Console.WriteLine("\nApós a árdua batalha contra o guardião, os heróis recuperam todas as suas forças!");
                _grupoDeHerois.Herois.ForEach(h => h.RecuperarVidaEMana(1.0)); 

                Console.WriteLine("O guardião foi derrotado! O caminho se abre.");
                Console.ReadKey();

                if (i < 2)
                {
                    _mapa.ProximoEstagio();
                }
            }

            Console.Clear();
            Console.WriteLine("\n--- A TORRE NEGRA DE MORDOR ---");
            Console.WriteLine("Os heróis chegam ao covil de Sauron! A batalha final se aproxima...");
            Console.ReadKey();

            var sauron = new Sauron();
            if (ExecutarBatalha(new List<Inimigo> { sauron }))
            {
                Console.WriteLine("\n\n--- VITÓRIA FINAL! ---");
                Console.WriteLine("Sauron foi derrotado e a paz foi restaurada na Terra-média!");
            }
        }

        private bool ExecutarBatalha(List<Inimigo> inimigos)
        {
            bool vitoria = _arena.IniciarBatalha(_grupoDeHerois, inimigos);
            if (!vitoria)
            {
                Console.WriteLine("\n--- GAME OVER ---");
                Console.WriteLine("Seus heróis foram derrotados.");
                return false;
            }
            return true;
        }

        private Inimigo GetChefeDoBioma(Bioma bioma)
        {
            if (bioma is BiomaGelo) return new DragaoDeRaios();
            if (bioma is BiomaPantano) return new CobraGigante();
            if (bioma is BiomaDeserto) return new Saruman();
            if (bioma is BiomaFloresta) return new ElementalDeFogo();
            if (bioma is BiomaRuinas) return new ReiBruxoDeAngmar();

            throw new Exception("Bioma desconhecido, não foi possível encontrar o chefe.");
        }
    }
}