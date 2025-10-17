using JogoBatalha.Jogo.Biomas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JogoBatalha.Jogo
{
    public class Mapa
    {
        private List<Bioma> _biomasDaJornada;
        private int _estagioAtual = 0;

        private Dictionary<string, List<string>> _narrativasDisponiveis;
        private Dictionary<string, List<string>> _narrativasOriginais;

        public Mapa()
        {
            _biomasDaJornada = new List<Bioma>();
            InicializarNarrativas();
        }

        public void NarrarEntradaDoBioma()
        {
            string tipoBioma = GetBiomaAtual().GetType().Name.Replace("Bioma", "");
            string narrativaEntrada = "";

            if (tipoBioma == "Gelo")
            {
                narrativaEntrada = "O ar se torna gélido e a neve começa a cair densamente. Os heróis adentram a Floresta Congelada, onde o silêncio é quebrado apenas pelo estalar do gelo sob seus pés.";
            }
            else if (tipoBioma == "Pantano")
            {
                narrativaEntrada = "Um odor pútrido preenche o ar enquanto o grupo pisa em solo encharcado. Bem-vindos ao Pântano Sombrio, um lugar onde a luz do sol raramente toca o chão.";
            }
            else if (tipoBioma == "Deserto")
            {
                narrativaEntrada = "O calor é implacável e a areia se estende até onde a vista alcança. A jornada pelo Deserto de Fogo começou, e cada passo é um teste de resistência.";
            }
            Console.WriteLine(narrativaEntrada);
        }

        private void InicializarNarrativas()
        {
            _narrativasOriginais = new Dictionary<string, List<string>>
            {
                ["Gelo"] = new List<string>
                {
                    "Com os inimigos derrotados, os heróis encontram abrigo em uma caverna de gelo. As paredes cintilam com uma luz azulada enquanto eles descansam, recuperando o fôlego para o que está por vir.",
                    "A trilha os leva a uma ponte de gelo frágil sobre um abismo sem fundo. Com cuidado, eles cruzam, o vento uivante cantando uma canção sinistra ao seu redor.",
                    "Após a batalha, o grupo descobre as ruínas de um antigo posto avançado. Entre as pedras congeladas, eles encontram suprimentos antigos, mas ainda úteis, e um mapa que aponta para o coração da floresta.",
                    "A neve cessa por um momento, revelando um céu noturno repleto de estrelas desconhecidas. O silêncio da paisagem gelada é quebrado apenas pelo som de suas respirações, um lembrete de sua solidão nesta terra hostil.",
                    "Eles seguem as pegadas de uma criatura desconhecida, esperando que ela os leve para um caminho seguro. As pegadas os guiam por um vale escondido, onde o gelo assume formas estranhas e belas."
                },
                ["Pantano"] = new List<string>
                {
                    "Vitoriosos, os heróis navegam por um labirinto de manguezais. Raízes retorcidas emergem da água escura como garras, e o ar é pesado com o cheiro de decomposição e magia antiga.",
                    "Eles encontram uma clareira com uma cabana abandonada, afundando lentamente no lodo. Dentro, um diário antigo conta a história de um explorador que enlouqueceu, alertando sobre os horrores que se escondem nas profundezas.",
                    "A chuva ácida começa a cair, forçando o grupo a se abrigar sob um cogumelo gigante. As gotas sibilam ao tocar o chão, dissolvendo a vegetação e revelando ossos de criaturas menos afortunadas.",
                    "Seguindo uma luz fantasmagórica, eles descobrem um cemitério de barcos, navios antigos presos no pântano. O silêncio é assustador, e a sensação de estar sendo observado é constante.",
                    "O caminho se torna um rio de lodo espesso. Os heróis constroem uma jangada improvisada, remando lentamente através da escuridão, enquanto olhos brilhantes os observam da margem."
                },
                ["Deserto"] = new List<string>
                {
                    "Com a areia ainda manchada pela batalha, o grupo avança sob o sol escaldante. No horizonte, uma miragem dança, prometendo água e descanso, mas eles sabem que é apenas uma ilusão cruel do deserto.",
                    "Eles descobrem a carcaça de uma criatura colossal, seus ossos branqueados pelo sol. O esqueleto serve como um marco e um aviso sombrio do poder das bestas que habitam esta terra.",
                    "Uma tempestade de areia se aproxima, forçando-os a procurar abrigo em uma fenda rochosa. O vento uiva como um espírito atormentado, e a areia chicoteia a pedra, erodindo o mundo ao seu redor.",
                    "Ao anoitecer, o deserto se transforma. A temperatura cai drasticamente, e o céu se enche de estrelas brilhantes. Eles montam acampamento, revezando-se na vigília contra os predadores noturnos.",
                    "O grupo encontra um oásis escondido, uma joia de vida no meio da desolação. Eles reabastecem seus cantis e descansam à sombra das palmeiras, um breve momento de paz antes de continuar a jornada."
                },
                ["Floresta"] = new List<string>
    {
        "Após a batalha, os heróis encontram um riacho de águas cristalinas, cujas águas parecem restaurar um pouco de sua vitalidade.",
        "A trilha os leva a um círculo de pedras antigas que pulsam com uma energia serena. Descansar ali parece acelerar sua recuperação.",
        "O grupo avista um cervo branco espectral que os guia por um atalho seguro, longe dos olhos de mais inimigos.",
        "Sob a copa de uma árvore ancestral, eles encontram gravuras que contam histórias de heróis do passado, inspirando-os a continuar.",
        "A luz do sol se filtra pelas folhas, criando um espetáculo de luz e sombra que renova o ânimo do grupo para a próxima etapa."
    },
                ["Ruinas"] = new List<string>
    {
        "Entre os escombros, os heróis encontram um altar esquecido. Uma prece silenciosa parece fortalecer seus espíritos contra a escuridão.",
        "Eles decifram runas em uma parede desmoronada, aprendendo sobre uma fraqueza secreta dos mortos-vivos que habitam o local.",
        "Um vento fantasmagórico sopra pelos corredores, carregando sussurros de advertência que os ajudam a evitar uma armadilha mortal.",
        "O grupo encontra o diário de um antigo guarda, detalhando a queda da cidade. Sua coragem inspira os heróis a não cometerem os mesmos erros.",
        "Em uma câmara escondida, eles encontram um frasco de água benta, uma arma potente contra as criaturas profanas que os aguardam."
    }
            };
            _narrativasDisponiveis = new Dictionary<string, List<string>>(_narrativasOriginais);
        }

        public void IniciarJornada()
        {
            _estagioAtual = 0;
            _biomasDaJornada.Clear();
            _narrativasDisponiveis = _narrativasOriginais.ToDictionary(entry => entry.Key, entry => new List<string>(entry.Value));

            Random random = new Random();
            int primeiroBioma = random.Next(3);
            if (primeiroBioma == 0) _biomasDaJornada.Add(new BiomaGelo());
            else if (primeiroBioma == 1) _biomasDaJornada.Add(new BiomaPantano());
            else _biomasDaJornada.Add(new BiomaDeserto());
        }

        public Bioma GetBiomaAtual()
        {
            return _biomasDaJornada[_estagioAtual];
        }

        public bool ProximoEstagio()
        {
            _estagioAtual++;
            if (_estagioAtual >= 3) return false;

            ApresentarEncruzilhada();
            return true;
        }

        private void ApresentarEncruzilhada()
        {
            Console.WriteLine("\nApós derrotar o guardião, os heróis chegam a uma encruzilhada.");

            var todosOsBiomas = new List<Bioma> { new BiomaGelo(), new BiomaPantano(), new BiomaDeserto(), new BiomaFloresta(), new BiomaRuinas() };
            var biomasVisitados = _biomasDaJornada.Select(b => b.GetType()).ToList();
            var biomasDisponiveis = todosOsBiomas.Where(b => !biomasVisitados.Contains(b.GetType())).ToList();

            Console.WriteLine("Caminhos inéditos se abrem à frente:");
            for (int i = 0; i < biomasDisponiveis.Count; i++)
            {
                Console.WriteLine($"{i + 1}. O caminho de {biomasDisponiveis[i].Nome}.");
            }

            int? escolha = null;
            while (escolha == null)
            {
                escolha = UserInput.GetInt($"Escolha o próximo caminho (1-{biomasDisponiveis.Count}): ", 1, biomasDisponiveis.Count);
                if (escolha == null)
                {
                    Console.WriteLine("Ação inválida neste menu. Por favor, escolha um caminho.");
                }
            }

            _biomasDaJornada.Add(biomasDisponiveis[escolha.Value - 1]);
        }

        public void NarrarVitoria()
        {
            string tipoBioma = GetBiomaAtual().GetType().Name.Replace("Bioma", "");
            if (_narrativasDisponiveis.ContainsKey(tipoBioma) && _narrativasDisponiveis[tipoBioma].Any())
            {
                Random random = new Random();
                int indice = random.Next(_narrativasDisponiveis[tipoBioma].Count);
                string narrativa = _narrativasDisponiveis[tipoBioma][indice];

                Console.WriteLine($"\n{narrativa}\n");

                _narrativasDisponiveis[tipoBioma].RemoveAt(indice);
            }
        }
    }
}