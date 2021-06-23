using System;
using System.Collections;
using ThreadsTeste.Controllers;

namespace ThreadsTeste
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            MainController.InitControllers();
            PrintValues(Mat.OrdersQueue);
            MainController.RunTheads();

        }

        public static void PrintValues(IEnumerable myCollection)
        {
            foreach (Order obj in myCollection)
                Console.WriteLine(" Obj da fila {0} Quantidade {1} Prioridade {2}", obj.ClientName, obj.ProductQuantity, obj.Deadline);
            Console.WriteLine();
        }

        public static void PrintColofull(string text, ConsoleColor color){
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
