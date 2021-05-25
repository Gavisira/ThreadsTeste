using System;
using System.Collections;

namespace ThreadsTeste
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Controller.InitQueue();

            PrintValues(Mat.OrdersQueue);

            Controller.RunTheads();

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
