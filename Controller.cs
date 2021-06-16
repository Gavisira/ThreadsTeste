using System;
using System.Collections.Generic;
using System.Threading;

namespace ThreadsTeste
{
    public class Controller
    {
        public static Thread Mat01 = new Thread(new Mat().Run);
        public static Thread Mat02 = new Thread(new Mat().Run);
        public static Thread Main = new Thread(Run);
        public static bool ProcessStarts = false;
        public static void StartProcess() => ProcessStarts = true;
        public static void StopProcess() => ProcessStarts = false;

        public static void Run()
        {
            while (ProcessStarts)
            {
                var input = Console.ReadLine();
                if (input == "0") StopProcess();
                if (input == "2")
                {
                    StopProcess();
                    var quant = Console.ReadLine();
                    var orders  = Load(int.Parse(quant));
                    Mat.Enqueue(orders, true);
                    Program.PrintValues(Mat.OrdersQueue);
                    RestartProcess();
                }
            }
        }

        public static void RunTheads()
        {
            StartProcess();

            Mat01.Start();
            Mat02.Start();
            Main.Start();
        }

        public static void InitQueue()
        {
            //Mat.Enqueue(Order.OrderByDeadlineAndQuantity(ReadFile.ReadOrdersList("./dados/Empacotadeira.txt")));
            Mat.Enqueue(Order.OrderByDeadlineAndQuantity(ReadFile.ReadOrdersList("./data/Teste1.txt")));
        }
        public static List<Order> Load(int quantity)
        {
            var newOrders = new List<Order>();
            for (int i = 0; i < quantity; i++)
            {
                var line = Console.ReadLine();
                newOrders.Add(GetOrderByLine(line));
            }

            return newOrders;
        }

        public static void RestartProcess()
        {
            ProcessStarts = true;
            if (Mat01.ThreadState == ThreadState.Stopped)
            {
                Mat01 = new Thread(new Mat().Run);
                Mat01.Start();
            }
            if (Mat02.ThreadState == ThreadState.Stopped)
            {
                Mat02 = new Thread(new Mat().Run);
                Mat02.Start();
            }
        }

        public static Order GetOrderByLine(string line){
            string[] splitter = line.Split(";");

            return new Order(
                splitter[0],
                int.Parse(splitter[1]), 
                int.Parse(splitter[2]) == 0? int.MaxValue : int.Parse(splitter[2])
            );
        }


    }
}