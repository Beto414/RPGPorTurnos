using System;
using System.Collections.Generic;

namespace JogoBatalha.Habilidades.Arqueiro
{
    public class OlhosDeFalcao : Habilidade
    {
        public OlhosDeFalcao()
            : base("Olhos de Falcão", "Garante que o próximo ataque do alvo (aliado ou próprio) seja um acerto crítico.", TipoDeAlvo.Aliado)
        {
        }

        public override void Executar(Personagem usuario, Personagem alvo, List<Personagem> todosOsInimigos)
        {
            Console.WriteLine($"{usuario.Nome} usa {Nome}, focando sua mira em {alvo.Nome}!");
            alvo.AplicarEfeito(EfeitoDeStatus.CriticoGarantido, 2); 
        }
    }
}