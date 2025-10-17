using JogoBatalha.Habilidades;
using JogoBatalha.Personagens;
using JogoBatalha.Personagens.Herois;
using JogoBatalha.Personagens.Inimigos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace JogoBatalha.Jogo
{
    public class ArenaDeBatalha
    {
        private GrupoDeHerois _grupoDeHerois;

        public bool IniciarBatalha(GrupoDeHerois grupoDeHerois, List<Inimigo> inimigos)
        {
            _grupoDeHerois = grupoDeHerois;

            while (_grupoDeHerois.Herois.Any(h => h.EstaVivo()) && inimigos.Any(i => i.EstaVivo()))
            {
                foreach (var heroi in _grupoDeHerois.Herois.Where(h => h.EstaVivo()))
                {
                    Console.Clear();
                    ExibirStatus(_grupoDeHerois.Herois, inimigos);

                    heroi.PrepararProximoTurno();
                    heroi.ProcessarEfeitosDeTurno();
                    if (!heroi.EstaVivo()) continue;

                    if (heroi.Efeitos.ContainsKey(EfeitoDeStatus.Atordoado))
                    {
                        Console.WriteLine($"\n{heroi.Nome} está atordoado e não pode agir neste turno!");
                        Thread.Sleep(2500);
                        continue;
                    }

                    if (!inimigos.Any(i => i.EstaVivo())) break;

                    ExecutarTurnoDoHeroi(heroi, inimigos);
                    Thread.Sleep(2500);
                }

                if (!inimigos.Any(i => i.EstaVivo())) break;

                foreach (var inimigo in inimigos.Where(i => i.EstaVivo()))
                {
                    Console.Clear();
                    ExibirStatus(_grupoDeHerois.Herois, inimigos);

                    inimigo.PrepararProximoTurno();
                    inimigo.ProcessarEfeitosDeTurno();
                    if (!inimigo.EstaVivo()) continue;

                    if (inimigo.Efeitos.ContainsKey(EfeitoDeStatus.Atordoado))
                    {
                        Console.WriteLine($"\n{inimigo.Nome} está atordoado e não pode agir neste turno!");
                        Thread.Sleep(2500);
                        continue;
                    }

                    ExecutarTurnoDoInimigo(inimigo, _grupoDeHerois.Herois);
                    Thread.Sleep(2500);
                }
            }

            if (_grupoDeHerois.Herois.Any(h => h.EstaVivo()))
            {
                Console.Clear();
                ExibirStatus(_grupoDeHerois.Herois, inimigos);
                Console.WriteLine("\n--- VITÓRIA! ---");
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ExecutarTurnoDoHeroi(Personagem heroi, List<Inimigo> inimigos)
        {
            Console.WriteLine($"\nÉ a vez de {heroi.Nome}. O que fazer?");
            Console.WriteLine("1. Atacar");
            Console.WriteLine("2. Defender");
            Console.WriteLine("3. Usar Habilidade");
            Console.WriteLine($"4. Usar Poção de Cura ({_grupoDeHerois.PocoesDeCura} restantes)");
            Console.WriteLine("\n(Digite 'v' a qualquer momento para voltar ao menu de ações)");

            int? escolhaAcao = UserInput.GetInt("Escolha sua ação (1-4): ", 1, 4);

            if (escolhaAcao == null)
            {
                ExecutarTurnoDoHeroi(heroi, inimigos);
                return;
            }

            switch (escolhaAcao.Value)
            {
                case 1:
                    var alvoAtaque = EscolherAlvoInimigo(inimigos);
                    if (alvoAtaque == null) { ExecutarTurnoDoHeroi(heroi, inimigos); return; }
                    heroi.Atacar(alvoAtaque);
                    break;
                case 2:
                    heroi.Defender();
                    break;
                case 4:
                    if (_grupoDeHerois.UsarPocao())
                    {
                        Console.WriteLine("\nEscolha um aliado para curar:");
                        var alvoCura = EscolherAlvoAliado();
                        if (alvoCura == null)
                        {
                            _grupoDeHerois.DevolverPocao();
                            ExecutarTurnoDoHeroi(heroi, inimigos);
                            return;
                        }
                        int cura = (int)(alvoCura.PontosDeVidaMax * 0.40);
                        alvoCura.Curar(cura);
                    }
                    else
                    {
                        Console.WriteLine("Não há mais poções de cura! Escolha outra ação.");
                        Thread.Sleep(1500);
                        ExecutarTurnoDoHeroi(heroi, inimigos);
                    }
                    break;
                case 3:
                    Console.WriteLine("\nHabilidades disponíveis:");
                    for (int i = 0; i < heroi.Habilidades.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {heroi.Habilidades[i].Nome}");
                    }
                    int? escolhaHabilidade = UserInput.GetInt("Escolha a habilidade: ", 1, heroi.Habilidades.Count);
                    if (escolhaHabilidade == null) { ExecutarTurnoDoHeroi(heroi, inimigos); return; }

                    var habilidadeEscolhida = heroi.Habilidades[escolhaHabilidade.Value - 1];

                    Personagem alvoHabilidade;
                    if (habilidadeEscolhida.Alvo == TipoDeAlvo.Aliado)
                    {
                        Console.WriteLine("\nEscolha um aliado como alvo:");
                        alvoHabilidade = EscolherAlvoAliado();
                    }
                    else
                    {
                        alvoHabilidade = EscolherAlvoInimigo(inimigos);
                    }

                    if (alvoHabilidade == null) { ExecutarTurnoDoHeroi(heroi, inimigos); return; }

                    heroi.UsarHabilidade(escolhaHabilidade.Value - 1, alvoHabilidade, inimigos.Cast<Personagem>().ToList());
                    break;
            }
        }

        private Inimigo EscolherAlvoInimigo(List<Inimigo> inimigos)
        {
            var inimigosVivos = inimigos.Where(i => i.EstaVivo()).ToList();
            Console.WriteLine("\nEscolha o alvo:");
            for (int i = 0; i < inimigosVivos.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {inimigosVivos[i].Nome} (HP: {inimigosVivos[i].PontosDeVida})");
            }
            int? escolhaAlvo = UserInput.GetInt("Alvo: ", 1, inimigosVivos.Count);
            if (escolhaAlvo == null) return null;
            return inimigosVivos[escolhaAlvo.Value - 1];
        }

        private Personagem EscolherAlvoAliado()
        {
            var heroisVivos = _grupoDeHerois.Herois.Where(h => h.EstaVivo()).ToList();
            Console.WriteLine("\nEscolha o alvo:");
            for (int i = 0; i < heroisVivos.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {heroisVivos[i].Nome} (HP: {heroisVivos[i].PontosDeVida}/{heroisVivos[i].PontosDeVidaMax})");
            }
            int? escolhaAlvo = UserInput.GetInt("Alvo: ", 1, heroisVivos.Count);
            if (escolhaAlvo == null) return null;
            return heroisVivos[escolhaAlvo.Value - 1];
        }

        private void ExecutarTurnoDoInimigo(Inimigo inimigo, List<Personagem> herois)
        {
            Console.WriteLine($"\nÉ a vez de {inimigo.Nome}.");
            var heroisVivos = herois.Where(h => h.EstaVivo()).ToList();
            if (heroisVivos.Any())
            {
                Random random = new Random();
                var alvo = heroisVivos[random.Next(heroisVivos.Count)];
                inimigo.Atacar(alvo);
            }
        }

        private void ExibirStatus(List<Personagem> herois, List<Inimigo> inimigos)
        {
            Console.WriteLine("--- GRUPO DE HERÓIS ---");
            foreach (var heroi in herois)
            {
                string status = heroi.EstaVivo() ? $"HP: {heroi.PontosDeVida}/{heroi.PontosDeVidaMax}" : "DERROTADO";
                if (heroi is HabilidadesMago mago)
                {
                    status += $" | Mana: {mago.PontosDeMana}/{mago.PontosDeManaMax}";
                }
                Console.WriteLine($"{heroi.Nome}: {status}");
            }

            Console.WriteLine("\n--- INIMIGOS ---");
            foreach (var inimigo in inimigos.Where(i => i.EstaVivo()))
            {
                Console.WriteLine($"{inimigo.Nome}: HP: {inimigo.PontosDeVida}/{inimigo.PontosDeVidaMax}");
            }
            Console.WriteLine("--------------------------");
        }
    }
}