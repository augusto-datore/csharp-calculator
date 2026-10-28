using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        string opcao = "";

        while (opcao != "0")
        {
            Console.WriteLine("CALCULADORA C#");
            Console.WriteLine(" 1 - Adição");
            Console.WriteLine(" 2 - Subtração");
            Console.WriteLine(" 3 - Multiplicação");
            Console.WriteLine(" 4 - Divisão");
            Console.WriteLine(" 5 - Potenciação");
            Console.WriteLine(" 6 - Raiz quadrada");
            Console.WriteLine(" 7 - Porcentagem");
            Console.WriteLine(" 0 - Sair");
            Console.Write("\nEscolha uma opção: ");

            string entradaOpcao = Console.ReadLine();

            if (entradaOpcao == null)
            {
                break;
            }

            opcao = entradaOpcao;

            if (opcao == "0")
            {
                Console.WriteLine("\nCalculadora encerrada.\n");
                break;
            }

            if (opcao != "1" && opcao != "2" &&
                opcao != "3" && opcao != "4" &&
                opcao != "5" && opcao != "6" &&
                opcao != "7")
            {
                Console.WriteLine("\nEscolha um número no menu.\n");
                continue;
            }

            double n1 = 0;
            double n2 = 0;
            double resultado = 0;

            Console.Write("Digite o primeiro número: ");
            string entrada1 = Console.ReadLine();

            if (entrada1 == null ||
                !double.TryParse(
                    entrada1.Replace(',', '.'),
                    NumberStyles.Float,
                    CultureInfo.InvariantCulture,
                    out n1) ||
                double.IsNaN(n1) || double.IsInfinity(n1))
            {
                Console.WriteLine("\nDigite um número válido.\n");
                continue;
            }

            if (opcao != "6")
            {
                Console.Write("Digite o segundo número: ");

                string entrada2 = Console.ReadLine();

                if (entrada2 == null ||
                    !double.TryParse(
                        entrada2.Replace(',', '.'),
                        NumberStyles.Float,
                        CultureInfo.InvariantCulture,
                        out n2) ||
                    double.IsNaN(n2) || double.IsInfinity(n2))
                {
                    Console.WriteLine("\nDigite um número válido.\n");
                    continue;
                }
            }

            switch (opcao)
            {
                case "1":
                    resultado = n1 + n2;
                    break;

                case "2":
                    resultado = n1 - n2;
                    break;

                case "3":
                    resultado = n1 * n2;
                    break;

                case "4":
                    if (n2 == 0)
                    {
                        Console.WriteLine("\nNão é permitido divisão por zero.\n");
                        continue;
                    }

                    resultado = n1 / n2;
                    break;

                case "5":
                    resultado = Math.Pow(n1, n2);
                    break;

                case "6":
                    if (n1 < 0)
                    {
                        Console.WriteLine("\nNão é possível calcular a raiz quadrada real de um número negativo.\n");
                        continue;
                    }

                    resultado = Math.Sqrt(n1);
                    break;

                case "7":
                    resultado = (n1 * n2) / 100;
                    break;
            }

            if (double.IsNaN(resultado) || double.IsInfinity(resultado))
            {
                Console.WriteLine("\nO resultado não pode ser representado.\n");
            }
            else
            {
                Console.WriteLine("\nResultado: " + resultado.ToString("G15", new CultureInfo("pt-BR")));
                Console.WriteLine("");
            }
        }
    }
}
