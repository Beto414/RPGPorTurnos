using System;

namespace JogoBatalha
{
    public static class UserInput
    {
        public static double GetDouble(string prompt)
        {
            double number;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (double.TryParse(input, out number))
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Por favor, digite um número válido.");
                }
            }
        }

        public static int? GetInt(string prompt, int min, int max)
        {
            int number;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine().ToLower();

                if (input == "v")
                {
                    return null; 
                }

                if (int.TryParse(input, out number) && number >= min && number <= max)
                {
                    return number;
                }
                else
                {
                    Console.WriteLine($"Entrada inválida. Por favor, digite um número entre {min} e {max}, ou 'v' para voltar.");
                }

            }
        }
    }
}