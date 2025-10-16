using JogoBatalha.Jogo;

namespace JogoBatalha
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new GameEngine();
            game.IniciarJogo();

            Console.WriteLine("\nPressione qualquer tecla para fechar...");
            Console.ReadKey();
        }
    }
}