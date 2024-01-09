using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalLive.Net
{

    public class MainForm
    {
        public static void ShowMenu()
        {
            Console.WriteLine("1. Execute a chamada à API");
            Console.WriteLine("2. Outra opção");
            Console.WriteLine("3. Sair");
        }

        public static void Main()
        {
            bool exit = false;

            do
            {
                Console.WriteLine("Hello Everyone!!");
                Console.WriteLine("I'm GoalLive.Net");
                ShowMenu();
                Console.Write("Escolha uma opção: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        // Chame o método desejado ou insira o código aqui
                        Console.WriteLine("Chamando a API...");
                        Program.Main().GetAwaiter().GetResult();
                        break;

                    case "2":
                        // Adicione mais opções conforme necessário
                        Console.WriteLine("Opção 2 escolhida.");
                        break;

                    case "3":
                        exit = true;
                        Console.WriteLine("Saindo do programa.");
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }

                Console.WriteLine(); // Adiciona uma linha em branco para melhorar a formatação na console

            } while (!exit);
        }
    }
}